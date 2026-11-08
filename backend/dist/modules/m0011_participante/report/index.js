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
const report_1 = __importDefault(require("./report"));
const reportParticipanteRouter = (0, express_1.Router)();
reportParticipanteRouter.get('/list', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.List.get(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'list', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
reportParticipanteRouter.get('/list-participante-grupo-economico', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.GrupoEconomicoList.get(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'list-participante-grupo-economico', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
reportParticipanteRouter.get('/redshift/list', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Redshift.get(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'list', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
reportParticipanteRouter.get('/list-pagvendedor', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.List.getPagVendedor(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'list-pagvendedor', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
reportParticipanteRouter.get('/list-pagfabricante', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.List.getPagFabricante(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'list-pagfabricante', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
reportParticipanteRouter.get('/tipolist', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.TipoList.get(request.query);
        response.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('reportParticipanteRouter', 'tipolist', e);
        return response.status(500).json({ status: `error ${e}` });
    }
}));
exports.default = reportParticipanteRouter;
