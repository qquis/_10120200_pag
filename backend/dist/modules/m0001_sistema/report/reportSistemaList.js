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
class reportSistemalist {
    static sql(parametros = {}) {
        try {
            console.log(`user name ${parametros.user_name}`);
            return `   SELECT 	sis_cd_pk 
                            ,	sis_ref
                            ,	sis_descricao 
                        FROM 	TBSISTEMA
                        WHERE   sis_cd_pk in (1,3,5)
                        order by sis_descricao asc

                        ${parametros.sis_ta_cd ? `and ta.sis_ta_cd = ${parametros.sis_ta_cd}` : ''}
                        ${parametros.sis_ta_descricao ? `and UPPER(ta.sis_ta_descricao) like UPPER('%${parametros.sis_ta_descricao}%')` : ''}
                        ${parametros.sis_ta_tipo_descricao ? `and UPPER(tp.sis_ta_tipo_descricao) like UPPER('%${parametros.sis_ta_tipo_descricao}%')` : ''}
        `;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemalist`, 'sql', e);
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
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemalist', e);
            }
        });
    }
}
exports.default = reportSistemalist;
