import { clsBase, clsTools } from "../../../model/modelbase";
import { Router } from "express";

import serviceCRM from "./service";

const serviceCRMRouter = Router();

serviceCRMRouter.get("/status", async (req, res) => {
    try {
        res.status(200).json({ status: "CRM Service is running" });
    } catch (error) {
        clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - status", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
});



serviceCRMRouter.post("/sorteio/atualizar", async (req, res) => {
    try {
        await serviceCRM.CrmSorteio.AtualizarBase.start(req.query);
        res.status(200).json({ message: "Atualização de Base Realizada com sucesso" });
    } catch (error) {
        clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
});



serviceCRMRouter.post("/sorteio/gerartemporada", async (req, res) => {
    try {
        await serviceCRM.CrmSorteio.GerarTemporada.start();
        res.status(200).json({ message: "Geração de Temporada Realizada com sucesso" });
    } catch (error) {
        clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
});



serviceCRMRouter.post("/sorteio/exportar", async (req, res) => {
    try {
        await serviceCRM.CrmSorteio.Exportar.start(req.query);
        res.status(200).json({ message: "Exportação de Temporada Realizada com sucesso" });
    } catch (error) {
        clsTools.PagErrorException("M0090_CRM", "serviceCRMRouter - Erro na atualização da base", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
});

export default serviceCRMRouter;