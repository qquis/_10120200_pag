import { clsTools, clsBase } from "../../../model/modelbase";
import { Router, request, response} from 'express'

import reportParticipante from "./report";




const reportParticipanteRouter = Router();

reportParticipanteRouter.get('/list', async(request, response) => {
    try {

        const result = await reportParticipante.List.get(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'list', e)
        return response.status(500).json({status: `error ${e}`})
    }
})

reportParticipanteRouter.get('/list-participante-grupo-economico', async(request, response) => {
    try {

        const result = await reportParticipante.GrupoEconomicoList.get(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'list-participante-grupo-economico', e)
        return response.status(500).json({status: `error ${e}`})
    }
})


reportParticipanteRouter.get('/redshift/list', async(request, response) => {
    try {

        const result = await reportParticipante.Redshift.get(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'list', e)
        return response.status(500).json({status: `error ${e}`})
    }
})



reportParticipanteRouter.get('/list-pagvendedor', async(request, response) => {
    try {

        const result = await reportParticipante.List.getPagVendedor(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'list-pagvendedor', e)
        return response.status(500).json({status: `error ${e}`})
    }
})

reportParticipanteRouter.get('/list-pagfabricante', async(request, response) => {
    try {

        const result = await reportParticipante.List.getPagFabricante(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'list-pagfabricante', e)
        return response.status(500).json({status: `error ${e}`})
    }
})

reportParticipanteRouter.get('/tipolist', async(request, response) => {
    try {
        const result = await reportParticipante.TipoList.get(request.query)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('reportParticipanteRouter', 'tipolist', e)
        return response.status(500).json({status: `error ${e}`})
    }
})


export default reportParticipanteRouter;