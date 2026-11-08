import { clsTools, clsBase} from '../../../model/modelbase';

import {Request, Response, Router} from 'express'

import reportSistema from './report';


const reportSistemaRouter = Router();


reportSistemaRouter.get("/list", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.List.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaList", e)
    }
})

reportSistemaRouter.get("/nucleo", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.Nucleo.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaNucleo", e)
    }
})

reportSistemaRouter.get("/nucleoprocedimento", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.NucleoProcedimento.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaNucleoProcedimento", e)
    }
})

reportSistemaRouter.get("/tarefa", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.Tarefa.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaTarefa", e)
    }
})

reportSistemaRouter.get("/permissao", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.Permissao.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaPermissao", e)
    }
})



reportSistemaRouter.get("/funcao", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.Funcao.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaFuncao", e)
    }
})

reportSistemaRouter.get("/acesso", async (req : Request, resp: Response) => {
    try {
        const result = await reportSistema.Acesso.get(req.query)
        resp.send(result)
    } catch (e) { 
        clsTools.PagErrorException("M0001 - Sistema", "reportSistemaAcesso", e)
    }
})



export default reportSistemaRouter