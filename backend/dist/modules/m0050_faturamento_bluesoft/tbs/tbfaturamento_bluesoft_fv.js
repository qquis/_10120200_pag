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
class tbforca_venda_pedido extends modelbase_1.clsBase {
    constructor() {
        super();
        this.numeropedido_fv = 0;
        this.cdpessoabluesoft_vendedor = 0;
        this.data_emissao = new Date();
        this.tabelapreco_cd = 0;
        this.tabelapreco_versao_cd = 0;
        this.cdgrupoeconomico = 0;
        this.fv_prazopgto_cd = 0;
        this.pedido_tipo_cd = 0;
        this.descontoFinanceiro = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.cdpessoabluesoft_vendedor = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_vendedor;
                this.data_emissao = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.data_emissao, "YYYY-MM-DD HH:mm");
                this.tabelapreco_cd = item === null || item === void 0 ? void 0 : item.tabelapreco_cd;
                this.tabelapreco_versao_cd = item === null || item === void 0 ? void 0 : item.tabelapreco_versao_cd;
                this.cdgrupoeconomico = item === null || item === void 0 ? void 0 : item.cdgrupoeconomico;
                this.fv_prazopgto_cd = item === null || item === void 0 ? void 0 : item.fv_prazopgto_cd;
                this.pedido_tipo_cd = item === null || item === void 0 ? void 0 : item.pedido_tipo_cd;
                this.descontoFinanceiro = item === null || item === void 0 ? void 0 : item.descontoFinanceiro;
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
    bindingFromApiForcaVenda(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.pedidoForcaVendaKey;
                this.cdpessoabluesoft_vendedor = item === null || item === void 0 ? void 0 : item.vendedorExternoKey;
                this.tabelapreco_cd = item === null || item === void 0 ? void 0 : item.tabelaPrecoVendaKey;
                this.tabelapreco_versao_cd = item === null || item === void 0 ? void 0 : item.tabelaPrecoVersao;
                this.data_emissao = modelbase_1.clsTools._datemomentDatStrToDate(item.dataEmissao, "DD/MM/YYYY HH:mm");
                this.cdgrupoeconomico = item === null || item === void 0 ? void 0 : item.grupoEconomicoKey;
                this.fv_prazopgto_cd = item === null || item === void 0 ? void 0 : item.prazoPagamentoFvKey;
                this.pedido_tipo_cd = item === null || item === void 0 ? void 0 : item.tipoPedidoVendaKey;
                this.descontoFinanceiro = item === null || item === void 0 ? void 0 : item.descontoFinanceiro;
            }
        });
    }
    scriptSqlInsert() {
        return __awaiter(this, void 0, void 0, function* () {
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
                    ,   pedido_tipo_cd
                    ,   descontoFinanceiro
                
                    ) SELECT 
                        ${this.numeropedido_fv}
                    ,   ${this.cdpessoabluesoft_vendedor}
                    ,   ${this.tabelapreco_cd}
                    ,   ${this.tabelapreco_versao_cd}
                    ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD HH:mm:ss")}'
                    ,   ${this.cdgrupoeconomico}
                    ,   ${this.fv_prazopgto_cd}
                    ,   ${this.pedido_tipo_cd}
                    ,   ${this.descontoFinanceiro}
                        WHERE NOT EXISTS (SELECT 1 
                                    FROM tbfaturamento_bluesoft_fv 
                                    WHERE numeropedido_fv = ${this.numeropedido_fv}


                    ); 
                    
                    UPDATE tbfaturamento_bluesoft_fv SET
                        cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}
                    ,   tabelapreco_cd = ${this.tabelapreco_cd}
                    ,   tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}
                    ,   cdgrupoeconomico = ${this.cdgrupoeconomico}
                    ,   fv_prazopgto_cd = case when ${this.fv_prazopgto_cd} > 0 then ${this.fv_prazopgto_cd} else fv_prazopgto_cd end
                    ,   pedido_tipo_cd = ${this.pedido_tipo_cd}
                    ,   descontoFinanceiro = ${this.descontoFinanceiro}
                    ,   dtlog_update  = current_timestamp
                    WHERE numeropedido_fv = ${this.numeropedido_fv};
                    
                    `;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft_fv", "scriptSqlInsert", e);
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = tbforca_venda_pedido;
