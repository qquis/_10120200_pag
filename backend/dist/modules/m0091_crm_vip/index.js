"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const report_1 = __importDefault(require("./report"));
const service_1 = __importDefault(require("./service"));
const api_1 = __importDefault(require("./api"));
const model_1 = __importDefault(require("./model"));
const m0091_routerCrmVip = (0, express_1.Router)();
m0091_routerCrmVip.use("/report", report_1.default);
m0091_routerCrmVip.use("/model", model_1.default);
m0091_routerCrmVip.use("/service", service_1.default);
m0091_routerCrmVip.use("/vipApi", api_1.default);
m0091_routerCrmVip.get("/", (req, res) => {
    res.send({ status: "1", info: "M0091 - CRM VIP - OK" });
});
exports.default = m0091_routerCrmVip;
