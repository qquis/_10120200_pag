import { Request, response, Response, Router } from "express";

import serviceEstatisticaRouter from "./service";
import reportFaturamentoRouter from "./report";
import modelFaturamentoRouter from "./model";
import batch_module_m0070 from "./batch";


const faturamento = Router();


faturamento.use("/service", serviceEstatisticaRouter);
faturamento.use("/report", reportFaturamentoRouter);
faturamento.use("/model", modelFaturamentoRouter);

faturamento.get ("/", async (req: Request, resp: Response ) => {
    try {
        const help = [
            {
                url: "/report", 
                info: "Relatórios Faturamento"
            },
            {
                url: "/service", 
                info: "Services Faturamento"
            },
        ]

        return resp.send(help)
    } catch (e) {
        throw new Error(`${e}`)
    }
})


faturamento.post("/batch/atualizacao-diaria", async (req: Request, resp: Response) => {
    try {
        const result = await batch_module_m0070.AtualizacaoDiaria();
        return resp.send({ success: result });
    } catch (e) {
        return resp.status(500).send({ error: `${e}` });
    }
});

export default faturamento

