import { Request, Response, Router } from "express";
/*import service from "./service";*/

import routerService from "./service";
import routerReport from "./report"

const preco = Router()

preco.use("/report", routerReport)
preco.use("/service", routerService)
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
export default preco;