using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0054
{
    public static class Select  
    {
        public static DataTable Dt(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vcompetencia_cd
                , int vcdr_cd
                , int vcdr_subgrupo_cd
                , int vcentrodr_resumo_cd
                , int vcdr_tipo_cd
            
            )

        {

            try
            {
                string SQL_POSTGRE = string.Format("select * from r0054_0001_centrodr_lancamento_mapa({0} , {1}, {2}, {3}, {4})",
                                                      vcompetencia_cd
                                                    , vcdr_cd
                                                    , vcdr_subgrupo_cd
                                                    , vcentrodr_resumo_cd
                                                    , vcdr_tipo_cd
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


