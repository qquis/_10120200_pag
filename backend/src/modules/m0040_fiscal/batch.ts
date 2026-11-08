import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';


import service from './service/service'



export default class batch_module_m0040 { 
    static async start (sis_batch_run_seq: number) : Promise<boolean> {

        let mymodelsistema_batch : modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0)
        
        
        await mymodelsistema_batch.modelConsultar(0,sis_batch_run_seq)
        
        let status: boolean = false;
        try {

            switch (mymodelsistema_batch.sistema_batch.sis_batch_cd) {
                case 40005: 
                    await service.FiguraFiscalRegraFiscal.start();    
                    break;

                case 40010: 
                    await service.FiguraFiscalPorProdutoUnitario.start({})
                    
                    /*A atualização da figura nfce ja esta dentro do "atualizarBasePag" */ 
                    //await service.regraFiscalNfceProduto.start({});

                    await service.atualizaMapeamentoFiscal.start();
                    break;
            }
            status = true;
   
        } catch (e) {
            clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }

    static async Procedimento(nucleo_procedimento : modelsistema_nucleo_procedimento) : Promise<boolean> {

        if (!nucleo_procedimento.__atualizado)
            nucleo_procedimento.consultar();


        
        let status: boolean = false;

        try {
                switch (nucleo_procedimento.sis_nucleo_prc_cd) { 
                case 40005: 
                    await service.FiguraFiscalRegraFiscal.start();    
                    break;

                case 40010: 
                    await service.FiguraFiscalPorProdutoUnitario.start({})
                    break;
                }
        } catch (e) {
            clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }
    static async AtualizacaoDiaria() : Promise<boolean> {
        try {
            await service.FiguraFiscalRegraFiscal.start();
            await service.FiguraFiscalPorProdutoNfce.start({});
            await service.FiguraFiscalPorProdutoNfe.start({});
            await service.atualizaMapeamentoFiscal.start();

            return true;
        } catch (e) {
            return false;
        }
    } 
}