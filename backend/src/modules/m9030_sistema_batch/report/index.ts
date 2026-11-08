import { Response, Request, Router } from "express";




const reportSistemaBatchRouter = Router()

import reportSistemaBatch from "./report";


reportSistemaBatchRouter.get("/servicelist", async (req: Request, resp: Response) => {
    try {
        let result = await reportSistemaBatch.batchServiceList(req.query);
         resp.status(200).send(result);
    } catch(e) {
        return resp.status(500).send({message: "Erro ao consultar serviços do sistema batch"});
    }
})

export default reportSistemaBatchRouter;