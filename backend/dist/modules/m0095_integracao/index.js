"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const report_1 = __importDefault(require("./report"));
const service_1 = __importDefault(require("./service"));
const Integracao = (0, express_1.Router)();
Integracao.use("/report", report_1.default);
Integracao.use("/service", service_1.default);
Integracao.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = [
        {
            url: "/report",
            info: "M0095 | Integrações - Reports disponíveis"
        },
        {
            url: "/service",
            info: "M0095 | Integrações - Serviços disponíveis"
        }
    ];
    return response.send(help);
}));
exports.default = Integracao;
