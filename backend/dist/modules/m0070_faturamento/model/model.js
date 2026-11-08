"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const model_faturamento_contrato_1 = __importDefault(require("./model_faturamento_contrato"));
const model_faturamento_controle_1 = __importDefault(require("./model_faturamento_controle"));
class modelFaturamento {
}
modelFaturamento.contrato = model_faturamento_contrato_1.default;
modelFaturamento.controle = model_faturamento_controle_1.default;
exports.default = modelFaturamento;
