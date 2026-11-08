using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.scripts
{
    public static class f0080_20_1012006_fin_forma_pgto_list
    {
        private static string _VERSION() { return "f0080_20_1012006_fin_forma_pgto_list"; }
        public static string Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + "()");
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


