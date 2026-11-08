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
const tbprecoagendamento_1 = __importDefault(require("../tbs/tbprecoagendamento"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class modelprecoagendado extends tbprecoagendamento_1.default {
    constructor() {
        super();
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
                this.prca_dt_aplicacao = Tools_1.default.pagDateTime_getDate(item.prca_dt_aplicacao ? item.prca_dt_aplicacao : this.__defaultDateNow);
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`modelprecoaplicacao | ERROR \n ${e}`, true);
            }
        });
    }
    BlueSoftIntegrar() {
        return __awaiter(this, void 0, void 0, function* () {
            let dadosApi = {
                "produtoKey": this.prb_cdprodutobluesoft,
                "dataInicialOferta": `${Tools_1.default._dataformatgetstr(this.prca_dt_aplicacao.toString())} 08:00:00`,
                "dataFinalOferta": `${Tools_1.default._dataformatgetstr(this.prca_dt_aplicacao.toString())} 23:00:00`,
                "lojasKeys": [
                    1
                ],
                "aplicarAosEquivalentes": true,
                "precoOferta": this.prc_valor
            };
            const ItemProcessamento = {
                prb_cdprodutobluesoft: this.prb_cdprodutobluesoft,
                dados: dadosApi
            };
            console.log(dadosApi);
            //let ResultadoBlue = {}
            //ResultadoBlue = await bluesoft_api.api_post("vendas/precos/ofertas", ItemProcessamento)
        });
    }
}
exports.default = modelprecoagendado;
