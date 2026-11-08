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
class reportForcaVendaTabela {
    static sql(parametro) {
        let sql = `
                    select 	t.fv_tabelapreco_cd 
                        ,	t.fv_tabelapreco_descricao
                        ,	coalesce(co.percentual_comissao,0) as percentual_comissao
                        ,	coalesce(v.qtde_versao,0) as qtde_versao
                        ,	coalesce(v.versao_atual,0) as versao_atual
                        ,	coalesce(v.vigencia_inicial_atual, '1900-01-01 00:00') as vigencia_inicial_atual
                        ,	coalesce(v.vigencia_fim_atual, '1900-01-01 00:00') as vigencia_fim_atual
                    from tbforca_venda_tabpreco t
                    left join tbforca_venda_comis_tabpreco co on co.fv_tabelapreco_cd = t.fv_tabelapreco_cd
                    left join (
                                    select 	x.fv_tabelapreco_cd
                                        ,	count(distinct(x.versao)) as qtde_versao 
                                        ,	max(x.versao) as versao_atual 
                                        ,	max(x.datainiciovigencia) as vigencia_inicial_atual 
                                        ,	max(x.datafimvigencia) as vigencia_fim_atual 
                                    from tbforca_venda_tabpreco_versao x
                                    group by 	x.fv_tabelapreco_cd
                                ) v on v.fv_tabelapreco_cd = t.fv_tabelapreco_cd
                    where 1=1
                    `;
        if (parametro.fv_tabelapreco_descricao) {
            sql += ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`;
        }
        if (parametro.fv_tabelapreco_cd) {
            sql += ` and t.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`;
        }
        if (parametro.statusversao && parametro.statusversao == 1) {
            sql += ` and t.fv_tabelapreco_cd in ( select fv_tabelapreco_cd from tbforca_venda_tabpreco_versao where ativo = 1 )`;
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
exports.default = reportForcaVendaTabela;
