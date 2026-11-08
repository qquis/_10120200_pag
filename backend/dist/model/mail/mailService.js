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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const nodemailer_1 = __importDefault(require("nodemailer"));
const html_mail_adm_1 = __importDefault(require("./mail_adm/html_mail_adm"));
const html_mail_crm_1 = __importDefault(require("./mail_crm/html_mail_crm"));
const modelbase_1 = require("../../model/modelbase");
class serviceMail {
    static transport() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const transporter = nodemailer_1.default.createTransport({
                    service: 'gmail',
                    host: 'smtp.gmail.com',
                    port: 465,
                    secure: true, // true for 465, false for other ports
                    auth: {
                        user: process.env.MAIL_ACOUNT, // generated ethereal user
                        pass: process.env.MAIL_PASSWORD, // generated ethereal password
                    },
                });
                return transporter;
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException('MODEL BASE - mailService', 'transport', error);
                throw new Error('Erro ao criar o transporte de email');
            }
        });
    }
    static sendMail(to_1, subject_1, html_1) {
        return __awaiter(this, arguments, void 0, function* (to, subject, html, format = "ADM", cc = "", bcc = "") {
            try {
                const transporter = yield this.transport();
                let htmlformat = format === "CRM" ? (0, html_mail_crm_1.default)({
                    notificacao_email_title: subject,
                    notificacao_email: to
                }, html) : (0, html_mail_adm_1.default)({
                    notificacao_email_title: subject,
                    notificacao_email: to
                }, html);
                if (modelbase_1.clsTools.ENVIRONMENT() == "DES") {
                    /* AMBIENTE DE DESENVOLVIMENTO - ENVIA APENAS PARA O DESENVOLVEDOR, INDEPENDENTE DO DESTINATÁRIO ORIGINAL */
                    let ENV_MAIL_DESENVOL = process.env.ENVIRONMENT_MAIL || "suporte@oxan.com.br";
                    yield transporter.sendMail({
                        from: process.env.MAIL_ACOUNT, // sender address
                        to: ENV_MAIL_DESENVOL, // list of receivers
                        subject: "DESENVOLVIMENTO (env.ENVIRONMENT_MAIL ou suporte@oxan.com.br) [to_original: " + to + "] [cc_original: " + cc + "] [bcc_original: " + bcc + "] " + subject, // Subject line
                        html: htmlformat, // html body
                        cc: "", // No ambiente de desenvolvimento, não enviar CC
                        bcc: "" // No ambiente de desenvolvimento, não enviar BCC
                    });
                }
                else {
                    /* AMBIENTE DE PRODUÇÃO*/
                    yield transporter.sendMail({
                        from: process.env.MAIL_ACOUNT, // sender address
                        to, // list of receivers
                        subject, // Subject line
                        html: htmlformat, // html body
                        cc, // CC list of receivers
                        bcc // BCC list of receivers
                    });
                }
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException('MODEL BASE - mailService', 'sendMail', error);
                throw new Error('Erro ao enviar o email');
            }
        });
    }
}
exports.default = serviceMail;
