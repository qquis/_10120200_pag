"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportCRMCliente_1 = __importDefault(require("./reportCRMCliente"));
const reportCRMSorteio_1 = __importDefault(require("./ReportCRMSorteio/reportCRMSorteio"));
class reportCRM {
}
reportCRM.clientes = reportCRMCliente_1.default;
reportCRM.sorteio = reportCRMSorteio_1.default;
exports.default = reportCRM;
