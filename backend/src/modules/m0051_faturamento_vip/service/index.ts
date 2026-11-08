import { Router, Response, Request } from "express";

import serviceFaturamentoVip    from './service';

const serviceFaturamentoVipRouter = Router();

serviceFaturamentoVipRouter.post("/processar", async (request: Request, response: Response) => {
    try {

        
        await serviceFaturamentoVip.faturamentoPedido.start(request.query);
        response.send({ message: "Processo de importação iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})


export default serviceFaturamentoVipRouter;
