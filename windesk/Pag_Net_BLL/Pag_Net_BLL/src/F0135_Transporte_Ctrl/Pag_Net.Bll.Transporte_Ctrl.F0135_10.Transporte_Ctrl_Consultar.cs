using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{
    public static class F0135_10_Transporte_Ctrl_Consultar
    {
        private static string _VERSION() { return "f0135_10_1011915_transporte_ctrl_consultar"; }
        public static string Get(
                int controle_reg_seq,
                int transporte_ctrl_seq 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1})",
                        controle_reg_seq.ToString(),
                        transporte_ctrl_seq.ToString()
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


