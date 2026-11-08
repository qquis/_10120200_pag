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
class reportServiceList {
    static sql(parametros) {
        let sql = `
                        select s.sis_batch_service_cd
                             , s.sis_batch_service_tipo_cd
                             , t.sis_batch_service_tipo_descricao
                             , s.sis_batch_service_descricao 
                             , sis_batch_service_host
                        from        tbsistema_batch_service s
                        left join   tbsis_batch_service_tipo t on s.sis_batch_service_tipo_cd = t.sis_batch_service_tipo_cd
                        ${parametros.sis_batch_service_cd ? ` where s.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}
                        ORDER BY   s.sis_batch_service_cd ASC 

  

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
                modelbase_1.clsTools.PagErrorException(`reportListService.get`, `get`, e);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportServiceList;
