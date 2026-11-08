import { Request, Response, Router, request, response } from "express";
import wk from './wk'
import { isistemaLog_Constructor, isistemaLog} from "./interfaces";

const sistema_log = Router() 

const routerReports = Router() 
const routerModel = Router()
const routerCmd = Router() 

sistema_log.use("/reports", routerReports)
sistema_log.use("/cmd", routerCmd)
sistema_log.use("/model", routerModel)

/*
routerReports.get("/serviceconsultar", async (request: Request, response: Response) => {
        try {
                response.send(await wk.ObterBatchsRunsPendentes(request))
        } catch(e) {
            return response.json({})
        }
    
    })
*/
routerCmd.post("/processarlog", async (request: Request, response: Response) => {
        try {
                let result = await wk.ProcessarLog(isistemaLog_Constructor.byfromRequest(request))
                response.send(result)

        } catch(e) {
                console.log(e)
                response.json({})
        }
    })


export default sistema_log