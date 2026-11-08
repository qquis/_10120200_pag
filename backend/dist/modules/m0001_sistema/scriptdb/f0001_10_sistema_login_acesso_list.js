"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0001_02_sistema_login_acesso_list {
    static sqlScript_VERSION() { return `f0001_10_1012010_sistema_login_acesso_list`; }
    static get(parametros) {
        return `SELECT * 
                        FROM   ${this.sqlScript_VERSION()}
                        (
                                vsis_id:= ${parametros.sis_id},
                                vemail_main:= '${parametros.email_main}',
                                vuser_name:= '${parametros.email_main}',
                                vpasswd:= '${parametros.vpasswd}' 
                        ) `;
    }
}
exports.default = f0001_02_sistema_login_acesso_list;
