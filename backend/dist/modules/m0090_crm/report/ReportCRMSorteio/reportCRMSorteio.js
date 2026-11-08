"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportCRMSorteioTemporada_1 = __importDefault(require("./reportCRMSorteioTemporada"));
const reportCRMSorteioConsultarCupom_1 = __importDefault(require("./reportCRMSorteioConsultarCupom"));
const reportCRMSorteioNumero_1 = __importDefault(require("./reportCRMSorteioNumero"));
const reportCRMSorteioList_1 = __importDefault(require("./reportCRMSorteioList"));
class reportCRMSorteio {
}
reportCRMSorteio.Temporada = reportCRMSorteioTemporada_1.default;
reportCRMSorteio.Cupom = reportCRMSorteioConsultarCupom_1.default;
reportCRMSorteio.Numero = reportCRMSorteioNumero_1.default;
reportCRMSorteio.List = reportCRMSorteioList_1.default;
exports.default = reportCRMSorteio;
