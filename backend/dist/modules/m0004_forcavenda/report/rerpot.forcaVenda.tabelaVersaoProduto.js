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
class reportForcaVendaTabelaProduto {
    static sql(parametro) {
        let sql = `
                        select i.fv_tabelapreco_cd 
                            ,	t.fv_tabelapreco_descricao 
                            ,	i.versao 
                            ,	i.dtlog_update 
                            ,	i.prb_cdprodutobluesoft 
                            ,	pb.prb_descricao 
                            ,	i.precoembalagem 
                            ,	i.precounitario 
                            ,	i.descontomaximo
                            ,	i.descontopadrao
                            ,	i.acrescimomaximo
                            , 	i.fatorpreco
                            ,	i.fatorestoque
                            ,	i.versao
                            ,	i.precopromocional
                            ,   v.datainiciovigencia
                        from 	tbforca_venda_tabprecoprodutobluesoft i
                        inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        inner join tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = i.fv_tabelapreco_cd
                        inner join tbforca_venda_tabpreco_versao v on v.fv_tabelapreco_cd = i.fv_tabelapreco_cd and v.versao = i.versao
                        where 1 =1
  
                    `;
        if (parametro.fv_tabelapreco_descricao && parametro.fv_tabelapreco_descricao.trim() !== '') {
            sql += ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`;
        }
        if (parametro.fv_tabelapreco_cd && parametro.fv_tabelapreco_cd > 0) {
            sql += ` and v.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`;
        }
        if (parametro.vigencia_inicial) {
            sql += ` and v.datainiciovigencia >= '${parametro.vigencia_inicial} 00:00:00'`;
        }
        if (parametro.prb_descricao && parametro.prb_descricao.trim() !== '') {
            sql += ` and upper(pb.prb_descricao) like upper('%${parametro.prb_descricao}%')`;
        }
        if (parametro.prb_cdpessoabluesoft_fabricante && parametro.prb_cdpessoabluesoft_fabricante > 0) {
            sql += ` and pb.prb_cdpessoabluesoft_fabricante = ${parametro.prb_cdpessoabluesoft_fabricante}`;
        }
        if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft > 0) {
            sql += ` and i.prb_cdprodutobluesoft = ${parametro.prb_cdprodutobluesoft}`;
        }
        sql += ` ORDER BY t.fv_tabelapreco_descricao, pb.prb_descricao ASC `;
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
exports.default = reportForcaVendaTabelaProduto;
