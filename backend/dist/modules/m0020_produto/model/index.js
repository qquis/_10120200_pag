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
/*Models */
const modelproduto_1 = __importDefault(require("./modelproduto"));
const modelprodutoEmbalagemGtin_1 = __importDefault(require("./modelprodutoEmbalagemGtin"));
const modelProdutoRouter = (0, express_1.Router)();
/* Consultar um produto */
modelProdutoRouter.get('/produto/:pr_cdproduto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const pr_cdproduto = Number(req.params.pr_cdproduto);
    const model = new modelproduto_1.default();
    try {
        const dataQuery = yield model.ConsultarDataQuery(pr_cdproduto);
        res.status(200).json(dataQuery);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelProdutoRouter`, 'GET /produto/:pr_cdproduto', e);
        res.status(500).json({ error: 'Erro ao consultar o produto.' });
    }
}));
modelProdutoRouter.get('/ProdutoEmbalagemGtin/:preg_cdbarra', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const preg_cdbarra = String(req.params.preg_cdbarra);
    const model = new modelprodutoEmbalagemGtin_1.default;
    try {
        const dataQuery = yield model.ConsultarDataQuery(preg_cdbarra);
        res.status(200).json(dataQuery);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelProdutoRouter`, 'GET /ProdutoEmbalagemGtin/:preg_cdbarra', e);
        res.status(500).json({ error: 'Erro ao consultar o produto.' });
    }
}));
exports.default = modelProdutoRouter;
