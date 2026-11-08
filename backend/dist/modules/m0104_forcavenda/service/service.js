"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const service_Import_PrazoPgto_1 = __importDefault(require("./service.Import.PrazoPgto"));
const service_Import_TabelaPreco_1 = __importDefault(require("./service.Import.TabelaPreco"));
class serviceForcaVenda {
}
serviceForcaVenda.prazoPgto = service_Import_PrazoPgto_1.default;
serviceForcaVenda.tabelaPreco = service_Import_TabelaPreco_1.default;
exports.default = serviceForcaVenda;
