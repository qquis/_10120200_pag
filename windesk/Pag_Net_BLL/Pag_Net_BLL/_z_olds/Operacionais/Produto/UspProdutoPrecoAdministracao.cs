using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class UspProdutoPrecoAdministracao : Bll.USPDataContext
    {
        public ProdutoPrecoAdministracaoFiltros Filtros;
        public UspProdutoPrecoAdministracao(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new ProdutoPrecoAdministracaoFiltros();
        }

        public void Select()
        {
            try
            {
                List<UVWProdutoPrecoAdministracao> L = new List<UVWProdutoPrecoAdministracao>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {

                    UVWProdutoPrecoAdministracao l = new UVWProdutoPrecoAdministracao();

                    l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                    l.Descricao = i["Descricao"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.ValorPreco  = Convert.ToDouble( i["ValorPreco"].ToString());
                    l.ValorCustoPadrao = Convert.ToDouble(i["ValorCustoPadrao"].ToString());
                    l.DescontoPromocionalQtde = Convert.ToDouble(i["DescontoPromocionalQtde"].ToString());
                    l.DescontoPromocionalPercentual = Convert.ToDouble(i["DescontoPromocionalPercentual"].ToString());

                    

                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("CdOperacao", SqlDbType.Int, true, Filtros.CdOperacao));
            ListParameters.Add(new Models.ParameterQuey("Codigos", SqlDbType.VarChar , true, Filtros.Codigos ));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar , true, Filtros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar , true, Filtros.CdProdutoDepartamento));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar , true, Filtros.CdProdutoSecao));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar , true, Filtros.CdProdutoLinha));


            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspProdutoPrecoAdministracao";
        }
    }



    
    public class UVWProdutoPrecoAdministracao
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemEstoque { get; set; }
        public double ValorPreco { get; set; }
        public double ValorCustoPadrao { get; set; }
        public double DescontoPromocionalQtde { get; set; }
        public double DescontoPromocionalPercentual { get; set; }
    }

    public class ProdutoPrecoAdministracaoFiltros
    {
        public int CdOperacao { get; set; }
        public string Codigos { get; set; }
        public string Descricao { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }

    }
}
