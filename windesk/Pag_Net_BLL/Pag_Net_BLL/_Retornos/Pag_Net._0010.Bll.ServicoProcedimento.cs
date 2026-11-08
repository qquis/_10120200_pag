using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll._0010
{
    public static class Select  
    {
        public static DataTable _dataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, string _stringNOMESERVICO)
        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from f9000_25_1011950_sistema_serviceo_nucleo_procedimento_list('{0}')", _stringNOMESERVICO);
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


