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
class tbparticipante extends modelbase_1.clsBase {
    constructor() {
        super();
        this.cpf_cnpj = '';
        this.bluesoftcliente = 0;
        this.bluesoftfabricante = 0;
        this.bluesoftfornecedor = 0;
        this.bluesoftmotorista = 0;
        this.bluesoftvendedor = 0;
        this.cdgrupoeconomico = 0;
        this.cdparticipante = 0;
        this.cdpessoa = 0;
        this.cdpessoabluesoft = 0;
        this.cdpessoabluesoft_vendedor = 0;
        this.celular_dd = 0;
        this.celular_numero = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.email_main = '';
        this.erptargetcd_clien = 0;
        this.erptargetcd_vend = '';
        this.johnson_cliente_top = 0;
        this.nome_abreviado = '';
        this.nome_razao = '';
        this.participante_status = 0;
        this.pessoajuridica = 0;
        this.tipo_clienteloja = 0;
        this.inscricaoestadual = '';
    }
    bindingFromRedShift(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.bluesoftcliente = item === null || item === void 0 ? void 0 : item.bluesoftcliente;
                this.bluesoftfabricante = item === null || item === void 0 ? void 0 : item.bluesoftfabricante;
                this.bluesoftfornecedor = item === null || item === void 0 ? void 0 : item.bluesoftfornecedor;
                this.bluesoftmotorista = item === null || item === void 0 ? void 0 : item.bluesoftmotorista;
                this.bluesoftvendedor = item === null || item === void 0 ? void 0 : item.bluesoftvendedor;
                this.cdgrupoeconomico = item === null || item === void 0 ? void 0 : item.cdgrupoeconomico;
                this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                this.cdpessoabluesoft = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft;
                this.cdpessoabluesoft_vendedor = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_vendedor;
                this.cdpessoa = item === null || item === void 0 ? void 0 : item.cdpessoa;
                this.celular_dd = item === null || item === void 0 ? void 0 : item.celular_dd;
                this.celular_numero = item === null || item === void 0 ? void 0 : item.celular_numero;
                this.cpf_cnpj = item === null || item === void 0 ? void 0 : item.cpf_cnpj;
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_insert, `YYYY-MM-DD HH:mm:ss`);
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dtlog_update, `YYYY-MM-DD HH:mm:ss`);
                this.email_main = item === null || item === void 0 ? void 0 : item.email_main;
                this.erptargetcd_clien = item === null || item === void 0 ? void 0 : item.erptargetcd_clien;
                this.erptargetcd_vend = item === null || item === void 0 ? void 0 : item.erptargetcd_vend;
                this.johnson_cliente_top = item === null || item === void 0 ? void 0 : item.johnson_cliente_top;
                this.nome_abreviado = (item === null || item === void 0 ? void 0 : item.nome_abreviado) ? item === null || item === void 0 ? void 0 : item.nome_abreviado.replace("'", "") : '';
                this.nome_razao = (item === null || item === void 0 ? void 0 : item.nome_razao) ? item === null || item === void 0 ? void 0 : item.nome_razao.replace("'", "") : '';
                this.participante_status = item === null || item === void 0 ? void 0 : item.participante_status;
                this.pessoajuridica = item === null || item === void 0 ? void 0 : item.pessoajuridica;
                this.tipo_clienteloja = item === null || item === void 0 ? void 0 : item.tipo_clienteloja;
                this.inscricaoestadual = (item === null || item === void 0 ? void 0 : item.inscricaoestadual) ? item === null || item === void 0 ? void 0 : item.inscricaoestadual.replace("'", "") : '';
            }
        });
    }
    bindingFromBlueSoftAPI(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cdpessoabluesoft = item === null || item === void 0 ? void 0 : item.clienteKey;
                this.nome_razao = (item === null || item === void 0 ? void 0 : item.nomeRazao) ? item === null || item === void 0 ? void 0 : item.nomeRazao.replace("'", "") : '';
                this.nome_abreviado = (item === null || item === void 0 ? void 0 : item.nomeAbreviado) ? item === null || item === void 0 ? void 0 : item.nomeAbreviado.replace("'", "") : '';
                this.cpf_cnpj = item === null || item === void 0 ? void 0 : item.cpfCnpj.padStart(14, '0');
                this.pessoajuridica = (item === null || item === void 0 ? void 0 : item.tipo) == 'JURIDICA' ? 1 : 0;
                this.inscricaoestadual = (item === null || item === void 0 ? void 0 : item.inscricaoEstadual) ? item === null || item === void 0 ? void 0 : item.inscricaoEstadual.replace("'", "").replace("'", "") : '';
            }
        });
    }
}
exports.default = tbparticipante;
