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
class reportExternalZanthusTabFinalizadora {
    static sql(parametro) {
        let sql = ``;
        try {
            sql = `
           select cod_finalizadora as finalizadora_cd, descricao as finalizadora_descricao from tab_finalizadora
            WHERE 1 = 1
        
           order by 2 asc



            `;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - sql", e);
        }
        finally {
            return sql;
        }
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let mylist = [];
            try {
                let myBase = new modelbase_1.clsBase();
                mylist = yield myBase.myDataBase.zanthusPostgre.DataGet(this.sql(parametro));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - get", e);
            }
            finally {
                return mylist;
            }
        });
    }
}
exports.default = reportExternalZanthusTabFinalizadora;
