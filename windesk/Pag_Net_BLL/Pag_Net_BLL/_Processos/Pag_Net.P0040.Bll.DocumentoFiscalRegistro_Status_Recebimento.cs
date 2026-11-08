using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.P0040.Bll
{

    /*
    public static class Process
    {
        public static void Execute(Pag_Net.Models.TbSysUserInfo MyConnect)
        {
            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute("select p0040_DocumentoFiscalRegistro_Status_Recebimento ()", null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);

            }

            catch (Exception ex)
            {
                throw new Exception(ErroInfo + ex.Message);
            }
        }

    }*/
}
