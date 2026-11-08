import { Router } from "express";

const serviceEstatisticaRouter = Router();



import serviceEstatistica from './service/Service';

serviceEstatisticaRouter.post('/estatistica_processamento', async(Request, Response)=> {
    try {
        await serviceEstatistica.Faturamento.processar.start(Request.body);
        return Response.status(200).json({message: 'Processamento de estatística iniciado com sucesso!'});
    }

    catch(e){
        throw e;
    }

})

export default serviceEstatisticaRouter;