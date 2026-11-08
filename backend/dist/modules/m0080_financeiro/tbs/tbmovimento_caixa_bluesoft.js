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
class tbmovimento_caixa_bluesoft extends modelbase_1.clsBase {
    constructor() {
        super();
        this.administradora_cdpessoabluesoft = 0;
        this.caixa_bluesoft_cd = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.em_cdempresa = 0;
        this.mv_caixa_autorizacao_cd = 0;
        this.mv_caixa_bluesoft_tipo_cd = 0;
        this.mv_caixa_cpf = '';
        this.mv_caixa_data_deposito = this.__defaultDateNow;
        this.mv_caixa_data_entrega = this.__defaultDateNow;
        this.mv_caixa_data_previsao_credito = this.__defaultDateNow;
        this.mv_caixa_data = this.__defaultDateNow;
        this.mv_caixa_descricao = '';
        this.mv_caixa_nsu = '';
        this.mv_caixa_seq = 0;
        this.mv_caixa_updated_at = this.__defaultDateNow;
        this.mv_caixa_valor = 0;
        this.mv_caixa_vl_juros = 0;
        this.mv_caixa_vl_parcela = 0;
        this.mv_caixa_vl_taxa = 0;
        this.mv_caixa_vl_taxa_operacao = 0;
        this.sat_ecf = 0;
        this.debitocredito = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.administradora_cdpessoabluesoft = item === null || item === void 0 ? void 0 : item.administradora_cdpessoabluesoft;
                this.caixa_bluesoft_cd = item === null || item === void 0 ? void 0 : item.caixa_bluesoft_cd;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.em_cdempresa = item === null || item === void 0 ? void 0 : item.em_cdempresa;
                this.mv_caixa_autorizacao_cd = item === null || item === void 0 ? void 0 : item.mv_caixa_autorizacao_cd;
                this.mv_caixa_bluesoft_tipo_cd = item === null || item === void 0 ? void 0 : item.mv_caixa_bluesoft_tipo_cd;
                this.mv_caixa_cpf = item === null || item === void 0 ? void 0 : item.mv_caixa_cpf;
                this.mv_caixa_data_deposito = item === null || item === void 0 ? void 0 : item.mv_caixa_data_deposito;
                this.mv_caixa_data_entrega = item === null || item === void 0 ? void 0 : item.mv_caixa_data_entrega;
                this.mv_caixa_data = item === null || item === void 0 ? void 0 : item.mv_caixa_data;
                this.mv_caixa_data_previsao_credito = item === null || item === void 0 ? void 0 : item.mv_caixa_data_previsao_credito;
                this.mv_caixa_descricao = item === null || item === void 0 ? void 0 : item.mv_caixa_descricao;
                this.mv_caixa_nsu = item === null || item === void 0 ? void 0 : item.mv_caixa_nsu;
                this.mv_caixa_seq = item === null || item === void 0 ? void 0 : item.mv_caixa_seq;
                this.mv_caixa_updated_at = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.mv_caixa_updated_at, `YYYY-MM-DD HH:mm:ss`);
                this.mv_caixa_valor = item === null || item === void 0 ? void 0 : item.mv_caixa_valor;
                this.mv_caixa_vl_juros = item === null || item === void 0 ? void 0 : item.mv_caixa_vl_juros;
                this.mv_caixa_vl_parcela = item === null || item === void 0 ? void 0 : item.mv_caixa_vl_parcela;
                this.mv_caixa_vl_taxa = item === null || item === void 0 ? void 0 : item.mv_caixa_vl_taxa;
                this.mv_caixa_vl_taxa_operacao = item === null || item === void 0 ? void 0 : item.mv_caixa_vl_taxa_operacao;
                this.sat_ecf = item === null || item === void 0 ? void 0 : item.sat_ecf;
                this.debitocredito = item === null || item === void 0 ? void 0 : item.debitocredito;
            }
        });
    }
}
exports.default = tbmovimento_caixa_bluesoft;
