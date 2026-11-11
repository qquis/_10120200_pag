import { Router, Request, Response } from 'express';


const m1000_informe = Router();

import batch_module_m1000 from './batch';


import serviceInformeRouter from './service';
import reportInformeRouter from './report';
import modelInformeRouter from './model';


m1000_informe.use('/service', serviceInformeRouter);
m1000_informe.use('/report', reportInformeRouter);
m1000_informe.use('/model', modelInformeRouter);


m1000_informe.post('/batch/inicializacao-diaria', async (req: Request, res: Response) => {
    try { 
        await batch_module_m1000.AtualizacaoDiaria();
    
    } catch (e) {

        res.status(500).send({ error: e as string });
    }
    res.status(200).send({ message: 'Processo concluído com sucesso' });
})



export default m1000_informe;