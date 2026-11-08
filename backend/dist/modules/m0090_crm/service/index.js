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
const serviceCRMRouter = (0, express_1.Router)();
serviceCRMRouter.get("/status", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).json({ status: "CRM Service is running" });
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - status", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
}));
serviceCRMRouter.post("/sorteio/atualizar", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.CrmSorteio.AtualizarBase.start(req.query);
        res.status(200).json({ message: "Atualização de Base Realizada com sucesso" });
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
}));
serviceCRMRouter.post("/sorteio/gerartemporada", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.CrmSorteio.GerarTemporada.start();
        res.status(200).json({ message: "Geração de Temporada Realizada com sucesso" });
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
}));
serviceCRMRouter.post("/sorteio/exportar", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.CrmSorteio.Exportar.start(req.query);
        res.status(200).json({ message: "Exportação de Temporada Realizada com sucesso" });
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
}));
exports.default = serviceCRMRouter;
