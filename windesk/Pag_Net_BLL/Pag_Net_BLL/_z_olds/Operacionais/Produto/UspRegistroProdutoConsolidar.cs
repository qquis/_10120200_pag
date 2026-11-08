using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public  class UspRegistroProdutoConsolidar
    {

       
            public static void Executar(Models.modelSistemaUsuario MyConnect)
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
                try
                {
                    List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
                    ListParameters.Add(new Models.ParameterQuey("CdEmpresa", SqlDbType.Int, true, 1));
                    int RegistrosAffetados = DalUpdate.Execute("UspRegistroProdutoConsolidar", ListParameters.ToArray());
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro Aplicação de Preço:" + ex.Message.ToString());
                }
            }
        
    }
}
