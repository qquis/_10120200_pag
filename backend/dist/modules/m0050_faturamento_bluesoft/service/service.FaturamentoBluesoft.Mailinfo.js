"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
const report_1 = __importDefault(require("../report/report"));
const SIS_NUCLEO_PRC_CD = 10050030;
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoft_MailInfo {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let messageLogNucleoProcedimento = `FaturamentoBluesoft - MailInfo Diário [Start: ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}]`;
            try {
                let ProcedimentoExecutadoHoje = yield service_SistemaLog_1.default.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD);
                if (ProcedimentoExecutadoHoje)
                    if (ProcedimentoExecutadoHoje && parametro.executeoverwrite && parametro.executeoverwrite == "1") {
                        modelbase_1.clsTools.pagConsole("Importação de Venda Bluesoft - MAIL já executada hoje. Mas será executada novamente");
                        messageLogNucleoProcedimento = `FaturamentoBluesoft - MAIL ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}`;
                    }
                    else {
                        modelbase_1.clsTools.pagConsole("Importação de Venda Bluesoft - MAIL já executada hoje. Parametro Overwrite não definido ou diferente de 1. Execução cancelada");
                        messageLogNucleoProcedimento += " - Já executado hoje. Execução cancelada";
                        return;
                    }
                else {
                    modelbase_1.clsTools.pagConsole("Importação de Venda Bluesoft - MAIL será executado pela primeira vez hoje");
                    messageLogNucleoProcedimento += " [1a Execução] ";
                }
                /* MAIL DE CORTE POR VENDEDOR */
                yield report_1.default.ForcaVenda.PedidoComCorte.mail_vendedor(parametro);
                // Define período de faturamento:
                // - padrão: mês atual (01 até último dia)
                // - exceção: se hoje for dia 01, usa mês anterior
                const hoje = new Date();
                let anoRef = hoje.getFullYear();
                let mesRef = hoje.getMonth(); // 0..11
                if (hoje.getDate() === 1) {
                    mesRef -= 1;
                    if (mesRef < 0) {
                        mesRef = 11;
                        anoRef -= 1;
                    }
                }
                const dataInicial = new Date(anoRef, mesRef, 1);
                const dataFinal = new Date(anoRef, mesRef + 1, 0);
                parametro.dataFaturamento_parametro = 1;
                parametro.dataFaturamento_ini = modelbase_1.clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD");
                parametro.dataFaturamento_fim = modelbase_1.clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD");
                /* RESUMO SEMANAL DO MES PARA OS SUPERVISORES*/
                yield report_1.default.ForcaVenda.PedidoComCorte.mail_semanal(parametro);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_MailInfo", "start", e);
            }
            finally {
                messageLogNucleoProcedimento += ` - End: ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")} Executado com sucesso`;
                yield service_SistemaLog_1.default.Registrar.submit({
                    sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                    sis_log_tag: "FAT_BLUE_FV_MAIL",
                    sis_log_info: messageLogNucleoProcedimento,
                    sis_batch_run_seq: 0,
                    proc_log_seq: 0,
                    sis_log_seq: 0,
                    uuid_start: "",
                    uuid: ""
                });
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoft_MailInfo;
