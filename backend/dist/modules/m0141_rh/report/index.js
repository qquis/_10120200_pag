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
const ReportRh = (0, express_1.Router)();
const reportRh_1 = __importDefault(require("./reportRh"));
ReportRh.get(`/competencia`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).send(yield reportRh_1.default.CompetenciaGet(req.query));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ReportRh', 'competencia', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
}));
ReportRh.get(`/folhacontratada`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).send(yield reportRh_1.default.FolhaContratadaGet(req.query));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ReportRh', 'relatorio', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
}));
ReportRh.get(`/folhaporcompetencia`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).send(yield reportRh_1.default.FolhaContrataPorCompetenciaGet(req.query));
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ReportRh', 'relatorio', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
}));
ReportRh.get(`/tipo_contrato`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).send(yield reportRh_1.default.TipoContrato());
        //let sql = 'select * from tbrh_tipo_contrato order by rh_tipo_contrato_descricao';
        //const myTools = new clsBase();
        //const result = await myTools.myDataBase.pag.DataGet(sql);
        //res.status(200).send(result);
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ReportRh', 'tipo_contrato', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
}));
ReportRh.get(`/setoroperacional`, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        // Implement the logic for generating the report here
        res.status(200).send(yield reportRh_1.default.SetorOperacional());
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException('ReportRh', 'tipo_contrato', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
}));
exports.default = ReportRh;
