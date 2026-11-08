using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao.model
{
    public class model_notificacao
    {
        public tbs.TbNotificacao Notificacao; 
        public model_notificacao()
        {
            Notificacao = new tbs.TbNotificacao();
        }

        public void Binding()
        {
            try 
            { 
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addParticipante(Pag_Net.Models.modelSistemaUsuario MyConnect, int cdparticipante)
            { try { NotificacoParticipante(MyConnect, cdparticipante, false); } catch (Exception ex) { throw new Exception(ex.Message); } }

        public void delParticipante(Pag_Net.Models.modelSistemaUsuario MyConnect, int cdparticipante)
        { try { NotificacoParticipante(MyConnect, cdparticipante, false); } catch (Exception ex) { throw new Exception(ex.Message); } }

        public void NotificacoParticipante(Pag_Net.Models.modelSistemaUsuario MyConnect, int cdparticipante, bool excluir)
        {
            string urlApi = "";
            try
            {

                urlApi = string.Format("{0}/notificacao/model/{1}?notificacao_cd={2}&cdparticipante={3}"
                    , MyConnect.PAG_API
                    , excluir? "delparticipante": "addparticipante"
                    , Notificacao.notificacao_cd
                    , cdparticipante.ToString()
                    );

                var resultado = Pag_Net.Bll.RESTAPI.post(urlApi, null);

                if (resultado == "")
                {
                    throw new Exception("Pag/Api sem retorno ! Favor acionar o Suporte");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
    }
}
