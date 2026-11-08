using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacaoFaturamento : Bll.USPDataContext
    {
        public ParametroContratoLocacaoFaturamento Parametros;
        public UspContratoLocacaoFaturamento(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacaoFaturamento();

        }

        public void Select()
        {
            List<UVWContratoLocacaoFaturamento> L = new List<UVWContratoLocacaoFaturamento>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacaoFaturamento l = new UVWContratoLocacaoFaturamento();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.NumeroParcelas = Convert.ToInt32(i["NumeroParcelas"].ToString());
                l.SeqContratoLocacaoFaturamento = Convert.ToInt32(i["SeqContrato"].ToString());
                l.StatusContratoLocacaoFaturamento = Convert.ToBoolean(i["StatusContratoLocacaoFaturamento"].ToString());
                l.ValorParcela = Convert.ToDouble(i["ValorParcela"].ToString());
                l.Cd_Usr_Registro = i["Cd_Usr_Registro"].ToString();
                l.DataRegistro = Convert.ToDateTime(i["DataRegistro"].ToString());
                l.DiaVencimento = Convert.ToInt32(i["DiaVencimento"].ToString());
                l.DataInicial = Convert.ToDateTime(i["DataInicial"].ToString());
                l.CdTituloEspecie = Convert.ToInt32(i["CdTituloEspecie"].ToString());
                l.CdContaFinanceira = Convert.ToInt32(i["CdContaFinanceira"].ToString());
                l.SeqProdutoFinanceiro = Convert.ToInt32(i["SeqProdutoFinanceiro"].ToString());
                l.TituloEspecieDescricao = i["TituloEspecieDescricao"].ToString();
                l.DescricaoContaFinanceira = i["DescricaoContaFinanceira"].ToString();
                l.DescricaoProdutoFinanceiro = i["DescricaoProdutoFinanceiro"].ToString();
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
            return "UspContratoLocacaoFaturamento";
        }
    }

    public class UVWContratoLocacaoFaturamento
    {

        public int SeqContrato { get; set; }
        public int SeqContratoLocacaoFaturamento { get; set; }
        public Int32 DiaVencimento { get; set; }
        public double ValorParcela { get; set; }
        public bool StatusContratoLocacaoFaturamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataInicial { get; set; }
        public string Cd_Usr_Registro { get; set; }
        public Int32 NumeroParcelas { get; set; }
        public int CdTituloEspecie { get; set; }
        public string TituloEspecieDescricao { get; set; }
        public int SeqProdutoFinanceiro { get; set; }
        public string DescricaoProdutoFinanceiro { get; set; }
        public int CdContaFinanceira { get; set; }
        public string DescricaoContaFinanceira { get; set; }


    }


    public class ParametroContratoLocacaoFaturamento
    {
        public int SeqContrato { get; set; }
        public int SeqContratoLocacaoFaturamento { get; set; }
        public Int32 DiaVencimento { get; set; }
        public bool StatusContratoLocacaoFaturamento { get; set; }
        public DateTime DataInicial { get; set; }
        public Int32 NumeroParcelas { get; set; }

    }
}
