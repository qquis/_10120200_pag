import { Router} from "express";
import { clsTools } from "../../../model/modelbase";

import modelFaturamento from "./model";





const modelFaturamentoRouter = Router();
const submodelFaturamentoRouterContrato = Router();


modelFaturamentoRouter.use('/contrato', submodelFaturamentoRouterContrato);

modelFaturamentoRouter.get('/faturamento', async (req, res) => {
    let responseDefaut : any = {}
    try {
        let result = await modelFaturamento.controle.get(req.query)
        responseDefaut = clsTools.responseDefault.get(200, "Success", result)
    } catch (e) {
        responseDefaut = clsTools.responseDefault.get(500, "Internal Server Error")
    }

    finally {
        res.status(responseDefaut.status).send(responseDefaut)
    }

});






submodelFaturamentoRouterContrato.post('/', async (req, res) => {
    let responseDefaut : any = {}
    try {
        
        let result = await modelFaturamento.contrato.post(req.body); 
        
        responseDefaut = clsTools.responseDefault.get(200, "Success", result)
        
    } catch (e) {
        
        responseDefaut = clsTools.responseDefault.get(500, "Internal Server Error")
    }

    finally {
        res.status(responseDefaut.status).send(responseDefaut)
    }

});

submodelFaturamentoRouterContrato.get('/', async (req, res) => {
    let responseDefaut : any = {}
    try {
        
        let result = await modelFaturamento.contrato.get(req.query); 
        
        responseDefaut = clsTools.responseDefault.get(200, "Success", result)
        
    } catch (e) {
        
        responseDefaut = clsTools.responseDefault.get(500, "Internal Server Error")
    }

    finally {
        res.status(responseDefaut.status).send(responseDefaut)
        
    }

});

submodelFaturamentoRouterContrato.post('/inativar', async (req, res) => {
    let responseDefaut : any = {}
    try {
        
        let result = await modelFaturamento.contrato.contratoInativar(req.query); 
        
        responseDefaut = clsTools.responseDefault.get(200, "Success", result)
        
    } catch (e) {
        
        responseDefaut = clsTools.responseDefault.get(500, "Internal Server Error")
    }

    finally {
        res.status(responseDefaut.status).send(responseDefaut)
        
    }

});



submodelFaturamentoRouterContrato.get('/produto-list', async (req, res) => {
    let responseDefaut : any = {}
    try {
        let result = await modelFaturamento.contrato.consultarContratoProdutoItensFornecedor(req.query)
        responseDefaut = clsTools.responseDefault.get(200, "Success", result)
    } catch (e) {
        responseDefaut = clsTools.responseDefault.get(500, "Internal Server Error")
    }

    finally {
        res.status(responseDefaut.status).send(responseDefaut)
    }
});


export default modelFaturamentoRouter;