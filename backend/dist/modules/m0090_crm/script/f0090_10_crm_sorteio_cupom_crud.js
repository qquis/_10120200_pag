"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0090_10_crm_sorteio_cupom_crud {
    static sqlScript_VERSION() { return `f0090_10_1012015_crm_sorteio_cupom_crud`; }
    static get(parametros) {
        let data = modelbase_1.clsTools._datemomentDatStrToDate((parametros === null || parametros === void 0 ? void 0 : parametros.data_nascimento) ? parametros.data_nascimento : '1900-01-01', 'YYYY-MM-DD HH:mm:ss');
        let sql = `SELECT * from ` + this.sqlScript_VERSION() +
            `(              sqlcommand := 'DBINSERT'				
                                ,       vcrm_so_temp_cd:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.crm_so_temp_cd) ? parametros.crm_so_temp_cd : 0}			
                                ,	vnumero_cupom:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.numero_cupom) ? parametros.numero_cupom : '0'}			
                                ,	vnumero_pedido:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.numero_pedido) ? parametros.numero_pedido : '0'} 			
                                ,	vdata_emissao:= '${modelbase_1.clsTools._datemomentDateToStr(parametros.data_emissao, 'YYYY-MM-DD')}'
                                ,       vdata_emissao_hora:= '${modelbase_1.clsTools._datemomentDateToStr(parametros.data_emissao_hora, 'YYYY-MM-DD HH:mm:ss')}'			
                                ,       vsat_ecf:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.sat_ecf) ? parametros.sat_ecf : 0}			
                                ,	vnf_numero:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.nf_numero) ? parametros.nf_numero : 0}			
                                ,	vnf_data_emissao:= '${modelbase_1.clsTools._datemomentDateToStr(parametros.nf_data_emissao, 'YYYY-MM-DD')}'		
                                ,	vnf_chave:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.nf_chave) ? parametros.nf_chave : ''}'			
                                ,	vvalor:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.valor) ? parametros.valor : 0}				
                                ,	vcpf_cnpj:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.cpf_cnpj) ? parametros.cpf_cnpj : ''}'			
                                ,       vcrm_so_cpf:= '${(parametros === null || parametros === void 0 ? void 0 : parametros.crm_so_cpf) ? parametros.crm_so_cpf : ''}'			
                                ,       vcdparticipante:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.cdparticipante) ? parametros.cdparticipante : 0}			
                                ,       vcrm_so_qtde_numero_sorteio:= ${(parametros === null || parametros === void 0 ? void 0 : parametros.crm_so_qtde_numero_sorteio) ? parametros.crm_so_qtde_numero_sorteio : 0}	
                        );
                       `;
        return sql;
    }
}
exports.default = f0090_10_crm_sorteio_cupom_crud;
