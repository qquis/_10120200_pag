"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0100_20_fechamento_consultar {
    static sqlScript_VERSION() { return `f0100_20_1012011_fechamento_consultar`; }
    static get(parametros) {
        let sql = `SELECT * FROM ${f0100_20_fechamento_consultar.sqlScript_VERSION()}
                        (
                                vcompetencia_cd:= ${parametros.competencia_cd}
                             ,  vop_cdoperacao:= ${parametros.op_cdoperacao} 
                             ,  vr_resp_cd:= ${parametros.r_resp_cd}
                             ,  vr_centro_op_cd:= ${parametros.r_centro_op_cd}
                             ,  vr_cd:= ${parametros.r_cd}
                        )
                
                `;
        return sql;
    }
}
exports.default = f0100_20_fechamento_consultar;
