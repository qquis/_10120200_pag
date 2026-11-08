import { Router, Response, Request } from "express";
import { clsBase, clsTools } from "../../../model/modelbase";


const modelFaturamentoBLuesoftRouter = Router();


import modelFaturamentoBluesoft from "./modelFaturamentoBluesoft";
import modelfaturamentovip from "src/modules/m0051_faturamento_vip/model/modelfaturamentovip";

modelFaturamentoBLuesoftRouter.get("/consultar", async (req: Request, resp: Response ) => {
    try { 
        
        
        let faturamento = await modelFaturamentoBluesoft.Consultar(req.query)

        
        return resp.status(200).json(faturamento)
        
    } catch (error) {
        clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /faturamentobluesoft", error);
    }
})

export default modelFaturamentoBLuesoftRouter;