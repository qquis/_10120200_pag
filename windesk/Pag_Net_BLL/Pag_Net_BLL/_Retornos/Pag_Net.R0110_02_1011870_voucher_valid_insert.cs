using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0110_02
{
    public static class Postgre
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect
           ,    string      vvoucher_cpf_cnpj	
		   ,    int voucher_tipo_cd 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.R0110_02) +
                    string.Format("('{0}', {1})" 
                    
                    , vvoucher_cpf_cnpj.ToString()		
                     , voucher_tipo_cd.ToString()
                    ));

                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
