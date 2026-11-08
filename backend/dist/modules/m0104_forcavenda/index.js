"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const model_1 = __importDefault(require("./model"));
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const M0104_ForcaVenda = (0, express_1.Router)();
M0104_ForcaVenda.use('/model', model_1.default);
M0104_ForcaVenda.use('/service', service_1.default);
M0104_ForcaVenda.use('/report', report_1.default);
exports.default = M0104_ForcaVenda;
