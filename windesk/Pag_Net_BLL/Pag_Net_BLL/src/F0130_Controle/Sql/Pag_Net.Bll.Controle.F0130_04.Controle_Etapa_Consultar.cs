using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_04_Controle_Etapa_Consultar
    {
        private static string _VERSION() { return "f0130_04_1011915_controle_etapa_consultar"; }
        public static string Get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            int controle_cd
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("({0})",  controle_cd.ToString()));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


