import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*
class batch_m4501_45011 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
                myService.servicePrecoAplicado.bluesoftIntegrarPrecosPendentes(sis_batch_run_seq);

                return true;  
        } catch(e) {
            return false;
        }
    }
}

class batch_m4502_45021 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
                //await service.BlueSoftIntegrarAll(sis_batch_run_seq)
                return true;  
        } catch(e) {
            return false;
        }
    }
}

export  { batch_m4501_45011 , batch_m4502_45021}
*/


import service from './service/service'



export default class batch_module_m0045 { 
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
                return true
   
        }
        catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            return false;
        }
    }

    static async Procedimento(nucleo_procedimento : modelsistema_nucleo_procedimento) : Promise<boolean> {

        if (!nucleo_procedimento.__atualizado)
            nucleo_procedimento.consultar();


        
        let status: boolean = false;

        try {
                switch (nucleo_procedimento.sis_nucleo_prc_cd) { 
                    case 45060: 
                        status = await service.AplicarPrecos();
                    break; 
                }
        } catch (e) {
            clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }
}