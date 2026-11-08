using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Faturamento
{
    public class UspFaturamentoDocumentoItens : Bll.USPDataContext
    {
        public FaturamentoDocumentoItensFiltros Filtros { get; set; }
        public UspFaturamentoDocumentoItens(Models.modelSistemaUsuario _myconnect)
            : base(_myconnect)
        {
            Filtros = new FaturamentoDocumentoItensFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWFaturamentoDocumentosItens> L = new List<UVWFaturamentoDocumentosItens>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWFaturamentoDocumentosItens l = new UVWFaturamentoDocumentosItens();
                    l.SeqFaturamento = Convert.ToInt32(i["SeqFaturamento"].ToString());
                    l.SeqFaturamentoOrigem = Convert.ToInt32(i["SeqFaturamentoOrigem"].ToString());
                    l.Ecf = Convert.ToInt32(i["Ecf"].ToString());
                    l.CupomFiscal = Convert.ToInt32(i["CupomFiscal"].ToString());
                    l.NumeroPedido = Convert.ToInt32(i["NumeroPedido"].ToString());
                    l.NumeroNfe = Convert.ToInt32(i["NumeroNfe"].ToString());
                    l.CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
                    l.DescricaoProduto = i["DescricaoProduto"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemEstoqueQtde = Convert.ToDecimal(i["EmbalagemEstoqueQtde"].ToString());
                    l.ValorUnitario = Convert.ToDouble(i["ValorUnitario"].ToString());
                    l.ValorTotalFaturamento = Convert.ToDouble(i["ValorTotalFaturamento"].ToString());
                    L.Add(l);
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
            ListParameters.Add(new Models.ParameterQuey("SeqFaturamento", SqlDbType.Int, true, Filtros.SeqFaturamento));
            ListParameters.Add(new Models.ParameterQuey("SeqFaturamentoOrigem", SqlDbType.Int, true, Filtros.SeqFaturamentoOrigem));
                    
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFaturamentoDocumentoItens";
        }

    }

    public class UVWFaturamentoDocumentosItens
    {
        public int SeqFaturamento { get; set; }
        public int SeqFaturamentoOrigem { get; set; }
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public int NumeroPedido { get; set; }
        public int NumeroNfe { get; set; }	
        public int CdProduto { get; set; }	
        public string DescricaoProduto { get; set; }
        public string EmbalagemEstoque { get; set; }
        public decimal EmbalagemEstoqueQtde { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotalFaturamento { get; set; }
    }

    public class FaturamentoDocumentoItensFiltros
    {
        public int SeqFaturamento { get; set; }
        public int SeqFaturamentoOrigem { get; set; }
    }
}
