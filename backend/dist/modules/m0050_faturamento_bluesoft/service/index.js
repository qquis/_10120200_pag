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
const FaturamentoBluesoftServiceRouter = (0, express_1.Router)();
const service_1 = __importDefault(require("./service"));
FaturamentoBluesoftServiceRouter.post("/processar-pendente", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.processamentoPendente();
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    }
    finally {
        resp.json({ message: "ok" });
    }
}));
FaturamentoBluesoftServiceRouter.post("/redshift-processar", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.ImportFromRedShift.start(req.query);
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    }
    finally {
        resp.json({ message: "ok" });
    }
}));
FaturamentoBluesoftServiceRouter.post("/apibluesoft-processar", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.ImportForcaVendaApi.start(req.query);
    }
    catch (error) {
        modelbase_1.clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    }
    finally {
        resp.json({ message: "ok" });
    }
}));
exports.default = FaturamentoBluesoftServiceRouter;
