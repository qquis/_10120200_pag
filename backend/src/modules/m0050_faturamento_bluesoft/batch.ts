import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceFaturamentoBluesoft    from './service/service';


export default class batch_module_m0050 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {

            
            
            await serviceFaturamentoBluesoft.processamentoPendente();
            
            return true;
            
        }
        catch (e) {
            clsTools.PagErrorException(`M0050`, `batch_module_m0050.start Error`, e)
            return false;
        }
    }

      static async AtualizacaoDiaria() : Promise<boolean> {
          try {
              
            const hoje = new Date();
            const addDias = (d: Date, n: number) => { const r = new Date(d); r.setDate(r.getDate() + n); return r; };
            const fmt = (d: Date) => d.toISOString().slice(0, 10);
            let parametro: any = {};
            parametro.dataInicial = fmt(addDias(hoje, -45)); // 2026-09-06
            parametro.dataFinal   = fmt(addDias(hoje, -1));  // 2026-10-20

            await serviceFaturamentoBluesoft.ImportFromRedShift.start(parametro);
  
              return true;
          } catch (e) {
              return false;
          }
      }  

}
