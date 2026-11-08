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
class reportServiceBathTimeList {
    static sql(parametros) {
        let sql = `
                            
                                select 	        t.sis_batch_cd 
                                        ,	t.sis_batch_recorrencia_cd
                                        ,	r.sis_batch_recorrencia_descricao
                                        ,	t.sis_batch_dt_ini
                                        ,	t.sis_batch_dt_fim
                                        ,	t.sis_batch_hm_ini
                                        ,	t.sis_batch_hm_fim
                                        ,	t.sis_batch_wk_ini
                                        ,	t.sis_batch_wk_fim
                                        ,	t.sis_batch_time_seq 
                                from  tbsistema_batch_time t
                                left join tbsistema_batch b on b.sis_batch_cd = t.sis_batch_cd
                                left join tbsistema_batch_recorrencia r on r.sis_batch_recorrencia_cd = t.sis_batch_recorrencia_cd
                                left join tbsistema_batch_service s on s.sis_batch_service_cd = b.sis_batch_service_cd
                                                        where 1 = 1 
                                ${parametros.sis_batch_cd ? ` and t.sis_batch_cd = ${parametros.sis_batch_cd}` : ''}
                                ${parametros.sis_batch_service_cd ? ` and s.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}


                `;
        return sql;
    }
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                const modeldb = new modelbase_1.clsBase();
                result = yield modeldb.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportSistemaBatchTimeList.get`, `get`, e);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportServiceBathTimeList;
