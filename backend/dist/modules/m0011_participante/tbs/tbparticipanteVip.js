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
class tbparticipanteVip extends modelbase_1.clsBase {
    constructor() {
        super();
        this.vip_id = 0;
        this.vip_cliente_id = '';
        this.vip_cpf_cnpj = '';
        this.vip_cpf = '';
        this.vip_cnpj = '';
        this.vip_data_nascimento = modelbase_1.clsTools._datemomentDateToStr(this.__defaultDateNow, "YYYY-MM-DD");
        this.vip_email = '';
        this.vip_nome = '';
        this.vip_sobre_nome = '';
        this.vip_telefone_celular = '';
        this.vip_nome_completo = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            /*
                Le as informações do banco de dados
            */
            if (item) {
                this.vip_id = item === null || item === void 0 ? void 0 : item.vip_id;
                this.vip_cliente_id = item === null || item === void 0 ? void 0 : item.vip_cliente_id;
                this.vip_cpf_cnpj = item === null || item === void 0 ? void 0 : item.vip_cpf_cnpj;
                this.vip_cnpj = item === null || item === void 0 ? void 0 : item.vip_cnpj;
                this.vip_cpf = item === null || item === void 0 ? void 0 : item.vip_cpf;
                this.vip_data_nascimento = item === null || item === void 0 ? void 0 : item.vip_data_nascimento;
                this.vip_email = item === null || item === void 0 ? void 0 : item.vip_email;
                this.vip_nome = item === null || item === void 0 ? void 0 : item.vip_nome;
                this.vip_sobre_nome = item === null || item === void 0 ? void 0 : item.sobre_nome;
                this.vip_telefone_celular = item === null || item === void 0 ? void 0 : item.vip_telefone_celular;
                this.vip_nome_completo = item === null || item === void 0 ? void 0 : item.vip_nome_completo;
            }
        });
    }
}
exports.default = tbparticipanteVip;
