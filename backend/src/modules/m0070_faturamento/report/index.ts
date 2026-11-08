import { Router} from "express";

const reportFaturamentoRouter = Router();

import reportFaturamento from "./report";
import { clsBase, clsTools } from '../../../model/modelbase';
import report from "./report";

reportFaturamentoRouter.get('/statusList', async (req, res) => {
    try {
        let result = await reportFaturamento.faturamentoStatus.get(req.query)
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportFaturamentoRouter | statusList | ${e}`)
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFaturamentoRouter.get('/operacaoconferencia', async (req, res) => {
    try {
        let result = await reportFaturamento.faturamentoOperacaoConferencia.get(req.query)
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportFaturamentoRouter | operacaoconferencia | ${e}`)
        res.status(500).json({ error: 'Internal Server Error' });
    }
})

reportFaturamentoRouter.get('/export', async (req, res) => {
    try {
        let result = await reportFaturamento.faturamentoExport.get(req.query)
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportFaturamentoRouter | Export | ${e}`)
        res.status(500).json({ error: 'Internal Server Error' });
    }
})
reportFaturamentoRouter.get('/tipoContrato', async (req, res) => {
    let responseDefault : any = {}
    try {
        let result = await reportFaturamento.faturamentoContratoTipo.get(req.query)
        responseDefault = clsTools.responseDefault.get(200, "Sucesso", result)
    } catch (e) {
        responseDefault = clsTools.responseDefault.get(500, "Internal Server Error", e)
    }
    finally {
        res.status(responseDefault.status).json(responseDefault)
    }
})

reportFaturamentoRouter.get('/contrato', async (req, res) => {
    let responseDefault : any = {}
    try {
        let result = await reportFaturamento.faturamentoContrato.get(req.query)
        responseDefault = clsTools.responseDefault.get(200, "Sucesso", result)
    } catch (e) {
        responseDefault = clsTools.responseDefault.get(500, "Internal Server Error", e)
    }
    finally {
        res.status(responseDefault.status).json(responseDefault)
    }
})

reportFaturamentoRouter.get('/list', async (req, res) => {
    try {
        let result = await report.faturamentoList.get(req.query)
        res.status(200).json(result)
    } catch (e) {
        console.log(`reportFaturamentoRouter | list | ${e}`)
        res.status(500).json({ error: 'Internal Server Error' });
    }
})



export default reportFaturamentoRouter;