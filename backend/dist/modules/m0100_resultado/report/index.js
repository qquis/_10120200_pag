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
const ReportResultado = (0, express_1.Router)();
const _reportManager_1 = __importDefault(require("./_reportManager"));
let filterReport;
const middlewareReportFechamento = (request, response, next) => __awaiter(void 0, void 0, void 0, function* () {
    var _a, _b, _c, _d, _e, _f, _g, _h;
    try {
        if (!request.query.competencia_cd && !request.query.op_cdoperacao && !request.query.r_resp_cd && !request.query.r_centro_op_cd && !request.query.r_cd) {
            response.status(400).send({ error: `Um dos filtros não foi informado` });
            return;
        }
        let filter = {
            competencia_cd: parseInt(`${((_a = request === null || request === void 0 ? void 0 : request.query) === null || _a === void 0 ? void 0 : _a.competencia_cd) ? (_b = request === null || request === void 0 ? void 0 : request.query) === null || _b === void 0 ? void 0 : _b.competencia_cd : 0}`),
            op_cdoperacao: (request.query.op_cdoperacao) ? parseInt(request.query.op_cdoperacao) : 0,
            r_resp_cd: parseInt(`${((_c = request === null || request === void 0 ? void 0 : request.query) === null || _c === void 0 ? void 0 : _c.r_resp_cd) ? (_d = request === null || request === void 0 ? void 0 : request.query) === null || _d === void 0 ? void 0 : _d.r_resp_cd : 0}`),
            r_centro_op_cd: parseInt(`${((_e = request === null || request === void 0 ? void 0 : request.query) === null || _e === void 0 ? void 0 : _e.r_centro_op_cd) ? (_f = request === null || request === void 0 ? void 0 : request.query) === null || _f === void 0 ? void 0 : _f.r_centro_op_cd : 0}`),
            r_cd: parseInt(`${((_g = request === null || request === void 0 ? void 0 : request.query) === null || _g === void 0 ? void 0 : _g.r_cd) ? (_h = request === null || request === void 0 ? void 0 : request.query) === null || _h === void 0 ? void 0 : _h.r_cd : 0}`)
        };
        filterReport = filter;
        if (filter.competencia_cd == 0)
            response.status(400).send({ error: `Competência não informada` });
        next();
    }
    catch (e) {
        return modelbase_1.clsTools.PagErrorException('routerReport', 'middlewareReportFechamento', e);
    }
});
ReportResultado.get(`/fechamento`, middlewareReportFechamento, (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        res.status(200).send(yield _reportManager_1.default.fechamento(filterReport));
    }
    catch (e) {
        return modelbase_1.clsTools.PagErrorException('Resultado', 'report/fechamento', e);
    }
}));
ReportResultado.get("/centrooperacionallistget", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.CentroOperacionalListGet();
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({});
    }
}));
ReportResultado.get("/resultadocontalistget", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        //const result = await reportManagerResultado.ResultadoContaListGet({r_rateio_cd: r_rateio_cd, r_grupo_cd: r_grupo_cd})
        const result = yield _reportManager_1.default.ResultadoContaListGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({});
    }
}));
ReportResultado.get("/resultadorateiolistget", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoRateioListGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({});
    }
}));
ReportResultado.get("/resultadoResposavellistget", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoResposavelListGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({});
    }
}));
ReportResultado.get("/resultadoOperacaolistget", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoOperacaoListGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({});
    }
}));
ReportResultado.get("/competencia", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.CompetenciaGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({ "error": "Erro ao processar o filtro" });
    }
}));
ReportResultado.get("/resultadogrupo", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoGrupoListGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({ "error": "Erro ao processar o filtro" });
    }
}));
ReportResultado.get("/resultado", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({ "error": "Erro ao processar o filtro" });
    }
}));
ReportResultado.get("/resultadofechamentolanc", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        const result = yield _reportManager_1.default.ResultadoFechamentoLancGet(req.query);
        res.status(200).send(result);
    }
    catch (e) {
        res.status(400).send({ "error": "Erro ao processar o filtro" });
    }
}));
exports.default = ReportResultado;
