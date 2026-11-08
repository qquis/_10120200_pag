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
const serviceIntegracao_1 = __importDefault(require("./serviceIntegracao"));
const modelintegracao_tipo_1 = __importDefault(require("../model/modelintegracao_tipo"));
const modelbase_1 = require("../../../model/modelbase");
const routerService = (0, express_1.Router)();
let service = new serviceIntegracao_1.default();
routerService.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = [
        {
            url: "/integrar?sis_batch_cd=9999&sis_batch_run_seq=9999",
            info: "M0095 | Integrações - buscar e executar integrações | indicar sis_batch_cd e/ou sis_batch_run_seq"
        },
    ];
    return response.send(help);
}));
routerService.post("/integrar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let sis_batch_run_seq = request.query.sis_batch_run_seq ? parseInt(`${request.query.sis_batch_run_seq}`) : 0;
        let sis_batch_cd = request.query.sis_batch_cd ? parseInt(`${request.query.sis_batch_cd}`) : 0;
        let result = yield service.processar(sis_batch_cd, sis_batch_run_seq);
        return response.send(result);
    }
    catch (e) {
        return response.json({});
    }
}));
routerService.post("/atualizarPendenciaPrecoD1", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let integracao_tipo_cd = request.query.integracao_tipo_cd ? parseInt(`${request.query.integracao_tipo_cd}`) : 0;
        let mymodelintegracao_tipo = new modelintegracao_tipo_1.default();
        mymodelintegracao_tipo.integracao_tipo.integracao_tipo_cd = integracao_tipo_cd;
        yield mymodelintegracao_tipo.GerarPendenciaDePrecos();
        return response.send(mymodelintegracao_tipo);
    }
    catch (e) {
        return response.json({});
    }
}));
routerService.post("/cargaLojaParcial", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        //console.log(`CARGA LOJA INCOMPLETA`)
        let result = yield service.CargaLoja(false);
        return response.send(result);
    }
    catch (e) {
        return response.json({});
    }
}));
routerService.post("/cargaLojaCompleta", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        // CARGA LOJA COMPLETA
        let result = yield service.CargaLoja(true);
        return response.send(result);
    }
    catch (e) {
        return response.json({});
    }
}));
routerService.post("/cacheClear", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        // CARGA LOJA COMPLETA
        if (request.query.integracao_tipo_cd || parseInt(`${request.query.integracao_tipo_cd}`) != 0) {
            yield service.ClearCache(parseInt(`${request.query.integracao_tipo_cd}`));
            return response.send({ message: `Cache Limpo` });
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`serviceIntegracao`, 'cacheClear', e);
        return response.json({ notice: `Erro ao limpar cache ${e}` });
    }
}));
/*
routerService.post("/integrarproduto", async(request: Request, response: Response)  => {
    try {
        console.log(`Executando Sis Batch Seq ${request.query.sis_batch_run_seq}`)

        let sis_batch_run_seq : number = parseInt(`${request.query.sis_batch_run_seq}`)

        return response.send(await service.produto.integrar(sis_batch_run_seq))

    } catch(e) {
        return response.json({})
    }
})*/
exports.default = routerService;
