import { Request, Response, Router, NextFunction, response } from "express";
import serviceNotificacao from './_serviceNotificacao'
import {clsTools} from '../../../model/modelbase'



const routerServiceNotificacao = Router();





routerServiceNotificacao.post('/processar', async(request: Request, response: Response) => { 
    try {
        let notificacao_cd = parseInt(`${request.query.notificacao_cd}`)
        let parametros = request.query
        let body = request.body


   


        response.send(await serviceNotificacao.GerarEnvio(notificacao_cd, parametros, body))
    } catch (e) {
        clsTools.PagErrorException('serviceNotificacao', 'processarNotificacao', e)
        return response.json({})
    }
})


routerServiceNotificacao.post('/teste', async(request: Request, response: Response) => {
    try {
        console.log(request.query)
        let result = await serviceNotificacao.MessageWhatsTeste(parseInt(`${request.query.notificacao_send_tipo_cd}`), `${request.query.notificacao_celular_dd_numero}`, `${request.query.notificacao_send_message}`)
        response.send(clsTools.responseDefault.get(200, `Teste de envio de mensagem`, result))
        
    } catch (e) {
        clsTools.PagErrorException('serviceNotificacao', 'teste', e)
        response.send(clsTools.responseDefault.get(404, `Erro ${e}`, null))
    }
})

export default routerServiceNotificacao
