using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceFaturamentoInfoItemDetalhe: Bll.USPDataContext
     {
        public InterfaceFaturamentoInfoItemDetalheFiltros Filtros { get; set; }

        public double TotalValorFaturamento { get; set; }
        public double TotalVolume { get; set; }
        
        public string Detalhe_Arquivo { get; set; }
        public int Detalhe_SeqProcessamentoItemDocumento { get; set; }
        public string Detalhe_EmbalagemEstoque { get; set; }
        public double Detalhe_EmbalagemEstoqueQtde { get; set; }
        public int Detalhe_SeqFaturamento { get; set; }
        public int Detalhe_SeqFaturamentoOrigem { get; set; }
        public int Detalhe_SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem { get; set; }
        public int Detalhe_StatusProcessamento { get; set; }
        
        public UspInterfaceFaturamentoInfoItemDetalhe(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new InterfaceFaturamentoInfoItemDetalheFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoInfoItemDetalhe> L = new List<UVWInterfaceFaturamentoInfoItemDetalhe>();
                this.TotalValorFaturamento = 0;
                this.TotalVolume = 0;
                this.Detalhe_Arquivo = "";
                this.Detalhe_SeqProcessamentoItemDocumento = 0;
                this.Detalhe_EmbalagemEstoque = "";
                this.Detalhe_EmbalagemEstoqueQtde = 0;
                this.Detalhe_SeqFaturamento = 0;
                this.Detalhe_SeqFaturamentoOrigem = 0;
                this.Detalhe_SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem = 0;
                this.Detalhe_StatusProcessamento = 0;


                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoInfoItemDetalhe l = new UVWInterfaceFaturamentoInfoItemDetalhe();
                        
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.Arquivo = i["Arquivo"].ToString();
                        l.SeqProcessamentoItemDocumento = Convert.ToInt32(i["SeqProcessamentoItemDocumento"].ToString());
                        l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                        l.CdClienteERP  = Convert.ToInt32(i["CdClienteERP"].ToString());
                        l.ClienteNome = i["ClienteNome"].ToString();
                        l.CdVendedorERP =i["CdVendedorERP"].ToString();
                        l.VendedorNome = i["VendedorNome"].ToString();
                        l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                        l.DescricaoProduto = i["DescricaoProduto"].ToString();
                        l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                        l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                        l.EmbalagemCompraQtde =Convert.ToDouble( i["EmbalagemCompraQtde"].ToString());
                        l.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());
                        l.ValorTotalFaturamento = Convert.ToDouble(i["ValorTotalFaturamento"].ToString());
                        l.SeqFaturamento = Convert.ToInt32(i["SeqFaturamento"].ToString());
                        l.SeqFaturamentoOrigem = Convert.ToInt32(i["SeqFaturamentoOrigem"].ToString());
                        l.NumeroPedido = Convert.ToInt32(i["NumeroPedido"].ToString());
                        l.Nfe = Convert.ToInt32(i["Nfe"].ToString());
                        l.ECF = Convert.ToInt32(i["ECF"].ToString());
                        l.CupomFiscal = Convert.ToInt32(i["CupomFiscal"].ToString());
                        l.SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem = Convert.ToInt32(i["SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem"].ToString());
                        l.StatusProcessamento = Convert.ToInt32(i["StatusProcessamento"].ToString());

                        TotalValorFaturamento += l.ValorTotalFaturamento;
                        TotalVolume += l.EmbalagemCompraQtde;

                        Detalhe_Arquivo = l.Arquivo;
                        Detalhe_SeqProcessamentoItemDocumento = l.SeqProcessamentoItemDocumento;
                        Detalhe_EmbalagemEstoque = l.EmbalagemEstoque;
                        Detalhe_EmbalagemEstoqueQtde = l.EmbalagemEstoqueQtde;
                        Detalhe_SeqFaturamento = l.SeqFaturamento;
                        Detalhe_SeqFaturamentoOrigem = l.SeqFaturamentoOrigem;
                        Detalhe_SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem = l.SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem;
                        Detalhe_StatusProcessamento = l.StatusProcessamento;
                      

                        //l.Descricao = i["Descricao"].ToString();
                        L.Add(l);
                        

                    }
                    base.ViewData = L.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {

            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqInterfaceInfo", SqlDbType.Int, true, Filtros.SeqInterfaceInfo));
            ListParameters.Add(new Models.ParameterQuey("DataInicial", SqlDbType.Date, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFinal", SqlDbType.Date, true, Filtros.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, Filtros.CdProdutoDepartamento));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, Filtros.CdProdutoSecao ));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, Filtros.Descricao ));
            ListParameters.Add(new Models.ParameterQuey("ProdutoLista", SqlDbType.VarChar, true, Filtros.ProdutoLista));

            return ListParameters.ToArray();
            //return null;
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceFaturamentoInfoItemDetalhe";
        }

    }
    public class UVWInterfaceFaturamentoInfoItemDetalhe
    {
        public int SeqInterfaceInfo { get; set; }
        public string Arquivo { get; set; }
        public int SeqProcessamentoItemDocumento { get; set; }
        public DateTime DataFaturamento { get; set; }
        public int CdClienteERP { get; set; }
        public string ClienteNome { get; set; }
        public string CdVendedorERP { get; set; }
        public string VendedorNome { get; set; }
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string EmbalagemEstoque { get; set; }
        public double EmbalagemEstoqueQtde { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtde { get; set; }
        public double ValorTotalFaturamento { get; set; }
        public int SeqFaturamento { get; set; }
        public int SeqFaturamentoOrigem { get; set; }
        public int NumeroPedido { get; set; }
        public int Nfe { get; set; }
        public int ECF { get; set; }
        public int CupomFiscal { get; set; }
        public int SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem { get; set; }
        public int StatusProcessamento { get; set; }
    }

    public class InterfaceFaturamentoInfoItemDetalheFiltros
    {
        public int SeqInterfaceInfo  {get;set;}
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string ProdutoLista { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string ListaArquivos { get; set; }

    }
}
