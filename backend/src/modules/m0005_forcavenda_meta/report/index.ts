import { Router } from "express";

import reportForcaVendaMeta from './report';
const reportForcaVendaMetaRouter = Router();

reportForcaVendaMetaRouter.get('/meta-fabricante', async (req, res) => {
    const result = await reportForcaVendaMeta.metaFabricante.get(req.query);
    res.json(result);
});




export default reportForcaVendaMetaRouter;