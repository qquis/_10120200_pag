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
const report_1 = __importDefault(require("./report"));
const reportForcaVendaRouter = (0, express_1.Router)();
reportForcaVendaRouter.get('/prazo-pgto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.prazopgto.get();
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /prazo-pgto Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/prazo-pgto Error ${e}` });
    }
}));
reportForcaVendaRouter.get('/tabela', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.tabela.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela Error ${e}` });
    }
}));
reportForcaVendaRouter.get('/tabela-versao', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.tabelaVersao.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-versao Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-versao Error ${e}` });
    }
}));
reportForcaVendaRouter.get('/tabela-produto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.tabelaProduto.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-produto Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-produto Error ${e}` });
    }
}));
reportForcaVendaRouter.get('/tabela-padrao', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        if (req.query.mail && req.query.mail == "1") {
            yield report_1.default.tabelaPadrao.mail(req.query);
            return res.status(200).json({ status: 1, info: "E-mail enviado com sucesso" });
        }
        else {
            const result = yield report_1.default.tabelaPadrao.get(req.query);
            res.status(200).json(result);
        }
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-padrao Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-padrao Error ${e}` });
    }
}));
reportForcaVendaRouter.get('/fabricante-fv', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.fabricanteFv.get(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        console.log(`reportForcaVendaRouter.get /fabricante Error ${e}`);
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/fabricante Error ${e}` });
    }
}));
exports.default = reportForcaVendaRouter;
