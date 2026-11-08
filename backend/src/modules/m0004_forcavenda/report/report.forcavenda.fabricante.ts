import { clsBase, clsTools } from "../../../model/modelbase";

export default class reportForcaVendaFabricante {
    static sql (parametro: any) : string {

        let sql = `
                    select 		p.nome_razao 
                        ,		fv_fabricante_seq 
                        ,		fv_fabricante_descricao 
                        ,		fv_fabricante_referencia
                        ,		fv_fabricante_cdpessoabluesoft 
                        ,		t.mail_notificacao_estoque
                        ,		coalesce(t.mail_notificacao_estoque_address,'') as mail_notificacao_estoque_address
                        ,		t.mail_notificacao_giro
                        ,		t.fv_fabricante_status 
                    from 		tbforca_venda_fabricante t 
                    inner join 	tbpessoabluesoft p on p.cdpessoabluesoft  = t.fv_fabricante_cdpessoabluesoft
                    where 1=1
        `
        if (parametro.cdpessoabluesoftfabricante) {
            sql += ` and t.fv_fabricante_cdpessoabluesoft = ${parametro.cdpessoabluesoftfabricante} `
        }

        if (parametro.fv_fabricante_status && parametro.fv_fabricante_status == 1) {
            sql += ` and t.fv_fabricante_status = ${parametro.fv_fabricante_status} `
        }


        sql += ` ORDER BY t.fv_fabricante_descricao ASC `

        return sql;

    }

    static async get(parametro: any): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro))
            return result
        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaFabricante.result | Error \n ${e}`, false, false)
            throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaFabricante.result | Error ${e}`);
        }
     }
}