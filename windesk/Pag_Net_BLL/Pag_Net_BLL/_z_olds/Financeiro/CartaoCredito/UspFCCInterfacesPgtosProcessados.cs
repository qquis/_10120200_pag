using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfacesPgtosProcessados : Bll.USPDataContext
    {
        public DateTime DataFaturamentoInicial { get; set; }
        public DateTime DataFaturamentoFinal { get; set; }
        public DateTime DataPagamentoInicial { get; set; }
        public DateTime DataPagamentoFinal { get; set; }

        public double ValorPagamentoCupomInicial { get; set; }
        public double ValorPagamentoCupomFinal { get; set; }


        public int SeqSitefLogInterfacedProdutoFinanceiro { get; set; }
        public int CdParticipante { get; set; }
        public UspFCCInterfaceProdutoFinanceiro ProdutosFinanceiros;

        public bool DataFaturamento { get; set; }
        public bool DataPagamento { get; set; }

        private double _ValorTotal;
        private double _ValorTarifa;
        private double _ValorLiquido;
        public double ValorTotal 
        {
            get
            {
                return _ValorTotal;
            }
        }
        public double ValorTarifa
        {
            get
            {
                return _ValorTarifa;
            }
        }
        public double ValorLiquido
        {
            get
            {
                return _ValorLiquido;
            }
        }

        public UspFCCInterfacesPgtosProcessados(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            ProdutosFinanceiros = new UspFCCInterfaceProdutoFinanceiro(_myConnect);
            
        }
        public void Select()
        {
            try
            {
                _ValorTotal = 0;
                _ValorTarifa = 0;
                _ValorLiquido = 0;
                List<UVWFCCInterfacesPgtosProcessados> L = new List<UVWFCCInterfacesPgtosProcessados>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWFCCInterfacesPgtosProcessados l = new UVWFCCInterfacesPgtosProcessados();
                    l.SeqArquivo = Convert.ToInt32(i["SeqArquivo"].ToString());
                    l.SeqLinha = Convert.ToInt32(i["SeqLinha"].ToString());
                    l.DescricaoProdutoFinanceiro = i["DescricaoProdutoFinanceiro"].ToString();
                    l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                    l.DataPgto = Convert.ToDateTime(i["DataPgto"].ToString());
                    l.ValorFaturamento = Convert.ToDouble(i["ValorFaturamento"].ToString());
                    l.ValorTarifa = Convert.ToDouble(i["ValorTarifa"].ToString());
                    l.ValorLiquido = Convert.ToDouble(i["ValorLiquido"].ToString());
                    _ValorLiquido += l.ValorLiquido;
                    _ValorTarifa += l.ValorTarifa;
                    _ValorTotal += l.ValorFaturamento;
                    L.Add(l);
                    
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataFaturamento", SqlDbType.Bit, true, this.DataFaturamento));
            ListParameters.Add(new Models.ParameterQuey("DataPagamento", SqlDbType.Bit, true, this.DataPagamento));
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoInicial", SqlDbType.DateTime, true, DataFaturamentoInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoFinal", SqlDbType.DateTime, true, DataFaturamentoFinal));
            ListParameters.Add(new Models.ParameterQuey("DataPagamentoInicial", SqlDbType.DateTime, true, DataPagamentoInicial));
            ListParameters.Add(new Models.ParameterQuey("DataPagamentoFinal", SqlDbType.DateTime, true, DataPagamentoFinal));
            ListParameters.Add(new Models.ParameterQuey("ValorPagamentoCupomInicial", SqlDbType.Decimal, true, this.ValorPagamentoCupomInicial ));
            ListParameters.Add(new Models.ParameterQuey("ValorPagamentoCupomFinal", SqlDbType.Decimal, true, this.ValorPagamentoCupomFinal));
            ListParameters.Add(new Models.ParameterQuey("SeqSitefLogInterfacedProdutoFinanceiro", SqlDbType.Int, true, this.SeqSitefLogInterfacedProdutoFinanceiro));
            ListParameters.Add(new Models.ParameterQuey("CdParticipante", SqlDbType.Int, true, this.CdParticipante));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCInterfacesPgtosProcessados";
        }
    }

    public class UVWFCCInterfacesPgtosProcessados
    {
        public int SeqInterfacePgto { get; set; }
        public int SeqLinha { get; set; }
        public int SeqArquivo { get; set; }
        public int SeqSitefLogInterfacedProdutoFinanceiro { get; set; }

        public string DescricaoProdutoFinanceiro { get; set; }
        public DateTime DataFaturamento { get; set; }
        public DateTime DataPgto { get; set; }
        public double ValorFaturamento { get; set; }
        public double ValorTarifa { get; set; }
        public double ValorLiquido { get; set; }
        public UVWFCCInterfacesPgtosProcessados() { }
    }
}
