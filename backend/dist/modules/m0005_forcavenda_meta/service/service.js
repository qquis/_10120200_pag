"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceForcaVendaMeta_Fabricante_Processar_1 = __importDefault(require("./serviceForcaVendaMeta.Fabricante.Processar"));
const serviceForcaVendaMeta_Processar_1 = __importDefault(require("./serviceForcaVendaMeta.Processar"));
const serviceProcessarMetasAtuais_1 = __importDefault(require("./serviceProcessarMetasAtuais"));
class serviceForcaVendaMeta {
}
serviceForcaVendaMeta.meta = serviceForcaVendaMeta_Processar_1.default;
serviceForcaVendaMeta.metaFabricante = serviceForcaVendaMeta_Fabricante_Processar_1.default;
serviceForcaVendaMeta.metasAtuais = serviceProcessarMetasAtuais_1.default;
exports.default = serviceForcaVendaMeta;
