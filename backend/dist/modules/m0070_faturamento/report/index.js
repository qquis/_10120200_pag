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
const reportFaturamentoRouter = (0, express_1.Router)();
const report_1 = __importDefault(require("./report"));
const modelbase_1 = require("../../../model/modelbase");
const report_2 = __importDefault(require("./report"));
reportFaturamentoRouter.get('/statusList', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.faturamentoStatus.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportFaturamentoRouter | statusList | ${e}`);
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFaturamentoRouter.get('/operacaoconferencia', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.faturamentoOperacaoConferencia.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportFaturamentoRouter | operacaoconferencia | ${e}`);
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFaturamentoRouter.get('/export', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.faturamentoExport.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportFaturamentoRouter | Export | ${e}`);
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFaturamentoRouter.get('/tipoContrato', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefault = {};
    try {
        let result = yield report_1.default.faturamentoContratoTipo.get(req.query);
        responseDefault = modelbase_1.clsTools.responseDefault.get(200, "Sucesso", result);
    }
    catch (e) {
        responseDefault = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error", e);
    }
    finally {
        res.status(responseDefault.status).json(responseDefault);
    }
}));
reportFaturamentoRouter.get('/contrato', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let responseDefault = {};
    try {
        let result = yield report_1.default.faturamentoContrato.get(req.query);
        responseDefault = modelbase_1.clsTools.responseDefault.get(200, "Sucesso", result);
    }
    catch (e) {
        responseDefault = modelbase_1.clsTools.responseDefault.get(500, "Internal Server Error", e);
    }
    finally {
        res.status(responseDefault.status).json(responseDefault);
    }
}));
reportFaturamentoRouter.get('/list', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_2.default.faturamentoList.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportFaturamentoRouter | list | ${e}`);
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
exports.default = reportFaturamentoRouter;
