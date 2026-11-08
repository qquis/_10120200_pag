using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfacesConsolidarPgto
    {
        public static void Aplicar(Models.modelSistemaUsuario MyConnect)
        {
            Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                int RegistrosAffetados = DalUpdate.Execute("UspFCCInterfacesConsolidarPgto", null);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Aplicação de Preço:" + ex.Message.ToString());
            }
        }
    }
}
