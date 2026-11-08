import nodemailer from 'nodemailer';
import htmlmailAdm from './mail_adm/html_mail_adm';
import htmlmailCRM from './mail_crm/html_mail_crm';
import { clsTools } from '../../model/modelbase'

export default class serviceMail { 
    private static async transport() : Promise<nodemailer.Transporter> {
        try {
            const transporter = nodemailer.createTransport({
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
        } catch (error) {
            clsTools.PagErrorException('MODEL BASE - mailService', 'transport', error)
            throw new Error('Erro ao criar o transporte de email');
        }    
    }
    
    public static async sendMail(to: string, subject: string, html: any, format: string = "ADM", cc: string = "", bcc : string = "") : Promise<void> {
        try {
            const transporter = await this.transport();

            let htmlformat: string = format === "CRM" ? htmlmailCRM(
                { 
                    notificacao_email_title: subject,
                    notificacao_email: to
                }
                , html
            ) : htmlmailAdm(
                { 
                    notificacao_email_title: subject,
                    notificacao_email: to
                }
                , html
            );


            if (clsTools.ENVIRONMENT() == "DES") {
                
                /* AMBIENTE DE DESENVOLVIMENTO - ENVIA APENAS PARA O DESENVOLVEDOR, INDEPENDENTE DO DESTINATÁRIO ORIGINAL */

                let ENV_MAIL_DESENVOL = process.env.ENVIRONMENT_MAIL || "suporte@oxan.com.br";

                await transporter.sendMail({
                    from: process.env.MAIL_ACOUNT, // sender address
                    to: ENV_MAIL_DESENVOL, // list of receivers
                    subject: "DESENVOLVIMENTO (env.ENVIRONMENT_MAIL ou suporte@oxan.com.br) [to_original: " + to + "] [cc_original: " + cc + "] [bcc_original: " + bcc + "] " + subject, // Subject line
                    html: htmlformat, // html body
                    cc: "", // No ambiente de desenvolvimento, não enviar CC
                    bcc: "" // No ambiente de desenvolvimento, não enviar BCC
                });     

            } else { 
                
                /* AMBIENTE DE PRODUÇÃO*/
                await transporter.sendMail({
                    from: process.env.MAIL_ACOUNT, // sender address
                    to, // list of receivers
                    subject, // Subject line
                    html: htmlformat, // html body
                    cc, // CC list of receivers
                    bcc // BCC list of receivers
                }); 

            }

        } catch (error) {
            clsTools.PagErrorException('MODEL BASE - mailService', 'sendMail', error)
            throw new Error('Erro ao enviar o email');
        }
    }
}