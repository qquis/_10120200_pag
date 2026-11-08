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
const service_1 = __importDefault(require("./service"));
const serviceProdutoBluesoftRouter = (0, express_1.Router)();
serviceProdutoBluesoftRouter.post('/importarprodutolist', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield service_1.default.Importar.start(req.body);
        res.status(200).send({ result: true, message: 'Importação de produtos iniciada com sucesso' });
    }
    catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}));
serviceProdutoBluesoftRouter.post('/importarproduto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield service_1.default.Importar.start(req.body);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: `Internal Server Error ${error}` });
    }
}));
serviceProdutoBluesoftRouter.post('/processar-integracao-bluepag', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield service_1.default.ProcessarImportacoes.start(req.body);
        res.status(200).send(result);
    }
    catch (error) {
        res.status(500).json({ error: `Internal Server Error ${error}` });
    }
}));
exports.default = serviceProdutoBluesoftRouter;
