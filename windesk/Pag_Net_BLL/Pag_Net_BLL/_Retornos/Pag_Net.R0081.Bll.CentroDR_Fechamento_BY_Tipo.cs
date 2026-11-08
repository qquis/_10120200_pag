using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0081
{
    public static class Select
    {
        public static DataTable Dt(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vcompetencia_cd
                , int vcdr_fechamento_cd
                , int vcdr_cdr
                , int vcdr_subgrupo_cd

            )
        {

            try
            {
                string SQL_POSTGRE = string.Format("select * from r00810001_centrodr_fechamento_by_tipo({0}, {1}, {2}, {3})",
                                                      vcompetencia_cd
                                                    , vcdr_fechamento_cd
                                                    , vcdr_cdr
                                                    , vcdr_subgrupo_cd);
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