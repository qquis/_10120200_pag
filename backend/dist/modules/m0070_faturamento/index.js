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
const report_1 = __importDefault(require("./report"));
const model_1 = __importDefault(require("./model"));
const batch_1 = __importDefault(require("./batch"));
const faturamento = (0, express_1.Router)();
faturamento.use("/service", service_1.default);
faturamento.use("/report", report_1.default);
faturamento.use("/model", model_1.default);
faturamento.get("/", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const help = [
            {
                url: "/report",
                info: "Relatórios Faturamento"
            },
            {
                url: "/service",
                info: "Services Faturamento"
            },
        ];
        return resp.send(help);
    }
    catch (e) {
        throw new Error(`${e}`);
    }
}));
faturamento.post("/batch/atualizacao-diaria", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield batch_1.default.AtualizacaoDiaria();
        return resp.send({ success: result });
    }
    catch (e) {
        return resp.status(500).send({ error: `${e}` });
    }
}));
exports.default = faturamento;
