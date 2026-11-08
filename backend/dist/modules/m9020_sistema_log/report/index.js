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
const modelbase_1 = require("../../../model/modelbase");
const express_1 = require("express");
const report_1 = __importDefault(require("./report"));
const reportSistemaLogRouter = (0, express_1.Router)();
reportSistemaLogRouter.get("/list", (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    let result = { message: "Erro no processamento" };
    try {
        result = yield report_1.default.list.get(req.query);
        resp.status(200).json(result);
    }
    catch (e) {
        modelbase_1.clsTools.pagConsole(`reportSistemaLogRouter | list \n Error: ${e}`);
        resp.status(500).json(result);
    }
}));
exports.default = reportSistemaLogRouter;
