"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceCRMSorteioAtualizarBase_1 = __importDefault(require("./serviceCRMSorteioAtualizarBase"));
const serviceCRMSorteioGerarTemporada_1 = __importDefault(require("./serviceCRMSorteioGerarTemporada"));
const serviceCRMSorteioExportar_1 = __importDefault(require("./serviceCRMSorteioExportar"));
class serviceCrmSoteio {
}
serviceCrmSoteio.AtualizarBase = serviceCRMSorteioAtualizarBase_1.default;
serviceCrmSoteio.GerarTemporada = serviceCRMSorteioGerarTemporada_1.default;
serviceCrmSoteio.Exportar = serviceCRMSorteioExportar_1.default;
exports.default = serviceCrmSoteio;
