using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceInfoArquivo: Bll.USPDataContext
    {
        public ParametrosInterfaceInfoArquivo Parametros;
        public UspInterfaceInfoArquivo(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Parametros = new ParametrosInterfaceInfoArquivo();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceInfoArquivo> L = new List<UVWInterfaceInfoArquivo>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceInfoArquivo l = new UVWInterfaceInfoArquivo();
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.SeqTipoArquivo = Convert.ToInt32(i["SeqTipoArquivo"].ToString());
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.SeqArquivoHistorico = Convert.ToInt32(i["SeqArquivoHistorico"].ToString());
                        l.SeqLinha = Convert.ToInt32(i["SeqLinha"].ToString());
                        l.DescricaoTipoArquivo = i["DescricaoTipoArquivo"].ToString();
                        l.DbProcedure = i["DbProcedure"].ToString();
                        l.NomeArquivo = i["NomeArquivo"].ToString();
                        l.PathArquivo = i["PathArquivo"].ToString();
                        l.Linha = i["Linha"].ToString();
                        l.DataEnvio = Convert.ToDateTime(i["DataEnvio"].ToString());
                        l.DataConfirmacao = Convert.ToDateTime(i["DataConfirmacao"].ToString());
                        l.DataGeracao = Convert.ToDateTime(i["DataGeracao"].ToString());
                        L.Add(l);
                    }
                    base.ViewData = L.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
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
            return "UspInterfaceInfoArquivo";
        }
    }

    public class UVWInterfaceInfoArquivo
    {
        public int SeqTipoArquivo { get; set; }
        public int SeqInterfaceInfo { get; set; }
        public int SeqLinha { get; set; }
        public int SeqArquivoHistorico { get; set; }
        public string DescricaoTipoArquivo { get; set; }
        public string DbProcedure { get; set; }
        public string NomeArquivo { get; set; }
        public string PathArquivo { get; set; }
        public string Linha { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime DataConfirmacao { get; set; }
        public DateTime DataGeracao { get; set; }
    }

    public class ParametrosInterfaceInfoArquivo
    {

        public string TipoRelatorio { get; set; }
        public int SeqInterfaceInfo { get; set; }
        public int SeqTipoArquivo { get; set; }
        public DateTime DataGeracao { get; set; }
        public DateTime DataGeracaoFinal { get; set; }
        public int SeqArquivoHistorico { get; set; }
        public int SeqLinha { get; set; }
    }
}

