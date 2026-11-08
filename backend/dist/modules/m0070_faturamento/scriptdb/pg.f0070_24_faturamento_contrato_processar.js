"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0070_24_faturamento_contrato_processar {
    static version() { return `f0070_24_1012010_faturamento_contrato_processar`; }
    static get(parametro) {
        return `
            SELECT * FROM ${this.version()} 
            (
                    vfaturamento_controle_seq:= ${parametro.faturamento_controle_seq}		
                ,	vcontrato_seq:= ${parametro.contrato_seq}					
                ,	vdata_val_ini:= '${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_ini, "YYYY-MM-DD")}' 					
                ,	vdata_val_fim:= '${modelbase_1.clsTools._datemomentDateToStr(parametro.data_val_fim, "YYYY-MM-DD")}'			
            
            )
        `;
    }
}
exports.default = f0070_24_faturamento_contrato_processar;
