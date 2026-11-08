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
class reportForcaVendaFabricante {
    static sql(parametro) {
        let sql = `
                    select 		p.nome_razao 
                        ,		fv_fabricante_seq 
                        ,		fv_fabricante_descricao 
                        ,		fv_fabricante_referencia
                        ,		fv_fabricante_cdpessoabluesoft 
                        ,		t.mail_notificacao_estoque
                        ,		coalesce(t.mail_notificacao_estoque_address,'') as mail_notificacao_estoque_address
                        ,		t.mail_notificacao_giro
                        ,		t.fv_fabricante_status 
                    from 		tbforca_venda_fabricante t 
                    inner join 	tbpessoabluesoft p on p.cdpessoabluesoft  = t.fv_fabricante_cdpessoabluesoft
                    where 1=1
        `;
        if (parametro.cdpessoabluesoftfabricante) {
            sql += ` and t.fv_fabricante_cdpessoabluesoft = ${parametro.cdpessoabluesoftfabricante} `;
        }
        if (parametro.fv_fabricante_status && parametro.fv_fabricante_status == 1) {
            sql += ` and t.fv_fabricante_status = ${parametro.fv_fabricante_status} `;
        }
        sql += ` ORDER BY t.fv_fabricante_descricao ASC `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                let result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaFabricante.result | Error \n ${e}`, false, false);
                throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaFabricante.result | Error ${e}`);
            }
        });
    }
}
exports.default = reportForcaVendaFabricante;
