"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0045_60_aplicacao {
    static sqlScript_VERSION() { return `p0045_60_1012014_produto_preco_aplicacao`; }
    static SELECT(filter = null) {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()} ()`;
        return sqlscript;
    }
}
exports.default = f0045_60_aplicacao;
