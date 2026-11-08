using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0150_Estatistica
{
    public class TbEst_Info
    {
        public int est_info_seq				            { get; set; }
        public DateTime est_satual_data_ini			    { get; set; }
        public DateTime est_satual_data_fim			    { get; set; }
        public DateTime est_s4_data_ini				    { get; set; }
        public DateTime est_s4_data_fim				    { get; set; }
        public DateTime est_s3_data_ini				    { get; set; }
        public DateTime est_s3_data_fim				    { get; set; }
        public DateTime est_s2_data_ini				    { get; set; }
        public DateTime est_s2_data_fim				    { get; set; }
        public DateTime est_s1_data_ini				    { get; set; }
        public DateTime est_s1_data_fim                 { get; set; }

        public TbEst_Info()
        {
            est_satual_data_ini		    = Convert.ToDateTime("1900-01-01"); 
            est_satual_data_fim			= Convert.ToDateTime("1900-01-01"); 
            est_s4_data_ini				= Convert.ToDateTime("1900-01-01"); 
            est_s4_data_fim				= Convert.ToDateTime("1900-01-01"); 
            est_s3_data_ini				= Convert.ToDateTime("1900-01-01"); 
            est_s3_data_fim				= Convert.ToDateTime("1900-01-01"); 
            est_s2_data_ini				= Convert.ToDateTime("1900-01-01"); 
            est_s2_data_fim				= Convert.ToDateTime("1900-01-01"); 
            est_s1_data_ini				= Convert.ToDateTime("1900-01-01");
            est_s1_data_fim             = Convert.ToDateTime("1900-01-01"); 

        }


        public TbEst_Info(DataRow i)
        {
            est_satual_data_ini = Convert.ToDateTime(i["est_satual_data_ini"].ToString());
            est_satual_data_fim = Convert.ToDateTime(i["est_satual_data_fim"].ToString());
            est_s4_data_ini = Convert.ToDateTime(i["est_s4_data_ini"].ToString());
            est_s4_data_fim = Convert.ToDateTime(i["est_s4_data_fim"].ToString());
            est_s3_data_ini = Convert.ToDateTime(i["est_s3_data_ini"].ToString());
            est_s3_data_fim = Convert.ToDateTime(i["est_s3_data_fim"].ToString());
            est_s2_data_ini = Convert.ToDateTime(i["est_s2_data_ini"].ToString());
            est_s2_data_fim = Convert.ToDateTime(i["est_s2_data_fim"].ToString());
            est_s1_data_ini = Convert.ToDateTime(i["est_s1_data_ini"].ToString());
            est_s1_data_fim = Convert.ToDateTime(i["est_s1_data_fim"].ToString()); 
        }
    }
}
