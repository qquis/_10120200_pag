require('dotenv/config');
const { Client, LocalAuth } = require('whatsapp-web.js');
const Tools = require("../../tools");

(async () => {
    const client = new Client({
        authStrategy: new LocalAuth({
            clientId: process.env.WHATSAPPWEB_CLIENTID || "PagAdmListContacts"
        }),
        webVersionCache: {
            type: process.env.WHATSAPPWEB_WEBVERSIONCACHE_TYPE || 'remote',
            remotePath: process.env.WHATSAPPWEB_WEBVERSIONCACHE_REMOTEPATH || "https://raw.githubusercontent.com/wppconnect-team/wa-version/main/html/2.2412.6.html",
        },
        puppeteer: {
            args: [
                '--no-sandbox',
                '--disable-setuid-sandbox',
                '--disable-dev-shm-usage',
                '--disable-web-security',
                '--disable-features=VizDisplayCompositor'
            ]
        }
    });

    client.on('qr', qr => {
        Tools.pagConsoleLog('Escaneie o QR Code para conectar:', true);
        require('qrcode-terminal').generate(qr, { small: true });
    });

    client.on('authenticated', () => {
        Tools.pagConsoleLog('Autenticado com sucesso!', true);
                Tools.pagConsoleLog('WhatsApp conectado! Carregando contatos...', true);
        try {
            // Aguarda 3 segundos para garantir que todos os contatos/grupos sejam carregados
            setTimeout(async () => {
                const contacts = await client.getContacts();
                contacts.forEach(contact => {
                        console.log(`Nome: ${contact.name || contact.pushname || contact.number} | Número: ${contact.number} | Tipo: ${contact.isGroup ? 'Grupo' : 'Contato'} | ID: ${contact.id._serialized}`);
                });
                Tools.pagConsoleLog(`Total de contatos encontrados: ${contacts.length}`, true);
                process.exit(0);
            }, 3000);
        } catch (error) {
            Tools.pagConsoleLog(`Erro ao listar contatos: ${error}`, true);
            process.exit(1);
        }
    });

    
    client.on('auth_failure', message => {
        Tools.pagConsoleLog('Falha na autenticação: ' + message, true);
        process.exit(1);
    });

    client.on('disconnected', (reason) => {
        Tools.pagConsoleLog('Desconectado: ' + reason, true);
        process.exit(1);
    });

    client.initialize();
})();