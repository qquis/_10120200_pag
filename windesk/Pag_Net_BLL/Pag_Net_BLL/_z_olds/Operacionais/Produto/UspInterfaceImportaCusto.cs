using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public static class UspInterfaceImportaCusto
    {
        public static void Importar(Models.modelSistemaUsuario MyConnect)
        {
            Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                DalUpdate.Begin();
                int RegistrosAffetados = DalUpdate.Execute("UspInterfaceImportaCusto", null);
                DalUpdate.Commit();
            }
            catch (Exception ex)
            {
                DalUpdate.RollBack();
                throw new Exception("Erro Aplicação de Preço:" + ex.Message.ToString());

            }

        }
    }
}