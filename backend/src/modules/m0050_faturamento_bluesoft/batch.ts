import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceFaturamentoBluesoft    from './service/service';
import reportSistema from '../m0001_sistema/report/report';

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
              

            let dadosSistemaOperacional : any = await reportSistema.Operacional.getDefault()
            console.log(dadosSistemaOperacional)

            let parametro: any = {};
            parametro.dataInicial = dadosSistemaOperacional.data_processamento_venda_ini
            parametro.dataFinal   = dadosSistemaOperacional.data_processamento_venda_fim;  // 2026-10-20

            
            await serviceFaturamentoBluesoft.ImportFromRedShift.start(parametro);
  
              return true;
          } catch (e) {
              return false;
          }
      }  

}
