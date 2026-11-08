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
const report_1 = __importDefault(require("./report"));
const reportFinanceiroRouter = (0, express_1.Router)();
reportFinanceiroRouter.get("/autorizacaopgto", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.autorizacaoPgtoGet(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "rerpotfinaceiro", e);
    }
}));
reportFinanceiroRouter.get("/autorizacaopgtopag", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.autorizacaoPgtoPagGet(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "rerpotfinaceiro", e);
    }
}));
reportFinanceiroRouter.get("/fluxocaixa", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.fluxoCaixaGet(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "rerpotfinaceiro", e);
    }
}));
reportFinanceiroRouter.get("/formapgto-bluesoft", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.formaPgtoBlueSoft.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "rerpotfinaceiro", e);
    }
}));
exports.default = reportFinanceiroRouter;
