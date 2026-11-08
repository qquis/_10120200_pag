"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
class tbautorizacaopagamento_abatimento extends model_1.modelTb {
    constructor() {
        super();
        this.autpgto_seq_pk = 0;
        this.autpgto_ab_seq = 0;
        this.autpgto_seq_pk_origem = 0;
        this.autpgto_ab_valor = 0;
    }
}
exports.default = tbautorizacaopagamento_abatimento;
