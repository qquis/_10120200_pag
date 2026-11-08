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
const modelCRMRouter = (0, express_1.Router)();
const modelcrmSorteioRouter = (0, express_1.Router)();
modelCRMRouter.use('/sorteio', modelcrmSorteioRouter);
const modelcrm_sorteio_cupom_1 = __importDefault(require("./modelcrm_sorteio_cupom"));
modelcrmSorteioRouter.get('/consultar', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let modelitem = new modelcrm_sorteio_cupom_1.default();
    try {
        modelitem = new modelcrm_sorteio_cupom_1.default();
        yield modelitem.consultar(req.query);
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
    finally {
        res.status(200).send(modelitem);
    }
}));
modelcrmSorteioRouter.get('/registrarCupom', (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let modelitem = new modelcrm_sorteio_cupom_1.default();
    try {
        modelitem = new modelcrm_sorteio_cupom_1.default();
        if (!req.query.nf_chave) {
            res.status(400).send({ error: "Parâmetro nf_chave é obrigatório." });
            return;
        }
        if (!req.query.crm_so_cpf) {
            res.status(400).send({ error: "Parâmetro crm_so_cpf é obrigatório." });
            return;
        }
        yield modelitem.consultar(req.query);
        console.log('item a registrar consultado', modelitem);
        if (modelitem.nf_chave) {
            modelitem.crm_so_cpf = String(req.query.crm_so_cpf);
            yield modelitem.registrar_cupom();
        }
        else {
            res.status(404).send({ error: "Cupom não encontrado para a chave informada" });
            return;
        }
    }
    catch (e) {
        res.status(500).send({ error: e.message });
    }
    finally {
        res.status(200).send(modelitem);
    }
}));
exports.default = modelCRMRouter;
