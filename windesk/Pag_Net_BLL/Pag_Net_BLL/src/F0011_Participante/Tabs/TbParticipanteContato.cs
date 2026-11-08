using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteContato : Pag_Net.Bll.Tb
    {
        public TbParticipanteContatoTipo Tipo { get; set;  }
        public int cdparticipante { get; set;  }
        public int contato_seq { get; set;  }
        public int contato_tipo_cd { get; set;  }
        public string contato_email { get; set;  }
        public int contato_celular_dd { get; set; }
        public int contato_celular_numero { get; set; }
        public string contato_instagram { get; set; }
        public string contato_facebook { get; set; }
        public string contato_tipo_descricao
        {
            get
            {
                return Tipo.contato_tipo_descricao;
            }
        }
        

        public TbParticipanteContato() { _constructor(); }

        public override void __Binding(DataRow i)
        {
            try
            {
                cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                contato_seq = Convert.ToInt32(i["contato_seq"].ToString());
                contato_tipo_cd = Convert.ToInt32(i["contato_tipo_cd"].ToString());
                contato_email = i["contato_email"].ToString();
                contato_celular_dd = Convert.ToInt32(i["contato_celular_dd"].ToString());
                contato_celular_numero = Convert.ToInt32(i["contato_celular_numero"].ToString());
                contato_instagram = i["contato_instagram"].ToString();
                contato_facebook = i["contato_facebook"].ToString();
                Tipo.contato_tipo_cd = this.contato_tipo_cd;
                Tipo.contato_tipo_descricao = i["contato_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Contato: " + ex.Message);
            }

        }

        public TbParticipanteContato(
            int _celular_dd,
            int _celular_numero,
            string _instagram,
            string _facebook
            )
        {
            _constructor();
            cdparticipante = 0;
            contato_seq = 0;
            contato_tipo_cd = 1;
            contato_email = "";
            contato_celular_dd = _celular_dd;
            contato_celular_numero = _celular_numero;
            contato_instagram = _instagram;
            contato_facebook = _facebook;
        }
        public void _constructor()
        {
            cdparticipante = 0;
            contato_seq = 0;
            contato_tipo_cd = 0;
            contato_email = "";
            contato_celular_dd = 11;
            contato_celular_numero = 0;
            contato_instagram = "";
            contato_facebook = "";
            Tipo = new TbParticipanteContatoTipo();

        }

        public override string __Db_Pg_script(BDCommandTypes _BDCommnadType)
        {
            try
            {
                string sqlScript = "SELECT * FROM  " + F0011_04_ParticipanteContato._VERSION() +
                            " (	 sqlcommand:= '" + _BDCommnadType.ToString() + "'" +
                            "  ,	vcdparticipante:= 	" + this.cdparticipante.ToString() + 
		                    "  ,	vcontato_seq:= " + this.contato_seq.ToString() + 
		                    "  ,	vcontato_tipo_cd:= " + this.contato_tipo_cd + 
		                    "  ,	vcontato_email:= '" + this.contato_email.ToString().Replace("'", "") + "'" + 
		                    "  ,	vcontato_celular_dd:= " + this.contato_celular_dd.ToString() + 
		                    "  ,	vcontato_celular_numero:=  " + this.contato_celular_numero.ToString() +
                            "  ,	vcontato_instagram:= '" + this.contato_instagram.ToString().Replace("'", "") + "'" +
                            "  ,	vcontato_facebook:= '" + this.contato_facebook.ToString().Replace("'", "") + "'" + 
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
