import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceForcaVenda from './service/service'


export default class batch_module_m0004 {


    static async Procedimento(sistema_nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<boolean> {
        
        try { 

            /*Importação dos prazos de pagamento */
            await serviceForcaVenda.prazoPgto.start();

            /*Importação das tabelas/versão/produto*/
            await serviceForcaVenda.tabelaPreco.start();
            
            return true;

        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0004.Procedimento Error`, e)
            return false;
        } finally {
            clsTools.pagConsole(`Procedimento ${sistema_nucleo_procedimento.sis_nucleo_prc_descricao} finalizado`, true)
            return true;
        }

    }

        static async AtualizacaoDiaria() : Promise<boolean> {
        
        try { 

            /*Importação dos prazos de pagamento */
            await serviceForcaVenda.prazoPgto.start();

            /*Importação das tabelas/versão/produto*/
            await serviceForcaVenda.tabelaPreco.start();
            
            return true;

        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0004.Procedimento Error`, e)
            return false;
        } finally {
            clsTools.pagConsole(`Procedimento ${"Atualizacao Diaria"} finalizado`, true)
            return true;
        }

    }
  
  

}
