import { clsBase, clsTools } from "../../../model/modelbase";

import serviceFaturamentoBluesoftImportRedShift from "./service.FaturamentoBluesoft.Import.RedShift";
import serviceFaturamentoBluesoftImportForcaVendaApi from "./service.FaturamentoBluesoft.Import.ForcaVendaApi";
import serviceFaturamentoBluesoft_MailInfoDiario from "./service.FaturamentoBluesoft.MailinfoDiario";
import serviceFaturamentoBluesoft_Processo_Registrar from "./service.FaturamentoBluesoft.Processo.Registrar";
import serviceFaturamentoBluesoft_NotificacoesPendenciaWhats from "./service.FaturamentoBluesoft.Processo.NotificarPendenciaWhats";

import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";



const SIS_NUCLEO_PRC_CD = 10050001


export default class serviceFaturamentoBluesoft { 
    static ImportFromRedShift = serviceFaturamentoBluesoftImportRedShift
    static ImportForcaVendaApi = serviceFaturamentoBluesoftImportForcaVendaApi
    static MailInfo = serviceFaturamentoBluesoft_MailInfoDiario
    static ProcessoRegistrar = serviceFaturamentoBluesoft_Processo_Registrar
    static NotificarWhats = serviceFaturamentoBluesoft_NotificacoesPendenciaWhats

    static async processamentoPendente() { 
        let messageLogNucleoProcedimento = `FaturamentoBluesoft - Processamento Pendente Diário [Start: ${clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}]`
        try { 

                let dataInicial : Date = clsTools._datemomentSubtractDays(new Date(), 10)
                let dataFinal : Date = new Date()

                
                
                
                /*__ PROCESSAMENTO DE VENDAS REDSHIFT __________________________________________________________*/
                dataInicial = clsTools._datemomentSubtractDays(new Date(), 10)
                let parametroImportacaoRedShift = { 
                    dataInicial: clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                    dataFinal: clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                    executeoverwrite: "0"
                }
                if(!await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(10050011)) {
                    await this.ImportFromRedShift.fromRedShift(parametroImportacaoRedShift)
                }
                /*______________________________________________________________________________________________*/



                /*__ PROCESSAMENTO DE VENDAS API ________________________________________________________________*/
                //dataInicial = clsTools._datemomentSubtractDays(new Date(), 5)
                //let parametroImportacaoForcaVendaApi = { 
                //    dataInicial: clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                //    dataFinal: clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                //    tipo_periodo: "EMISSAO",
                //    executeoverwrite: "0"
                //}
                //await this.ImportForcaVendaApi.start(parametroImportacaoForcaVendaApi)
                /*______________________________________________________________________________________________*/


                /*__ PROCESSAMENTO DE VENDAS API ________________________________________________________________*/
                //dataInicial = clsTools._datemomentSubtractDays(new Date(), 5)
                //let parametroParaProcessamento = { 
                //    dataInicial: clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                //    dataFinal: clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                //    tipo_periodo: "EMISSAO",
                //    executeoverwrite: "0"
                //}
                //await serviceFaturamentoBluesoft_Processo_Registrar.start(parametroParaProcessamento)
                /*______________________________________________________________________________________________*/        



                /*__ NOTIFICAÇÕES DE E-MAIL PARA EQUIPE DE VENDAS_______________________________________________*/


                

                
                if(!await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(10050030)) {
                    await this.MailInfo.start({})
                }
                /*______________________________________________________________________________________________*/

                
                
                /*__ NOTIFICAÇÕES DE WHATSAPP PARA EQUIPE DE VENDAS_______________________________________________*/
                dataInicial = clsTools._datemomentSubtractDays(new Date(), 5)
                let ParametroNotificaoPendenteWhatsAPP = { 
                    dataInicial: clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                    dataFinal: clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                }
                await this.NotificarWhats.start(ParametroNotificaoPendenteWhatsAPP)
                
                /*______________________________________________________________________________________________*/

        } catch (e) { 
            clsTools.PagErrorException("serviceFaturamentoBluesoft.processamentoPendente", "Error processamentoPendente", e)
        }
        finally {
             messageLogNucleoProcedimento += ` - End: ${clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")} Executado com sucesso`
             await serviceSistemaLog.Registrar.submit({
                       sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                       sis_log_tag: "FAT_BLUE_SERVICE",
                       sis_log_info: messageLogNucleoProcedimento,
                       sis_batch_run_seq: 0,
                       proc_log_seq: 0,
                       sis_log_seq: 0,
                       uuid_start: "",
                       uuid: ""
                   })
        }
    }
}