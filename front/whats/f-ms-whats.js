require('dotenv/config')
const fs = require('fs');
const { Client, LocalAuth} = require('whatsapp-web.js');

const qrcode = require('qrcode-terminal');
const cron = require('node-cron')
const qrcodeLib = require('qrcode');
const express = require('express');
const cors = require('cors');


const Tools = require ("../../tools")
const {WhatsAppLojaMessageDefault} = require('./src/bll/WhatsApp_Message/WhatsApp_Message_Default')

//const nodeSchedule = require('node-schedule');

let isClientReady = false;
let currentQRCode = null;
let isRestarting = false;
let client; // Declarar a variável client aqui

const app = express();
app.use(cors());
app.use(express.json());



const SESSION_FILE_PATH = './session.json';
let sessionData;
if(fs.existsSync(SESSION_FILE_PATH)) {
    sessionData = require(SESSION_FILE_PATH);
}


const config_client_autStrategy = {
        clientId: process.env.WHATSAPPWEB_CLIENTID || "PagAdm",
        session: sessionData, 
        webVersion: process.env.WHATSAPPWEB_VERSION || '2.3000.1031850069-alpha',                 
        puppeteer: {
            args: [
                '--no-sandbox',
                '--disable-setuid-sandbox',
                '--disable-dev-shm-usage',
                '--disable-web-security',
                '--disable-features=VizDisplayCompositor'
            ]
        }
    }


/*
client = new Client({
    authStrategy: new LocalAuth({
        clientId: "PagClient",
        session: sessionData, 
        webVersion: '2.3000.1031850069-alpha',         
        puppeteer: {
            args: [
                '--no-sandbox',
                '--disable-setuid-sandbox',
                '--disable-dev-shm-usage',
                '--disable-web-security',
                '--disable-features=VizDisplayCompositor'
            ]
        }
    }), 
    webVersionCache: {
        type: 'remote',
        remotePath: "https://raw.githubusercontent.com/wppconnect-team/wa-version/main/html/2.2412.6.html",
    },
});
*/





// Função centralizada para criar o cliente
async function openClient () { 
    client = new Client({
        authStrategy: new LocalAuth(config_client_autStrategy), 
        webVersionCache: {
            type: process.env.WHATSAPPWEB_WEBVERSIONCACHE_TYPE || 'remote',
            remotePath: process.env.WHATSAPPWEB_WEBVERSIONCACHE_REMOTEPATH || "https://raw.githubusercontent.com/wppconnect-team/wa-version/main/html/2.2412.6.html",
        },
    });
    return client;
}

// Função para reinicializar o cliente
async function restartWhatsApp() {
    if (isRestarting) {
        return { success: false, message: 'Reinicialização já em andamento' };
    }

    try {
        isRestarting = true;
        isClientReady = false;
        currentQRCode = null;

        Tools.pagConsoleLog("Iniciando reinicialização do WhatsApp...", true);

        // Destruir o cliente atual
        if (client) {
            try {
                await client.destroy();
                Tools.pagConsoleLog("Cliente destruído com sucesso", true);
            } catch (destroyError) {
                Tools.pagConsoleLog(`Erro ao destruir cliente: ${destroyError}`, true);
            }
        }

        // Aguardar um pouco antes de reinicializar
        await new Promise(resolve => setTimeout(resolve, 3000));

        // Usar a função openClient() para recriar o cliente
        await openClient();

        // Reconfigurar os event listeners
        setupClientEvents();

        // Inicializar o novo cliente
        client.initialize();

        Tools.pagConsoleLog("Cliente WhatsApp reinicializado", true);
        
        return { success: true, message: 'WhatsApp reinicializado com sucesso' };
    } catch (error) {
        Tools.pagConsoleLog(`Erro ao reinicializar WhatsApp: ${error}`, true);
        return { success: false, message: `Erro: ${error.message}` };
    } finally {
        isRestarting = false;
    }
}

// Função para configurar os eventos do cliente
function setupClientEvents() {
    client.on('qr', async (qr) => {
        qrcode.generate(qr, {small: true});
        
        // Gerar QR Code como base64 para a API
        try {
            currentQRCode = await qrcodeLib.toDataURL(qr);
            isClientReady = false;
            Tools.pagConsoleLog("QR Code gerado e disponível na API", true);
        } catch (error) {
            Tools.pagConsoleLog(`Erro ao gerar QR Code: ${error}`, true);
        }
    });

    client.on('ready', async () => {
       // Limpar QR Code quando conectado
        currentQRCode = null;
        isClientReady = true;
        isRestarting = false;

        Tools.pagConsoleLog(` ${process.env.WHATSAPPWEB_CLIENTID} Running...`, true);

    });

    client.on('auth_failure', message => {
        Tools.pagConsoleLog("Conexão falhou", true);
        currentQRCode = null;
        isClientReady = false;
        isRestarting = false;
    });

    client.on('message', async message => {

        currentQRCode = null;
        isClientReady = true;
        isRestarting = false;

        // Filtrar apenas mensagens diretas (não status, não grupos desnecessários)
        if (message.isStatus) {
            //console.log('Status ignorado');
            return; // Ignora atualizações de status
        }
        
        if (message.from === 'status@broadcast') {
            //console.log('Broadcast de status ignorado');
            return; // Ignora broadcasts de status
        }

        // Filtrar apenas mensagens de chat individual (opcional: remover se quiser grupos)
        if (message.from.endsWith('@g.us')) {
            //console.log('Mensagem de grupo ignorada');
            return; // Ignora mensagens de grupo
        }


        const chatid = message.from
        chat = await message.getChat(); 
        
        
        
        hora = new Date(message.timestamp * 1000).toLocaleTimeString()  
        const __notifyName = obterNotifyName(message)
        

        //console.log(`${hora} | Informações da mensagem enviada: `)
        //console.log(`De: ${message.from} | Para: ${message.to} | Hora: ${message.timestamp} Message: ${message.body} - ${__notifyName}`);
        

        const message_last = (await chat.fetchMessages(5)).map(item => item).reverse(); 
    
        let message_chat = []

        message_last.map(item => {
            let itemMessage = { "from": item.from , "to": item.to, "body": item.body, "hora": item.timestamp, "notifyName:": __notifyName } 
            message_chat.push(itemMessage);
        })


        let messageMax = message_chat.length
        if (messageMax > 5) messageMax = 5;

        let MENSAGEM_ANTERIOR_FROM = ""; 
        let MENSAGEM_ANTERIOR_TO = ""; 
        let MENSAGEM_ANTERIOR_BODY = "";
        let MENSAGEM_ANTERIOR_HORA = Math.round(Date.now(),0)
        let MENSAGEM_ATUAL = message.timestamp;
        let MENSAGEM_ANTERIOR_TIME = 0

    
        for (let i = 0; i <= messageMax - 1; i++) {
            MENSAGEM_ANTERIOR_FROM = message_chat[i].from
            MENSAGEM_ANTERIOR_TO = message_chat[i].to
            MENSAGEM_ANTERIOR_BODY = message_chat[i].body.substring(0,3)
            MENSAGEM_ANTERIOR_TIME = message_chat[i].hora
            if (MENSAGEM_ANTERIOR_FROM === process.env.PAG_CEL_USER && MENSAGEM_ANTERIOR_BODY === "Olá")
            {
                break;
            }
            //console.log(`i = ${i} - ${message_chat[i].notifyName} -H. MENS ${Date(MENSAGEM_ANTERIOR_TIME*1000)} [Diferença Hora.A - H.Mens ${(Date.now()/1000) - message.timestamp}] | From: ${message_chat[i].from} - to ${message_chat[i].to} - body: ${message_chat[i].body.substring(0,3)}`);
        }

        if (message_chat.length == 0) { 
            return;
        }

        let message_send =  WhatsAppLojaMessageDefault(0,__notifyName )
        
        //console.log(`Debug: MENSAGEM_ANTERIOR_FROM = ${MENSAGEM_ANTERIOR_FROM}`);
        //console.log(`Debug: process.env.PAG_CEL_USER = ${process.env.PAG_CEL_USER}`);
        //console.log(`Debug: MENSAGEM_ANTERIOR_BODY = ${MENSAGEM_ANTERIOR_BODY}`);

        //if (MENSAGEM_ANTERIOR_FROM === process.env.PAG_CEL_USER && MENSAGEM_ANTERIOR_BODY === "Olá") {

        if (message.from !== message.to){
            if (message.body === "1") message_send = WhatsAppLojaMessageDefault(1, __notifyName)
            if (message.body === "2") message_send = WhatsAppLojaMessageDefault(2, __notifyName)
            if (message.body === "3") message_send = WhatsAppLojaMessageDefault(3, __notifyName)
            if (message.body === "4") message_send = WhatsAppLojaMessageDefault(4, __notifyName)
            if (message.body === "5") message_send = WhatsAppLojaMessageDefault(5, __notifyName)
            if (message.body === "6") message_send = WhatsAppLojaMessageDefault(6, __notifyName)
            if (message.body === "7") message_send = WhatsAppLojaMessageDefault(7, __notifyName)
            if (message.body === "8") message_send = WhatsAppLojaMessageDefault(8, __notifyName)   
            if (message.body === "9") message_send = WhatsAppLojaMessageDefault(9, __notifyName)                    
            //WhatsAppLojaMessageDefault(parseInt(message.body));
        }

        if(message.from !== process.env.PAG_CEL_USER) {
        await client.sendMessage(chatid,message_send, {sendSeen: false})
        }

    })

}



// Endpoints da API
app.get('/api/qrcode', (req, res) => {
    // Só logar se não estiver conectado ou se estiver reiniciando
    if (!isClientReady || isRestarting) {
        Tools.pagConsoleLog("Requisição recebida em /api/qrcode", true);
    }
    
    if (isRestarting) {
        return res.json({ 
            status: 'restarting', 
            message: 'WhatsApp está sendo reinicializado...',
            qrcode: null 
        });
    }

    if (isClientReady) {
        return res.json({ 
            status: 'ready', 
            message: 'WhatsApp já está conectado',
            qrcode: null 
        });
    }
    
    if (!currentQRCode) {
        return res.json({ 
            status: 'waiting', 
            message: 'Aguardando QR Code...',
            qrcode: null 
        });
    }
    
    res.json({ 
        status: 'qrcode', 
        message: 'QR Code disponível',
        qrcode: currentQRCode 
    });
});

app.get('/api/status', (req, res) => {
    // Só logar se não estiver conectado
    if (!isClientReady) {
        Tools.pagConsoleLog("Requisição recebida em /api/status", true);
    }
    
    res.json({ 
        isReady: isClientReady,
        hasQRCode: !!currentQRCode,
        isRestarting: isRestarting
    });
});

app.post('/api/restart', async (req, res) => {
    Tools.pagConsoleLog("Requisição recebida em /api/restart", true);
    
    try {
        const result = await restartWhatsApp();
        Tools.pagConsoleLog(`Resultado do restart: ${JSON.stringify(result)}`, true);
        res.json(result);
    } catch (error) {
        Tools.pagConsoleLog(`Erro no endpoint restart: ${error}`, true);
        res.status(500).json({ 
            success: false, 
            message: `Erro interno: ${error.message}` 
        });
    }
});

app.post('/api/logout', async (req, res) => {
    Tools.pagConsoleLog("Requisição recebida em /api/logout", true);
    
    try {
        if (client) {
            await client.logout();
            Tools.pagConsoleLog("Logout realizado com sucesso", true);
        }
        
        isClientReady = false;
        currentQRCode = null;
        
        res.json({ 
            success: true, 
            message: 'Logout realizado com sucesso' 
        });
    } catch (error) {
        Tools.pagConsoleLog(`Erro ao fazer logout: ${error}`, true);
        res.status(500).json({ 
            success: false, 
            message: `Erro: ${error.message}` 
        });
    }
});

// Iniciar servidor
const PORT = process.env.PORT_WHATSAPP || 3001;
app.listen(PORT, () => {
    Tools.pagConsoleLog(`API QR Code rodando na porta ${PORT}`, true);
});

// Usar openClient() para inicialização inicial
(async () => {
    try {
        await openClient();
        setupClientEvents();
        client.initialize();
        Tools.pagConsoleLog(`Sistema ${process.env.WHATSAPPWEB_CLIENTID} iniciado`, true);
    } catch (error) {
        Tools.pagConsoleLog(`Erro ao iniciar sistema: ${error}`, true);
    }
})();




const obterNotifyName = function (message)
{
    let notifyName = ""
    for (const [key,value] of Object.entries(message))
    {
        if (key === "_data" && typeof value === "object")
        {
            notifyName = value.notifyName; 
        }
    }
    return notifyName
}