"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class tbforca_venda_tabprecoProdutoBluesoft extends modelbase_1.clsBase {
    constructor() {
        super();
        this.fv_tabelapreco_cd = 0;
        this.fv_tabelapreco_prod_seq_blue = 0;
        this.prb_cdprodutobluesoft = 0;
        this.precoEmbalagem = 0;
        this.precoUnitario = 0;
        this.descontoMaximo = 0;
        this.descontoPadrao = 0;
        this.acrescimoMaximo = 0;
        this.fatorPreco = 0;
        this.fatorEstoque = 0;
        this.versao = 0;
        this.precoPromocional = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.fv_tabelapreco_cd = item === null || item === void 0 ? void 0 : item.fv_tabelapreco_cd;
                this.fv_tabelapreco_prod_seq_blue = item === null || item === void 0 ? void 0 : item.fv_tabelapreco_prod_seq_blue;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
                this.precoEmbalagem = item === null || item === void 0 ? void 0 : item.precoEmbalagem;
                this.precoUnitario = item === null || item === void 0 ? void 0 : item.precoUnitario;
                this.descontoMaximo = item === null || item === void 0 ? void 0 : item.descontoMaximo;
                this.descontoPadrao = item === null || item === void 0 ? void 0 : item.descontoPadrao;
                this.acrescimoMaximo = item === null || item === void 0 ? void 0 : item.acrescimoMaximo;
                this.fatorPreco = item === null || item === void 0 ? void 0 : item.fatorPreco;
                this.fatorEstoque = item === null || item === void 0 ? void 0 : item.fatorEstoque;
                this.versao = item === null || item === void 0 ? void 0 : item.versao;
                this.precoPromocional = item === null || item === void 0 ? void 0 : item.precoPromocional;
            }
        });
    }
}
exports.default = tbforca_venda_tabprecoProdutoBluesoft;
