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
const model_1 = __importDefault(require("./model"));
const modelFaturamentoRouter = (0, express_1.Router)();
const submodelFaturamentoRouterContrato = (0, express_1.Router)();
modelFaturamentoRouter.use('/contrato', submodelFaturamentoRouterContrato);
modelFaturamentoRouter.get('/faturamento', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefaut = {};
    try {
        let result = yield model_1.default.controle.get(req.query);
        responseDefaut = modelbase_1.clsTools.responseDefault.get(200, "Success", result);
    }
    catch (e) {
        responseDefaut = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error");
    }
    finally {
        res.status(responseDefaut.status).send(responseDefaut);
    }
}));
submodelFaturamentoRouterContrato.post('/', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefaut = {};
    try {
        let result = yield model_1.default.contrato.post(req.body);
        responseDefaut = modelbase_1.clsTools.responseDefault.get(200, "Success", result);
    }
    catch (e) {
        responseDefaut = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error");
    }
    finally {
        res.status(responseDefaut.status).send(responseDefaut);
    }
}));
submodelFaturamentoRouterContrato.get('/', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefaut = {};
    try {
        let result = yield model_1.default.contrato.get(req.query);
        responseDefaut = modelbase_1.clsTools.responseDefault.get(200, "Success", result);
    }
    catch (e) {
        responseDefaut = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error");
    }
    finally {
        res.status(responseDefaut.status).send(responseDefaut);
    }
}));
submodelFaturamentoRouterContrato.post('/inativar', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefaut = {};
    try {
        let result = yield model_1.default.contrato.contratoInativar(req.query);
        responseDefaut = modelbase_1.clsTools.responseDefault.get(200, "Success", result);
    }
    catch (e) {
        responseDefaut = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error");
    }
    finally {
        res.status(responseDefaut.status).send(responseDefaut);
    }
}));
submodelFaturamentoRouterContrato.get('/produto-list', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefaut = {};
    try {
        let result = yield model_1.default.contrato.consultarContratoProdutoItensFornecedor(req.query);
        responseDefaut = modelbase_1.clsTools.responseDefault.get(200, "Success", result);
    }
    catch (e) {
        responseDefaut = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error");
    }
    finally {
        res.status(responseDefaut.status).send(responseDefaut);
    }
}));
exports.default = modelFaturamentoRouter;
