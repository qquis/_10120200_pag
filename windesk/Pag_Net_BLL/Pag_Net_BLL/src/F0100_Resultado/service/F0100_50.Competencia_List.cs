using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0100_Resultado.scripts
{
    public static class F0100_50_competencia_list
    {
        private static string _VERSION() { return "f0100_50_1011918_competencia_list"; }
        public static string Get(
            int ano 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + "(" + ano + ")");
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}