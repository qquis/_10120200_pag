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
class reportFaturamentoBluesoftItemList {
    static sql(filter) {
        let sql = `  select      i.op_cdoperacao 
                    ,	i.numeropedido 
                    ,	i.numeropedido_fv
                    ,	i.prb_cdprodutobluesoft_unitario 
                    ,	i.prb_cdprodutobluesoft 
                    ,   p.prb_descricao as prb_descricao 
                    ,	i.prb_embalagem 
                    ,	i.prb_fatorestoque 
                    ,	i.embalagem_descricao 
                    ,	i.qtde_unitaria_solicitada 
                    ,	i.qtde_unitaria_faturada
                    ,	i.qtde_solicitada 
                    ,	i.qtde_faturada 
                    ,	i.valor_custo_com_icm_unit 
                    ,	i.valor_custo 
                    ,	i.valor_preco_tabela
                    ,	i.valor_preco 
                    ,	i.valor_preco_aplicado 
                    ,	i.valor_verba 
                    ,	i.valor_verba_gerencia 
                    ,	i.valor_verba_supervisao 
                    ,	i.valor_verba_calculada
                    ,	i.valor_desconto_financeiro 
                    ,	i.valor_nf_item_bruto 
                    ,	i.valor_nf_item 
                    ,	i.item_nf_bonificado 
                    ,	i.percentual_desconto_financeiro 
                from 	tbfaturamento_bluesoft_item i
                left join tbfaturamento_bluesoft    f on f.numeropedido = i.numeropedido and f.numeropedido_fv = i.numeropedido_fv and i.op_cdoperacao = f.op_cdoperacao
                left join tbprodutobluesoft p on p.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
                where 1 = 1 
         
         `;
        if (filter.op_cdoperacao) {
            sql += ` and i.op_cdoperacao = ${filter.op_cdoperacao}`;
        }
        if (filter.numeropedido) {
            sql += ` and i.numeropedido = ${filter.numeropedido}`;
        }
        if (filter.numeropedido_fv) {
            sql += ` and i.numeropedido_fv = ${filter.numeropedido_fv}`;
        }
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
exports.default = reportFaturamentoBluesoftItemList;
