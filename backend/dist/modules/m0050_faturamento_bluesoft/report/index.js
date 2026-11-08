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
const report_1 = __importDefault(require("./report"));
const reportFaturamentoBluesoftRouter = (0, express_1.Router)();
reportFaturamentoBluesoftRouter.get("/list", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.list.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | list \n Error: ${e}`);
        resp.status(500).json(result);
    }
}));
reportFaturamentoBluesoftRouter.get("/statusList", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.statusList.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | statusList \n Error: ${e}`);
        resp.status(500).json(result);
    }
}));
reportFaturamentoBluesoftRouter.get("/redshift/list", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.redshift_list.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | redshift/list \n Error: ${e}`);
        resp.status(500).json({ message: "Em desenvolvimento" });
    }
}));
reportFaturamentoBluesoftRouter.get("/processos", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.processo.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | getFaturamentoFVNotificacoesPendentes \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}` });
    }
}));
reportFaturamentoBluesoftRouter.get("/log", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.Log.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | sistema-log \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}` });
    }
}));
reportFaturamentoBluesoftRouter.get("/forca-venda/pedido-com-corte", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        if (req.query.mail && req.query.mail == "1") {
            yield report_1.default.ForcaVenda.PedidoComCorte.mail(req.query);
            resp.status(200).json({ message: "E-mail Enviado com sucesso!" });
        }
        else {
            result = yield report_1.default.ForcaVenda.PedidoComCorte.get(req.query);
            resp.status(200).json(result);
        }
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoftRouter | forca-venda/pedido-com-corte \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}` });
    }
}));
exports.default = reportFaturamentoBluesoftRouter;
