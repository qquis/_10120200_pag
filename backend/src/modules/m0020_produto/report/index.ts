import { Router } from "express"

import reportProduto from "./report"

const reportProdutoRouter = Router()

reportProdutoRouter.get("/categoria", async (req, resp) => {
    let result = {}
    try {
        result = await reportProduto.categoria.get(req.query)
        return resp.send(result) 
    } catch (ex) {

        console.log(ex)
        return resp.send(result)
    }
}) 

reportProdutoRouter.get("/list", async (req, resp) => {
    let result = {}
    try {
        result = await reportProduto.list.get(req.query)
        return resp.send(result) 
    } catch (ex) {

        console.log(ex)
        return resp.send(result)
    }
}) 

reportProdutoRouter.get("/subgrupo", async (req, resp) => {
    let result = {}
    try {
        result = await reportProduto.subgrupo.get(req.query)
        return resp.send(result) 
    } catch (ex) {

        console.log(ex)
        return resp.send(result)
    }
}) 

export default reportProdutoRouter





