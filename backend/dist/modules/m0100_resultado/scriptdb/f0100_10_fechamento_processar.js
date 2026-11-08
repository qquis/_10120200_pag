"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
/*f0100_10_1012011_fechamento_processar*/
class f0100_10_fechamento_processar {
    static sqlScript_VERSION() { return `f0100_10_1012013_fechamento_processar`; }
    static post(parametros) {
        let sql = '';
        try {
            if (!parametros || !parametros.competencia_cd) {
                throw new Error("Parâmetros inválidos: 'competencia_cd' é obrigatório.");
            }
            sql = `SELECT * FROM ${f0100_10_fechamento_processar.sqlScript_VERSION()}
                        (
                                vcompetencia_cd:= ${parametros.competencia_cd}
                        
                        )`;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException('f0100_10_fechamento_processar', 'get', e);
        }
        finally {
            return sql;
        }
    }
}
exports.default = f0100_10_fechamento_processar;
