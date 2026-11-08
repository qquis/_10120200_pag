
import { Router, Request, Response } from "express";
import { clsBase, clsTools } from '../../../model/modelbase';

const reportFiscalRouter = Router();

import reportFiscal from "./report";

reportFiscalRouter.get('/figurafiscal-produto', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.figuraFiscalProduto.get(req.query);
        res.status(200).send(result);
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
}) 

reportFiscalRouter.get('/figurafiscal-nfce-produto', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.figuraFiscalProdutoNfce.get(req.query);
        res.status(200).send(result);
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFiscalRouter.get('/figurafiscal', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.figuraFiscal.get(req.query);
        res.status(200).send(result);
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFiscalRouter.get('/cbenef-produto', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.cbenefProduto.get(req.query); 
        res.status(200).send(result);        
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFiscalRouter.get('/cbenef', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.cbenef.get(req.query); 
        res.status(200).send(result);        
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFiscalRouter.get('/cbenef-cst', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.cbenefCst.get(req.query); 
        res.status(200).send(result);        
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFiscalRouter.get('/zanthus-tributacao-icms-pdv', async (req: Request, res: Response) => {
    try {
        const result = await reportFiscal.ZanthusTributacaoIcmsPdv.get(req.query); 

        clsTools.responseDefault.send(res, result);
    } catch (error) {
        clsTools.responseDefault.send(res, {}, "Internal Server Error ${error}", 500);
    }
})

export default reportFiscalRouter;