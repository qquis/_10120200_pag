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
const modelbase_1 = require("../../../model/modelbase");
const _ModelNotificacao_1 = __importDefault(require("./_ModelNotificacao"));
const routerModelNotificacao = (0, express_1.Router)();
let myModelNotificacao = new _ModelNotificacao_1.default();
const middlewareQueryGetNotificacoCd = (request, response, next) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        if (request.query.notificacao_cd === undefined) {
            return response.json({});
        }
        myModelNotificacao.notificacao.notificacao_cd = parseInt(`${request.query.notificacao_cd}`);
        yield myModelNotificacao.notificacao.NotificacaoGet(parseInt(`${request.query.notificacao_cd}`));
        next();
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('model_notificacao', 'middlewareQueryGetNotificacoCd', e);
        response.json(myModelNotificacao);
    }
});
routerModelNotificacao.get('/get', middlewareQueryGetNotificacoCd, (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        response.send(myModelNotificacao);
    }
    catch (e) {
        return response.json({});
    }
}));
routerModelNotificacao.post('/addparticipante', middlewareQueryGetNotificacoCd, (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let cdparticipante = parseInt(`${request.query.cdparticipante}`);
        yield myModelNotificacao.NotificacaoAddParticipante(cdparticipante);
        response.send(myModelNotificacao);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('model_notificacao', 'addparticipante', e);
        return response.json({});
    }
}));
routerModelNotificacao.post('/delparticipante', middlewareQueryGetNotificacoCd, (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let cdparticipante = parseInt(`${request.query.cdparticipante}`);
        yield myModelNotificacao.NotificaoDelParticipante(cdparticipante);
        response.send(myModelNotificacao);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('model_notificacao', 'delParticipante', e);
        return response.json({});
    }
}));
routerModelNotificacao.post('/sendmessage/start', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield myModelNotificacao.ProcessNotificacaoSend(parseInt(`${request.query.notificacao_send_seq}`), _ModelNotificacao_1.default.NotificacaoSendProcessStatus.start);
        response.send(myModelNotificacao);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('model_notificacao', 'delParticipante', e);
        return response.json({});
    }
}));
routerModelNotificacao.post('/sendmessage/send', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        //myModelNotificacao.NotificacaoSendMessage.notificacao_send_seq = parseInt(`${request.query.notificacao_send_seq}`)
        yield myModelNotificacao.ProcessNotificacaoSend(parseInt(`${request.query.notificacao_send_seq}`), _ModelNotificacao_1.default.NotificacaoSendProcessStatus.send);
        response.send(myModelNotificacao);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('model_notificacao', 'delParticipante', e);
        return response.json({});
    }
}));
exports.default = routerModelNotificacao;
