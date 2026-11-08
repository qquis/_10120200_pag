import { Router } from "express";



import reportFaturamentoBluesoftRouter from "./report";
import FaturamentoBluesoftServiceRouter from "./service";
import FaturamentoBluesoftApiRouter from "./api";
import modelFaturamentoBLuesoftRouter from "./model";
import batch_module_m0050 from "./batch";



const routerFaturamentoBluesoft = Router();

routerFaturamentoBluesoft.use("/report", reportFaturamentoBluesoftRouter);
routerFaturamentoBluesoft.use("/service", FaturamentoBluesoftServiceRouter);
routerFaturamentoBluesoft.use("/bluesoftapi", FaturamentoBluesoftApiRouter);
routerFaturamentoBluesoft.use("/model", modelFaturamentoBLuesoftRouter);
routerFaturamentoBluesoft.post("/batch/atualizacao-diaria", async (req, resp) => {
    try {
        await batch_module_m0050.AtualizacaoDiaria();
        resp.json({ message: "ok" });
    } catch (error) {
        resp.json({ message: "error" });
    }
});

export default routerFaturamentoBluesoft






