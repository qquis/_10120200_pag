"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportProdutoCadastro_1 = __importDefault(require("../report/reportProdutoCadastro"));
const reportprodutocategoria_1 = __importDefault(require("../report/reportprodutocategoria"));
const reportprodutoSubGrupoLIst_1 = __importDefault(require("../report/reportprodutoSubGrupoLIst"));
class reportProduto {
}
reportProduto.list = reportProdutoCadastro_1.default;
reportProduto.categoria = reportprodutocategoria_1.default;
reportProduto.subgrupo = reportprodutoSubGrupoLIst_1.default;
exports.default = reportProduto;
