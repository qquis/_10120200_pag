using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteTipoReg : Pag_Net.Bll.Tb
    {

        public TbParticipanteTipo Tipo { get; set; }
        public int participante_tipo_reg_seq { get; set; }
        public int cdparticipante { get; set; }
        public int participante_tipo_cd { get; set; }
        public int participante_tipo_reg_status { get; set;  }
        public string participante_tipo_descricao
        {
            get { return Tipo.participante_tipo_descricao; }
        }

        public TbParticipanteTipoReg() { _constructor(); }

        public void _constructor()
        {
            Tipo = new TbParticipanteTipo();
            participante_tipo_reg_seq = 0;
            cdparticipante = 0;
            participante_tipo_cd = 0;
            participante_tipo_reg_status = 0;

        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                this.participante_tipo_reg_seq = Convert.ToInt32(i["participante_tipo_reg_seq"].ToString());
                this.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                this.participante_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                this.participante_tipo_reg_status = Convert.ToInt32(i["participante_tipo_reg_status"].ToString());

                this.Tipo.participante_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                this.Tipo.participante_tipo_descricao = i["participante_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }
        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {

            
            string __Db_Pg_script = "";
            __Db_Pg_script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0011_Participante.F0011_02_ParticipanteTipoReg._VERSION() + 
                "(      sqlcommand:= '" + BDCommnadType.ToString() + "'" + 
                "   ,   vparticipante_tipo_reg_seq:= " + this.participante_tipo_reg_seq.ToString() + 
                "   ,   vcdparticipante:= " + this.cdparticipante.ToString() + 
                "   ,   vparticipante_tipo_cd:= " + this.participante_tipo_cd.ToString() + 
                "   ,   vparticipante_tipo_reg_status:= " + this.participante_tipo_reg_status.ToString() + 
                ")"  );


            return __Db_Pg_script;
        }

        /*
        public void __Consultar(Pag_Net.Models.TbSysUserInfo _MyConnect)
        {
            try
            {
                _Binding(_DBSELECT(_MyConnect));
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void __Atualizar(Pag_Net.Models.TbSysUserInfo _MyConnect)
        {
            try { this._DBCRUD(_MyConnect); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }*/
    }
}
