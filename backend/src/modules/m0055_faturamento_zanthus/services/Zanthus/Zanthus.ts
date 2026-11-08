/* database */
import DataBase from "../../../../database/DataBase"



/* interfaces */
import { ifilter_faturamento } from '../../wk'


const myDataBase : DataBase = new DataBase()

/*Script ZANTHUS SQL SERVER */

import Zanthus_Ctrl from "../../scriptsql/Zanthus_Ctrl"
import Zanthus_Ctrl_Cupom from "../../scriptsql/Zanthus_Ctrl_Cupom"
import Zanthus_Cupom from "../../scriptsql/Zanthus_Cupom"
import Zanthus_CupomItem from "../../scriptsql/Zanthus_CupomItem"


export default class Zanthus {
    
    /*
    private static async get(zanthus_script: string): Promise<object> {
        try {
            let dados = {}
                dados = await myDataBase.zanthusSQL.DataGet(zanthus_script)
                return Promise.resolve(dados);
        } catch (e){
            return Promise.reject({})    
        }

    }*/
    
    public static async Ctrl_Get (filter: ifilter_faturamento, BaseDeDados : string = ``): Promise<object> {        
        
        let dataObject : object = {}
        try {
                 
             //if ( BaseDeDados == "ZANTHUSSQLSERVER") { 
             //     dataObject =  await myDataBase.zanthusSQL.DataGet(Zanthus_Ctrl.get(filter, BaseDeDados))
             //}

             if ( BaseDeDados == "ZANTHUSPOSTGRE") { 
                dataObject =  await myDataBase.zanthusPostgre.DataGet(Zanthus_Ctrl.get(filter, BaseDeDados))
            }             

             return dataObject

        } catch(e) {
            return Promise.reject({})
        }
    }

    public static async CtrlCupom_Get (filter: ifilter_faturamento): Promise<object> {        
        try {return await myDataBase.zanthusSQL.DataGet(Zanthus_Ctrl_Cupom.get(filter))} catch(e){return Promise.reject({})}
    }    

    public static async CupomFiscal_Get(filter: ifilter_faturamento): Promise<object> {        
        try {return await myDataBase.zanthusSQL.DataGet( Zanthus_Cupom.getBaseZanthusSQLServer(filter))} catch(e){return Promise.reject({})}
    }    

    public static async CupomFiscalItem_Get(filter: ifilter_faturamento): Promise<object> {        
        try {return await myDataBase.zanthusSQL.DataGet(Zanthus_CupomItem.getBaseZanthusSQLServer(filter))} catch(e){return Promise.reject({})}
    }    
}