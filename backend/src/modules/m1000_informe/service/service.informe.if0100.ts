import { clsBase, clsTools } from "../../../model/modelbase";


import InformeMailset from "../model/model.informe_mailset";



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 101000010
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M1000-INFORME(service.IF0100.ts - VENDAS)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    




export default class serviceinforme_if0100 {

    static async start(parametros: any) { 
        try { 

            let par = parametros

            par.email_subervisao = "distribuicao@oxan.com.br"
            let mailset = new InformeMailset()
            mailset.getDistribuicaoDestinatarios(par)
            par.mail_cc = mailset.mail_cc
            par.mail_bcc = mailset.mail_bcc
            par.email_subervisao = mailset.email_subervisao



            par.fv_fab_meta_cd = 2026001


            par.seqinterface = 0
            await clsTools.pagConsole(`${FLG_MODULO} - Inicializando envio de E-MAIL - Coletando Parâmetros`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getParametros(par)

            
            

            await clsTools.pagConsole(`${FLG_MODULO} - Processando VENDA POR VENDEDOR/FABRICANTE`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getBaseVendaPorFabricante(par)
            await clsTools.pagConsole(`${FLG_MODULO} - Processamento VENDA POR VENDEDOR/FABRICANTE Concluído _ QTDE DE REG ${par.listVendaFabricante.length}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)



            await clsTools.pagConsole(`${FLG_MODULO} - Processando VENDA POR Meta Vendedor`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getQuadroMetasVendedor(par)


            await clsTools.pagConsole(`${FLG_MODULO} - Processando VENDA META COLUMNS`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getQuadroSupervisaoMetaVendedorColumns(par)


            await clsTools.pagConsole(`${FLG_MODULO} - Processando VENDA Supervisao`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getQuadroSupervisaoMetaVendedor(par)


            await clsTools.pagConsole(`${FLG_MODULO} - Enviando E-mail para os vendedores`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.sendMailVendedor(par)
            await clsTools.pagConsole(`${FLG_MODULO} - Enviando E-mail para os supervisores`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            await this.sendMailSupervisor(par)


            await clsTools.pagConsole(`${FLG_MODULO} - Processo concluído`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)






        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "start (service.if0045)", e)
        }
    }

    static async getParametros(parametros: any) : Promise<any>{
        let par = parametros
        try {

                const dataFaturamentoObter = (stringData: string) => {
                    return  clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(stringData, 'YYYY-MM-DD HH:mm:ss'), 'YYYY-MM-DD')
                }

                const dataRelatorio = (stringData: string) => { 
                    return  clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(stringData, 'YYYY-MM-DD HH:mm:ss'), 'DD/MM/YYYY')
                }



                if (!par.competencia_cd) {
                    const hoje = new Date();
                    par.competencia_cd = `${hoje.getFullYear()}${String(hoje.getMonth() + 1).padStart(2, '0')}`;
                }



                let sql = `SELECT 	competencia_data_ini
                                ,	competencia_data_fim
                                ,   competencia_cd
                            FROM tbcompetencia 
                            where competencia_cd = ${par.competencia_cd}
                `
                let result = await this.__db(sql)
                if (result) {
                    let rowCompetencia = (result as any[])[0]
                    par.competencia_cd = rowCompetencia.competencia_cd
                    par.competencia_data_ini = dataFaturamentoObter(rowCompetencia.competencia_data_ini)
                    par.competencia_data_fim = dataFaturamentoObter(rowCompetencia.competencia_data_fim)
                }

                let mailset = new InformeMailset()
                mailset.getDistribuicaoDestinatarios(par)
                par.mail_cc = mailset.mail_cc
                par.mail_bcc = mailset.mail_bcc
                par.email_subervisao = mailset.email_subervisao
                par.periodo_descricao = `${dataRelatorio(par.competencia_data_ini)} a ${dataRelatorio(par.competencia_data_fim)} (CMP ${par.competencia_cd})`




        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getParametros (service.if0045)", e)
        }
        return par
    }

    static async getBaseVendaPorFabricante(parametros: any) : Promise<any>{
        let par = parametros
        try {

            let sql = `
                   SELECT  	    a.CdParticipanteVendedor
                            ,	v.nome_razao as nome_vendedor
                            ,   pv.vendedor_status 
                            ,   coalesce(p.email_main, 'distribuicao@oxan.com.br') as email_vendedor
                            ,	sum(case when fabricante = 'PRINCIPAL' then positivacao else 0 end ) as johson_positivacao
                            ,	sum(case when fabricante = 'PRINCIPAL' then embalagemcompraqtde else 0 end ) as johson_embalagemcompra
                            ,	sum(case when fabricante = 'PRINCIPAL' then valortotalfaturamento else 0 end ) as johson_valortotalfaturamento

                            ,	sum(case when fabricante = 'SEMPREMIO' then positivacao else 0 end ) as sempremio_positivacao
                            ,	sum(case when fabricante = 'SEMPREMIO' then embalagemcompraqtde else 0 end ) as sempremio_embalagemcompra
                            ,	sum(case when fabricante = 'SEMPREMIO' then valortotalfaturamento else 0 end ) as sempremio_valortotalfaturamento

                            ,	sum(case when fabricante = 'PREMIOINDUSTRIA' then positivacao else 0 end ) as premioindustria_positivacao
                            ,	sum(case when fabricante = 'PREMIOINDUSTRIA' then embalagemcompraqtde else 0 end ) as premioindustria_embalagemcompra
                            ,	sum(case when fabricante = 'PREMIOINDUSTRIA' then valortotalfaturamento else 0 end ) as premioindustria_valortotalfaturamento

                            ,	sum(case when fabricante = 'OUTROS' then positivacao else 0 end ) as outros_positivacao
                            ,	sum(case when fabricante = 'OUTROS' then embalagemcompraqtde else 0 end ) as outros_embalagemcompra
                            ,	sum(case when fabricante = 'OUTROS' then valortotalfaturamento else 0 end ) as outros_valortotalfaturamento
                    FROM (
                        SELECT		
                                        F.CdParticipanteVendedor	
                                    ,   COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
                                    ,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
                                            when 1010 then 'PRINCIPAL' 
                                            when 1020 then 'SEMPREMIO' 
                                            when 1025 then 'PREMIOINDUSTRIA' 
                                            when 0 then  'OUTROS'
                                            else 'OUTROS'
                                            end as fabricante 			
                                    ,	count(distinct(F.CdParticipanteCliente )) as positivacao
                                    ,	SUM(cast(I.EmbalagemEstoqueQtde as numeric(13,1))) as embalagemestoqueqtde
                                    ,	SUM(cast(I.EmbalagemCompraQtde as numeric(13,1))) as embalagemcompraqtde
                                    ,	SUM(cast(I.ValorTotalFaturamento as numeric(13,2))) as valortotalfaturamento

                        FROM		TbFaturamento				f
                        INNER JOIN	TbFaturamentoOrigem			o on o.SeqFaturamento = f.SeqFaturamento 
                        INNER JOIN	TbFaturamentoItens			i on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
                        INNER JOIN  tbproduto  					pr on pr.pr_cdproduto = i.pr_cdproduto 
                        inner join  tbprodutobluesoft		   prb on prb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
                        left join   tbparticipante_bluesoft      c on c.cdparticipante = f.cdparticipantecliente
                        left join   tbgrupoeconomico g on g.cdgrupoeconomico = c.cdgrupoeconomico
                        LEFT JOIN   (	select 		i.fv_fabricante_cdpessoabluesoft
                                                , 	i.fv_fabricante_info_tipo_cd 
                                                , 	t.fv_fabricante_info_tipo_descricao 
                                        from  tbforca_venda_fabricante_info i
                                        inner join   tbforca_venda_fabricante_info_tipo t on t.fv_fabricante_info_tipo_cd = i.fv_fabricante_info_tipo_cd
                                        where fv_fabricante_info_status = 1
                                        and  t.fv_fabricante_info_tipo_cd in (1010, 1025, 1020) 
                                        ) TPF ON TPF.fv_fabricante_cdpessoabluesoft = prb.prb_cdpessoabluesoft_fabricante 
                        WHERE		1 = 1
                        AND			F.em_cdempresa = 1
                        AND			F.op_cdoperacao  = 1
                        AND			f.StatusFaturamento  = 1
                        and			i.StatusFaturamentoItem = 1
                        AND			F.DataFaturamento >= '${par.competencia_data_ini}'
                        AND			F.DataFaturamento <= '${par.competencia_data_fim}' 
                        GROUP BY	F.CdParticipanteVendedor	

                                    ,  	 COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
                                    ,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
                                            when 1010 then 'PRINCIPAL' 
                                            when 1020 then 'SEMPREMIO' 
                                            when 1025 then 'PREMIOINDUSTRIA' 
                                            when 0 then  'OUTROS'
                                            else 'OUTROS'
                                            end 										 

                    ) A
                    left join tbparticipante_bluesoft v on v.cdparticipante = a.CdParticipanteVendedor
                    left join tbparticipante_vendedor pv on pv.cdparticipante = a.CdParticipanteVendedor
                    left join tbparticipante p on p.cdparticipante = a.CdParticipanteVendedor

                      
                    group by  a.CdParticipanteVendedor
                            ,	v.nome_razao 
                            ,   pv.vendedor_status 
                            ,   coalesce(p.email_main, 'distribuicao@oxan.com.br') 

						 
            
            `
            
            let result = await this.__db(sql)
            par.listVendaFabricante = result as any[]
            
     
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "processarRelatorioBaseReal (service.if0045)", e)
        }
        finally {
            return par
        }
    }

    static async getQuadroMetasVendedor(parametros: any) : Promise<any> {
        let par: any = parametros
        try {
            let sql = `
                                select 		v.fv_meta_cdparticipantevendedor 
                                        ,	v.fv_meta_cd
                                        ,   m.fv_meta_descricao 
                                        ,   COALESCE(v.fv_meta_rq_pos,0)  as fv_meta_rq_pos_minimo
                                        ,   COALESCE(v.fv_meta_rq_pos,0)         as fv_meta_rq_pos
                                        ,   COALESCE(v.fv_meta_rz_pos,0)         as fv_meta_rz_pos
                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde
                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde_maximo
                                        ,   COALESCE(v.fv_meta_rz_qtde,0)        as fv_meta_rz_qtde
                                        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor
                                        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor_maximo
                                        ,   COALESCE(v.fv_meta_rz_valor,0)       as fv_meta_rz_valor
                                        ,   COALESCE(v.fv_meta_bonus_percentual,0)    as fv_meta_bonus_percentual
                                from 		tbforca_venda_meta_vendedor v
                                inner join 	tbforca_venda_meta m on m.fv_meta_cd = v.fv_meta_cd
                                where       m.competencia_cd = ${par.competencia_cd}
                                order by    v.fv_meta_cdparticipantevendedor, v.fv_meta_cd
            
            `
            let result = await this.__db(sql)
            par.listQuadroMetasVendedor = result as any[]



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getQuadroMetasVendedor", e)
        }
        finally {
            return par
        }
    }

    static async getQuadroSupervisaoMetaVendedorColumns(parametro: any) : Promise<any> {
        let par = parametro
        try {
            let string_sql = `
                        SELECT 		ROW_NUMBER() OVER (ORDER BY fv_meta_cd) AS RO
                                ,	fv_meta_cd
                                , 	fv_meta_descricao 
                        FROM 	tbforca_venda_meta 
                        WHERE 	competencia_cd = ${par.competencia_cd}
                        ORDER BY fv_meta_cd
            
            `
            let result = await this.__db(string_sql)
            par.MetasVendedorListGeralColumns = result as any[]
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getQuadroSupervisaoMetaVendedorColumns (Service.if0100)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
        }
        finally {
            return par
        }
    }

    static async getQuadroSupervisaoMetaVendedor(parametro: any) : Promise<any> {
        let par = parametro
        try {
                let sql =  `
                
                select 		v.cdparticipante 
                        ,   b.nome_razao
                        ,   coalesce(fv01.fv_meta_rq_pos, 0)				 as fv01_meta_rq
                        ,   coalesce(fv01.fv_meta_rz_pos, 0) 				 as fv01_meta_rz
                        ,   coalesce(fv01.fv_meta_bonus_percentual, 0) 		 as fv01_meta_bonus_percentual
                        ,   coalesce(fv01.fv_meta_base_valor, 0)             as fv01_meta_base_valor
                        ,   coalesce(fv01.fv_meta_resultado_valor, 0)        as fv01_meta_resultado_valor

                        ,	coalesce(fv02.fv_meta_rq_qtde ,0)				 as fv02_meta_rq
                        ,	coalesce(fv02.fv_meta_rz_qtde, 0) 				 as fv02_meta_rz
                        ,	coalesce(fv02.fv_meta_bonus_percentual,0) 		 as fv02_meta_bonus_percentual
                        ,	coalesce(fv02.fv_meta_base_valor, 0)  			 as fv02_meta_base_valor
                        ,	coalesce(fv02.fv_meta_resultado_valor, 0) 		 as fv02_meta_resultado_valor

                        , coalesce(fv03.fv_meta_rq_pos ,0)				     as fv03_meta_rq
                        , coalesce(fv03.fv_meta_rz_pos, 0) 				     as fv03_meta_rz
                        , coalesce(fv03.fv_meta_bonus_percentual,0) 		 as fv03_meta_bonus_percentual
                        , coalesce(fv03.fv_meta_base_valor, 0)  			 as fv03_meta_base_valor
                        , coalesce(fv03.fv_meta_resultado_valor, 0) 		 as fv03_meta_resultado_valor

                        , coalesce(fv04.fv_meta_rq_valor, 0)				 as fv04_meta_rq
                        , coalesce(fv04.fv_meta_rz_valor, 0) 				 as fv04_meta_rz
                        , coalesce(fv04.fv_meta_bonus_percentual, 0) 		 as fv04_meta_bonus_percentual
                        , coalesce(fv04.fv_meta_base_valor, 0)  			 as fv04_meta_base_valor
                        , coalesce(fv04.fv_meta_resultado_valor, 0) 		 as fv04_meta_resultado_valor

                        , coalesce(fv05.fv_meta_rq_qtde, 0)				     as fv05_meta_rq
                        , coalesce(fv05.fv_meta_rz_qtde, 0) 				 as fv05_meta_rz
                        , coalesce(fv05.fv_meta_bonus_percentual, 0) 		 as fv05_meta_bonus_percentual
                        , coalesce(fv05.fv_meta_base_valor, 0)  			 as fv05_meta_base_valor
                        , coalesce(fv05.fv_meta_resultado_valor, 0) 		 as fv05_meta_resultado_valor
                        
                        , coalesce(fv06.fv_meta_rq_valor, 0)				 as fv06_meta_rq
                        , coalesce(fv06.fv_meta_rz_valor, 0) 				 as fv06_meta_rz
                        , coalesce(fv06.fv_meta_bonus_percentual, 0) 		 as fv06_meta_bonus_percentual
                        , coalesce(fv06.fv_meta_base_valor, 0)  			 as fv06_meta_base_valor
                        , coalesce(fv06.fv_meta_resultado_valor, 0) 		 as fv06_meta_resultado_valor

                        ,  coalesce(fv01.fv_meta_resultado_valor, 0)  +
                        coalesce(fv02.fv_meta_resultado_valor, 0)  +
                        coalesce(fv03.fv_meta_resultado_valor, 0)  +
                        coalesce(fv04.fv_meta_resultado_valor, 0)  +
                        coalesce(fv05.fv_meta_resultado_valor, 0)  +
                        coalesce(fv06.fv_meta_resultado_valor, 0)  		as total_meta_resultado_valor

                from 		tbparticipante_vendedor 	v
                inner join 	tbparticipante_bluesoft 	b on b.cdparticipante = v.cdparticipante
                left join   tbforca_venda_meta_vendedor fv01 on fv01.fv_meta_cdparticipantevendedor = v.cdparticipante and fv01.fv_meta_cd = ${par.MetasVendedorListGeralColumns[0].fv_meta_cd}
                left join   tbforca_venda_meta_vendedor fv02 on fv02.fv_meta_cdparticipantevendedor = v.cdparticipante and fv02.fv_meta_cd = ${par.MetasVendedorListGeralColumns[1].fv_meta_cd}
                left join   tbforca_venda_meta_vendedor fv03 on fv03.fv_meta_cdparticipantevendedor = v.cdparticipante and fv03.fv_meta_cd = ${par.MetasVendedorListGeralColumns[2].fv_meta_cd}
                left join   tbforca_venda_meta_vendedor fv04 on fv04.fv_meta_cdparticipantevendedor = v.cdparticipante and fv04.fv_meta_cd = ${par.MetasVendedorListGeralColumns[3].fv_meta_cd}
                left join   tbforca_venda_meta_vendedor fv05 on fv05.fv_meta_cdparticipantevendedor = v.cdparticipante and fv05.fv_meta_cd = ${par.MetasVendedorListGeralColumns[4].fv_meta_cd}
                left join   tbforca_venda_meta_vendedor fv06 on fv06.fv_meta_cdparticipantevendedor = v.cdparticipante and fv06.fv_meta_cd = ${par.MetasVendedorListGeralColumns[5].fv_meta_cd}

                where       v.vendedor_status = 1
                order by    b.nome_razao asc

               
                
                `

            let result = await this.__db(sql)
            par.listQuadroMetasVendedorResumo = result as any[]




        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getQuadroSupervisaoMetaVendedor (Service.if0100)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
        }
        finally {
            return par
        }
    }


  static async sendMailVendedor(parametros: any) : Promise<any> {
 let par: any = parametros
        try {

            const lista: any[] = (par.listVendaFabricante || []).filter((vendedor: any) => Number(vendedor.vendedor_status) === 1)
            const listaMetas: any[] = Array.isArray(par.listQuadroMetasVendedor) ? par.listQuadroMetasVendedor : []


            if (lista.length === 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | sendMailVendedor | Sem dados para envio`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                return par
            }

            const num = (v: any) => Number(v) || 0
            const fmt = (v: any, d: number = 2) => num(v).toLocaleString("pt-BR", { minimumFractionDigits: d, maximumFractionDigits: d })

            const TD  = `style="border:1px solid #000;padding:2px 4px;font-size:11px;"`
            const TDR = `style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:right;"`
            const TDY = `style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:right;background:#ffff00;"`
            const TH  = `style="border:1px solid #000;padding:3px 4px;font-size:11px;color:#0000cc;text-align:center;font-weight:bold;"`

            const periodo = par.periodo_descricao

            const buildQuadroMetas = (cdvendedor: any): string => {
                const metas = listaMetas.filter(meta =>
                    String(meta.fv_meta_cdparticipantevendedor) === String(cdvendedor)
                )

                if (metas.length === 0) return ""

                const tdMeta = (valor: any, casasDecimais: number, alinhar = "right"): string => {
                    const valorNumerico = num(valor)
                    const destaque = valorNumerico === 0 ? "background:#ffff00;" : ""
                    const texto = valorNumerico.toLocaleString("pt-BR", {
                        minimumFractionDigits: casasDecimais,
                        maximumFractionDigits: casasDecimais,
                    })
                    return `<td style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:${alinhar};${destaque}">${texto}</td>`
                }

                const header = (texto: string, colspan = 1, rowspan = 1): string =>
                    `<td colspan="${colspan}" rowspan="${rowspan}" ${TH}>${texto}</td>`

                let html = `
                    <div style="font-family:Arial,sans-serif;margin-top:16px;font-size:12px;">RELATÓRIO PRELIMINAR DE METAS</div>
                    <table style="border-collapse:collapse;border:1px solid #000;margin-top:4px;">
                        <tr><td colspan="12" ${TH} style="border:1px solid #000;padding:6px;font-size:12px;text-align:center;font-weight:bold;">Relatório de Metas - ${periodo}</td></tr>
                        <tr>
                            ${header("Meta", 1, 2)}
                            ${header("Descrição", 1, 2)}
                            ${header("POS", 3)}
                            ${header("VOLUME", 3)}
                            ${header("VALOR", 3)}
                            ${header("Bonus", 1, 2)}
                        </tr>
                        <tr>
                            ${header("Requisito Min")}
                            ${header("Meta")}
                            ${header("Realizado")}
                            ${header("Requisito Min")}
                            ${header("Meta")}
                            ${header("Realizado")}
                            ${header("Requisito Min")}
                            ${header("Meta")}
                            ${header("Realizado")}
                        </tr>
                `

                for (const meta of metas) {
                    html += `<tr>`
                        + `<td ${TD}>${meta.fv_meta_cd ?? ""}</td>`
                        + `<td ${TD}>${meta.fv_meta_descricao ?? ""}</td>`
                        + tdMeta(meta.fv_meta_rq_pos_minimo, 0)
                        + tdMeta(meta.fv_meta_rq_pos, 0)
                        + tdMeta(meta.fv_meta_rz_pos, 0)
                        + tdMeta(meta.fv_meta_rq_qtde, 1)
                        + tdMeta(meta.fv_meta_rq_qtde_maximo, 1)
                        + tdMeta(meta.fv_meta_rz_qtde, 1)
                        + tdMeta(meta.fv_meta_rq_valor, 2)
                        + tdMeta(meta.fv_meta_rq_valor_maximo, 2)
                        + tdMeta(meta.fv_meta_rz_valor, 2)
                        + tdMeta(meta.fv_meta_bonus_percentual, 2)
                        + `</tr>`
                }

                return html + "</table>"
            }


            for (const v of lista) {
                try {
                    const cdvendedor = v.cdparticipantevendedor
                    const nomeVendedor = String(v.nome_vendedor || "").trim()
                    const emailVendedor = !par.email_conferencia || par.email_conferencia === "" ? String(v.email_vendedor || "").trim() : par.email_conferencia
                    const subject = `IF0100 | Relatório de Venda - ${nomeVendedor} | ${v.email_vendedor} ${par.email_conferencia && par.email_conferencia !== "" ? `(CONFERÊNCIA ${par.email_conferencia})` : ""}`

                    const grupos = [
                        { pre: "johson",          titulo: "JOHNSON",          amarelo: false },
                        { pre: "sempremio",       titulo: "MELITTA/ADRIA",    amarelo: true  },
                        { pre: "premioindustria", titulo: "PREMIO IND.",      amarelo: true  },
                        { pre: "outros",          titulo: "OUTROS",           amarelo: true  },
                    ]

                    const totalVlr = grupos.reduce((s, g) => s + num(v[`${g.pre}_valortotalfaturamento`]), 0)

                    const headGrupos = grupos.map(g => `<td colspan="3" ${TH}>${g.titulo}</td>`).join("")
                    const headSub = grupos.map(() => `<td ${TH}>Pos</td><td ${TH}>Vol</td><td ${TH}>Valor</td>`).join("")

                    const cols = grupos.map(g => {
                        const st = g.amarelo && num(v[`${g.pre}_valortotalfaturamento`]) === 0 ? TDY : TDR
                        return `<td ${st}>${fmt(v[`${g.pre}_positivacao`],0)}</td>`
                             + `<td ${st}>${fmt(v[`${g.pre}_embalagemcompra`], 1)}</td>`
                             + `<td ${st}>${fmt(v[`${g.pre}_valortotalfaturamento`],2)}</td>`
                    }).join("")

                    const html = `
                    <html><body style="font-family:Arial,sans-serif;">
                    <table style="border-collapse:collapse;border:1px solid #000;">
                        <tr><td colspan="15" ${TH} style="border:1px solid #000;padding:6px;font-size:13px;text-align:center;font-weight:bold;">${subject}</td></tr>
                        <tr>
                            <td rowspan="2" ${TH}>CODIGO</td>
                            <td rowspan="2" ${TH}>NOME</td>
                            ${headGrupos}
                            <td rowspan="2" ${TH}>TOTAL</td>
                        </tr>
                        <tr>${headSub}</tr>
                        <tr>
                            <td ${TD}>${cdvendedor}</td>
                            <td ${TD}>${nomeVendedor}</td>
                            ${cols}
                            <td ${TDR}>${fmt(totalVlr,2)}</td>
                        </tr>
                    </table>
                    ${buildQuadroMetas(cdvendedor)}
                    </body></html>`

                    await clsTools.mail.sendMail(emailVendedor, `${subject}`, html, "ADM", par.mail_cc, par.mail_bcc)

                } catch (e) {
                    await clsTools.PagErrorException(FLG_MODULO, `sendMailVendedor vendedor ${v?.cdparticipantevendedor} (Service.if0100)`, e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
                }
            }

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "sendMailVendedor (Service.if0100)", e)
        } finally {
            return par
        }
    }
    

  static async sendMailSupervisor(par: any) : Promise<any> {
        try {
            const listaVendas: any[] = Array.isArray(par.listVendaFabricante) ? par.listVendaFabricante : []
            const listaMetas: any[] = Array.isArray(par.listQuadroMetasVendedorResumo) ? par.listQuadroMetasVendedorResumo : []
            const colunasMetas: any[] = Array.isArray(par.MetasVendedorListGeralColumns) ? par.MetasVendedorListGeralColumns : []

            if (listaVendas.length === 0 && listaMetas.length === 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | sendMailSupervisor | Sem dados para envio`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                return par
            }

            const num = (valor: any) => Number(valor) || 0
            const fmt = (valor: any, casasDecimais = 2) => num(valor).toLocaleString("pt-BR", {
                minimumFractionDigits: casasDecimais,
                maximumFractionDigits: casasDecimais,
            })
            const TD = `style="border:1px solid #000;padding:2px 4px;font-size:11px;"`
            const TDR = `style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:right;"`
            const TDY = `style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:right;background:#ffff00;"`
            const TH = `style="border:1px solid #000;padding:3px 4px;font-size:11px;color:#0000cc;text-align:center;font-weight:bold;"`
            const periodo = par.periodo_descricao || par.competencia_cd || ""
            const grupos = [
                { pre: "johson", titulo: "JOHNSON" },
                { pre: "sempremio", titulo: "MELITTA/ADRIA" },
                { pre: "premioindustria", titulo: "PREMIO IND." },
                { pre: "outros", titulo: "OUTROS" },
            ]
            const somarVendas = (campo: string) =>
                listaVendas.reduce((soma, item) => soma + num(item[campo]), 0)
            const colunasVenda = grupos.map(grupo => `
                <td ${grupo.pre !== "johson" && somarVendas(`${grupo.pre}_valortotalfaturamento`) === 0 ? TDY : TDR}>${fmt(somarVendas(`${grupo.pre}_positivacao`), 0)}</td>
                <td ${grupo.pre !== "johson" && somarVendas(`${grupo.pre}_valortotalfaturamento`) === 0 ? TDY : TDR}>${fmt(somarVendas(`${grupo.pre}_embalagemcompra`), 1)}</td>
                <td ${grupo.pre !== "johson" && somarVendas(`${grupo.pre}_valortotalfaturamento`) === 0 ? TDY : TDR}>${fmt(somarVendas(`${grupo.pre}_valortotalfaturamento`), 2)}</td>
            `).join("")
            const totalVendas = listaVendas.reduce((soma, item) => soma + grupos.reduce((subtotal, grupo) =>
                subtotal + num(item[`${grupo.pre}_valortotalfaturamento`]), 0), 0)
            const cabecalhoVendas = grupos.map(grupo => `<td colspan="3" ${TH}>${grupo.titulo}</td>`).join("")
            const subCabecalhoVendas = grupos.map(() => `<td ${TH}>Pos</td><td ${TH}>Vol</td><td ${TH}>Valor</td>`).join("")
            const linhasVendas = listaVendas.map(vendedor => {
                const valores = grupos.map(grupo => {
                    const estilo = grupo.pre !== "johson" && num(vendedor[`${grupo.pre}_valortotalfaturamento`]) === 0 ? TDY : TDR
                    return `
                        <td ${estilo}>${fmt(vendedor[`${grupo.pre}_positivacao`], 0)}</td>
                        <td ${estilo}>${fmt(vendedor[`${grupo.pre}_embalagemcompra`], 1)}</td>
                        <td ${estilo}>${fmt(vendedor[`${grupo.pre}_valortotalfaturamento`], 2)}</td>
                    `
                }).join("")
                const totalVendedor = grupos.reduce((soma, grupo) =>
                    soma + num(vendedor[`${grupo.pre}_valortotalfaturamento`]), 0)
                return `<tr>
                    <td ${TD}>${vendedor.cdparticipantevendedor ?? ""}</td>
                    <td ${TD}>${vendedor.nome_vendedor ?? ""}</td>
                    ${valores}
                    <td ${TDR}>${fmt(totalVendedor, 2)}</td>
                </tr>`
            }).join("")
            const quadroVendas = `
                <div style="font-family:Arial,sans-serif;margin-top:16px;font-size:12px;">RELATÓRIO DE VENDA POR FABRICANTE</div>
                <table style="border-collapse:collapse;border:1px solid #000;margin-top:4px;">
                    <tr><td colspan="15" ${TH} style="border:1px solid #000;padding:6px;font-size:12px;text-align:center;font-weight:bold;">Relatório de Venda por Fabricante - ${periodo}</td></tr>
                    <tr><td rowspan="2" ${TH}>CODIGO</td><td rowspan="2" ${TH}>NOME</td>${cabecalhoVendas}<td rowspan="2" ${TH}>TOTAL</td></tr>
                    <tr>${subCabecalhoVendas}</tr>
                    <tr>
                        <td ${TD}>0</td><td ${TD}><b>** TOTAL **</b></td>
                        ${colunasVenda}
                        <td ${TDR}><b>${fmt(totalVendas, 2)}</b></td>
                    </tr>
                    ${linhasVendas}
                </table>`

            const metricasMeta = [
                { campo: "meta_rq", titulo: "Rq", casas: 0 },
                { campo: "meta_rz", titulo: "Rz", casas: 0 },
                { campo: "meta_bonus_percentual", titulo: "Bonus", casas: 2 },
                { campo: "meta_base_valor", titulo: "Base", casas: 2 },
                { campo: "meta_resultado_valor", titulo: "Resultado", casas: 2 },
            ]
            const linhasMetaCabecalho = colunasMetas.map(meta =>
                `<td colspan="5" ${TH}>(${meta.fv_meta_cd}) ${meta.fv_meta_descricao ?? ""}</td>`
            ).join("")
            const linhasSubCabecalhoMeta = colunasMetas.map(() =>
                metricasMeta.map(metrica => `<td ${TH}>${metrica.titulo}</td>`).join("")
            ).join("")
            const linhasMetas = listaMetas.map(vendedor => {
                const valoresMeta = colunasMetas.map((_, indice) => {
                    const prefixo = `fv${String(indice + 1).padStart(2, "0")}`
                    return metricasMeta.map(metrica => {
                        const valor = vendedor[`${prefixo}_${metrica.campo}`]
                        const estilo = num(valor) === 0 ? TDY : TDR
                        return `<td ${estilo}>${fmt(valor, metrica.casas)}</td>`
                    }).join("")
                }).join("")
                return `<tr>
                    <td ${TD}>${vendedor.cdparticipante ?? ""}</td>
                    <td ${TD}>${vendedor.nome_razao ?? ""}</td>
                    ${valoresMeta}
                    <td ${TDR}>${fmt(vendedor.total_meta_resultado_valor, 2)}</td>
                </tr>`
            }).join("")
            const quadroMetas = `
                <div style="font-family:Arial,sans-serif;margin-top:16px;font-size:12px;">RELATÓRIO PRELIMINAR DE METAS</div>
                <table style="border-collapse:collapse;border:1px solid #000;margin-top:4px;">
                    <tr><td colspan="${2 + (colunasMetas.length * metricasMeta.length) + 1}" ${TH} style="border:1px solid #000;padding:6px;font-size:12px;text-align:center;font-weight:bold;">Relatório de Metas - ${periodo}</td></tr>
                    <tr><td rowspan="2" ${TH}>Vendedor</td><td rowspan="2" ${TH}>Nome</td>${linhasMetaCabecalho}<td rowspan="2" ${TH}>Resultado Total</td></tr>
                    <tr>${linhasSubCabecalhoMeta}</tr>
                    ${linhasMetas}
                </table>`

            const html = `<html><body style="font-family:Arial,sans-serif;">${quadroVendas}${quadroMetas}</body></html>`
            const subject = `IF0100 | Relatório de Supervisão | ${periodo} - distribuicao@oxan.com.br`
            await clsTools.mail.sendMail(
                par.email_conferencia || "distribuicao@oxan.com.br",
                subject,
                html,
                "ADM",
                par.mail_cc,
                par.mail_bcc
            )
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "sendMailSupervisor (Service.if0100)", e)
        } finally {
            return par
        }
    }


    private static async __db(string_sql: string) : Promise<any> {
        try {
            let __db : clsBase = new clsBase()
            let result = __db.myDataBase.pag.DataGet(string_sql)
            return result
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "__db (Service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }
}       