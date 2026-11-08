"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const model_1 = __importDefault(require("./model"));
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const m0021_produtobluesoft = (0, express_1.Router)();
m0021_produtobluesoft.use('/model', model_1.default);
m0021_produtobluesoft.use('/service', service_1.default);
m0021_produtobluesoft.use('/report', report_1.default);
exports.default = m0021_produtobluesoft;
