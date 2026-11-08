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
const report_1 = __importDefault(require("./report"));
const modelbase_1 = require("../../../model/modelbase");
const reportProdutoBluesoftRouter = (0, express_1.Router)();
reportProdutoBluesoftRouter.get('/list', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result = {};
    try {
        const data = yield report_1.default.list.get(req.query);
        result = modelbase_1.clsTools.responseDefault.get(200, "Processamento concluído com sucesso.", data);
    }
    catch (e) {
        result = modelbase_1.clsTools.responseDefault.get(500, "Ocorreu um erro durante o processamento.", e);
    }
    finally {
        res.status(result.status || 200).json(result);
    }
}));
exports.default = reportProdutoBluesoftRouter;
