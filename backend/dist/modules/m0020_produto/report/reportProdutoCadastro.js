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
class reportProdutoCadastro {
    static sql() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
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
                ,           pr.pr_descricao 
                ,           pr.prb_cdprodutobluesoft 

                ,           pr.pr_embalagemestoque 
                ,           pr.pr_embalagemcompra 
                ,           pr.pr_embalagemcompra_fator

                ,           pb.prb_descricao 
                ,           pb.prb_cdbarra_principal 
                ,           pb.prb_dt_cadastro 
                ,           pb.prb_dt_ultimaalteracao 
                ,           case when pb.prb_vendaexterna then 1 else 0 end as prb_vendaexterna
                ,           case when pb.prb_status then 1 else 0 end as prb_status
                ,           pb.prb_cdpessoabluesoft_fornecedor as fornecedor_cdpessoabluesoft
                ,           ps.nome_razao as fornecedor_nome_razao 
                ,           coalesce(ff.fc_figurafiscal_cd,0)       as fc_figurafiscal_cd
                ,           coalesce(ff.fc_figurafiscal_versao,0)   as fc_figurafiscal_versao
                ,           coalesce(ff.fc_figurafiscal_descricao, '') as fc_figurafiscal_descricao
                ,           sb.prsg_cdsubgrupo 
                ,           sb.prsg_descricao 
                ,           gr.prg_cdgrupo 
                ,           gr.prg_descricao 
                ,           sc.prs_cdsecao 
                ,           sc.prs_descricao 
                ,           dp.prd_cddepartamento 
                ,           dp.prd_descricao
            from         tbproduto pr
            inner join   tbprodutobluesoft              pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
            left join    tbpessoabluesoft               ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
            left join    tbfc_figurafiscal_produto      rf on rf.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
            left join    tbfc_figurafiscal              ff on ff.fc_figurafiscal_cd = rf.fc_figurafiscal_cd and ff.fc_figurafiscal_versao = rf.fc_figurafiscal_versao
            left join    tbproduto_subgrupo             sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
            left join    tbproduto_grupo                gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
            left join    tbproduto_secao                sc on sc.prs_cdsecao = gr.prs_cdsecao
            left join    tbproduto_departamento         dp on dp.prd_cddepartamento = sc.prd_cddepartamento
            where      1 = 1
            
            `;
            /* CODIGO DO PRODUTO */
            sql += `${parametro.pr_descricao ? ` and pr.pr_descricao like '%${parametro.pr_descricao}%' ` : ` `}`;
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
                        and pr.prb_cdprodutobluesoft in (   select      i.prb_cdprodutobluesoft 
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
            sql += ` order by pr.prb_cdprodutobluesoft asc  `;
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
                modelbase_1.clsTools.PagErrorException('m0020_produto', 'reportProdutoOperacional', e);
            }
            finally {
                return report;
            }
        });
    }
}
exports.default = reportProdutoCadastro;
