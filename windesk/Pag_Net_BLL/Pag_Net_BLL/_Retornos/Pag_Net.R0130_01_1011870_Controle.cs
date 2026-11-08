using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0130_01
{
    public static class Postgre
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect
    ,       int proc_log_seq 			
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.R0130_01) +
                    string.Format("({0})", proc_log_seq.ToString()));

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
