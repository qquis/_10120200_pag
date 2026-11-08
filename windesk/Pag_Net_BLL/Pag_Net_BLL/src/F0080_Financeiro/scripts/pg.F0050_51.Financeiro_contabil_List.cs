using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.scripts
{
    public static class F0050_51_financeiro_contabil_list 
    {
        private static string _VERSION() { return "f0050_51_1011918_financeiro_contabil_list"; }
        public static string Get
            (
                int competencia_cd 
               , int NfolhaPgto 
               , int Nfornecedor 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format ( "({0}, {1}, {2} )", competencia_cd.ToString(), NfolhaPgto.ToString(), Nfornecedor.ToString()));
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
