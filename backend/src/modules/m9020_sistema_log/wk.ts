import { Request } from "express"
import modelsistema_log from "./model/modelsistema_log"
import { isistemaLog } from "./interfaces";

class wk {
    public static async ProcessarLog (_isistema_log : isistemaLog) : Promise<modelsistema_log> {
        
        
        let modelSistema_Log : modelsistema_log; 
        modelSistema_Log = new modelsistema_log();

        modelSistema_Log.binding(_isistema_log)

        await modelSistema_Log.ProcessarLog(); 

        return modelSistema_Log;

    }
}

export default wk 