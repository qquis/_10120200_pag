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
const modelFaturamentoBLuesoftRouter = (0, express_1.Router)();
const modelFaturamentoBluesoft_1 = __importDefault(require("./modelFaturamentoBluesoft"));
modelFaturamentoBLuesoftRouter.get("/consultar", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let faturamento = yield modelFaturamentoBluesoft_1.default.Consultar(req.query);
        return resp.status(200).json(faturamento);
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /faturamentobluesoft", error);
    }
}));
exports.default = modelFaturamentoBLuesoftRouter;
