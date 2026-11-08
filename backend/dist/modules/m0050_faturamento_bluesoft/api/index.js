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
const apiFaturamebtoBluesoft_1 = __importDefault(require("./apiFaturamebtoBluesoft"));
const FaturamentoBluesoftApiRouter = (0, express_1.Router)();
FaturamentoBluesoftApiRouter.get("/pedido", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let resultado = {};
    try {
        resultado = yield apiFaturamebtoBluesoft_1.default.obterPedidosBluesoft(req.query);
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("faturamentoBluesoftApi.get", "get /", error);
    }
    finally {
        return resp.json(resultado);
    }
}));
exports.default = FaturamentoBluesoftApiRouter;
