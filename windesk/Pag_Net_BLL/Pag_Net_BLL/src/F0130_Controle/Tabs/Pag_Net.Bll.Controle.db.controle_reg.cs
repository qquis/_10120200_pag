using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg
    {
        public int controle_cd { get; set; }
        public int controle_reg_numero { get; set; }
        public DateTime controle_reg_data { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_status_cd { get; set; }
        public int controle_status_pgto_cd { get; set; }
        public int proc_log_seq { get; set; }

        public TbControle_Reg()
        {
            controle_cd = 0;
            controle_reg_numero = 0;
            controle_reg_seq = 0;
            controle_reg_data = DateTime.Now;
            controle_status_cd = 0;
            controle_status_pgto_cd = 0;
        }

        public TbControle_Reg(

             int _controle_cd,
             int _controle_reg_numero,
             DateTime _controle_reg_data,
             int _controle_reg_seq,
             int _controle_status_cd,
             int _controle_status_pgto_cd
            )
        {

            controle_cd = _controle_cd;
            controle_reg_numero = _controle_reg_numero;
            controle_reg_data = _controle_reg_data;
            controle_reg_seq = _controle_reg_seq;
            controle_status_cd = _controle_status_cd;
            controle_status_pgto_cd = _controle_status_pgto_cd;
            proc_log_seq = 0;

        }


        public TbControle_Reg(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_reg_numero = Convert.ToInt32(i["controle_reg_numero"]);
            controle_reg_data = Convert.ToDateTime(i["controle_reg_data"]);
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"]);
            controle_status_cd = Convert.ToInt32(i["controle_status_cd"]);
            controle_status_pgto_cd = Convert.ToInt32(i["controle_status_pgto_cd"]);
            proc_log_seq = Convert.ToInt32(i["proc_log_seq"]); 
        }


    }
}
