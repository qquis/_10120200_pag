"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0141_65_salario_contratada_list {
    static sqlScript_VERSION() { return `f0141_66_1012013_salario_competencia_list`; }
    static get(parametros) {
        let sql = `SELECT * 
                FROM f0141_65_1012009_salario_contratado_list 
                (
                    vtipo_relatorio:= '${parametros.tipo_relatorio ? parametros.tipo_relatorio : 'F'}',
                    vcdparticipante:= 0,
                    vrh_tipo_contrato_cd:= ${parametros.rh_tipo_contrato_cd ? parametros.rh_tipo_contrato_cd : 0},
                    vrh_setor_operacional_cd:= ${parametros.rh_setor_operacional_cd ? parametros.rh_setor_operacional_cd : 0},
                    vnome_razao:= ''
                )`;
        return sql;
    }
}
exports.default = f0141_65_salario_contratada_list;
