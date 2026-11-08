using System;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using System.Collections.Generic;


namespace Pag_Net.Bll.R0090
{

    public static class Select
    {

        public static DataTable get_DataTable( Pag_Net.Models.modelSistemaUsuario MyConnect
                ,   DateTime    vdata_log_ini	
	            ,   DateTime	vdata_log_fim	
	            ,	int         vSIS_US_SEQ	
	            ,	int         vproc_tipo_cd
	            ,	int         vproc_cd
            
            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM r0090_processo_log( '{0}', '{1}', {2}, {3}, {4})",
                    vdata_log_ini.ToString("yyyy-MM-dd"),
                    vdata_log_fim.ToString("yyyy-MM-dd"),
                    vSIS_US_SEQ.ToString(),
                    vproc_tipo_cd.ToString(),
                    vproc_cd.ToString()
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

