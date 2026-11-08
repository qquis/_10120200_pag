using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0021_ProdutoBlueSoft;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class F0021_90_ProdutoBlueSoftProcessamento
    {
        //private static string _VERSION() { return "f0021_90_1011950_produtobluesoft_processamento"; }
        private static string _VERSION() { return "f0021_90_1012019_produtobluesoft_processamento"; }
        public static string Post(
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + _VERSION() + "()");
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
