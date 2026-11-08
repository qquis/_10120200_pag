using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.Cadastros
{
    public static class UspProdutoRelacaoLinha
    {
        public static int Relacionar(Pag_Net.Models.modelSistemaUsuario __myConnect, string __cdProdutoLinha, string __codigos)
        {
            try
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(__myConnect, Dal.DataBaseName.DBAMAINADM);
                List<Models.ParameterQuey> listParametroInfo = new List<Models.ParameterQuey>();
                listParametroInfo.Add(new ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, false, __cdProdutoLinha));
                listParametroInfo.Add(new ParameterQuey("Codigos", SqlDbType.VarChar, false, __codigos));
                return DalUpdate.Execute("UspProdutoRelacaoLinha", listParametroInfo.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
