import {Router } from 'express';

import serviceProdutoBluesoft from './service';
const serviceProdutoBluesoftRouter = Router();


serviceProdutoBluesoftRouter.post('/importarprodutolist', async (req, res) => {
    try {

        const result = await serviceProdutoBluesoft.Importar.start(req.body);
        res.status(200).send({ result: true, message: 'Importação de produtos iniciada com sucesso' });
    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

serviceProdutoBluesoftRouter.post('/importarproduto', async (req, res) => {
    try {
        
        const result = await serviceProdutoBluesoft.Importar.start(req.body);
        res.status(200).send(result);

    } catch (error) {
        res.status(500).json({ error: `Internal Server Error ${error}` });
    }
})

serviceProdutoBluesoftRouter.post('/processar-integracao-bluepag', async (req, res) => {
    try {

        const result = await serviceProdutoBluesoft.ProcessarImportacoes.start(req.body);
        res.status(200).send(result);

    } catch (error) {
        res.status(500).json({ error: `Internal Server Error ${error}` });
    }
})

export default serviceProdutoBluesoftRouter;