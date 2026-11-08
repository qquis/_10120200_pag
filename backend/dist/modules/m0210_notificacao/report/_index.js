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
const _reportNotificacao_1 = __importDefault(require("./_reportNotificacao"));
const modelbase_1 = require("../../../model/modelbase");
const routerReport = (0, express_1.Router)();
let filterReport;
let myReport;
const middlewareReportNotificacaoGetFilterBody = (request, response, next) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let filter = {
            notificacao_send_seq: parseInt(`${request.body.notificacao_send_seq}`),
            notificacao_send_data_ini: modelbase_1.clsTools._datemomentDatStrToDate(`${request.body.notificacao_send_data_ini}`, `DD/MM/YYYY`),
            notificacao_send_data_fim: modelbase_1.clsTools._datemomentDatStrToDate(`${request.body.notificacao_send_data_fim}`, `DD/MM/YYYY`),
            notificacao_send_status_cd: parseInt(`${request.body.notificacao_send_status_cd}`),
            notificacao_send_tipo_cd: parseInt(`${request.body.notificacao_send_tipo_cd}`),
            notificacao_celular_dd_numero: `${request.body.notificacao_celular_dd_numero}`,
            notificacao_email: `${request.body.notificacao_email}`,
            notificacao_whatsapp: parseInt(`${request.body.notificacao_whatsapp}`),
            notificacao_mail: parseInt(`${request.body.notificacao_mail}`),
            notificacao_whatsapp_gp: parseInt(`${request.body.notificacao_whatsapp_gp}`)
        };
        filterReport = filter;
        next();
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('routerReport', 'middlewareReportNotificacaoGetFilterBody', e);
        response.status(500).send({ error: `Erro ao processar o filtro` });
    }
});
routerReport.get('/sendmessage/list', middlewareReportNotificacaoGetFilterBody, (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        myReport = new _reportNotificacao_1.default();
        response.send((yield myReport.rptNotificacaoSendMessageGet(filterReport)).list);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('routerReport', 'get /sendmessage/list', e);
    }
}));
exports.default = routerReport;
