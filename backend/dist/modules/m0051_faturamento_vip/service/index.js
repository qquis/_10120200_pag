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
const serviceFaturamentoVipRouter = (0, express_1.Router)();
serviceFaturamentoVipRouter.post("/processar", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.faturamentoPedido.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });
    }
    catch (e) {
        response.status(500).send({ error: e.message });
    }
}));
exports.default = serviceFaturamentoVipRouter;
