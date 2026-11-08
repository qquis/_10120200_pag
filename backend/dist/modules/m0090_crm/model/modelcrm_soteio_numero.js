"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbcrm_sorteio_numero_1 = __importDefault(require("../tbs/tbcrm_sorteio_numero"));
class modelcrm_sorteio_numero extends tbcrm_sorteio_numero_1.default {
    constructor() {
        super();
        this.numero_cupom = 0;
        this.numero_pedido = 0;
        this.nf_data_emissao = this.__dataZERO;
        this.nf_numero = 0;
        this.nf_chave = '';
        this.valor = 0;
        this.cpf_cnpj = '';
        this.crm_so_cpf = '';
    }
    model_biding(item) {
        {
            super.binding(item);
            this.numero_cupom = item === null || item === void 0 ? void 0 : item.numero_cupom;
            this.numero_pedido = item === null || item === void 0 ? void 0 : item.numero_pedido;
            this.nf_data_emissao = item === null || item === void 0 ? void 0 : item.nf_data_emissao;
            this.nf_numero = item === null || item === void 0 ? void 0 : item.nf_numero;
            this.nf_chave = item === null || item === void 0 ? void 0 : item.nf_chave;
            this.valor = item === null || item === void 0 ? void 0 : item.valor;
            this.cpf_cnpj = item === null || item === void 0 ? void 0 : item.cpf_cnpj;
            this.crm_so_cpf = item === null || item === void 0 ? void 0 : item.crm_so_cpf;
        }
    }
}
exports.default = modelcrm_sorteio_numero;
