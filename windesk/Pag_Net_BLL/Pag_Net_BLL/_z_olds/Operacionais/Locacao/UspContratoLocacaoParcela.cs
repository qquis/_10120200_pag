using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;


namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacaoParcela : Bll.USPDataContext
    {
        public ParametroContratoLocacaoParcela Parametros;
        public UspContratoLocacaoParcela(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacaoParcela();

        }

        public void Select()
        {
            List<UVWContratoLocacaoParcela> L = new List<UVWContratoLocacaoParcela>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacaoParcela l = new UVWContratoLocacaoParcela();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.SeqContratoLocacaoFaturamento = Convert.ToInt32(i["SeqContratoLocacaoFaturamento"].ToString());
                l.SeqContratoLocacaoParcela = Convert.ToInt32(i["SeqContratoLocacaoParcela"].ToString());
                l.NumeroOrdem = Convert.ToInt32(i["NumeroOrdem"].ToString());
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
                l.ValorDesconto = Convert.ToDouble(i["ValorDesconto"].ToString());
                l.SeqFaturamento = Convert.ToInt32(i["SeqFaturamento"].ToString());
                l.DataVencimento = Convert.ToDateTime(i["DataVencimento"].ToString());
                l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                l.DescricaoContrato = i["DescricaoContrato"].ToString();
                l.StatusFaturamento = i["StatusFaturamento"].ToString();
                
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "USPContratoLocacaoParcela";
        }
    }

    public class UVWContratoLocacaoParcela  
    {
        public int SeqContrato { get; set; }
        public int SeqContratoLocacaoFaturamento { get; set; }
        public int SeqContratoLocacaoParcela { get; set; }
        public Int32 NumeroOrdem { get; set; }
        public int SeqFaturamento { get; set; }
        public double Valor { get; set; }
        public double ValorDesconto { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataFaturamento { get; set; }
        public string DescricaoContrato { get; set; }
        public string StatusFaturamento { get; set; }
    }


    public class ParametroContratoLocacaoParcela
    {
        public int SeqContrato { get; set; }
        public int SeqContratoLocacaoFaturamento { get; set; }
        public string DescricaoContrato { get; set; }
        public string StatusFaturamento { get; set; }
        public int SeqTitulo { get; set; }
    }
}


