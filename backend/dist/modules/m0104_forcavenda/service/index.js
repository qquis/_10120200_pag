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
const serviceForcaVendaRouter = (0, express_1.Router)();
serviceForcaVendaRouter.post('/importar-prazoPgto', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const prazoPgto = yield service_1.default.prazoPgto.start();
        return res.status(200).send({ status: 1, info: "Importação realizada com sucesso", prazoPgto });
    }
    catch (e) {
        return res.status(400).send({ status: 0, info: `Erro ao importar prazo de pagamento ${e}` });
    }
}));
serviceForcaVendaRouter.post('/importar-tabelaPreco', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const tabelaPreco = yield service_1.default.tabelaPreco.start();
        return res.status(200).send({ status: 1, info: "Importação realizada com sucesso", tabelaPreco });
    }
    catch (e) {
        return res.status(400).send({ status: 0, info: `Erro ao importar tabela de preço ${e}` });
    }
}));
serviceForcaVendaRouter.post('/importar-baseGeralPreco', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        console.log(`Index/Post _ Atualização Geral do força de venda em execução`);
        yield service_1.default.prazoPgto.start();
        yield service_1.default.tabelaPreco.start();
        console.log(`Index/Post _ Atualização Geral do força de venda concluída`);
        return res.status(200).send({ status: 1, info: "Importação realizada com sucesso" });
    }
    catch (e) {
        return res.status(400).send({ status: 0, info: `Erro ao importar base geral de preços ${e}` });
    }
}));
exports.default = serviceForcaVendaRouter;
