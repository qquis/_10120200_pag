import { Router } from "express";

import reportForcaVenda from "./report";

const reportForcaVendaRouter = Router();

reportForcaVendaRouter.get('/prazo-pgto', async (req, res) => {
    try {
        const result = await reportForcaVenda.prazopgto.get()
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportForcaVendaRouter.get /prazo-pgto Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/prazo-pgto Error ${e}` })
    }
})

reportForcaVendaRouter.get('/tabela', async (req, res) => {
    try {
        const result = await reportForcaVenda.tabela.get(req.query)
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela Error ${e}` })
    }
})

reportForcaVendaRouter.get('/tabela-versao', async (req, res) => {
    try {
        const result = await reportForcaVenda.tabelaVersao.get(req.query) 
        res.status(200).json(result)
    }   
        catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-versao Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-versao Error ${e}` })
    }
})

reportForcaVendaRouter.get('/tabela-produto', async (req, res) => {
    try {
        const result = await reportForcaVenda.tabelaProduto.get(req.query) 
        res.status(200).json(result)
    }   
        catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-produto Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-produto Error ${e}` })
    }
})

reportForcaVendaRouter.get('/tabela-padrao', async (req, res) => {
    try {
        if (req.query.mail && req.query.mail == "1") {
            await reportForcaVenda.tabelaPadrao.mail(req.query)
            return res.status(200).json({status: 1, info: "E-mail enviado com sucesso"})
        } else { 
            const result = await reportForcaVenda.tabelaPadrao.get(req.query) 
            res.status(200).json(result)
        }
    }   
        catch (e) {
        console.log(`reportForcaVendaRouter.get /tabela-padrao Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/tabela-padrao Error ${e}` })
    }
})

reportForcaVendaRouter.get('/fabricante-fv', async (req, res) => {
    try {
        const result = await reportForcaVenda.fabricanteFv.get(req.query) 
        res.status(200).json(result)
    }   
        catch (e) {
        console.log(`reportForcaVendaRouter.get /fabricante Error ${e}`)
        res.status(500).json({ error: `reportForcaVendaRouter.get /report/fabricante Error ${e}` })
    }
})
export default reportForcaVendaRouter

