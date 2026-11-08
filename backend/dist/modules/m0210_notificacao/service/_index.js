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
const _serviceNotificacao_1 = __importDefault(require("./_serviceNotificacao"));
const modelbase_1 = require("../../../model/modelbase");
const routerServiceNotificacao = (0, express_1.Router)();
routerServiceNotificacao.post('/processar', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let notificacao_cd = parseInt(`${request.query.notificacao_cd}`);
        let parametros = request.query;
        let body = request.body;
        response.send(yield _serviceNotificacao_1.default.GerarEnvio(notificacao_cd, parametros, body));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'processarNotificacao', e);
        return response.json({});
    }
}));
routerServiceNotificacao.post('/teste', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        console.log(request.query);
        let result = yield _serviceNotificacao_1.default.MessageWhatsTeste(parseInt(`${request.query.notificacao_send_tipo_cd}`), `${request.query.notificacao_celular_dd_numero}`, `${request.query.notificacao_send_message}`);
        response.send(modelbase_1.clsTools.responseDefault.get(200, `Teste de envio de mensagem`, result));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('serviceNotificacao', 'teste', e);
        response.send(modelbase_1.clsTools.responseDefault.get(404, `Erro ${e}`, null));
    }
}));
exports.default = routerServiceNotificacao;
