import { clsBase, clsTools } from "../../../model/modelbase";


/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0005 FORCA VENDA META - Service | Meta Fabricante Processar"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    



import sqlForcaVenda from "../../m0005_forcavenda_meta/sql/sql"

export default class serviceForcaVendaMetaFabricanteProcessar {
    static async start(parametro: any) : Promise<any> {

        try { 
            let sql = sqlForcaVenda.f0005_30_fv_meta_fab_processar.get({
                fv_fab_meta_cd: parametro.fv_fab_meta_cd
            });
            let result = await this._db(sql);   


        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "start", e)
        }

    }


    static async _db(sql: string) : Promise<any> {
        let result : any = {}
        try { 
            let __db : clsBase = new clsBase();
            result = await __db.myDataBase.pag.Execute(sql);
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "_db", e)
        } finally {
            return result;
        }
    }


}



