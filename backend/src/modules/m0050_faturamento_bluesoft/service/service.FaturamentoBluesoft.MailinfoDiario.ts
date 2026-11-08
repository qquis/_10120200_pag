import { clsBase, clsTools } from "../../../model/modelbase";
import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";

import reportFaturamentoBluesoft from "../report/report";

const SIS_NUCLEO_PRC_CD = 10050030


const myBase = new clsBase();

export default class serviceFaturamentoBluesoft_MailInfoDiario {

    static async start(parametro : any) { 
        let messageLogNucleoProcedimento = `FaturamentoBluesoft - MailInfo Diário [Start: ${clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}]`
        try { 
            let ProcedimentoExecutadoHoje : boolean = await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD);

             if (ProcedimentoExecutadoHoje)
                if ( ProcedimentoExecutadoHoje && parametro.executeoverwrite && parametro.executeoverwrite == "1") {
                    clsTools.pagConsole("Importação de Venda Bluesoft - MAIL já executada hoje. Mas será executada novamente");
                    messageLogNucleoProcedimento = `FaturamentoBluesoft - MAIL ${clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}`
                }
                else { 
                    clsTools.pagConsole("Importação de Venda Bluesoft - MAIL já executada hoje. Parametro Overwrite não definido ou diferente de 1. Execução cancelada");
                    messageLogNucleoProcedimento += " - Já executado hoje. Execução cancelada"
                    return
                }
             else { 
                clsTools.pagConsole("Importação de Venda Bluesoft - MAIL será executado pela primeira vez hoje");
                messageLogNucleoProcedimento += " [1a Execução] "
            }





            const hoje = new Date();

            let anoRef = hoje.getFullYear();
            let mesRef = hoje.getMonth(); // 0..11

            if (hoje.getDate() === 1) { //SE FOR DIA PRIMEIRO, DEVE PROCESSAR O MES ANTERIOR
                mesRef -= 1;
                if (mesRef < 0) {
                    mesRef = 11;
                    anoRef -= 1;
                }
            }

            const dataFaturamentoIni = new Date(anoRef, mesRef, 1);
            const dataFaturamentoFim = new Date(anoRef, mesRef + 1, 0);


            const dataInicial = new Date(anoRef, mesRef, 1);
            const dataFinal = new Date(anoRef, mesRef + 1, 0);

            parametro.dataFaturamento_filter = 1;
            parametro.dataFaturamento_ini = clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD");
            parametro.dataFaturamento_fim = clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD");
            parametro.mail_to = "" // EMAIL DIÁRIO DEVE ENVIAR OBRIGATORIAMENTE PARA CADA VENDEDOR INDIVIDUALMENTE
            
            await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.mail_vendedor(parametro)

            /* RESUMO SEMANAL DO MES PARA OS SUPERVISORES*/
            parametro.mail_to = "distribuicao@oxan.com.br";
            await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.mail_semanal(parametro)


        } catch (e) {
            clsTools.PagErrorException("serviceFaturamentoBluesoft_MailInfo", "start", e)
        }

        finally { 
            messageLogNucleoProcedimento += ` - End: ${clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")} Executado com sucesso`
              await serviceSistemaLog.Registrar.submit({
                  sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                  sis_log_tag: "FAT_BLUE_FV_MAIL",
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