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
class reportCbenefCst {
    static sql(parametro) {
        let sql = ` select 	fc_cbenef_cd 
                        ,	icms_codigo_tributacao
                    from tbfc_cbenef_cst
                    where 1 = 1
                `;
        if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
            sql += ` and fc_cbenef_cd like '%${parametro.fc_cbenef_cd}%'`;
        }
        if (parametro.icms_codigo_tributacao && parametro.icms_codigo_tributacao.trim() !== '') {
            sql += ` and icms_codigo_tributacao = %${parametro.icms_codigo_tributacao}%`;
        }
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let myBase = new modelbase_1.clsBase();
                result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportCbenefProduto | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportCbenefCst;
