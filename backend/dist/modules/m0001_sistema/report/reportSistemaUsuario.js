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
class reportSistemaUsuario {
    static sql(parametros = {}) {
        try {
            let sql = `   SELECT 		
                                us.sis_us_seq 
                            ,	us.cdpessoabluesoft 
                            ,   us.user_name
                FROM 		tbsistema_usuario us
                WHERE 1=1
        `;
            if (parametros.user_name) {
                sql += ` AND us.user_name = '${parametros.user_name}' `;
            }
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportSistemaUsuario`, 'sql', e);
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
                yield modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaUsuario.get', e);
            }
        });
    }
    static getByUserName(user_name) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const myTools = new modelbase_1.clsBase();
                let result = yield this.get({ user_name });
                let item = yield myTools.myDataBase.RecordItem(result, 0);
                return item;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaUsuario.getByUserName', e);
            }
        });
    }
}
exports.default = reportSistemaUsuario;
