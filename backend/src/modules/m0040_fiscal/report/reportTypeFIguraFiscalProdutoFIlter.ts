


type reportFiguraFiscalProdutoFilter = { 
    pr_cdproduto?: number
    prb_cdprodutobluesoft?: number
    pr_descricao?: string
    prb_descricao?: string
    prb_descricao_fiscal?: string
    prd_cddepartamento?: number
    prs_cdsecao?: number
    prg_cdgrupo?: number
    prsg_cdsubgrupo?: number
    filter_prb_dt_cadastro?: number
    filtra_prb_dt_cadastro_ini ?: string 
    filtra_prb_dt_cadastro_fim ?: string
    fornecedor_razao_social?: string
    filtrarcomestoque?: number



    filtrar_entrada_saida?: number
    filtrar_entrada_saida_tipo?: 'ENTRADA' | 'SAIDA' | 'TODOS'
    filtrar_entrada_saida_numero_mes?: number
    filtrar_entrada_saida_data_inicial?: Date
    filtrar_entrada_saida_data_final?: Date    
    filtrar_entrada_saida_negativo?: number
    
    filtrar_status_bluesoft?: 'ATIVO' | 'INATIVO' | 'TODOS'
    filtrar_vendaexterna?: "SIM" | "NAO" | "TODOS"

    distribuica_regime_tributacao?: 'C' | 'S' | 'N'
    figurafiscalassociada?: 'S' | 'N' | 'T'
    figurafiscal?: string
    ncm ?: string
    cest ?: string
    operacaoVisualizar?: string

    filtrarprodutounitario?: number

    filtrarComRegraNfce?: string 
    nfce_produto_tipo_cd?: number
    apenasunitario?: number
}

export default reportFiguraFiscalProdutoFilter 