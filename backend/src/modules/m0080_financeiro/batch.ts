import { clsTools } from '../../model/modelbase';

/*Controles de Baths */
import reportSistemaBatch from '../m9030_sistema_batch/report/report';
import modelsistema_ServiceBatch from '../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';
/*-----------------------------------------------------*/


/* Serviços */
import serviceAutorizacaoPgto from './service/serviceAutorizacaoPgto'
import serviceMovimentoCaixaBluesoftImportar from './service/serviceMovimentoCaixaBluesoft'


export default class batch_module_m0080 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {


            let item: modelsistema_ServiceBatch = await reportSistemaBatch.ConsultarRegistroSisBath(sis_batch_run_seq);
            switch (item.sistema_batch.sis_batch_cd) { 
                case 80011: 
                    await serviceAutorizacaoPgto.Atualizar(sis_batch_run_seq)
                    break;
                case 80021:
                    await this.executeListProcedimentos(item)
                    break; 
                default:
                    clsTools.pagConsole(`Batch M0080 não implementado para o código ${item.sistema_batch.sis_batch_cd}`, true)

            }

            return true;
            
        }
        catch (e) {
            await clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            return false;
        }
    }

    static async executeListProcedimentos(modelsistema_batch: modelsistema_ServiceBatch) : Promise<object> { 
        try { 

            for (let i = 0; i <= modelsistema_batch.listProcedimentos.length; i++) {
                    await modelsistema_batch.listProcedimentos[i].iniciarExecucao();
                    await this.Procedimento(modelsistema_batch.listProcedimentos[i]);
                    await modelsistema_batch.listProcedimentos[i].finalizarExecucao();
            }


        } catch (e) {
            await clsTools.PagErrorException(`M0080`, `serviceMovimentoCaixaBluesoft.execute Error`, e)
            
        } finally {
            await clsTools.pagConsole(`Service Movimento Caixa Bluesoft finalizado`, true)
            return modelsistema_batch.listProcedimentos;
        }

    }

    
    static async Procedimento(sistema_nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<boolean> {

        if (!sistema_nucleo_procedimento.__atualizado)
            sistema_nucleo_procedimento.consultar();

        
        let status: boolean = false;

        try {
                switch (sistema_nucleo_procedimento.sis_nucleo_prc_cd) { 
                    case 8002: 
                        status = false;
                        let result = await serviceMovimentoCaixaBluesoftImportar.start(sistema_nucleo_procedimento)
                        if (result)
                            status = true;
                        break; 
                }
            
        } catch (e) {
            await clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e)
            status = false
        }
        finally {
            return status;
        }
    }

    static async AtualizacaoDiaria() : Promise<boolean> {
        let status: boolean = false;
        try {
            let nucleo_procedimento: modelsistema_nucleo_procedimento = new modelsistema_nucleo_procedimento();
            nucleo_procedimento.sis_nucleo_prc_cd = 8002;
            await nucleo_procedimento.consultar();
            await serviceMovimentoCaixaBluesoftImportar.start(nucleo_procedimento);
            status = true;
        } catch (e) {
            await clsTools.PagErrorException(`M0080`, `batch_module_m0080.AtualizacaoDiaria Error`, e)
            status = false;
        } finally {
            return status;
        }
    }

}
