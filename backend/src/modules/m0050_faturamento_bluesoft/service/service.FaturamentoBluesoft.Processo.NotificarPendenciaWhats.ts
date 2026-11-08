import { clsBase, clsTools } from "../../../model/modelbase";

import reportSistema from "src/modules/m0001_sistema/report/report";

import modelFaturamentoBluesoft_Processo from "../model/modelFaturamentoBluesoft_processo";
import reportFaturamentoBluesoftProcesso from "../report/reportFaturamentoBluesoftProcesso";

const myBase = new clsBase();

export default class serviceFaturamentoBluesoft_NotificacoesPendenciaWhats {

    static async start(parametro : any) { 
        try { 
             

            /*OBTENDO PENDÊNCIAS DE NOTIFICAÇÃO DE WHATS APP*/
            //->>>>>
            let listNotificacoes = await  reportFaturamentoBluesoftProcesso.getFaturamentoFVNotificacoesPendentes(parametro);



            /* PROCESSANDO */
            for await (const itemNotificacao of listNotificacoes as any[]) {
                let modelProcesso : modelFaturamentoBluesoft_Processo = new modelFaturamentoBluesoft_Processo()
                modelProcesso.binding(itemNotificacao)
                await modelProcesso.notificar_bluesoftfaturamento_fv(itemNotificacao)
                

            }

        } catch (e) {
            clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "GerarNotificacoesPendentes", e);
        }

    }


}