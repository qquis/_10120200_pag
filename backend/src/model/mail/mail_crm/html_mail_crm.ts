import htmlCRMHeaderStyle from "./html_mail_crm_header"
export default function htmlmailCRM(notificacao: any, DADOS: object): string {

        return `<!DOCTYPE html>
    
        ${htmlCRMHeaderStyle()}
        <body style="margin: 0; padding: 20px; background-color: #f5f5f5; font-family: 'Inter', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
            
            <div class="email-container">
                <!-- Header Section -->
                <div class="header">
                    <img class="logo" 
                         src="https://static.wixstatic.com/media/6d5282_258ee6a7b0c54af3a70546c97969796f~mv2.png" 
                         alt="Logo da Empresa" 
                         style="max-width: 180px; height: auto; margin-bottom: 15px; border-radius: 4px;" />
                    
                    <div class="title" style="font-size: 24px; font-weight: 600; margin: 15px 0 10px 0; text-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);">
                        ${notificacao.notificacao_email_title || 'Notificação do Sistema'}
                    </div>

                </div>

                <!-- Content Section -->
                <div class="content">
                    <div class="content-section">
                        ${DADOS}
                    </div>
                    
                    <div class="divider"></div>
                    
                    <!-- Additional Information -->
                    <div style="padding: 20px; background-color: #f8f9fa; border-radius: 6px; border-left: 4px solid #3498db;">
                        <p style="margin: 0 0 10px 0; font-size: 16px; font-weight: 600; color: #2c3e50;">
                            📧 Informações Importantes
                        </p>
                        <p style="margin: 0 0 8px 0; font-size: 14px; color: #666;">
                            Este é um email automático do sistema. Por favor, não responda diretamente a esta mensagem.
                        </p>
                        <p style="margin: 0 0 8px 0; font-size: 14px; color: #666;">
                            Para dúvidas ou suporte, utilize os canais oficiais de atendimento abaixo.
                        </p>

                        <p style="margin: 10px 0 10px 0; font-size: 16px; font-weight: 600; color: #2c3e50;">
                        📧 Contatos
                        </p>
                        <p style="margin: 0 0 8px 0; font-size: 14px; color: #666;">
                            📞 Atendimento: <a href="tel:+551127825200" style="color: #3498db; text-decoration: none;">(11) 2782-5200</a>
                        </p>
                        <p style="margin: 0 0 8px 0; font-size: 14px; color: #666;">
                            📧 Email: <a href="mailto:sac@oxan.com.br" style="color: #3498db; text-decoration: none;">sac@oxan.com.br</a>
                        </p>
                        <p style="margin: 0 0 8px 0; font-size: 14px; color: #666;">
                            🕒 Horário de Atendimento: Segunda a Sexta, das 08h às 18h
                        </p>
                    </div>
                </div>

            </div>

            <!-- Fallback for older email clients -->
            <div style="display: none; mso-hide: all;">
                OXAN | Tecnologia - ${notificacao.notificacao_email_title}
            </div>
            
        </body>
        </html>`
}