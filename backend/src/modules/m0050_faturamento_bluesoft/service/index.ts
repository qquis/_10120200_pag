import { Router, Response, Request } from "express";
import { clsBase, clsTools } from "../../../model/modelbase";


const FaturamentoBluesoftServiceRouter = Router();

import serviceFaturamentoBluesoft from "./service";



FaturamentoBluesoftServiceRouter.post("/processar-pendente", async (req: Request, resp: Response ) => {
    try { 

        await serviceFaturamentoBluesoft.processamentoPendente()
    } catch (error) {
        clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    } finally {
        resp.json({ message: "ok" });
    }
})


FaturamentoBluesoftServiceRouter.post("/redshift-processar", async (req: Request, resp: Response ) => {
    try { 
        await serviceFaturamentoBluesoft.ImportFromRedShift.start(req.query)
    } catch (error) {
        clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    } finally {
        resp.json({ message: "ok" });
    }
})

FaturamentoBluesoftServiceRouter.post("/apibluesoft-processar", async (req: Request, resp: Response ) => {
    try { 
        await serviceFaturamentoBluesoft.ImportForcaVendaApi.start(req.query)
    } catch (error) {
        clsTools.PagErrorException("routerServiceFaturamentoBluesoft.get", "get /", error);
        resp.json({ message: "error" });
    } finally {
        resp.json({ message: "ok" });
    }
})




export default FaturamentoBluesoftServiceRouter;