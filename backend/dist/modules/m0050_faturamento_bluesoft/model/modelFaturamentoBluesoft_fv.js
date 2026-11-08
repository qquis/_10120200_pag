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
const tbfaturamento_bluesoft_fv_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv"));
const tbfaturamento_bluesoft_fv_cliente_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_cliente"));
class modelFaturamentoBluesoft_Fv extends tbfaturamento_bluesoft_fv_1.default {
    constructor() {
        super();
        this.list_pedido_cliente = [];
        this.list_pedido_nf = [];
    }
    bindingRedhisft_FaturamentoBluesoft_fv(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    Object.assign(this, item);
                }
            }
            catch (e) {
            }
        });
    }
    bindingApiForcaVenda(dadosPedidoForca) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                if (dadosPedidoForca) {
                    this.numeropedido_fv = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.pedidoForcaVendaKey;
                    this.cdpessoabluesoft_vendedor = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.vendedorExternoKey;
                    this.tabelapreco_cd = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.tabelaPrecoVendaKey;
                    this.tabelapreco_versao_cd = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.tabelaPrecoVersao;
                    this.data_emissao = modelbase_1.clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm");
                    this.cdgrupoeconomico = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.grupoEconomicoKey;
                    let listPedidoCliente = [];
                    if ((dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.clientes) && Array.isArray(dadosPedidoForca.clientes)) {
                        try {
                            for (var _d = true, _e = __asyncValues(dadosPedidoForca.clientes), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                                _c = _f.value;
                                _d = false;
                                const cliente = _c;
                                let itemCliente = new tbfaturamento_bluesoft_fv_cliente_1.default();
                                itemCliente.cdpessoabluesoft_cliente = cliente === null || cliente === void 0 ? void 0 : cliente.clienteKey;
                                itemCliente.numeropedido_fv = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.pedidoForcaVendaKey;
                                itemCliente.numeropedido = cliente === null || cliente === void 0 ? void 0 : cliente.pedidoForcaVendaClienteKey;
                                itemCliente.pedido_status_cd = cliente === null || cliente === void 0 ? void 0 : cliente.pedidoVendaStatusKey;
                                listPedidoCliente.push(itemCliente);
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                    }
                    this.list_pedido_cliente = listPedidoCliente;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft_Fv", "bindingApiForcaVenda", e);
            }
        });
    }
    scriptSqlInsert() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let sql = ``;
            try {
                sql = `INSERT INTO tbfaturamento_bluesoft_fv (
                    numeropedido_fv			
				,	cdpessoabluesoft_vendedor	
				,	tabelapreco_cd				
				,	tabelapreco_versao_cd		
				,	data_emissao		
                ,   cdgrupoeconomico		
                ,   fv_prazopgto_cd
            
                ) SELECT 
                    ${this.numeropedido_fv}
                ,   ${this.cdpessoabluesoft_vendedor}
                ,   ${this.tabelapreco_cd}
                ,   ${this.tabelapreco_versao_cd}
                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD HH:mm:ss")}'
                ,   ${this.cdgrupoeconomico}
                ,   ${this.fv_prazopgto_cd}
                    WHERE NOT EXISTS (SELECT 1 
                                FROM tbfaturamento_bluesoft_fv 
                                WHERE numeropedido_fv = ${this.numeropedido_fv}


                ); 
                
                UPDATE tbfaturamento_bluesoft_fv SET
                    cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}
                ,   tabelapreco_cd = ${this.tabelapreco_cd}
                ,   tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}
                ,   cdgrupoeconomico = ${this.cdgrupoeconomico}
                ,   fv_prazopgto_cd = case when ${this.fv_prazopgto_cd} > 0 then fv_prazopgto_cd else ${this.fv_prazopgto_cd} end
                ,   dtlog_update  = current_timestamp
                WHERE numeropedido_fv = ${this.numeropedido_fv};
                
                `;
                try {
                    for (var _d = true, _e = __asyncValues(this.list_pedido_cliente), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const cliente = _c;
                        sql += ` 
                            INSERT INTO tbfaturamento_bluesoft_fv_cliente (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   pedido_status_cd
                        ) SELECT 
                                ${cliente.numeropedido_fv}
                            ,   ${cliente.numeropedido}
                            ,   ${cliente.cdpessoabluesoft_cliente}
                            ,   ${cliente.pedido_status_cd}
                        WHERE NOT EXISTS 
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_cliente 
                                WHERE   numeropedido_fv = ${cliente.numeropedido_fv}
                                AND     numeropedido = ${cliente.numeropedido}
                            )
                            ;

                            `;
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelforca_venda_prazopgto", "scriptSqlInsert", e);
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = modelFaturamentoBluesoft_Fv;
