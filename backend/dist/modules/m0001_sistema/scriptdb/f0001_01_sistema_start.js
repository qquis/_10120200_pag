"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0001_01_sistema_backend_start {
    static sqlScript_VERSION() { return `f0001_01_1012014_sistema_backend_start`; }
    static get(parametros) {
        let sql = `SELECT ` + this.sqlScript_VERSION() +
            `(         venvironment:= '${parametros.venvironment}'
                                ,  vbackend_mirror:= '${parametros.vbackend_mirror ? parametros.vbackend_mirror : '0'}'
                        )
                       `;
        return sql;
    }
}
exports.default = f0001_01_sistema_backend_start;
