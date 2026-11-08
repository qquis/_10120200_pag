import { clsBase, clsTools } from "../../../model/modelbase";
import modelforca_venda_prazopgto from "../model/modelforca_venda_prazopgtos";

const myBase : clsBase = new clsBase()

export default class serviceForcaVendaImportPrazoPgto {

    static async start() { 
        try { 

                let result = await myBase.blueSoftApi.api_get('/forca-de-vendas/prazos-de-pagamento')
                
                let sqlInsert : string = ``

                

                
                for await (const item of result.data.data as any[]) {
                    let model = new modelforca_venda_prazopgto()
                    model.apiBluesoftGet(item)
                    sqlInsert += model.sqlPrimeInsert()
                   
                }

                await myBase.myDataBase.pag.Execute(sqlInsert)
                

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error \n ${e}`, false, false)
            throw new Error(`modules | m0104_ForcaVenda | service | serviceForcaVendaImportPrazoPgto.start | Error ${e}`);
        }
    }


}