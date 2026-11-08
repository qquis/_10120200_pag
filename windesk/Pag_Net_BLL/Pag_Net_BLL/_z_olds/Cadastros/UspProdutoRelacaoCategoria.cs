using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.Cadastros
{
    public static class UspProdutoRelacaoCategoria
    {
        public static int Relacionar(Pag_Net.Models.modelSistemaUsuario __myConnect, int __seqProdutoCategoria, string __codigos)
        {
            try
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(__myConnect, Dal.DataBaseName.DBAMAINADM);
                List<Models.ParameterQuey> listParametroInfo = new List<Models.ParameterQuey>();
                listParametroInfo.Add(new ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, false, __seqProdutoCategoria));
                listParametroInfo.Add(new ParameterQuey("Codigos", SqlDbType.VarChar, false, __codigos));
                return DalUpdate.Execute("UspProdutoRelacaoCategoria", listParametroInfo.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
