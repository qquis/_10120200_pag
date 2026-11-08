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
class mailLoginLog {
    static start(mail_logado) {
        return __awaiter(this, void 0, void 0, function* () {
            {
                try {
                    let message = `
                <div align="left">Olá </div>
                <div align="left"> 
                    <h1> O usuário ${mail_logado} acabou de fazer login </h1>
                </div>  
            
            `;
                    yield modelbase_1.clsTools.mail.sendMail("eliassilva@oxan.com.br", "Login no sistema", message);
                }
                catch (e) {
                    modelbase_1.clsTools.PagErrorException('mailLoginLog', 'start | Erro ao enviar o email de log de login', e);
                    throw new Error('Erro ao enviar o email de log de login');
                }
            }
        });
    }
}
exports.default = mailLoginLog;
