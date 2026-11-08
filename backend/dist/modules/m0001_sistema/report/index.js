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
const reportSistemaRouter = (0, express_1.Router)();
reportSistemaRouter.get("/list", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.List.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaList", e);
    }
}));
reportSistemaRouter.get("/nucleo", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Nucleo.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaNucleo", e);
    }
}));
reportSistemaRouter.get("/nucleoprocedimento", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.NucleoProcedimento.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaNucleoProcedimento", e);
    }
}));
reportSistemaRouter.get("/tarefa", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Tarefa.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaTarefa", e);
    }
}));
reportSistemaRouter.get("/permissao", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Permissao.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaPermissao", e);
    }
}));
reportSistemaRouter.get("/funcao", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Funcao.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaFuncao", e);
    }
}));
reportSistemaRouter.get("/acesso", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.Acesso.get(req.query);
        resp.send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0001 - Sistema", "reportSistemaAcesso", e);
    }
}));
exports.default = reportSistemaRouter;
