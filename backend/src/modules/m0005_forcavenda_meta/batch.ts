import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/

import serviceForcaVendaMeta from './service/service'


export default class batch_module_m0005 {


    static async Procedimento(sistema_nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<boolean> {
        
        try { 

        
            return true;

        } catch (e) {
            await clsTools.PagErrorException(`M0080`, `batch_module_m0005.Procedimento Error`, e)
            return false;
        } finally {
            await clsTools.pagConsole(`Procedimento ${sistema_nucleo_procedimento.sis_nucleo_prc_descricao} finalizado`, true)
            return true;
        }

    }

        static async AtualizacaoDiaria() : Promise<boolean> {
        
        try { 

            await serviceForcaVendaMeta.metasAtuais.start({});
            
            return true;

        } catch (e) {
            await clsTools.PagErrorException(`M0080`, `batch_module_m0005.Procedimento Error`, e)
            return false;
        } finally {
            await clsTools.pagConsole(`Procedimento ${"Atualizacao Diaria"} finalizado`, true)
            return true;
        }

    }
  
  

}
