"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = htmlmail;
const htmlheader_1 = __importDefault(require("./htmlheader"));
function htmlmail(notificacao, DADOS) {
    return `<!DOCTYPE html>
    
        ${(0, htmlheader_1.default)()}
        <body style="background-color:rgb(236, 229, 229); margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;">
            <table style="background-color: #555555" border="0" cellpadding="0" cellspacing="0" class="image_block block-1" role="presentation" style="mso-table-lspace: 0pt; mso-table-rspace: 0pt;" width="100%">
                <tr>
                    <td class="pad" style="width:100%;padding-right:0px;padding-left:0px;">
                    <div align="left" class="alignment" style="display: inline-block; line-height:10px">
                            <img alt="Logo" src="https://static.wixstatic.com/media/6d5282_258ee6a7b0c54af3a70546c97969796f~mv2.png" 
                                    style="display: block; height: auto; border: 0; max-width: 200px; width: 100%;" title="Logo" width="200"/>
                        </div>
                    <span style="display: inline-block; color: #ffffff; font-size: 22px;">${notificacao.notificacao_email_title}</span>
                    </td>
                </tr>
                <tr>
                    <td class="pad" style="padding-bottom:10px;padding-left:50px;padding-right:50px;text-align:center;width:100%;">
                            <span style="display: inline-block; color:rgb(61, 64, 137); font-size: 22px;"> Destinatário (E-mail) ${notificacao.notificacao_email}</span>
                    </td>
                </tr>
            </table>
            ${DADOS}
            <p style="margin: 0; font-size: 18px; text-align: left; mso-line-height-alt: 21px;"><strong>Administrativo </strong></p>
            <p style="margin: 0; font-size: 18px; text-align: left; mso-line-height-alt: 21px;">Atendimento (11) 2782 5200 _ administrativo@oxan.com.br | Horário 08h - 18h</p>
    
            </body>
        </html>`;
}
