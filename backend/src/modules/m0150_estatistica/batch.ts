import { clsTools } from '../../model/modelbase';


import serviceEstatistica from '../m0150_estatistica/service/Service';

import modelsistema_nucleo_procedimento from '../m9030_sistema_batch/model/modelsistema_nucleo_procedimento';


export default class batch_module_m0150 { 
    
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {

            /*Atualiza os dados estatísticos com base no parâmetro (default 45 dias) */
                await serviceEstatistica.Faturamento.processar.dailyExec()
                await serviceEstatistica.Faturamento.processar.onLineExec();
            return true 

        } catch (e) {
            return false;
        }
    }

    static async startProcedimento (modelsistemanucleoprocedimento: any) : Promise<boolean> {
        let statusExecucao: boolean = false;
        try { 

            if (modelsistemanucleoprocedimento.sis_nucleo_prc_cd == 10150010) {
                await serviceEstatistica.Faturamento.processar.dailyExec()
                await serviceEstatistica.Faturamento.processar.onLineExec();
                statusExecucao = true;
            }
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e)
        }
        finally {
            return statusExecucao;
        }
        
    
    }

        static async AtualizacaoDiaria () : Promise<boolean> {
        let statusExecucao: boolean = false;
        try { 

            let modelsistemanucleoprocedimento: modelsistema_nucleo_procedimento = new modelsistema_nucleo_procedimento();
            modelsistemanucleoprocedimento.sis_nucleo_prc_cd = 10150010;
            modelsistemanucleoprocedimento.consultar();

            if (modelsistemanucleoprocedimento.sis_nucleo_prc_cd == 10150010) {
                await serviceEstatistica.Faturamento.processar.dailyExec()
                await serviceEstatistica.Faturamento.processar.onLineExec();
                statusExecucao = true;
            }
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e)
        }
        finally {
            return statusExecucao;
        }
        
    
    }

}