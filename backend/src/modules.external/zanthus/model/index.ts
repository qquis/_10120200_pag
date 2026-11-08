
import { Router } from "express";


const external_zanthus_model = Router()

import modelExternalZanthusBase from "./model";

external_zanthus_model.get('/mercadoria', async (req, res) => { 
    
    try { 
        let mercadoriaResult = await modelExternalZanthusBase.obterDadosMercadoria(req.query)
        res.status(200).send(mercadoriaResult);

    } catch (e) {
        res.status(500).send({ error: 'Erro interno no servidor' });
    }
    
})  

external_zanthus_model.get('/cliente', async (req, res) => { 
    
    try { 
        let clienteResult = await modelExternalZanthusBase.obterDadosDoCliente(req.query)
        res.status(200).send(clienteResult);

    } catch (e) {
        res.status(500).send({ error: 'Erro interno no servidor' });
    }
    
})  



export default external_zanthus_model;