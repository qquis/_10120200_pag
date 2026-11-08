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
const serviceSistema_1 = __importDefault(require("./serviceSistema"));
const routerServiceSistema = (0, express_1.Router)();
routerServiceSistema.post('/startbackend', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield serviceSistema_1.default.BackendStart.defaultStartBackEnd();
        response.send({ status: 'ok' });
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceSistema', 'startbackend', e);
        return response.json({ status: `error ${e}` }).status(500);
    }
}));
routerServiceSistema.post('/login', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const { sis_id, mail, password } = request.body;
        const result = yield serviceSistema_1.default.Login.Userlogin(sis_id, mail, password);
        /*
            14/04/2026
            Lembrar que a senha está sendo lida apenas do campo passwd_web, que, por enquanto, deve ser gerada via insomminia

        */
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceSistema', 'login', e);
        return response.status(401).json({ status: `${e}` });
    }
}));
routerServiceSistema.post('/crmLogin', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const { typeRequest, mail, user_credential_number, user_credential } = request.body;
        //const myServiceSistemaLogin = new serviceSistemaLogin()
        const result = yield serviceSistema_1.default.Login.ClienteCrmLogin(typeRequest, mail, user_credential_number, user_credential);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceSistema', 'login', e);
        return response.status(401).json({ status: `${e}` });
    }
}));
routerServiceSistema.get('/loginCheck', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const { usuario_login_uuid, mail } = request.body;
        //const myServiceSistemaLogin = new serviceSistemaLogin()
        const result = yield serviceSistema_1.default.Login.checkWjt(usuario_login_uuid);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceSistema', 'login', e);
        return response.status(401).json({ status: `${e}` });
    }
}));
routerServiceSistema.get('/passwordget', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let stringToCript = `${req.query.password}`;
        let passwordCript = yield serviceSistema_1.default.PassWord.generate(stringToCript);
        if (!passwordCript)
            res.status(200).send({ "passwordCript": passwordCript });
        else {
            res.status(500).send({ "passwordCript": passwordCript });
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceSistema', 'login', e);
        return res.status(401).json({ status: `${e}` });
    }
}));
exports.default = routerServiceSistema;
