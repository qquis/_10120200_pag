"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const model_1 = __importDefault(require("./model"));
const m0051_faturamentoVip = (0, express_1.Router)();
m0051_faturamentoVip.use("/service", service_1.default);
m0051_faturamentoVip.use("/report", report_1.default);
m0051_faturamentoVip.use("/model", model_1.default);
exports.default = m0051_faturamentoVip;
