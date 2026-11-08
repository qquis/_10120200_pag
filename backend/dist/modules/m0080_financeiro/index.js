"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const model_1 = __importDefault(require("./model"));
const report_1 = __importDefault(require("./report"));
const service_1 = __importDefault(require("./service"));
const m0080_financeiro = (0, express_1.Router)();
m0080_financeiro.get("/", (req, resp) => {
    resp.send({ "info": "Módulo Financeiro" });
});
m0080_financeiro.use("/model", model_1.default);
m0080_financeiro.use("/report", report_1.default);
m0080_financeiro.use("/service", service_1.default);
exports.default = m0080_financeiro;
