using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfacesImportadasLancamentos:Bll.USPDataContext
    {
        public FiltrosCartaoCreditoInterface Filtros { get; set; }
        public UspFCCInterfacesImportadasLancamentos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosCartaoCreditoInterface();
        }
        public void Select()
        {

            List<UVWFCCInterfacesImportadasLancamentos> L = new List<UVWFCCInterfacesImportadasLancamentos>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCInterfacesImportadasLancamentos l = new UVWFCCInterfacesImportadasLancamentos();
                l.CartaoReferencia = i["CartaoReferencia"].ToString();
                l.ValorFaturamento = Convert.ToDouble(i["ValorFaturamento"].ToString());
                l.CodigoAutorizacao = i["CodigoAutorizacao"].ToString();
                l.DescricaoProdutoFinanceiroInterface = i["DescricaoProdutoFinanceiroInterface"].ToString();
                l.HoraTransacao = i["HoraTransacao"].ToString();
                l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                l.DataProcessamento = Convert.ToDateTime(i["DataProcessamento"].ToString());
                l.DataPgto = Convert.ToDateTime(i["DataPgto"].ToString());
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqArquivo", SqlDbType.Int, true, Filtros.SeqArquivo));
            ListParameters.Add(new Models.ParameterQuey("SeqLinhaResumo", SqlDbType.Int, true, Filtros.SeqLinhaResumo));

            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCInterfacesImportadasLancamentos";
        }
    }

    public class UVWFCCInterfacesImportadasLancamentos
    {
        public DateTime DataFaturamento { get; set; }
        public DateTime DataProcessamento { get; set; }
        public DateTime DataPgto { get; set; }
        public string CartaoReferencia { get; set; }
        public string CodigoAutorizacao { get; set; }
        public double ValorFaturamento { get; set; }
        public string DescricaoProdutoFinanceiroInterface { get; set; }
        public string HoraTransacao { get; set; }
        public UVWFCCInterfacesImportadasLancamentos() { }
    }
}