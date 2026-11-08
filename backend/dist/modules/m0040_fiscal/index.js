"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const m0040_fiscal = (0, express_1.Router)();
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const model_1 = __importDefault(require("./model"));
m0040_fiscal.use('/service', service_1.default);
m0040_fiscal.use('/report', report_1.default);
m0040_fiscal.use('/model', model_1.default);
exports.default = m0040_fiscal;
