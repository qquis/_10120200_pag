"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = htmlCRMHeader;
const html_mail_crm_headerstyle_1 = __importDefault(require("./html_mail_crm_headerstyle"));
function htmlCRMHeader() {
    return `<!DOCTYPE html>
    <html lang="pt-BR" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:v="urn:schemas-microsoft-com:vml">
    ${(0, html_mail_crm_headerstyle_1.default)()}
    <head>
        <title>Notificação - Sistema PAG</title>
        <meta content="text/html; charset=utf-8" http-equiv="Content-Type"/>
        <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
        <meta name="x-apple-disable-message-reformatting"/>
        <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
        <!--[if !mso]><!-->
        <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet" type="text/css"/>
        <!--<![endif]-->
    </head>`;
}
