"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const m0002_enterprise = (0, express_1.Router)();
const report_1 = __importDefault(require("./report"));
m0002_enterprise.use("/report", report_1.default);
exports.default = m0002_enterprise;
