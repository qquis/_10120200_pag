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
const tbfaturamento_bluesoft_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft"));
const tbfaturamento_bluesoft_fv_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv"));
const tbfaturamento_bluesoft_fv_cliente_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_cliente"));
const tbfaturamento_bluesoft_fv_nf_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_nf"));
const tbfaturamento_bluesoft_fv_item_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_item"));
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoftImportFromApi {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.fromApi();
        });
    }
    static fromApi() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f, _g, e_3, _h, _j;
            var _k;
            try {
                let result = yield myBase.blueSoftApi.api_get("forca-de-vendas/pedidos?dataEmissaoInicial=10/03/2026 00:01&dataEmissaoFinal=10/03/2026 23:59");
                let ListPedidos = (_k = result === null || result === void 0 ? void 0 : result.data) === null || _k === void 0 ? void 0 : _k.data;
                let i = 0;
                let imax = 100;
                let sql = ``;
                try {
                    //for await (const pedidoForcaVenda of ListPedidos) {
                    //    console.log(pedidoForcaVenda)
                    //}
                    //return 
                    for (var _l = true, ListPedidos_1 = __asyncValues(ListPedidos), ListPedidos_1_1; ListPedidos_1_1 = yield ListPedidos_1.next(), _a = ListPedidos_1_1.done, !_a; _l = true) {
                        _c = ListPedidos_1_1.value;
                        _l = false;
                        const pedidoForcaVenda = _c;
                        console.log(pedidoForcaVenda);
                        /* Le o cabeçalho dos itens PEDIDO FORÇA DE VENDA */
                        let itemTbFaturamentoBluesoftFv = new tbfaturamento_bluesoft_fv_1.default();
                        yield itemTbFaturamentoBluesoftFv.bindingFromApiForcaVenda(pedidoForcaVenda);
                        sql += yield itemTbFaturamentoBluesoftFv.scriptSqlInsert();
                        try {
                            /* Le os Pedidos dos clientes filhos do GRUPO ECONOMICO */
                            for (var _m = true, _o = (e_2 = void 0, __asyncValues(pedidoForcaVenda.clientes)), _p; _p = yield _o.next(), _d = _p.done, !_d; _m = true) {
                                _f = _p.value;
                                _m = false;
                                const pedidoCliente = _f;
                                /*Tabela tbforca_venda_pedido_cliente - para controle de pedidos x clientes */
                                let itemTbFaturamentoBluesoftFvCliente = new tbfaturamento_bluesoft_fv_cliente_1.default();
                                yield itemTbFaturamentoBluesoftFvCliente.bindingFromApiForcaVenda(pedidoCliente, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                sql += yield itemTbFaturamentoBluesoftFvCliente.scriptSqlInsert();
                                /*Tabela de Faturamento FV - Nota Fiscal */
                                let itemTbFaturamentoBluesoftFvNf = new tbfaturamento_bluesoft_fv_nf_1.default();
                                if (pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.nfKey) { //se existir nf
                                    if ((pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.nfKey) > 0) {
                                        yield itemTbFaturamentoBluesoftFvNf.bindingFromApiForcaVenda(pedidoCliente, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                        sql += yield itemTbFaturamentoBluesoftFvNf.scriptSqlInsert();
                                    }
                                }
                                /*Tabela unica de Processamento de Venda Bluesoft tbfaturamento_bluesoft */
                                let FaturamentoBlueSoft = new tbfaturamento_bluesoft_1.default();
                                yield FaturamentoBlueSoft.bindingApiForcaVenda(pedidoCliente, pedidoForcaVenda);
                                sql += yield FaturamentoBlueSoft.ScriptFaturamentoBluesoft_Insert();
                                sql += yield FaturamentoBlueSoft.scriptFaturamentoBlueSoft_Update();
                                if (pedidoForcaVenda.itens) {
                                    try {
                                        for (var _q = true, _r = (e_3 = void 0, __asyncValues(pedidoForcaVenda.itens)), _s; _s = yield _r.next(), _g = _s.done, !_g; _q = true) {
                                            _j = _s.value;
                                            _q = false;
                                            const itemPedido = _j;
                                            itemPedido.pedidoForcaVendaClienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.pedidoForcaVendaClienteKey;
                                            itemPedido.clienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.clienteKey;
                                            let itemTbFaturamentoBluesoftFvItem = new tbfaturamento_bluesoft_fv_item_1.default();
                                            yield itemTbFaturamentoBluesoftFvItem.bindingFromApiForcaVenda(itemPedido, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                            sql += yield itemTbFaturamentoBluesoftFvItem.scriptSqlInsert();
                                        }
                                    }
                                    catch (e_3_1) { e_3 = { error: e_3_1 }; }
                                    finally {
                                        try {
                                            if (!_q && !_g && (_h = _r.return)) yield _h.call(_r);
                                        }
                                        finally { if (e_3) throw e_3.error; }
                                    }
                                }
                            }
                        }
                        catch (e_2_1) { e_2 = { error: e_2_1 }; }
                        finally {
                            try {
                                if (!_m && !_d && (_e = _o.return)) yield _e.call(_o);
                            }
                            finally { if (e_2) throw e_2.error; }
                        }
                        //Adicionar um sequencial ao processamento (por pedido_fv)
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
                        if (!_l && !_a && (_b = ListPedidos_1.return)) yield _b.call(ListPedidos_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql) {
                    console.log("Executando batch insert/update final...");
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "fromApi", e);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoftImportFromApi;
