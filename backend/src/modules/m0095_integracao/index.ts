import {Request, Response, Router} from "express"


import routerReport from "./report"
import routerService from "./service";
import router from "src/routes/router";

const Integracao = Router() 

Integracao.use("/report", routerReport);
Integracao.use("/service", routerService)



Integracao.get("/", async(request: Request, response: Response) => {

    const help = [
        { 
            url : "/report", 
            info : "M0095 | Integrações - Reports disponíveis"
        },
        {
            url : "/service", 
            info : "M0095 | Integrações - Serviços disponíveis"
        } 
    ]

    return response.send(help)
})

export default Integracao


