using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0051
{
    public static class Select  
    {
        public static DataTable _0001_Centrodr_lancamento(Pag_Net.Models.modelSistemaUsuario MyConnect, int op_cdoperacao)
        {
            try
            {
                string SQL_POSTGRE = string.Format("select * from r0051_0001_centrodr_subgrupo({0})", op_cdoperacao);
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


