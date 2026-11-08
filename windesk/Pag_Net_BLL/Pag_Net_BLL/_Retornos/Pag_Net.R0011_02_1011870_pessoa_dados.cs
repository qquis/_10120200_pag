using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0011_02
{
    public static class Postgre
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect
	,		string cpf_cnpj			
            )
        {
            try
            {

                if (cpf_cnpj == null || cpf_cnpj == "")
                {
                    throw new Exception("CNPJ Não Informado");
                }

                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.R0011_02) +
                    string.Format("('{0}')", cpf_cnpj == null ? "": cpf_cnpj.ToString())
                    
                    
                    );

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
