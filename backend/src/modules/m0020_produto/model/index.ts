import { clsBase, clsTools } from "../../../model/modelbase";

import { Router } from "express";


/*Models */
import modelproduto from "./modelproduto";
import modelprodutoEmbalagemGtin from "./modelprodutoEmbalagemGtin";

const modelProdutoRouter = Router();

/* Consultar um produto */
modelProdutoRouter.get('/produto/:pr_cdproduto', async (req, res) => {
    const pr_cdproduto = Number(req.params.pr_cdproduto);

    const model = new modelproduto();

    try {
        const dataQuery = await model.ConsultarDataQuery(pr_cdproduto);
        res.status(200).json(dataQuery);
    } catch (e) {
        clsTools.PagErrorException(`M0020 - PRODUTO | modelProdutoRouter`,'GET /produto/:pr_cdproduto', e );
        res.status(500).json({ error: 'Erro ao consultar o produto.' });
    }
});


modelProdutoRouter.get('/ProdutoEmbalagemGtin/:preg_cdbarra', async (req, res) => {
    const preg_cdbarra = String(req.params.preg_cdbarra);

    const model = new modelprodutoEmbalagemGtin
    try {
        const dataQuery = await model.ConsultarDataQuery(preg_cdbarra);
        res.status(200).json(dataQuery);
    } catch (e) {
        clsTools.PagErrorException(`M0020 - PRODUTO | modelProdutoRouter`,'GET /ProdutoEmbalagemGtin/:preg_cdbarra', e );
        res.status(500).json({ error: 'Erro ao consultar o produto.' });
    }
});

export default modelProdutoRouter;