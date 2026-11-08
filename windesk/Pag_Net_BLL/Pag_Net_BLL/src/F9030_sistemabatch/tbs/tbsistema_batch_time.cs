using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch.tbs
{
    public class tbsistema_batch_time : Pag_Net.Bll.Tb
    {
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public int sis_batch_cd { get; set; }
        public int sis_batch_recorrencia_cd { get; set; }
        public DateTime sis_batch_dt_ini { get; set; }
        public DateTime sis_batch_dt_fim { get; set; }
        public DateTime sis_batch_hm_ini { get; set; }
        public DateTime sis_batch_hm_fim { get; set; }
        public int sis_batch_wk_ini { get; set; }
        public int sis_batch_wk_fim { get; set; }
        public int sis_batch_time_seq { get; set; }


        public tbsistema_batch_time() : base() { _constructor(); }

        public void _constructor()
        {
            dtlog_insert = DateTime.Now;
            dtlog_update = DateTime.Now;
            sis_batch_dt_ini = DateTime.Now;
            sis_batch_dt_fim = DateTime.Now;
            sis_batch_hm_ini = DateTime.Now;
            sis_batch_hm_fim = DateTime.Now;
            sis_batch_time_seq = 0;
        }

        public override void __Binding(DataRow i)
        {
            try
            {
                //dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                //dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());

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
                /*
                POSTGRE_SCRIPT = "Select * from " + F0138_10_Recurso_Ctrl_CRUD._VERSION() + "( " +
                        "   vcommand_db:=  '" + BDCommnadType.ToString() + "'" +
                        " , vrecurso_ctrl_seq:= " + this.recurso_ctrl_seq.ToString() +
                        " , vcontrole_reg_seq:= " + this.controle_reg_seq.ToString() +
                        " , vrecurso_ctrl_utiliza_ativo:= " + this.recurso_ctrl_utiliza_ativo.ToString() +
                        " , vat_seq:= " + this.at_seq.ToString() +
                        " , vrecurso_ctrl_observacao:= '" + this.recurso_ctrl_observacao.ToString() + "'" +
                        ")";
                return POSTGRE_SCRIPT;*/
                return ""; 
            }

            catch (Exception ex)
            {
                throw new Exception("Class tbsistema_batch_time - Error: \n" + ex.Message + "\n" + POSTGRE_SCRIPT);
            }
        }

    }
}
