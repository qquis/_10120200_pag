import { clsBase, clsTools } from "../../../model/modelbase";
import { Router, Response, Request } from "express";


import apiFaturamentoBluesoft from "./apiFaturamebtoBluesoft";

const FaturamentoBluesoftApiRouter = Router();


FaturamentoBluesoftApiRouter.get("/pedido", async (req: Request, resp: Response ) => {
    
    let resultado = {};
    
    try { 
        resultado = await apiFaturamentoBluesoft.obterPedidosBluesoft(req.query);
            
    } catch (error) {
        clsTools.PagErrorException("faturamentoBluesoftApi.get", "get /", error);
    } finally {
        return resp.json(resultado);
    }
     
}) 


export default FaturamentoBluesoftApiRouter;