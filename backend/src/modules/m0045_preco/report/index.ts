import reportPreco from "./report";
import { Request, Response, Router } from "express";

const routerReport = Router() 

const __reportPreco : reportPreco = new reportPreco();

routerReport.get("/PrecoAplicados", async (request: Request, response: Response) => { 
    try {
            
            return response.send(await __reportPreco.PrecosAplicados(request))
                  
    } catch (e) {
        throw Error("Erro")
    }

})


routerReport.get("/PrecoAplicacaoIntegracaoBlueSoftGeral", async (request: Request, response: Response) => { 
    try {
            return response.send(await __reportPreco.PrecosAplicadosIntegracaoBlueSoftGeral())
                  
    } catch (e) {
        throw Error("Erro")
    }

})


routerReport.get("/PrecoAplicacaoIntegracaoBlueSoftPendente", async (request: Request, response: Response) => { 
    try {
            return response.send(await __reportPreco.PrecosAplicadosIntegracaoBlueSoftPendente())
                  
    } catch (e) {
        throw Error("Erro")
    }

})


routerReport.get("/PrecoAgendadoIntegracaoBlueSoftPendente", async (request: Request, response: Response) => { 
    try {
            return response.send(await __reportPreco.PrecoAgendadoIntegracaoBlueSoftPendente())
                  
    } catch (e) {
        throw Error("Erro")
    }

})

export default routerReport;
