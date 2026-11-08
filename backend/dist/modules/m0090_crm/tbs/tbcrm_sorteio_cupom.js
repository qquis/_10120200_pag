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
class tbcrm_sorteio_cupom extends modelbase_1.clsBase {
    constructor() {
        super();
        this.cdparticipante = 0;
        this.cpf_cnpj = '';
        this.crm_so_cpf = '';
        this.crm_so_cupom_seq = 0;
        this.crm_so_temp_cd = 0;
        this.data_emissao = this.__dataZERO;
        this.data_emissao_hora = this.__dataZERO;
        this.numero_cupom = 0;
        this.numero_pedido = 0;
        this.nf_numero = 0;
        this.nf_chave = '';
        this.nf_data_emissao = this.__dataZERO;
        this.sat_ecf = 0;
        this.valor = 0;
        this.crm_so_qtde_numero_sorteio = 0;
        this.crm_so_registrado = 0;
        this.crm_so_log_registro = this.__dataZERO;
        this.crm_so_externo_enviado = 0;
        this.crm_so_externo_enviado_data = this.__dataZERO;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                this.cpf_cnpj = item === null || item === void 0 ? void 0 : item.cpf_cnpj;
                this.crm_so_cpf = item === null || item === void 0 ? void 0 : item.crm_so_cpf;
                this.crm_so_cupom_seq = item === null || item === void 0 ? void 0 : item.crm_so_cupom_seq;
                this.crm_so_temp_cd = item === null || item === void 0 ? void 0 : item.crm_so_temp_cd;
                this.data_emissao = item === null || item === void 0 ? void 0 : item.data_emissao;
                this.data_emissao_hora = item === null || item === void 0 ? void 0 : item.data_emissao_hora;
                this.numero_cupom = item === null || item === void 0 ? void 0 : item.numero_cupom;
                this.nf_numero = item === null || item === void 0 ? void 0 : item.nf_numero;
                this.nf_chave = item === null || item === void 0 ? void 0 : item.nf_chave;
                this.nf_data_emissao = item === null || item === void 0 ? void 0 : item.nf_data_emissao;
                this.numero_pedido = item === null || item === void 0 ? void 0 : item.numero_pedido;
                this.sat_ecf = item === null || item === void 0 ? void 0 : item.sat_ecf;
                this.valor = item === null || item === void 0 ? void 0 : item.valor;
                this.crm_so_qtde_numero_sorteio = item === null || item === void 0 ? void 0 : item.crm_so_qtde_numero_sorteio;
                this.crm_so_registrado = item === null || item === void 0 ? void 0 : item.crm_so_registrado;
                this.crm_so_log_registro = item === null || item === void 0 ? void 0 : item.crm_so_log_registro;
                this.crm_so_externo_enviado = item === null || item === void 0 ? void 0 : item.crm_so_externo_enviado;
                this.crm_so_externo_enviado_data = item === null || item === void 0 ? void 0 : item.crm_so_externo_enviado_data;
            }
        });
    }
}
exports.default = tbcrm_sorteio_cupom;
