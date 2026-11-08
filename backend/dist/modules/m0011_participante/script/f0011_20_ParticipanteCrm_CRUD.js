"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0011_20_ParticipanteCRM_CRUD {
    static sqlScript_VERSION() { return `f0011_20_1012015_tbparticipante_crm_crud`; }
    static get(parametros) {
        let data = modelbase_1.clsTools._datemomentDatStrToDate((parametros === null || parametros === void 0 ? void 0 : parametros.data_nascimento) ? parametros.data_nascimento : '1900-01-01', 'YYYY-MM-DD HH:mm:ss');
        let sql = `SELECT * from ` + this.sqlScript_VERSION() +
            `(              sqlcommand := 'DBINSERT'				
                                ,	vcrm_seq:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.crm_seq) ? parametros.crm_seq : 0}
                                ,       vcrm_status_cd:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.crm_status_cd) ? parametros.crm_status_cd : 'A'}'
                                ,	vcrm_email:= '${parametros === null || parametros === void 0 ? void 0 : parametros.crm_email}'
                                ,       vcpf:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.cpf) ? parametros.cpf : ''}'
                                ,       vcdparticipante:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.cdparticipante) ? parametros.cdparticipante : 0}
                                ,	vnome:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.nome) ? parametros.nome : ''}'
                                ,	vsobre_nome:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.sobre_nome) ? parametros.sobre_nome : ''}'
                                ,       vdata_nascimento:= '${modelbase_1.clsTools._datemomentDateToStr(data, 'YYYY-MM-DD')}'
                                ,       vpf_sexo:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.pf_sexo) ? parametros.pf_sexo : 'N'}'
                        );
                       `;
        return sql;
    }
}
exports.default = f0011_20_ParticipanteCRM_CRUD;
