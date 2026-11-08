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
const serviceFaturamento_1 = __importDefault(require("./serviceFaturamento"));
const routerFaturamentoService = (0, express_1.Router)();
routerFaturamentoService.get("/", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const help = [
            {
                url: "/processarpedido",
                info: "Faturamento Service | Processar pedido _ numeropedido?"
            },
        ];
        resp.status(200).send(help);
    }
    catch (e) {
        throw new Error(`${e}`);
    }
}));
routerFaturamentoService.post("/processar", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const reprocessaritem = req.query.reprocessaritem ? req.query.reprocessaritem === '1' : false;
        let result = yield serviceFaturamento_1.default.FaturamentoProcessar(req.query);
        resp.status(200).send(result);
    }
    catch (e) {
        resp.status(400).send({ error: `${e}` });
    }
}));
routerFaturamentoService.post("/contrato-processar-apurar", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield serviceFaturamento_1.default.faturamentoContratoService.start(req.body);
        resp.status(200).send(result);
    }
    catch (e) {
        resp.status(400).send({ error: `${e}` });
    }
}));
exports.default = routerFaturamentoService;
