// Arquivo de utilitários para melhorar a compatibilidade dos emails com diferentes clientes
export const emailStyles = {
    container: `
        max-width: 600px;
        margin: 0 auto;
        background-color: #ffffff;
        font-family: 'Segoe UI', Arial, sans-serif;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        border-radius: 8px;
        overflow: hidden;
    `,
    
    header: `
        background: linear-gradient(135deg, #2c3e50 0%, #3498db 100%);
        padding: 30px 20px;
        text-align: center;
        color: white;
    `,
    
    content: `
        padding: 30px 25px;
        line-height: 1.6;
        color: #333333;
    `,
    
    footer: `
        background-color: #2c3e50;
        color: white;
        padding: 25px;
        text-align: center;
        font-size: 14px;
    `,
    
    button: `
        display: inline-block;
        padding: 12px 24px;
        background-color: #3498db;
        color: white;
        text-decoration: none;
        border-radius: 6px;
        font-weight: 600;
        margin: 10px 0;
    `,
    
    alert: `
        padding: 15px;
        background-color: #fff3cd;
        border: 1px solid #ffeaa7;
        border-radius: 4px;
        color: #856404;
        margin: 15px 0;
    `,
    
    success: `
        padding: 15px;
        background-color: #d4edda;
        border: 1px solid #c3e6cb;
        border-radius: 4px;
        color: #155724;
        margin: 15px 0;
    `,
    
    info: `
        padding: 15px;
        background-color: #d1ecf1;
        border: 1px solid #bee5eb;
        border-radius: 4px;
        color: #0c5460;
        margin: 15px 0;
    `
};

export const emailHelpers = {
    // Função para garantir links clicáveis
    makeClickableLink: (url: string, text: string) => {
        return `<a href="${url}" style="color: #3498db; text-decoration: none;">${text}</a>`;
    },
    
    // Função para formatar telefone clicável
    makeClickablePhone: (phone: string) => {
        const cleanPhone = phone.replace(/\D/g, '');
        return `<a href="tel:+55${cleanPhone}" style="color: #3498db; text-decoration: none;">${phone}</a>`;
    },
    
    // Função para garantir que imagens tenham fallback
    makeResponsiveImage: (src: string, alt: string, maxWidth: string = '100%') => {
        return `<img src="${src}" alt="${alt}" style="max-width: ${maxWidth}; height: auto; display: block; border: 0;" />`;
    }
};

export default { emailStyles, emailHelpers };