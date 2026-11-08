using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_10_Controle_Reg_Etapa_Alterar
    {
        private static string _VERSION() { return "f0130_10_1011915_controle_reg_etapa_alterar"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            model_controle_reg Controle_Reg,
            int controle_etapa_cd_a_finalizar, 
            int controle_etapa_cd_a_considerar, 
            int controle_status_cd
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION()) +
                    string.Format("({0}, {1}, {2}, {3}, {4}, {5})",
                    MyConnect.SEQUENCIAL_DE_PROCESSO.ToString(),
                    Controle_Reg.controle_reg_seq.ToString(), 
                    Controle_Reg.Fila.controle_reg_fila_seq.ToString(),
                    controle_etapa_cd_a_finalizar.ToString(), 
                    controle_etapa_cd_a_considerar.ToString(),
                    controle_status_cd.ToString()
                    );
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


