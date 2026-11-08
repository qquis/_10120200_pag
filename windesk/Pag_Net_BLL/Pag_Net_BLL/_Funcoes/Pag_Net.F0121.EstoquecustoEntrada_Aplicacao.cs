using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0121
{
    public static class Postgres
    {
        public static void CRUD(
                 Pag_Net.Models.modelSistemaUsuario MyConnect
            ,    int        vproc_log_seq 				                		
           )
        {

            try
            {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT f0121_estoquecusto_entrada_aplicacao ({0})",vproc_log_seq.ToString());
                BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0121 | ERRO: " + ex.Message);
            }

        }

    
    }
}

