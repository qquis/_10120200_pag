using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0010
{
    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute("select f0010_processo_log_info_produto (" + MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() + ")", null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0010 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

