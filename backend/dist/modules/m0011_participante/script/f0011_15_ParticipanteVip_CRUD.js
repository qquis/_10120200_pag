"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0011_15_ParticipanteVip_CRUD {
    static sqlScript_VERSION() { return `f0011_15_1012017_tbparticipante_vip_crud`; }
    static get(parametros) {
        let sql = `SELECT ` + this.sqlScript_VERSION() +
            `(              sqlcommand := 'DBINSERT'
                                ,       vvip_id := ${parametros.vip_id ? parametros.vip_id : 0}				
                                ,	vvip_cliente_id:= '${parametros.vip_cliente_id ? parametros.vip_cliente_id : '0'}'
                                ,       vvip_cpf_cnpj:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_cpf_cnpj}'
                                ,	vvip_cpf:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_cpf}'
                                ,	vvip_cnpj:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_cnpj}'
                                ,	vcdparticipante:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.vcdparticipante) ? parametros.vcdparticipante : 0}
                                ,	vvip_nome_completo:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_nome_completo}'
                                ,	vvip_nome:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_nome}'
                                ,	vvip_sobre_nome:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_sobre_nome}'
                                ,	vvip_email:= '${parametros === null || parametros === void 0 ? void 0 : parametros.vvip_email}'
                                ,       vvip_data_nascimento:= '${parametros.vvip_data_nascimento ? modelbase_1.clsTools._datemomentDateToStr(parametros.vvip_data_nascimento, "YYYY-MM-DD") === "Data inválida" ? '1900-01-01' : modelbase_1.clsTools._datemomentDateToStr(parametros.vvip_data_nascimento, "YYYY-MM-DD") : '1900-01-01'}'
                                ,       vvip_telefone_celular:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.vvip_telefone_celular) ? parametros.vvip_telefone_celular : ''}'
                        );
                       `;
        return sql;
    }
}
exports.default = f0011_15_ParticipanteVip_CRUD;
