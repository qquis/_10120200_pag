using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0110_01
{
    public static class Postgre
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect
    ,       int         vvoucher_seq
    ,       string      vvoucher_cd
    ,       DateTime    vvoucher_data_ini
    ,       DateTime    vvoucher_data_fim
	,		int         cdpessoa
    ,       string      vvoucher_cpf_cnpj			
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.R0110_01) +
                    string.Format("({0}, '{1}', '{2}', '{3}', {4}, '{5}')" 
                    , vvoucher_seq.ToString()
                    , vvoucher_cd.ToString()
                    , vvoucher_data_ini.ToString("yyyy-MM-dd")
                    , vvoucher_data_fim.ToString("yyyy-MM-dd")
                    , cdpessoa.ToString()
                    , vvoucher_cpf_cnpj.ToString()		
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
