import htmlCRMHeaderStyle from './html_mail_crm_headerstyle'
export default function htmlCRMHeader(): string {
        return `<!DOCTYPE html>
    <html lang="pt-BR" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:v="urn:schemas-microsoft-com:vml">
    ${htmlCRMHeaderStyle()}
    <head>
        <title>Notificação - Sistema PAG</title>
        <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
        <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
        <meta name="x-apple-disable-message-reformatting"/>
        <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
        <!--[if !mso]><!-->
        <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet" type="text/css"/>
        <!--<![endif]-->
    </head>`
}