using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteEndereco : Pag_Net.Bll.Tb
    {


        public TbParticipanteEnderecoTipo Tipo { get; set;  }
        public int cdparticipante {get; set; }

        public int endereco_seq { get; set; }
        public int endereco_cep { get; set; }
        public int endereco_tipo_cd { get; set; }
        public string endereco_tipo_descricao
        {
            get { return Tipo.endereco_tipo_descricao;  }
        }

        private string __endereco_logradouro;
        
        public string endereco_logradouro
        {
            get { return __endereco_logradouro; }
            set { __endereco_logradouro = value.ToString().ToUpper().Replace("'", ""); }
        }
        public string endereco_numero { get; set; }

        private string __endereco_bairro;
        public string endereco_bairro
        {
            get { return __endereco_bairro; }
            set { __endereco_bairro = value.ToString().ToUpper().Replace("'", ""); }
        }

        private string __endereco_municipio;
        public string endereco_municipio
        {
            get { return __endereco_municipio; }
            set { __endereco_municipio = value.ToString().ToUpper().Replace("'", ""); }
        }

        public string endereco_uf { get; set; }

        private string __endereco_complemento;
        public string endereco_complemento
        {
            get { return __endereco_complemento; }
            set { __endereco_complemento = value.ToString().ToUpper().Replace("'", ""); }
        }

        public double endereco_latitude { get; set; }

        public double endereco_longitude { get; set; }

        public TbParticipanteEndereco() {_constructor();}

        public TbParticipanteEndereco(
            int          _endereco_cep                      ,
            string       _endereco_logradouro               ,
            string       _endereco_numero                   ,
            string       _endereco_bairro                   ,
            string       _endereco_municipio                ,
            string       _endereco_uf                       ,
            string       _endereco_complemento              ,
            Double       _latitude, 
            Double       _longitude 
            )
        {
            _constructor();
            endereco_seq = 0;
            endereco_tipo_cd = 0;
            endereco_cep                    = _endereco_cep               ;
            endereco_logradouro             = _endereco_logradouro        ;
            endereco_numero                 = _endereco_numero            ;
            endereco_bairro                 = _endereco_bairro            ;
            endereco_municipio              = _endereco_municipio         ;
            endereco_uf                     = _endereco_uf                ;
            endereco_complemento            = _endereco_complemento       ;
            endereco_latitude = _latitude;
            endereco_longitude = _longitude;
        }
        public void _constructor()
        {
            Tipo = new TbParticipanteEnderecoTipo(); 
            cdparticipante = 0;
            endereco_seq = 0;
            endereco_tipo_cd = 0;
            endereco_cep = 0;
            endereco_logradouro = "";
            endereco_numero = "S/N";
            endereco_bairro = "";
            endereco_municipio = "";
            endereco_uf = "";
            endereco_complemento = "";
            endereco_latitude = 0;
            endereco_longitude = 0;
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                Tipo.endereco_tipo_descricao = i["endereco_tipo_descricao"].ToString();
                Tipo.endereco_tipo_cd = Convert.ToInt32(i["endereco_tipo_cd"].ToString());
                cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                endereco_seq = Convert.ToInt32(i["endereco_seq"].ToString());
                endereco_tipo_cd = Convert.ToInt32(i["endereco_tipo_cd"].ToString());
                endereco_cep = Convert.ToInt32(i["endereco_cep"].ToString());
                endereco_logradouro = Convert.ToString(i["endereco_logradouro"].ToString());
                endereco_numero = Convert.ToString(i["endereco_numero"].ToString());
                endereco_bairro = Convert.ToString(i["endereco_bairro"].ToString());
                endereco_municipio = Convert.ToString(i["endereco_municipio"].ToString());
                endereco_uf = Convert.ToString(i["endereco_uf"].ToString());
                endereco_complemento = Convert.ToString(i["endereco_complemento"].ToString());
                endereco_latitude = Convert.ToDouble(i["endereco_latitude"].ToString());
                endereco_longitude = Convert.ToDouble(i["endereco_longitude"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Endereco: " + ex.Message);
            }
        }

        public override string __Db_Pg_script (Models.BDCommandTypes _BDCommandTypes)
        {
            try
            {
                string sqlScript = "SELECT * FROM  " + F0011_03_ParticipanteEndereco._VERSION() +
                            " (	 sqlcommand:= '" + _BDCommandTypes.ToString() + "'" +
                            "  , vcdparticipante:=  " + this.cdparticipante.ToString() +
                            "  , vendereco_seq:= 	" + this.endereco_seq.ToString() +
                            "  , vendereco_tipo_cd:= " + this.endereco_tipo_cd.ToString() +
                            "  , vendereco_cep:= " + this.endereco_cep.ToString() +
                            "  , vendereco_numero:= '" + this.endereco_numero.ToString() + "'" +
                            "  , vendereco_logradouro:= '" + this.endereco_logradouro.ToString().Replace("'", "") + "'" +
                            "  , vendereco_bairro:= '" + this.endereco_bairro.ToString().Replace("'", "") + "'" +
                            "  , vendereco_municipio:= '" + this.endereco_municipio.ToString().Replace("'", "") + "'" +
                            "  , vendereco_complemento:= '" + this.endereco_complemento.ToString().Replace("'", "") + "'" +
                            "  , vendereco_uf:= '" + this.endereco_uf.ToString().Replace("'", "") + "'" +
                            "  , vendereco_latitude:= " + this.endereco_latitude.ToString("0.000000").Replace(",", ".") +
                            "  , vendereco_longitude:= " + this.endereco_longitude.ToString("0.000000").Replace(",", ".") +
                            "  )";
                return sqlScript;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
  



    }
}
