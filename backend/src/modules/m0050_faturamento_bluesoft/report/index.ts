import { clsBase, clsTools } from "../../../model/modelbase";
import { Request, Response, Router } from "express";


import reportFaturamentoBluesoft from "./report";

const reportFaturamentoBluesoftRouter = Router();

reportFaturamentoBluesoftRouter.get("/list", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportFaturamentoBluesoft.list.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | list \n Error: ${e}`);
        resp.status(500).json(result)
    }
})

reportFaturamentoBluesoftRouter.get("/statusList", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportFaturamentoBluesoft.statusList.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | statusList \n Error: ${e}`);
        resp.status(500).json(result)
    }
})


reportFaturamentoBluesoftRouter.get("/redshift/list", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportFaturamentoBluesoft.redshift_list.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | redshift/list \n Error: ${e}`);
        resp.status(500).json({ message: "Em desenvolvimento"})
    }
})

reportFaturamentoBluesoftRouter.get("/processos", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportFaturamentoBluesoft.processo.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | getFaturamentoFVNotificacoesPendentes \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}`})
    }
})

reportFaturamentoBluesoftRouter.get("/log", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportFaturamentoBluesoft.Log.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | sistema-log \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}`})
    }
})

reportFaturamentoBluesoftRouter.get("/forca-venda/pedido-com-corte", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        if (req.query.mail && req.query.mail == "1")
        {
            await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.mail(req.query)
            resp.status(200).json({ message: "E-mail Enviado com sucesso!"})

        } else {
            result = await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.get(req.query)
            resp.status(200).json(result)
        }
        
    } catch (e) {
        clsTools.pagConsole(`reportFaturamentoBluesoftRouter | forca-venda/pedido-com-corte \n Error: ${e}`);
        resp.status(500).json({ message: `Erro no processamento: ${e}`})
    }
})


export default reportFaturamentoBluesoftRouter; 


