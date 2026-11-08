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
const serviceResultado_1 = __importDefault(require("./serviceResultado"));
const ServiceDRE = (0, express_1.Router)();
ServiceDRE.post(`/processarfechamento`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let resultado = { "status": "0", "message": "Processamento falhou" };
    try {
        let dados = req.query ? req.query : {};
        yield serviceResultado_1.default.ProcessarFechamento(dados);
        resultado = { "status": "1", "message": "Processamento finalizado com sucesso" };
        return res.status(200).send(resultado);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ServiceNotificacao', 'inativarfuncionariopag', e);
        return res.status(500).send(resultado);
    }
}));
exports.default = ServiceDRE;
