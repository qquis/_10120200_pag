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
class reportSistemaParametro {
    static sql(parametros = {}) {
        try {
            let sql = `    select      s.sis_pr_cd
                                ,   s.sis_pr_descricao
                                ,   s.sis_pr_value
                        from    tbsistema_parametro s
                        WHERE       1 = 1

        `;
            if (parametros.sis_pr_cd) {
                sql += ` and s.sis_pr_cd = ${parametros.sis_pr_cd} `;
            }
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemaTarefa`, 'sql', e);
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
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaTarefa', e);
            }
        });
    }
    static getParametroValue(sis_pr_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = yield this.get({ sis_pr_cd });
            if (result && result.length > 0) {
                return result[0].sis_pr_value;
            }
            else {
                return '';
            }
        });
    }
}
exports.default = reportSistemaParametro;
