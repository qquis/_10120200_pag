"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const repor_Meta_Fabricante_list_1 = __importDefault(require("./repor.Meta.Fabricante.list"));
const repor_Meta_Fabricante_Resultado_Vendedor_1 = __importDefault(require("./repor.Meta.Fabricante.Resultado.Vendedor"));
class reportForcaVendaMeta {
}
reportForcaVendaMeta.metaFabricante = repor_Meta_Fabricante_list_1.default;
reportForcaVendaMeta.metaFabricanteResultadoVendedor = repor_Meta_Fabricante_Resultado_Vendedor_1.default;
exports.default = reportForcaVendaMeta;
