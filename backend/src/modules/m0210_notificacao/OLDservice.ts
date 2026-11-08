/*
import { Request } from 'express';
import model_notificacao from './model/modelnotificacao';
import modelNotificacaoSendMessage  from './model/modelnotificacaoSend'
import reports from "./report/reportNotificacao"
import myTools from '../../tools/Tools';
*/






/* SERVICE

-->> NAO ESTA MAIS EM USO

export default class notificacaoService {

    public static async obterListagemDeNotificacoes(request: Request): Promise<Array<modelNotificacaoSendMessage>> {
        try {
                return await reports.ListModelNotificacao_Get(request)
        }
        catch (e) {
            throw Error(`Notificacao | Filter_Get Error ${e}`)
        }
    }

    public static async Consultar(request: Request) : Promise<modelNotificacaoSendMessage> {
        try {
                let MyModel : modelNotificacaoSendMessage = new modelNotificacaoSendMessage(0)
                await MyModel.getModelFromRequest(request); 
                await MyModel.modelConsultar();
                return MyModel; 
        }
        catch (e) {
            throw Error(`Notificacao | Filter_Get Error ${e}`)
        }
    }

    public static async Atualizar(request: Request) : Promise<modelNotificacaoSendMessage> {
        try {
                let ItemConsultar : modelNotificacaoSendMessage = new modelNotificacaoSendMessage(0)
                ItemConsultar.getModelFromRequest(request)
                await ItemConsultar.modelAtualizar();
                return ItemConsultar; 
        }
        catch (e) {
            throw Error(`Notificacao | Filter_Get Error ${e}`)
        }
    }

    public static async Start(request: Request) : Promise<modelNotificacaoSendMessage> {
        try {
            let ItemConsultar : modelNotificacaoSendMessage = new modelNotificacaoSendMessage(0)
            ItemConsultar.NotificacaoSendGet(request)
            await ItemConsultar.Start()
            return ItemConsultar; 
    }
    catch (e) {
        throw Error(`Notificacao | Filter_Get Error ${e}`)
        }
    }

    public static async Send(request: Request) : Promise<modelNotificacaoSendMessage> {
        try {
            let ItemConsultar : modelNotificacaoSendMessage = new modelNotificacaoSendMessage(0)
            ItemConsultar.NotificacaoSendGet(request)
            await ItemConsultar.Send();
            return ItemConsultar; 
    }
    catch (e) {
        throw Error(`Notificacao | Filter_Get Error ${e}`)
        }
    }

    public static async NotificaicaoGet(request: Request) : Promise<model_notificacao> {
        let MyModel : model_notificacao = new model_notificacao()
        try {
            console.log(request.query.notificacao_cd)
            let notificacao_cd = parseInt(`${request.query.notificacao_cd}`)
            await MyModel.NotificacaoGet({notificacao_cd})
            return MyModel; 
        } catch (e) {
            myTools.PagErrorException('Notificacao', 'NotificaicaoGet', e)
            return MyModel
        }
    }

    public static async NotificacaoAddParticipante(request: Request) : Promise<model_notificacao> { 
        let MyModel : model_notificacao = new model_notificacao()
        try {

            if (!request.query.notificacao_cd || !request.query.cdparticipante) { 
                throw new Error('NotificacaoAddParticipante: notificacao_cd / cdparticipante não informados')
            }

            let notificacao_cd = parseInt(`${request.query.notificacao_cd}`)
            let cdparticipante = parseInt(`${request.query.cdparticipante}`)
            await MyModel.NotificacaoGet({notificacao_cd})
            await MyModel.NotificacaoAddParticipante(cdparticipante)
            return MyModel; 
        }
        catch (e) {
            myTools.PagErrorException('Notificacao', 'NotificacaoAddParticipante', e)
            return MyModel
        }
    }
    public static async NotificacaodelParticipante(request: Request) : Promise<model_notificacao> { 
        let MyModel : model_notificacao = new model_notificacao()
        try {

            if (!request.query.notificacao_cd || !request.query.cdparticipante) { 
                throw new Error('NotificacaoAddParticipante: notificacao_cd / cdparticipante não informados')
            }

            let notificacao_cd = parseInt(`${request.query.notificacao_cd}`)
            let cdparticipante = parseInt(`${request.query.cdparticipante}`)
            await MyModel.NotificacaoGet({notificacao_cd})
            await MyModel.NotificaoDelParticipante(cdparticipante)
            return MyModel; 
        }
        catch (e) {
            myTools.PagErrorException('Notificacao', 'NotificacaoAddParticipante', e)
            return MyModel
        }
    }


}

 */


