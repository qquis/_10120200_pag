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
const service_FaturamentoBluesoft_Import_RedShift_1 = __importDefault(require("./service.FaturamentoBluesoft.Import.RedShift"));
const service_FaturamentoBluesoft_Import_ForcaVendaApi_1 = __importDefault(require("./service.FaturamentoBluesoft.Import.ForcaVendaApi"));
const service_FaturamentoBluesoft_MailinfoDiario_1 = __importDefault(require("./service.FaturamentoBluesoft.MailinfoDiario"));
const service_FaturamentoBluesoft_Processo_Registrar_1 = __importDefault(require("./service.FaturamentoBluesoft.Processo.Registrar"));
const service_FaturamentoBluesoft_Processo_NotificarPendenciaWhats_1 = __importDefault(require("./service.FaturamentoBluesoft.Processo.NotificarPendenciaWhats"));
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
const SIS_NUCLEO_PRC_CD = 10050001;
class serviceFaturamentoBluesoft {
    static processamentoPendente() {
        return __awaiter(this, void 0, void 0, function* () {
            let messageLogNucleoProcedimento = `FaturamentoBluesoft - Processamento Pendente Diário [Start: ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")}]`;
            try {
                let dataInicial = modelbase_1.clsTools._datemomentSubtractDays(new Date(), 10);
                let dataFinal = new Date();
                /*__ PROCESSAMENTO DE VENDAS REDSHIFT __________________________________________________________*/
                dataInicial = modelbase_1.clsTools._datemomentSubtractDays(new Date(), 10);
                let parametroImportacaoRedShift = {
                    dataInicial: modelbase_1.clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                    dataFinal: modelbase_1.clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                    executeoverwrite: "0"
                };
                if (!(yield service_SistemaLog_1.default.Registrar.LogNucleoProcedimentoToday(10050011))) {
                    yield this.ImportFromRedShift.fromRedShift(parametroImportacaoRedShift);
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
                if (!(yield service_SistemaLog_1.default.Registrar.LogNucleoProcedimentoToday(10050030))) {
                    yield this.MailInfo.start({});
                }
                /*______________________________________________________________________________________________*/
                /*__ NOTIFICAÇÕES DE WHATSAPP PARA EQUIPE DE VENDAS_______________________________________________*/
                dataInicial = modelbase_1.clsTools._datemomentSubtractDays(new Date(), 5);
                let ParametroNotificaoPendenteWhatsAPP = {
                    dataInicial: modelbase_1.clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD"),
                    dataFinal: modelbase_1.clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD"),
                };
                yield this.NotificarWhats.start(ParametroNotificaoPendenteWhatsAPP);
                /*______________________________________________________________________________________________*/
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft.processamentoPendente", "Error processamentoPendente", e);
            }
            finally {
                messageLogNucleoProcedimento += ` - End: ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "HH:mm:ss")} Executado com sucesso`;
                yield service_SistemaLog_1.default.Registrar.submit({
                    sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                    sis_log_tag: "FAT_BLUE_SERVICE",
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
serviceFaturamentoBluesoft.ImportFromRedShift = service_FaturamentoBluesoft_Import_RedShift_1.default;
serviceFaturamentoBluesoft.ImportForcaVendaApi = service_FaturamentoBluesoft_Import_ForcaVendaApi_1.default;
serviceFaturamentoBluesoft.MailInfo = service_FaturamentoBluesoft_MailinfoDiario_1.default;
serviceFaturamentoBluesoft.ProcessoRegistrar = service_FaturamentoBluesoft_Processo_Registrar_1.default;
serviceFaturamentoBluesoft.NotificarWhats = service_FaturamentoBluesoft_Processo_NotificarPendenciaWhats_1.default;
exports.default = serviceFaturamentoBluesoft;
