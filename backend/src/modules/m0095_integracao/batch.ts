import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/



import myTools from "../../tools/Tools";
import service from './service/serviceIntegracao'
import { Numeric } from 'msnodesqlv8';

const myService : service = new service();

export default class batch_module_m0095 {
    public static async start (sis_batch_run_seq: number, uuid_start: string = ``) : Promise<boolean> {
        try {

                await myService.processar(0,sis_batch_run_seq, uuid_start)
                return true;  
        } catch(e) {
            clsTools.PagErrorException(`M0095_INTEGRACAO`, `batch_module_m0095.start Error`, e)
            throw new Error(`M0095_INTEGRACAO | ERROR \n ${e}`) 
        }
    }
  
    static async Procedimento(nucleo_procedimento : modelsistema_nucleo_procedimento) : Promise<boolean> {

        if (!nucleo_procedimento.__atualizado)
            nucleo_procedimento.consultar();

        
        let status: boolean = false;
        try {
                switch (nucleo_procedimento.sis_nucleo_prc_cd) { 
                    case 95101: 
                        await myService.processar(0,0,'',nucleo_procedimento.sis_nucleo_prc_cd)
                    break; 
                    case 85002: 
                        await myService.processar(0,0,'',nucleo_procedimento.sis_nucleo_prc_cd)
                    break;
                    case 95011: 
                        await myService.processar(0,0,'',nucleo_procedimento.sis_nucleo_prc_cd)
                    break;                                         
                }
            status = true;
        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            nucleo_procedimento.ErrorMessage = `ERROR ${e}`;
            status = false
        }
        finally {
            return status;
        }
    }
}