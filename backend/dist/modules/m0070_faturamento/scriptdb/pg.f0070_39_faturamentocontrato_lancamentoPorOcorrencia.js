"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_39_faturamentocontrato_lancamentoPorOcorrencia {
    static version() { return `f0070_39_1012017_faturamentocontrato_lancarporOcorrencia`; }
    static get(parametro) {
        return `
            SELECT * FROM ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}					
            )
        `;
    }
}
exports.default = f0070_39_faturamentocontrato_lancamentoPorOcorrencia;
