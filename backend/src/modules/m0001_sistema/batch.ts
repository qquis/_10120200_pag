import { clsTools } from '../../model/modelbase';

//import serviceSistema from './service/serviceSistema'

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';


import serviceSistemaNotificarFuncionamento from './service/serviceSistemaNotificarFuncionamento';

export default class batch_module_m0001 { 
    
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
            let sistema_batch : modelsistema_ServiceBatch = await reportSistemaBatch.ConsultarRegistroSisBath(sis_batch_run_seq);


            switch (sistema_batch.sistema_batch.sis_batch_cd) {
                case 11: 
                    await serviceSistemaNotificarFuncionamento.start();
                    break;
            }
            return true 
        } catch (e) {
            return false;
        }
    }

}