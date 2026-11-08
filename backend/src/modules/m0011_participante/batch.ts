import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceParticipante from './service/Service';


export default class batch_module_m0051 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {

            await serviceParticipante.vipimport.start({});
            return true;
            
        }
        catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            return false;
        }
    }

    static async Procedimento(sistema_nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<boolean> {
        
        try { 

            await serviceParticipante.vipimport.start({});
            return true;

        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.Procedimento Error`, e)
            return false;
        } finally {
            clsTools.pagConsole(`Procedimento ${sistema_nucleo_procedimento.sis_nucleo_prc_descricao} finalizado`, true)
            return true;
        }

    }
    static async AtualizacaoDiaria() : Promise<boolean> {
        try {
            await serviceParticipante.RedShiftBlueSoftImport.start({});
            await serviceParticipante.APIBlueSoftImport.start({});            
            await serviceParticipante.vipimport.start({});
            return true;
        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.AtualizacaoDiaria Error`, e)
            return false;
        }
    }
  

}
