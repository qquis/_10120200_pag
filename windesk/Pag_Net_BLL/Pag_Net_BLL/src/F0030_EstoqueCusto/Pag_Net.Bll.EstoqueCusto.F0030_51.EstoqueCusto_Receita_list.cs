using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public static class F0030_51_EstoqueCusto_Receita_list
    {
        private static string _VERSION() { return "f0030_51_1011970_estoquecusto_receita_list"; }
        public static string Get(
            int pr_cdproduto 
            )
        {
            try
            {
                string stringsql = String.Format("SELECT  * FROM " + _VERSION() + " ( {0} )",
										pr_cdproduto.ToString()
                                              );
                return stringsql;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
    }
}
