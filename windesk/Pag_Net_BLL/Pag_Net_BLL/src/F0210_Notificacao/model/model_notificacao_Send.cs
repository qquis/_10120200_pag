using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class Model_Notificacao_Send : TbNotificacao_Send
    {
        public TbNotificacao_Send_Message[] MENSAGENS;
        public Model_Notificacao_Send()
            : base()
        {


        }
        public Model_Notificacao_Send(DataRow i) : base(i) { }

        public void SAVE(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.proc_log_seq == 0)
                {
                    /* INSERIR REGISTRO */
                    MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30103);
                    this.proc_log_seq = MyConnect.SEQUENCIAL_DE_PROCESSO;
                    DataTable DtWhats = BDCommand.get_DataTable(MyConnect, F0210_01_Notificacao_Send_Crud.Post(MyConnect, Models.BDCommandTypes.DBINSERT, this));
                    this.DataBinding(DtWhats.Rows[0]);
                    this.Save_Message(MyConnect);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void New_Message(string MESSAGE)
        {
            try
            {

                TbNotificacao_Send_Message NEW_MESSAGE = new TbNotificacao_Send_Message();
                NEW_MESSAGE.notificacao_send_message = MESSAGE;
                List<TbNotificacao_Send_Message> list = new List<TbNotificacao_Send_Message>();

                if (this.MENSAGENS != null)
                {
                    foreach (TbNotificacao_Send_Message i in this.MENSAGENS)
                    {
                        list.Add(i);
                    }
                }
                list.Add(NEW_MESSAGE);
                this.MENSAGENS = list.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Save_Message(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                foreach (TbNotificacao_Send_Message i in MENSAGENS)
                {
                    i.notificacao_send_seq = this.notificacao_send_seq;
                    DataTable DtWhats = BDCommand.get_DataTable(MyConnect, F0210_02_Notificacao_Send_Message_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, i));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }


 
}
