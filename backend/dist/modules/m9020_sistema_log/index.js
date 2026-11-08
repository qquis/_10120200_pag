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
const wk_1 = __importDefault(require("./wk"));
const interfaces_1 = require("./interfaces");
const sistema_log = (0, express_1.Router)();
const routerReports = (0, express_1.Router)();
const routerModel = (0, express_1.Router)();
const routerCmd = (0, express_1.Router)();
sistema_log.use("/reports", routerReports);
sistema_log.use("/cmd", routerCmd);
sistema_log.use("/model", routerModel);
/*
routerReports.get("/serviceconsultar", async (request: Request, response: Response) => {
        try {
                response.send(await wk.ObterBatchsRunsPendentes(request))
        } catch(e) {
            return response.json({})
        }
    
    })
*/
routerCmd.post("/processarlog", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let result = yield wk_1.default.ProcessarLog(interfaces_1.isistemaLog_Constructor.byfromRequest(request));
        response.send(result);
    }
    catch (e) {
        console.log(e);
        response.json({});
    }
}));
exports.default = sistema_log;
