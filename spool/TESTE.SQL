SELECT 
    Convert(int,1)                                AS cdempresa,
    Convert(int,1)                                AS cdoperacao,
    pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft,
    nf.NF_NUMERO                                  AS NumeroNotaFiscal,
    ISNULL(dv.NF_NUMERO,0)                        AS NumeroNotaFiscalDevolucao,
    pd.data_emissao                               AS DataPedido,
    pd.data_faturamento                           AS DataNotaFiscal,
    pd.status_pedido                              AS PedidoStatus,
    pd.prazo_pagamento                            AS PedidoPrazoPagamento,
    pd.vendedor_key                               AS VendedorKey,
    ps.cpf_cnpj                                   AS PedidoVendedorCPFCNPJ,
    ps.nome_razao                                 AS VENDEDOR,
    cl.nome_razao                                 AS CLIENTE,
    cl.cpf_cnpj                                   AS PedidoClienteCPFCNPJ,
    CASE
        WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
    END AS TipoVenda,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END AS statusnotacancelamento,
    CONVERT(int, 1)                               AS OrigemNotaFiscalBlueSoft,
    CAST(COALESCE(nf.nf_key,0) AS bigint)         AS df_nf_seq_blue
FROM fato_pedido_forca_venda pd
    LEFT JOIN produto_d pr ON pr.produto_key = pd.produto_key
    LEFT JOIN produto_d pn ON pn.produto_key = pr.produto_unitario_key
    LEFT JOIN fornecedor_produto fp ON fp.fornecedor_produto_key = pn.fornecedor_produto_padrao_key
    LEFT JOIN produto_d cx ON cx.produto_key = fp.produto_key
    INNER JOIN pessoa ps ON ps.pessoa_key = pd.vendedor_key
    INNER JOIN nota_fiscal nf ON nf.nf_key = pd.nf_key AND nf.loja_key = pd.loja_key
    LEFT JOIN nota_fiscal dv ON dv.numero_documento_origem = nf.nf_numero AND dv.loja_key = nf.loja_key
    LEFT JOIN fato_nota_fiscal pf ON pf.nf_key = nf.nf_key 
        AND pf.loja_key = nf.loja_key 
        AND pf.produto_origem_key = pd.produto_key
    LEFT JOIN produto_d pe ON pe.produto_key = pf.produto_origem_key
    LEFT JOIN pessoa cl ON cl.pessoa_key = pd.cliente_key
    LEFT JOIN ESTOQUE_DIARIO ct ON ct.produto_key = pn.produto_key AND ct.data = pd.data_Faturamento
WHERE pd.data_faturamento >= '2025-11-04'
    AND pd.data_faturamento <= '2025-11-18'
GROUP BY 
    pd.pedido_forca_venda_cliente_key,
    nf.NF_NUMERO,
    dv.NF_NUMERO,
    pd.data_emissao,
    pd.data_faturamento,
    pd.status_pedido,
    pd.prazo_pagamento,
    pd.vendedor_key,
    ps.cpf_cnpj,
    ps.nome_razao,
    cl.nome_razao,
    cl.cpf_cnpj,
    CASE
        WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
    END,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END,
    COALESCE(nf.nf_key,0)

UNION

SELECT 
    Convert(int,3)                                AS cdempresa,
    Convert(int,6)                                AS cdoperacao,
    n.nf_numero                                   AS NumeroPedidoBlueSOft,
    n.nf_numero                                   AS NumeroNotaFiscal,
    0                                             AS NumeroNotaFiscalDevolucao,
    n.data_emissao                                AS DataPedido,
    n.data_emissao                                AS DataNotaFiscal,
    'Faturado por Nota Fiscal'                    AS PedidoStatus,
    'A VISTA'                                     AS pedidoprazopagamento,
    0                                             AS vendedorkey,
    21814585885                                   AS pedidovendedorcpfcnpj,
    'ELIAS DA SILVA'                              AS vendedor,
    cl.nome_razao                                 AS CLIENTE,
    cl.cpf_cnpj                                   AS PedidoClienteCPFCNPJ,
    CASE
        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
    END AS TipoVenda,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END AS statusnotacancelamento,
    CONVERT(int, 1)                               AS OrigemNotaFiscalBlueSoft,
    CAST(COALESCE(nf.nf_key,0) AS bigint)         AS df_nf_seq_blue
FROM fato_nota_fiscal n
    INNER JOIN nota_fiscal nf ON nf.nf_key = n.nf_key AND n.loja_key = nf.loja_key
    INNER JOIN pessoa cl ON cl.pessoa_key = nf.fornecedor_key
    INNER JOIN produto_d pr ON pr.produto_key = n.produto_key
WHERE nf.data_emissao >= '2025-11-04'
    AND nf.data_emissao <= '2025-11-18'
    AND n.loja_key = 991
    AND nf.codigo_operacao_fiscal IN ('5102','5910','5405')
    AND n.nf_tipo_descricao = 'Nota fiscal de venda a cliente por pedido'
GROUP BY 
    n.nf_key,
    n.nf_numero,
    n.data_emissao,
    cl.nome_razao,
    cl.cpf_cnpj,
    CASE
        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
    END,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END,
    COALESCE(nf.nf_key,0)

UNION

SELECT 
    Convert(int,1)                                AS cdempresa,
    Convert(int,1)                                AS cdoperacao,
    n.nf_numero                                   AS NumeroPedidoBlueSOft,
    n.nf_numero                                   AS NumeroNotaFiscal,
    0                                             AS NumeroNotaFiscalDevolucao,
    n.data_emissao                                AS DataPedido,
    n.data_emissao                                AS DataNotaFiscal,
    'Faturado por Nota Fiscal'                    AS PedidoStatus,
    '28 DIAS'                                     AS pedidoprazopagamento,
    0                                             AS vendedorkey,
    21814585885                                   AS pedidovendedorcpfcnpj,
    'ELIAS DA SILVA'                              AS vendedor,
    cl.nome_razao                                 AS CLIENTE,
    cl.cpf_cnpj                                   AS PedidoClienteCPFCNPJ,
    CASE
        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6108' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '6910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6405' THEN 'VENDA'
    END AS TipoVenda,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END AS statusnotacancelamento,
    CONVERT(int, 1)                               AS OrigemNotaFiscalBlueSoft,
    CAST(COALESCE(nf.nf_key,0) AS bigint)         AS df_nf_seq_blue
FROM fato_nota_fiscal n
    INNER JOIN nota_fiscal nf ON nf.nf_key = n.nf_key AND n.loja_key = nf.loja_key
    INNER JOIN pessoa cl ON cl.pessoa_key = nf.fornecedor_key
    INNER JOIN cliente_grupo_economico GP ON gp.cliente_key = cl.pessoa_key
    INNER JOIN GRUPO_ECONOMICO GE ON GE.GRUPO_ECONOMICO_KEY = GP.GRUPO_ECONOMICO_KEY
    INNER JOIN produto_d pr ON pr.produto_key = n.produto_key
WHERE 1 = 1
    AND nf.data_emissao >= '2025-11-04'
    AND nf.data_emissao <= '2025-11-18'
    AND n.loja_key = 1
    AND nf.codigo_operacao_fiscal IN ('5102','5910','5405', '6102','6910','6405', '6108')
    AND n.nf_tipo_descricao IN ('Nota fiscal de venda a cliente por pedido', 'Nota fiscal de venda a cliente')
    AND n.nf_key NOT IN (
        SELECT nf_key 
        FROM fato_pedido_forca_venda 
        WHERE data_faturamento >= '20200301' 
        GROUP BY nf_key
    )
    AND ge.descricao LIKE '%5ASEC%'
GROUP BY 
    n.nf_key,
    n.nf_numero,
    n.data_emissao,
    cl.nome_razao,
    cl.cpf_cnpj,
    CASE
        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6102' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6108' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '6910' THEN 'BONIFICACAO'
        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'
        WHEN nf.codigo_operacao_fiscal = '6405' THEN 'VENDA'
    END,
    CASE WHEN nf.data_cancelamento IS NULL THEN 0 ELSE 1 END,
    COALESCE(nf.nf_key,0)