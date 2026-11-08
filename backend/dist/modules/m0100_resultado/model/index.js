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
const modelresultado_conta_1 = __importDefault(require("./modelresultado_conta"));
const modelDRE = (0, express_1.Router)();
const modelDreConta = (0, express_1.Router)();
modelDRE.use("/conta", modelDreConta);
/*Modelos*/
let myResultadoConta = new modelresultado_conta_1.default();
const middlewareConta = ((req, resp, next) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        if (!req.query.r_conta_cd)
            resp.status(400).send({ "status": "código da conta não informado: r_conta_cd" });
        myResultadoConta = new modelresultado_conta_1.default();
        const { r_conta_cd = 0 } = req.query;
        yield myResultadoConta.modelGet(r_conta_cd);
        next();
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("m0100 | model/index", "Model/get", e);
    }
}));
modelDreConta.get("/", middlewareConta, (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        resp.status(200).send(myResultadoConta);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("m0100 | model/index", "Model/get", e);
        resp.status(500).send({ "status": `error ${e}` });
    }
}));
modelDreConta.post("/", middlewareConta, (req, resp) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        if (!req.body)
            throw new Error((req.body.status = "ERROR! Não contem body"));
        if (!req.body.r_conta_cd
            || !req.body.r_rateio_cd)
            throw new Error((req.body.status = "ERROR! Bory incompleto"));
        yield myResultadoConta.modelPost(req.body);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("m0100 | model/index", "Model/get", e);
        resp.status(500).send(req.body);
    }
    finally {
        resp.status(200).send(myResultadoConta);
    }
}));
exports.default = modelDRE;
