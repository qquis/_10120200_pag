using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0138_Recurso_Ctrl
{
    public class TbRecurso_Ctrl : Pag_Net.Bll.Tb
    {
        public Pag_Net.Bll.F0130_Controle.model_controle_reg CONTROLE_REG;
        public DateTime dtlog_insert { get; set;  }
        public DateTime dtlog_update { get; set; }
        public int  recurso_ctrl_seq {get; set;}
		public int	controle_reg_seq 
        {
            get
            {
                return CONTROLE_REG.controle_reg_seq;
            }
        }
        public int recurso_ctrl_utiliza_ativo { get; set;  }
 		public int 	at_seq	{get; set;}
 		public string recurso_ctrl_observacao {get; set;}

        public TbRecurso_Ctrl() : base() { _constructor(); }
        

        public void _constructor()
        {
            recurso_ctrl_seq = 0;
            CONTROLE_REG = new F0130_Controle.model_controle_reg(12);
            CONTROLE_REG.controle_status_cd = 1;
            CONTROLE_REG.controle_status_pgto_cd = 1;
            at_seq = 0;
            recurso_ctrl_observacao = "";
        }

        public override void __Binding(DataRow i)
        {
            try
            {
                //dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                //dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());

                recurso_ctrl_seq = Convert.ToInt32(i["recurso_ctrl_seq"].ToString());
                recurso_ctrl_utiliza_ativo = Convert.ToInt32(i["recurso_ctrl_utiliza_ativo"].ToString());
                at_seq = Convert.ToInt32(i["at_seq"].ToString());
                recurso_ctrl_observacao = i["recurso_ctrl_observacao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            string POSTGRE_SCRIPT = "";
            try
            {
                POSTGRE_SCRIPT = "Select * from " + F0138_10_Recurso_Ctrl_CRUD._VERSION() + "( " +
                        "   vcommand_db:=  '" + BDCommnadType.ToString() + "'" +
                        " , vrecurso_ctrl_seq:= " + this.recurso_ctrl_seq.ToString() +
                        " , vcontrole_reg_seq:= " + this.controle_reg_seq.ToString() +
                        " , vrecurso_ctrl_utiliza_ativo:= " + this.recurso_ctrl_utiliza_ativo.ToString() +
                        " , vat_seq:= " + this.at_seq.ToString() +
                        " , vrecurso_ctrl_observacao:= '" + this.recurso_ctrl_observacao.ToString() + "'" +
                        ")";
                return POSTGRE_SCRIPT;
            }

            catch (Exception ex)
            {
                throw new Exception("Class TbRecurso_Ctrl - Error: \n" + ex.Message + "\n" + POSTGRE_SCRIPT);
            }
        }


    }
}
