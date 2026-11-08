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
exports.reportProdutoOperacional = void 0;
const modelbase_1 = require("../../../model/modelbase");
const myBase = new modelbase_1.clsBase();
class reportProdutoOperacional {
    static sql(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ` `;
            sql = ` select      pr.pr_cdproduto 
                ,       pr.pr_descricao 
                ,       pr.prb_cdprodutobluesoft 

                ,       pr.pr_embalagemestoque 
                ,       pr.pr_embalagemcompra 
                ,       pr.pr_embalagemcompra_fator

                ,       pb.prb_descricao 
                ,       pb.prb_cdbarra_principal 
                ,       pb.prb_dt_cadastro 
                ,       pb.prb_dt_ultimaalteracao 
                ,       pb.prb_vendaexterna 
                ,       pb.prb_status
                ,       pb.prb_cdpessoabluesoft_fornecedor

                ,       es.ec_embalagemestoque_qtde 
                ,       es.ec_valor_custo_precificacao 
                ,       es.ec_valor_custo_faturamento 
            from        tbproduto pr
            left join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
            left join   tbestoquecusto    es on es.pr_cdproduto = pr.pr_cdproduto 
                    
                    `;
            return sql;
        });
    }
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let report = {};
            try {
                report = yield myBase.myDataBase.pag.DataGet(yield this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('m0020_produto', 'reportProdutoOperacional', e);
            }
            finally {
                return report;
            }
        });
    }
}
exports.reportProdutoOperacional = reportProdutoOperacional;
