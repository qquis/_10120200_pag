using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class SitefLogArquivosRegistros: Bll.USPDataContext
    {
        public FiltrosBasicos Filtros { get; set; }
        public SitefLogArquivosRegistros(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosBasicos();
        }
        public void Select()
        {

            List<UVWFCCSitefLogArquivosRegistros> L = new List<UVWFCCSitefLogArquivosRegistros>();
            base.Select();
            foreach( DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCSitefLogArquivosRegistros l = new UVWFCCSitefLogArquivosRegistros();
                l.Arquivo = i["Arquivo"].ToString();
                l.Autorizador = i["Autorizador"].ToString();
                l.CdProdutoFinanceiro = i["CdProdutoFinanceiro"].ToString();
                l.EstadoTransacao = i["EstadoTransacao"].ToString();
                l.CartaoReferencia = i["CartaoReferencia"].ToString();
                l.CodigoAutorizacao = i["CodigoAutorizacao"].ToString();
                l.OrigemLancamento = i["OrigemLancamento"].ToString();
                l.Linha = Convert.ToInt32(i["linha"].ToString());
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
                l.LogDataHora = Convert.ToDateTime(i["LogDataHora"].ToString());
                l.HoraTransacao = Convert.ToDateTime(i["HoraTransacao"].ToString());
                l.LogTipoTransacao = i["LogTipoTransacao"].ToString();
                l.LogNSU = i["LogNSU"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("Arquivo", SqlDbType.VarChar, true, Filtros.Arquivo));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCSitefLogArquivosRegistros";
        }
    }

    public class UVWFCCSitefLogArquivosRegistros
    {

        public string Autorizador { get; set; }
        public string CdProdutoFinanceiro { get; set; }
        public string EstadoTransacao { get; set; }
        public string CartaoReferencia { get; set; }
        public double Valor { get; set; }
        public string CodigoAutorizacao { get; set; }
        public string OrigemLancamento { get; set; }
        public int Linha { get; set; }
        public DateTime LogDataHora { get; set; }
        public DateTime HoraTransacao { get; set; }
        public string Arquivo { get; set; }
        public string LogNSU { get; set; }
        public string LogTipoTransacao { get; set; }
        public UVWFCCSitefLogArquivosRegistros() { }
    }
}

