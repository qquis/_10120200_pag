import { Router, Request, Response } from "express";


import serviceProduto from "./service";

const serviceProdutoRouter = Router();


serviceProdutoRouter.post('/produto-subgrupo-associar-cbenef', async (req: Request, res: Response) => {
    try {
        console.log(req.body)
        const result = await serviceProduto.subGrupoAssociarCbenef.start(req.body);
        res.status(200).send(result);

    } catch (error) {
        res.status(500).json({ error: 'Internal Server Error' });
    }
})



export default serviceProdutoRouter;


