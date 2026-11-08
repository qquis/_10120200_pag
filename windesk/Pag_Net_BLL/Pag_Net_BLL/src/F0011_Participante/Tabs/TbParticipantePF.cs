using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipante_PF: Pag_Net.Bll.Tb
    {
        public int      cdparticipante               { get; set; }
        public string   pf_sexo                         { get; set; }
        public DateTime pf_data_nascimento              { get; set; } 
        public string   pf_documento_rg			        {get; set;}
        public string   pf_documento_cnh			    {get; set; }
        public DateTime pf_documento_cnh_validade     { get; set; }
        
        public TbParticipante_PF() { _constructor(); }

        public void _constructor()
        {
            cdparticipante= 0;
            pf_sexo = "M";
            pf_data_nascimento = Convert.ToDateTime("1900-01-01");
            pf_documento_rg= "0";
            pf_documento_cnh = "0";
            pf_documento_cnh_validade = Convert.ToDateTime("1900-01-01");
        }

        public override void __Binding(DataRow i)
        {
            try
            {
                cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                pf_sexo = i["pf_sexo"].ToString();
                pf_data_nascimento = Convert.ToDateTime(i["pf_data_nascimento"].ToString());
                pf_documento_rg = i["pf_documento_rg"].ToString();
                pf_documento_cnh = i["pf_documento_cnh"].ToString();
                pf_documento_cnh_validade = Convert.ToDateTime(i["pf_documento_cnh_validade"].ToString()); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string __Db_Pg_script(BDCommandTypes __BDCommnadType)
        {
            return "select * from " + F0011_Participante.F0011_05_ParticipantePF._VERSION() +
                    "(	    sqlcommand:= '" + __BDCommnadType.ToString() + "'" +
                    "  ,	vcdparticipante:= " + this.cdparticipante.ToString() +
                    "  ,	vpf_seq:= 0" +
                    "  ,	vpf_sexo:= '" + this.pf_sexo.ToString().ToUpper() + "'" +
                    "  ,	vpf_data_nascimento:= '" + this.pf_data_nascimento.ToString("yyyy-MM-dd") + "'" +
                    "  ,	vpf_documento_rg:= '" + this.pf_documento_rg.ToString().Replace("'", "") + "'" +
                    "  ,	vpf_documento_cnh:= '" + this.pf_documento_cnh.ToString().Replace("'", "") + "'" +
                    "  ,	vpf_documento_cnh_validade:= ' " + this.pf_documento_cnh_validade.ToString("yyyy-MM-dd") + "'" +
                    ")";

        }
        
    }
}
