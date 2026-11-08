require ('dotenv/config')
const fs = require ('fs')
const mail_comunicacao = require('./src/mail/account/account_comunicacao')
const Tools = require ("../../tools")
const cron = require('node-cron')

const notificacao = require('./src/Notificacao')


const m0210_notificacao = require("../Api/src/m0210_notificacao");
const API_NOTIFICACAO = new m0210_notificacao() 

API_NOTIFICACAO.filterList.notificacao_send_tipo_cd = 110; 
API_NOTIFICACAO.filterList.notificacao_send_status_cd = 1; 
API_NOTIFICACAO.filterList.notificacao_send_data_ini = "01/01/1900"
API_NOTIFICACAO.filterList.notificacao_send_data_fim = "01/01/1900"




const Enviar = async () => {
    try {
        listMessages = await API_NOTIFICACAO.obterListagemDeNotificacoes(); 
        listMessages.map(async item => {

            //Inicializando o Processo 
            await API_NOTIFICACAO.Start(item);
            


            let email = item.notificacao_email
            let html_body = await notificacao(item)

            //Enviando e-mail 
            if (email) {
                let mailOptions = {
                    from: 'comunicacao@oxan.com.br', 
                    to: email, 
                    subject: item.notificacao_email_subject,
                    //text: 'Teste', 
                    html: html_body //nodemalierhtmlx("TESTE")
                }

                await mail_comunicacao.sendMail(mailOptions)        
            }

            //Finalizando o processo
            await API_NOTIFICACAO.Send(item)

        })
    } catch (error) {
        console.log(`Erro no processamneto de envio de e-mail: ${error}`)
    }
}


cron.schedule(" */25 * * * * * ", async() => {
    Enviar()
        .catch((err) => {console.log(err)})
})

