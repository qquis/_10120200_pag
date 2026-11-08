"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class modelUserLogin {
    constructor() {
        this.sis_id = 0;
        this.usuario_login_uuid = ``;
        this.sis_us_seq = 0;
        this.user_name = ``;
        this.dtlog_insert = new Date();
        this.autorizado = 0;
        this.email_login = ``;
        this.password = ``;
        this.jwtExp = 0;
        this.jwtIat = 0;
        this.user_credential = ``;
        this.user_credential_number = ``;
    }
    binding(item) {
        try {
            if (item) {
                this.usuario_login_uuid = item === null || item === void 0 ? void 0 : item.usuario_login_uuid;
                this.sis_us_seq = item === null || item === void 0 ? void 0 : item.sis_us_seq;
                this.user_name = item === null || item === void 0 ? void 0 : item.user_name;
                this.autorizado = item === null || item === void 0 ? void 0 : item.autorizado;
                this.email_login = item === null || item === void 0 ? void 0 : item.email_login;
                this.usuario_login_uuid = item === null || item === void 0 ? void 0 : item.usuario_login_uuid;
                this.password = ``;
                this.user_credential = item === null || item === void 0 ? void 0 : item.user_credential;
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException('model_notificacao', 'NotificacaoGetParticipantes', e);
        }
    }
}
exports.default = modelUserLogin;
