import { clsBase, clsTools } from "../../../model/modelbase";

export default class reportForcaVendaPrazoPgto {
    static sql() : string { 
            return `
                    select 	fv_prazopgto_cd 
                        ,	fv_prazopgto_descricao 
                        ,	custofinanceiro 
                        ,	coefcustofinanceiro 
                        ,	tipo 
                        ,	tipocusto
                        ,	status
                        ,	versao
                        ,   listapadraoorder
                    from 	tbforca_venda_prazopgto 
                    ORDER BY fv_prazopgto_descricao
                    
                    `
    }

    static async get(): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(reportForcaVendaPrazoPgto.sql())
            return result
        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaPrazoPgto.result | Error \n ${e}`, false, false)
            throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaPrazoPgto.result | Error ${e}`);
        }
    }



}