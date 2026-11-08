import fi from "date-fns/esm/locale/fi/index.js";
import { clsBase, clsTools } from "../../../model/modelbase";


/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0005 FORCA VENDA META - Service | Meta "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    



import sqlForcaVenda from "../sql/sql"
import comercial from "src/modules/m0132_comercial";

export default class serviceForcaVendaMetaProcessar {
    static async start(parametro: any) : Promise<any> {

        try { 
            let sql = sqlForcaVenda.f0005_20_fv_meta_processar.get({
                competencia_cd: parametro.competencia_cd
            });
            
            let result = await this._db(sql);
            return result

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



