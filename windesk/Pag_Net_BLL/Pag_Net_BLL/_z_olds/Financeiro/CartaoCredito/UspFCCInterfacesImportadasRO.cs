using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfacesImportadasRO : Bll.USPDataContext
    {   
        public FiltrosCartaoCreditoInterface Filtros { get; set; }
    public UspFCCInterfacesImportadasRO(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosCartaoCreditoInterface();
        }
        public void Select()
        {

            List<UVWFCCInterfacesImportadasRO> L = new List<UVWFCCInterfacesImportadasRO>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCInterfacesImportadasRO l = new UVWFCCInterfacesImportadasRO();
                l.DescricaoProdutoFinanceiroInterface = i["DescricaoProdutoFinanceiro"].ToString();
                l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                l.DataPgto = Convert.ToDateTime(i["DataPgto"].ToString());
                l.ValorFaturamento = Convert.ToDouble(i["ValorFaturamento"].ToString());
                l.ValorTarifa = Convert.ToDouble(i["ValorTarifa"].ToString());
                l.ValorLiquido = Convert.ToDouble(i["ValorLiquido"].ToString());
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqArquivo", SqlDbType.Int, true, Filtros.SeqArquivo));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCInterfacesImportadasResumo";
        }
    }

    public class UVWFCCInterfacesImportadasRO
    {
        public string DescricaoProdutoFinanceiroInterface { get; set; }
        public DateTime DataFaturamento { get; set; }
        public DateTime DataPgto { get; set; }
        public double ValorFaturamento { get; set; }
        public double ValorTarifa { get; set; }
        public double ValorLiquido { get; set; }
        public UVWFCCInterfacesImportadasRO() { }
    }
}