using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.P0070
{
    public static class Process
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
             
            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute("select p0070_01_1011861_produto_preco_aplicacao ()", null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
            }

            catch (Exception ex)
            {
                throw new Exception(ErroInfo + ex.Message);
            }

        }
    }
}
