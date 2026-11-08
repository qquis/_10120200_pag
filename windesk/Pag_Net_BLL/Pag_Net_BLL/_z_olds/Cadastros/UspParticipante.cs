using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspParticipante : Bll.USPDataContext
    {
        public ParametrosParticipante Parametros;
        public UspParticipante(Models.modelSistemaUsuario __myconnect)
            : base(__myconnect)
        {
            Parametros = new ParametrosParticipante();
        }

        public void Select()
        {
            List<UVWParticipante> L = new List<UVWParticipante>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWParticipante x = new UVWParticipante();
                x.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                x.Nome = i["Nome"].ToString();
                x.Documento = i["Documento"].ToString();
                x.Informacao = i["Informacao"].ToString();
                x.TipoEntidade = i["TipoEntidade"].ToString();
                x.LinkImage = i["LinkImage"].ToString();
                x.DescricaoCategoria = i["DescricaoCategoria"].ToString();

                L.Add(x);
            }
            base.ViewData = L.ToArray();
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "UspParticipante";
        }

    }

    public class ParametrosParticipante
    {
        public int CdParticipante { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string  CdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public bool DataNascimentoInformacao { get; set; }
        public int SeqTipoParticipanteEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int CdEmpresa { get; set; }

    }
    public class UVWParticipante
    {
        public int CdParticipante { get; set; }
        public string Nome {get; set; }
        public DateTime DataNascimentoInicioAtividade { get; set; }
        public string Documento { get; set; }
        public string Informacao { get; set; }
        public string TipoEntidade { get; set; }
        public string LinkImage { get; set; }
        public string DescricaoCategoria { get; set; }

    }
}
