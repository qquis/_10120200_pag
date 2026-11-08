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
class reportCbenefProduto {
    static sql(parametro) {
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
        let sql = ` select 		
                            sb.prsg_cdsubgrupo
                        ,	sb.prsg_descricao 
                        ,	gr.prg_cdgrupo
                        ,	gr.prg_descricao 
                        ,	dp.prd_cddepartamento 
                        ,	dp.prd_descricao 
                        ,   pr.pr_cdproduto
                        ,	pr.prb_cdprodutobluesoft
                        ,   pb.prb_descricao 
                        ,	case when pb.prb_status then 1 else 0 end as prb_status
                        ,   pl.prbt_icms_saida_cst
                        ,	nfce.icms_codigo_tributacao  
						,	ff.fc_figurafiscal_descricao 
                        ,   nfce.ncm_codigo

                        ,   cbenf_grupo.fc_cbenef_cd            as subgrupo_fc_cbenef_cd
                        ,   grupo_cbenef.fc_cbenef_objetivo     as cbenef_grupo_objetivo

                        ,   pb.prb_blue_fc_cbenef_cd            as prb_blue_fc_cbenef_cd
                        ,   blue_cbenef.fc_cbenef_objetivo      as cbenef_blue_objetivo



                        ,   pr.pr_pag_fc_cbenef_cd              as pr_pag_fc_cbenef_cd
                        ,   pag_cbenef.fc_cbenef_objetivo       as cbenef_pag_objetivo
               
               

                from         tbproduto pr
                inner join   tbprodutobluesoft              pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                left join    tbpessoabluesoft               ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                left join    tbfc_regrafiscal_nfce_produto  nfce on nfce.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft            
                left join    tbfc_figurafiscal_produto      rf on rf.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                left join    tbfc_figurafiscal              ff on ff.fc_figurafiscal_cd = rf.fc_figurafiscal_cd 
                left join    tbproduto_subgrupo             sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
                left join    tbproduto_grupo                gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
                left join    tbproduto_secao                sc on sc.prs_cdsecao = gr.prs_cdsecao
                left join    tbproduto_departamento         dp on dp.prd_cddepartamento = sc.prd_cddepartamento
                left join    tbprodutobluesoft_tributacao   pl on pl.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk and pl.op_cdoperacao = 2
                left join    tbprodutobluesoft_tributacao   pdr on pdr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk and pdr.op_cdoperacao = 1 and pdr.prbt_regimetributario = '${parametro.distribuica_regime_tributacao}'  and pdr.prbt_cfop = '5102'          
                left join    tbestoquecusto                 ec on ec.pr_cdproduto = pr.pr_cdproduto 

  				left join (select 		cc.fc_cbenef_cd
									,	cc.icms_codigo_tributacao
									,	ss.prsg_cdsubgrupo
							from 		tbfc_cbenef_cst cc
							inner join  tbproduto_subgrupo ss on ss.fc_cbenef_cd = cc.fc_cbenef_cd
							) cbenf_grupo on cbenf_grupo.prsg_cdsubgrupo = sb.prsg_cdsubgrupo 
									and cbenf_grupo.icms_codigo_tributacao = nfce.icms_codigo_tributacao  

                left join    tbfc_cbenef                    grupo_cbenef on grupo_cbenef.fc_cbenef_cd = cbenf_grupo.fc_cbenef_cd
                left join    tbfc_cbenef                    pag_cbenef   on pag_cbenef.fc_cbenef_cd   = pr.pr_pag_fc_cbenef_cd
                left join    tbfc_cbenef                    blue_cbenef  on blue_cbenef.fc_cbenef_cd  = pb.prb_blue_fc_cbenef_cd                                    

                where		1 = 1
                and       pb.prb_status = true

                `;
        if (parametro.filtrarcomestoque && parametro.filtrarcomestoque == 1) {
            sql += ` and coalesce(ec.ec_embalagemestoque_qtde, 0) > 0 `;
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
        sql += `${parametro.prb_cdprodutobluesoft ? ` and pb.prb_cdprodutobluesoft_pk = ${parametro.prb_cdprodutobluesoft} ` : ` `}`;
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
                sql += ` and rf.fc_figurafiscal_cd is null `;
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
        if (parametro.ComCbenefPAGFilter && parametro.ComCbenefPAGFilter == 1) {
            sql += ` and coalesce(pr.pr_pag_fc_cbenef_cd, '') != '' `;
        }
        if (parametro.cbenefpagFilter && parametro.cbenefpagFilter !== '') {
            sql += ` and UPPER(trim(pr.pr_pag_fc_cbenef_cd)) = UPPER(trim('${parametro.cbenefpagFilter}')) `;
        }
        if (parametro.SemCbenefBlueFilter && parametro.SemCbenefBlueFilter == 1) {
            sql += ` and coalesce(pb.prb_blue_fc_cbenef_cd, '') = '' `;
        }
        if (parametro.ComCbenefBlueFilter && parametro.ComCbenefBlueFilter == 1) {
            sql += ` and coalesce(pb.prb_blue_fc_cbenef_cd, '') != '' `;
        }
        if (parametro.cbenefblueFilter && parametro.cbenefblueFilter !== '') {
            sql += ` and UPPER(trim(pb.prb_blue_fc_cbenef_cd)) = UPPER(trim('${parametro.cbenefblueFilter}')) `;
        }
        if (parametro.CSTFilter && parametro.CSTFilter !== 0) {
            sql += ` and  (    coalesce(pl.prbt_icms_saida_cst,'000') = lpad('${parametro.CSTFilter}', 3, '0') 
                                or coalesce(cast(nfce.icms_codigo_tributacao as varchar(3)), '000') = lpad('${parametro.CSTFilter}', 3, '0')
                              )
                `;
        }
        sql += ` order by pb.prb_descricao asc `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let myBase = new modelbase_1.clsBase();
                result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportCbenefProduto | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportCbenefProduto;
