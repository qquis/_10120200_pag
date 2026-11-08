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
class reportAutorizacaoPgtoPag {
    static sql(parametros = {}) {
        try {
            let data_pgto_ini = new Date(parametros.data_pgto_ini);
            let data_pgto_fim = new Date(parametros.data_pgto_fim);
            if (parametros.filtrar_data_pgto) {
                if (isNaN(data_pgto_ini.getDate()))
                    data_pgto_ini = new Date();
                if (isNaN(data_pgto_fim.getDate()))
                    data_pgto_fim = new Date();
            }
            let sql = `SELECT   x.sis_us_seq	
                            ,   ul.user_name as user_name
                            ,   x.aut_pgto_pag_seq
                            ,   x.aut_pgto_pag_uuid	
                            ,	x.competencia_cd 
                            ,   c.competencia_descricao			
                            ,	x.em_cdempresa		
                            ,   x.r_conta_cd
                            ,   r.r_conta_descricao  	
                            ,	x.aut_pgto_pag_data 		
                            ,	x.cdparticipante			
                            ,	x.aut_pgto_pag_data_pgto  
                            ,	x.aut_pgto_pag_valor	
                            ,   x.aut_pgto_pag_obs
                            ,   x.aut_pgto_pag_cancelado
                            ,   x.aut_pgto_pag_cancelado_data
                            ,   x.aut_pgto_pag_cancelado_sis_us_seq
                            ,   uc.user_name as user_name_cancelador
                        FROM tbautorizacaopagamentopag x 
                        left join tbresultado_conta r on r.r_conta_cd = x.r_conta_cd
                        left join tbsistema_usuario ul on ul.sis_us_seq = x.sis_us_seq
                        left join tbsistema_usuario uc on uc.sis_us_seq = x.aut_pgto_pag_cancelado_sis_us_seq
                        left join tbcompetencia c on c.competencia_cd = x.competencia_cd 
                        where 1 = 1
                          
                        ${(parametros.filtrar_data_pgto == 1 && parametros.data_pgto_ini) ?
                " and x.aut_pgto_pag_data_pgto >= '" + modelbase_1.clsTools._datemomentDateToStr(data_pgto_ini, "YYYY-MM-DD") + "'" : ""} 
                        ${(parametros.filtrar_data_pgto == 1 && parametros.data_pgto_fim) ?
                " and x.aut_pgto_pag_data_pgto <= '" + modelbase_1.clsTools._datemomentDateToStr(data_pgto_fim, "YYYY-MM-DD") + "'" : ""} 

                        ${(parametros.r_conta_cd && parseInt(parametros.r_conta_cd) > 0) ? "and r.r_conta_cd=" + parametros.r_conta_cd : ""}

                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0) ? "and x.competencia_cd=" + parametros.competencia_cd : ""}

                        ${(parametros.cancelado && parseInt(parametros.cancelado) == 1) ? "and x.aut_pgto_pag_cancelado in (1,0) " : "and x.aut_pgto_pag_cancelado = 0"}

                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0) ? "and x.competencia_cd=" + parametros.competencia_cd : ""}

                     ORDER BY x.aut_pgto_pag_data desc 
                     `;
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
            return '';
        }
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
                return result; //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
            }
        });
    }
}
exports.default = reportAutorizacaoPgtoPag;
