"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceFiscal_ImportarFigura_1 = __importDefault(require("./serviceFiscal.ImportarFigura"));
const serviceFiscal_ImportarFiguraProduto_1 = __importDefault(require("./serviceFiscal.ImportarFiguraProduto"));
const serviceFiscal_ImportarRegraFiscalNFCEProduto_1 = __importDefault(require("./serviceFiscal.ImportarRegraFiscalNFCEProduto"));
const serviceFiscal_AtualizaMapeamentoFiscal_1 = __importDefault(require("./serviceFiscal.AtualizaMapeamentoFiscal"));
const serviceFiscal_Cbenef_AtualizarProdutoPag_1 = __importDefault(require("./serviceFiscal.Cbenef.AtualizarProdutoPag"));
const serviceFiscal_Cbenef_ImportarBluesoft_1 = __importDefault(require("./serviceFiscal.Cbenef.ImportarBluesoft"));
const serviceFiscal_Cbenef_ExportarProdutoBluesoft_1 = __importDefault(require("./serviceFiscal.Cbenef.ExportarProdutoBluesoft"));
const serviceFiscal_ImportarCofins_1 = __importDefault(require("./serviceFiscal.ImportarCofins"));
const serviceFiscal_ImportarPis_1 = __importDefault(require("./serviceFiscal.ImportarPis"));
const serviceFiscal_ImportarRegraFiscalNFEProduto_1 = __importDefault(require("./serviceFiscal.ImportarRegraFiscalNFEProduto"));
class serviceFiscal {
}
serviceFiscal.FiguraFiscalRegraFiscal = serviceFiscal_ImportarFigura_1.default;
serviceFiscal.FiguraFiscalPorProdutoUnitario = serviceFiscal_ImportarFiguraProduto_1.default;
serviceFiscal.FiguraFiscalPorProdutoNfce = serviceFiscal_ImportarRegraFiscalNFCEProduto_1.default;
serviceFiscal.FiguraFiscalPorProdutoNfe = serviceFiscal_ImportarRegraFiscalNFEProduto_1.default;
serviceFiscal.atualizaMapeamentoFiscal = serviceFiscal_AtualizaMapeamentoFiscal_1.default;
serviceFiscal.cbenefAtualizarProdutoPag = serviceFiscal_Cbenef_AtualizarProdutoPag_1.default;
serviceFiscal.cbenefImportarBluesoft = serviceFiscal_Cbenef_ImportarBluesoft_1.default;
serviceFiscal.cbenefExportarProdutoBluesoft = serviceFiscal_Cbenef_ExportarProdutoBluesoft_1.default;
serviceFiscal.Pis = serviceFiscal_ImportarPis_1.default;
serviceFiscal.Cofins = serviceFiscal_ImportarCofins_1.default;
exports.default = serviceFiscal;
