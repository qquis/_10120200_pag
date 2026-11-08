import {NextFunction, query, Request, Response, Router} from 'express'
import { clsTools, clsBase} from '../../../model/modelbase';
import { ifilter } from "../interfaces";

const ReportResultado = Router();

import reportManagerResultado from './_reportManager';
let filterReport : ifilter

const middlewareReportFechamento = async (request: Request, response: Response, next: NextFunction) => { 
    try { 


        if (!request.query.competencia_cd && !request.query.op_cdoperacao && !request.query.r_resp_cd && !request.query.r_centro_op_cd && !request.query.r_cd) {
            response.status(400).send({error: `Um dos filtros não foi informado`})
            return
        }

        let filter: ifilter = {
            competencia_cd: parseInt(`${request?.query?.competencia_cd? request?.query?.competencia_cd: 0 }`),    
            op_cdoperacao: (request.query.op_cdoperacao) ? parseInt(request.query.op_cdoperacao as string) : 0,    
            r_resp_cd: parseInt(`${request?.query?.r_resp_cd? request?.query?.r_resp_cd: 0 }`),  
            r_centro_op_cd: parseInt(`${request?.query?.r_centro_op_cd? request?.query?.r_centro_op_cd: 0 }`),
            r_cd:parseInt(`${request?.query?.r_cd? request?.query?.r_cd: 0 }`)
                    }
        filterReport = filter;

        if (filter.competencia_cd == 0)
            response.status(400).send({error: `Competência não informada`})

        next()    

    } catch (e) { 
        return clsTools.PagErrorException('routerReport', 'middlewareReportFechamento', e)
       
    }
}



ReportResultado.get(`/fechamento`, middlewareReportFechamento, async (req: Request, res: Response) => {
    try {
        res.status(200).send(await reportManagerResultado.fechamento(filterReport));
    } catch (e) {
        return clsTools.PagErrorException('Resultado', 'report/fechamento', e);

    }
});


ReportResultado.get("/centrooperacionallistget", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.CentroOperacionalListGet()
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({})
    }
})

ReportResultado.get("/resultadocontalistget", async(req: Request, res: Response) => { 
    try {
            //const result = await reportManagerResultado.ResultadoContaListGet({r_rateio_cd: r_rateio_cd, r_grupo_cd: r_grupo_cd})
            const result = await reportManagerResultado.ResultadoContaListGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({})
    }
})

ReportResultado.get("/resultadorateiolistget", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoRateioListGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({})
    }
})

ReportResultado.get("/resultadoResposavellistget", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoResposavelListGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({})
    }
})

ReportResultado.get("/resultadoOperacaolistget", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoOperacaoListGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({})
    }
})

ReportResultado.get("/competencia", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.CompetenciaGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({"error": "Erro ao processar o filtro"})
    }
})

ReportResultado.get("/resultadogrupo", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoGrupoListGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({"error": "Erro ao processar o filtro"})
    }
})



ReportResultado.get("/resultado", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({"error": "Erro ao processar o filtro"})
    }
})

ReportResultado.get("/resultadofechamentolanc", async(req: Request, res: Response) => { 
    try {
            const result = await reportManagerResultado.ResultadoFechamentoLancGet(req.query)
            res.status(200).send(result)

    } catch (e) { 
        res.status(400).send({"error": "Erro ao processar o filtro"})
    }
})

export default ReportResultado;


