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
const serviceParticipanteRouter = (0, express_1.Router)();
const Service_1 = __importDefault(require("./Service"));
serviceParticipanteRouter.post("/vipimport", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.vipimport.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
serviceParticipanteRouter.post("/redshiftbluesoftimport", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.RedShiftBlueSoftImport.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
serviceParticipanteRouter.post("/apibluesoftimport", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.APIBlueSoftImport.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
serviceParticipanteRouter.post("/grupoeconomicoimport", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.GrupoEconomicoImport.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
serviceParticipanteRouter.post("/apibluesoftatualizarstatuscredito", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.APIBlueSoftAtualizarStatusCredito.start(request.query);
        response.send({ message: "Processo de atualização de status de crédito iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
serviceParticipanteRouter.post("/credito-correcao", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield Service_1.default.APIBlueSoftAtualizarStatusCreditoCorrecao.start(request.query);
        response.send({ message: "Processo de correção de status de crédito iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
exports.default = serviceParticipanteRouter;
