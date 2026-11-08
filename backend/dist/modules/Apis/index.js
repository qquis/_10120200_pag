"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const apis = (0, express_1.Router)();
const vipApi_1 = __importDefault(require("./vipApi"));
const bluesoftApi_1 = __importDefault(require("./bluesoftApi"));
apis.use("/vip", vipApi_1.default);
apis.use("/bluesoft", bluesoftApi_1.default);
exports.default = apis;
