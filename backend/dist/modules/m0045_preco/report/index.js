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
const report_1 = __importDefault(require("./report"));
const express_1 = require("express");
const routerReport = (0, express_1.Router)();
const __reportPreco = new report_1.default();
routerReport.get("/PrecoAplicados", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return response.send(yield __reportPreco.PrecosAplicados(request));
    }
    catch (e) {
        throw Error("Erro");
    }
}));
routerReport.get("/PrecoAplicacaoIntegracaoBlueSoftGeral", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return response.send(yield __reportPreco.PrecosAplicadosIntegracaoBlueSoftGeral());
    }
    catch (e) {
        throw Error("Erro");
    }
}));
routerReport.get("/PrecoAplicacaoIntegracaoBlueSoftPendente", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return response.send(yield __reportPreco.PrecosAplicadosIntegracaoBlueSoftPendente());
    }
    catch (e) {
        throw Error("Erro");
    }
}));
routerReport.get("/PrecoAgendadoIntegracaoBlueSoftPendente", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        return response.send(yield __reportPreco.PrecoAgendadoIntegracaoBlueSoftPendente());
    }
    catch (e) {
        throw Error("Erro");
    }
}));
exports.default = routerReport;
