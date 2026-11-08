using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class F0210_02_Notificacao_Send_Message_CRUD
    {
        private static string _VERSION() { return "f0210_02_1011960_notificacao_send_message_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbNotificacao_Send_Message item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, '{3}')",
                    BDCommnadType.ToString(),
                    item.notificacao_send_seq.ToString(),
                    item.notificacao_send_message_seq.ToString(),
                    item.notificacao_send_message.ToString()
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
