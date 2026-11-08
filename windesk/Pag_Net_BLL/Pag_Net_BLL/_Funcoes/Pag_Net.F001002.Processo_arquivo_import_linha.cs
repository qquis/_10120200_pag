using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F001002
{
    public static class Postgres
    {
        public static void CRUD(
                 Pag_Net.Models.modelSistemaUsuario MyConnect
              ,  int vproc_log_seq 						
	          ,  int vproc_log_arquivo_import_linha_ordem
	          ,  string vproc_log_arquivo_linha		


           )
        {

            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE = string.Format("SELECT f001102_processo_log_arquivo_linha({0}, {1}, '{2}')",
                                                           vproc_log_seq.ToString()						
                                                        ,  vproc_log_arquivo_import_linha_ordem.ToString()	
                                                        ,  vproc_log_arquivo_linha.ToString().Replace("'", "´")	
                                                      );
                                                   
                BDExecute.Execute(SQL_POSTGRE, null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F001001 | ERRO: " + ex.Message);
            }

        }

    
    }
}

