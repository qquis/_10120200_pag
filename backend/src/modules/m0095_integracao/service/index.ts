import { Router, Response, Request } from "express";
import serviceIntegracao from "./serviceIntegracao"
import modelintegracao_tipo from "../model/modelintegracao_tipo";
import router from "src/routes/router";
import { clsTools } from  "../../../model/modelbase";


const routerService = Router() 
let service : serviceIntegracao = new serviceIntegracao();



routerService.get("/", async(request: Request, response: Response) => {

    const help = [
        { 
            url : "/integrar?sis_batch_cd=9999&sis_batch_run_seq=9999", 
            info : "M0095 | Integrações - buscar e executar integrações | indicar sis_batch_cd e/ou sis_batch_run_seq"
        },
    ]

    return response.send(help)
})


routerService.post("/integrar", async(request: Request, response: Response)  => {
    try {

        let sis_batch_run_seq : number = request.query.sis_batch_run_seq? parseInt(`${request.query.sis_batch_run_seq}`) : 0
        let sis_batch_cd : number = request.query.sis_batch_cd? parseInt(`${request.query.sis_batch_cd}`): 0

        let result : any = await service.processar(sis_batch_cd, sis_batch_run_seq)


        return response.send(result)

    } catch(e) {
        return response.json({})
    }
})


routerService.post("/atualizarPendenciaPrecoD1", async(request: Request, response: Response)  => {
    try {

        let integracao_tipo_cd : number = request.query.integracao_tipo_cd? parseInt(`${request.query.integracao_tipo_cd}`) : 0

        let mymodelintegracao_tipo : modelintegracao_tipo = new modelintegracao_tipo()
        mymodelintegracao_tipo.integracao_tipo.integracao_tipo_cd = integracao_tipo_cd;
        await mymodelintegracao_tipo.GerarPendenciaDePrecos()
        return response.send(mymodelintegracao_tipo)

    } catch(e) {
        return response.json({})
    }
})


routerService.post("/cargaLojaParcial", async(request: Request, response: Response)  => {
    try {

        //console.log(`CARGA LOJA INCOMPLETA`)
        let result = await service.CargaLoja(false)
        return response.send(result)        

    } catch(e) {
        return response.json({})
    }
})

routerService.post("/cargaLojaCompleta", async(request: Request, response: Response)  => {
    try {

        // CARGA LOJA COMPLETA
        let result = await service.CargaLoja(true)
        return response.send(result)

    } catch(e) {
        return response.json({})
    }
})


routerService.post("/cacheClear", async(request: Request, response: Response)  => {
    try {

        // CARGA LOJA COMPLETA
        if (request.query.integracao_tipo_cd || parseInt(`${request.query.integracao_tipo_cd}`) != 0) {
            
            await service.ClearCache(parseInt(`${request.query.integracao_tipo_cd}`))
            return response.send({ message: `Cache Limpo`})
        }

    } catch(e) {
        clsTools.PagErrorException(`serviceIntegracao`, 'cacheClear', e);
        return response.json({notice: `Erro ao limpar cache ${e}`})
    }
})






/*
routerService.post("/integrarproduto", async(request: Request, response: Response)  => {
    try {
        console.log(`Executando Sis Batch Seq ${request.query.sis_batch_run_seq}`)

        let sis_batch_run_seq : number = parseInt(`${request.query.sis_batch_run_seq}`)

        return response.send(await service.produto.integrar(sis_batch_run_seq))

    } catch(e) {
        return response.json({})
    }
})*/





export default routerService