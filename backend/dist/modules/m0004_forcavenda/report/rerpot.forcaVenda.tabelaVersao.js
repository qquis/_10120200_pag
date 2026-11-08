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
class reportForcaVendaTabelaVersao {
    static sql(parametro) {
        console.log(parametro);
        let sql = `
                  Select v.fv_tabelapreco_cd
                    ,	t.fv_tabelapreco_descricao  	
                    ,	v.versao
                    ,   v.descontomaximo
                    ,	v.descontopadrao
                    ,	v.acrescimomaximo
                    ,	v.datainiciovigencia
                    ,	v.datafimvigencia 
                    ,	v.ativo
                    ,	v.tabelareferencia 
                from 		tbforca_venda_tabpreco_versao v
                left join 	tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = v.fv_tabelapreco_cd
                where 1 = 1
                    `;
        if (parametro.fv_tabelapreco_descricao) {
            sql += ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`;
        }
        if (parametro.fv_tabelapreco_cd) {
            sql += ` and v.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`;
        }
        if (parametro.vigencia_inicial) {
            sql += ` and v.datainiciovigencia >= '${parametro.vigencia_inicial} 00:00:00'`;
        }
        sql += ` ORDER BY t.fv_tabelapreco_descricao ASC `;
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
                modelbase_1.clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error \n ${e}`, false, false);
                throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error ${e}`);
            }
        });
    }
}
exports.default = reportForcaVendaTabelaVersao;
