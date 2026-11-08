using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0011_01
{
    public static class Postgre
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect
    ,       int cdpessoa 			
	,		int cdpessoabluesoft	
	,		int cdparticipante		
	,		string cpf_cnpj			
	,		string nome_razao 		
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.R0011_01) +
                    string.Format("({0}, {1}, {2}, '{3}', '{4}')", 
                    cdpessoa.ToString(),
                    cdpessoabluesoft.ToString(),
                    cdparticipante.ToString(), 
                    cpf_cnpj == null ? "": cpf_cnpj.ToString(),
                    nome_razao == null ? "": nome_razao.Replace("'",""))
                    
                    
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
