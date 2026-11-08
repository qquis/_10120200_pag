import { clsBase, clsTools } from "../../../model/modelbase";
import sistema_log from "../model/modelsistema_log";
import reportSistemaLogList from "../report/reportSistemaLog";

export default class serviceSistemaLogRegistrar { 

    static async submit(item: any = {sis_nucleo_prc_cd: 0, sis_log_tag: "", sis_log_info: "", sis_batch_run_seq: 0, proc_log_seq: 0, sis_log_seq: 0, uuid_start: "", uuid: ""}) { 
        try {

            let modelLog = new sistema_log();
            await modelLog.registrarLog(item) 
        }
            catch (e) {
                await clsTools.PagErrorException("serviceSistemaLogRegistrar", "submit", e);
            }
    }

    static async LogNucleoProcedimentoToday(sis_nucleo_prc_cd: number) : Promise<boolean> { 
        return await reportSistemaLogList.LogNucleoProcedimentoToday(sis_nucleo_prc_cd);
    }

    static async registrarLogResumido(sis_nucleo_prc_cd: number, sis_log_tag: string, sis_log_info: string, sis_batch_run_seq: number = 0, proc_log_seq: number = 0) : Promise<void> {
        try {
            let modelLog = new sistema_log();
            await modelLog.registrarLog({sis_nucleo_prc_cd, sis_log_tag, sis_log_info, sis_batch_run_seq, proc_log_seq, sis_log_seq: 0, uuid_start: "", uuid: ""}) 
        }
        catch (e) {
            await clsTools.PagErrorException("serviceSistemaLogRegistrar", "registrarLogResumido", e);
        }
    }
}

