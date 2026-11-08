import { Router, Request, Response } from "express";

import serviceForcaVendaMeta from "./service"

const serviceForcaVendaMetaRouter = Router();

serviceForcaVendaMetaRouter.post("/forca-venda-meta-atual", async (req: Request, res: Response) => {
    try {
        await serviceForcaVendaMeta.metasAtuais.start(req.body);
        res.status(200).send({ success: true });
    } catch (e) {
        res.status(500).send({ success: false, error: e});
    }
});


serviceForcaVendaMetaRouter.post("/forca-venda-meta-processar", async (req: Request, res: Response) => {
    try {
        await serviceForcaVendaMeta.meta.start(req.body);
        res.status(200).send({ success: true });
    } catch (e) {
        res.status(500).send({ success: false, error: e});
    }
});

export default serviceForcaVendaMetaRouter;