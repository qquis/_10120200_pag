"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
class tbintegracao extends model_1.modelTb {
    constructor() {
        super();
        this.integracao_cd = 0;
        this.integracao_descricao = ``;
    }
}
exports.default = tbintegracao;
