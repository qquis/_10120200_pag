
import { clsBase, clsTools } from "../../../model/modelbase";
import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M9030 - Sistema Batch | INICIALIZAÇÃO DIÁRIA"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = `inicializacao_diaria`
/*  ------------------------------------------------------------------------------------------- */    



/*MODULOS*/
/* Serviços */
import batch_module_m0080 from '../../m0080_financeiro/batch'
import batch_module_m0011 from '../../m0011_participante/batch'
import batch_module_m0004 from "../../m0004_forcavenda/batch";
import batch_module_m0150 from "../../m0150_estatistica/batch";
import batch_module_m0021 from '../../m0021_produtobluesoft/batch'
import batch_module_m0040 from '../../m0040_fiscal/batch'
import batch_module_m0085 from '../../m0085_zanthus/batch'
import batch_module_m0050 from '../../m0050_faturamento_bluesoft/batch'
import batch_module_m0005 from '../../m0005_forcavenda_meta/batch'

import batch_module_m0070 from '../../m0070_faturamento/batch'
import batch_module_m1000 from '../../m1000_informe/batch'
import { Console } from "console";





export default class ServiceSistemaBatchInicializacaoDiaria {
    
    static async start(parametros: any = {}) {
        let statusExecucao : any = true
        try {  


            let messageWhats: string[] = []
            
            await clsTools.pagConsole(`${FLG_MODULO} | Início da execução`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await serviceNotificacao.Criar({notificacao_cd : 1009030001
                                    , notificacao_send_tipo_cd : 100
                                    , notificacao_send_message : `🔄 Atualização Diária | Start`})

            
            /*PRODUTO BLUESOFT*/
            await clsTools.pagConsole(`${FLG_MODULO} | PRODUTO BLUESOFT - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0021.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | PRODUTO BLUESOFT - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ PRODUTO BLUESOFT - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);

            /*FISCAL*/
            await clsTools.pagConsole(`${FLG_MODULO} | FISCAL - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0040.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | FISCAL - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ FISCAL - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);

            /*IMPORTACAO DE PARTICIPANTES*/
            await clsTools.pagConsole(`${FLG_MODULO} | PARTICIPANTES - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0011.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | PARTICIPANTES - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ PARTICIPANTES - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);
            
            
            
            /*ZANTHUS*/
            await clsTools.pagConsole(`${FLG_MODULO} | ZANTHUS - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0085.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | ZANTHUS - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ ZANTHUS - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);
            
            //FINANCEIRO - Importação do Movimento Caixa Diário
            await clsTools.pagConsole(`${FLG_MODULO} | MOVIMENTO CAIXA - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0080.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | MOVIMENTO CAIXA - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ MOVIMENTO CAIXA - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);


            /*IMPORTAÇÃO FATURAMENTO BLUESOFT*/
            await clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO BLUESOFT - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0050.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO BLUESOFT - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ FATURAMENTO BLUESOFT - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);




            /*IMPORTAÇÃO FATURAMENTO PROCESSAMENTO DE VENDA - FATURAMENTO PAG ---------$ $ $ $ $ $ $*/
            await clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO CONTRATO - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0070.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | FATURAMENTO CONTRATO - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ FATURAMENTO CONTRATO - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);



            /*FORÇA DE VENDA*/
            await clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0004.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ FORÇA DE VENDA - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);




            /*FORÇA DE VENDA META*/
            await clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA META - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0005.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | FORÇA DE VENDA META - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ FORÇA DE VENDA META - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);



            /*M1000 INFORME - IFS*/
            await clsTools.pagConsole(`${FLG_MODULO} | M1000 INFORME - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m1000.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | M1000 INFORME - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ M1000 INFORME - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);













            /*DADOS ESTATÍSTICOS*/
            await clsTools.pagConsole(`${FLG_MODULO} | DADOS ESTATÍSTICOS - Inicializada`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            statusExecucao = await batch_module_m0150.AtualizacaoDiaria();
            await clsTools.pagConsole(`${FLG_MODULO} | DADOS ESTATÍSTICOS - Finalizada | Status    ${statusExecucao}`,FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            messageWhats.push(`✅ DADOS ESTATÍSTICOS - Finalizada | Status    ${statusExecucao}`)
            await clsTools._wait(1000);


            let messageWhatsStr = messageWhats.join('\n');


            await serviceNotificacao.Criar({notificacao_cd : 1009030001
                                    , notificacao_send_tipo_cd : 100
                                    , notificacao_send_message : `🔄 Atualização Diária | Concluído\n\n${messageWhatsStr}`})            
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `ServiceSistemaBatchInicializacaoDiaria.start Error`, e)
            return false;
        }
        finally {
            return statusExecucao;
        }
    }
    
}