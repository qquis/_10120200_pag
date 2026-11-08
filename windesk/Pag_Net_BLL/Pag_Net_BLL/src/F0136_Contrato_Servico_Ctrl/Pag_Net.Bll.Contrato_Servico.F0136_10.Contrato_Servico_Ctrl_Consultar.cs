using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class F0136_10_Contrato_Servico_Ctrl_Consultar
    {
        private static string _VERSION() { return "f0136_10_1011922_contrato_servico_ctrl_consultar"; }
        public static string Get(
	       int 	  controle_reg_seq				

            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0})", controle_reg_seq.ToString() ));
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    
    }
}
