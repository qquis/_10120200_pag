import { clsTools } from "../../../model/modelbase";
import { Router, Response, Request } from "express";

const reportFaturamentoZanthusRouter = Router();



import reportFaturamentoZanthus from "./report";

reportFaturamentoZanthusRouter.get('/cupom', async (request: Request, response: Response) => {
    try { 

        let parametro = request.query

        let result = await reportFaturamentoZanthus.Cupom.get(parametro)

        response.status(200).json(result)

    } catch(e) {
        await clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_cupom", e)
        response.status(400).json({
            error: `erro ao gerar relatório de cupom fiscal Zanthus: ${e}`
        })
    }
})


reportFaturamentoZanthusRouter.get('/cupom-item', async (request: Request, response: Response) => {
    try { 

        let parametro = request.query

        let result = await reportFaturamentoZanthus.CupomItem.get(parametro)

        response.status(200).json(result)

    } catch(e) {
        await clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_cupom-item", e)
        response.status(400).json({
            error: `erro ao gerar relatório de cupom fiscal Zanthus: ${e}`
        })
    }
})

reportFaturamentoZanthusRouter.get('/pagamento', async (request: Request, response: Response) => {
    try { 

        let parametro = request.query

        let result = await reportFaturamentoZanthus.Pagamento.get(parametro)

        response.status(200).json(result)

    } catch(e) {
        await clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportFaturamentoZanthusRouter / zanthus_pagamento", e)
        response.status(400).json({
            error: `erro ao gerar relatório de pagamento Zanthus: ${e}`
        })
    }
})



export default reportFaturamentoZanthusRouter;

