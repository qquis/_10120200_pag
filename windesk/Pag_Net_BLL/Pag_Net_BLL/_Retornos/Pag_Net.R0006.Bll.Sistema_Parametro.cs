using System;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using System.Collections.Generic;


namespace Pag_Net.Bll.R0006
{

    public static class Select
    {

        public static DataTable get_DataTable( 
                    Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vsis_pr_cd	
            
            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM r00060100_sistema_parametro( {0} )",  vsis_pr_cd.ToString());

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

