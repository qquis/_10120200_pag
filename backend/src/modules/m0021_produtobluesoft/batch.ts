import { clsTools } from '../../model/modelbase';

//import serviceSistema from './service/serviceSistema'

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';

import serviceProdutoBluesoft from './service/service';




export default class batch_module_m0021 { 
    
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
            
            let sistema_batch : modelsistema_ServiceBatch = await reportSistemaBatch.ConsultarRegistroSisBath(sis_batch_run_seq);
            clsTools.pagConsole(`Importação de Produto acionada via BATCH SEQ ${sis_batch_run_seq} | Modulo ${sistema_batch.sistema_batch.module_cd} | Batch cd ${sistema_batch.sistema_batch.sis_batch_cd}`, true, false);
            
            switch (sistema_batch.sistema_batch.sis_batch_cd) {
                case 95100: 
                    await serviceProdutoBluesoft.Importar.start({numeroDiasUltimaAlteracao: 1})
                    break; 
                case 95101: 
                    await serviceProdutoBluesoft.Importar.start({numeroDiasUltimaAlteracao: 2})
                    break; 
                case 95102: 
                    await serviceProdutoBluesoft.Importar.start({numeroDiasUltimaAlteracao: 1})
                    break; 
                default:
                    await serviceProdutoBluesoft.Importar.start({numeroDiasUltimaAlteracao: 1})
                    break;
            }

            return true 
        } catch (e) {
            return false;
        }
    }

    static async AtualizacaoDiaria() : Promise<boolean> {
        try {
            await serviceProdutoBluesoft.Importar.start({numeroDiasUltimaAlteracao: 1})
            return true;
        } catch (e) {
            return false;
        }
    }   

}