using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace Pag_Net.src.F0020_Produto.scripts
//{
//    public class report_ProdutoIntegracao
//    {
//        private static string _VERSION() { return "f0020_60_1012003_report_produtoIntegracao"; }
//        public static string Get(
//                   Pag_Net.Models.TbSysUserInfo MyConnect
//                ,  interfaces.iF0020_Produto_filter filtro
     

//               )
//        {

//            string SQL_POSTGRE = "";

//            try
//            {
//                SQL_POSTGRE = string.Format("Select * " + 
//                                                "FROM " + _VERSION() 
//                                                + "(   " +
//                                                  "   vpr_cdproduto:= " + filtro.pr_cdproduto.ToString() +
//                                                  " , vprb_cdprodutobluesoftunitario:=  " + filtro.prb_cdprodutoBluesfotUnitario.ToString() +
//                                                  " , vprb_cdprodutobluesoft:= " + filtro.prb_cdprodutoBlueSoft.ToString() + 
//                                                   "   )") ;
//                return SQL_POSTGRE;
//            }
//            catch (Exception Ex)
//            {
//                throw new Exception("Pag_Net.src.F0020_Produto.scripts " + Environment.NewLine +
//                                    "-------------------------------------------------------------" + Environment.NewLine +
//                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
//                                    "-------------------------------------------------------------" + Environment.NewLine +
//                                    "Erro Message: " + Ex.Message);
//            }

//        }
//    }
//}
