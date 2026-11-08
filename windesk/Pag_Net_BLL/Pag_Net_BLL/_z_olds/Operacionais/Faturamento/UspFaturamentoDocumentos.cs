using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Faturamento
{
    public class UspFaturamentoDocumentos: Bll.USPDataContext
     {
        public ParametrosFaturamentoDocumentos Parametros { get; set; }

        public UspFaturamentoDocumentos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Parametros = new ParametrosFaturamentoDocumentos();
        }
        public void Select()
        {
            try
            {
                List<UVWFaturamentoDocumentos> L = new List<UVWFaturamentoDocumentos>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWFaturamentoDocumentos l = new UVWFaturamentoDocumentos();
                    l.SeqFaturamento = Convert.ToInt32(i["SeqFaturamento"].ToString());
                    l.SeqFaturamentoOrigem = Convert.ToInt32(i["SeqFaturamentoOrigem"].ToString());
                    l.SeqContratoLocacaoParcela = Convert.ToInt32(i["SeqContratoLocacaoParcela"].ToString());
                    l.CdEmpresa = Convert.ToInt32( i["CdEmpresa"].ToString());
                    l.CdOperacao = Convert.ToInt32( i["CdOperacao"].ToString());
                    l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                    l.DescricaoEmpresa = i["DescricaoEmpresa"].ToString();
                    l.DataEmissao = Convert.ToDateTime(i["DataEmissao"].ToString());
                    l.DataFaturamento = Convert.ToDateTime(i["DataFaturamento"].ToString());
                    l.Ecf = Convert.ToInt32(i["Ecf"].ToString());
                    l.CupomFiscal = Convert.ToInt32(i["CupomFiscal"].ToString());
                    l.NumeroPedido = Convert.ToInt32(i["NumeroPedido"].ToString());
                    l.NumeroNfe = Convert.ToInt32(i["NumeroNfe"].ToString());
                    l.VendedorNome = i["VendedorNome"].ToString();
                    l.ClienteNome = i["ClienteNome"].ToString();
                    l.StatusFaturamento = Convert.ToBoolean( i["StatusFaturamento"].ToString());


                    L.Add(l);
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override object GetParametros()
        {
            return Parametros;
        }
        public override string SQLCommnad()
        {
            return "UspFaturamentoDocumentos";
        }
    }
    
    public class UVWFaturamentoDocumentos
    {
        public int SeqFaturamento { get; set; }
        public int SeqFaturamentoOrigem { get; set; }
        public int CdEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public int NumeroPedido { get; set; }
        public int NumeroNfe { get; set; }
        public int SeqContratoLocacaoParcela { get; set; }
        public int CdParticipanteVendedor { get; set; }
        public int CdParticipanteCliente { get; set; }
        public string DescricaoOperacao { get; set; }
        public string DescricaoEmpresa { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataFaturamento { get; set; }
        public string VendedorNome { get; set; }
        public string ClienteNome { get; set; }
        public bool StatusFaturamento { get; set; }
        
    }
    public class ParametrosFaturamentoDocumentos
    {
        public int SeqFaturamento { get; set; }
        public DateTime DataFaturamentoInicial { get; set; }
        public DateTime DataFaturamentoFinal { get; set; }
        public int CdOperacao { get; set; }
        public int NumeroNota { get; set; }
        public int NumeroPedido { get; set; }
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public bool StatusFaturamento { get; set; }
    }
}







