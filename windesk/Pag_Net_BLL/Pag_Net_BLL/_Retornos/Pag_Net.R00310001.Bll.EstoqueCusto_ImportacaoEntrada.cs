using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0031
{
    public static class Select
    {
        public static DataTable get(
                Pag_Net.Models.modelSistemaUsuario MyConnect
            ,   int _vproc_log_seq
            )
        {

            try
            {
                string SQL_POSTGRE = "";

                SQL_POSTGRE = string.Format("SELECT * FROM r00310001_estoquecusto_importacao_entrada({0})",
                                                         _vproc_log_seq
                                                         );
         

                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}













