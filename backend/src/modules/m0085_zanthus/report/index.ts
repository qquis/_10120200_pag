import { Router } from 'express';

import reportZanthus from "./report";
const reportZanthusRouter = Router();

reportZanthusRouter.get('/carga', async (req, res) => {
    try {
        const result = await reportZanthus.ZanthusCarga.get(req.query);
        res.json(result);
    } catch (e) {
        res.status(500).json({ error: e });
    }
});

export default reportZanthusRouter;