"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const modelbase_1 = require("../../../model/modelbase");
const serviceFiscalRouter = (0, express_1.Router)();
const LOG_FILE_NAME = 'M0041';
const service_1 = __importDefault(require("./service"));
serviceFiscalRouter.post('/figurafiscal/atualizar-figura-regra', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        yield service_1.default.FiguraFiscalRegraFiscal.start();
        result = modelbase_1.clsTools.responseDefault.get(200, "Base de Figura Fiscal atualizada com sucesso.", {});
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/figurafiscal/atualizar-figura-regra', error);
        result = modelbase_1.clsTools.responseDefault.get(500, "Erro ao atualizar a base de Figura Fiscal.", {});
    }
    finally {
        res.status(result.status).send(result);
    }
}));
serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-unitario', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        yield service_1.default.FiguraFiscalPorProdutoUnitario.start(req.query);
        result = modelbase_1.clsTools.responseDefault.get(200, "atualizar-figura-produto-unitario atualizada com sucesso.", {});
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-unitario', error);
        result = modelbase_1.clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-unitario.", {});
    }
    finally {
        res.status(result.status).send(result);
    }
}));
serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-nfce', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        //console.log(`DADOS DA RQUERY: `, req.query);
        yield service_1.default.FiguraFiscalPorProdutoNfce.start(req.query);
        result = modelbase_1.clsTools.responseDefault.get(200, "atualizar-figura-produto-nfce atualizada com sucesso.", {});
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-nfce', error);
        result = modelbase_1.clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-nfce.", {});
    }
    finally {
        res.status(result.status).send(result);
    }
}));
serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-nfe', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        //console.log(`DADOS DA RQUERY: `, req.query);
        yield service_1.default.FiguraFiscalPorProdutoNfe.start(req.query);
        result = modelbase_1.clsTools.responseDefault.get(200, "atualizar-figura-produto-nfe atualizada com sucesso.", {});
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-nfe', error);
        result = modelbase_1.clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-nfe.", {});
    }
    finally {
        res.status(result.status).send(result);
    }
}));
serviceFiscalRouter.post('/atualizacaogeral', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let result;
    try {
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL _ Atualização Geral Iniciando...", false, false, LOG_FILE_NAME);
        /*PIS/COFINS*/
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Base PIS/COFINS", false, false, LOG_FILE_NAME);
        yield service_1.default.Pis.start();
        yield service_1.default.Cofins.start();
        /*FIGURA FISCAL GERAL */
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Base FIGURA FISCAL", false, false, LOG_FILE_NAME);
        yield service_1.default.FiguraFiscalRegraFiscal.start();
        /*FIGURA NFCE */
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Atualizando base de NFEC e FIGURA FISCAL Produto...", false, false, LOG_FILE_NAME);
        yield service_1.default.FiguraFiscalPorProdutoNfce.start({});
        /*MAPEAMENTO FISCAL */
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Atualizando mapeamento fiscal...", false, false, LOG_FILE_NAME);
        yield service_1.default.atualizaMapeamentoFiscal.start();
        result = modelbase_1.clsTools.responseDefault.get(200, "Base de Figura Fiscal atualizada com sucesso.", {});
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/atualizacaogeral', error);
        result = modelbase_1.clsTools.responseDefault.get(500, "Erro ao atualizar a base de Figura Fiscal.", {});
    }
    finally {
        res.status(result.status).send(result);
    }
}));
serviceFiscalRouter.post('/cbenefAtualizarProdutoPag', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.cbenefAtualizarProdutoPag.start(req.body);
        res.status(200).send({ message: 'Atualização realizada com sucesso.' });
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefAtualizarProdutoPag', error);
        res.status(500).send({ error: 'Erro ao atualizar a base de Figura Fiscal.', details: error });
    }
}));
serviceFiscalRouter.post('/cbenefImportarBluesoft', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield service_1.default.cbenefImportarBluesoft.start(req.query);
        res.status(200).send({ message: 'Atualização realizada com sucesso.' });
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefImportarBluesoft', error);
        res.status(500).send({ error: 'Erro ao importar CBenef do Bluesoft.', details: error });
    }
}));
serviceFiscalRouter.post('/cbenefExportarProdutoBluesoft', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield modelbase_1.clsTools.pagConsole("Iniciando exportação de produtos para o Bluesoft...", false, false, LOG_FILE_NAME);
        yield service_1.default.cbenefExportarProdutoBluesoft.start(req.body);
        res.status(200).send({ message: 'Exportação realizada com sucesso.' });
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefExportarProdutoBluesoft', error);
        res.status(500).send({ error: 'Erro ao exportar produtos para o Bluesoft.', details: error });
    }
}));
serviceFiscalRouter.post('/atualizacao-pis-cofins', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL _ PIS", false, false, LOG_FILE_NAME);
        /*PIS/COFINS*/
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Base PIS", false, false, LOG_FILE_NAME);
        yield service_1.default.Pis.start();
        yield modelbase_1.clsTools.pagConsole("AMBIENTE FISCAL | Base COFINS", false, false, LOG_FILE_NAME);
        yield service_1.default.Cofins.start();
        res.status(200).send({ message: 'Base de PIS atualizada com sucesso.' });
    }
    catch (error) {
        yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/atualizacao-pis-cofins', error);
        res.status(500).send({ error: 'Erro ao atualizar a base de PIS.', details: error });
    }
}));
exports.default = serviceFiscalRouter;
