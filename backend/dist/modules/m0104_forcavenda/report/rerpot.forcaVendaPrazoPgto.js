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
class reportForcaVendaPrazoPgto {
    static sql() {
        return `
                    select 	fv_prazopgto_cd 
                        ,	fv_prazopgto_descricao 
                        ,	custofinanceiro 
                        ,	coefcustofinanceiro 
                        ,	tipo 
                        ,	tipocusto
                        ,	status
                        ,	versao
                    from 	tbforca_venda_prazopgto 
                    ORDER BY fv_prazopgto_descricao
                    
                    `;
    }
    static get() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                let result = yield myBase.myDataBase.pag.DataGet(reportForcaVendaPrazoPgto.sql());
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaPrazoPgto.result | Error \n ${e}`, false, false);
                throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaPrazoPgto.result | Error ${e}`);
            }
        });
    }
}
exports.default = reportForcaVendaPrazoPgto;
