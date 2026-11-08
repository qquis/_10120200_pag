"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Login = void 0;
class Login {
    constructor(sis_us_seq, cdpessoabluesoft, user_name, status_bluesoft, sis_fc_cd) {
        this.sis_us_seq = sis_us_seq;
        this.cdpessoabluesoft = cdpessoabluesoft;
        this.user_name = user_name;
        this.status_bluesoft = status_bluesoft;
        this.sis_fc_cd = sis_fc_cd;
    }
    static NewUsuarioFromRows(item) {
        return new Login(item.sis_us_seq, item.cdpessoabluesoft, item.user_name, item.status_bluesoft, item.sis_fc_cd);
    }
}
exports.Login = Login;
exports.default = Login;
