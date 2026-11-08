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
//import routerReport from "./report/_index";
//import routerModelNotificacao from "./model/_index";
const service_1 = __importDefault(require("./service"));
const model_1 = __importDefault(require("./model"));
const report_1 = __importDefault(require("./report"));
const sistemaRouter = (0, express_1.Router)();
sistemaRouter.use("/service", service_1.default);
sistemaRouter.use("/model", model_1.default);
sistemaRouter.use("/report", report_1.default);
//Notificacao.use("/report", routerReport)
//Notificacao.use("/model", routerModelNotificacao)
//Notificacao.use("/service", routerServiceNotificacao)
sistemaRouter.get("/", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    return resp.send({ status: "1", info: "Modulo M0001 - Sistema" });
}));
exports.default = sistemaRouter;
/*
    DESENHO PARA AS REQUISIÇÕES

    localhost/sistema/servise/startbackend
    localhost/sistema/servise/login

    localhost/sistema/model/Userget
    localhost/sistema/model/UserInativar


*/ 
