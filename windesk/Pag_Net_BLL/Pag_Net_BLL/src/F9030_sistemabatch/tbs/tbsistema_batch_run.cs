using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.F9030_sistemabatch.tbs
{
    public class tbsistema_batch_run : Pag_Net.Bll.Tb
    {
        public DateTime dtlog_insert { get; set;  }
        public DateTime dtlog_update { get; set; }
        public int sis_batch_cd {get; set; }

        public int sis_batch_run_seq { get; set;}
        public int sis_batch_run_status_cd { get; set;}  
        public DateTime sis_batch_run_dtlog_start { get; set;}
        public DateTime sis_batch_run_dtlog_end { get; set; }
        public int sis_batch_time_seq { get; set; }



        public tbsistema_batch_run() : base() { _constructor(); }


        public void _constructor()
        {
            dtlog_insert = DateTime.Now;
            dtlog_update = DateTime.Now;
            sis_batch_cd = 0;
            sis_batch_run_seq = 0;
            sis_batch_run_status_cd = 10;
            sis_batch_run_dtlog_start = DateTime.Now;
            sis_batch_run_dtlog_end = DateTime.Now;
            sis_batch_time_seq = 0;

        }

        public override void __Binding(DataRow i)
        {
            try
            {
                this.sis_batch_cd = Convert.ToInt32(i["sis_batch_cd"].ToString());
                this.sis_batch_run_seq = Convert.ToInt32(i["sis_batch_run_seq"]);
                this.sis_batch_run_status_cd = Convert.ToInt32(i["sis_batch_run_status_cd"]);
                this.sis_batch_run_dtlog_start = Convert.ToDateTime(i["sis_batch_run_dtlog_start"]);
                this.sis_batch_run_dtlog_end = Convert.ToDateTime(i["sis_batch_run_dtlog_end"]);
                this.sis_batch_time_seq = Convert.ToInt32(i["sis_batch_time_seq"]);

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

                POSTGRE_SCRIPT = "Select * from " + scriptspg.f9030_01_sistema_batch_run_crud._VERSION() + "( " +
                        "   vcommand_db:=  '" + BDCommnadType.ToString() + "'" +
                        " , vsis_batch_cd:= " + this.sis_batch_cd.ToString() +
                        " , vsis_batch_run_seq:= " + this.sis_batch_run_seq.ToString() +
                        " , vsis_batch_run_status_cd:= " + this.sis_batch_run_status_cd.ToString() +
                        " , vsis_batch_run_dtlog_start:= '" + this.sis_batch_run_dtlog_start.ToString("yyyy-MM-dd") + "'" + 
                        " , vsis_batch_run_dtlog_end:= '" + this.sis_batch_run_dtlog_end.ToString("yyyy-MM-dd") + "'" + 
                        " , vsis_batch_time_seq:= " + this.sis_batch_time_seq.ToString() + 
                        ")";
                return POSTGRE_SCRIPT;
            }

            catch (Exception ex)
            {
                throw new Exception("tbsistema_batch_run - Error: \n" + ex.Message + "\n" + POSTGRE_SCRIPT);
            }
        }

    }
}
