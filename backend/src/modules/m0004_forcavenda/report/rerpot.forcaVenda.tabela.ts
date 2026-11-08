import { clsBase, clsTools } from "../../../model/modelbase";

export default class reportForcaVendaTabela {
    static sql(parametro: any) : string { 
            let sql = `
                    select 	t.fv_tabelapreco_cd 
                        ,	t.fv_tabelapreco_descricao
                        ,	coalesce(co.percentual_comissao,0) as percentual_comissao
                        ,	coalesce(v.qtde_versao,0) as qtde_versao
                        ,	coalesce(v.versao_atual,0) as versao_atual
                        ,	coalesce(v.vigencia_inicial_atual, '1900-01-01 00:00') as vigencia_inicial_atual
                        ,	coalesce(v.vigencia_fim_atual, '1900-01-01 00:00') as vigencia_fim_atual
                    from tbforca_venda_tabpreco t
                    left join tbforca_venda_comis_tabpreco co on co.fv_tabelapreco_cd = t.fv_tabelapreco_cd
                    left join (
                                    select 	x.fv_tabelapreco_cd
                                        ,	count(distinct(x.versao)) as qtde_versao 
                                        ,	max(x.versao) as versao_atual 
                                        ,	max(x.datainiciovigencia) as vigencia_inicial_atual 
                                        ,	max(x.datafimvigencia) as vigencia_fim_atual 
                                    from tbforca_venda_tabpreco_versao x
                                    group by 	x.fv_tabelapreco_cd
                                ) v on v.fv_tabelapreco_cd = t.fv_tabelapreco_cd
                    where 1=1
                    `

            if (parametro.fv_tabelapreco_descricao) {
                sql +=  ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`
            }

            if (parametro.fv_tabelapreco_cd) {
                sql +=  ` and t.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`
            }

            if (parametro.statusversao && parametro.statusversao == 1) {
                sql +=  ` and t.fv_tabelapreco_cd in ( select fv_tabelapreco_cd from tbforca_venda_tabpreco_versao where ativo = 1 )`
            }

            sql += ` ORDER BY t.fv_tabelapreco_descricao ASC `
            return sql;
    }

    static async get(parametro: any): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro))
            return result
        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error \n ${e}`, false, false)
            throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error ${e}`);
        }
    }



}