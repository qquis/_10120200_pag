using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{
    public static class F0135_20_Transporte_Ctrl_Documentofiscal_list
    {
        private static string _VERSION() { return "f0135_20_1011922_transporte_ctrl_documentofiscal_list"; }
        public static string Get(
                int dfr_seq, 
                int controle_reg_seq,
                int controle_reg_etapa_seq 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1}, {2})",
                        dfr_seq.ToString(), 
                        controle_reg_seq.ToString(), 
                        controle_reg_etapa_seq.ToString()
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


