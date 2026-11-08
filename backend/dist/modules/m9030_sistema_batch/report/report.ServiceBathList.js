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
class reportServiceBathList {
    static sql(parametros) {
        let sql = `
                            select 	b.sis_batch_cd 
                                ,	b.sis_batch_descricao 
                                ,	b.sis_batch_status 
                                ,	b.sis_batch_service_cd 
                                ,	b.module_cd 
                            from 	tbsistema_batch b
                            where 1 = 1 
                            ${parametros.sis_batch_service_cd ? ` and b.sis_batch_service_cd = ${parametros.sis_batch_service_cd}` : ''}
                            ${parametros.sis_batch_cd ? ` and b.sis_batch_cd = ${parametros.sis_batch_cd}` : ''}

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
                modelbase_1.clsTools.PagErrorException(`reportSistemaBatch.get`, `get`, e);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportServiceBathList;
