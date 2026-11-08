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
const report_faturamentoBluesoft_RedShift_1 = __importDefault(require("../report/report.faturamentoBluesoft.RedShift"));
const report_faturamentoBluesoft_RedShift_item_1 = __importDefault(require("../report/report.faturamentoBluesoft.RedShift.item"));
const tbfaturamento_bluesoft_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft"));
const tbfaturamento_bluesoft_item_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_item"));
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoftImport {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.fromRedShift();
            //await this.fromApi();
        });
    }
    static fromRedShift() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            try {
                let i = 0;
                let imax = 50;
                let sql = ``;
                console.log("Iniciando importação do faturamento bluesoft - RedShift");
                let resultadoFaturamento = yield report_faturamentoBluesoft_RedShift_1.default.get({ tipo_Relatorio: "FATURAMENTO_BLUESOFT", dataProcessamentoIni: "2026-03-10", dataProcessamentoFim: "2026-03-10" });
                console.log("Importação do faturamento bluesoft - RedShift: " + resultadoFaturamento.length + " registros encontrados");
                try {
                    for (var _g = true, _h = __asyncValues(resultadoFaturamento), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                        _c = _j.value;
                        _g = false;
                        const item = _c;
                        let itemModel = new tbfaturamento_bluesoft_1.default;
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
                console.log("Iniciando importação do faturamento bluesoft - Itens - RedShift");
                let resultFaturamentoBluesoftItem = yield report_faturamentoBluesoft_RedShift_item_1.default.get({ tipo_Relatorio: "FATURAMENTOBLUESOFT_ITEM",
                    dataProcessamentoIni: "2026-03-10",
                    dataProcessamentoFim: "2026-03-10" });
                console.log("Importação do faturamento bluesoft - Itens - RedShift: " + resultFaturamentoBluesoftItem.length + " registros encontrados");
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
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "start", e);
            }
        });
    }
    static fromApiStatusPedido() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_3, _b, _c, _d, e_4, _e, _f;
            var _g;
            try {
                let result = yield myBase.blueSoftApi.api_get("forca-de-vendas/pedidos?dataEmissaoInicial=27/04/2026 00:01&dataEmissaoFinal=27/04/2026 23:59");
                let ListPedidos = (_g = result === null || result === void 0 ? void 0 : result.data) === null || _g === void 0 ? void 0 : _g.data;
                let listTipoStatus = [];
                try {
                    for (var _h = true, ListPedidos_1 = __asyncValues(ListPedidos), ListPedidos_1_1; ListPedidos_1_1 = yield ListPedidos_1.next(), _a = ListPedidos_1_1.done, !_a; _h = true) {
                        _c = ListPedidos_1_1.value;
                        _h = false;
                        const pedidoForcaVenda = _c;
                        try {
                            for (var _j = true, _k = (e_4 = void 0, __asyncValues(pedidoForcaVenda.clientes)), _l; _l = yield _k.next(), _d = _l.done, !_d; _j = true) {
                                _f = _l.value;
                                _j = false;
                                const pedidoCliente = _f;
                                const statusExistente = listTipoStatus.some((item) => item.pedidoVendaStatusKey == pedidoCliente.pedidoVendaStatusKey);
                                if (!statusExistente) {
                                    listTipoStatus.push({
                                        pedidoVendaStatusKey: pedidoCliente.pedidoVendaStatusKey,
                                        pedidoVendaStatus: pedidoCliente.pedidoVendaStatus
                                    });
                                }
                            }
                        }
                        catch (e_4_1) { e_4 = { error: e_4_1 }; }
                        finally {
                            try {
                                if (!_j && !_d && (_e = _k.return)) yield _e.call(_k);
                            }
                            finally { if (e_4) throw e_4.error; }
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_h && !_a && (_b = ListPedidos_1.return)) yield _b.call(ListPedidos_1);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                console.log(listTipoStatus);
                return;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "fromApiStatusPedido", e);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoftImport;
