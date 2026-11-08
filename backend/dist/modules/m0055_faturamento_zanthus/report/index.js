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
const reportFaturamentoZanthusRouter = (0, express_1.Router)();
const report_1 = __importDefault(require("./report"));
reportFaturamentoZanthusRouter.get('/cupom', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let parametro = request.query;
        let result = yield report_1.default.Cupom.get(parametro);
        response.status(200).json(result);
    }
    catch (e) {
        yield modelbase_1.clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_cupom", e);
        response.status(400).json({
            error: `erro ao gerar relatório de cupom fiscal Zanthus: ${e}`
        });
    }
}));
reportFaturamentoZanthusRouter.get('/cupom-item', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let parametro = request.query;
        let result = yield report_1.default.CupomItem.get(parametro);
        response.status(200).json(result);
    }
    catch (e) {
        yield modelbase_1.clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_cupom-item", e);
        response.status(400).json({
            error: `erro ao gerar relatório de cupom fiscal Zanthus: ${e}`
        });
    }
}));
reportFaturamentoZanthusRouter.get('/pagamento', (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let parametro = request.query;
        let result = yield report_1.default.Pagamento.get(parametro);
        response.status(200).json(result);
    }
    catch (e) {
        yield modelbase_1.clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_pagamento", e);
        response.status(400).json({
            error: `erro ao gerar relatório de pagamento Zanthus: ${e}`
        });
    }
}));
exports.default = reportFaturamentoZanthusRouter;
