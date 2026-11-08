import { clsBase, clsTools } from "../../../model/modelbase";

import InformeMailset from "../model/model.informe_mailset";



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 101000015
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M1000-INFORME(service.if0045.ts)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    


type TebelaColunas = { 
    agrupamento: string 
    subtitulo: string 
    titulo: string 
}


type TabelaClienteMix = {
     cdparticipantecliente: number | null;
     nomecliente: string | null;
     cpf_cnpj: string | null;
     cdparticipantevendedor: number | null;
     nomevendedor: string | null;
     cdgrupoeconomico: number | null;
     grupoeconomico: string | null;
     pos?: number | null;
     MIX02?: string | null;
     MIX07?: string | null;
     MIX17?: string | null;
     MIX28?: string | null;
     G01?: number | null;
     G02?: number | null;
     G03?: number | null;
     G04?: number | null;
     G05?: number | null;
     G06?: number | null;
     G07?: number | null;
     G08?: number | null;
     G09?: number | null;   
     G10?: number | null;
     G11?: number | null;
     G12?: number | null;
     G13?: number | null;
     G14?: number | null;
     G15?: number | null;
     G16?: number | null;
     G17?: number | null;
     G18?: number | null;
     G19?: number | null;
     G20?: number | null;
     G21?: number | null;
     G22?: number | null;
     G23?: number | null;
     G24?: number | null;
     G25?: number | null;
     G26?: number | null;
     G27?: number | null;
     G28?: number | null;

};


export default class serviceinforme_if0045 {

    static async start(parametros: any) { 
        try { 

            
            let par = parametros

            
            await clsTools.pagConsole(`${FLG_MODULO} - Inicializando envio de E-MAIL - Coletando Parâmetros`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)
            par = await this.getParametros(par)
            par.fv_fab_meta_cd = 2026001

                        




            await clsTools.pagConsole(`${FLG_MODULO} - Processando Relatório Base Real`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG)

            await this.processarRelatorioBaseReal(par)






        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "start (service.if0045)", e)
        }
    }
    static async getParametros(parametros: any) : Promise<any>{
        let par = parametros
        try {

            let mailset = new InformeMailset()
            mailset.getDistribuicaoDestinatarios(par)
            par.mail_cc = mailset.mail_cc
            par.mail_bcc = mailset.mail_bcc
            par.email_subervisao = mailset.email_subervisao



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getParametros (service.if0045)", e)
        }
        return par
    }

    static async processarRelatorioBaseReal(parametros: any) {
        try {

            let par = parametros
            par.seqinterface = 0 /*DADOS REAIS */
            
            par = await this.ListarClientesGerais(parametros)
            par = await this.ListarVendedor(parametros)
            par = await this.Colunas(parametros)
                
            
            
            await this.sendMailVendedor(par)
            
            return par
     
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "processarRelatorioBaseReal (service.if0045)", e)
        }
    }


    static async ListarClientesGerais(parametro: any) : Promise<any>{

        let par : any = parametro

        try {

            let listClienteMix : TabelaClienteMix[] = []
            
            let sql = `
                            SELECT		c.cdparticipante            as cdparticipantecliente
                                    ,	ps.cdpessoabluesoft             as cdpessoabluesoftcliente
                                    ,	ps.nome_razao                   as nomecliente
                                    ,   ps.cpf_cnpj                     as cpf_cnpj
                                    ,	ps.cdpessoabluesoft_vendedor    as cdpessoabluesoftvendedor
                                    ,	v.cdparticipante                as cdparticipantevendedor
                                    ,   v.nome_razao                    as nomevendedor
                                    ,	ps.cdgrupoeconomico             as cdgrupoeconomico
                                    ,	gr.descricao                    as grupoeconomico
                                    ,	ps.cpf_cnpj 
									
									,   coalesce(mix.mix02, -2) as mix02
									,   coalesce(mix.mix07, -7) as mix07
									,   coalesce(mix.mix17, -17) as mix17
									,   coalesce(mix.mix28, -28) as mix28


									,   coalesce(grupo.G01, 0) as G01
									,   coalesce(grupo.G02, 0) as G02
									,   coalesce(grupo.G03, 0) as G03
									,   coalesce(grupo.G04, 0) as G04
									,   coalesce(grupo.G05, 0) as G05
									,   coalesce(grupo.G06, 0) as G06
									,   coalesce(grupo.G07, 0) as G07
									,   coalesce(grupo.G08, 0) as G08
									,   coalesce(grupo.G09, 0) as G09
									,   coalesce(grupo.G10, 0) as G10
									,   coalesce(grupo.G11, 0) as G11
									,   coalesce(grupo.G12, 0) as G12
									,   coalesce(grupo.G13, 0) as G13
									,   coalesce(grupo.G14, 0) as G14
									,   coalesce(grupo.G15, 0) as G15
									,   coalesce(grupo.G16, 0) as G16
									,   coalesce(grupo.G17, 0) as G17
									,   coalesce(grupo.G18, 0) as G18
									,   coalesce(grupo.G19, 0) as G19
									,   coalesce(grupo.G20, 0) as G20
									,   coalesce(grupo.G21, 0) as G21
									,   coalesce(grupo.G22, 0) as G22
									,   coalesce(grupo.G23, 0) as G23
									,   coalesce(grupo.G24, 0) as G24
									,   coalesce(grupo.G25, 0) as G25
									,   coalesce(grupo.G26, 0) as G26
									,   coalesce(grupo.G27, 0) as G27
									,   coalesce(grupo.G28, 0) as G28
									





                            FROM		tbparticipante	        c
                            INNER JOIN	tbparticipante_bluesoft	ps on ps.cdpessoabluesoft = c.cdpessoabluesoft
                            INNER JOIN  tbgrupoeconomico          gr on gr.cdgrupoeconomico = ps.cdgrupoeconomico
                            INNER join  tbparticipante_bluesoft	v on v.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor
							LEFT JOIN   ( 		SELECT cdparticipantecliente
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd =  2 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,2) else 0 end) as mix02
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd =  7 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,7) else 0 end) as mix07
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd = 17 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,17) else 0 end) as mix17
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd = 28 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,28) else 0 end) as mix28

                                            FROM tbforca_venda_fab_meta_res_cliente_mix a
                                            left join tbforca_venda_fab_meta_mix b on a.fv_fab_meta_mix_cd = b.fv_fab_meta_mix_cd and a.fv_fab_meta_cd = b.fv_fab_meta_cd
                                            where 1 = 1 
                                          and   a.seqinterface = ${par.seqinterface}
                                          and   a.fv_fab_meta_cd = ${par.fv_fab_meta_cd}
                                          		group by cdparticipantecliente
										) as mix on mix.cdparticipantecliente = c.cdparticipante
							LEFT JOIN   (
											SELECT cdparticipantecliente
                                                ,  sum(case when fv_fab_meta_grupo_cd = 1 then embalagemestoqueqtde else 0 end) as G01
                                                ,  sum(case when fv_fab_meta_grupo_cd = 2 then embalagemestoqueqtde else 0 end) as G02
                                                ,  sum(case when fv_fab_meta_grupo_cd = 3 then embalagemestoqueqtde else 0 end) as G03
                                                ,  sum(case when fv_fab_meta_grupo_cd = 4 then embalagemestoqueqtde else 0 end) as G04
                                                ,  sum(case when fv_fab_meta_grupo_cd = 5 then embalagemestoqueqtde else 0 end) as G05
                                                ,  sum(case when fv_fab_meta_grupo_cd = 6 then embalagemestoqueqtde else 0 end) as G06
                                                ,  sum(case when fv_fab_meta_grupo_cd = 7 then embalagemestoqueqtde else 0 end) as G07
                                                ,  sum(case when fv_fab_meta_grupo_cd = 8 then embalagemestoqueqtde else 0 end) as G08
                                                ,  sum(case when fv_fab_meta_grupo_cd = 9 then embalagemestoqueqtde else 0 end) as G09
                                                ,  sum(case when fv_fab_meta_grupo_cd = 10 then embalagemestoqueqtde else 0 end) as G10
                                                ,  sum(case when fv_fab_meta_grupo_cd = 11 then embalagemestoqueqtde else 0 end) as G11
                                                ,  sum(case when fv_fab_meta_grupo_cd = 12 then embalagemestoqueqtde else 0 end) as G12
                                                ,  sum(case when fv_fab_meta_grupo_cd = 13 then embalagemestoqueqtde else 0 end) as G13
                                                ,  sum(case when fv_fab_meta_grupo_cd = 14 then embalagemestoqueqtde else 0 end) as G14
                                                ,  sum(case when fv_fab_meta_grupo_cd = 15 then embalagemestoqueqtde else 0 end) as G15
                                                ,  sum(case when fv_fab_meta_grupo_cd = 16 then embalagemestoqueqtde else 0 end) as G16
                                                ,  sum(case when fv_fab_meta_grupo_cd = 17 then embalagemestoqueqtde else 0 end) as G17
                                                ,  sum(case when fv_fab_meta_grupo_cd = 18 then embalagemestoqueqtde else 0 end) as G18
                                                ,  sum(case when fv_fab_meta_grupo_cd = 19 then embalagemestoqueqtde else 0 end) as G19
                                                ,  sum(case when fv_fab_meta_grupo_cd = 20 then embalagemestoqueqtde else 0 end) as G20
                                                ,  sum(case when fv_fab_meta_grupo_cd = 21 then embalagemestoqueqtde else 0 end) as G21
                                                ,  sum(case when fv_fab_meta_grupo_cd = 22 then embalagemestoqueqtde else 0 end) as G22
                                                ,  sum(case when fv_fab_meta_grupo_cd = 23 then embalagemestoqueqtde else 0 end) as G23
                                                ,  sum(case when fv_fab_meta_grupo_cd = 24 then embalagemestoqueqtde else 0 end) as G24
                                                ,  sum(case when fv_fab_meta_grupo_cd = 25 then embalagemestoqueqtde else 0 end) as G25
                                                ,  sum(case when fv_fab_meta_grupo_cd = 26 then embalagemestoqueqtde else 0 end) as G26
                                                ,  sum(case when fv_fab_meta_grupo_cd = 27 then embalagemestoqueqtde else 0 end) as G27
                                                ,  sum(case when fv_fab_meta_grupo_cd = 28 then embalagemestoqueqtde else 0 end) as G28
                                            from tbforca_venda_fab_meta_res_cliente_grupo
											where 1 = 1
											and   seqinterface = ${par.seqinterface}
											and   fv_fab_meta_cd = ${par.fv_fab_meta_cd}
                                            group by cdparticipantecliente
							
										) as grupo on grupo.cdparticipantecliente = c.cdparticipante
	
                            where		1 = 1
                            and			gr.cdgrupoeconomico <> 0 
                            and         ps.cdpessoabluesoft_vendedor <> 0 
                            and         ps.bluesoftclientestatus = 1
            
            `

            let resultCliente = await this.__db(sql)
            if (resultCliente) {
                
                let arrayCliente = resultCliente as any[]

                for (let cliente of arrayCliente) {
                    let itemCliente : TabelaClienteMix = { 
                        cdparticipantecliente: cliente.cdparticipantecliente,
                        nomecliente: cliente.nomecliente,
                        cpf_cnpj: cliente.cpf_cnpj,
                        cdparticipantevendedor: cliente.cdparticipantevendedor,
                        nomevendedor: cliente.nomevendedor,
                        cdgrupoeconomico: cliente.cdgrupoeconomico,
                        grupoeconomico: cliente.grupoeconomico,
                        MIX02: cliente.mix02,
                        MIX07: cliente.mix07,
                        MIX17: cliente.mix17,
                        MIX28: cliente.mix28,
                        G01: cliente.g01,
                        G02: cliente.g02,
                        G03: cliente.g03,
                        G04: cliente.g04,
                        G05: cliente.g05,
                        G06: cliente.g06,
                        G07: cliente.g07,
                        G08: cliente.g08,
                        G09: cliente.g09,
                        G10: cliente.g10,
                        G11: cliente.g11,
                        G12: cliente.g12,
                        G13: cliente.g13,
                        G14: cliente.g14,
                        G15: cliente.g15,
                        G16: cliente.g16,
                        G17: cliente.g17,
                        G18: cliente.g18,
                        G19: cliente.g19,
                        G20: cliente.g20,
                        G21: cliente.g21,
                        G22: cliente.g22,
                        G23: cliente.g23,
                        G24: cliente.g24,
                        G25: cliente.g25,
                        G26: cliente.g26,
                        G27: cliente.g27,
                        G28: cliente.g28


                    }
                    listClienteMix.push(itemCliente)

                }

                par.listClienteMix = listClienteMix

            }



            
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "ListarClientesGerais (service.if0045)", e)
        }

        finally {
            return par
        }
    
    }

    static async ListarVendedor(parametros: any) : Promise<any> {
        let par: any = parametros
        try {
            let sql = `
                           							SELECT 	 a.cdparticipante  as cdparticipantevendedor
                                ,    v.cdpessoabluesoft
                                ,    v.nome_razao
								,    p.email_main as email_vendedor
								,    a.vendedor_status
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 99 then qtde_positivacao else 0 end ) as pos
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 2 then qtde_positivacao else 0 end )  as mix02	   
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 7 then qtde_positivacao else 0 end )  as mix07
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 17 then qtde_positivacao else 0 end ) as mix17
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 28 then qtde_positivacao else 0 end ) as mix28
                            from    tbparticipante_vendedor a
							inner join  tbparticipante p on p.cdparticipante = a.cdparticipante
                            inner  join tbparticipante_bluesoft v on v.cdparticipante = a.cdparticipante
							left   join tbforca_venda_fab_meta_res_vendedor b on b.cdparticipantevendedor = a.cdparticipante
                            
                            where   1 = 1
                            and     b.fv_fab_meta_cd = 2026001
                            and     b.seqinterface = 0
                            group by a.cdparticipante  
                                ,    v.cdpessoabluesoft
                                ,    v.nome_razao
								,    p.email_main 
								,    a.vendedor_status
           
            `

            let result = await this.__db(sql)
            par.listVendedor = result as any[]


        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "ListarVendedor (service.if0045)", e)
        } finally {
            return par
        }



    }


    static async Colunas(parametros: any) : Promise<any> {
        let par: any = parametros
        let colunas: TebelaColunas[] = []
        try { 

            let coluna1: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "CNPJ"}
            let coluna2: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "Nome"}
            let coluna3: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "POS"}
            let coluna4: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "MIX02"}
            let coluna5: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "MIX07"}
            let coluna6: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "MIX17"}
            let coluna7: TebelaColunas = {agrupamento: "", subtitulo: "", titulo: "MIX28"}

            colunas.push(coluna1)
            colunas.push(coluna2)
            colunas.push(coluna3)
            colunas.push(coluna4)
            colunas.push(coluna5)
            colunas.push(coluna6)
            colunas.push(coluna7)


            for (let i: number = 1; i <= 28; i++) {
                let agrupamento = ``
                let subtitulo = ``
                let titulo = ``

                if (i <= 2) { agrupamento = `MIX02` }
                if (i >2 && i <= 7) { agrupamento = `MIX07` }
                if (i >7 && i <= 17) { agrupamento = `MIX17` }
                if (i >17 && i <= 28) { agrupamento = `MIX28` }
                
                subtitulo = `G${i.toString().padStart(2, '0')}`

                if (i == 1) titulo = `133852 - GLADE AERO LAVANDA 360ML OF, ESP`
                if (i == 2) titulo = `54502 - INSET, RAID AERO BASE AGUA 420ML PROMO (Cajamar)`
                if (i == 3) titulo = `1812 - DESINF, LYSOFORM BRUTO ORIGINAL 1LT`
                if (i == 4) titulo = `136199 - PATO PASTILHA SANIT, ADESIVA LAVANDA OF,ESP, C/3`
                if (i == 5) titulo = `59730 - PEDRA SANIT, GLADE LAVANDA OF, ESP`
                if (i == 6) titulo = `230494 - GLADE GOTAS ODORIZ CHA BRANCO 120ML`
                if (i == 7) titulo = `54140 - INSET, BAYGON AERO A, TOTAL 360ML PROMO`
                if (i == 8) titulo = `152354 - DESINF, LYSOFORM ORIG LAVANDA 1L`
                if (i == 9) titulo = `3650 - PATO GERMINEX MARINE OF, ESPECIAL 750ML`
                if (i == 10) titulo = `125204 - PATO GEL ADES,AP MARINE OF, ESP`
                if (i == 11) titulo = `218419 - GLADE GOTAS PERF, LAVANDA 120ML`
                if (i == 12) titulo = `139839 - GLADE AERO L, DE INFANCIA 360ML OF, ESP`
                if (i == 13) titulo = `153119 - GLADE AERO FRUTAS E FLORES 360ML OF, ESP`
                if (i == 14) titulo = `54506 - INSET, RAID AERO EUCALIPTO 420ML PROMO (Cajamar)`
                if (i == 15) titulo = `118506 - INSET, RAID 45N AP+RF 32,9ML PROMO`
                if (i == 16) titulo = `54505 - INSET, RAID 45N RF 32,9ML C/2 50% PROMO`
                if (i == 17) titulo = `54770 - INSET, REP,OFF FAMILY SPRAY ALOEVERA 100ML`
                if (i == 18) titulo = `118787 - LIMP, MR MUSCULO COZ, SACHE LARAN, 400ML PROMO`
                if (i == 19) titulo = `210999 - PATO GEL ADES,RF C/6 DISCOS MARINE PROMO`
                if (i == 20) titulo = `161032 - PATO PASTILHA SANIT, ADESIVA CITRUS OF,ESP, C/3`
                if (i == 21) titulo = `136727 - PEDRA SANIT, PATO MARINE 25% C/1 PROMO`
                if (i == 22) titulo = `218449 - GLADE GOTAS PERF, LEMB INFANCIA 120ML`
                if (i == 23) titulo = `110351 - GLADE AUTOM RF LAVANDA 269ML OF, ESP`
                if (i == 24) titulo = `230492 - DIFUSOR GLADE AMBIENTE CHA BRANCO 100ML`
                if (i == 25) titulo = `182000 - DIFUSOR GLADE AMBIENTE LAVANDA 100ML`
                if (i == 26) titulo = `200487 - DIFUSOR GLADE AMBIENTE F E FLORES 100ML`
                if (i == 27) titulo = `3653 - INSET, RAID 45N RF  32,9ML`
                if (i == 28) titulo = `59536	INSET, REP,OFF KIDS LOCAO 200ML`

                let coluna: TebelaColunas = {agrupamento: agrupamento, subtitulo: subtitulo, titulo: titulo}
                colunas.push(coluna)
            }

            par.colunasRelatorioDetalhe = colunas





        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "Colunas (service.if0045)", e)
        }

        finally {
            return par
        }

    }


  static async sendMailVendedor(parametros: any) : Promise<any> {
        let par: any = parametros
        try {
            const list: TabelaClienteMix[] = par.listClienteMix || []
            const colunas: TebelaColunas[] = par.colunasRelatorioDetalhe || []

            if (!Array.isArray(list) || list.length === 0 || colunas.length === 0) {
                await clsTools.pagConsole(`${FLG_MODULO} | sendMailVendedor | Sem dados para envio`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                return par
            }

            const MAIL_TESTE = "eliassilva@oxan.com.br"
            const TITULO = "JOHNSON MIX 01/07/2026 A 30/06/2027"
            const FIXAS = 7
            const MIXES = ["MIX02", "MIX07", "MIX17", "MIX28"]
            const GRUPOS_POR_MIX: Record<string, string[]> = {
                MIX02: ["G01", "G02"],
                MIX07: ["G01", "G02", "G03", "G04", "G05", "G06", "G07"],
                MIX17: Array.from({ length: 17 }, (_, i) => `G${String(i + 1).padStart(2, "0")}`),
                MIX28: Array.from({ length: 28 }, (_, i) => `G${String(i + 1).padStart(2, "0")}`),
            }

            const toNumber = (v: any): number => Number(v || 0)
            const th = (txt: string, extra = "", attrs = "") =>
                `<th ${attrs} style='padding: 4px; border: 1px solid #999; font-size: 10px; color: #0000cc; background-color: #f2f2f2; ${extra}'>${txt}</th>`
            const td = (txt: any, align = "right", size = 11, extra = "") =>
                `<td style='padding: 4px; border: 1px solid #999; font-size: ${size}px; text-align: ${align}; ${extra}'>${txt ?? ""}</td>`

            // O MIX só é considerado atingido quando seu valor e todos os grupos exigidos são positivos/zerados conforme a regra.
            const tdMix = (v: any, grupos: any[]) => {
                const n = toNumber(v)
                const todosGruposPositivos = grupos.every(grupo => toNumber(grupo) > 0)
                return n >= 0 && todosGruposPositivos
                    ? td("OK", "center", 10, "background-color: #2e7d32; color: white; font-weight: bold;")
                    : td(n, "center", 10, "background-color: #e8330f; color: white; font-weight: bold;")
            }

            // Vendedores vêm da composição pronta (ListarVendedor); clientes são indexados por vendedor
            const listVendedor: any[] = (par.listVendedor || []).filter((v: any) => Number(v.vendedor_status) === 1)
                
            const clientesPorVendedor = new Map<string, TabelaClienteMix[]>()
            for (const row of list) {
                const key = String(row.cdparticipantevendedor ?? 0)
                const arr = clientesPorVendedor.get(key)
                if (arr) arr.push(row)
                else clientesPorVendedor.set(key, [row])
            }

            // Cabeçalho em 3 linhas: agrupamento (colspan) / subtitulo / titulo
            const buildHeader = (): string => {
                let h = "<thead>"

                h += "<tr>"
                h += th("CNPJ", "", "rowspan='3'") + th("Nome", "", "rowspan='3'") + th("POS", "", "rowspan='3'")
                h += th("MIX02", "", "rowspan='3'") + th("MIX07", "", "rowspan='3'") + th("MIX17", "", "rowspan='3'") + th("MIX28", "", "rowspan='3'")
                let i = FIXAS
                while (i < colunas.length) {
                    let span = 1
                    while (i + span < colunas.length && colunas[i + span].agrupamento === colunas[i].agrupamento) span++
                    h += th(colunas[i].agrupamento.replace("MIX", "MIX "), "text-align: left;", `colspan='${span}'`)
                    i += span
                }
                h += "</tr>"

                h += "<tr>"
                for (let c = FIXAS; c < colunas.length; c++) h += th(colunas[c].subtitulo, "text-align: left;")
                h += "</tr>"

                h += "<tr>"
                for (let c = FIXAS; c < colunas.length; c++) h += th(colunas[c].titulo, "text-align: left; font-size: 9px; min-width: 70px; vertical-align: top;")
                h += "</tr>"

                return h + "</thead>"
            }

            const buildVendedor = (v: any, rows: TabelaClienteMix[]): string => {
                // Resumo vindo da composição de vendedores
                const posGeral = toNumber(v.pos)
                const okMix = [v.mix02, v.mix07, v.mix17, v.mix28].map(toNumber)

                let html = ""
                html += "<table style='border-collapse: collapse; background-color: white; margin-bottom: 12px;'>"
                html += `<tr><th colspan='7' style='padding: 6px; border: 1px solid #999; font-size: 12px;'>${TITULO}</th></tr>`
                html += "<tr>" + th("VENDEDOR") + th("NOME") + th("Pos Geral") + th("MIX 02") + th("MIX 07") + th("MIX 17") + th("MIX 28") + "</tr>"
                html += "<tr>"
                    + td(v.cdparticipantevendedor, "left", 12)
                    + td(v.nome_razao, "left", 12)
                    + td(posGeral, "center", 12, "font-weight: bold; background-color: #ddd;")
                okMix.forEach(n => html += td(n, "center", 12, "font-weight: bold; background-color: #ddd;"))
                html += "</tr></table>"

                html += "<table style='border-collapse: collapse; background-color: white; margin-bottom: 24px;'>"
                html += buildHeader()
                html += "<tbody>"

                rows.forEach((r: any) => {
                    const okGeral = MIXES.every(m => toNumber(r[m]) >= 0)
                    html += "<tr>"
                    html += td(r.cpf_cnpj, "left", 9)
                    html += td(r.nomecliente, "left", 11)
                    html += td(r.pos, "center", 10, `font-weight: bold; color: white; background-color: ${okGeral ? "#2e7d32" : "#e8330f"};`)
                    MIXES.forEach(m => html += tdMix(r[m], GRUPOS_POR_MIX[m].map(grupo => r[grupo])))
                    for (let c = FIXAS; c < colunas.length; c++) {
                        html += td(toNumber(r[colunas[c].subtitulo]), "right", 11)
                    }
                    html += "</tr>"
                })

                return html + "</tbody></table>"
            }


            for (const vendedor of listVendedor) {
                const cdvendedor = String(vendedor.cdparticipantevendedor ?? 0)
                const rows = clientesPorVendedor.get(cdvendedor)
                if (!rows || rows.length === 0) continue
                try {
                    const email_vendedor = !par.email_conferencia || par.email_conferencia === "" ? vendedor.email_vendedor || "" : par.email_conferencia
                    const nome = vendedor.nome_razao || cdvendedor
                    
                    
                    
                    let html = "<div style='font-family: Arial, sans-serif; padding: 20px; background-color: #f4f6f8;'>"
                    html += buildVendedor(vendedor, rows)
                    html += "</div>"

                    const subject = `IF0045 | ${TITULO} | ${nome} | ${email_vendedor} ${par.email_conferencia && par.email_conferencia !== "" ? `(CONFERÊNCIA ${par.email_conferencia})` : ""}`

                    // TESTE: todos para o e-mail de teste. Depois trocar pelo e-mail do vendedor.
                    await clsTools.mail.sendMail(email_vendedor, subject, html, "ADM", par.mail_cc, par.mail_bcc)

                } catch (e) {
                    await clsTools.PagErrorException(FLG_MODULO, `sendMailVendedor vendedor ${cdvendedor} (Service.if0045)`, e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
                }
            }

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "sendMailVendedor (Service.if0045)", e)
        } finally {
            return par
        }
    }


    static async __db(string_sql: string) : Promise<any> {
        try {
            let __db : clsBase = new clsBase()
            let result = __db.myDataBase.pag.DataGet(string_sql)
            return result
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "__db (Service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG)
        }
    }
}       