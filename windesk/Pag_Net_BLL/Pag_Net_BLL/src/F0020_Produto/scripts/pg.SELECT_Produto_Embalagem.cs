using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_ProdutoEmbalagem
    {
        private static string _VERSION() { return ""; }
        public static string Get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
                ,  interfaces.iF0020_Produto_filter filtro
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE =
                                   " SELECT  em.pr_cdproduto " +
                                   "       , em.prb_cdprodutobluesoft  " +
                                   "       , prb.prb_descricao " +
                                   "       , em.pre_embalagem " +
                                   "       , em.pre_fatorestoque " +
                                   "       , em.pre_fatorpreco " +
                                   "       , em.pre_status " +
                                   "       , coalesce(em.dtlog_insert, '1900-01-01') as dtlog_insert " +
                                   "       , coalesce(em.dtlog_update, '1900-01-01') as dtlog_update " +
                                   "       , coalesce(em.dtlog_update_api, '1900-01-01') as  dtlog_update_api" +
                                   "       , em.cdbarra_principal " +
                                   "       , em.pre_embalagem_descricao " +
                                   "       , case when prb.prb_status = 'true' then 'Ativo' else 'Inativo' end as label_prb_status " +
                                   "       , prb.prb_embalagemestoque " + 
                                   " from         tbprodutoembalagem em " +
                                   " left join    tbprodutobluesoft  prb  on prb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft " +
                                   " where 1 = 1 " +
                                   (filtro.pr_cdproduto !=0? " and em.pr_cdproduto = " + filtro.pr_cdproduto.ToString() : "") +
                                   (filtro.prb_cdprodutoBlueSoft != 0? " AND em.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString() : "").ToString() ;

                 SQL_POSTGRE += " ORDER BY em.pre_embalagem desc, em.pre_embalagem_descricao asc , prb.prb_descricao asc ";

                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.src.F0020_Produto.scripts.report_SELECT_ProdutoEmbalagem " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }
}
