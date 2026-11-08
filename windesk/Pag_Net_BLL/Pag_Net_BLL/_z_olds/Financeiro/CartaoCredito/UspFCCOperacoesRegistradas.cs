using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Pag_Net.Models.ModeloBase;
using Pag_Net.Dal;
using System.Data;
using System.Reflection;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class OperacoesRegistradas: Bll.USPDataContext
    {
        public FiltrosBasicos Filtros { get; set; }
        public OperacoesRegistradas(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosBasicos();
        }
        public void Select()
        {
         
            List<UVWFCCOperacoesRegistradas> L = new List<UVWFCCOperacoesRegistradas>();
            base.Select();
            foreach( DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCOperacoesRegistradas l = new UVWFCCOperacoesRegistradas();
                l.DataFaturamento = Convert.ToDateTime( i["DataFaturamento"].ToString());
                l.Finalizadora = i["Finalizadora"].ToString();
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
                l.ValorSitef = Convert.ToDouble(i["ValorSitef"].ToString());
                l.ECF = Convert.ToInt32( i["ECF"].ToString());
                l.CupomFiscal = Convert.ToInt32( i["CupomFiscal"].ToString());
                if (l.Valor != l.ValorSitef)
                {
                    l.StatusErroDescricao = "Valor de Identificação do Sitef Incorreto";
                    l.StatusErro = true;
                }
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoInicial", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataFaturamentoFinal", SqlDbType.DateTime, true, Filtros.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("Finalizadora", SqlDbType.VarChar, true, Filtros.Finalizadora));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCOperacoesRegistradas";
        }
    }


    public class UVWFCCOperacoesRegistradas
    {
        public DateTime DataFaturamento { get; set; }
        public int ECF {get;set;}
        public int CupomFiscal {get;set;}
        public Double Valor { get; set; }
        public Double ValorSitef { get; set; }
        public string Finalizadora { get; set; }
        public string StatusErroDescricao { get; set; }
        public bool StatusErro { get; set; }
        public UVWFCCOperacoesRegistradas() { }
    }
}
