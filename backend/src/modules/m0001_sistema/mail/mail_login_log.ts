import { clsTools } from "../../../model/modelbase";

export default class mailLoginLog { 
    static async start(mail_logado: string) : Promise<void> {
        { 

            try { 
            let message : string = `
                <div align="left">Olá </div>
                <div align="left"> 
                    <h1> O usuário ${mail_logado} acabou de fazer login </h1>
                </div>  
            
            `
            await clsTools.mail.sendMail("eliassilva@oxan.com.br", "Login no sistema", message)

            } catch (e) {
                clsTools.PagErrorException('mailLoginLog', 'start | Erro ao enviar o email de log de login', e)
                throw new Error('Erro ao enviar o email de log de login')
            }
        }
    }
}