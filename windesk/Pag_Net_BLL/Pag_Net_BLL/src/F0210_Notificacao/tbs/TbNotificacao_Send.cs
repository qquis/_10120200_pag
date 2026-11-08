using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class TbNotificacao_Send
    {
        public DateTime dtlog_insert                    {get; set;}
		public DateTime dtlog_update                    {get; set;}
		public int	    proc_log_seq                    {get; set;}
        public int      notificacao_cd                  { get; set;  }
		public int	    notificacao_send_seq	        {get; set;}
        public int      notificacao_whatsapp            { get; set; }
        public int      notificacao_whatsapp_gp         { get; set; }
        public int      notificacao_mail                { get; set; }
        public DateTime notificacao_send_data           { get; set; }
        public int notificacao_send_status_cd { get; set; }
        /*
				---- 1		Em processamento
				---- 10 	Pronto para envio 
				---- 20 	Em processo de Envio 
				---- 30 	Mensagem enviada  */
		public int	  notificacao_send_tipo_cd            {get; set;} /*TIPO 100 - Envio imediato*/
        public string notificacao_celular_dd_numero     { get; set; }
        public string notificacao_email                 { get; set;  }
        public string notificacao_email_cc              { get; set; }
        public string notificacao_email_co              { get; set; }
        public string notificacao_email_subject         { get; set; }
        public string notificacao_email_title           { get; set; }
        public int notificacao_mk_cd { get; set;  }


        public TbNotificacao_Send() 
        {
            notificacao_send_seq = 0;
            dtlog_insert = DateTime.Now;
            dtlog_update = DateTime.Now;
            proc_log_seq = 0;
            notificacao_cd = 0;
            notificacao_whatsapp = 0;
            notificacao_whatsapp_gp = 0;
            notificacao_mail = 0;
            notificacao_send_status_cd = 1;
            notificacao_send_data = DateTime.Now;
            notificacao_send_tipo_cd = 100;
            notificacao_celular_dd_numero = "";
            notificacao_email = "";
            notificacao_email_cc = "";        
            notificacao_email_co = "";        
            notificacao_email_subject = "";
            notificacao_email_title = "";
            notificacao_mk_cd = 0;

        
        }
        public TbNotificacao_Send(DataRow i) 
        {
            DataBinding(i);
        }

        public void DataBinding(DataRow i)
        {
            try
            {
                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                //dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
                notificacao_send_seq = Convert.ToInt32(i["notificacao_send_seq"].ToString());
                proc_log_seq = Convert.ToInt32(i["proc_log_seq"].ToString());
                notificacao_cd = Convert.ToInt32(i["notificacao_cd"].ToString());
                notificacao_send_data = Convert.ToDateTime(i["notificacao_send_data"].ToString());
                notificacao_send_status_cd = Convert.ToInt32(i["notificacao_send_status_cd"].ToString());
                notificacao_send_tipo_cd = Convert.ToInt32(i["notificacao_send_tipo_cd"].ToString());
                notificacao_whatsapp = Convert.ToInt32(i["notificacao_whatsapp"].ToString());
                notificacao_whatsapp_gp = Convert.ToInt32(i["notificacao_whatsapp_gp"].ToString());
                notificacao_mail = Convert.ToInt32(i["notificacao_mail"].ToString());
                notificacao_celular_dd_numero = i["notificacao_celular_dd_numero"].ToString();
                notificacao_email = i["notificacao_email"].ToString();

                notificacao_email_cc = i["notificacao_email_cc"].ToString();    
                notificacao_email_co  = i["notificacao_email_co"].ToString();       
                notificacao_email_subject= i["notificacao_email_subject"].ToString();
                notificacao_email_title = i["notificacao_email_title"].ToString();
                notificacao_mk_cd = Convert.ToInt32(i["notificacao_mk_cd"].ToString());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
