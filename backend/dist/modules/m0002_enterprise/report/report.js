"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const rptEnterpriseCompetenciaListGet_1 = __importDefault(require("./rptEnterpriseCompetenciaListGet"));
const rptEnterpriseEmpresaOperacao_1 = __importDefault(require("./rptEnterpriseEmpresaOperacao"));
class reportEnterprise {
}
reportEnterprise.Competencia = rptEnterpriseCompetenciaListGet_1.default;
reportEnterprise.EmpresaOperacao = rptEnterpriseEmpresaOperacao_1.default;
exports.default = reportEnterprise;
