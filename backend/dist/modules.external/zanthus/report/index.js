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
const externalZanthusReportRouter = (0, express_1.Router)();
const report_1 = __importDefault(require("./report"));
externalZanthusReportRouter.get('/tab_mercadoria', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.tabMercadoria.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
externalZanthusReportRouter.get('/tab_finalizadora', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.tabFinalizadora.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
externalZanthusReportRouter.get('/tab_cliente', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.tabCliente.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
externalZanthusReportRouter.get('/tab_regra_icms', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.tabRegrasIcms.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
externalZanthusReportRouter.get('/listvoucher', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield report_1.default.listVoucher.get(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
exports.default = externalZanthusReportRouter;
