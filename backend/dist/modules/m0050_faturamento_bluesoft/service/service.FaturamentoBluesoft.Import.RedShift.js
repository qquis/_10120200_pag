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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0050 FaturamentoBluesoft (service.FaturamentoBluesoft.Import.RedShift) |";
const FLG_DEBUG_CONSOLE_NOPRINT = false;
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
const report_faturamentoBluesoft_RedShift_1 = __importDefault(require("../report/report.faturamentoBluesoft.RedShift"));
const report_faturamentoBluesoft_RedShift_item_1 = __importDefault(require("../report/report.faturamentoBluesoft.RedShift.item"));
const tbfaturamento_bluesoft_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft"));
const tbfaturamento_bluesoft_item_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_item"));
const SIS_NUCLEO_PRC_CD = 10050011;
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoftImportRedShift {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            yield this.fromRedShift(parametros);
        });
    }
    static fromRedShift() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            let messageLogNucleoProcedimento = `FaturamentoBluesoft - Importação Redshift ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD HH:mm:ss")}`;
            try {
                let i = 0;
                let imax = 50;
                let sql = ``;
                let ProcedimentoExecutadoHoje = yield service_SistemaLog_1.default.Registrar.LogNucleoProcedimentoToday(SIS_NUCLEO_PRC_CD);
                if (ProcedimentoExecutadoHoje)
                    if (ProcedimentoExecutadoHoje && parametro.executeoverwrite && parametro.executeoverwrite == "1") {
                        yield this.__log("Importação de Venda Bluesoft - RedShift já executada hoje. Mas será executada novamente");
                        messageLogNucleoProcedimento = `FaturamentoBluesoft - Importação Redshift - Reexecutado ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD HH:mm:ss")}`;
                    }
                    else {
                        yield this.__log("Importação de Venda Bluesoft - RedShift já executada hoje. Parametro Overwrite não definido ou diferente de 1. Execução cancelada");
                        messageLogNucleoProcedimento += " - Já executado hoje. Execução cancelada";
                        return;
                    }
                else {
                    yield this.__log("Importação de Venda Bluesoft - RedShift será executado pela primeira vez hoje");
                    messageLogNucleoProcedimento += " - Executado pela primeira vez hoje";
                }
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                yield this.__log("Iniciando importação do faturamento bluesoft - RedShift");
                let resultadoFaturamento = yield report_faturamentoBluesoft_RedShift_1.default.get({ tipo_Relatorio: "FATURAMENTO_BLUESOFT", dataProcessamentoIni: dataInicial, dataProcessamentoFim: dataFinal });
                if (!resultadoFaturamento || resultadoFaturamento.length === 0) {
                    yield this.__log("Nenhum registro de faturamento encontrado no RedShift");
                    return;
                }
                yield this.__log("Importação do faturamento bluesoft - RedShift: " + resultadoFaturamento.length + " registros encontrados");
                try {
                    for (var _g = true, _h = __asyncValues(resultadoFaturamento), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                        _c = _j.value;
                        _g = false;
                        const item = _c;
                        let itemModel = new tbfaturamento_bluesoft_1.default;
                        yield itemModel.binding(item);
                        sql += yield itemModel.ScriptFaturamentoBluesoft_RedSfhit();
                        i++;
                        if (i >= imax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                i = 0;
                imax = 60;
                sql = ``;
                yield this.__log("Iniciando importação do faturamento bluesoft - Itens - RedShift");
                let resultFaturamentoBluesoftItem = yield report_faturamentoBluesoft_RedShift_item_1.default.get({ tipo_Relatorio: "FATURAMENTOBLUESOFT_ITEM",
                    dataProcessamentoIni: dataInicial,
                    dataProcessamentoFim: dataFinal });
                yield this.__log("Importação do faturamento bluesoft - Itens - RedShift: " + resultFaturamentoBluesoftItem.length + " registros encontrados");
                try {
                    for (var _k = true, _l = __asyncValues(resultFaturamentoBluesoftItem), _m; _m = yield _l.next(), _d = _m.done, !_d; _k = true) {
                        _f = _m.value;
                        _k = false;
                        const item = _f;
                        let itemModel = new tbfaturamento_bluesoft_item_1.default();
                        yield itemModel.binding(item);
                        sql += yield itemModel.ScriptFaturamentoBluesoft_Insert();
                        sql += yield itemModel.scriptFaturamentoBlueSoft_Update();
                        i++;
                        if (i >= imax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_k && !_d && (_e = _l.return)) yield _e.call(_l);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                messageLogNucleoProcedimento += " - Executado com Sucesso";
            }
            catch (e) {
                messageLogNucleoProcedimento += ` - Erro: ${e}`;
                console.log("-----------------");
                console.log(e);
                console.log("-----------------");
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "start", e);
            }
            finally {
                yield service_SistemaLog_1.default.Registrar.submit({
                    sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                    sis_log_tag: "FAT_BLUE_IMP_REDSHIFT",
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
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(message, FLG_DEBUG_CONSOLE_LOG, FLG_DEBUG_CONSOLE_NOPRINT, FLG_DEBUG_FILE_CONSOLE_LOG, FLG_MODULO);
        });
    }
}
exports.default = serviceFaturamentoBluesoftImportRedShift;
