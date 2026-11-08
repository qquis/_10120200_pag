"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportFiguraFiscalProduto_1 = __importDefault(require("./reportFiguraFiscalProduto"));
const reportFiguraFiscalProdutoNfce_1 = __importDefault(require("./reportFiguraFiscalProdutoNfce"));
const reportFiguraFiscal_1 = __importDefault(require("./reportFiguraFiscal"));
const reportCbenefProduto_1 = __importDefault(require("./reportCbenefProduto"));
const reportCbenef_1 = __importDefault(require("./reportCbenef"));
const reportCbenefcst_1 = __importDefault(require("./reportCbenefcst"));
const report_Zanthus_TributacaoIcmsPdv_1 = __importDefault(require("./report.Zanthus.TributacaoIcmsPdv"));
class reportFiscal {
}
reportFiscal.figuraFiscalProduto = reportFiguraFiscalProduto_1.default;
reportFiscal.figuraFiscalProdutoNfce = reportFiguraFiscalProdutoNfce_1.default;
reportFiscal.figuraFiscal = reportFiguraFiscal_1.default;
reportFiscal.cbenefProduto = reportCbenefProduto_1.default;
reportFiscal.cbenef = reportCbenef_1.default;
reportFiscal.cbenefCst = reportCbenefcst_1.default;
reportFiscal.ZanthusTributacaoIcmsPdv = report_Zanthus_TributacaoIcmsPdv_1.default;
exports.default = reportFiscal;
