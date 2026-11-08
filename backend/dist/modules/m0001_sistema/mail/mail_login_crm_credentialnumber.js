"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class mailLoginCRMCredentialNumber {
    static start(mail_crm, credentialNumber) {
        return __awaiter(this, void 0, void 0, function* () {
            {
                try {
                    let message = `
                    <div style="font-size: 18px;">
                        <div align="left">Olá, tudo bem? </div>
                        <div align="left"> 
                            Segue o código de acesso ao portal de Relacionamento com o cliente OXAN:
                        </div>  
                        <div align="left"> 
                            Código de Acesso: <h1 style="font-size: 28px;"> ${credentialNumber} </h1>
                        </div>
                    </div>  
            `;
                    yield modelbase_1.clsTools.mail.sendMail(mail_crm, "Código de Acesso", message, "CRM");
                }
                catch (e) {
                    modelbase_1.clsTools.PagErrorException('mailLoginLog', 'start | Erro ao enviar o email de log de login', e);
                    throw new Error('Erro ao enviar o email de log de login');
                }
            }
        });
    }
}
exports.default = mailLoginCRMCredentialNumber;
