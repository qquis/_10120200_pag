export default interface filter {
    fat_controle_tipo_cd?: number 
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
    numeropedido_fv?: number
    cdpessoabluesoft_cliente?: number
    sat_ecf?: number,
    cupomfiscal?: number 
    df_nf_seq_blue?: number,
    df_nf_seq_blue_fv?: number

}