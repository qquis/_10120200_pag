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
class reportFormaPgtoBlueSoft {
    static sql(parametros = {}) {
        try {
            let sql = `SELECT forma_pgto_cd, forma_pgto_descricao, forma_pgto_ref_blue  FROM tbforma_pgto_bluesoft WHERE 1 = 1 order by forma_pgto_descricao asc`;
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
exports.default = reportFormaPgtoBlueSoft;
