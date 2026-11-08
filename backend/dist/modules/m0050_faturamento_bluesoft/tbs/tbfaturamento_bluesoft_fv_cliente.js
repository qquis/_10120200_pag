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
class tbfaturamento_bluesoft_fv_cliente extends modelbase_1.clsBase {
    constructor() {
        super();
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.cdpessoabluesoft_cliente = 0;
        this.pedido_status_cd = 0;
        this.pedido_status_descricao_redshift = "";
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_cliente;
                this.pedido_status_cd = item === null || item === void 0 ? void 0 : item.pedido_status_cd;
                this.pedido_status_descricao_redshift = item === null || item === void 0 ? void 0 : item.pedido_status_descricao_redshift;
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
                this.pedido_status_cd = item === null || item === void 0 ? void 0 : item.pedidoVendaStatusKey;
            }
        });
    }
    scriptSqlInsert() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = ` 
                            INSERT INTO tbfaturamento_bluesoft_fv_cliente (
                                numeropedido_fv
                            ,   numeropedido
                            ,   cdpessoabluesoft_cliente
                            ,   pedido_status_cd
                        ) SELECT 
                                ${this.numeropedido_fv}
                            ,   ${this.numeropedido}
                            ,   ${this.cdpessoabluesoft_cliente}
                            ,   ${this.pedido_status_cd}
                        WHERE NOT EXISTS 
                            (   SELECT 1 
                                FROM    tbfaturamento_bluesoft_fv_cliente 
                                WHERE   numeropedido_fv = ${this.numeropedido_fv}
                                AND     numeropedido = ${this.numeropedido}
                            )
                            ;

                        update tbfaturamento_bluesoft_fv_cliente set
                            pedido_status_cd = ${this.pedido_status_cd}
                        where numeropedido_fv = ${this.numeropedido_fv}
                        and numeropedido = ${this.numeropedido}
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
exports.default = tbfaturamento_bluesoft_fv_cliente;
