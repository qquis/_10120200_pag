"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_22_faturamentoorigem_processar {
    static version() { return `f0070_22_1012019_faturamentoorigem_processar`; }
    static get(parametro) {
        const sql = `
            SELECT * FROM ${this.version()} 
            (
                   vdata_processamento:= '${parametro.data_processamento}'
            )
        `;
        return sql;
    }
}
exports.default = f0070_22_faturamentoorigem_processar;
