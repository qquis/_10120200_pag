import { clsBase, clsTools } from "../../../model/modelbase";
import { Request, Response, Router } from "express";

import servicePatch from "./serviceSistemaBatch";
import sistemaServiceProcedimento from "./serviceSistemaProcedimento";
import ServiceSistemaBatchInicializacaoDiaria from "./serviceSistemaBatchInicializacaoDiaria";

const serviceSistemaBatchRouter = Router()



serviceSistemaBatchRouter.post("/servicerun", async (request: Request, response: Response) => {
        try {
                // Os serviços tem de ser criados para cada chamada post/get
                let myServicePatch : servicePatch = new servicePatch()
                response.send(await myServicePatch.ServiceRun(request))
        } catch(e) {
                clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.servicerun`, e)
                response.json({})
        }
    })

serviceSistemaBatchRouter.post("/serviceprocessar", async (request: Request, response: Response) => {
        try {
                // Os serviços tem de ser criados para cada chamada post/get
                let myServicePatch : servicePatch = new servicePatch() 
                response.send(await myServicePatch.ServiceProcessar(request)) 
       } catch(e) {
                clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.serviceprocessar`, e)
                response.json({})
        }
    })    

serviceSistemaBatchRouter.post("/procedimento-processar", async (request: Request, response: Response) => {
        try {

                let result = await sistemaServiceProcedimento.startProcedimento(request.query)
                response.send(clsTools.responseDefault.get(200, `OK`, result))

       } catch(e) {
                clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.serviceprocessar`, e)
                response.send(clsTools.responseDefault.get(500, `M9030 _ /procedimento-processar | ${e}`, {}))
        }
    })
serviceSistemaBatchRouter.post("/inicializacao-diaria", async (request: Request, response: Response) => {
        try {
                let myService : ServiceSistemaBatchInicializacaoDiaria = new ServiceSistemaBatchInicializacaoDiaria()
                response.send(await ServiceSistemaBatchInicializacaoDiaria.start(request.query))
        } catch(e) {
                clsTools.PagErrorException(`M9030 | Index Error \n ${e}`, `serviceSistemaBatchRouter.post.inicializacao-diaria`, e)
                response.send(clsTools.responseDefault.get(500, `M9030 _ /inicializacao-diaria | ${e}`, {}))
        }
    })


export default serviceSistemaBatchRouter;