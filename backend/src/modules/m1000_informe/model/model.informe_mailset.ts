export default class InformeMailset {
    mail_to: string = ""
    mail_cc: string = ""
    mail_bcc: string = ""
    email_subervisao: string = ""

    constructor() { 

    }

    getDistribuicaoDestinatarios(parametro: any): void {
        if (parametro.email_conferencia && parametro.email_conferencia !== "") {
            this.mail_cc = "jocelio.alves@oxan.com.br; rafael.barreto@oxan.com.br; daniel@oxan.com.br"
            this.mail_bcc = ""
            this.email_subervisao = "distribuicao@oxan.com.br"
        } else  {
            this.mail_cc = ""
            this.mail_bcc = "jocelio.alves@oxan.com.br; rafael.barreto@oxan.com.br; eliassilva@oxan.com.br;DISTRIBUICAO@oxan.com.br" 
            this.email_subervisao = "distribuicao@oxan.com.br"
        }
    }
}