using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0001
{
    public static class Select  
    {
        public static DataTable _0001_login_acesso(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Models.Filter.Login _Filters)
        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from f0001_10_1012006_login_acesso_list({0} , '{1}' ,'{2}', '{3}')",
                                                      "3",          
                                                      _Filters.email_main,
                                                      _Filters.user_name,
                                                      _Filters.passwd
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


