using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public static class UspProdutoPrecoAlteracao
    {
        public static void Aplicacao(Models.modelSistemaUsuario MyConnect, VWProdutoOperacaoPreco[] lista, DateTime dataAplicacao, int cdOperacao)
        {
            Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                DalUpdate.Begin();
                foreach (VWProdutoOperacaoPreco item in lista)
                {
                    
                    List<ParameterQuey> listParametro = new List<ParameterQuey>();
                    listParametro.Add(new ParameterQuey("CdProduto", SqlDbType.Int, false, item.CdProduto));
                    listParametro.Add(new ParameterQuey("EmbalagemCdprodutobluesoft", SqlDbType.Int, false, item.EmbalagemCdprodutobluesoft));
                    listParametro.Add(new ParameterQuey("Embalagem", SqlDbType.Char, false, item.Embalagem));
                    listParametro.Add(new ParameterQuey("ValorPreco", SqlDbType.Decimal, false, item.EmbalagemEstoquePrecoAlterado));
                    listParametro.Add(new ParameterQuey("fatorpreco", SqlDbType.Decimal, false, item.FatorPrecoAlterado));
                    listParametro.Add(new ParameterQuey("DataAplicacao", SqlDbType.SmallDateTime, true, dataAplicacao));
                    listParametro.Add(new ParameterQuey("cdoperacao", SqlDbType.Int, true, cdOperacao));
                    listParametro.Add(new ParameterQuey("QtdePromocional", SqlDbType.Decimal, true, item.QtdePromocionalAlterada));
                    int RegistrosAffetados = DalUpdate.Execute("SPP0071_ProdutoPrecoAlteracao", listParametro.ToArray());
                }
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
