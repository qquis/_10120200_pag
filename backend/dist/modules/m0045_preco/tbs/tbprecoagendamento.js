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
const model_1 = require("../../../model/model");
class tbpreco_agendamento extends model_1.modelTb {
    constructor() {
        super();
        this.prca_seq = 0;
        this.prca_dt_aplicacao = this.__defaultDateNow;
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.tab_pre_cd = 0;
        this.prc_valor = 0;
        this.prc_qtde_promocional = 0;
        this.prc_valor_promocional = 0;
        this.prc_valor_embalagemestoque = 0;
        this.prc_aplicacao_definitiva = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item != undefined) {
                this.prca_seq = item.prca_seq ? item.prca_seq : 0;
                this.prca_dt_aplicacao = item.prca_dt_aplicacao ? this.__defaultDateNow : item.prca_dt_aplicacao;
                this.pr_cdproduto = item.pr_cdproduto ? item.pr_cdproduto : 0;
                this.prb_cdprodutobluesoft = item.prb_cdprodutobluesoft ? item.prb_cdprodutobluesoft : 0;
                this.tab_pre_cd = item.tab_pre_cd ? item.tab_pre_cd : 0;
                this.prc_valor = item.prc_valor ? item.prc_valor : 0;
                this.prc_qtde_promocional = item.prc_qtde_promocional ? item.prc_qtde_promocional : 0;
                this.prc_valor_promocional = item.prc_valor_promocional ? item.prc_valor_promocional : 0;
                this.prc_valor_embalagemestoque = item.prc_valor_embalagemestoque ? item.prc_valor_embalagemestoque : 0;
                this.prc_aplicacao_definitiva = item.prc_aplicacao_definitiva ? item.prc_aplicacao_definitiva : 0;
            }
        });
    }
}
exports.default = tbpreco_agendamento;
