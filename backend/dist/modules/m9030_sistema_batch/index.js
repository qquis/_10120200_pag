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
const sistema_batch = (0, express_1.Router)();
const index_1 = __importDefault(require("./report/index"));
const index_2 = __importDefault(require("./service/index"));
const index_3 = __importDefault(require("./model/index"));
sistema_batch.use("/report", index_1.default);
sistema_batch.use("/service", index_2.default);
sistema_batch.use("/model", index_3.default);
sistema_batch.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    response.json({ message: "M9030 - Sistema Batch Ativo" });
}));
/*
routerReports.get("/serviceconsultar", async (request: Request, response: Response) => {
        try {
                response.send(await wk.ObterBatchsRunsPendentes(request))
        } catch(e) {
            return response.json({})
        }
    
    })
*/
/*
routerService.post("/servicerun", async (request: Request, response: Response) => {
        try {
                // Os serviços tem de ser criados para cada chamada post/get
                let myServicePatch : servicePatch = new servicePatch()
                response.send(await myServicePatch.ServiceRun(request))
        } catch(e) {
                myTools.pagConsoleLog(`M9030 | Index Error \n ${e}`)
                response.json({})
        }
    })

routerService.post("/serviceprocessar", async (request: Request, response: Response) => {
        try {
                // Os serviços tem de ser criados para cada chamada post/get
                let myServicePatch : servicePatch = new servicePatch()
                response.send(await myServicePatch.ServiceProcessar(request))
       } catch(e) {
                myTools.pagConsoleLog(`M9030 | Index Error \n ${e}`)
                response.json({})
        }
    })
*/
exports.default = sistema_batch;
