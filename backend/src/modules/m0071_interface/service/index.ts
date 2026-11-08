import { Router, Request, Response } from 'express';
import { clsBase, clsTools } from '../../../model/modelbase';

const serviceInterfaceRouter = Router();

import serviceInterface from './service';

serviceInterfaceRouter.post("/interface-faturamento-processar",async (req, res) => {
    let response
    try { 

        let result = await serviceInterface.InterfaceFaturamentoProcessar.start(req.query)
        response = clsTools.responseDefault.get(200, "Atualização realizada com sucesso", result)

    } catch (e) { 
        response = clsTools.responseDefault.get(500, "Erro ao processar atualização", e)
    }

    res.send(response)
})

export default serviceInterfaceRouter;