import {Request, Response, Router} from 'express'
import { clsTools} from '../../../model/modelbase';

const reportEnterpriseRouter = Router();
import reportEnterprise from './report';

reportEnterpriseRouter.get("/competenciaListGet", async (req : Request, resp: Response) => {
    try {
        const result = await reportEnterprise.Competencia.get(req.query);
        resp.send(result);
    } catch (e) { 
        clsTools.PagErrorException("M0002", "reportEnterpriseCompetencia", e)
    }
})


reportEnterpriseRouter.get("/empresaOperacaoListGet", async (req : Request, resp: Response) => {
    try {
        const result = await reportEnterprise.EmpresaOperacao.getModelOperacao(req.query);
        resp.send(result);
    } catch (e) { 
        clsTools.PagErrorException("M0002", "reportEnterpriseEmpresaOperacao", e)
    }
})



export default reportEnterpriseRouter;