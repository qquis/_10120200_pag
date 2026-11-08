using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.SPP0015.Bll
{
    public static class SqlServer
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                //BDExecute.Begin();
                ErroInfo = "Pag_Net.SPP0015.Bll | Execução da SQLSERVER-SPP: ";
                BDExecute.Execute(Pag_Net.SPP0015.Models.BD.SqlServer.SqlProcedureName(), Pag_Net.SPP0015.Models.BD.SqlServer.Fill(Pag_Net.Models.BDCommandTypes.BDEXECUTE));
            }

            catch (Exception ex)
            {
                throw new Exception(ErroInfo + ex.Message);
            }
        }

    }
}
