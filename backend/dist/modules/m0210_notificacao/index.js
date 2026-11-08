"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const _index_1 = __importDefault(require("./report/_index"));
const _index_2 = __importDefault(require("./model/_index"));
const _index_3 = __importDefault(require("./service/_index"));
const Notificacao = (0, express_1.Router)();
Notificacao.use("/report", _index_1.default);
Notificacao.use("/model", _index_2.default);
Notificacao.use("/service", _index_3.default);
exports.default = Notificacao;
//get  http://localhost:57895/notificacao/listNotificacaoesObter 
//get  http://localhost:57895/notificacao/model/ 
//post http://localhost:57895/notificacao/model/ 
//post http://localhost:57895/notificacao/cmd/start 
//post http://localhost:57895/notificacao/cmd/send
