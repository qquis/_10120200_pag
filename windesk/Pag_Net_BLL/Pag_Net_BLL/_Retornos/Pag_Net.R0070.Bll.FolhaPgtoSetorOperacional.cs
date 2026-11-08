using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0070
{
    public static class Select  
    {
        public static DataTable get(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int SetorOperacional
            
            )

        {

            try
            {
                string SQL_POSTGRE = string.Format("select * from r0070_0001_folhapgto_setor_operacional({0} )",
                                                        SetorOperacional

                                                      );

                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DX.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }
      
    }
}


