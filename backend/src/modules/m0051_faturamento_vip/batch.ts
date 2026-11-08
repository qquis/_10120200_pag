import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceFaturamentoVip    from './service/service';


export default class batch_module_m0051 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {

            await serviceFaturamentoVip.faturamentoPedido.start({});
            return true;
            
        }
        catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            return false;
        }
    }

  

}
