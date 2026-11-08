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
//import serviceResultado from './serviceResultado';
const service_1 = __importDefault(require("./service"));
const serviceFinanceiroRouter = (0, express_1.Router)();
serviceFinanceiroRouter.get('/atualizar', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    let res = [];
    try {
        yield response.send(yield service_1.default.AutorizacaoPgtoAtualizar());
    }
    catch (e) {
        console.log(e);
        response.send({ "Registros": 0 });
    }
}));
serviceFinanceiroRouter.get('/atualizarduplicata', (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield service_1.default.AutorizacaoPgtoAtualizarDuplicata(req.query);
        resp.status(200).send(result);
    }
    catch (e) {
        console.log(e);
        resp.send({});
    }
}));
serviceFinanceiroRouter.get('/movimentocaixabluesoftatualizar', (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield service_1.default.MovimentoCaixaBluesoftAtualizar();
        resp.status(200).send(result);
    }
    catch (e) {
        console.log(e);
        resp.send({});
    }
}));
serviceFinanceiroRouter.post('/formapgto-atualizar', (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.FinanceiroFormaPgto.start(req.query);
        resp.status(200).send({ "status": "ok" });
    }
    catch (e) {
        console.log(e);
        resp.send({ "status": "error" });
    }
}));
exports.default = serviceFinanceiroRouter;
