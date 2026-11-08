using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0010
{
    public static class Select  
    {
        public static DataTable get(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vproc_tipo_cd
            
            )

        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = "SELECT proc_log_seq FROM f9050_10_1012008_processo_log( " + 
                                                      "   vproc_tipo_cd:= " + vproc_tipo_cd.ToString() +  
                                                      " , vsis_us_seq:= " + MyConnect.sis_us_seq.ToString() +
                                                      " , vuuid_user_seq:= '' " + 
                                                      ")" ;

                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DX.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.R0010 | " + ex.Message);
            }
  
        }
     
        public static int Proc_Log_Seq (Pag_Net.Models.modelSistemaUsuario MyConnect, int vproc_tipo_cd)
        {
            try
            {
                return Convert.ToInt32(get(MyConnect, vproc_tipo_cd).Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.R0010 | " + ex.Message);
            }
  

        }
    }
}


