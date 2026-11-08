import { clsBase, clsTools } from "../../../model/modelbase";

export default class reportForcaVendaTabelaVersao {
    static sql(parametro: any) : string { 

            console.log(parametro)

            let sql = `
                  Select v.fv_tabelapreco_cd
                    ,	t.fv_tabelapreco_descricao  	
                    ,	v.versao
                    ,   v.descontomaximo
                    ,	v.descontopadrao
                    ,	v.acrescimomaximo
                    ,	v.datainiciovigencia
                    ,	v.datafimvigencia 
                    ,	v.ativo
                    ,	v.tabelareferencia 
                from 		tbforca_venda_tabpreco_versao v
                left join 	tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = v.fv_tabelapreco_cd
                where 1 = 1
                    `

            if (parametro.fv_tabelapreco_descricao) {
                sql +=  ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`
            }

            if (parametro.fv_tabelapreco_cd) {
                sql +=  ` and v.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`
            }

            if (parametro.vigencia_inicial) {
                sql +=  ` and v.datainiciovigencia >= '${parametro.vigencia_inicial} 00:00:00'`
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