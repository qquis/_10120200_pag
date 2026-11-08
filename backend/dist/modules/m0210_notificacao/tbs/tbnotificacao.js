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
class tbnotificacao extends model_1.modelTb {
    constructor() {
        super();
        this.notificacao_cd = 0;
        this.notificacao_descricao = '';
        this.notificacao_mail = 0;
        this.notificacao_origem_sis_nucleo_prc_cd = 0;
        this.notificacao_send_tipo_cd = 0;
        this.notificacao_whatsapp = 0;
        this.notificacao_tipo_body_cd = 0;
        this.notificacao_sql = '';
        this.notificacao_whats_user_show = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.notificacao_cd = item === null || item === void 0 ? void 0 : item.notificacao_cd;
                this.notificacao_descricao = item === null || item === void 0 ? void 0 : item.notificacao_descricao;
                this.notificacao_mail = item === null || item === void 0 ? void 0 : item.notificacao_mail;
                this.notificacao_origem_sis_nucleo_prc_cd = item === null || item === void 0 ? void 0 : item.notificacao_origem_sis_nucleo_prc_cd;
                this.notificacao_send_tipo_cd = item === null || item === void 0 ? void 0 : item.notificacao_send_tipo_cd;
                this.notificacao_whatsapp = item === null || item === void 0 ? void 0 : item.notificacao_whatsapp;
                this.notificacao_tipo_body_cd = item === null || item === void 0 ? void 0 : item.notificacao_tipo_body_cd;
                this.notificacao_sql = item === null || item === void 0 ? void 0 : item.notificacao_sql;
                this.notificacao_whats_user_show = item === null || item === void 0 ? void 0 : item.notificacao_whats_user_show;
            }
        });
    }
}
exports.default = tbnotificacao;
