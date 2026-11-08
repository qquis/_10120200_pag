import { Router } from "express";


const modelProdutoBluesoftRouter = Router();

import modelProdutoBluesoft from "./modelProdutoBluesoft";

modelProdutoBluesoftRouter.post('/importar', async (req, res) => {
    try {

        
        const produtoBluesoft = new modelProdutoBluesoft();

        await produtoBluesoft.AtualizarProdutoBluesoftComDadosDaApi(req.query);

        res.status(200).json({ message: 'Importação de produtos iniciada com sucesso.' });
    } catch (error) {
        res.status(500).json({ error: 'Erro ao importar produtos do Bluesoft.' });
    }
})

export default modelProdutoBluesoftRouter;