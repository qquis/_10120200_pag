using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0021_ProdutoBluesoft.scripts
{
    public class report_SELECT_ProdutoBlueSoftTributacao
    {
        private static string _VERSION() { return ""; }
        public static string Get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
                ,  interfaces.iF0021_ProdutoBlueSoft_filter filtro
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("	select 	                                                " + 	
                    			            "             	tr.dtlog_insert	                            " + 
                                            "             ,	tr.prb_dtupdate_from_api	                " + 
			                                "             ,	tr.dtlog_update	                            " + 
                                            "             , tr.op_cdoperacao	                        " + 
			                                "             ,	op.op_descricao                             " + 
			                                "             ,	tr.prb_cdprodutobluesoft	                " + 
                                            "             , prb.prb_embalagemestoque                    " +
                                            "             ,	tr.prbt_regimetributario	                " + 
                                            "             , case tr.prbt_regimetributario               " + 
                                            "                 when 'C' then 'CONSUMIDOR'                " +
                                            "                 when 'S' then 'SIMPLES NACIONAL'          " +
                                            "                 when 'N' then 'REGIME NORMAL'             " +
                                            "                 when 'X' then 'OUTRO/LOJA'                " +
                                            "               end as label_prbt_regimetributario          " +
                                            "             , prb.prb_descricao                           " +
                                            "             ,	tr.prbt_regrafiscal	                        " + 
			                                "             ,	tr.prbt_regrafiscal_versao	                " + 

			                                "             ,	tr.prbt_cfop	                            " + 
			                                "             ,	tr.prbt_pis_entrada_cst	                    " + 
			                                "             ,	tr.prbt_pis_entrada_aliquota	            " + 
			                                "             ,	tr.prbt_pis_saida_cst	                    " + 
			                                "             ,	tr.prbt_pis_saida_aliquota	                " + 
			                                "             ,	tr.prbt_cofins_entrada_cst	                " + 
			                                "             ,	tr.prbt_cofins_entrada_aliquota	            " + 
			                                "             ,	tr.prbt_cofins_saida_cst	                " + 
			                                "             ,	tr.prbt_cofins_saida_aliquota	            " + 
			                                "             ,	tr.prbt_icms_saida_cst	                    " + 
			                                "             ,	tr.prbt_icms_entrada_cst	                " + 
			                                "             ,	tr.prbt_icms_aliquota_interna	            " + 
			                                "             ,	tr.prbt_icms_reducao	                    " + 
			                                "             ,	tr.prbt_ncm	                                " + 
			                                "             ,	tr.prbt_cest	                            " + 
			                                "             ,	tr.prbt_st_iva	                            " + 

			                                "             ,	tr.prbt_icms_entrada_aliquota_interna	    " + 
			                                "             ,	tr.prbt_icms_entrada_reducao	            " + 
			                                "             ,	tr.prbt_icms_revenda_cst	                " + 
			                                "             ,	tr.prbt_icms_revenda_aliquota_interna	    " + 
			                                "             ,	tr.prbt_icms_revenda_reducao                " + 
                                            " from 			tbprodutobluesoft_tributacao tr             " + 
                                            " inner join    tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = tr.prb_cdprodutobluesoft " + 
                                            " left join 	tboperacao op on op.op_cdoperacao = tr.op_cdoperacao " + 
                                            " left join     tbproduto pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoft_pk"  + 
                                            " where     1 = 1 " +
                                            "" + (filtro.pr_cdproduto != 0 ? " and pr.pr_cdproduto = " + filtro.pr_cdproduto.ToString() : "") +
                                            "" + (filtro.prb_cdprodutoBlueSoft != 0 ? " and prb.prb_cdprodutobluesoft_pk = " + filtro.prb_cdprodutoBlueSoft.ToString() : "") +
                                            "" + (filtro.prb_descricao != "" ? " and prb.prb_descricao like '%" + filtro.prb_descricao.ToString() + "%'" : "")
                                            );
                if ( filtro.Status_Ativo && !filtro.Status_Inativo)
                    SQL_POSTGRE += " and prb.pr_status = 'true' ";

                if ( !filtro.Status_Ativo && filtro.Status_Inativo)
                    SQL_POSTGRE += " and prb.pr_status = 'false' ";

                if (filtro.Seleciona_Data_Cadastro)
                {
                    SQL_POSTGRE += " and prb.prb_dt_cadastro >= '" + filtro.prb_dt_cadastro_ini.ToString("yyyy-MM-dd") + "' ";
                    SQL_POSTGRE += " and prb.prb_dt_cadastro <= '" + filtro.prb_dt_cadastro_fim.ToString("yyyy-MM-dd") + "' ";
                }

                if (filtro.prbg_cdbarra_pk != "")
                    SQL_POSTGRE += " and prb.prb_cdprodutobluesoft_pk in ( " + 
                                   "                select       xu.prb_cdprodutobluesoftunitario " + 
                                   "                from         tbprodutobluesoft_gtins cb " + 
                                   "                inner join   tbprodutobluesoft xu on xu.prb_cdprodutobluesoft_pk = cb.prb_cdprodutobluesoft " + 
                                   "                where        1 = 1 " +
                                   "                  and        cb.prbg_cdbarra_pk like '%" + filtro.prbg_cdbarra_pk.ToString().Trim() + "%' " +
                                   "                group by xu.prb_cdprodutobluesoftunitario ) ";


                SQL_POSTGRE += " ORDER BY prb.prb_descricao, prb_descricao asc ";

                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.src.F0020_Produto.scripts.report_SELECT_Produto " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }
}
