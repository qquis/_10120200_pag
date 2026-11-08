"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const pagToolsDate_1 = __importDefault(require("../../tools/pagToolsDate"));
const f0062_01_guardian_ticket_crud = {
    post: (tbguardian_ticket) => {
        try {
            const query = `select * from f0062_01_guardianticket_crud
                (   '${tbguardian_ticket.gtk_uuid}'
                ,    ${tbguardian_ticket.gtk_seq}
                ,    ${tbguardian_ticket.gtk_numero}
                ,   '${tbguardian_ticket.gtk_placa}'
                ,   '${pagToolsDate_1.default.getStringDateToPostgre(tbguardian_ticket.gtk_data)}'
                ,   '${pagToolsDate_1.default.getStringDateTimeToPostgre(tbguardian_ticket.gtk_pesagemInicialHora)}'
                ,   '${pagToolsDate_1.default.getStringDateTimeToPostgre(tbguardian_ticket.gtk_pesagemFinalHora)}'
                ,    ${tbguardian_ticket.gtk_pesagemInicialPeso}
                ,    ${tbguardian_ticket.gtk_pesagemFinalPeso}
                ,    ${tbguardian_ticket.gtk_pesagemPesoLiquido}
                  )  `;
            return query;
        }
        catch (e) {
            console.log("Error f0062_01_guardian_ticket_crud");
            return '';
        }
    }
};
exports.default = f0062_01_guardian_ticket_crud;
