using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class SitefLogArquivos: Bll.USPDataContext
    {
        public FiltrosBasicos Filtros { get; set; }
        public SitefLogArquivos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new FiltrosBasicos();
        }
        public void Select()
        {

            List<UVWFCCSitefLogArquivos> L = new List<UVWFCCSitefLogArquivos>();
            base.Select();
            foreach( DataRow i in base.DataTableResult.Rows)
            {
                UVWFCCSitefLogArquivos l = new UVWFCCSitefLogArquivos();
                l.Arquivo = i["Arquivo"].ToString();
                l.DataMovimento = Convert.ToDateTime(i["DataMovimento"].ToString());
                l.TotalRegistros = Convert.ToInt32(i["TotalRegistros"].ToString());
                l.UltimoProcessamento = Convert.ToDateTime(i["UltimoProcessamento"].ToString());
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataMovimento_inicial", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("DataMovimento_final", SqlDbType.DateTime, true, Filtros.DataFinal));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspFCCSitefLogArquivos";
        }
    }

    public class UVWFCCSitefLogArquivos
    {

        public string Arquivo { get; set; }
        public DateTime DataMovimento { get; set; }
        public DateTime UltimoProcessamento { get; set; }
        public int TotalRegistros { get; set; }
        public UVWFCCSitefLogArquivos() { }
    }
}
