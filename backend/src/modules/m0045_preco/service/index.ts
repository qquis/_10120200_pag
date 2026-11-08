import { clsBase, clsTools } from "../../../model/modelbase";
import { Request, Response, Router, request } from "express";
import service from "./service";

const routerService = Router() 



routerService.get("/aplicar", async(request: Request, response: Response) => {
    
    let status : boolean = false;
    
    
    try {
        status = await service.AplicarPrecos(request.query);
    } catch (e) {
        clsTools.PagErrorException(`M0045`, `serviceAplicacao.aplicar Error`, e)
    }

    finally { 
        response.send({"status" : status})
    }
})

routerService.post("/BlueSoftAtualizarProdutosPendentes", async(request: Request, response: Response) => {
    try {
        const result = await service.integrarBlueSoftPrecoAplicado()
        
        return response.send(result);

    } catch (e) {
        clsTools.PagErrorException(`M0045`, `serviceAplicacao.BlueSoftAtualizarProdutosPendentes Error`, e)
        return response.json({})
    }
})

routerService.post("/BlueSoftAtualizarAgendamentosPendentes", async(request: Request, response: Response) => {
    try {
        const result = await service.integrarBlueSoftPrecoAgedando();
        
        return response.send(result);

    } catch (e) {
        clsTools.PagErrorException(`M0045`, `serviceAplicacao.BlueSoftAtualizarAgendamentosPendentes Error`, e)
        return response.json({})
    }
})

export default routerService