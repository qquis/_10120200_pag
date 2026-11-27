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
class reportForcaVendaMetaFabricante {
    static sql(filter) {
        let sql = `	select 	x.fv_fabricante_cdpessoabluesoft 
                ,	b.nome_razao 
                ,	x.fv_fab_meta_cd
                ,	x.fv_fab_meta_descricao 
                ,	x.fv_fab_meta_tipo
                ,	a.fv_fab_meta_tipo_descricao 
                ,	x.fv_fab_data_ini
                ,	x.fv_fab_data_fim 
            from 	tbforca_venda_fab_meta X
            LEFT JOIN tbforca_venda_fab_meta_tipo A ON A.fv_fab_meta_tipo_cd = x.fv_fab_meta_tipo
            LEFT JOIN tbparticipante_bluesoft b on b.cdpessoabluesoft = x.fv_fabricante_cdpessoabluesoft
            order by x.fv_fab_meta_cd

        `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield new modelbase_1.clsBase().myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportForcaVendaMetaFabricante | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportForcaVendaMetaFabricante;
