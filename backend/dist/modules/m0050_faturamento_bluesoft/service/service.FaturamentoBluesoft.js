"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const service_FaturamentoBlueSoftApi_1 = __importDefault(require("./service.FaturamentoBlueSoftApi"));
const service_FaturamentoBluesoft_Import_1 = __importDefault(require("./service.FaturamentoBluesoft.Import"));
const service_FaturamentoBluesoft_Import_FomApi_1 = __importDefault(require("./service.FaturamentoBluesoft.Import.FomApi"));
class serviceFaturamentoBluesoft {
}
serviceFaturamentoBluesoft.BlueSoftApi = service_FaturamentoBlueSoftApi_1.default;
serviceFaturamentoBluesoft.Import = service_FaturamentoBluesoft_Import_1.default;
serviceFaturamentoBluesoft.ImportFromApi = service_FaturamentoBluesoft_Import_FomApi_1.default;
exports.default = serviceFaturamentoBluesoft;
