"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0070_25_faturamentocontrato_apuracao {
    static version() { return `f0070_30_1012019_faturamentocontrato_apuracao`; }
    static get(parametro) {
        const sql = `
            SELECT * FROM ${this.version()} 
            (
                    VCOMPETENCIA_CD:= ${parametro.competencia_cd}		
                ,	VCONTRATO_SEQ:= ${parametro.contrato_seq}					
                    		
            
            )
        `;
        return sql;
    }
}
exports.default = f0070_25_faturamentocontrato_apuracao;
