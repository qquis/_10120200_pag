import { emailHelpers } from './email_utils'

export default function htmlmailCRMSimple(notificacao: any, DADOS: object): string {
    return `<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Notificação - Sistema PAG</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f5f5f5; }
        .container { max-width: 600px; margin: 20px auto; background: white; }
        .header { background-color: #2c3e50; color: white; padding: 20px; text-align: center; }
        .content { padding: 20px; }
        .footer { background-color: #34495e; color: white; padding: 15px; text-align: center; font-size: 14px; }
        .logo { max-width: 150px; height: auto; }
        .title { font-size: 20px; margin: 10px 0; }
        .subtitle { font-size: 14px; opacity: 0.8; }
        .info-box { background-color: #ecf0f1; padding: 15px; margin: 15px 0; border-left: 4px solid #3498db; }
        a { color: #3498db; text-decoration: none; }
        a:hover { text-decoration: underline; }
    </style>
</head>
<body>
    <table width="100%" cellpadding="0" cellspacing="0" style="background-color: #f5f5f5;">
        <tr>
            <td align="center" style="padding: 20px;">
                <table class="container" width="600" cellpadding="0" cellspacing="0" style="background-color: white; max-width: 600px;">
                    
                    <!-- Header -->
                    <tr>
                        <td class="header" style="background-color: #2c3e50; color: white; padding: 20px; text-align: center;">
                            <img src="https://static.wixstatic.com/media/6d5282_258ee6a7b0c54af3a70546c97969796f~mv2.png" 
                                 alt="Logo da Empresa" class="logo" style="max-width: 150px; height: auto; margin-bottom: 10px;" />
                            <div class="title" style="font-size: 20px; margin: 10px 0; font-weight: bold;">
                                ${notificacao.notificacao_email_title || 'Notificação do Sistema'}
                            </div>
                            <div class="subtitle" style="font-size: 14px; opacity: 0.8;">
                                Destinatário: ${notificacao.notificacao_email}
                            </div>
                        </td>
                    </tr>
                    
                    <!-- Content -->
                    <tr>
                        <td class="content" style="padding: 20px;">
                            <div style="margin-bottom: 20px;">
                                ${DADOS}
                            </div>
                            
                            <div class="info-box" style="background-color: #ecf0f1; padding: 15px; margin: 15px 0; border-left: 4px solid #3498db;">
                                <p style="margin: 0 0 10px 0; font-weight: bold; color: #2c3e50;">
                                    ℹ️ Informações Importantes
                                </p>
                                <p style="margin: 0 0 8px 0; font-size: 14px;">
                                    Este é um email automático do sistema. Por favor, não responda diretamente a esta mensagem.
                                </p>
                                <p style="margin: 0; font-size: 14px;">
                                    Para dúvidas ou suporte, utilize os canais oficiais de atendimento abaixo.
                                </p>
                            </div>
                        </td>
                    </tr>
                    
                    <!-- Footer -->
                    <tr>
                        <td class="footer" style="background-color: #34495e; color: white; padding: 15px; text-align: center; font-size: 14px;">
                            <p style="margin: 0 0 10px 0; font-weight: bold; font-size: 16px;">
                                Administrativo
                            </p>
                            <p style="margin: 5px 0;">
                                📞 Atendimento: ${emailHelpers.makeClickablePhone('(11) 2782-5200')}
                            </p>
                            <p style="margin: 5px 0;">
                                📧 Email: ${emailHelpers.makeClickableLink('mailto:administrativo@oxan.com.br', 'administrativo@oxan.com.br')}
                            </p>
                            <p style="margin: 5px 0;">
                                🕒 Horário: Segunda a Sexta, das 08h às 18h
                            </p>
                            <p style="margin: 15px 0 0 0; font-size: 12px; opacity: 0.7;">
                                © ${new Date().getFullYear()} - Sistema PAG. Todos os direitos reservados.
                            </p>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
    </table>
</body>
</html>`
}