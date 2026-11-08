import { Request, Response, Router, request, response } from "express";
import servicePatch from "./service/serviceSistemaBatch";
import myTools from "../../tools/Tools";

const sistema_batch = Router() 

import reportSsiteamBatchRouter from "./report/index";
import serviceSistemaBatchRouter from "./service/index";
import modelSistemaBatchRouter from "./model/index";





sistema_batch.use("/report", reportSsiteamBatchRouter)
sistema_batch.use("/service", serviceSistemaBatchRouter)
sistema_batch.use("/model", modelSistemaBatchRouter)

sistema_batch.get("/",  async (request: Request, response: Response) => {
        response.json({message : "M9030 - Sistema Batch Ativo"})
    })


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
export default sistema_batch