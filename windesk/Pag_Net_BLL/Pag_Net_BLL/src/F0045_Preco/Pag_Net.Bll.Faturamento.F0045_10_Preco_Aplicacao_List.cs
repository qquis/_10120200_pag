using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0045_Preco
{
    public static class F0045_10_Preco_Aplicacao_List
    {
        public static string _VERSION() { return "f0045_10_1012001_preco_aplicacao_list"; }
        public static string Get(
				int data_alteracao_filtrar 
			,	DateTime data_alteracao
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("({0}, '{1}')", data_alteracao_filtrar.ToString(), data_alteracao.ToString("yyyy-MM-dd")));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}

