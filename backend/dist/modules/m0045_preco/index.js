"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
/*import service from "./service";*/
const service_1 = __importDefault(require("./service"));
const report_1 = __importDefault(require("./report"));
const preco = (0, express_1.Router)();
preco.use("/report", report_1.default);
preco.use("/service", service_1.default);
//preco.use("/model", routerModel)
/*
routerReport.get("/PrecoAplicacaoList", async (request: Request, response: Response) => {
    
    try {
            response.send(await service.ObterPrecosAplicados(request))
    } catch (e) {
        return response.json({})
    }
})

routerService.post('/bluesoftatualizarproduto', async (request: Request, response: Response) => {
    try {
        const result = await service.BlueSoftAtualizarProduto(request);
        response.send({"result": 1})
    }

    catch(e){
        console.log(`F0045 | /get/blue_update_export:
                     ERROR -> \n ${e}`);
        response.send({"result": 0})
    }

})

routerService.post('/bluesoftintegrarprodutospendentes', async (request: Request, response: Response) => {
    try {
        const result = await service.BlueSoftIntegrarPendentes()
        response.send(result)
    }

    catch(e){
        console.log(`F0045 | /get/blue_update_export:
                     ERROR -> \n ${e}`);
        response.send({"result": 0})
    }

})

routerService.post('/bluesoftintegrarprodutosall', async (request: Request, response: Response) => {
    try {
        const result = await service.BlueSoftIntegrarAll()
        response.send(result)
    }

    catch(e){
        console.log(`F0045 | /get/blue_update_export:
                     ERROR -> \n ${e}`);
        response.send({"result": 0})
    }

})


routerService.post('/bluesoft_integrar')
*/
exports.default = preco;
