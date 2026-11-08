"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class reportFechamentoLanc {
    static sql(parametros = {}) {
        let sql = `
                        select    l.em_cdempresa 
                                , em.em_descricao
                                , l.competencia_cd
                                , cm.competencia_descricao
                                , l.r_conta_cd
                                , rc.r_conta_descricao
                                , l.autpgto_seq_pk
                                , ad.descritivo
                                , ap.autpgto_dataemissao 
                                , ap.autpgto_datapagamento        
                                , ap.autpgto_datavencimento

                                , l.aut_pgto_pag_seq
                                , pag.aut_pgto_pag_data
                                , pag.aut_pgto_pag_obs        
                                , l.r_centro_op_cd
                                , l.r_resp_cd 
                                , l.rh_setor_operacional_cd
                                , so.rh_setor_operacional_descricao
                                , l.rh_funcionario_cd
                                , l.r_fechamento_lanc_valor
                                , sal.rh_vl_salario
                                , sal.rh_vl_pj
                                , sal.rh_vl_outros
                                , l.r_fechamento_lanc_valor
                                , l.cdparticipante
                                , p.nome_razao
                        from      tbresultado_fechamento_lanc       l
                        left join tbempresa                         em  on em.em_cdempresa = l.em_cdempresa
                        left join tbcompetencia                     cm  on cm.competencia_cd = l.competencia_cd
                        left join tbresultado_conta                 rc  on rc.r_conta_cd = l.r_conta_cd  
                        left join tbautorizacaopagamento            ap  on ap.autpgto_seq_pk = l.autpgto_seq_pk
                        left join tbautorizacaopagamento_descritivo ad  on ad.autpgto_seq_fk = l.autpgto_seq_pk
                        left join tbautorizacaopagamentopag         pag on pag.aut_pgto_pag_seq = l.aut_pgto_pag_seq
                        left join tbrh_setor_operacional            so  on so.rh_setor_operacional_cd = l.rh_setor_operacional_cd
                        left join tbrh_salario                      sal on sal.competencia_cd = l.competencia_cd 
                                                                    and sal.rh_setor_operacional_cd = l.rh_setor_operacional_cd
                                                                    and sal.rh_funcionario_cd = l.rh_funcionario_cd
                        left join tbparticipante                    p   on p.cdparticipante = l.cdparticipante
                                        
                        where     1 = 1 
                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0) ? " AND l.competencia_cd = " + (parametros === null || parametros === void 0 ? void 0 : parametros.competencia_cd) : ""}                            
                        ${(parametros.r_conta_cd && parseInt(parametros.r_conta_cd) > 0) ? " AND rc.r_conta_cd = " + (parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_cd) : ""}    
                        ${((parametros === null || parametros === void 0 ? void 0 : parametros.r_rateio_cd) && parseInt(parametros === null || parametros === void 0 ? void 0 : parametros.r_rateio_cd) > 0) ? " AND rc.r_rateio_Cd = " + (parametros === null || parametros === void 0 ? void 0 : parametros.r_rateio_cd) : ""}
                        ${((parametros === null || parametros === void 0 ? void 0 : parametros.r_grupo_cd) && parseInt(parametros === null || parametros === void 0 ? void 0 : parametros.r_grupo_cd) > 0) ? " AND rc.r_grupo_cd = " + (parametros === null || parametros === void 0 ? void 0 : parametros.r_grupo_cd) : ""}     

                        ${((parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_lancamento_manual) && parseInt(parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_lancamento_manual) > 0) ? " AND rc.r_conta_lancamento_manual = " + (parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_lancamento_manual) : ""}
                        ${(parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_descricao) ? " AND UPPER(rc.r_conta_descricao)  like '%" + (parametros === null || parametros === void 0 ? void 0 : parametros.r_conta_descricao) + "%'" : ""}
                        
                        ${(parametros.orderbycolunm && parametros.orderbycolunm !== "") ?
            " ORDER BY " + parametros.orderbycolunm : "ORDER BY 1"}

            `;
        return sql;
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}, sql = ``) {
            let sqlQuery = sql || this.sql(parametros);
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield myTools.myDataBase.pag.DataGet(sqlQuery);
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDREContaList`, 'sql', e);
            }
        });
    }
}
exports.default = reportFechamentoLanc;
