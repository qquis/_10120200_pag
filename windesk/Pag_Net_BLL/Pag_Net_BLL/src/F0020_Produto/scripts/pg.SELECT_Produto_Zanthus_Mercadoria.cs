using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.scripts
{
    public class report_SELECT_Produto_Zanthus_Mercadoria
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
                SQL_POSTGRE = string.Format("select 		    z.pr_cdproduto				    " +
 				                            "                ,  pr.pr_descricao                 " + 
 				                            "                ,	z.prb_cdprodutobluesoft         " + 
                                            "                ,  x.prb_descricao                 " + 
                                            "                ,  x.prb_cdprodutobluesoftunitario " + 
                                            "                ,  em.pre_embalagem                " + 
 				                            "                ,	z.preg_cdbarra					" +
                                            "                ,	z.cod_mercadoria 					" +
                                            "                ,	z.descricao 		                " + 		
				                            "                ,	z.cod_loja 						" + 			
				                            "                ,	z.controle 						" + 			
			
	
				                            "                ,	z.desc_abr                        " + 
				                            "                ,	z.cod_departamento                " + 
				                            "                ,	z.COD_TRIBUTACAO_MERCADORIA       " + 
				                            "                ,	z.COD_TECLA                       " + 
				                            "                ,	z.PERCENTUAL_DESC_VENDA           " + 
				                            "                ,	z.PERMISSAO_VENDA                 " + 
				                            "                ,	z.PERCENTUAL_REDUZ_B_CALCULO      " + 
				                            "                ,	z.INDICA_MERC_PESO_VARIAVEL       " + 
				                            "                ,	z.CUSTO_UNITARIO                  " + 
				                            "                ,	z.GRUPO_GARANTIA	                " + 
				                            "                ,	z.FATOR_SEGURANCA_VENDA_ESTOQUE   " + 
				                            "                ,	z.UNIDADE_VENDA		            " + 
				                            "                ,	z.DATA_MODO_PRECO		            " + 
				                            "                ,	z.MARGEM_MERCADORIA	            " + 
				                            "                ,	z.QUANTIDADE_EMBALAGEM		    " + 
				                            "                ,	z.COD_FORNECEDOR                  " + 
				                            "                ,	z.CUSTO_MOEDA_ESTAVEL             " + 
				                            "                ,	z.ALIQUOTA_ICMS	                " + 
				                            "                ,	z.QUANTIDADE_BONUS_VENDA	        " + 
				                            "                ,	z.QUANTIDADE_MAX_PRECO_PROMO		" + 
				                            "                ,	z.VALOR_TOTAL_PRECO_PROMOCAO		" + 
				                            "                ,	z.CUSTO_CONTABIL					" + 
				                            "                ,	z.QUANTIDADE_MAXIMA_VENDA			" + 
				                            "                ,	z.MULTIPLICA_PONTOS_VALOR_LIQ		" + 
				                            "                ,	z.QUANTIDADE_PONTOS_VENDA	        " + 
				                            "                ,	z.COD_NCM                         " + 
				                            "                ,	z.CEST                            " + 
				                            "                ,	z.COD_SITUACAO_TRIBUTARIA         " + 
				                            "                ,	z.DATA_CADASTRO                   " + 
				                            "                ,	z.DATA_ULTIMA_ALTERACAO           " + 
                                            " from 		TbZanthusTab_Mercadoria   z              " + 
                                            " left join tbproduto pr on pr.pr_cdproduto = z.pr_cdproduto " + 
                                            " left join tbprodutoembalagem em on em.pr_cdproduto = pr.pr_cdproduto and em.prb_cdprodutobluesoft = z.prb_cdprodutobluesoft " + 
                                            " left join tbprodutobluesoft  x on x.prb_cdprodutobluesoft_pk = z.prb_cdprodutobluesoft " + 
                                            " where     1 = 1 " + 
                                            "" + ( filtro.pr_cdproduto != 0? " and z.pr_cdproduto = " + filtro.pr_cdproduto.ToString(): "") +  
                                            "" + ( filtro.prb_cdprodutoBlueSoft != 0? " and z.prb_cdprodutobluesoft = " + filtro.prb_cdprodutoBlueSoft.ToString(): "") +
                                            "" + (filtro.preg_cdbarra.Trim() != "" ? " z.preg_cdbarra like '%" + filtro.preg_cdbarra.ToString() + "%'" : "") +
                                            "" + (filtro.pr_descricao != "" ? " and pr.pr_descricao like '%" + filtro.pr_descricao.ToString() + "%'" : "") +
                                            "" + (filtro.prb_descricao != "" ? " and x.prb_descricao like '%" + filtro.prb_descricao.ToString() + "%'" : "") + 
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
