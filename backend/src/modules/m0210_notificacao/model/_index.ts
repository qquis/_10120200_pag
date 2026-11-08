import { Request, Response, Router, NextFunction  } from "express";
import {clsTools} from '../../../model/modelbase'
import modelNotificacao from "./_ModelNotificacao";

const routerModelNotificacao = Router();
let myModelNotificacao : modelNotificacao = new modelNotificacao()


const middlewareQueryGetNotificacoCd = async (request: Request, response: Response, next: NextFunction) => {
    
    try {
        if (request.query.notificacao_cd === undefined) {
            return response.json({})
        }
        myModelNotificacao.notificacao.notificacao_cd = parseInt(`${request.query.notificacao_cd}`)
        await myModelNotificacao.notificacao.NotificacaoGet(parseInt(`${request.query.notificacao_cd}`))
        next() 
    } catch(e) {
        clsTools.PagErrorException('model_notificacao', 'middlewareQueryGetNotificacoCd', e)
        response.json(myModelNotificacao)
    }
}

routerModelNotificacao.get('/get', middlewareQueryGetNotificacoCd, async(request: Request, response: Response) => {
    try {
        response.send(myModelNotificacao)
    }
    catch(e) {
        return response.json({})
    }
})

routerModelNotificacao.post('/addparticipante', middlewareQueryGetNotificacoCd, async(request: Request, response: Response) => {
    try {
        let cdparticipante = parseInt(`${request.query.cdparticipante}`)
        await myModelNotificacao.NotificacaoAddParticipante(cdparticipante)
        response.send(myModelNotificacao)
    }
    catch(e) {
        clsTools.PagErrorException('model_notificacao', 'addparticipante', e)
        return response.json({})
    }
})
routerModelNotificacao.post('/delparticipante', middlewareQueryGetNotificacoCd, async(request: Request, response: Response) => {
    try {
        let cdparticipante = parseInt(`${request.query.cdparticipante}`)
        await myModelNotificacao.NotificaoDelParticipante(cdparticipante)
        response.send(myModelNotificacao)
    }
    catch(e) {
        clsTools.PagErrorException('model_notificacao', 'delParticipante', e)
        return response.json({})
    }
})


routerModelNotificacao.post('/sendmessage/start',async(request: Request, response: Response) => {
    try {
        await myModelNotificacao.ProcessNotificacaoSend(parseInt(`${request.query.notificacao_send_seq}`), modelNotificacao.NotificacaoSendProcessStatus.start)
        response.send(myModelNotificacao)
        
    }
    catch(e) {
        clsTools.PagErrorException('model_notificacao', 'delParticipante', e)
        return response.json({})
    }
})

routerModelNotificacao.post('/sendmessage/send',async(request: Request, response: Response) => {
    try {
        //myModelNotificacao.NotificacaoSendMessage.notificacao_send_seq = parseInt(`${request.query.notificacao_send_seq}`)
        await myModelNotificacao.ProcessNotificacaoSend(parseInt(`${request.query.notificacao_send_seq}`), modelNotificacao.NotificacaoSendProcessStatus.send)
        response.send(myModelNotificacao)
        
    }
    catch(e) {
        clsTools.PagErrorException('model_notificacao', 'delParticipante', e)
        return response.json({})
    }
})


export default routerModelNotificacao