import { clsTools } from "../../../model/modelbase";

export default class mailLoginCRMCredentialNumber { 
    static async start(mail_crm: string, credentialNumber: string ) : Promise<void> {
        { 

            try { 
            let message : string = `
                    <div style="font-size: 18px;">
                        <div align="left">Olá, tudo bem? </div>
                        <div align="left"> 
                            Segue o código de acesso ao portal de Relacionamento com o cliente OXAN:
                        </div>  
                        <div align="left"> 
                            Código de Acesso: <h1 style="font-size: 28px;"> ${credentialNumber} </h1>
                        </div>
                    </div>  
            `
            await clsTools.mail.sendMail(mail_crm, "Código de Acesso", message, "CRM")

            } catch (e) {
                clsTools.PagErrorException('mailLoginLog', 'start | Erro ao enviar o email de log de login', e)
                throw new Error('Erro ao enviar o email de log de login')
            }
        }
    }
}