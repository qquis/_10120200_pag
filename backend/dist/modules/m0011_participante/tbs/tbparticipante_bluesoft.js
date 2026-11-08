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
class tbparticipante_bluesoft extends modelbase_1.clsBase {
    constructor() {
        super();
        this.bluesoftcliente = 0;
        this.bluesoftcliente_creditolimite_valor = 0;
        this.bluesoftcliente_creditolimite_valor_reservado = 0;
        this.bluesoftcliente_creditostatus_cd = 0;
        this.bluesoftcliente_ramoatividade_cd = 0;
        this.bluesoftclientestatus = 0;
        this.bluesoftfabricante = 0;
        this.bluesoftfornecedor = 0;
        this.bluesoftmotorista = 0;
        this.bluesoft_pessoa_data_cadastro = this.__defaultDateNow;
        this.bluesoft_pessoa_status = 0;
        this.bluesoftvendedor = 0;
        this.cdgrupoeconomico = 0;
        this.cdparticipante = 0;
        this.cdpessoabluesoft = 0;
        this.cdpessoabluesoft_vendedor = 0;
        this.cpf_cnpj = '';
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.nome_abreviado = '';
        this.nome_razao = '';
        this.pessoajuridica = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.bluesoftcliente_creditolimite_valor = item === null || item === void 0 ? void 0 : item.bluesoftcliente_creditolimite_valor;
                this.bluesoftcliente_creditolimite_valor_reservado = item === null || item === void 0 ? void 0 : item.bluesoftcliente_creditolimite_valor_reservado;
                this.bluesoftcliente_creditostatus_cd = item === null || item === void 0 ? void 0 : item.bluesoftcliente_creditostatus_cd;
                this.bluesoftcliente = item === null || item === void 0 ? void 0 : item.bluesoftcliente;
                this.bluesoftcliente_ramoatividade_cd = item === null || item === void 0 ? void 0 : item.bluesoftcliente_ramoatividade_cd;
                this.bluesoftclientestatus = item === null || item === void 0 ? void 0 : item.bluesoftclientestatus;
                this.bluesoftfabricante = item === null || item === void 0 ? void 0 : item.bluesoftfabricante;
                this.bluesoftfornecedor = item === null || item === void 0 ? void 0 : item.bluesoftfornecedor;
                this.bluesoftmotorista = item === null || item === void 0 ? void 0 : item.bluesoftmotorista;
                this.bluesoft_pessoa_data_cadastro = item === null || item === void 0 ? void 0 : item.bluesoft_pessoa_data_cadastro;
                this.bluesoft_pessoa_status = item === null || item === void 0 ? void 0 : item.bluesoft_pessoa_status;
                this.bluesoftvendedor = item === null || item === void 0 ? void 0 : item.bluesoftvendedor;
                this.cdgrupoeconomico = item === null || item === void 0 ? void 0 : item.cdgrupoeconomico;
                this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                this.cdpessoabluesoft = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft;
                this.cdpessoabluesoft_vendedor = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_vendedor;
                this.cpf_cnpj = item === null || item === void 0 ? void 0 : item.cpf_cnpj;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.nome_abreviado = item === null || item === void 0 ? void 0 : item.nome_abreviado;
                this.nome_razao = item === null || item === void 0 ? void 0 : item.nome_razao;
                this.pessoajuridica = item === null || item === void 0 ? void 0 : item.pessoajuridica;
            }
        });
    }
}
exports.default = tbparticipante_bluesoft;
