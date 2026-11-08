using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_ProdutoEmbalagemGtins
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
                                   " SELECT 		                                                                                                                " + 
			                       "            coalesce(g.dtlog_insert,'1900-01-01') as dtlog_insert                                                               " + 
		                           "         ,	coalesce(g.dtlog_update,'1900-01-01') as dtlog_update                                                               " + 
		                           "         ,	coalesce(g.dtlog_update_api,'1900-01-01') as dtlog_update_api                                                       " + 
		                           "         ,	g.pr_cdproduto                                                                                                      " + 
		                           "         ,	g.prb_cdprodutobluesoft                                                                                             " + 
		                           "         ,	g.pre_embalagem                                                                                                     " + 
		                           "         ,	g.preg_cdbarra                                                                                                      " + 
		                           "         ,	coalesce(g.preg_status,'false')                                                                                     " + 
		                           "         ,	case when coalesce(g.preg_status,'false') = 'true' then 'Ativo' else 'inativo' end as label_preg_status             " + 
                                   " FROM 		Tbprodutoembalagem_gtins g                                                                                          " + 
                                   " left join  tbprodutoembalagem em on em.pr_cdproduto = g.pr_cdproduto and em.prb_cdprodutobluesoft = g.prb_cdprodutobluesoft   " + 
                                   " where 1 = 1 " +
                                   (filtro.pr_cdproduto !=0? " and em.pr_cdproduto = " + filtro.pr_cdproduto.ToString() : "") +
                                   (filtro.prb_cdprodutoBlueSoft != 0? " AND em.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString() : "").ToString() ;

                 SQL_POSTGRE += " ORDER BY em.pre_embalagem desc, em.pre_embalagem_descricao asc ";

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
