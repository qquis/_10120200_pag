const Tools = require ("../../../tools/index")
const {ApiGet, ApiPost} = require("../src/Api/pag")

class m0210_notificacao {
    
    url_notificacao_list_get () {
        return '/notificacao/report/sendmessage/list'
    }

    url_notificacao_start() {
        return "/notificacao/model/sendmessage/start?notificacao_send_seq="
    }

    url_notificacao_send() {
        return "/notificacao/model/sendmessage/send?notificacao_send_seq="
    }
    constructor() {
        
        this.filterList = {
            notificacao_send_seq: 0,
            notificacao_send_data_ini: '01/01/2024',
            notificacao_send_data_fim: '01/01/1900',
            notificacao_send_status_cd: 0,
            notificacao_send_tipo_cd: 0,
            notificacao_celular_dd_numero: '',
            notificacao_email: '',
            notificacao_whatsapp: 0, 
            notificacao_mail: 0, 
            notificacao_whatsapp_gp: 0 
        }

        this.data = { 
        
            proc_log_seq: 0, 
            notificacao_cd: 0,
            notificacao_send_seq: 0,
            notificacao_send_data:  Tools.Date_br_current(),
            notificacao_send_tipo_cd: 0, 
            notificacao_send_status_cd: 0,
            notificacao_whatsapp:  0,
            notificacao_whatsapp_gp:  0,
            notificacao_mail:  0,
            notificacao_celular_dd_numero: 0 ,
            notificacao_email: "",
            notificacao_email_cc:  "",
            notificacao_email_co: "",
            notificacao_email_subject:  "",
            notificacao_email_title:  "",
            notificacao_send_message:  "TESTE"
        }
    }

    async obterListagemDeNotificacoes() {
        try { 
            const dados = await ApiGet(this.url_notificacao_list_get(), this.filterList)
            const list = dados.data
            return list
        } catch (error) {
            console.log(`Erro ao obter listagem de notificações: ${error.message}`)
            return { 
                error: error.code ? error.code : 'UNKNOWN_ERROR',
            }
        }
    }

    async Start(item) {
        if (item !== undefined) {
           const dados = await ApiPost(`${this.url_notificacao_start()}${item.notificacao_send_seq}`)
             return dados.data 
         }
     }

    async Send(item) {
        if (item !== undefined) {
            const dados = await ApiPost(`${this.url_notificacao_send()}${item.notificacao_send_seq}`)
              return dados.data 
          }
      }
    


}

module.exports = m0210_notificacao;
