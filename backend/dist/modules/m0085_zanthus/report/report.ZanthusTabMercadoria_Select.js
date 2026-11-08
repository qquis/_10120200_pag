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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS REPORT _ tab_mercadoria_select";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = `LOG_TESTE`;
/*  ____________________________________________________________________________________________*/
/*
-------------------------------------------------------------------------------------------------------------------------------------
B18.15 _ 18/08/2026, terça feira - 09:00
-------------------------------------------------------------------------------------------------------------------------------------
- Alteração no scriptSelect() para obter os produtos pendentes. Os produtos pendentes eram selecionados de acordo com o pr_cdproduto
e agora passarão a ser selecionados pelo prb_cdprodutobluesoftUNITARIO.
a) Esta tabela/campo será alimentada em várias etapas na execução das
    - f0021_01_1012018_produtobluesoft_crud
    - f0021_90_1012018_produtobluesoft_processamento

    Código anterior ________________________________________________________________________________________
                             + (this.filter.ProdutosPendentesDeIntegracao?
                  ` and ( 			pr.pr_cdproduto in (
                                                       select x.pr_cdproduto
                                                       from   tbintegracao_produto x
                                                       where  1 = 1
                                                         and  x.integracao_tipo_cd = 20008501
                                                         and  x.integracao_status_cd = 2
                          
                                                    )
    Código atual ___________________________________________________________________________________________
                             + (this.filter.ProdutosPendentesDeIntegracao?
                  ` and ( 			pr.prb_cdprodutobluesoft in (
                                                       select x.prb_cdprodutobluesoftunitario
                                                       from   tbintegracao_produto x
                                                       where  1 = 1
                                                         and  x.integracao_tipo_cd = 20008501
                                                         and  x.integracao_status_cd = 2
                          
                                                    )
-------------------------------------------------------------------------------------------------------------------------------------

*/
require("dotenv/config");
const tbZanthusTabMercadoria_1 = __importDefault(require("../tbs/tbZanthusTabMercadoria"));
const modelbase_1 = require("../../../model/modelbase");
class reportZanthusTabMercadoria_Select {
    constructor(filter) {
        this.filter = filter;
    }
    tblist_Get() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let listTabMercadoria = [];
            try {
                let myClsBase = new modelbase_1.clsBase();
                let result = yield myClsBase.myDataBase.pag.DataGet(this.scriptSelect());
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTab_Mercadoria = new tbZanthusTabMercadoria_1.default();
                        itemTbZanthusTab_Mercadoria.binding(value);
                        listTabMercadoria.push(itemTbZanthusTab_Mercadoria);
                        if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Mercadoria.pr_cdproduto} - ${itemTbZanthusTab_Mercadoria.descricao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE);
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `report.tab_mercadoria_select | tblist_Get`, e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Total de produtos selecionados: ${listTabMercadoria.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE);
                return listTabMercadoria;
            }
        });
    }
    scriptSelect() {
        let sqlscript = ``;
        sqlscript = `SELECT	me.pr_cdproduto				
                            ,   pr.prb_cdprodutobluesoft as prb_cdprodutobluesoftunitario 				
                            ,	me.prb_cdprodutobluesoft						
                            ,	me.preg_cdbarra								
                            ,	me.cod_loja 									
                            ,	me.controle 									
                            ,	me.cod_mercadoria 								
                            ,	me.descricao 									
                            ,	me.desc_abr             as descricao_abr								
                            ,	me.cod_departamento 							
                            ,	me.cod_tributacao_mercadoria					
                            ,	me.cod_tecla 									
                            ,	me.percentual_desc_venda						
                            ,	me.permissao_venda  							
                            ,	me.percentual_reduz_b_calculo					
                            ,	me.indica_merc_peso_variavel					
                            ,	me.custo_unitario 								
                            ,	me.grupo_garantia								
                            ,	me.fator_seguranca_venda_estoque				
                            ,	me.unidade_venda								
                            ,	me.data_modo_preco 							
                            ,	me.margem_mercadoria 							
                            ,	me.quantidade_embalagem 						
                            ,	me.cod_fornecedor								
                            ,	me.custo_moeda_estavel							
                            ,	me.aliquota_icms 								
                            ,	me.quantidade_bonus_venda						
                            ,	me.quantidade_max_preco_promo 					
                            ,	me.valor_total_preco_promocao 					
                            ,	me.custo_contabil 								
                            ,	me.quantidade_maxima_venda 					
                            ,	me.multiplica_pontos_valor_liq 				
                            ,	me.quantidade_pontos_venda 					
                            ,	me.cod_situacao_tributaria 					
                            ,   me.data_cadastro 								
                            ,	me.data_ultima_alteracao 						
                            ,	me.cod_ncm										
                            ,	me.cod_produto_pai	
                            ,	me.cest 
                            ,   me.cfop
                            ,   me.cod_sit_trib_pis
                            ,   me.aliquota_pis
                            ,   me.cod_sit_trib_cofins
                            ,   me.aliquota_cofins
                            ,   coalesce(me.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal
                FROM            tbzanthustab_mercadoria me
                inner join      tbproduto pr on pr.pr_cdproduto = me.pr_cdproduto
                WHERE   1 = 1 
                `;
        if (this.filter.ProdutosPendentesDeIntegracao
            && this.filter.ProdutosPendentesDeIntegracao == true
            && this.filter.integracao_tipo_cd
            && this.filter.integracao_tipo_cd > 0) {
            sqlscript +=
                ` and ( 	   pr.prb_cdprodutobluesoft in (
		                                               select x.prb_cdprodutobluesoftunitario
		                                               from   tbintegracao_produto x 
		                                               where  1 = 1
		                                                 and  x.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
		                                                 and  x.integracao_status_cd = 2
		                  
		                                            )
					 or 
							   pr.prb_cdprodutobluesoft in (select xx.prb_cdprodutobluesoft 
							                       from   TbZanthustab_produto_decomposicao_insum xx
		                                            where xx.pr_cdproduto in (select ax.pr_cdproduto 
							                                               from   tbintegracao_produto ax 
							                                               where  1 = 1
							                                                 and  ax.integracao_tipo_cd = ${this.filter.integracao_tipo_cd || 20008501}
							                                                 and  ax.integracao_status_cd = 2
																			group by ax.pr_cdproduto 
																		  )
													group by  xx.prb_cdprodutobluesoft 
												)
					)
                            `;
        }
        if (this.filter.AlteracaoTributaria === "1") {
            sqlscript += ` and (    pr.prb_cdprodutobluesoft in ( select prb_cdprodutobluesoft_pk from tbprodutobluesoft where prb_dt_ultimaalteracao >= current_date - interval '5 day' ) 
                                                     or pr.prb_cdprodutobluesoft in ( select prb_cdprodutobluesoft from tbfc_regrafiscal_nfce_produto where dtlog_update >=  current_date - interval '1 day')
                                                    )
                                               and pr.pr_status = 'true'
                                `;
        }
        return sqlscript;
    }
}
exports.default = reportZanthusTabMercadoria_Select;
