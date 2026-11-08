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
const modelbase_1 = require("../../../model/modelbase");
const express_1 = require("express");
const service_1 = __importDefault(require("./service"));
const routerService = (0, express_1.Router)();
routerService.get("/aplicar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    let status = false;
    try {
        status = yield service_1.default.AplicarPrecos(request.query);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M0045`, `serviceAplicacao.aplicar Error`, e);
    }
    finally {
        response.send({ "status": status });
    }
}));
routerService.post("/BlueSoftAtualizarProdutosPendentes", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield service_1.default.integrarBlueSoftPrecoAplicado();
        return response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M0045`, `serviceAplicacao.BlueSoftAtualizarProdutosPendentes Error`, e);
        return response.json({});
    }
}));
routerService.post("/BlueSoftAtualizarAgendamentosPendentes", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield service_1.default.integrarBlueSoftPrecoAgedando();
        return response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M0045`, `serviceAplicacao.BlueSoftAtualizarAgendamentosPendentes Error`, e);
        return response.json({});
    }
}));
exports.default = routerService;
