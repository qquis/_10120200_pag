using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0131_Veiculo
{

    public static class f0131_30_veiculo_modelo_list
    {
        private static string _VERSION() { return "f0131_30_1011915_veiculo_modelo_list"; }
        public static string Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("()"));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


