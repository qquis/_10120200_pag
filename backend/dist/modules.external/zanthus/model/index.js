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
const external_zanthus_model = (0, express_1.Router)();
const model_1 = __importDefault(require("./model"));
external_zanthus_model.get('/mercadoria', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let mercadoriaResult = yield model_1.default.obterDadosMercadoria(req.query);
        res.status(200).send(mercadoriaResult);
    }
    catch (e) {
        res.status(500).send({ error: 'Erro interno no servidor' });
    }
}));
external_zanthus_model.get('/cliente', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let clienteResult = yield model_1.default.obterDadosDoCliente(req.query);
        res.status(200).send(clienteResult);
    }
    catch (e) {
        res.status(500).send({ error: 'Erro interno no servidor' });
    }
}));
exports.default = external_zanthus_model;
