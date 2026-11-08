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
const modelUserConnect_1 = __importDefault(require("./modelUserConnect"));
const routerModelSistema = (0, express_1.Router)();
/* Router ModelUserConnect */
routerModelSistema.get("/userConnectGet", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let myModelmyUserConnect = new modelUserConnect_1.default();
        let sis_us_seq = request.query.sis_us_seq ? parseInt(`${request.query.sis_us_seq}`) : 0;
        let sis_cd = request.query.sis_cd ? parseInt(`${request.query.sis_cd}`) : 0;
        if (sis_us_seq == 0)
            throw new Error(`Código não informado`);
        yield myModelmyUserConnect.consultar(sis_us_seq, sis_cd);
        return response.send(myModelmyUserConnect);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("ModelSistema", "userConnectGet", e);
        response.status(400).send({ "status": "error" });
    }
}));
routerModelSistema.get("/ambiente", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return response.send({ ambiente: process.env.ENVIRONMENT });
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("ModelSistema", "ambiente", e);
        response.status(400).send({ "status": "error" });
    }
}));
exports.default = routerModelSistema;
