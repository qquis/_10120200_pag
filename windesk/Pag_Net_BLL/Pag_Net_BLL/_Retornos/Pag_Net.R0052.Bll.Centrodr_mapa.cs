using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0052
{
    public static class Select  
    {
        public static DataTable get(Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vcentrodr_resumo_cd)
        {
            try
            {
                string SQL_POSTGRE = string.Format("select * from r0052_0001_centrodr_mapa({0})", vcentrodr_resumo_cd);
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


