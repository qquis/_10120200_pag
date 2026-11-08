"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const uuid_1 = require("uuid");
class tbguardian_ticket {
    constructor(gtk_numero, gtk_placa, gtk_data, gtk_pesagemInicialHora, gtk_pesagemFinalHora, gtk_pesagemInicialPeso, gtk_pesagemFinalPeso, gtk_pesagemPesoLiquido) {
        try {
            this.gtk_uuid = (0, uuid_1.v4)();
            this.gtk_seq = 0;
            this.gtk_numero = gtk_numero;
            this.gtk_placa = gtk_placa;
            this.gtk_data = gtk_data;
            this.gtk_pesagemInicialHora = gtk_pesagemInicialHora;
            this.gtk_pesagemFinalHora = gtk_pesagemFinalHora;
            this.gtk_pesagemInicialPeso = gtk_pesagemInicialPeso;
            this.gtk_pesagemFinalPeso = gtk_pesagemFinalPeso;
            this.gtk_pesagemPesoLiquido = gtk_pesagemPesoLiquido;
        }
        catch (e) {
            this.gtk_uuid = '';
            this.gtk_seq = 0;
            this.gtk_numero = 0;
            this.gtk_placa = 'ERROR';
            this.gtk_data = new Date();
            this.gtk_pesagemInicialHora = new Date();
            this.gtk_pesagemFinalHora = new Date();
            this.gtk_pesagemInicialPeso = 0;
            this.gtk_pesagemFinalPeso = 0;
            this.gtk_pesagemPesoLiquido = 0;
        }
    }
}
exports.default = tbguardian_ticket;
