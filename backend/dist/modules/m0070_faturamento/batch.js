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
const modelbase_1 = require("../../model/modelbase");
const report_1 = __importDefault(require("../m0001_sistema/report/report"));
const serviceFaturamentoBluesoftProcessar_1 = __importDefault(require("./service/serviceFaturamentoBluesoftProcessar"));
const serviceFaturamentoContratoProcessarApurar_1 = __importDefault(require("./service/serviceFaturamentoContratoProcessarApurar"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0070-FATURAMENTO __ batch_module_m0070 PROCEDIMENTOS __ | Faturamento ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class batch_module_m0070 {
    static Procedimento(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.AtualizacaoDiaria();
                return true;
            }
            catch (e) {
                return false;
            }
            finally {
                return true;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.__log("Coletando os dados do processamento atual tbsistema_operacional sis_operacional_default = 1 ");
                let DadosProcessamento = yield report_1.default.Operacional.getDefault();
                const _hoje = modelbase_1.clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD");
                const dataLimite = DadosProcessamento.faturamento_data_limite;
                if (_hoje > dataLimite) {
                    yield this.__log(`Data limite de faturamento ultrapassada: ${dataLimite}`);
                }
                else {
                    yield this.__log(`Data limite de faturamento ainda não atingida - O Processamento será realizado: ${dataLimite}`);
                }
                console.log(DadosProcessamento);
                const dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_ini, "YYYY-MM-DD");
                const dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_fim, "YYYY-MM-DD");
                console.log(dataInicial);
                if (Number.isNaN(dataInicial.getTime()) || Number.isNaN(dataFinal.getTime()) || dataInicial > dataFinal) {
                    throw new Error("Período de processamento inválido.");
                }
                for (let data = new Date(dataInicial); data <= dataFinal; data.setUTCDate(data.getUTCDate() + 1)) {
                    const dataProcessamento = modelbase_1.clsTools._datemomentDateToStr(data, "YYYY-MM-DD");
                    if (dataProcessamento >= _hoje) {
                        yield this.__log(`Data de processamento ${dataProcessamento} é maior ou igual a hoje ${_hoje}`);
                        break;
                    }
                    const dataprocessamento = modelbase_1.clsTools._datemomentDateToStr(data, "YYYY-MM-DD");
                    const parametro = { data_processamento: dataprocessamento };
                    yield this.__log(`Processando a data: ${dataprocessamento}`);
                    yield serviceFaturamentoBluesoftProcessar_1.default.start(parametro);
                    yield this.__log(`Processando concluído para a data: ${dataprocessamento}`);
                }
                yield this.__log(`Iniciando processamento do faturamento contrato para a competência ${DadosProcessamento.competencia_cd}`);
                let dadosContrato = {
                    op_cdoperacao: 4,
                    dataFaturamento_filter: 1,
                    faturamento_controle_seq: 0,
                    competencia_cd: DadosProcessamento.competencia_cd,
                    contrato_seq: 0,
                    data_val_ini: modelbase_1.clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_ini, "YYYY-MM-DD"),
                    data_val_fim: modelbase_1.clsTools._datemomentDatStrToDate(DadosProcessamento.data_competencia_fim, "YYYY-MM-DD")
                };
                yield serviceFaturamentoContratoProcessarApurar_1.default.start(dadosContrato);
                return true;
            }
            catch (e) {
                return false;
            }
        });
    }
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(message, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG, FLG_MODULO);
        });
    }
}
exports.default = batch_module_m0070;
