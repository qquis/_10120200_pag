using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Sistemas
{
    public static class Processos
    {
        public static void Executa(Models.modelSistemaUsuario __myConnect, Pag_Net.Bll.Sistemas.VWProcessos __processo)
        {

            if (__processo.Ref == "DBAMAINADM")
            {
                Pag_Net.Dal.DbUpdate dal = new Dal.DbUpdate(__myConnect, Dal.DataBaseName.DBAMAINADM);
                dal.Execute(__processo.StoredProcedure, null);
            }
            else
            {
                Pag_Net.Dal.DbUpdate dal = new Dal.DbUpdate(__myConnect, Dal.DataBaseName.DBAMAINERP);
                dal.Execute(__processo.StoredProcedure, null);
            }

        }
    }
}
