import modelNotificacao from "../model/_ModelNotificacao"
import { clsBase, clsTools } from "../../../model/modelbase"
import mdNotificacaoParticipante from "../model/mdNotificacaoParticipante"
import mdNotificacaoSendMessage from "../model/mdNotificacaoSend";




type NovaNotificacao = { 
    notificacao_cd: number 
    notificacao_send_tipo_cd?: number, 
    notificacao_email_subject?: string , 
    notificacao_email_title?: string,
    notificacao_email?: string, 
    notificacao_email_cc?: string,
    notificacao_email_co?: string, 
    notificacao_celular_dd_numero?: number
    notificacao_send_message?: string 

}



export default class serviceNotificacao { 

    
    public static async CriarNotificacaoNucleBatch(message: string) { 
        await this.Criar({notificacao_cd : 1009030001,
                          notificacao_send_tipo_cd: 100, 
                            notificacao_send_message : message 
                        } )

    }


    public static async CriarMailBasico(to_email: string, subject: string, title: string, message: string) { 
        await this.Criar({notificacao_cd : 1000000009,
                          notificacao_send_tipo_cd: 110, 
                          notificacao_email : to_email,
                          notificacao_email_subject : subject,
                          notificacao_email_title : title,
                          notificacao_send_message : message                        
                        })
    }

    public static async Criar(dados : NovaNotificacao) : Promise<modelNotificacao> {
        try { 
            let mycls : serviceNotificacao = new serviceNotificacao() 
            let result = await this.GerarEnvio(dados.notificacao_cd, dados, dados)
            return result
        } catch (e) {
            clsTools.PagErrorException('serviceNotificacao', 'Criar', e)
            throw new Error(`${e}`)
        }


    }
    
    public static async GerarEnvio(notificacao_cd: number, parametros : any, body : any): Promise<modelNotificacao>{ 
        let myNotificacao : modelNotificacao = new modelNotificacao()
        try  {



            
            /*Abrir registro*/
            await myNotificacao.notificacao.NotificacaoGet(notificacao_cd)



            /*Obter os destinatarios*/
            await myNotificacao.NotificacaoParticipantesBinding()


            /* GERANDO AS NOTIFICAÇÕES */
            if (myNotificacao.Participantes.length == 0) {
                await myNotificacao.NotificacaoSendMessage.push(await this.processar(myNotificacao, parametros, body, {}  ))

            } else {
                for await (const ParticipanteDestinatario of myNotificacao.Participantes) {
                    await myNotificacao.NotificacaoSendMessage.push(await this.processar(myNotificacao, parametros, body, ParticipanteDestinatario ))
                };
            }

            /* NOTIFICANDO O ARRAYS DAS NOTIFICAÇÕES GERADAS */
            for await (const itemNotificacaoSendMessage of myNotificacao.NotificacaoSendMessage) {

                

                await myNotificacao.Notificar(itemNotificacaoSendMessage)

            }
            
            return myNotificacao;
        } catch (e) {
            clsTools.PagErrorException('serviceNotificacao', 'GerarEnvio', e)
            return myNotificacao;
        }
    }


    private static async processar(myNotificacao : modelNotificacao, parametros : any, infoDados : any, ParticipanteDestinatario : typeof mdNotificacaoParticipante | any ) : Promise<mdNotificacaoSendMessage> { 
        
        let myClsBase : clsBase = new clsBase()
        let dadosNOTIFICACAO : any
        try {
            
            let itemNotificacaoSendMessage : mdNotificacaoSendMessage = new mdNotificacaoSendMessage(0)



            itemNotificacaoSendMessage.notificacao_send_tipo_cd = infoDados.notificacao_send_tipo_cd

            /* Enviar para o e-mail/celular indicado no bory prioritariamente caso contrário enviar para o e-mail do participante*/	
            itemNotificacaoSendMessage.notificacao_email = infoDados.notificacao_email? infoDados.notificacao_email : ParticipanteDestinatario.email_main
            itemNotificacaoSendMessage.notificacao_celular_dd_numero = infoDados.notificacao_celular_dd_numero? infoDados.notificacao_celular_dd_numero : this.CelularNumeroGet(ParticipanteDestinatario)
            
            //console.log(`E-mail infodados ${infoDados.notificacao_email} E-mail part ${ParticipanteDestinatario.email_main} Email Registrado ${itemNotificacaoSendMessage.notificacao_email}`)
            //console.log(ParticipanteDestinatario)
            if (ParticipanteDestinatario) {
                if (ParticipanteDestinatario.isgroup == 1) {
                    itemNotificacaoSendMessage.notificacao_whatsapp_gp = 1
                }
            }

            itemNotificacaoSendMessage.notificacao_email_subject = infoDados.notificacao_email_subject
            itemNotificacaoSendMessage.notificacao_email_title = infoDados.notificacao_email_title
            
            itemNotificacaoSendMessage.notificacao_email_cc = infoDados.notificacao_email_cc
            itemNotificacaoSendMessage.notificacao_email_co = infoDados.notificacao_email_co
            
            
            
            /* Tratamento da Mensagem */
            let MESSAGE = `` 

            if (myNotificacao.notificacao.notificacao_tipo_body_cd == 1) 

                
                if (myNotificacao.notificacao.notificacao_whats_user_show == 1) {
                    MESSAGE = `Olá, ${ParticipanteDestinatario.nome_razao}.\n\n` + infoDados.notificacao_send_message
                } else { 
                    MESSAGE = infoDados.notificacao_send_message
                }
                itemNotificacaoSendMessage.SetMessage(infoDados.notificacao_send_message)

            if (myNotificacao.notificacao.notificacao_tipo_body_cd == 2) {
                
                let result =  await myClsBase.myDataBase.pag.DataGet(`SELECT * FROM ${myNotificacao.notificacao.notificacao_sql} (cdparticipante:= ${ParticipanteDestinatario.cdparticipante})` )
                MESSAGE = JSON.stringify(result)

        
            }

            

            if (myClsBase.ENVIRONMENT_CLASS == 'DES' && itemNotificacaoSendMessage.notificacao_whatsapp == 1) {
                MESSAGE = `- TESTE DESENVOL - ` + MESSAGE
            }

            itemNotificacaoSendMessage.SetMessage(MESSAGE)
            /* _____________________________________________________________________ */


            

            if (myNotificacao.notificacao.notificacao_cd == 10) { 
                itemNotificacaoSendMessage.notificacao_whatsapp = 1
                itemNotificacaoSendMessage.notificacao_send_tipo_cd = parametros.notificacao_send_tipo_cd
                itemNotificacaoSendMessage.notificacao_email = parametros.notificacao_email
                itemNotificacaoSendMessage.notificacao_celular_dd_numero = parametros.notificacao_celular_dd_numero
                itemNotificacaoSendMessage.SetMessage(parametros.notificacao_send_message)
            }


            
            return itemNotificacaoSendMessage

        } catch (e) { 
            clsTools.PagErrorException('serviceNotificacao', 'processar', e)
            throw new Error(`${e}`)
        }
    }


    private static CelularNumeroGet(ParticipanteDestinatario : mdNotificacaoParticipante) : string { 
        return `${ParticipanteDestinatario.celular_dd}${ParticipanteDestinatario.celular_numero}`
    }
    
    public static async MessageWhatsTeste(send_tipo_cd: number, celular_dd_numero: string, message: string) : Promise<any> { 
        
        let result: any
        try { 

                result = await this.Criar({
                notificacao_cd : 10,
                notificacao_send_tipo_cd: send_tipo_cd, 
                notificacao_email : "",
                notificacao_email_subject : "",
                notificacao_email_title : "",
                notificacao_celular_dd_numero: parseInt(celular_dd_numero),
                notificacao_send_message : message                        
            })


        } catch (e) {
            clsTools.PagErrorException('serviceNotificacao', 'MessageTeste', e)
        }
        finally {
            return result
        }
    }
   

}
