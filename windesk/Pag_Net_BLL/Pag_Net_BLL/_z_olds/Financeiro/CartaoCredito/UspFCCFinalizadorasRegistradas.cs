using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class FinalizadorasRegistradas: Bll.USPDataContext
    {
        public FiltrosBasicos Filtros { get; set; }
        public FinalizadorasRegistradas(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosBasicos();
        }
        public void Select()
        {
         
            List<UVWFCCFinalizadorasRegistradas> L = new List<UVWFCCFinalizadorasRegistradas>();
            base.Select();
            foreach( DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCFinalizadorasRegistradas l = new UVWFCCFinalizadorasRegistradas();
                l.DataFaturamento = Convert.ToDateTime( i["DataFaturamento"].ToString());
                l.Finalizadora = i["Finalizadora"].ToString();
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
                l.ValorSitef = Convert.ToDouble(i["ValorSitef"].ToString());
                if (l.Valor != l.ValorSitef ) l.StatusErro = true;
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoInicial", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoFinal", SqlDbType.DateTime, true, Filtros.DataFinal));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCFinalizadorasRegistradas";
        }
    }
    public class UVWFCCFinalizadorasRegistradas
    {
        public DateTime  DataFaturamento { get; set; } 
        public Double Valor  { get; set; }                                 
        public Double ValorSitef { get; set; }
        public bool StatusErro { get; set; }
        public string Finalizadora { get; set; }
        public UVWFCCFinalizadorasRegistradas() { }
    }
}
