import { Router, Response, Request} from 'express'
import { clsTools } from '../../../model/modelbase';
//import serviceResultado from './serviceResultado';
import serviceFinanceiro from './service';


const serviceFinanceiroRouter = Router(); 

serviceFinanceiroRouter.get('/atualizar', async (request: Request, response: Response) => { 
    
    let res = []
    try {
        await response.send(await serviceFinanceiro.AutorizacaoPgtoAtualizar()); 
    } catch (e) {
        console.log(e)
        response.send({"Registros": 0})
    }
})


serviceFinanceiroRouter.get('/atualizarduplicata', async (req: Request, resp: Response) => { 
    

    try {
        
        let result = await serviceFinanceiro.AutorizacaoPgtoAtualizarDuplicata(req.query);
        resp.status(200).send(result)
        
    } catch (e) {
        console.log(e)
        resp.send({})
    }
})


serviceFinanceiroRouter.get('/movimentocaixabluesoftatualizar', async (req: Request, resp: Response) => { 
    

    try {
        
        let result = await serviceFinanceiro.MovimentoCaixaBluesoftAtualizar();
        resp.status(200).send(result)
        
    } catch (e) {
        console.log(e)
        resp.send({})
    }
})

serviceFinanceiroRouter.post('/formapgto-atualizar', async (req: Request, resp: Response) => { 
    try {
        await serviceFinanceiro.FinanceiroFormaPgto.start(req.query);
        resp.status(200).send({"status": "ok"});
    } catch (e) {
        console.log(e)
        resp.send({"status": "error"})
    }
})


export default serviceFinanceiroRouter;