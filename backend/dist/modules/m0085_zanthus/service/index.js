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
const serviceZanthusRouter = (0, express_1.Router)();
const serviceAtualizacaoGeralFiscal_1 = __importDefault(require("./serviceAtualizacaoGeralFiscal"));
const serviceAtualizacaoCBNEF_1 = __importDefault(require("./serviceAtualizacaoCBNEF"));
//import serviceZanthusCargaOld from './serviceAtualizacao.Carga.Processar.old';
const serviceAtualizacaoClientes_1 = __importDefault(require("./serviceAtualizacaoClientes"));
const serviceAtualizacao_Carga_Processar_new_1 = __importDefault(require("./serviceAtualizacao.Carga.Processar.new"));
const serviceAtualizacao_Carga_DeskTop_1 = __importDefault(require("./serviceAtualizacao.Carga.DeskTop"));
serviceZanthusRouter.post('/atualizacao-geral', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result = {};
    try {
        result = yield serviceAtualizacao_Carga_DeskTop_1.default.start(req.query);
        res.status(200).json(result);
    }
    catch (e) {
        res.status(500).json(result);
    }
}));
serviceZanthusRouter.post('/atualizacao-fiscal', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield serviceAtualizacaoGeralFiscal_1.default.start(req.query);
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    }
    catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
}));
serviceZanthusRouter.post('/atualizacao-cbenef', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield serviceAtualizacaoCBNEF_1.default.start(req.query);
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    }
    catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
}));
serviceZanthusRouter.post('/atualizacao-cliente', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield serviceAtualizacaoClientes_1.default.start(req.query);
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    }
    catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
}));
serviceZanthusRouter.post('/carga-processar', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield serviceAtualizacao_Carga_Processar_new_1.default.start(req.query);
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    }
    catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
}));
exports.default = serviceZanthusRouter;
