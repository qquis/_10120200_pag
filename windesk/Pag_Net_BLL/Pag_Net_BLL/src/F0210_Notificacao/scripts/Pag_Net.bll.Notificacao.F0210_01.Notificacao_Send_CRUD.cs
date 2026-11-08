using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class F0210_01_Notificacao_Send_Crud
    {
        private static string _VERSION() { return "f0210_01_1012008_notificacao_send_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbNotificacao_Send item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', {15}, {16} )",
                    BDCommnadType.ToString(),
                    item.notificacao_cd.ToString(), 
                    item.notificacao_send_seq.ToString(), 
                    item.notificacao_send_data.ToString("yyyy-MM-dd"), 
                    item.notificacao_send_tipo_cd.ToString(),
                    item.notificacao_send_status_cd.ToString(),
                    item.proc_log_seq.ToString(),
                    item.notificacao_whatsapp.ToString(), 
                    item.notificacao_mail.ToString(), 
                    item.notificacao_celular_dd_numero.ToString(),
                    item.notificacao_email.ToString() == null ? "" : item.notificacao_email.ToString(),
                    item.notificacao_email_cc.ToString() == null ? "" : item.notificacao_email_cc.ToString(),
                    item.notificacao_email_co.ToString() == null ? "" : item.notificacao_email_co.ToString(),
                    item.notificacao_email_subject.ToString() == null ? "" : item.notificacao_email_subject.ToString(),
                    item.notificacao_email_title.ToString() == null ? "" : item.notificacao_email_title.ToString(),
                    item.notificacao_whatsapp_gp.ToString(),
                    item.notificacao_mk_cd.ToString()
                      ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
