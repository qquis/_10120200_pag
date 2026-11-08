"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0150_01_estatistica_processamento {
    static version() { return `f0150_01_1012018_estatistica_processamento`; }
    static get(parametro = {}) {
        const sql = `
            SELECT * FROM ${this.version()} (
                dataFaturamento_ini:= '${parametro.dataFaturamento_ini ? modelbase_1.clsTools._datemomentDateToStr(parametro.dataFaturamento_ini, "YYYY-MM-DD") : '1900-01-01'}',
                dataFaturamento_fim:= '${parametro.dataFaturamento_fim ? modelbase_1.clsTools._datemomentDateToStr(parametro.dataFaturamento_fim, "YYYY-MM-DD") : '1900-01-01'}',
                vprocessamento_parcial:= ${parametro.vprocessamento_parcial ? parametro.vprocessamento_parcial : 1}
            )
        `;
        return sql;
    }
}
exports.default = f0150_01_estatistica_processamento;
