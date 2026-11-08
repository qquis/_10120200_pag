require ('dotenv/config')
const fs = require ('fs')
const { Client, LocalAuth  } = require('whatsapp-web.js');
const qrcode = require('qrcode-terminal');
const cron = require('node-cron')
const qrcodeLib = require('qrcode');
const express = require('express');
const cors = require('cors');

const Tools = require ("../../tools")

let isClientReady = false;
let currentQRCode = null;
let isRestarting = false;
let client; // Declarar a variável client aqui

const app = express();
app.use(cors());
app.use(express.json());

// Configuração do cliente WhatsApp

const SESSION_FILE_PATH = './session.json';
//const SESSION_FILE_PATH = '/app/front/ms_adm/session.json';



let sessionData;
if(fs.existsSync(SESSION_FILE_PATH)) {
    sessionData = require(SESSION_FILE_PATH);
}

const config_client_autStrategy = {
        clientId: process.env.WHATSAPPWEB_CLIENTID || "PagAdm",
        session: sessionData, 
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
        
        // Configurar o cron job apenas uma vez
        if (!global.cronJobConfigured) {
            setupCronJob();
            global.cronJobConfigured = true;
        }
    });

    client.on('auth_failure', message => {
        Tools.pagConsoleLog("Conexão falhou", true);
        currentQRCode = null;
        isClientReady = false;
        isRestarting = false;
    });

    client.on('message', message => {
        // Handle messages if needed
    });
}

// Função para configurar o cron job
function setupCronJob() {
    const m0210_notificacao = require("../Api/src/m0210_notificacao");
    const API_NOTIFICACAO = new m0210_notificacao();
    const TOKEN = process.env.API_PAG_TOKEN;

    API_NOTIFICACAO.filterList.notificacao_send_tipo_cd = process.env.API_PAG_NOTIFICACAO_SEND_TIPO_CD || 100; 
    API_NOTIFICACAO.filterList.notificacao_send_status_cd = 1; 
    API_NOTIFICACAO.filterList.notificacao_whatsapp = 0; 
    API_NOTIFICACAO.filterList.notificacao_send_data_ini = "01/01/1900";
    API_NOTIFICACAO.filterList.notificacao_send_data_fim = "01/01/1900";

    console.log('Token PAG API:', TOKEN);

    let _ultima_mensagem_seq_enviada = 0;
    let isProcessing = false;

    cron.schedule("*/10 * * * * *", async() => {
        if (isProcessing) {
            Tools.pagConsoleLog("Processamento anterior ainda em andamento...", true);
            return;
        }

        isProcessing = true;

        try { 
            let listMessages = await API_NOTIFICACAO.obterListagemDeNotificacoes(); 
            //if (listMessages.length > 0 ){
            //   Tools.pagConsoleLog(`Processamento realizado em [${new Date().toLocaleString()}] _ Mensagens obtidas: ${listMessages.length}`);
            //}

            if (listMessages && listMessages.length > 0) {
                Tools.pagConsoleLog(`Processamento realizado em [${new Date().toLocaleString()}] _ Mensagens obtidas: ${listMessages.length}`);

                let valorSetTimeOut = 500
                if (listMessages.length >= 5) {
                    valorSetTimeOut = 2000
                }
                if (listMessages.length >= 20) {
                    valorSetTimeOut = 3000
                }                

                for await (const item of listMessages) {
                    Tools.pagConsoleLog(`Last-Ms-Seq: ${_ultima_mensagem_seq_enviada} - Ms Seq ${item.notificacao_send_seq} Cel: ${item.notificacao_celular_dd_numero} - Mss ${item.notificacao_send_message.notificacao_send_message}`);

                    await API_NOTIFICACAO.Start(item);

                    let chatid = '';

                    if(item.notificacao_celular_dd_numero){
                        if (item.notificacao_whatsapp_gp == 0) 
                            chatid = '55' + item.notificacao_celular_dd_numero + "@c.us";

                        if (item.notificacao_whatsapp_gp == 1) 
                            chatid = item.notificacao_celular_dd_numero + "@g.us";

                        Tools.pagConsoleLog(`Chat Id: ${chatid}`);

                        if (_ultima_mensagem_seq_enviada != item.notificacao_send_seq) {
                            try { 
                                await client.sendMessage(chatid, item.notificacao_send_message.notificacao_send_message, {sendSeen: false});
                                _ultima_mensagem_seq_enviada = item.notificacao_send_seq;
                                
                                await new Promise(resolve => setTimeout(resolve, valorSetTimeOut));
                            } catch (error) {
                                Tools.pagConsoleLog(`Error Ms-Seq: ${_ultima_mensagem_seq_enviada} : ${error}`, true);
                            }
                        } else {
                            Tools.pagConsoleLog(`Ms Seq Not Send: Duplicate ${item.notificacao_send_seq}`);
                        }
                    } else { 
                        Tools.pagConsoleLog("Erro - CELULAR NÃO INDICADO NA MENSAGEM", true);
                    }

                    await API_NOTIFICACAO.Send(item);
                }
            }
        } catch (error) {
            Tools.pagConsoleLog(`Erro no processamento das mensagens: ${error}`, true);
        } finally {
            isProcessing = false;
        }
    });
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

