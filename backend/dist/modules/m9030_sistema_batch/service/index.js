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
const serviceSistemaBatch_1 = __importDefault(require("./serviceSistemaBatch"));
const serviceSistemaProcedimento_1 = __importDefault(require("./serviceSistemaProcedimento"));
const serviceSistemaBatchInicializacaoDiaria_1 = __importDefault(require("./serviceSistemaBatchInicializacaoDiaria"));
const serviceSistemaBatchRouter = (0, express_1.Router)();
serviceSistemaBatchRouter.post("/servicerun", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        // Os serviços tem de ser criados para cada chamada post/get
        let myServicePatch = new serviceSistemaBatch_1.default();
        response.send(yield myServicePatch.ServiceRun(request));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.servicerun`, e);
        response.json({});
    }
}));
serviceSistemaBatchRouter.post("/serviceprocessar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        // Os serviços tem de ser criados para cada chamada post/get
        let myServicePatch = new serviceSistemaBatch_1.default();
        response.send(yield myServicePatch.ServiceProcessar(request));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.serviceprocessar`, e);
        response.json({});
    }
}));
serviceSistemaBatchRouter.post("/procedimento-processar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield serviceSistemaProcedimento_1.default.startProcedimento(request.query);
        response.send(modelbase_1.clsTools.responseDefault.get(200, `OK`, result));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.serviceprocessar`, e);
        response.send(modelbase_1.clsTools.responseDefault.get(500, `M9030 _ /procedimento-processar | ${e}`, {}));
    }
}));
serviceSistemaBatchRouter.post("/inicializacao-diaria", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let myService = new serviceSistemaBatchInicializacaoDiaria_1.default();
        response.send(yield serviceSistemaBatchInicializacaoDiaria_1.default.start(request.query));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.inicializacao-diaria`, e);
        response.send(modelbase_1.clsTools.responseDefault.get(500, `M9030 _ /inicializacao-diaria | ${e}`, {}));
    }
}));
exports.default = serviceSistemaBatchRouter;
