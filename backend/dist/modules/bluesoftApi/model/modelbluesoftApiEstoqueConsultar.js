"use strict";
var __rest = (this && this.__rest) || function (s, e) {
    var t = {};
    for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
        t[p] = s[p];
    if (s != null && typeof Object.getOwnPropertySymbols === "function")
        for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) {
            if (e.indexOf(p[i]) < 0 && Object.prototype.propertyIsEnumerable.call(s, p[i]))
                t[p[i]] = s[p[i]];
        }
    return t;
};
Object.defineProperty(exports, "__esModule", { value: true });
class Estoque {
    constructor(_a) {
        var Estoque = __rest(_a, []);
        this.produtoKey = Estoque.produtoKey;
        this.lojaKey = Estoque.lojaKey;
        this.gtinPrincipal = Estoque.gtinPrincipal;
        this.saldoOnline = Estoque.saldoOnline;
        this.saldoFisico = Estoque.saldoFisico;
        this.gtinsAdicionais = Estoque.gtinsAdicionais;
        this.saldoDisponivel = Estoque.saldoDisponivel;
        this.mediaVendaDiaria = Estoque.mediaVendaDiaria;
        this.dataUltimaVenda = Estoque.dataUltimaVenda;
        this.custoMedioContabil = Estoque.custoMedioContabil;
        this.custoMedioSemImposto = Estoque.custoMedioSemImposto;
        this.custoMedioComImposto = Estoque.custoMedioComImposto;
        this.saldoEstoqueContabil = Estoque.saldoEstoqueContabil;
        this.custoBrutoUltimaCompra = Estoque.custoBrutoUltimaCompra;
        this.custoLiquidoUltimaCompra = Estoque.custoLiquidoUltimaCompra;
        this.diasDeCoberturaOnline = Estoque.diasDeCoberturaOnline;
        this.dataAtualizacaoFichaEstoque = Estoque.dataAtualizacaoFichaEstoque;
        this.produtoUnitarioKey = Estoque.produtoUnitarioKey;
        this.fatorEstoque = Estoque.fatorEstoque;
        this.quantidadeEmTerceiros = Estoque.quantidadeEmTerceiros;
        this.quantidadeDeTerceiros = Estoque.quantidadeDeTerceiros;
        this.quantidadePendenteEmPedidos = Estoque.quantidadePendenteEmPedidos;
        this.quantidadeReservada = Estoque.quantidadeReservada;
        this.quantidadeFutura = Estoque.quantidadeFutura;
    }
}
exports.default = Estoque;
