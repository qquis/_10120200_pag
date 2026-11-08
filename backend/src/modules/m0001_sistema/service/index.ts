import { Request, Response, Router, NextFunction } from "express";

import {clsTools} from '../../../model/modelbase'



import serviceSistema from './serviceSistema'

const routerServiceSistema = Router();

routerServiceSistema.post('/startbackend', async(request: Request, response: Response) => { 
    try {
        await serviceSistema.BackendStart.defaultStartBackEnd()
        response.send({status: 'ok'})
    } catch (e) {
        clsTools.PagErrorException('ServiceSistema', 'startbackend', e)
        return response.json({status: `error ${e}`}).status(500)
    }
})


routerServiceSistema.post('/login', async(request: Request, response: Response) => { 
    try {
        const {sis_id, mail, password} = request.body as { sis_id: number, mail: string, password: string }

        const result = await serviceSistema.Login.Userlogin(sis_id, mail, password)

        /*
            14/04/2026
            Lembrar que a senha está sendo lida apenas do campo passwd_web, que, por enquanto, deve ser gerada via insomminia

        */




        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('ServiceSistema', 'login', e)
        return response.status(401).json({status: `${e}`})
    }
}) 

routerServiceSistema.post('/crmLogin', async(request: Request, response: Response) => { 
    try {
        const {typeRequest, mail, user_credential_number, user_credential} = request.body as { typeRequest: string, mail: string, user_credential_number: string, user_credential: string }
        //const myServiceSistemaLogin = new serviceSistemaLogin()
        const result = await serviceSistema.Login.ClienteCrmLogin(typeRequest, mail, user_credential_number, user_credential  )
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('ServiceSistema', 'login', e)
        return response.status(401).json({status: `${e}`})
    }
}) 


routerServiceSistema.get('/loginCheck', async(request: Request, response: Response) => { 
    try {
        const {usuario_login_uuid, mail} = request.body as { usuario_login_uuid: string, mail: string}
        //const myServiceSistemaLogin = new serviceSistemaLogin()
        const result : any  = await  serviceSistema.Login.checkWjt(usuario_login_uuid)
        response.send(result)
    } catch (e) {
        clsTools.PagErrorException('ServiceSistema', 'login', e)
        return response.status(401).json({status: `${e}`})
    }
}) 


routerServiceSistema.get('/passwordget', async(req: Request, res: Response) => { 
    try {
        
        let stringToCript : string = `${req.query.password}`

        let passwordCript = await serviceSistema.PassWord.generate(stringToCript)
        
        if (!passwordCript)
            res.status(200).send({ "passwordCript": passwordCript })
        else { 
            res.status(500).send({ "passwordCript": passwordCript })
        }
        
        
    } catch (e) {
        clsTools.PagErrorException('ServiceSistema', 'login', e)
        return res.status(401).json({status: `${e}`})
    }
}) 

export default routerServiceSistema
