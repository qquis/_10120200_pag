using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R001301
{
    public static class Select
    {
        public static DataTable get(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vproc_log_seq

            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM r001301_processo_log_arquivo_linha({0})", vproc_log_seq);
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.R0010 | " + ex.Message);
            }

        }

    }
}


