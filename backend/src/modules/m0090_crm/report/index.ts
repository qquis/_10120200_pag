import { Router, request, response} from 'express'
import reportCRMCliente from './reportCRMCliente';

const reportCRMRouter = Router();

/* modulos internos */

import reportCRMSorteioRouter from './ReportCRMSorteio';




reportCRMRouter.use('/sorteio', reportCRMSorteioRouter);
reportCRMRouter.get('/clientes', async (req, res) => { 
    try { 
     
        let result = await reportCRMCliente.get(req.query)

        res.status(200).send(result);

    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }

})


export default reportCRMRouter;