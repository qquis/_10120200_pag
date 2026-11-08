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
const reportInterfaceRouter = (0, express_1.Router)();
reportInterfaceRouter.get('/interface-dial-venda', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.reportInterfaceJohnson_Dial_Venda.get(req.query);
        res.send(modelbase_1.clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result));
    }
    catch (e) {
        res.send(modelbase_1.clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
}));
reportInterfaceRouter.get('/interface-faturamento-item', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.reportInterfaceFaturamentoItem.get(req.query);
        res.send(modelbase_1.clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result));
    }
    catch (e) {
        res.send(modelbase_1.clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
}));
reportInterfaceRouter.get('/interface-dial-cliente', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.reportInterfaceJohnson_Dial_Cliente.get(req.query);
        res.send(modelbase_1.clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result));
    }
    catch (e) {
        res.send(modelbase_1.clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
}));
reportInterfaceRouter.get('/interface-dial-estoque', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield report_1.default.reportInterfaceJohnson_Dial_Estoque.get(req.query);
        res.send(modelbase_1.clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result));
    }
    catch (e) {
        res.send(modelbase_1.clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
}));
exports.default = reportInterfaceRouter;
