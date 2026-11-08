"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceEstatistica_FaturamentoProcessar_1 = __importDefault(require("./serviceEstatistica.FaturamentoProcessar"));
class serviceEstatisticaFaturamento {
}
serviceEstatisticaFaturamento.processar = serviceEstatistica_FaturamentoProcessar_1.default;
exports.default = serviceEstatisticaFaturamento;
