type reportFilter = { 
    em_cdempresa?: number
    op_cdoperacao?: number
    dataPedidoEmissao_filter?: boolean
    dataPedidoEmissao_ini?: Date
    dataPedidoEmissao_fim?: Date

    dataFaturamento_filter?: boolean 
    dataFaturamento_ini?: Date
    dataFaturamento_fim?: Date 
    tipoStatusFiltro?: Date

    numeropedido?: number
    cdpessoabluesoft_cliente?: number
}

export { reportFilter }