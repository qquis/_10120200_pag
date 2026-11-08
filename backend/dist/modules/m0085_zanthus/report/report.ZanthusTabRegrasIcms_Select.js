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
const tbZanthusTabRegraIcms_1 = __importDefault(require("../tbs/tbZanthusTabRegraIcms"));
const modelbase_1 = require("../../../model/modelbase");
class reportZanthusTabRegrasIcms_Select {
    constructor(filter) {
        this.filter = filter;
    }
    tblist_Get() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let listTabMercadoriaRegraIcms = [];
            try {
                let myClsBase = new modelbase_1.clsBase();
                let result = yield myClsBase.myDataBase.pag.DataGet(this.scriptSelect());
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let myItem = new tbZanthusTabRegraIcms_1.default();
                        myItem.binding(value);
                        listTabMercadoriaRegraIcms.push(myItem);
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
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `report.tab_regras_icms_select | tblist_Get`, e);
            }
            finally {
                return listTabMercadoriaRegraIcms;
            }
        });
    }
    scriptSelect() {
        let sqlscript = ``;
        sqlscript =
            ` select     a.pr_cdproduto
                        ,   a.prb_cdprodutobluesoft
                        ,   a.cod_regras_icms             as  cod_regras_icms
                        ,	a.cod_loja 
                        ,	a.descricao 
                        ,	a.prioridade 
                        ,	a.flg_registro 
                        ,	a.cod_ncm_ini                 as  cod_ncm_ini
                        ,	a.cod_ncm_fim                 as  cod_ncm_final
                        ,	a.cod_mercadoria 
                        ,	a.uf_origem 
                        ,	a.uf_destino 
                        ,	coalesce(a.aliquota,0) as aliquota
                        ,	a.cst
                        ,	a.perc_substituicao 
                        ,	coalesce(a.perc_reducao,0) as perc_reducao 
                        ,	a.flg_tipo_imposto 
                        ,	a.flg_revenda 
                        ,	a.dta_val_inicial 
                        ,	a.dta_val_final 
                        ,	a.cst_orig
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	a.data_ultima_alteracao 
                        ,	a.aliquota_interestadual 
                        ,	a.valor_imposto 
                        ,	a.tipo_lista_st 
                        ,	a.perc_reducao_st 
                        ,	a.perc_diferimento 
                        ,	a.exigibilidade_iss 
                        ,	a.flg_incentivo_fiscal_iss 
                        ,	a.tipo_documento
                        ,   a.codigo_beneficio_fiscal
                        ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                        ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                        ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                `;
        if (this.filter.ProdutosPendentesDeIntegracao
            && this.filter.ProdutosPendentesDeIntegracao === true
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
        +` UNION `
            + `
                select      pr.pr_cdproduto
                        ,   me.prb_cdprodutobluesoft
                        ,   a.cod_regras_icms             as  cod_regras_icms
                        ,	a.cod_loja 
                        ,	a.descricao 
                        ,	a.prioridade 
                        ,	a.flg_registro 
                        ,	a.cod_ncm_ini                 as  cod_ncm_ini
                        ,	a.cod_ncm_fim                 as  cod_ncm_final
                        ,	a.cod_mercadoria 
                        ,	a.uf_origem 
                        ,	a.uf_destino 
                        ,	coalesce(a.aliquota,0) as aliquota
                        ,	a.cst
                        ,	a.perc_substituicao 
                        ,	coalesce(a.perc_reducao,0) as perc_reducao 
                        ,	a.flg_tipo_imposto 
                        ,	a.flg_revenda 
                        ,	a.dta_val_inicial 
                        ,	a.dta_val_final 
                        ,	a.cst_orig
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	a.data_ultima_alteracao 
                        ,	a.aliquota_interestadual 
                        ,	a.valor_imposto 
                        ,	a.tipo_lista_st 
                        ,	a.perc_reducao_st 
                        ,	a.perc_diferimento 
                        ,	a.exigibilidade_iss 
                        ,	a.flg_incentivo_fiscal_iss 
                        ,	a.tipo_documento
                        ,   a.codigo_beneficio_fiscal
                        ,   a.cod_class_tributaria
                        ,   a.per_cred_presumido_ibs_mono
                        ,   a.per_cred_presumido_cbs_mono                        
                from 		 tbzanthustab_regra_icms           			 a
                inner join   TbZanthustab_produto_decomposicao_insum     me on me.cod_insumo = a.cod_mercadoria 
                inner join   tbproduto 						   			 pr on pr.pr_cdproduto = me.pr_cdproduto 
				where		 pr.pr_cdproduto != 0 
                
                `;
        if (this.filter.ProdutosPendentesDeIntegracao
            && this.filter.ProdutosPendentesDeIntegracao === true
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
        return sqlscript;
    }
}
exports.default = reportZanthusTabRegrasIcms_Select;
