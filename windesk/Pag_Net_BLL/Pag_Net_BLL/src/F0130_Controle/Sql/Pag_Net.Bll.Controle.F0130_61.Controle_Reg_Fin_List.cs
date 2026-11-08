using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_61_Controle_Reg_Fin_List
    {
        private static string _VERSION() { return "f0130_61_1011915_controle_reg_fin_list"; }
        public static string Get(
            int controle_reg_seq, 
            DateTime controle_reg_fin_data_inicial, 
            DateTime controle_reg_fin_data_final
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, '{1}', '{2}')",
                    controle_reg_seq.ToString(),
                    controle_reg_fin_data_inicial.ToString("yyy-MM-dd"), 
                    controle_reg_fin_data_final.ToString("yyy-MM-dd")
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


