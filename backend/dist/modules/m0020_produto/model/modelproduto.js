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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbprodutos_1 = __importDefault(require("../tbs/tbprodutos"));
class modelproduto extends tbprodutos_1.default {
    constructor() {
        super();
    }
    ConsultarDataQuery(pr_cdproduto) {
        return __awaiter(this, void 0, void 0, function* () {
            let dataQuery = {};
            let pr_cdproduto_consultar = this.pr_cdproduto || pr_cdproduto;
            const myBase = new modelbase_1.clsBase();
            try {
                if (pr_cdproduto_consultar == null || pr_cdproduto_consultar == 0) {
                    throw new Error('Parâmetro pr_cdproduto é obrigatório para consulta.');
                }
                let sql = `select   pr.pr_cdproduto 
                                ,   pr.prb_cdprodutobluesoft
                                ,   pr.pr_descricao 
                                ,   pr.pr_embalagemestoque 
                                ,   pr.pr_embalagemcompra
                                ,   pr.pr_embalagemcompra_fator 
                                ,   pr.pr_cdbarra_principal 
                                ,   case when pr.pr_status then 1 else 0 end as pr_status
                                ,   coalescE(pr.dtlog_insert, '1900-01-01 01:01:01') as dtlog_insert
                                ,   coalesce(pr.dtlog_update, '1900-01-01 01:01:01') as dtlog_update
                                ,   coalescE(pr.dtlog_update_api, '1900-01-01 01:01:01') as dtlog_update_api
                                ,   pr.cdpessoabluesoft_fabricante 
                                ,   pr.prb_cdproduto_compra_padrao 
                                ,   pr.prsg_cdsubgrupo 
                                ,   case when coalesce(pr.pr_cesta,'false') = 'true' then 1 else 0 end as pr_cesta 
                                ,   coalesce(pr.pr_status_comercial_preco_inativo, 0) as pr_status_comercial_preco_inativo
                                ,   pb.prb_cdprodutobluesoftunitario as prb_cdprodutobluesoftunitario
                                ,   pb.prb_descricao as prb_descricao
                                ,   fp.fc_figurafiscal_cd
                                ,   fp.dtlog_insert
                                ,   fp.dtlog_update
								,	f.fc_figurafiscal_descricao
                                ,   fp.regrafiscal_nfce
                                ,   fp.fc_figurafiscal_versao 
                                ,   ps.nome_razao as fornecedor_nome_razao



                            from    tbproduto pr
                            left join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                            left join    tbpessoabluesoft               ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor                            
                            left join tbfc_figurafiscal_produto fp     on fp.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
							left join tbfc_figurafiscal f on f.fc_figurafiscal_cd = fp.fc_figurafiscal_cd
                            left join tbfc_regrafiscal_nfce_produto nfce    on nfce.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                            where   1 = 1
                            and     pr.prb_cdprodutobluesoft = ${pr_cdproduto_consultar}  `;
                const item = yield myBase.myDataBase.RecordItem(yield myBase.myDataBase.pag.DataGet(sql), 0);
                dataQuery = item;
                if (item) {
                    this.binding(item);
                    let resultEmbalagens = yield this.ConsultarEmbalagensDataQuery(this.pr_cdproduto);
                    if (resultEmbalagens && resultEmbalagens.length > 0) {
                        dataQuery.embalagens = {};
                        dataQuery.embalagens = resultEmbalagens;
                        let resultEmbalagensGtins = yield this.ConsultarEmabalagemGtinsDataQuery(this.pr_cdproduto);
                        if (resultEmbalagensGtins && resultEmbalagensGtins.length > 0) {
                            dataQuery.embalagensGtins = {};
                            dataQuery.embalagensGtins = resultEmbalagensGtins;
                        }
                    }
                    let resultPrecoLoja = yield this.ConsultarListPrecosLoja(this.prb_cdprodutobluesoft);
                    if (resultPrecoLoja && resultPrecoLoja.length > 0) {
                        dataQuery.precoLoja = {};
                        dataQuery.precoLoja = resultPrecoLoja;
                    }
                    let resultComposicao = yield this.ConsultarComposicao(this.prb_cdprodutobluesoft);
                    if (resultComposicao && resultComposicao.length > 0) {
                        dataQuery.composicao = {};
                        dataQuery.composicao = resultComposicao;
                    }
                }
                return dataQuery;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar', e);
            }
        });
    }
    ConsultarEmbalagensDataQuery(pr_cdproduto_1) {
        return __awaiter(this, arguments, void 0, function* (pr_cdproduto, nfce_produto_tipo_cd = 0) {
            let itemEmbalagens = {};
            let pr_cdproduto_consultar = this.pr_cdproduto || pr_cdproduto;
            const myBase = new modelbase_1.clsBase();
            try {
                if (pr_cdproduto_consultar == null || pr_cdproduto_consultar == 0) {
                    throw new Error('Parâmetro pr_cdproduto é obrigatório para consulta.');
                }
                let sql = `select       em.pr_cdproduto            as pr_cdproduto
                                ,       em.prb_cdprodutobluesoft   as prb_cdprodutobluesoft
                                ,       pb.prb_descricao           as prb_descricao 
                                ,       em.pre_embalagem           as pre_embalagem
                                ,       em.pre_fatorpreco          as pre_fatorpreco
                                ,       em.pre_fatorestoque        as pre_fatorestoque
                                ,       em.pre_status              as pre_status 
                                ,       em.dtlog_insert            as dtlog_insert
                                ,       em.dtlog_update            as dtlog_update
                                ,       em.dtlog_update_api        as dtlog_update_api
                                ,       em.cdbarra_principal       as cdbarra_principal  
                                ,       em.pre_embalagem_descricao as pre_embalagem_descricao
                                ,       NFCE_SUB.icms_codigo_origem
                                ,       NFCE_SUB.icms_codigo_tributacao
                                ,       NFCE_SUB.icms_aliquota
                                ,       NFCE_SUB.icms_reducao 
                                ,       NFCE_SUB.icms_aliquota_final 
                                ,       NFCE_SUB.pis_cst
                                ,       NFCE_SUB.pis_aliquota
                                ,       NFCE_SUB.cofins_cst
                                ,       NFCE_SUB.cofins_aliquota                                

								,		pb.prb_dtupdate_from_api 
								,		pb.dtlog_insert as pb_dtlog_insert
								,		pb.dtlog_update as pb_dtlog_update
                                ,       NFCE_SUB.dtlog_update as dtlog_update_nfce

                            from        tbprodutoembalagem em 
                            left join   tbprodutobluesoft  pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft 
                            LEFT JOIN   ( 
                                            SELECT   
                                                     nfce.prb_cdprodutobluesoft      
                                                  ,  nfce.icms_codigo_origem
                                                  ,  nfce.icms_codigo_tributacao
                                                  ,  nfce.icms_aliquota
                                                  ,  nfce.icms_reducao 
                                                  ,  nfce.icms_aliquota_final 
                                                  ,  nfce.pis_cst
                                                  ,  nfce.pis_aliquota
                                                  ,  nfce.cofins_cst
                                                  ,  nfce.cofins_aliquota   
                                                  ,  nfce.dtlog_update
                                                  
                                            FROM         tbfc_regrafiscal_nfce_produto nfce
                                            INNER join   tbfc_regrafiscal_nfce_produto_tipo nfce_tipo on nfce_tipo.nfce_produto_tipo_cd = nfce.nfce_produto_tipo_cd
                                            WHERE 1= 1
                                            `;
                if (nfce_produto_tipo_cd && nfce_produto_tipo_cd != 0) {
                    sql += ` and nfce.nfce_produto_tipo_cd = ${nfce_produto_tipo_cd} `;
                }
                else {
                    sql += ` and coalesce(nfce_tipo.nfce_produto_padrao_pdv_consumidor, 0) = 1 `;
                }
                sql += `                
                                        ) NFCE_SUB ON NFCE_SUB.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft
                            
                                        
                            where 1 = 1
                            and     em.pr_cdproduto = ${pr_cdproduto_consultar}  `;
                itemEmbalagens = yield myBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar embalagens', e);
            }
            finally {
                return itemEmbalagens;
            }
        });
    }
    ConsultarEmabalagemGtinsDataQuery(pr_cdproduto) {
        return __awaiter(this, void 0, void 0, function* () {
            let itemEmbalagensGtins = {};
            let pr_cdproduto_consultar = this.pr_cdproduto || pr_cdproduto;
            const myBase = new modelbase_1.clsBase();
            try {
                if (pr_cdproduto_consultar == null || pr_cdproduto_consultar == 0) {
                    throw new Error('Parâmetro pr_cdproduto é obrigatório para consulta.');
                }
                let sql = `select 		m.pr_cdproduto
                                    ,	m.prb_cdprodutobluesoft
                                    ,	m.pre_embalagem_descricao 
                                    ,	g.preg_cdbarra 
                                    , 	m.pre_embalagem 
                            from 		tbprodutoembalagem_gtins g
                            inner join  tbprodutoembalagem m on m.pr_cdproduto = g.pr_cdproduto 
                                            and m.prb_cdprodutobluesoft = g.prb_cdprodutobluesoft
                            where 1 = 1
                            and     m.pr_cdproduto = ${pr_cdproduto_consultar}  `;
                itemEmbalagensGtins = yield myBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar embalagens', e);
            }
            finally {
                return itemEmbalagensGtins;
            }
        });
    }
    ConsultarListPrecosLoja(pr_cdproduto) {
        return __awaiter(this, void 0, void 0, function* () {
            let itemPrecoList = {};
            let pr_cdproduto_consultar = this.pr_cdproduto || pr_cdproduto;
            const myBase = new modelbase_1.clsBase();
            try {
                if (pr_cdproduto_consultar == null || pr_cdproduto_consultar == 0) {
                    throw new Error('Parâmetro pr_cdproduto é obrigatório para consulta.');
                }
                let sql = `select 			t.tab_pre_descricao
                                        , 	x.prb_cdprodutobluesoft 
                                        ,	x.pre_embalagem 
                                        ,	x.prc_valor 
                            from 			tbpreco_aplicacao x 
                            left join 		tbtabela_preco t on t.tab_pre_cd = x.tab_pre_cd 
                            where x.prb_cdprodutobluesoft = ${pr_cdproduto_consultar}  `;
                itemPrecoList = yield myBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar embalagens', e);
            }
            finally {
                return itemPrecoList;
            }
        });
    }
    ConsultarComposicao(prb_cdprodutobluesoft_1) {
        return __awaiter(this, arguments, void 0, function* (prb_cdprodutobluesoft, nfce_produto_tipo_cd = 0) {
            let listitemComposicao = [];
            try {
                const myBase = new modelbase_1.clsBase();
                let sql = `select 	c.prb_cdprodutobluesoft_unitario
                        , 		c.prb_cdprodutobluesoft 
                        ,       pb.prb_descricao 
                        ,		pb.prb_cdbarra_principal 
                        ,		c.prc_qtde
                        ,		c.prc_percentual_composicao
                        ,		c.prc_percentual_composicao_qtde 
                        ,		c.prc_composicao_qtde_total 
                        ,		c.dtlog_insert
                        ,		c.dtlog_update 
                        ,		f.fc_figurafiscal_cd
                        ,		f.regrafiscal_nfce 
                        from 		tbproduto_composicao c
                        left join   tbfc_figurafiscal_produto f on f.prb_cdprodutobluesoft = c.prb_cdprodutobluesoft 
                        left join  	tbfc_regrafiscal_nfce_produto nfce on nfce.prb_cdprodutobluesoft = c.prb_cdprodutobluesoft
                        left join   tbfc_regrafiscal_nfce_produto_tipo nfce_tipo on nfce_tipo.nfce_produto_tipo_cd = nfce.nfce_produto_tipo_cd
                        left join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = c.prb_cdprodutobluesoft 
                        where 1 = 1
                        and         c.prb_cdprodutobluesoft_unitario = ${prb_cdprodutobluesoft}
                `;
                if (nfce_produto_tipo_cd && nfce_produto_tipo_cd != 0) {
                    sql += ` and nfce.nfce_produto_tipo_cd = ${nfce_produto_tipo_cd} `;
                }
                else {
                    sql += ` and coalesce(nfce_tipo.nfce_produto_padrao_pdv_consumidor, 0) = 1 `;
                }
                listitemComposicao = yield myBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar composição', e);
            }
            finally {
                return listitemComposicao;
            }
        });
    }
}
exports.default = modelproduto;
