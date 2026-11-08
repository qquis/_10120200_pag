using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle.F0130_09_Controle_Status_Consultar
{

    public class filter
    {
        public int controle_cd { get; set;  }
        public filter(int _controle_cd)
        {
            controle_cd = _controle_cd;
        }
    }
    public static class PostGre
    {
        private static string _VERSION() { return "f0130_09_1011915_controle_status_consultar"; }
        public static DataTable Get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
             filter _filter 
            )
        {

            try
            {
                DataTable DT;
                DT = BDCommand.get_DataTable(MyConnect, string.Format("SELECT * FROM" + _VERSION() + " {0}", 
                    _filter.controle_cd.ToString()));
                return DT;
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0130_Controle.F0130_09_Controle_Status_Consultar: " + ex.Message);
            }

        }

    }
}
