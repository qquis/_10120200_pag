using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0001_0002
{
    public static class Select  
    {
        public static DataTable get(Pag_Net.Models.modelSistemaUsuario MyConnect, int vsis_ta_cd )
        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from f0001_11_1012017_sistema_login_acesso_tarefa({0}, {1}, {2})",
                                                      "3",
                                                      MyConnect.sis_us_seq.ToString(),
                                                      vsis_ta_cd
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


