using Pag_Net.Bll;
using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net
{
    public static class Process
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, string SQL)
        {
            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute(SQL, null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void p0010_02(Pag_Net.Models.modelSistemaUsuario MyConnect) { try { Pag_Net.Bll.BDCommand.Execute(MyConnect, BDCommand.Name.P0010_02); } catch (Exception ex) { throw new Exception(ex.Message); } }
    }
}
