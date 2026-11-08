"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class sql_function_f0071_10_interface_faturamento_processar {
    static version() { return `f0071_10_1012019_interface_faturamento_processar`; }
    static get(parametro) {
        const sql = `
            SELECT * FROM ${this.version()} ( vdata_faturamento_ini:= '${parametro.data_processamento_ini}', vdata_faturamento_fim:= '${parametro.data_processamento_fim}')`;
        return sql;
    }
}
exports.default = sql_function_f0071_10_interface_faturamento_processar;
