using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_40_Status_Pgto_Update
    {
        private static string _VERSION() { return "f0130_40_1011915_controle_reg_status_pgto_update"; }
        public static string Post(
                    int proc_log_seq ,
                    int controle_reg_seq, 
                    int controle_status_pgto_cd 
                    
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1}, {2})",
                        proc_log_seq.ToString(),
                        controle_reg_seq.ToString(),
                        controle_status_pgto_cd.ToString() 
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


