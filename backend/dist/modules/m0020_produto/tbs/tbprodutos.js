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
class tbproduto extends modelbase_1.clsBase {
    constructor() {
        super();
        this.cdparticipante_fabricante = 0;
        this.cdpessoabluesoft_fabricante = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update_api = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.prb_cdprodutobluesoft = 0;
        this.prb_cdproduto_compra_padrao = 0;
        this.prbf_seq = 0;
        this.pr_cdbarra_principal = '';
        this.pr_cdproduto = 0;
        this.pr_descricao = '';
        this.pr_embalagemcompra = '';
        this.pr_embalagemcompra_fator = 0;
        this.pr_embalagemestoque = '';
        this.pr_seq = 0;
        this.prsg_cdsubgrupo = 0;
        this.pr_status_comercial_preco_inativo = 0;
        this.pr_status = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cdparticipante_fabricante = item === null || item === void 0 ? void 0 : item.cdparticipante_fabricante;
                this.cdpessoabluesoft_fabricante = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_fabricante;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update_api = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update_api, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
                this.prb_cdproduto_compra_padrao = item === null || item === void 0 ? void 0 : item.prb_cdproduto_compra_padrao;
                this.prbf_seq = item === null || item === void 0 ? void 0 : item.prbf_seq;
                this.pr_cdbarra_principal = item === null || item === void 0 ? void 0 : item.pr_cdbarra_principal;
                this.pr_cdproduto = item === null || item === void 0 ? void 0 : item.pr_cdproduto;
                this.pr_descricao = item === null || item === void 0 ? void 0 : item.pr_descricao;
                this.pr_embalagemcompra_fator = item === null || item === void 0 ? void 0 : item.pr_embalagemcompra_fator;
                this.pr_embalagemcompra = item === null || item === void 0 ? void 0 : item.pr_embalagemcompra;
                this.pr_embalagemestoque = item === null || item === void 0 ? void 0 : item.pr_embalagemestoque;
                this.pr_seq = item === null || item === void 0 ? void 0 : item.pr_seq;
                this.prsg_cdsubgrupo = item === null || item === void 0 ? void 0 : item.prsg_cdsubgrupo;
                this.pr_status_comercial_preco_inativo = item === null || item === void 0 ? void 0 : item.pr_status_comercial_preco_inativo;
                this.pr_status = item === null || item === void 0 ? void 0 : item.pr_status;
            }
        });
    }
}
exports.default = tbproduto;
