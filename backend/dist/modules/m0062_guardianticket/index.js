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
const express_1 = require("express");
const Service_1 = __importDefault(require("./Service"));
const tbguardian_ticket_1 = __importDefault(require("./tbguardian_ticket"));
const Tools_1 = __importDefault(require("../../tools/Tools"));
const guardianticket = (0, express_1.Router)();
const __service = new Service_1.default();
exports.default = guardianticket.post("/m0062_guardianticket_incluir", (Request, Response) => __awaiter(void 0, void 0, void 0, function* () {
    let tbguardian_ticket_result = new tbguardian_ticket_1.default(0, '', new Date(), new Date(), new Date(), 0, 0, 0);
    try {
        //console.log(myTools._dataConvertStrtoDate(Request.body.gtk_pesagemInicialHora)) 
        const data_ini = Tools_1.default._dataMomentoStrToDate(Request.body.gtk_data, 'DD/MM/YYYY HH:mm:ss');
        const { gtk_numero, gtk_placa, gtk_data, gtk_pesagemInicialHora, gtk_pesagemFinalHora, gtk_pesagemInicialPeso, gtk_pesagemFinalPeso, gtk_pesagemPesoLiquido } = Request.body;
        tbguardian_ticket_result = (yield __service.IncluirNovoTicket(new tbguardian_ticket_1.default(gtk_numero, gtk_placa, Tools_1.default._dataMomentoStrToDate(gtk_data, 'DD/MM/YYYY HH:mm:ss'), Tools_1.default._dataMomentoStrToDate(gtk_pesagemInicialHora, 'DD/MM/YYYY HH:mm:ss'), Tools_1.default._dataMomentoStrToDate(gtk_pesagemFinalHora, 'DD/MM/YYYY HH:mm:ss'), gtk_pesagemInicialPeso, gtk_pesagemFinalPeso, gtk_pesagemPesoLiquido)));
        return Response.json(tbguardian_ticket_result);
    }
    catch (e) {
        return Response.json(tbguardian_ticket_result);
    }
}));
