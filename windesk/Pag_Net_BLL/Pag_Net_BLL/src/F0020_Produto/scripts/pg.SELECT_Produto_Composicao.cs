using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_ProdutoComposicao
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
                SQL_POSTGRE =      "            select      pr.pr_cdproduto " + 
                                   "                    , 	cp.prbc_bluesoft_seq     " +
		                           "                    ,	cp.prb_cdprodutobluesoft_unitario     " + 
		                           "                    ,	cp.prb_cdprodutobluesoft    " + 
                                   "                    ,   b.prb_descricao " + 
                                   "                    ,   b.prb_cdprodutobluesoftunitario " + 
		                           "                    ,	cp.prc_qtde    " + 
		                           "                    ,	cp.prc_percentual_composicao    " + 
		                           "                    ,	cp.dtlog_insert    " + 
		                           "                    ,	cp.dtlog_update    " + 
		                           "                    ,	cp.dtlog_update_api     " + 
		                           "                    ,	cp.prc_percentual_composicao_qtde    " +
                                   "                    ,	cp.prc_composicao_qtde_total     " +
                                   "                    ,   coalesce(cp.dtlog_insert, '1900-01-01') as dtlog_insert " +
                                   "                    ,   coalesce(cp.dtlog_update, '1900-01-01') as dtlog_update " +
                                   "                    ,   coalesce(cp.dtlog_update_api, '1900-01-01') as  dtlog_update_api" + 
                                   "  from 		 tbproduto_composicao   cp " + 
                                   "  inner join tbproduto              pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario " + 
                                   "  left  join tbprodutobluesoft      b on b.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft " + 
                                   " where 1 = 1 " +
                                   (filtro.pr_cdproduto !=0? " and pr.pr_cdproduto = " + filtro.pr_cdproduto.ToString() : "") +
                                   (filtro.prb_cdprodutoBlueSoft != 0? " AND pr.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString() : "").ToString() ;

                 //SQL_POSTGRE += " ORDER BY em.pre_embalagem desc, em.pre_embalagem_descricao asc ";

                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.src.F0020_Produto.scripts.report_SELECT_ProdutoComposicao " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }
}
