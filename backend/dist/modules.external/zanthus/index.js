"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const externalZanthusRouter = (0, express_1.Router)();
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const model_1 = __importDefault(require("./model"));
externalZanthusRouter.use('/service', service_1.default);
externalZanthusRouter.use('/report', report_1.default);
externalZanthusRouter.use('/model', model_1.default);
exports.default = externalZanthusRouter;
