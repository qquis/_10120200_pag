

import reportEstoqueCusto from "./report";


import { Router } from 'express';


const reportEstoqueCustoRouter = Router();

reportEstoqueCustoRouter.get('/analise-estoque', async (req, res) => {
    try {

        const result = await reportEstoqueCusto.analise.get(req.query);
        res.status(200).json(result);
    } catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
});

export default reportEstoqueCustoRouter;



