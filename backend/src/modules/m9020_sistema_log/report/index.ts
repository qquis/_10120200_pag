import { clsBase, clsTools } from "../../../model/modelbase";
import { Request, Response, Router } from "express";


import reportSistemaLog from "./report";

const reportSistemaLogRouter = Router();

reportSistemaLogRouter.get("/list", async (req: Request, resp: Response ) => {
    
    let result : any = { message: "Erro no processamento"}
    try {

        result = await reportSistemaLog.list.get(req.query)
        resp.status(200).json(result)
        
    } catch (e) {
        clsTools.pagConsole(`reportSistemaLogRouter | list \n Error: ${e}`);
        resp.status(500).json(result)
    }
})

export default reportSistemaLogRouter
