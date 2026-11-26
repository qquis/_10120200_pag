"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0045_60_aplicacao {
    static sqlScript_VERSION() { return `f0045_60_1012020_produto_preco_aplicacao`; }
    static SELECT(filter = null) {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()} ()`;
        return sqlscript;
    }
}
exports.default = f0045_60_aplicacao;
