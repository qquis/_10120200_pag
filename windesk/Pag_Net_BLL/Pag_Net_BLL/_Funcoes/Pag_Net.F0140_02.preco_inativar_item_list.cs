using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;



namespace Pag_Net.Bll.F0140_02
{
  
    public static class Postgre 
    { 
        public static string Post(
                int _cdProduto
            ,   int _pr_status_comercial_preco_inativo
   

            )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = Pag_Net.Bll.BDCommand.ScriptSql_Get(BDCommand.Name.F0140_02_preco_inativar_item_list, string.Format("{0} , {1}",
                                                        _cdProduto.ToString(),
                                                        _pr_status_comercial_preco_inativo
                    ));
                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.F0140_01.Bll " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }

        
    
    }

}
