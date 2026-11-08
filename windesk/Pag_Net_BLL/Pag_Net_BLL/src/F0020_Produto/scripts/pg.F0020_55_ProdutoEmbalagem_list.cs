using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0020_Produto
{

    public static class F0020_55_ProdutoEmbalagem_List
    {
        private static string _VERSION() { return "f0020_55_1011915_produtoembalagem_list"; }
        public static string Get(
            int pr_cdproduto , 
			int prb_cdprodutobluesoft_unitario ,
			string preg_cdbarra

            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("({0}, {1}, '{2}')", 
                    pr_cdproduto.ToString()
				,	prb_cdprodutobluesoft_unitario.ToString()
				,	preg_cdbarra.ToString()
                   
                    ));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}