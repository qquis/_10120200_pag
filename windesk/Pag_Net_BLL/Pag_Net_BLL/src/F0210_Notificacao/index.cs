using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0210_Notificacao;
using System.Data;
using Pag_Net.Bll;

namespace Pag_Net.src.F0210_Notificacao
{

    public enum TipoMensagem
    {
        AdmWhats = 100,
        AdmMail = 110, 
        PortariaWhats = 200

    }
    public class _index 
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public src.F0210_Notificacao.model.model_notificacao notificacao;
        public _indexReport report;



        public _index(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            notificacao = new model.model_notificacao();
            report = new _indexReport(MyConnect);
        }

        public void NotificacaoParticipante(string notificacao_cd, string cdParticipante, bool Excluir) 
        {
            try
            {
                notificacao.Notificacao.notificacao_cd = Convert.ToInt32(notificacao_cd);
                notificacao.Notificacao.__Consultar(MyConnect);
                if (notificacao.Notificacao.notificacao_cd == 0)
                    throw new Exception("Notificação não Selecionada / Localizada");
                
                if (cdParticipante == "")
                    throw new Exception("Participante Não indicado");
                notificacao.NotificacoParticipante(MyConnect, Convert.ToInt32(cdParticipante), Excluir);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class Notificacao
    {
        public static void startWhatsAPP(Pag_Net.Models.modelSistemaUsuario MyConnect, TipoMensagem TipoMensagem, int ddd, int NumeroCelular, string Message)
        {
            startWhatsAPP(MyConnect, TipoMensagem, ddd, NumeroCelular, "", 0);
        }
        public static void startWhatsAPP(Pag_Net.Models.modelSistemaUsuario MyConnect, TipoMensagem TipoMensagem, int ddd, int NumeroCelular, string Message, int notificacao_mk_cd)
        {
            startWhatsAPP(MyConnect, 0, TipoMensagem, ddd, NumeroCelular, "", 0);
        }
        public static void startWhatsAPP(Pag_Net.Models.modelSistemaUsuario MyConnect, int notificacao_cd  , TipoMensagem TipoMensagem, int ddd, int NumeroCelular, string Message, int notificacao_mk_cd)
        {
            try
            {
                Model_Notificacao_Send whatsAPP = new Model_Notificacao_Send();
                whatsAPP.notificacao_whatsapp = 1; /*Notificacao do Tipo WhatsAPP */
                whatsAPP.notificacao_mk_cd = notificacao_mk_cd;
                whatsAPP.notificacao_cd = notificacao_cd;
                whatsAPP.notificacao_celular_dd_numero = ddd.ToString() + NumeroCelular.ToString();

                whatsAPP.New_Message(Message);
                switch(TipoMensagem)
                {

                    case F0210_Notificacao.TipoMensagem.AdmWhats:
                        whatsAPP.notificacao_send_tipo_cd = 100;
                        break;                    
                    case F0210_Notificacao.TipoMensagem.PortariaWhats:
                        whatsAPP.notificacao_send_tipo_cd = 200;
                        break;
                    default: 
                        whatsAPP.notificacao_send_tipo_cd = 100;
                        break;
                }


                whatsAPP.SAVE(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Procedimento(Pag_Net.Models.modelSistemaUsuario MyConnect, int notificacao_cd, string texto)
        {
            try
            {
                BDCommand.Post(MyConnect, F0210_50_Notificacao_Procedimento.Post(notificacao_cd, texto));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }



}
