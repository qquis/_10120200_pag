using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0003_Loja
{
    public class F0003_50_precolistagem_balanca_mgv
    {
        private static string _VERSION() { return "F0003_50_1011980_precolistagem_balanca_mgv"; }
        public static string Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + "()" );
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
