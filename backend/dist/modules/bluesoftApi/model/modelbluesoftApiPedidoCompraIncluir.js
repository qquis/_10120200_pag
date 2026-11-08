"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PedidoCompra = void 0;
class PedidoCompra {
    constructor({ compradorKey, condicaoEspecialPagamentoKey, considerarEstoqueOnline, contratoFornecimentoKey, dataLimiteDigitacao, dataPeriodoSuperiorFinal, dataPeriodoSuperiorInicial, desprezarDiasEmOferta, divisaoKey, entregas, lojaKeysDoPedido, lojas, lojakeys }) {
        this.compradorKey = compradorKey;
        this.condicaoEspecialPagamentoKey = condicaoEspecialPagamentoKey;
        this.considerarEstoqueOnline = considerarEstoqueOnline;
        this.contratoFornecimentoKey = contratoFornecimentoKey;
        this.dataLimiteDigitacao = dataLimiteDigitacao;
        this.dataPeriodoSuperiorFinal = dataPeriodoSuperiorFinal;
        this.dataPeriodoSuperiorInicial = dataPeriodoSuperiorInicial;
        this.desprezarDiasEmOferta = desprezarDiasEmOferta;
        this.divisaoKey = divisaoKey;
        this.entregas = entregas;
        this.lojaKeysDoPedido = lojaKeysDoPedido;
        this.lojas = lojas;
        this.lojakeys = lojakeys;
    }
}
exports.PedidoCompra = PedidoCompra;
exports.default = PedidoCompra;
/*
{
"compradorKey": 2046,
"condicaoEspecialPagamentoKey": 1,
"considerarEstoqueOnline": true,
"contratoFornecimentoKey": 0,
"dataLimiteDigitacao": "30/04/2022",
"dataPeriodoSuperiorFinal": "01/04/2022",
"dataPeriodoSuperiorInicial": "30/05/2022",
"desprezarDiasEmOferta": true,
"divisaoKey": 1,
"entregas": [
            {
            "dataEntregaAgendada": "03/05/2022",
            "dataEntregaPrevista": "03/05/2022",
            "numeroEntrega": 1,
            "vigenciaFinal": "03/05/2022",
            "vigenciaInicial": "03/05/2022"
            }
],
"estatisticaVendaFinal": "01/05/2022",
"estatisticaVendaInicial": "01/04/2022",
"fechado": false,
"fornecedorKey": 13752,
"limitarSugestaoAoPedidoMaximoDoProduto": true,
"lojaDeReferenciaDeCustoKey": 1,
"lojaKeys": [
1
],
"lojaKeysDoPedido": [
1
],
"lojas": [
{
"condicaoEspecialPagamentoKey": 0,
"lojaKey": 0
}
],
"negociacaoKey": 323913,
"numeroContratoExterno": 1,
"numeroEntregas": 1,
"numeroPedidoExterno": 1,
"produtos": [
{
"codigoReferenciaFornecedor": "325160",
"custoBruto": 14.07,
"entregas": [
{
"numeroEntrega": 1,
"quantidade": 10
}
],
"lojaKey": 1,
"maiorEntrega": 10,
"numeroItemExterno": 1,
"percentualIpi": 0,
"produtoKey": 196727,
"tipoFrete": "CIF",
"valorFreteUnitario": 0
}
],
"referenciaDeCusto": "ULTIMA_NEGOCIACAO",
"sugerirParaXDias": 0,
"tipoDistribuicao": "DIRETO_NAS_LOJAS",
"tipoEstatisticaVenda": "ESTATISTICA_VENDA_90_DIAS_PERIODO_ABERTO",
"tipoFinalidadePedidoKey": 1,
"tipoPedido": "PEDIDO_COMPRA",
"usaPeriodoVendaSuperior": true,
"usarSugestaoDeCompra": true,
"usuario": "elias",
"usuarioKey": 2046
}*/ 
