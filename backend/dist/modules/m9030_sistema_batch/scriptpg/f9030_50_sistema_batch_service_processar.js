"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f9030_50_sistema_batch_service_processar {
    static sqlScript_VERSION() { return `f9030_50_1012014_sistema_batch_runs_processar`; }
    static SELECT(sis_batch_service_cd) {
        let sql = `    SELECT ${this.sqlScript_VERSION()} 
                                    (
                                        vsis_batch_service_cd:= ${sis_batch_service_cd}
                                        
                                    )
                    
                    `;
        return sql;
    }
}
exports.default = f9030_50_sistema_batch_service_processar;
