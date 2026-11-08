using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_34_Controle_Reg_Etapa_CRUD
    {
        private static string _VERSION() { return "f0130_34_1011915_controle_reg_etapa_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType ,
            TbControle_reg_etapa REG_ETAPA
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, '{4}', {5}, {6}, '{7}', '{8}', {9})",
                    BDCommnadType.ToString(),
                    REG_ETAPA.controle_reg_seq.ToString(), 
                    REG_ETAPA.controle_reg_fila_seq.ToString(),
                    REG_ETAPA.controle_reg_etapa_seq.ToString(),
                    REG_ETAPA.controle_reg_etapa_data.ToString("yyyy-MM-dd"),
                    REG_ETAPA.controle_etapa_cd.ToString(),
                    REG_ETAPA.controle_etapa_em_execucao.ToString(), 
                    REG_ETAPA.controle_etapa_inicio.ToString("yyyy-MM-dd HH:mm:ss"),
                    REG_ETAPA.controle_etapa_fim.ToString("yyyy-MM-dd HH:mm:ss"),
                    REG_ETAPA.proc_log_seq.ToString()
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


