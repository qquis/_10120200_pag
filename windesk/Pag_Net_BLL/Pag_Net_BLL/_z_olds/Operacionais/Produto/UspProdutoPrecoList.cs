using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class UspProdutoPrecoList : Bll.USPDataContext
    {
        public ProdutoPrecoListFiltros Filtros;
        public UspProdutoPrecoList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new ProdutoPrecoListFiltros();

        }
        public void Select()
        {
            try
            {
                List<UVWProdutoPrecoList> L = new List<UVWProdutoPrecoList>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {

                    UVWProdutoPrecoList l = new UVWProdutoPrecoList();
                    l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    l.DataCadastro = Convert.ToDateTime(i["DataCadastro"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.DescricaoDepartamento = i["DescricaoDepartamento"].ToString();
                    l.DescricaoSecao = i["DescricaoSecao"].ToString();
                    l.DescricaoLinha = i["DescricaoLinha"].ToString();
                    l.StatusProduto = Convert.ToBoolean(i["StatusProduto"]);
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                    l.EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["EmbalagemCompraQtdeUnitaria"].ToString());
                    l.ValorPrecoOriginal = Convert.ToDouble(i["ValorPrecoOriginal"]);
                    l.ValorCusto = Convert.ToDouble(i["ValorCusto"]); 
                    l.NfDataUltimaEntrada = Convert.ToDateTime(i["NfDataUltimaEntrada"]);
                    l.NfUltimaEntrada = Convert.ToInt32(i["NFUltimaEntrada"]);
                    l.EmbalegmEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"]);
                    l.ValorVendasCustoTotal = Convert.ToDouble(i["VendasCustoTotal"]);
                    l.ValorVendasValorTotal = Convert.ToDouble(i["VendasValorTotal"]);
                    l.ValorVendasQtdeTotal = Convert.ToDouble(i["VendasQtdeTotal"]);

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
            ListParameters.Add(new Models.ParameterQuey("DataCadastro", SqlDbType.Bit, true, this.Filtros.DataCadastro));
            if (this.Filtros.DataCadastro)
            {
                ListParameters.Add(new Models.ParameterQuey("DataCadastroInicial", SqlDbType.DateTime, true, this.Filtros.DataCadastroInicial));
                ListParameters.Add(new Models.ParameterQuey("DataCadastroFinal", SqlDbType.DateTime, true, this.Filtros.DataCadastroFinal));
            }
            ListParameters.Add(new Models.ParameterQuey("StatusProduto", SqlDbType.Bit, true, this.Filtros.StatusProduto));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, this.Filtros.CdProdutoDepartamento));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, this.Filtros.CdProdutoSecao));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, this.Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("CdFabricante", SqlDbType.VarChar, true, this.Filtros.CdFabricante));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, this.Filtros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("Codigos", SqlDbType.VarChar, true, this.Filtros.Codigos));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, true, this.Filtros.SeqProdutoCategoria));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoGestor", SqlDbType.Int, true, this.Filtros.SeqProdutoGestor));


            ListParameters.Add(new Models.ParameterQuey("FiltroValorVendas", SqlDbType.Bit, true, this.Filtros.FiltroValorVendas));
            ListParameters.Add(new Models.ParameterQuey("ValorVendasInicial", SqlDbType.Decimal, true, this.Filtros.ValorVendasInicial));
            ListParameters.Add(new Models.ParameterQuey("ValorVendasFinal", SqlDbType.Decimal, true, this.Filtros.ValorVendasFinal));

            
            ListParameters.Add(new Models.ParameterQuey("FiltroQtdeVendas", SqlDbType.Bit , true, this.Filtros.FiltroQtdeVendas));
            ListParameters.Add(new Models.ParameterQuey("QtdeVendasInicial", SqlDbType.Decimal, true, this.Filtros.QtdeVendasInicial));
            ListParameters.Add(new Models.ParameterQuey("QtdeVendasFinal", SqlDbType.Decimal, true, this.Filtros.QtdeVendasFinal));

            ListParameters.Add(new Models.ParameterQuey("FiltroMargemVendas", SqlDbType.Bit, true, this.Filtros.FiltroMargemVendas));
            ListParameters.Add(new Models.ParameterQuey("MargemVendasInicial", SqlDbType.Decimal, true, this.Filtros.MargemVendasInicial));
            ListParameters.Add(new Models.ParameterQuey("MargemVendasFinal", SqlDbType.Decimal, true, this.Filtros.MargemVendasFinal));


            ListParameters.Add(new Models.ParameterQuey("FiltroEstoque", SqlDbType.Bit, true, this.Filtros.FiltroEstoque));
            ListParameters.Add(new Models.ParameterQuey("EstoqueInicial", SqlDbType.Decimal, true, this.Filtros.EstoqueInicial));
            ListParameters.Add(new Models.ParameterQuey("EstoqueFinal", SqlDbType.Decimal, true, this.Filtros.EstoqueFinal));


            ListParameters.Add(new Models.ParameterQuey("DataVendaInicial", SqlDbType.SmallDateTime, true, this.Filtros.DataVendaInicial));
            ListParameters.Add(new Models.ParameterQuey("DataVendaFinal", SqlDbType.SmallDateTime, true, this.Filtros.DataVendaFinal));





            return ListParameters.ToArray();

        }
        public override string SQLCommnad()
        {
            return "UspProdutoPrecoList";
        }

    }

    public class UVWProdutoPrecoList
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public bool StatusProduto { get; set; }
        public string DescricaoDepartamento { get; set; }
        public string DescricaoSecao { get; set; }
        public string DescricaoLinha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string EmbalagemEstoque { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtdeUnitaria { get; set; }
        public double EmbalegmEstoqueQtde { get; set; }

        public double ValorVendasCustoTotal { get; set; }
        public double ValorVendasValorTotal { get; set; }
        public double ValorVendasQtdeTotal {get;set;}

        public double ValorVendasPrecoMedio 
        {
            get
            {
                if (this.ValorVendasValorTotal > 0)
                {
                    return Math.Round(this.ValorVendasValorTotal / ValorVendasQtdeTotal, 2);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double ValorVendasCustoMedio
        {
            get
            {
                if (ValorVendasCustoTotal > 0)
                {
                    return Math.Round(this.ValorVendasCustoTotal / ValorVendasQtdeTotal, 2);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double ValorPrecoOriginal { get; set; }
        public double ValorCusto { get; set; }
        public int NfUltimaEntrada { get; set; }
        public DateTime NfDataUltimaEntrada { get; set; }



    }
    public class ProdutoPrecoListFiltros
    {
        public bool DataCadastro { get; set; }
        public DateTime DataCadastroInicial { get; set; }
        public DateTime DataCadastroFinal { get; set; }
        public bool StatusProduto { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string Descricao { get; set; }
        public string Codigos { get; set; }
        public string CdFabricante { get; set; }
        public int SeqProdutoCategoria { get; set; }
        public int SeqProdutoGestor { get; set; }

        public DateTime DataVendaInicial { get; set; }
        public DateTime DataVendaFinal { get; set; }


        public bool FiltroValorVendas { get; set; }
        public double ValorVendasInicial { get; set; }
        public double ValorVendasFinal { get; set; }

        public bool FiltroQtdeVendas { get; set; }
        public double QtdeVendasInicial { get; set; }
        public double QtdeVendasFinal { get; set; }


        public bool FiltroMargemVendas { get; set; }
        public double MargemVendasInicial { get; set; }
        public double MargemVendasFinal { get; set; }

        public bool FiltroEstoque { get; set; }
        public double EstoqueInicial { get; set; }
        public double EstoqueFinal { get; set; }


    }
}

