import { Request, response, Response, Router, NextFunction } from "express";
import serviceFaturamento from "./serviceFaturamento";

const routerFaturamentoService = Router();

routerFaturamentoService.get("/", async (req: Request, resp: Response ) => {
    try {
        const help = [
            {
                url: "/processarpedido", 
                info: "Faturamento Service | Processar pedido _ numeropedido?"
            },
        ]
        resp.status(200).send(help)
    } catch (e) {
        throw new Error(`${e}`)
    }
})

routerFaturamentoService.post("/processar", async (req: Request, resp: Response ) => {
    try {

        const reprocessaritem : boolean = req.query.reprocessaritem ? req.query.reprocessaritem === '1' : false;

        let result = await serviceFaturamento.FaturamentoProcessar(req.query);
        resp.status(200).send(result)
    } catch (e) {
        resp.status(400).send({ error: `${e}` });
    }
})

routerFaturamentoService.post("/contrato-processar-apurar", async (req: Request, resp: Response ) => {
    try {



        let result = await serviceFaturamento.faturamentoContratoService.start(req.body);
        resp.status(200).send(result)
    } catch (e) {
        resp.status(400).send({ error: `${e}` });
    }
})







export default routerFaturamentoService;