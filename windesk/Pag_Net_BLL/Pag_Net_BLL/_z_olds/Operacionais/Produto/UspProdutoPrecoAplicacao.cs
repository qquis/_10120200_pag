using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public static class UspProdutoPrecoAplicacao
    {
        public static void Aplicacao(Models.modelSistemaUsuario MyConnect)
        {
            Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                int RegistrosAffetados = DalUpdate.Execute("SPP0060_ProdutoLojaCarga", null);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Aplicação de Preço:" + ex.Message.ToString());
            }
        }
    }
}
