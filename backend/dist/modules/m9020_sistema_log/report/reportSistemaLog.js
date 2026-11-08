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
const myBase = new modelbase_1.clsBase();
class reportSistemaLogList {
    static sql(parametro) {
        try {
            let sql = `  select 		a.dtlog_insert 
                ,		a.sis_log_seq
                ,		coalesce(a.proc_log_seq,0) as proc_log_seq
                ,		coalesce(a.sis_nucleo_prc_cd, 0) as sis_nucleo_prc_cd
                ,		a.sis_log_tag
                ,		a.sis_log_info
                ,		coalesce(a.sis_batch_run_seq,0) as sis_batch_run_seq
                ,		a.uuid 
                ,		a.uuid_start 
                ,		coalesce(b.sis_nucleo_prc_descritivo,'') as sis_nucleo_prc_descritivo
                ,		coalesce(b.sis_nucleo_prc_descricao, '') as sis_nucleo_prc_descricao
            from 		tbsistema_log a
            left join 	tbsistema_nucleo_procedimento b on b.sis_nucleo_prc_cd = a.sis_nucleo_prc_cd 

         where		1 = 1 

         `;
            if (parametro.dtlog_insert_inicial) {
                sql += ` and a.dtlog_insert >= '${parametro.dtlog_insert_inicial}'`;
            }
            if (parametro.dtlog_insert_final) {
                sql += ` and a.dtlog_insert <= '${parametro.dtlog_insert_final}'`;
            }
            if (parametro.sis_nucleo_prc_cd && parametro.sis_nucleo_prc_cd > 0) {
                sql += ` and a.sis_nucleo_prc_cd = ${parametro.sis_nucleo_prc_cd}`;
            }
            if (parametro.list_sis_nucleo_prc_cd && parametro.list_sis_nucleo_prc_cd.length > 0) {
                sql += ` and a.sis_nucleo_prc_cd in (${parametro.list_sis_nucleo_prc_cd.split(",").join(",")})`;
            }
            sql += ` order by a.sis_log_seq desc `;
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemaLogList`, `sql`, e);
            return ``;
        }
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportSistemaLog | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
    static LogNucleoProcedimentoToday(sis_nucleo_prc_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            let executed = false;
            try {
                let parametro = {
                    dtlog_insert_inicial: modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYY-MM-DD 01:01:01`),
                    dtlog_insert_final: modelbase_1.clsTools._datemomentDateToStr(new Date(), `YYYY-MM-DD 23:59:59`),
                    sis_nucleo_prc_cd
                };
                let result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
                if (result && Array.isArray(result) && result.length > 0) {
                    executed = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportSistemaLog | LogNucleoProcedimentoToday \n Error: ${e}`);
            }
            finally {
                return executed;
            }
        });
    }
}
exports.default = reportSistemaLogList;
