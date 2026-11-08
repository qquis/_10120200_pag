import { Response, Request, Router } from "express";
import { clsTools } from "../../../model/modelbase";




const modelSistemaBatchRouter = Router()

import modelsistema_Service from "../model/modelsistema_Service";
import modelsistema_ServiceBatch from "./modelsistema_ServiceBatch";


modelSistemaBatchRouter.get("/service", async (req: Request, resp: Response) => {

    let result : any 
    try { 

            let item : modelsistema_Service = new modelsistema_Service(Number(req.query.sis_batch_service_cd));
            result = await item.GetDataQueyAny(req.query);
    } catch (e) { 
        clsTools.PagErrorException(`modelsistema_ServiceBatch.get`,`service`, e);
    }
    finally {
        resp.status(200).send(result);
    }


})

modelSistemaBatchRouter.get("/serviceBatch", async (req: Request, resp: Response) => {

    let result : any 
    try { 
            if (!req.query.sis_batch_cd) {
                throw new Error("Parâmetro sis_batch_cd é obrigatório");
            }

            let item : modelsistema_ServiceBatch = new modelsistema_ServiceBatch(Number(req.query.sis_batch_cd));
            result = await item.GetDataQueyAny();
            
    } catch (e) { 
        clsTools.PagErrorException(`modelsistema_ServiceBatch.get`,`service`, e);
        result = { message: "Erro ao consultar serviço batch."};
    }
    finally {
        resp.status(200).send(result);
    }


})

export default modelSistemaBatchRouter