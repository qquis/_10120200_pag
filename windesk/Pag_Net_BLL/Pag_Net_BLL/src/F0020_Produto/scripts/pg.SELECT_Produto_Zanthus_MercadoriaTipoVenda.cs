using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_Produto_Zanthus_MercadoriaTipoVenda
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
                SQL_POSTGRE = string.Format("select 		    z.pr_cdproduto				      " +
 				                            "                ,  pr.pr_descricao                   " + 
 				                            "                ,	z.prb_cdprodutobluesoft           " + 
                                            "                ,  x.prb_descricao                   " + 
                                            "                ,  x.prb_cdprodutobluesoftunitario   " + 
                                            "                ,  em.pre_embalagem                  " + 
 				                            "                ,	z.preg_cdbarra					  " +
                                            "                ,	z.cod_mercadoria 				  " +
		                                    "                ,  z.tab_pre_cd                      " + 
				                            "               ,	z.cod_loja                        " + 
				                            "               ,	z.controle                        " + 
				                            "               ,	z.cod_tipo_venda                  " + 
				                            "               ,	z.usuario                         " + 
				                            "               ,	z.data_cadastro                   " + 
				                            "               , 	z.data_ultima_alteracao           " + 
				                            "               ,	z.preco_unitario                  " + 
				                            "               , 	z.percentual_comissao_vendedor    " + 
				                            "               ,	z.preco_anterior                  " +
                                            " from 		TbZanthusTab_Mercadoria_Tipo_Venda   z              " + 
                                            " left join tbproduto pr on pr.pr_cdproduto = z.pr_cdproduto " + 
                                            " left join tbprodutoembalagem em on em.pr_cdproduto = pr.pr_cdproduto and em.prb_cdprodutobluesoft = z.prb_cdprodutobluesoft " + 
                                            " left join tbprodutobluesoft  x on x.prb_cdprodutobluesoft_pk = z.prb_cdprodutobluesoft " + 
                                            " where     1 = 1 " + 
                                            "" + ( filtro.pr_cdproduto != 0? " and z.pr_cdproduto = " + filtro.pr_cdproduto.ToString(): "") +  
                                            "" + ( filtro.prb_cdprodutoBlueSoft != 0? " and z.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString(): "") +
                                            "" + (filtro.preg_cdbarra.Trim() != "" ? " and z.preg_cdbarra like '%" + filtro.preg_cdbarra.ToString() + "%'" : "") + 
                                            " order by pr.pr_descricao asc, em.pre_embalagem desc "
                                            ) ;
                                            

                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.src.F0020_Produto.scripts " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }
}
