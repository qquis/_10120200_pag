using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_50_Controle_Reg_Consultar
    {
        private static string _VERSION() { return "f0130_50_1011915_controle_reg_consultar"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            model_controle_reg Controle_Reg
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("({0})",   Controle_Reg.controle_reg_seq.ToString()));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


