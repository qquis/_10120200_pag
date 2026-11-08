import { Router, Request, Response } from 'express';

import reportProdutoBluesoft    from './report';
import { clsTools } from '../../../model/modelbase';

const reportProdutoBluesoftRouter = Router();

reportProdutoBluesoftRouter.get('/list', async (req: Request, res: Response) => {
    let result : any = {}
    try {
        const data = await reportProdutoBluesoft.list.get(req.query);
        result = clsTools.responseDefault.get(200, "Processamento concluído com sucesso.", data);

    } catch (e) {
        result = clsTools.responseDefault.get(500, "Ocorreu um erro durante o processamento.", e);

    }

    finally {
        res.status(result.status || 200).json(result);
    }
});

export default reportProdutoBluesoftRouter;