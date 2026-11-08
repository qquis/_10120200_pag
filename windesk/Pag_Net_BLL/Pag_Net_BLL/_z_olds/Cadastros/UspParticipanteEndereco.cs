using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspParticipanteEndereco: Bll.USPDataContext
    {
        public ParametrosParticipanteEndereco Parametros;
        public UspParticipanteEndereco(Models.modelSistemaUsuario __myconnect)
            : base(__myconnect)
        {
            Parametros = new ParametrosParticipanteEndereco();
        }

        public void Select()
        {
            List<UVWParticipanteEndereco> L = new List<UVWParticipanteEndereco>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWParticipanteEndereco x = new UVWParticipanteEndereco();
                x.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                x.Cep = Convert.ToInt32(i["CEP"].ToString());
                x.LogradouroIbge = i["LogradouroIbge"].ToString();
                x.Complemento = i["Complemento"].ToString();
                x.Numero = i["Numero"].ToString();
                x.Bairro = i["Bairro"].ToString();
                x.Municipio = i["Municipio"].ToString();
                x.Estado = i["Estado"].ToString();
                x.Tipo = i["Tipo"].ToString();
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
            return "UspParticipanteEndereco";
        }

    }

    public class ParametrosParticipanteEndereco
    {
        public int CdParticipante { get; set; }
        public int SeqTipoEndereco { get; set; }
        public string LogradouroIndicado { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }

    }
    public class UVWParticipanteEndereco
    {
        public int CdParticipante { get; set; }
        public string LogradouroIbge {get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Tipo { get; set; }
        
    }
}
