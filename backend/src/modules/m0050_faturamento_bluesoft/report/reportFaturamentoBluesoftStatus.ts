import { reportFilter } from "../types";
import { clsBase, clsTools } from "../../../model/modelbase";
import modelFaturamentoBluesoft from "../model/modelFaturamentoBluesoft";

const myBase : clsBase = new clsBase();

export default class reportFaturamentoBluesoftStatus {
    public static sql(filter : any) : string {
        let sql = 
        
         `	SELECT 		sf.statusfaturamento
                    ,	sf.statusfaturamento_descricao 
                    ,	s.fat_blue_status_cd
                    ,	s.fat_blue_status_descricao 
            from 		tbfaturamento_bluesoft_status s
            inner join 	tbfaturamentostatus sf on sf.statusfaturamento = s.statusfaturamento

         where		1 = 1 
                     order by sf.statusfaturamento, s.fat_blue_status_descricao 
         `


         return sql 

    }

    public static async get(filter : reportFilter) : Promise<object> {
        let result = { }
        try {
            result = await myBase.myDataBase.pag.DataGet( this.sql(filter));
        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    } 


}