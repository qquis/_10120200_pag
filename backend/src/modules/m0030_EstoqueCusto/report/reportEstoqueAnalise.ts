import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportEstoqueAnalise {
    public static sql(filter : any) : string {


        let fatormediavenda : number = 90
        if (filter.fatormediavenda) {
            fatormediavenda = parseInt(`${filter.fatormediavenda}`)
        }

        let dataFaturamento_ini : Date = new Date(new Date().setDate(new Date().getDate() - fatormediavenda))




        let sql = 
        
         `	SELECT 		pr.pr_cdproduto                                       as pr_cdproduto
                ,		pr.prb_cdprodutobluesoft                              as prb_cdprodutobluesoft
                ,		pr.pr_descricao                                       as pr_descricao
                ,		case when prb.prb_status then 1 else 0 end            as prb_status
                ,		cast(ec.ec_embalagemestoque_qtde as numeric(13,2))    as ec_embalagemestoque_qtde
                ,		cast(pr.pr_embalagemcompra_fator as numeric(13,0))    as fator
                ,		CAST(ec.ec_embalagemestoque_qtde  / pr.pr_embalagemcompra_fator AS NUMERIC(13,2)) 
                                                                              as ec_embalagemcompra_qtde
                ,		coalesce(es.data_ultima_compra, '1900-01-01')         as data_ultima_compra
                ,		coalesce(es.data_ultima_venda, '1900-01-01')          as data_ultima_venda

                ,		cast(coalesce(v.venda_unit,0) as numeric(13,0))       as venda_embalagemestoque
                ,		cast( coalesce(v.venda_caixa ,0) as numeric(13,2))    as venda_embalagemcompra 
                ,		coalesce(cast(v.venda_unit / ${fatormediavenda} as numeric(13,2)),0) as venda_embalagemestoque_media_diaria 

                ,		cast(ec.ec_valor_custo_faturamento as numeric(13,2))  as ec_valor_custo_faturamento 
                
                ,		g.prg_descricao                                       as prg_descricao
                ,		s.prs_descricao                                       as prs_descricao
                ,		sb.prsg_descricao                                     as prsg_descricao
                ,		prb.prb_cdbarra_principal                             as prb_cdbarra_principal
                ,		prb.PRB_CDPESSOABLUESOFT_FABRICANTE                   as prb_cdpessoabluesoft_fabricante
                ,		coalesce(p.nome_razao,'')                             as fabricante_nome_razao
            FROM 		tbproduto pr

            inner join	tbprodutobluesoft 	prb on prb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft and prb.prb_cdprodutobluesoftunitario = prb.prb_cdprodutobluesoft_pk
            left join   tbproduto_subgrupo 	sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo 
            left join   tbproduto_grupo     g  on g.prg_cdgrupo = sb.prg_cdgrupo
            left join   tbproduto_secao 	s  on s.prs_cdsecao = g.prs_cdsecao 
            left join   tbparticipante_bluesoft     p on p.cdpessoabluesoft = prb.PRB_CDPESSOABLUESOFT_FABRICANTE
            
            left join   tbestoquecusto    	ec on ec.pr_cdproduto = pr.pr_cdproduto 
            left  join  tbest_produto       es on es.pr_cdproduto = pr.pr_cdproduto and es.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
            left join ( select  ni.prb_cdprodutobluesoft 
                            , max(nf.df_data_recebimento) as df_data_recebimento
                        from 	tbdocumentofiscalitem ni 
                        inner join tbdocumentofiscal nf on nf.df_nf_seq_blue = ni.df_nf_seq_blue 
                        where 1 = 1
                        and   nf.df_data_cancelamento = '1900-01-01'
                        and   nf.df_data_recebimento >= '2024-01-01'
                        and   nf.df_entrada_saida = 'E'
                        and   nf.em_cdempresabluesoft =1
                        group by ni.prb_cdprodutobluesoft 
                    ) e on e.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
            left join  ( select 		i.pr_cdproduto 
                                ,	sum(i.embalagemestoqueqtde) as venda_unit
                                ,	sum(i.embalagemcompraqtde) as venda_caixa
                                ,	MAX (i.datafaturamento) as ultima_venda
                        from 		tbest_faturamento_data i
                        where 1 = 1
                        and   i.datafaturamento >= '${clsTools._datemomentDateToStr(dataFaturamento_ini, 'YYYY-MM-DD')}'
                        and   i.em_cdempresa = 1
                        and   i.op_cdoperacao in (1,2,4)
                        group by i.pr_cdproduto  )	v on v.pr_cdproduto = pr.pr_cdproduto 

                        
            WHERE		1 = 1

        `

        if (filter.cdparticipante_fabricante) {
            sql += ` AND p.cdparticipante = ${filter.cdparticipante_fabricante} `
        }



        if (filter.filtrarEstoque) {
            sql += ` AND ec.ec_embalagemestoque_qtde >= ${filter.qtdeinicial} `
            sql += ` AND ec.ec_embalagemestoque_qtde <= ${filter.qtdefinal} `
        }


        if (filter.prd_cddepartamento) {
            sql += ` AND s.prd_cddepartamento = ${filter.prd_cddepartamento} `
        }

        if (filter.prs_cdsecao) {
            sql += ` AND s.prs_cdsecao = ${filter.prs_cdsecao} `
        }

        if (filter.venda_externa) {
            sql += ` AND prb.prb_vendaexterna = ${filter.venda_externa} `
        }

        if (filter.prb_status) {
            sql += ` AND prb.prb_status = ${filter.prb_status} `
        }

        if (filter.DataUltimaVendaFiltrar) {
            sql += ` AND es.data_ultima_venda >= '${filter.DataUltimaVendaIni}' `
            sql += ` AND es.data_ultima_venda <= '${filter.DataUltimaVendaFim}' `
        }

        if (filter.DataUltimaCompraFiltrar) {
            sql += ` AND es.data_ultima_compra >= '${filter.DataUltimaCompraIni}' `
            sql += ` AND es.data_ultima_compra <= '${filter.DataUltimaCompraFim}' `
        }

        /*AREIA */
        sql += ` AND prb.prb_cdprodutobluesoftunitario not in (144960, 130038, 130039) `

        sql += `ORDER BY PR_DESCRICAO ASC`

        

            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {
            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportEstoqueAnalise | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
