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
const service_1 = __importDefault(require("./service"));
const api_1 = __importDefault(require("./api"));
const model_1 = __importDefault(require("./model"));
const batch_1 = __importDefault(require("./batch"));
const routerFaturamentoBluesoft = (0, express_1.Router)();
routerFaturamentoBluesoft.use("/report", report_1.default);
routerFaturamentoBluesoft.use("/service", service_1.default);
routerFaturamentoBluesoft.use("/bluesoftapi", api_1.default);
routerFaturamentoBluesoft.use("/model", model_1.default);
routerFaturamentoBluesoft.post("/batch/atualizacao-diaria", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield batch_1.default.AtualizacaoDiaria();
        resp.json({ message: "ok" });
    }
    catch (error) {
        resp.json({ message: "error" });
    }
}));
exports.default = routerFaturamentoBluesoft;
