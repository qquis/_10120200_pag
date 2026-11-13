"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const report_tab_mercadoria_1 = __importDefault(require("./report.tab_mercadoria"));
const report_tab_finalizadora_1 = __importDefault(require("./report.tab_finalizadora"));
const report_tab_cliente_1 = __importDefault(require("./report.tab_cliente"));
const report_tab_regra_icms_1 = __importDefault(require("./report.tab_regra_icms"));
const report_tab_voucher_1 = __importDefault(require("./report.tab_voucher"));
class reportExternalZanthus {
}
reportExternalZanthus.tabMercadoria = report_tab_mercadoria_1.default;
reportExternalZanthus.tabFinalizadora = report_tab_finalizadora_1.default;
reportExternalZanthus.tabCliente = report_tab_cliente_1.default;
reportExternalZanthus.tabRegrasIcms = report_tab_regra_icms_1.default;
reportExternalZanthus.listVoucher = report_tab_voucher_1.default;
exports.default = reportExternalZanthus;
