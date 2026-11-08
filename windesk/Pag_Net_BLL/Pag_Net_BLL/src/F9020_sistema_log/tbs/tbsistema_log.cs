using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.F9020_sistema_log.tbs
{
    public class tbsistema_log : Pag_Net.Bll.Tb
    {
        public DateTime dtlog_insert { get; set;  }
        public int sis_log_seq { get; set;  }
        public int proc_log_seq { get; set; }
        public int sis_nucleo_prc_cd { get; set; }
        public string sis_log_tag { get; set;  }
        public string sis_log_info { get; set;  }
        public int sis_batch_run_seq { get; set;  }

        public tbsistema_log() : base() { _constructor(); }


        public void _constructor()
        {
            dtlog_insert = DateTime.Now;
            sis_log_seq = 0;
            proc_log_seq = 0;
            sis_nucleo_prc_cd = 0;
            sis_log_tag = "";
            sis_log_info = "";
            sis_batch_run_seq = 0; 
        }

        public override void __Binding(DataRow i)
        {
            try
            {
                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                sis_log_seq = Convert.ToInt32(i["sis_log_seq"].ToString());
                sis_nucleo_prc_cd = Convert.ToInt32(i["sis_nucleo_prc_cd"].ToString());
                sis_log_tag = i["sis_log_tag"].ToString();
                sis_log_info = i["sis_log_info"].ToString(); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override string _Db_Pg_script_Insert()
        {
            return "INSERT INTO tbsistema_log " +
                   " (    proc_log_seq " +
                   "    , sis_nucleo_prc_cd " +
                   "    , sis_log_tag " +
                   "    , sis_log_info " +
                   "    , sis_batch_run_seq " +
                   " ) values " +
                   " ( " + 
                           this.proc_log_seq.ToString() +
                   ", "  + this.sis_nucleo_prc_cd.ToString() +
                   ", '" + this.sis_log_tag.ToString().Replace("'", "") + "'" +
                   ", '" + this.sis_log_info.ToString().Replace("'", "") + "'" +
                   ", "  + this.sis_batch_run_seq.ToString().Replace("'", "") +
                   ") "; 
        }
        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            try
            {
                return this._Db_Pg_script_Insert(); 
            }

            catch (Exception ex)
            {
                throw new Exception("tbsistema_batch_run - Error: \n" + ex.Message);
            }
        }

    }
}
