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
const modelProdutoBluesoftRouter = (0, express_1.Router)();
const modelProdutoBluesoft_1 = __importDefault(require("./modelProdutoBluesoft"));
modelProdutoBluesoftRouter.post('/importar', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const produtoBluesoft = new modelProdutoBluesoft_1.default();
        yield produtoBluesoft.AtualizarProdutoBluesoftComDadosDaApi(req.query);
        res.status(200).json({ message: 'Importação de produtos iniciada com sucesso.' });
    }
    catch (error) {
        res.status(500).json({ error: 'Erro ao importar produtos do Bluesoft.' });
    }
}));
exports.default = modelProdutoBluesoftRouter;
