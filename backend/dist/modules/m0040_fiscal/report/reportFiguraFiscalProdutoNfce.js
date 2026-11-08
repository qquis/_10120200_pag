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
class reportFiguraFiscalProdutoNfce {
    static sql() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            if (!parametro.distribuica_regime_tributacao) {
                parametro.distribuica_regime_tributacao = 'N';
            }
            if (parametro.filtrar_entrada_saida && parametro.filtrar_entrada_saida == 1) {
                if (parametro.filtrar_entrada_saida_numero_mes && parametro.filtrar_entrada_saida_numero_mes > 0) {
                    const data_final = new Date();
                    const data_inicial = new Date();
                    data_inicial.setMonth(data_final.getMonth() - parametro.filtrar_entrada_saida_numero_mes);
                    parametro.filtrar_entrada_saida_data_inicial = data_inicial;
                    parametro.filtrar_entrada_saida_data_final = data_final;
                }
                if (parametro.filtrar_entrada_saida_data_inicial && parametro.filtrar_entrada_saida_data_final) {
                    parametro.filtrar_entrada_saida = 1;
                }
                else {
                    parametro.filtrar_entrada_saida = 0;
                }
            }
            let sql = ` `;
            sql = ` select     pr.pr_cdproduto 
                        ,   pr.pr_descricao 
                        ,   pb.prb_descricao_fiscal 
                        ,   pr.prb_cdprodutobluesoft
                        ,   pb.prb_cdprodutobluesoft_pk
                        ,   pb.prb_descricao

                        ,   pr.pr_embalagemestoque 
                        ,   pr.pr_embalagemcompra 
                        ,   pr.pr_embalagemcompra_fator

                        ,   pb.prb_descricao 
                        ,   pb.prb_cdbarra_principal 
                        ,   pb.prb_dt_cadastro 
                        ,   pb.prb_dt_ultimaalteracao 
                        ,   case when pb.prb_vendaexterna then 1 else 0 end as prb_vendaexterna
                        ,   case when pb.prb_status then 1 else 0 end as prb_status
                        ,   pb.prb_cdpessoabluesoft_fornecedor as fornecedor_cdpessoabluesoft
                        ,   ps.nome_razao as fornecedor_nome_razao 
                ,           coalesce(ff.fc_figurafiscal_cd,0)       as fc_figurafiscal_cd
                ,           coalesce(ff.fc_figurafiscal_versao,0)   as fc_figurafiscal_versao
                ,           coalesce(ff.fc_figurafiscal_descricao, '') as fc_figurafiscal_descricao
                ,           case when coalesce(nfce.prb_cdprodutobluesoft, 0) = 0 then 'NAO' else 'SIM' end as status_regra_nfce                         
                        ,   coalesce(nfce.prb_cdprodutobluesoft, 0) 
                        ,   coalesce(nfce.cfop ,0) 
                        ,   cast(nfce.icms_codigo_origem as varchar(1)) ||  cast(nfce.icms_codigo_tributacao as varchar(2)) as cst

                        
	            ,			nfce.icms_codigo_icms as icms_cd
				,			icms.icms_descricao 
				,			nfce.icms_reducao
				,			nfce.icms_aliquota

				,			nfce.cofins_cst
				,			nfce.cofins_aliquota
				,			nfce.pis_cst
				,			nfce.pis_aliquota
				,			nfce.ncm_codigo
				,			nfce.ncm_excecao
				,			nfce.data_hora_geracao 
 
				,			nfce.codigo_figura_regra_fiscal
				,			nfce.codigo_regra_fiscal
				,			nfce.rt_codigo_cst_ibs_cbs
				,			nfce.rt_codigo_class_trib_ibs_cbs
				,			nfce.ibs_cd
                ,			ibs.ibs_descricao 
				,			nfce.ibs_mun_aliquota
				,			nfce.ibs_mun_percentual_reducao 				
				,			nfce.ibs_aliquota
				,			nfce.ibs_percentual_reducao
				,			nfce.cbs_cd
				,			cbs.cbs_descricao 
				
				,			nfce.cbs_aliquota
				,			nfce.cbs_percentual_reducao














                        ,   nfce_count.qtde_nfce as qtde_nfce
                    from        tbprodutobluesoft pb 
                    inner join  tbproduto                           pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario 
                    left join   tbfc_regrafiscal_nfce_produto     nfce on nfce.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk
                    left join    tbfc_regrafiscal_nfce_produto_tipo nfce_tipo on nfce_tipo.nfce_produto_tipo_cd = nfce.nfce_produto_tipo_cd 
                    left join    tbfc_icms						icms on icms.icms_cd = nfce.icms_codigo_icms
                    left join    tbfc_ibs                       ibs  on ibs.ibs_cd = nfce.ibs_Cd 
                    left join    tbfc_cbs                       cbs on cbs.cbs_cd = nfce.cbs_cd                     
                    left join   tbpessoabluesoft                    ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                    left join   tbproduto_subgrupo                  sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
                    left join   tbproduto_grupo                     gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
                    left join   tbproduto_secao                     sc on sc.prs_cdsecao = gr.prs_cdsecao
                    left join   tbproduto_departamento              dp on dp.prd_cddepartamento = sc.prd_cddepartamento
                    left join   tbfc_figurafiscal_produto           rf on rf.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                    left join   tbfc_figurafiscal                   ff on ff.fc_figurafiscal_cd = rf.fc_figurafiscal_cd 
                    left join   ( select prb_cdprodutobluesoft
                                , count(*) as qtde_nfce 
                                  from tbfc_regrafiscal_nfce_produto 
                                  group by prb_cdprodutobluesoft
                            ) as nfce_count on nfce_count.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk
            where       1 = 1 
            `;
            if (parametro.apenasunitario && parametro.apenasunitario == 1) {
                sql += ` and pb.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario `;
            }
            if (parametro.nfce_produto_tipo_cd && parametro.nfce_produto_tipo_cd > 0) {
                sql += ` and nfce.nfce_produto_tipo_cd = ${parametro.nfce_produto_tipo_cd} `;
            }
            if (parametro.filtrarComRegraNfce && parametro.filtrarComRegraNfce == "S") {
                sql += ` and coalesce(nfce.prb_cdprodutobluesoft, 0) != 0 `;
            }
            if (parametro.filtrarComRegraNfce && parametro.filtrarComRegraNfce == "N") {
                sql += ` and coalesce(nfce.prb_cdprodutobluesoft, 0) = 0 `;
            }
            /* CODIGO DO PRODUTO */
            sql += `${parametro.pr_descricao ? ` and pr.pr_descricao like '%${parametro.pr_descricao}%' ` : ` `}`;
            sql += `${parametro.prb_descricao_fiscal ? ` and pb.prb_descricao_fiscal like '%${parametro.prb_descricao_fiscal}%' ` : ` `}`;
            /* CODIGO DO PRODUTO */
            sql += `${parametro.pr_cdproduto ? ` and pr.pr_cdproduto = ${parametro.pr_cdproduto} ` : ` `}`;
            /* CODIGO DO PRODUTO */
            sql += `${parametro.prb_cdprodutobluesoft ? ` and pb.prb_cdprodutobluesoftunitario = ${parametro.prb_cdprodutobluesoft} ` : ` `}`;
            if (parametro.filter_prb_dt_cadastro && parametro.filter_prb_dt_cadastro > 0) {
                if (parametro.filtra_prb_dt_cadastro_ini) {
                    sql += ` and pb.prb_dt_cadastro >= '${parametro.filtra_prb_dt_cadastro_ini}' `;
                }
                if (parametro.filtra_prb_dt_cadastro_fim) {
                    sql += ` and pb.prb_dt_cadastro <= '${parametro.filtra_prb_dt_cadastro_fim}' `;
                }
            }
            sql += `${parametro.filtrar_vendaexterna && parametro.filtrar_vendaexterna === 'SIM' ? ` and pb.prb_vendaexterna = 'true' ` : ` `}`;
            sql += `${parametro.filtrar_vendaexterna && parametro.filtrar_vendaexterna === 'NAO' ? ` and pb.prb_vendaexterna = 'false' ` : ` `}`;
            /* STATUS BLUESOFT */
            sql += `
                ${parametro.filtrar_status_bluesoft && parametro.filtrar_status_bluesoft === 'ATIVO' ? ` and pb.prb_status = 'true' ` : ` `}
                ${parametro.filtrar_status_bluesoft && parametro.filtrar_status_bluesoft === 'INATIVO' ? ` and pb.prb_status = 'false' ` : ` `}
            `;
            sql += `${parametro.prd_cddepartamento && parametro.prd_cddepartamento !== 0 ? ` and dp.prd_cddepartamento = ${parametro.prd_cddepartamento} ` : ` `}`;
            sql += `${parametro.prs_cdsecao && parametro.prs_cdsecao !== 0 ? ` and sc.prs_cdsecao = ${parametro.prs_cdsecao} ` : ` `}`;
            sql += `${parametro.prg_cdgrupo && parametro.prg_cdgrupo !== 0 ? ` and gr.prg_cdgrupo = ${parametro.prg_cdgrupo} ` : ` `}`;
            sql += `${parametro.prsg_cdsubgrupo && parametro.prsg_cdsubgrupo !== 0 ? ` and sb.prsg_cdsubgrupo = ${parametro.prsg_cdsubgrupo} ` : ` `}`;
            /* ENTRADA */
            if (parametro.filtrar_entrada_saida && parametro.filtrar_entrada_saida == 1 && parametro.filtrar_entrada_saida_data_inicial && parametro.filtrar_entrada_saida_data_final) {
                sql += `
                        and pr.prb_cdprodutobluesoft ${parametro.filtrar_entrada_saida_negativo && parametro.filtrar_entrada_saida_negativo == 1 ? 'not' : ''} in (   select      i.prb_cdprodutobluesoft 
                                                    from        tbdocumentofiscalitem I 
                                                    INNER JOIN  tbdocumentofiscal     n on n.df_nf_seq_blue = i.df_nf_seq_blue
                                                    where       coalesce(n.df_data_cancelamento, '1900-01-01') = '1900-01-01'
                                                    and         coalesce(df_cdpessoabluesoft_cancelamento,0) = 0 
                                                    and         n.df_data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(parametro.filtrar_entrada_saida_data_inicial, 'YYYY-MM-DD')}'
                                                    and         n.df_data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(parametro.filtrar_entrada_saida_data_final, 'YYYY-MM-DD')}'  
                                                    ${parametro.filtrar_entrada_saida_tipo === 'ENTRADA' ? ` and n.df_entrada_saida = 'E' ` : ` `}
                                                    ${parametro.filtrar_entrada_saida_tipo === 'SAIDA' ? ` and n.df_entrada_saida = 'S'` : ``}
                                                    group by    i.prb_cdprodutobluesoft
                                                                )

                        `;
            }
            /* FORNECEDOR */
            sql += `${parametro.fornecedor_razao_social ? ` and ps.nome_razao ilike '%${parametro.fornecedor_razao_social.replace("'", "")}%' ` : ` `}`;
            if (parametro.figurafiscalassociada && parametro.figurafiscalassociada !== 'T') {
                if (parametro.figurafiscalassociada === 'S') {
                    sql += ` and coalesce(ff.fc_figurafiscal_descricao, '') != '' `;
                    if (parametro.figurafiscal && parametro.figurafiscal !== '') {
                        sql += ` and coalesce(ff.fc_figurafiscal_descricao, '') like '%${parametro.figurafiscal}%' `;
                    }
                }
                else if (parametro.figurafiscalassociada === 'N') {
                    sql += ` and coalesce(ff.fc_figurafiscal_descricao, '') = '' `;
                }
            }
            if (parametro.ncm && parametro.ncm !== '') {
                sql += ` and ( pl.prbt_ncm = '${parametro.ncm.replace("'", "")}' or pdr.prbt_ncm = '${parametro.ncm.replace("'", "")}' ) `;
            }
            if (parametro.operacaoVisualizar && parametro.operacaoVisualizar !== '') {
                if (parametro.operacaoVisualizar === '1') {
                    if (parametro.ncm && parametro.ncm !== '') {
                        sql += ` and pdr.prbt_ncm like '%${parametro.ncm.replace("'", "")}%'`;
                    }
                    if (parametro.cest && parametro.cest !== '') {
                        sql += ` and pdr.prbt_cest like '%${parametro.cest.replace("'", "")}%'`;
                    }
                }
                if (parametro.operacaoVisualizar === '2') {
                    if (parametro.ncm && parametro.ncm !== '') {
                        sql += ` and pl.prbt_ncm like '%${parametro.ncm.replace("'", "")}%'`;
                    }
                    if (parametro.cest && parametro.cest !== '') {
                        sql += ` and pl.prbt_cest like '%${parametro.cest.replace("'", "")}%'`;
                    }
                }
            }
            sql += ` order by pr.pr_descricao asc  `;
            console.log(sql);
            return sql;
        });
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let report = {};
            try {
                report = yield myBase.myDataBase.pag.DataGet(yield this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('m0040_fiscal', 'reportFiguraFiscalProduto', e);
            }
            finally {
                return report;
            }
        });
    }
}
exports.default = reportFiguraFiscalProdutoNfce;
