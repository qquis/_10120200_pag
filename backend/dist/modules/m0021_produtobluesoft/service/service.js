"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceProdutoBluesoftApiImportar_1 = __importDefault(require("./serviceProdutoBluesoftApiImportar"));
const serviceProdutoBluesoftProcessarImportacoes_1 = __importDefault(require("./serviceProdutoBluesoftProcessarImportacoes"));
class serviceProdutoBluesoft {
}
serviceProdutoBluesoft.ProcessarImportacoes = serviceProdutoBluesoftProcessarImportacoes_1.default;
serviceProdutoBluesoft.Importar = serviceProdutoBluesoftApiImportar_1.default;
exports.default = serviceProdutoBluesoft;
