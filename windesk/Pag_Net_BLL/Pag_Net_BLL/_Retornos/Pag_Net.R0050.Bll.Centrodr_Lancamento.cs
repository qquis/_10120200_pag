using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0050
{
    public static class Select  
    {
        public static DataTable _0001_Centrodr_lancamento(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int cdr_cd
                , int cdr_subgrupo_cd
                , int cdr_lanc_competencia
            
            )

        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from r0050_0001_Centrodr_lancamento({0} , {1} ,'{2}')",
                                                        cdr_cd
                                                    , cdr_subgrupo_cd
                                                    , cdr_lanc_competencia
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


