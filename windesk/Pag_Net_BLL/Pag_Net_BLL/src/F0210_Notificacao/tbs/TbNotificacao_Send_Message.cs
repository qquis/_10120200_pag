using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class TbNotificacao_Send_Message
    {
        public DateTime dtlog_insert            {get; set;}
		public DateTime dtlog_update            {get; set;}
		public int	    notificacao_send_seq	    {get; set;}
        public int      notificacao_send_message_seq  {get; set; }
        public string   notificacao_send_message   {get; set; }


        public TbNotificacao_Send_Message () { }
        public TbNotificacao_Send_Message(DataRow i) 
        {



            dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
            dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
         
            notificacao_send_seq = Convert.ToInt32(i["whatsapp_send_seq"].ToString());
            notificacao_send_message_seq = Convert.ToInt32(i["whatsapp_send_message_seq"].ToString());
            notificacao_send_message = i["whatsapp_send_message"].ToString();

        }
    }
}
