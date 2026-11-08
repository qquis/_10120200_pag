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
const modelSistemaBatchRouter = (0, express_1.Router)();
const modelsistema_Service_1 = __importDefault(require("../model/modelsistema_Service"));
const modelsistema_ServiceBatch_1 = __importDefault(require("./modelsistema_ServiceBatch"));
modelSistemaBatchRouter.get("/service", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        let item = new modelsistema_Service_1.default(Number(req.query.sis_batch_service_cd));
        result = yield item.GetDataQueyAny(req.query);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`modelsistema_ServiceBatch.get`, `service`, e);
    }
    finally {
        resp.status(200).send(result);
    }
}));
modelSistemaBatchRouter.get("/serviceBatch", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        if (!req.query.sis_batch_cd) {
            throw new Error("Parâmetro sis_batch_cd é obrigatório");
        }
        let item = new modelsistema_ServiceBatch_1.default(Number(req.query.sis_batch_cd));
        result = yield item.GetDataQueyAny();
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`modelsistema_ServiceBatch.get`, `service`, e);
        result = { message: "Erro ao consultar serviço batch." };
    }
    finally {
        resp.status(200).send(result);
    }
}));
exports.default = modelSistemaBatchRouter;
