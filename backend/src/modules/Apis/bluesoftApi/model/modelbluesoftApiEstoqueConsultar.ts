interface IEstoque{
    produtoKey: number 
    lojaKey: number 
    gtinPrincipal: string 
    saldoOnline: number 
    saldoFisico: number 
    gtinsAdicionais: [string],
    saldoDisponivel: number 
    mediaVendaDiaria: number 
    dataUltimaVenda: Date
    custoMedioContabil: number 
    custoMedioSemImposto: number 
    custoMedioComImposto: number 
    saldoEstoqueContabil: number 
    custoBrutoUltimaCompra: number 
    custoLiquidoUltimaCompra: number 
    diasDeCoberturaOnline:number 
    dataAtualizacaoFichaEstoque: Date 
    produtoUnitarioKey: number 
    fatorEstoque: number 
    quantidadeEmTerceiros: number 
    quantidadeDeTerceiros: number 
    quantidadePendenteEmPedidos: number 
    quantidadeReservada: number 
    quantidadeFutura: number 
}

export default class Estoque{
    produtoKey: number 
    lojaKey: number 
    gtinPrincipal: string 
    saldoOnline: number 
    saldoFisico: number 
    gtinsAdicionais: [string]
    saldoDisponivel: number 
    mediaVendaDiaria: number 
    dataUltimaVenda: Date
    custoMedioContabil: number 
    custoMedioSemImposto: number 
    custoMedioComImposto: number 
    saldoEstoqueContabil: number 
    custoBrutoUltimaCompra: number 
    custoLiquidoUltimaCompra: number 
    diasDeCoberturaOnline:number 
    dataAtualizacaoFichaEstoque: Date 
    produtoUnitarioKey: number 
    fatorEstoque: number 
    quantidadeEmTerceiros: number 
    quantidadeDeTerceiros: number 
    quantidadePendenteEmPedidos: number 
    quantidadeReservada: number 
    quantidadeFutura: number 
    constructor ( { ...Estoque  } : IEstoque)
    {
        this.produtoKey = Estoque.produtoKey
        this.lojaKey = Estoque.lojaKey
        this.gtinPrincipal = Estoque.gtinPrincipal
        this.saldoOnline = Estoque.saldoOnline
        this.saldoFisico = Estoque.saldoFisico
        this.gtinsAdicionais = Estoque.gtinsAdicionais
        this.saldoDisponivel = Estoque.saldoDisponivel
        this.mediaVendaDiaria = Estoque.mediaVendaDiaria
        this.dataUltimaVenda = Estoque.dataUltimaVenda
        this.custoMedioContabil = Estoque.custoMedioContabil
        this.custoMedioSemImposto = Estoque.custoMedioSemImposto
        this.custoMedioComImposto = Estoque.custoMedioComImposto
        this.saldoEstoqueContabil = Estoque.saldoEstoqueContabil
        this.custoBrutoUltimaCompra = Estoque.custoBrutoUltimaCompra
        this.custoLiquidoUltimaCompra = Estoque.custoLiquidoUltimaCompra
        this.diasDeCoberturaOnline = Estoque.diasDeCoberturaOnline
        this.dataAtualizacaoFichaEstoque = Estoque.dataAtualizacaoFichaEstoque
        this.produtoUnitarioKey = Estoque.produtoUnitarioKey
        this.fatorEstoque = Estoque.fatorEstoque
        this.quantidadeEmTerceiros = Estoque.quantidadeEmTerceiros
        this.quantidadeDeTerceiros = Estoque.quantidadeDeTerceiros
        this.quantidadePendenteEmPedidos = Estoque.quantidadePendenteEmPedidos
        this.quantidadeReservada = Estoque.quantidadeReservada
        this.quantidadeFutura = Estoque.quantidadeFutura
    }

}


