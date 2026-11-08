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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class tbfaturamento_bluesoft_fv_item extends modelbase_1.clsBase {
    constructor() {
        super();
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.cdpessoabluesoft_cliente = 0;
        this.prb_cdprodutobluesoft = 0;
        this.qtde_pedida = 0;
        this.qtde_bonificada = 0;
        this.qtde_separada = 0;
        this.valor_preco = 0;
        this.valor_preco_final = 0;
        this.valor_total = 0;
        this.valor_total_separado = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_cliente;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
                this.qtde_pedida = item === null || item === void 0 ? void 0 : item.qtde_pedida;
                this.qtde_bonificada = item === null || item === void 0 ? void 0 : item.qtde_bonificada;
                this.qtde_separada = item === null || item === void 0 ? void 0 : item.qtde_separada;
                this.valor_preco = item === null || item === void 0 ? void 0 : item.valor_preco;
                this.valor_preco_final = item === null || item === void 0 ? void 0 : item.valor_preco_final;
                this.valor_total = item === null || item === void 0 ? void 0 : item.valor_total;
                this.valor_total_separado = item === null || item === void 0 ? void 0 : item.valor_total_separado;
            }
        });
    }
    bindingFromRedShift(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                if (item) {
                    Object.assign(this, item);
                }
            }
        });
    }
    bindingFromApiForcaVenda(item_1) {
        return __awaiter(this, arguments, void 0, function* (item, numeropedido_fv = 0) {
            if (item) {
                this.numeropedido_fv = (item === null || item === void 0 ? void 0 : item.pedidoForcaVendaKey) || numeropedido_fv;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.pedidoForcaVendaClienteKey;
                this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.clienteKey;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.pedidoForcaVendaClienteKey;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.produtoKey;
                this.valor_preco = item === null || item === void 0 ? void 0 : item.preco;
                this.valor_preco_final = (item === null || item === void 0 ? void 0 : item.precoFinalEmbalagem) || (item === null || item === void 0 ? void 0 : item.precoFinal) || 0;
                this.valor_total = item === null || item === void 0 ? void 0 : item.valorTotal;
                this.valor_total_separado = (item === null || item === void 0 ? void 0 : item.valorTotalSeparado) || 0;
                this.qtde_pedida = (item === null || item === void 0 ? void 0 : item.quantidadePedida) || (item === null || item === void 0 ? void 0 : item.quantidade) || 0;
                this.qtde_bonificada = item === null || item === void 0 ? void 0 : item.quantidadeBonificada;
                this.qtde_separada = (item === null || item === void 0 ? void 0 : item.quantidadeSeparada) || 0;
                /*
                                    "produtoKey": 228677,
                                    "preco": 4.748,
                                    "quantidadePedida": 12,
                                    "quantidadeBonificada": 0,
                                    "clienteKey": 4953,
                                    "precoFinalEmbalagem": 4.890,
                                    "valorTotal": 58.680000,
                                    "valorTotalSeparado": 0
                
                                    "pedidoForcaVendaItemKey": 2384965,
                                    "quantidade": 12.000,
                                    "quantidadeBonificada": 0.000,
                                    "origemVerba": "FUNCIONARIO",
                                    "descricaoProduto": "SUCO MARATA NECTAR UVA TP 1LT",
                                    "produtoKey": 228677,
                                    "fabricanteKey": 125224,
                                    "estoque": 3369.0000000000000000,
                                    "fatorPreco": 1.0,
                                    "fatorEstoque": 1.0,
                                    "itemFatorEstoque": 1.0,
                                    "clienteKey": 4953,
                                    "preco": 4.748,
                                    "precoVariacao": 0.00,
                                    "precoFinal": 4.89,
                                    "valorTotal": 58.68000
                            
                */
            }
        });
    }
    scriptSqlInsert() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = ` 
                          
                        INSERT INTO tbfaturamento_bluesoft_fv_item (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   prb_cdprodutobluesoft
                            ,   qtde_pedida
                            ,   qtde_bonificada
                            ,   qtde_separada
                            ,   valor_preco
                            ,   valor_preco_final
                            ,   valor_total
                            ,   valor_total_separado
                        ) SELECT
                                ${this.numeropedido_fv}
                            ,   ${this.numeropedido}
                            ,   ${this.cdpessoabluesoft_cliente}
                            ,   ${this.prb_cdprodutobluesoft}
                            ,   ${this.qtde_pedida}
                            ,   ${this.qtde_bonificada}
                            ,   ${this.qtde_separada}
                            ,   ${this.valor_preco}
                            ,   ${this.valor_preco_final}
                            ,   ${this.valor_total}
                            ,   ${this.valor_total_separado}
                        WHERE NOT EXISTS
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_item
                                WHERE   numeropedido_fv = ${this.numeropedido_fv}
                                AND     numeropedido = ${this.numeropedido}
                                AND     prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}

                            );

                            UPDATE tbfaturamento_bluesoft_fv_item SET
                                    qtde_pedida = ${this.qtde_pedida}
                                ,   qtde_bonificada = ${this.qtde_bonificada}
                                ,   qtde_separada = ${this.qtde_separada}
                                ,   valor_preco = ${this.valor_preco}
                                ,   valor_preco_final = ${this.valor_preco_final}
                                ,   valor_total = ${this.valor_total}
                                ,   valor_total_separado = ${this.valor_total_separado}
                            WHERE numeropedido_fv = ${this.numeropedido_fv}
                                AND numeropedido = ${this.numeropedido}
                                AND prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}

                            ;

                        `;
            }
            catch (e) {
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = tbfaturamento_bluesoft_fv_item;
