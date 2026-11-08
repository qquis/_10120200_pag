using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.P0041.Bll
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
                BDExecute.Execute("select p0041_01_1011870_documentofiscalregistro_excluir ()", null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);

            }

            catch (Exception ex)
            {
                throw new Exception(ErroInfo + ex.Message);
            }
        }

    }
}
