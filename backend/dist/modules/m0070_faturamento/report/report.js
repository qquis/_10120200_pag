"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportFaturamentoStatus_1 = __importDefault(require("./reportFaturamentoStatus"));
const reportFaturamentoOperacaoConferencia_1 = __importDefault(require("./reportFaturamentoOperacaoConferencia"));
const reportFaturamentoExport_1 = __importDefault(require("./reportFaturamentoExport"));
const reportFaturamento_Contrato_Tipo_1 = __importDefault(require("./reportFaturamento.Contrato.Tipo"));
const reportFaturamento_Contrato_1 = __importDefault(require("./reportFaturamento.Contrato"));
const reportFaturamento_list_1 = __importDefault(require("./reportFaturamento.list"));
class reportFaturamento {
}
reportFaturamento.faturamentoStatus = reportFaturamentoStatus_1.default;
reportFaturamento.faturamentoOperacaoConferencia = reportFaturamentoOperacaoConferencia_1.default;
reportFaturamento.faturamentoExport = reportFaturamentoExport_1.default;
reportFaturamento.faturamentoContratoTipo = reportFaturamento_Contrato_Tipo_1.default;
reportFaturamento.faturamentoContrato = reportFaturamento_Contrato_1.default;
reportFaturamento.faturamentoList = reportFaturamento_list_1.default;
exports.default = reportFaturamento;
