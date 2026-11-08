using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R001300
{
    public static class Select
    {
        public static DataTable get(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vproc_log_seq
                , int vproc_tipo_cd
                , int vproc_cd

            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM r001300_processo_log_arquivo({0}, {1}, {2})", vproc_log_seq, vproc_tipo_cd, vproc_cd);
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


