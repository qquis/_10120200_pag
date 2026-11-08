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
class tbfaturamento_bluesoft_fv_nf extends modelbase_1.clsBase {
    constructor() {
        super();
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.cdpessoabluesoft_cliente = 0;
        this.df_nf_seq_blue = 0;
        this.df_nf_numero = 0;
        this.df_nf_tipo = 0;
        this.df_valor = 0;
        this.df_data_emissao = new Date();
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_cliente;
                this.df_nf_seq_blue = item === null || item === void 0 ? void 0 : item.df_nf_seq_blue;
                this.df_nf_numero = item === null || item === void 0 ? void 0 : item.df_nf_numero;
                this.df_nf_tipo = item === null || item === void 0 ? void 0 : item.df_nf_tipo;
                this.df_valor = item === null || item === void 0 ? void 0 : item.df_valor;
            }
        });
    }
    bindingFromApiForcaVenda(item_1) {
        return __awaiter(this, arguments, void 0, function* (item, numeropedido_fv = 0) {
            var _a;
            if (item) {
                this.numeropedido_fv = (item === null || item === void 0 ? void 0 : item.pedidoForcaVendaKey) || numeropedido_fv;
                this.numeropedido = item === null || item === void 0 ? void 0 : item.pedidoForcaVendaClienteKey;
                this.df_nf_numero = item === null || item === void 0 ? void 0 : item.nfNumero;
                this.df_nf_seq_blue = item === null || item === void 0 ? void 0 : item.nfKey;
                if (item === null || item === void 0 ? void 0 : item.nfTipo) {
                    this.df_nf_tipo = (_a = item === null || item === void 0 ? void 0 : item.nfTipo) === null || _a === void 0 ? void 0 : _a.notaFiscalTipoKey;
                }
                this.df_valor = item === null || item === void 0 ? void 0 : item.valorNf;
                this.df_data_emissao = modelbase_1.clsTools._datemomentDatStrToDate(item.nfDataEmissao, "DD/MM/YYYY");
            }
        });
    }
    scriptSqlInsert() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `
            
                insert into tbfaturamento_bluesoft_fv_nf
                    (
                            numeropedido 				
                        ,	numeropedido_fv 			
                        ,	cdpessoabluesoft_cliente	
                        ,	df_nf_seq_blue				
                        ,	df_nf_numero				
                        ,	df_nf_tipo					
                        ,	df_valor		
                        ,   df_data_emissao			
                        )
                    select ${this.numeropedido}
                        ,   ${this.numeropedido_fv}
                        ,   ${this.cdpessoabluesoft_cliente}
                        ,   ${this.df_nf_seq_blue}
                        ,   ${this.df_nf_numero}
                        ,   ${this.df_nf_tipo}
                        ,   ${this.df_valor}
                        ,   '${modelbase_1.clsTools._datemomentDateToStr(this.df_data_emissao, "YYYY-MM-DD")}'  
                    where not exists (
                        select 1 from tbfaturamento_bluesoft_fv_nf
                            where numeropedido = ${this.numeropedido}
                                and numeropedido_fv = ${this.numeropedido_fv}
                                and cdpessoabluesoft_cliente = ${this.cdpessoabluesoft_cliente}
                                and df_nf_seq_blue = ${this.df_nf_seq_blue}
                    );
            `;
            try {
            }
            catch (e) {
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = tbfaturamento_bluesoft_fv_nf;
