using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacaoFinanceiro : Bll.USPDataContext
    {

        public ParametroContratoLocacaoFinanceiro Parametros;
        public UspContratoLocacaoFinanceiro(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacaoFinanceiro();
        }

        public void Select()
        {
            List<UVWContratoLocacaoFinanceiro> L = new List<UVWContratoLocacaoFinanceiro>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacaoFinanceiro l = new UVWContratoLocacaoFinanceiro();
                l.CdEmpresa = Convert.ToInt32(i["CdEmpresa"].ToString());
                l.DescricaoEmpresa = i["DescricaoEmpresa"].ToString();
                l.CdOperacao = Convert.ToInt32(i["CdOperacao"].ToString());
                l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                l.CdParticipanteSacado = Convert.ToInt32(i["CdParticipanteSacado"].ToString());
                l.NomeSacado = i["NomeSacado"].ToString();
                l.DataEmissao = Convert.ToDateTime(i["DataEmissao"]);
                l.DataVencimento = Convert.ToDateTime(i["DataVencimento"]);
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
                l.ValorSaldo = Convert.ToDouble(i["ValorSaldo"].ToString());
                l.StatusTitulo = Convert.ToBoolean(i["StatusTitulo"]);
                l.SeqSituacao = Convert.ToInt32(i["SeqSituacao"].ToString());
                l.DescricaoSituacao = i["DescricaoSituacao"].ToString();
                l.SeqTitulo = Convert.ToInt32(i["SeqTitulo"].ToString());
                l.DescricaoTituloEspecie = i["DescricaoTituloEspecie"].ToString();
                l.CdTituloEspecie = Convert.ToInt32(i["CdTituloEspecie"].ToString());
                l.SelecionadoParaExecucaoDeComando = false;
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
            return "USPContratoLocacaoFinanceiro";
        }

    }
    public class UVWContratoLocacaoFinanceiro
    {
        public int CdEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int CdParticipanteSacado { get; set; }
        public string NomeSacado { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public double ValorSaldo { get; set; }
        public bool StatusTitulo { get; set; }
        public int SeqSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public bool SelecionadoParaExecucaoDeComando { get; set; }
        public int SeqTitulo { get; set; }
        public string DescricaoTituloEspecie { get; set; }
        public int CdTituloEspecie { get; set; }
    }

    public class ParametroContratoLocacaoFinanceiro
    {
        public int SeqContrato { get; set; }
        public DateTime DataVencimentoInicial { get; set; }
        public DateTime DataVencimentoFinal { get; set; }
    }

}
