import { clsBase, clsTools } from "../../../model/modelbase";
import reportSistemaLogList from "../../m9020_sistema_log/report/reportSistemaLog";



export default class reportFaturamentoBluesoftSistemaLogList {


    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {

            filter.list_sis_nucleo_prc_cd = "10050001, 10050010, 10050011, 10050030, 10050032"


            result = await reportSistemaLogList.get(filter);
            

        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    } 


}