import { clsTools } from '../../model/modelbase';


import serviceInforme from './service/service';

export default class batch_module_m1000 { 
    static async start (sis_batch_run_seq: number) : Promise<boolean> {

        
        let status: boolean = false;
        try {


   
        } catch (e) {
            clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }

    static async AtualizacaoDiaria() : Promise<boolean> {
        let status: boolean = false;
        try {

            await serviceInforme.if0017.start({})
            await serviceInforme.if0045.start({})
            await serviceInforme.if0100.start({})
            await serviceInforme.if0050.start({})


        } catch (e) {
            clsTools.PagErrorException(`M1000`, `batch_module_m1000.AtualizacaoDiaria Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }


}