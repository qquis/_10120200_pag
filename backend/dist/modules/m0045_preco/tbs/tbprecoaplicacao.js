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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbprecoaplicacao extends model_1.modelTb {
    constructor(prb_cdprodutobluesoft) {
        super();
        this.prb_cdprodutobluesoft = prb_cdprodutobluesoft;
        this.preco_aplicacao_seq = 0;
        this.preco_aplicacao_data = this.__defaultDateNow;
        this.tab_pre_cd = 0;
        this.pr_cdproduto = 0;
        this.pr_embalagemestoque = 'UN';
        this.prc_valor_embalagemestoque = 0;
        this.pre_fatorestoque = 1;
        this.pre_embalagem = 'UN';
        this.prc_valor = 0;
        this.preco_aplicacao_agendamento = false;
        this.prca_seq = 0;
        this.prc_qtde_promocional = 0;
        this.prc_valor_promocional = 0;
        this.prb_cdprodutobluesoft_unitario = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item != undefined) {
                this.prb_cdprodutobluesoft = item.prb_cdprodutobluesoft ? item.prb_cdprodutobluesoft : 0;
                this.preco_aplicacao_seq = item.preco_aplicacao_seq ? parseInt(item.preco_aplicacao_seq) : 0;
                this.preco_aplicacao_data = Tools_1.default.pagDateTime_getDate(item.preco_aplicacao_data ? item.preco_aplicacao_data : this.__defaultDateNow);
                this.tab_pre_cd = item.tab_pre_cd ? parseInt(item.tab_pre_cd) : 0;
                this.pr_cdproduto = item.pr_cdproduto ? parseInt(item.pr_cdproduto) : 0;
                this.pr_embalagemestoque = item.pr_embalagemestoque ? item.pr_embalagemestoque : 'UN';
                this.prc_valor_embalagemestoque = item.prc_valor_embalagemestoque ? parseFloat(item.prc_valor_embalagemestoque) : 0;
                this.pre_fatorestoque = item.pre_fatorestoque ? item.pre_fatorestoque : 1;
                this.pre_embalagem = item.pre_embalagem ? item.pre_embalagem : `UN`;
                this.prc_valor = item.prc_valor ? parseFloat(item.prc_valor) : 0;
                this.preco_aplicacao_agendamento = item.preco_aplicacao_agendamento ? item.preco_aplicacao_agendamento : false;
                this.prca_seq = item.prca_seq ? item.prca_seq : 0;
                this.prc_qtde_promocional = item.prc_qtde_promocional ? parseFloat(item.prc_qtde_promocional) : 0;
                this.prc_valor_promocional = item.prc_valor_promocional ? parseFloat(item.prc_valor_promocional) : 0;
                this.prb_cdprodutobluesoft_unitario = item.prb_cdprodutobluesoft_unitario ? item.prb_cdprodutobluesoft_unitario : 0;
            }
        });
    }
}
exports.default = tbprecoaplicacao;
