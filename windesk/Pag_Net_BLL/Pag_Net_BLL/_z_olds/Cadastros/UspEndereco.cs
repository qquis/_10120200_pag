using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspEndereco: Bll.USPDataContext
    {
        public ParametrosEndereco Parametros;
        public UspEndereco(Models.modelSistemaUsuario __myconnect)
            : base(__myconnect)
        {
            Parametros = new ParametrosEndereco();
        }

        public void Select()
        {
            List<UVWEndereco> L = new List<UVWEndereco>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWEndereco x = new UVWEndereco();
                x.CdEndereco = Convert.ToInt32(i["CDENDERECO"]);
                x.Logradouro = i["LOGRADOURO"].ToString();
                x.Cep = Convert.ToInt32( i["CEP"].ToString());
                x.Bairro = i["BAIRRO"].ToString();
                x.Municipio = i["MUNICIPIO"].ToString();
                x.CdEstado = i["CDESTADO"].ToString();
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
            return "UspEndereco";
        }

    }

    public class ParametrosEndereco
    {
        public string Logradouro { get; set; }
        private int cep;
        public int Cep
        {
            get
            {
                return cep;

            }
            set
            {
                if (Convert.ToString(value) == "")
                {
                    this.cep = 0;
                }
                else
                {
                    this.cep = value;
                }
            }

        }
        private int cepfim;
        public int CepFim
        {
            get
            {
                return cepfim;

            }
            set
            {
                if (Convert.ToString(value) == "")
                {
                    this.cepfim = 0;
                }
                else
                {
                    this.cepfim = value;
                }
            }

        }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string CdEstado { get; set; }

    }
    public class UVWEndereco
    {
        public int CdEndereco { get; set; }
        public string Logradouro { get; set; }
        private int cep;
        public int Cep
        {
            get
            {
                return cep;

            }
            set
            {
                if (Convert.ToString(value) == "")
                {
                    this.cep = 0;
                }
                else
                {
                    this.cep = value;
                }
            }

        }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string CdEstado { get; set; }

    }
}
