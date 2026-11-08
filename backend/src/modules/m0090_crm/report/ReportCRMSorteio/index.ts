import { Router } from "express";


import reportCRMSorteio from './reportCRMSorteio';

const reportCRMSorteioRouter  = Router();


reportCRMSorteioRouter.get('/list', async (req, res) => {
    try {
        let result = await reportCRMSorteio.List.get(req.query);

        res.status(200).send(result);

    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
});

reportCRMSorteioRouter.get('/temporada', async (req, res) => {
    try {
        let result = await reportCRMSorteio.Temporada.get(req.query);

        res.status(200).send(result);

    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
});


reportCRMSorteioRouter.get('/cupom', async (req, res) => {
    try {
        let result = await reportCRMSorteio.Cupom.get(req.query);

        res.status(200).send(result);

    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
});

reportCRMSorteioRouter.get('/numero', async (req, res) => {
    try {
        let result = await reportCRMSorteio.Numero.get(req.query);

        res.status(200).send(result);

    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
});

export default reportCRMSorteioRouter;