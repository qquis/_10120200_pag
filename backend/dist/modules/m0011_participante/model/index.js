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
const modelParticipanteRouter = (0, express_1.Router)();
exports.default = modelParticipanteRouter;
const model_1 = __importDefault(require("./model"));
const modelParticipanteCrm_1 = __importDefault(require("./modelParticipanteCrm"));
/* Participante CRM */
const modelParticipanteCrmRouter = (0, express_1.Router)();
modelParticipanteRouter.get("/consultar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        //let participante = new modelParticipante(request.query)
        if (request.query.cdparticipante) {
            let participante = yield model_1.default.Consultar(request.query);
            response.status(200).json(participante);
        }
        else {
            throw new Error("Código do participante não informado");
        }
    }
    catch (e) {
        response.status(400).json({
            error: `erro ao consultar participante: ${e}`
        });
    }
}));
/* PARTICIPANTE CRM */
modelParticipanteRouter.use('/crm', modelParticipanteCrmRouter);
modelParticipanteCrmRouter.get('/consultar', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let participante_crm = new modelParticipanteCrm_1.default();
        yield participante_crm.consultar(request.query);
        response.status(200).json(participante_crm);
    }
    catch (e) {
        response.status(400).json({
            error: `erro ao consultar participante CRM: ${e}`
        });
    }
}));
modelParticipanteCrmRouter.get('/checkexists', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let participante_crm = new modelParticipanteCrm_1.default();
        let exists = yield participante_crm.checkExists(request.query);
        response.status(200).json({ exists });
    }
    catch (e) {
        response.status(400).json({
            error: `erro ao consultar participante CRM: ${e}`
        });
    }
}));
modelParticipanteCrmRouter.post('/incluir', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let participante = new modelParticipanteCrm_1.default();
        let sucessoInclusao = yield participante.incluir(request.body);
        if (sucessoInclusao) {
            response.status(200).json(participante);
        }
        else {
            response.status(400).json(participante);
        }
    }
    catch (e) {
        response.status(400).json({
            error: `erro ao criar participante CRM: ${e}`
        });
    }
}));
