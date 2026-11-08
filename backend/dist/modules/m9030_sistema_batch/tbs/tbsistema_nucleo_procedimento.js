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
//import {Request, Response, Router} from 'express'
class tbsistema_nucleo_procedimento extends modelbase_1.clsBase {
    constructor() {
        super();
        this.data_default_fim = 0;
        this.data_default_ini = 0;
        this.data_reprocessamento_default_fim = this.__defaultDateNow;
        this.data_reprocessamento_default = this.__defaultDateNow;
        this.dateadd_fim = 0;
        this.dateadd_ini = 0;
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.permite_execucao_manual = 0;
        this.script_app = 0;
        this.script_database = 0;
        this.sis_batch_cd = 0;
        this.sis_nucleo_cd_fk = '';
        this.sis_nucleo_prc_cd = 0;
        this.sis_nucleo_prc_descricao = '';
        this.sis_nucleo_prc_descritivo = '';
        this.sis_nucleo_prc_ref = '';
        this.sis_nucleo_prc_tipo = 0;
        this.versao = 0;
        this.notificacao_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.data_default_fim = item === null || item === void 0 ? void 0 : item.data_default_fim;
                this.data_default_ini = item === null || item === void 0 ? void 0 : item.data_default_ini;
                this.data_reprocessamento_default_fim = item === null || item === void 0 ? void 0 : item.data_reprocessamento_default_fim;
                this.data_reprocessamento_default = item === null || item === void 0 ? void 0 : item.data_reprocessamento_default;
                this.dateadd_fim = item === null || item === void 0 ? void 0 : item.dateadd_fim;
                this.dateadd_ini = item === null || item === void 0 ? void 0 : item.dateadd_ini;
                this.permite_execucao_manual = item === null || item === void 0 ? void 0 : item.permite_execucao_manual;
                this.script_app = item === null || item === void 0 ? void 0 : item.script_app;
                this.script_database = item === null || item === void 0 ? void 0 : item.script_database;
                this.sis_batch_cd = item === null || item === void 0 ? void 0 : item.sis_batch_cd;
                this.sis_nucleo_cd_fk = item === null || item === void 0 ? void 0 : item.sis_nucleo_cd_fk;
                this.sis_nucleo_prc_cd = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_cd;
                this.sis_nucleo_prc_descricao = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_descricao;
                this.sis_nucleo_prc_descritivo = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_descritivo;
                this.sis_nucleo_prc_ref = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_ref;
                this.sis_nucleo_prc_tipo = item === null || item === void 0 ? void 0 : item.sis_nucleo_prc_tipo;
                this.versao = item === null || item === void 0 ? void 0 : item.versao;
                this.notificacao_cd = item === null || item === void 0 ? void 0 : item.notificacao_cd;
            }
        });
    }
}
exports.default = tbsistema_nucleo_procedimento;
