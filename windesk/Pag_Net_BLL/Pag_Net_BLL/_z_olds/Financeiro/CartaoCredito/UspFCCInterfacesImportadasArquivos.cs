using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class UspFCCInterfacesImportadasArquivos: Bll.USPDataContext
    {
        public FiltrosBasicos Filtros { get; set; }
        public UspFCCInterfacesImportadasArquivos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosBasicos();
        }
        public void Select()
        {

            List<UVWFCCInterfacesImportadasArquivos> L = new List<UVWFCCInterfacesImportadasArquivos>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCInterfacesImportadasArquivos l = new UVWFCCInterfacesImportadasArquivos();
                l.SeqArquivo = Convert.ToInt32(i["SeqArquivo"].ToString());
                l.ArquivoProcessado = i["ArquivoProcessado"].ToString();
                l.CodigoInterfaceArquivo = i["CodigoInterfaceArquivo"].ToString();
                l.DataPeriodoFinal = Convert.ToDateTime(i["DataPeriodoFinal"].ToString());
                l.DataPeriodoInicial = Convert.ToDateTime(i["DataPeriodoInicial"].ToString());
                l.DataProcessamento = Convert.ToDateTime(i["DataProcessamento"].ToString());
                l.NumeroDeLinhas = Convert.ToInt32(i["NumeroDeLinhas"].ToString());
                l.Interface = i["Interface"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataProcessamentoInicial", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataProcessamentoFinal", SqlDbType.DateTime, true, Filtros.DataFinal));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCInterfacesImportadasArquivos";
        }
    }

    public class UVWFCCInterfacesImportadasArquivos
    {

        public int SeqArquivo { get; set; }
        public string ArquivoProcessado { get; set; }
        public string Interface { get; set; }
        public DateTime DataProcessamento { get; set; }
        public DateTime DataPeriodoInicial { get; set; }
        public DateTime DataPeriodoFinal { get; set; }
        public string CodigoInterfaceArquivo { get; set; }
        public int NumeroDeLinhas { get; set; }
        public UVWFCCInterfacesImportadasArquivos() { }
    }
}