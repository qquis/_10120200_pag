import { clsBase, clsTools } from "../../../model/modelbase";
import { Router, Request, Response } from "express";


const externalZanthusReportRouter = Router()

import reportExternalZanthus from "./report";

externalZanthusReportRouter.get('/tab_mercadoria', async (req: Request, res: Response) => {
    try {

        let result = await reportExternalZanthus.tabMercadoria.get(req.query)
        res.status(200).send(result);

         

    } catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

externalZanthusReportRouter.get('/tab_finalizadora', async (req: Request, res: Response) => {
    try {

        let result = await reportExternalZanthus.tabFinalizadora.get(req.query)
        res.status(200).send(result);

         

    } catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

externalZanthusReportRouter.get('/tab_cliente', async (req: Request, res: Response) => {
    try {

        let result = await reportExternalZanthus.tabCliente.get(req.query)
        res.status(200).send(result);

         

    } catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

externalZanthusReportRouter.get('/tab_regra_icms', async (req: Request, res: Response) => {
    try {

        let result = await reportExternalZanthus.tabRegrasIcms.get(req.query)
        res.status(200).send(result);

         

    } catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

externalZanthusReportRouter.get('/listvoucher', async (req: Request, res: Response) => {
    try {

        let result = await reportExternalZanthus.listVoucher.get(req.query)
        res.status(200).send(result);

         

    } catch (e) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})



export default externalZanthusReportRouter;