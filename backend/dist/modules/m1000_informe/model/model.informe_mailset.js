"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class InformeMailset {
    constructor() {
        this.mail_to = "";
        this.mail_cc = "";
        this.mail_bcc = "";
        this.email_subervisao = "";
    }
    getDistribuicaoDestinatarios(parametro) {
        if (parametro.email_conferencia && parametro.email_conferencia !== "") {
            this.mail_cc = "jocelio.alves@oxan.com.br; rafael.barreto@oxan.com.br; daniel@oxan.com.br";
            this.mail_bcc = "";
            this.email_subervisao = "distribuicao@oxan.com.br";
        }
        else {
            this.mail_cc = "";
            this.mail_bcc = "jocelio.alves@oxan.com.br; rafael.barreto@oxan.com.br; eliassilva@oxan.com.br;DISTRIBUICAO@oxan.com.br";
            this.email_subervisao = "distribuicao@oxan.com.br";
        }
    }
}
exports.default = InformeMailset;
