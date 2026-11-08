import myTools from "../../../tools/Tools";
import tbsistema_log from '../tbs/tbsistema_log';

///import dataStore from '../dataStore';

class modelsistema_log extends tbsistema_log {
    constructor() 
    {
        super()
    }
    public async ProcessarLog() {
        try {
                this.uuid = await this._uuid()
                await this.__INSERT();
                

        } catch (e) {
            myTools.pagConsoleLog(`M9020 | modelsistema_log ERROR ${e}`, true)    
        }
    }

    public async registrarLog(item: any) { 
        try {
            let modelLog = new modelsistema_log();

            if (item) { 
                 
                modelLog.sis_nucleo_prc_cd = item?.sis_nucleo_prc_cd? parseInt(`${item.sis_nucleo_prc_cd}`) : 0
                modelLog.sis_log_tag = item?.sis_log_tag ? `${item.sis_log_tag}` : ``
                modelLog.sis_log_info = item?.sis_log_info ? `${item.sis_log_info}` : ``
                modelLog.sis_batch_run_seq = item?.sis_batch_run_seq ? parseInt(`${item.sis_batch_run_seq}`) : 0
                modelLog.proc_log_seq = item?.proc_log_seq ? parseInt(`${item.proc_log_seq}`) : 0
                modelLog.sis_log_seq = item?.sis_log_seq ? parseInt(`${item.sis_log_seq}`) : 0
                modelLog.uuid_start = item?.uuid_start ? `${item.uuid_start}` : ``
                modelLog.uuid = item?.uuid ? `${item.uuid}` : ``
               
                await modelLog.ProcessarLog();

            }


        } catch (e) {
            myTools.PagErrorException(`modelsistema_log`, `registrarLog`, e)
        }
    }

}

export default modelsistema_log