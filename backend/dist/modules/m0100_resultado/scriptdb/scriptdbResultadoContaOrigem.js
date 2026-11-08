"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class scriptdbResultadoContaOrigem {
    static get(parametros) {
        let sql = `select 		o.r_conta_cd 
                            ,	o.r_conta_origem_tipo_cd 
                            ,	coalesce(tp.r_conta_origem_tipo_descricao,'') as r_conta_origem_tipo_descricao 
                            ,	o.r_centro_op_cd 
                            ,	coalesce(co.r_centro_op_descricao,'') as r_centro_op_descricao
                            ,	o.plc_conta_cd
                            ,	coalesce(cc.plc_descricao, '') as plc_descricao
                            ,	o.contrato_bluesoft_seq
                            ,	o.op_cdoperacao 
                            ,   x.op_descricao 
                            ,	o.prd_cddepartamento
                            ,	coalesce(dp.prd_descricao , '') as prd_descricao
                            ,	o.prs_cdsecao 
                            ,	coalesce(sc.prs_descricao, '') as prs_descricao
                            ,	o.rh_setor_operacional_cd 
                            ,	coalesce(rs.rh_setor_operacional_descricao, '') as rh_setor_operacional_descricao
                            ,	o.r_resp_cd
                            ,	coalesce(rp.r_resp_descricao, '') as r_resp_descricao
                            ,    o.cdparticipante
                            ,   coalesce(p.nome_razao, '') as nome_razao 
                    from 		tbresultado_conta_origem 			o
                    left join   tbresultado_conta_origem_tipo 		tp on tp.r_conta_origem_tipo_cd = o.r_conta_origem_tipo_cd
                    left join   tbresultado_centro_operacional		co on co.r_centro_op_cd = o.r_centro_op_cd 
                    left join   tbplanocontacontabil               cc on cc.plc_conta_cd = o.plc_conta_cd 
                    left join   tbproduto_departamento				dp on dp.prd_cddepartamento = o.prd_cddepartamento
                    left join   tbproduto_secao 					sc on sc.prs_cdsecao = o.prs_cdsecao 
                    left join   tbrh_setor_operacional 			rs on rs.rh_setor_operacional_cd = o.rh_setor_operacional_cd
                    left join   tbresultado_resp					rp on rp.r_resp_cd = o.r_resp_cd 
                    left join   tboperacao                         x on x.op_cdoperacao = o.op_cdoperacao 
                    left join   tbparticipante                     p on p.cdparticipante = o.cdparticipante 
                    WHERE 1 = 1
                    ${(parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_cd) ? " AND o.r_conta_cd = " + (parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_cd) : ""}
                    `;
        return sql;
    }
}
exports.default = scriptdbResultadoContaOrigem;
