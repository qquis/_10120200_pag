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
class reportFaturamentoBluesoftStatus {
    static sql(filter) {
        let sql = `	SELECT 		sf.statusfaturamento
                    ,	sf.statusfaturamento_descricao 
                    ,	s.fat_blue_status_cd
                    ,	s.fat_blue_status_descricao 
            from 		tbfaturamento_bluesoft_status s
            inner join 	tbfaturamentostatus sf on sf.statusfaturamento = s.statusfaturamento

         where		1 = 1 
                     order by sf.statusfaturamento, s.fat_blue_status_descricao 
         `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield myBase.myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoBluesoftStatus;
