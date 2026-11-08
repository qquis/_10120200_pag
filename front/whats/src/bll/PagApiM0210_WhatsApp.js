
const {ApiGet, ApiPost} = require("../Api/pag")
const url_message_list_get = '/whatsapp-message-list'
const url_message_start = '/whatsapp-message-start'
const url_message_ok = '/whatsapp-message-ok'

async function whatsAppMessagesList_Get () {
    try {
        data = {
 
                whatsapp_send_seq: 0,
                whatsapp_send_data_ini: '09/05/2023',
                whatsapp_send_data_fim: '09/05/2023',
                whatsapp_send_status: 1,
                whatsapp_send_tipo_cd: 100,
                whatsapp_ddd_numero: ''

        }
        dados = await ApiGet(url_message_list_get, data)
        list = dados.data.result 
        return list

    }
    catch(e)
    {
        console.log(e)
        throw e;
    }
}

async function whatsAppMessagesList_start(whatsapp_send_seq){
    try {
        console.log(`whatsAppMessagesList_start - PARAMETRO RECEBIDO ${whatsapp_send_seq}`)
        data = { }
        dados = await ApiPost(`${url_message_start}?whatsapp_send_seq=${whatsapp_send_seq}`, data)
        list = dados.data.result 
        return list

    }
    catch(e)
    {
        console.log(e)
        throw e;
    }
}

async function whatsAppMessagesList_ok(whatsapp_send_seq){
    try {
        data = {  }
        dados = await ApiPost(`${url_message_ok}?whatsapp_send_seq=${whatsapp_send_seq}`, data)
        list = dados.data.result 
        return list

    }
    catch(e)
    {
        console.log(e)
        throw e;
    }
}

module.exports = {whatsAppMessagesList_Get, whatsAppMessagesList_start, whatsAppMessagesList_ok}