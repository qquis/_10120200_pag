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
const tbprecoaplicacao_1 = __importDefault(require("../tbs/tbprecoaplicacao"));
const bluesoftApiUrl_1 = __importDefault(require("../../Apis/bluesoftApi/url/bluesoftApiUrl"));
class modelprecoaplicacao extends tbprecoaplicacao_1.default {
    /*
        preco_aplicacao_seq: number
    preco_aplicacao_data: Date
    tab_pre_cd: number
    pr_cdproduto: number
    pr_embalagemestoque: string
    prc_valor_embalagemestoque: number
    pre_fatorestoque: number
    prb_cdprodutobluesoft: number
    pre_embalagem: string
    prc_valor: number
    preco_aplicacao_agendamento: boolean
    prca_seq: number
    prc_qtde_promocional: number
    prc_valor_promocional: number
    prb_cdprodutobluesoft_unitario: number
    */
    constructor(prb_cdprodutobluesoft) {
        super(prb_cdprodutobluesoft);
        this.prsg_cdsubgrupo = 0;
        this.prsg_descricao = ``;
        this.prg_cdgrupo = 0;
        this.prg_descricao = ``;
        this.prs_cdsecao = 0;
        this.prs_descricao = ``;
        this.prd_cddepartamento = 0;
        this.prd_descricao = ``;
        this.cdpessoabluesoft = 0;
        this.nome_razao = ``;
        this.email_main = ``;
        this.celular_dd = 0;
        this.celular_numero = 0;
        this.pr_descricao = ``;
        this.prb_descricao = ``;
        this.pre_embalagem = ``;
    }
    modelBindind(item) {
        const _super = Object.create(null, {
            binding: { get: () => super.binding }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined)
                    _super.binding.call(this, item);
                this.prsg_cdsubgrupo = item.prsg_cdsubgrupo ? parseInt(item.prsg_cdsubgrupo) : 0;
                this.prsg_descricao = item.prsg_descricao ? item.prsg_descricao : ``;
                this.prg_cdgrupo = item.prg_cdgrupo ? parseInt(item.prg_cdgrupo) : 0;
                this.prg_descricao = item.prg_descricao ? item.prg_descricao : ``;
                this.prs_cdsecao = item.prs_cdsecao ? parseInt(item.prs_cdsecao) : 0;
                this.prs_descricao = item.prs_descricao ? item.prs_descricao : ``;
                this.prd_cddepartamento = item.prd_cddepartamento ? parseInt(item.prd_cddepartamento) : 0;
                this.prd_descricao = item.prd_descricao ? item.prd_descricao : ``;
                this.cdpessoabluesoft = item.cdpessoabluesoft ? parseInt(item.cdpessoabluesoft) : 0;
                this.nome_razao = item.nome_razao ? item.nome_razao : ``;
                this.email_main = item.email_main ? item.email_main : `suporte@oxan.com.br`;
                this.celular_dd = item.celular_dd ? item.celular_dd : 11;
                this.celular_numero = item.celular_numero ? item.celular_numero : 27825255;
                this.pr_descricao = item.pr_descricao;
                this.prb_descricao = item.prb_descricao ? item.prb_descricao : ``;
                this.pre_embalagem = item.pre_embalagem ? item.pre_embalagem : `UN`;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`modelprecoaplicacao | ERROR \n ${e}`, true);
            }
        });
    }
    modelBlueSoftAtualizar(request) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (request) {
                    if (request.body !== undefined) {
                        this.prb_cdprodutobluesoft = parseInt(`${request === null || request === void 0 ? void 0 : request.query.prb_cdprodutobluesoft}`);
                        this.prc_valor = Number(`${request === null || request === void 0 ? void 0 : request.query.prc_valor}`);
                    }
                }
                if (this.prb_cdprodutobluesoft !== 0 && this.prc_valor > 0) {
                    const dados = {
                        "aplicarPrecoParaCaixa": true,
                        "dataInicialAVigorar": `${(new Date()).toLocaleString("pt-br").substring(0, 10)} 08:01:01`,
                        "produtoKey": this.prb_cdprodutobluesoft,
                        "regioes": [
                            {
                                "precoAPartirDe": 0,
                                "precoAtacado": 0,
                                "precoFidelidade": 0,
                                "precoVenda": this.prc_valor,
                                "quantidadeAPartirDe": 0,
                                "regiaoKey": 1
                            }
                        ]
                    };
                    const ItemProcessamento = {
                        prb_cdprodutobluesoft: this.prb_cdprodutobluesoft,
                        dados: dados
                    };
                    let ResultadoBlue = {};
                    ResultadoBlue = yield bluesoftApiUrl_1.default.api_post("vendas/precos", ItemProcessamento.dados);
                    yield Tools_1.default.pagConsoleLog(`F0045 _ ModelPrecoAplicacao | modelBlueSoftAtualizar Produto: ${this.prb_cdprodutobluesoft} Preço: ${this.prc_valor}`);
                }
                else {
                    yield Tools_1.default.pagConsoleLog(`F0045 _ ModelPrecoAplicacao | modelBlueSoftAtualizar (ERROR: DADOS INCORRETOS) Produto: ${this.prb_cdprodutobluesoft} Preço: ${this.prc_valor}`);
                }
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`modelprecoaplicacao | modelBlueSoftAtualizar ERROR [Produto ${this.prb_cdprodutobluesoft} Preço ${this.prc_valor}] ${e}`);
            }
        });
    }
}
exports.default = modelprecoaplicacao;
