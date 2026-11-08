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
const reportFiscalRouter = (0, express_1.Router)();
const report_1 = __importDefault(require("./report"));
reportFiscalRouter.get('/figurafiscal-produto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.figuraFiscalProduto.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/figurafiscal-nfce-produto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.figuraFiscalProdutoNfce.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/figurafiscal', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.figuraFiscal.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/cbenef-produto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.cbenefProduto.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/cbenef', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.cbenef.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/cbenef-cst', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.cbenefCst.get(req.query);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
reportFiscalRouter.get('/zanthus-tributacao-icms-pdv', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.ZanthusTributacaoIcmsPdv.get(req.query);
        modelbase_1.clsTools.responseDefault.send(res, result);
    }
    catch (error) {
        modelbase_1.clsTools.responseDefault.send(res, {}, "Internal Server Error ${error}", 500);
    }
}));
exports.default = reportFiscalRouter;
