"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const model_1 = __importDefault(require("./model"));
const report_1 = __importDefault(require("./report"));
const service_1 = __importDefault(require("./service"));
const m0005_forcaVendaMetaRouter = (0, express_1.Router)();
m0005_forcaVendaMetaRouter.use("/model", model_1.default);
m0005_forcaVendaMetaRouter.use("/report", report_1.default);
m0005_forcaVendaMetaRouter.use("/service", service_1.default);
exports.default = m0005_forcaVendaMetaRouter;
