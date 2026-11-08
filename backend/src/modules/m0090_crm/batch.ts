import { clsTools } from "../../model/modelbase";
import serviceCrmSorteioAtualizarBase from "../../modules/m0090_crm/service/ServiceCRMSorteio/serviceCRMSorteioAtualizarBase";


export default class batch_module_m0090 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {

            clsTools.pagConsole("Iniciando o batch M0090 - Atualizar Base de Sorteio CRM");
            await serviceCrmSorteioAtualizarBase.start();
            
            
            return true;
        } catch (e) {
            clsTools.PagErrorException('M0090','batch_module_m0090.start',  e);
            return false;
            
        }
    }
}