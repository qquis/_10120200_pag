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
class reportProdutoBluesoftRedshift {
    static sql(parametro) {
        let sql = ``;
        sql =
            `select       coalesce(x.produto_key,0)                      as  prb_cdprodutobluesoft_pk
                           ,  coalesce(x.produto_unitario_key,0)             as  prb_cdprodutobluesoft_unitario 
                           ,  x.descricao                                    as  prb_descricao 
                           ,  x.embalagem_key                                as  prb_embalagemestoque 
                           ,  coalesce(x.fator_estoque,1)                    as  prb_fatorestoque 
                           ,  x.caixa                                        as  prb_status_embalagemcaixa  
                           ,  coalesce(x1.embalagem_key,x.embalagem_key)     as  prb_embalagemcompra  
                           ,  coalesce(x1.fator_estoque,1)                   as  prb_embalagemcompraqtdeunitaria  
                           ,  x.gtin_principal                               as  prb_cdbarra_principal 
                           ,  coalesce(x.controle_estoque,0)                 as  prb_cdprodutobluesoft_controleestoque 
                           ,  coalesce(x.preco_equivalente,0)                as  prb_cdprodutobluesoft_controlepreco 
                           ,  coalesce(x.sub_grupo_produto_key,0)            as  prb_cdsubgrupo             
                           ,  coalesce(x.ultima_alteracao,'1900-01-01')      as  prb_dt_ultimaalteracao  
                           ,  coalesce(x.data_cadastro,'1900-01-01')         as  prb_dt_cadastro 
                           ,  coalesce(x.fabricante_key,0)                   as  prb_cdpessoabluesoft_fabricante 
                           ,  coalesce(vx.vendaexterna,0)                    as  prb_vendaexterna  
                           ,  coalesce(x.status,0)                           as  prb_status  
                           ,  coalesce(fp.produto_key,0)                     as  prb_cdproduto_compra_padrao  
                           ,  coalesce(fp.fornecedor_produto_key,0)          as  prbf_seq  
                           ,  coalesce(x.tipo_composicao_key,0)              as  prb_tipo_composicao_cd  
                           ,  coalesce(x.descricao_gondola, '')              as  prb_descricao_gondola  
                           ,  coalesce(x.descricao_cupom, '')                as  prb_descricao_cupom  
                           ,  coalesce(x.descricao_balanca, '')              as  prb_descricao_balanca  
                           ,  coalesce(x.fornecedor_key, 0)                  as  prb_cdpessoabluesoft_fornecedor  
                           ,  coalesce(x.troca_fornecedor_key, 0)            as  prb_cdpessoabluesoft_fornecedor_troca   
                           ,  coalesce(x.peso_bruto,0)                       as  prb_pesobruto  
                           ,  coalesce(x.peso_liquido,0)                     as  prb_pesoliquido   
                 from         produto_d     x  
                 left join    fornecedor_produto           fp on fp.fornecedor_produto_key = x.fornecedor_produto_padrao_key  
                 left join    produto_d                    x1 on x1.produto_key = fp.produto_key 
                 left join    (   select   produto_key            as cdprodutobluesoft  
                                         , convert(int, 1)        as vendaexterna  
                                  from     produto_loja_venda_externa    
                                  group by produto_key  
                              ) vx on vx.cdprodutobluesoft = isnull(x.produto_key,0)  
                 where        x.produto_key > 0  
                 order by     x.produto_key asc ;
                `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let myBase = new modelbase_1.clsBase();
                result = yield myBase.myDataBase.redshift.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("ReportParticipanteBluesoftRedshift", "get", e);
                throw new Error(`modules | ProdutoBluesoft | Error ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportProdutoBluesoftRedshift;
