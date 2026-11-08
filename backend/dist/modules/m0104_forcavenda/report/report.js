"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const rerpot_forcaVenda_PrazoPgto_1 = __importDefault(require("./rerpot.forcaVenda.PrazoPgto"));
const rerpot_forcaVenda_tabela_1 = __importDefault(require("./rerpot.forcaVenda.tabela"));
const rerpot_forcaVenda_tabelaVersao_1 = __importDefault(require("./rerpot.forcaVenda.tabelaVersao"));
const rerpot_forcaVenda_tabelaVersaoProduto_1 = __importDefault(require("./rerpot.forcaVenda.tabelaVersaoProduto"));
const rerpot_forcaVenda_tabelaPadrao_1 = __importDefault(require("./rerpot.forcaVenda.tabelaPadrao"));
const report_forcavenda_fabricante_1 = __importDefault(require("./report.forcavenda.fabricante"));
class reportForcaVenda {
}
reportForcaVenda.prazopgto = rerpot_forcaVenda_PrazoPgto_1.default;
reportForcaVenda.tabela = rerpot_forcaVenda_tabela_1.default;
reportForcaVenda.tabelaVersao = rerpot_forcaVenda_tabelaVersao_1.default;
reportForcaVenda.tabelaProduto = rerpot_forcaVenda_tabelaVersaoProduto_1.default;
reportForcaVenda.tabelaPadrao = rerpot_forcaVenda_tabelaPadrao_1.default;
reportForcaVenda.fabricanteFv = report_forcavenda_fabricante_1.default;
exports.default = reportForcaVenda;
