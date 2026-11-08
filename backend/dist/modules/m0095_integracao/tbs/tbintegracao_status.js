"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
class tbintegracao_status extends model_1.modelTb {
    constructor() {
        super();
        this.integracao_status_cd = 0;
        this.integracao_status_descricao = ``;
    }
}
exports.default = tbintegracao_status;
