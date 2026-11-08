import {Request, Response, Router} from 'express'
import { clsTools, clsBase} from '../../../model/modelbase';

import reportFinanceiro from './report';


const reportFinanceiroRouter = Router();
reportFinanceiroRouter.get("/autorizacaopgto", async (req : Request, resp: Response) => {
    try {
        const result = await reportFinanceiro.autorizacaoPgtoGet(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0080", "rerpotfinaceiro", e)
        
    }
})


reportFinanceiroRouter.get("/autorizacaopgtopag", async (req : Request, resp: Response) => {
    try {
        const result = await reportFinanceiro.autorizacaoPgtoPagGet(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0080", "rerpotfinaceiro", e)
        
    }
})


reportFinanceiroRouter.get("/fluxocaixa", async (req : Request, resp: Response) => {
    try {
        const result = await reportFinanceiro.fluxoCaixaGet(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0080", "rerpotfinaceiro", e)
        
    }
})

reportFinanceiroRouter.get("/formapgto-bluesoft", async (req : Request, resp: Response) => {
    try {
        const result = await reportFinanceiro.formaPgtoBlueSoft.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0080", "rerpotfinaceiro", e)
        
    }
})


export default reportFinanceiroRouter