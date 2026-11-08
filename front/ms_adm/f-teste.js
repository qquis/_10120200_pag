require ('dotenv/config')
const Tools = require ("../../tools")
const fs = require ('fs')
const { Client, LocalAuth  } = require('whatsapp-web.js');
const qrcode = require('qrcode-terminal');
const cron = require('node-cron')

const m0210_notificacao = require("../Api/src/m0210_notificacao");

const API_NOTIFICACAO = new m0210_notificacao() 

API_NOTIFICACAO.filterList.notificacao_send_tipo_cd = 100; 
API_NOTIFICACAO.filterList.notificacao_send_status_cd = 1; 
API_NOTIFICACAO.filterList.notificacao_whatsapp = 1; 
API_NOTIFICACAO.filterList.notificacao_send_data_ini = "01/01/1900"
API_NOTIFICACAO.filterList.notificacao_send_data_fim = "01/01/1900"


let _ultima_mensagem_seq_enviada = 0;

const SESSION_FILE_PATH = './session.json';
let sessionData;
if(fs.existsSync(SESSION_FILE_PATH)) {
    sessionData = require(SESSION_FILE_PATH);
}

const wwebVersion = '2.2407.3';
const client = new Client({
    authStrategy: new LocalAuth({
        clientId: "Pag",
        session: sessionData, 
        /*dataPath: './WhatsPortaria', */
        puppeteer: {
		args: ['--no-sandbox']}
    }), 
    webVersionCache: {
        type: 'remote',
        remotePath: "https://raw.githubusercontent.com/wppconnect-team/wa-version/main/html/2.2412.54.html",
        /*remotePath: `https://raw.githubusercontent.com/wppconnect-team/wa-version/main/html/${wwebVersion}.html`,*/
    },

});


client.on('qr', qr => {
    qrcode.generate(qr, {small: true});
});

client.on('ready', async () => {
    Tools.pagConsoleLog("MS ADM Running...", true)
              5511994299919
    chatid = "5511994299919" + "@c.us"
    Tools.pagConsoleLog(`Chat Id: ${chatid}`)
    client.sendMessage(chatid, "TESTE DE MENSAGEM")
                .then(ok => { console.log("MENSAGEM ENVIADA")            })
                .catch(error => {Tools.pagConsoleLog(`Error Ms-Seq: ${_ultima_mensagem_seq_enviada} : ${error}`, true)});

});

client.on('auth_failure', message => {
    Tools.pagConsoleLog("Conexão falhou", true)

})

client.on('message', message => {

})
client.initialize();

