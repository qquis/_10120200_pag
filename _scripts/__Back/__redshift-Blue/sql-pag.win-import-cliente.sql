SELECT 
    PS.PESSOA_KEY                                                                           AS cdpessoabluesoft,
    PS.CPF_CNPJ                                                                            AS cpf_cnpj,
    PS.NOME_RAZAO                                                                          AS nome_razao,
    PS.NOME_ABREVIADO                                                                      AS nome_abreviado,
    CASE WHEN COALESCE(PS.FISICA,'0') = 0 THEN 1 ELSE 0 END                              AS pessoajuridica,
    LEFT(ISNULL(email_comercial, ''),60)                                                  AS email_main,
    COALESCE(PS.DATA_CADASTRO, '1900-01-01')                                             AS bluesoftpessoa_data_cadastro,
    CASE WHEN TRIM(COALESCE(sexo,'M')) = '' THEN 'M' ELSE COALESCE(sexo,'M') END         AS sexo,
    COALESCE(data_nascimento, '1900-01-01')                                              AS data_nascimento,
    COALESCE(PS.CEP, 0)                                                                   AS endereco_cep,
    COALESCE(PS.ENDERECO_RUA, '')                                                         AS endereco_logradouro,
    COALESCE(PS.ENDERECO_NUMERO, '0')                                                     AS endereco_numero,
    COALESCE(PS.ENDERECO_COMPLEMENTO, '')                                                 AS endereco_complemento,
    COALESCE(PS.BAIRRO, '')                                                               AS endereco_bairro,
    COALESCE(PS.MUNICIPIO, '')                                                            AS endereco_municipio,
    COALESCE(PS.ESTADO_SIGLA, '')                                                         AS endereco_uf,
    ISNULL(latitude,0)                                                                    AS endereco_latitude,
    ISNULL(longitude,0)                                                                   AS endereco_longitude,
    CASE WHEN COALESCE(CL.CLIENTE_KEY,0) <> 0 THEN 1 ELSE 0 END                         AS bluesoftcliente,
    CASE WHEN COALESCE(VE.VENDEDOR_EXTERNO_KEY,0) <> 0 THEN 1 ELSE 0 END                AS bluesoftvendedor,
    CASE WHEN COALESCE(FO.FORNECEDOR_KEY,0) <> 0 THEN 1 ELSE 0 END                      AS bluesoftfornecedor,
    CASE WHEN COALESCE(FA.FABRICANTE_KEY,0) <> 0 THEN 1 ELSE 0 END                      AS bluesoftfabricante,
    COALESCE(GRUPO_ECONOMICO.GRUPO_ECONOMICO_KEY,0)                                      AS cdgrupoeconomico,
    COALESCE(CLIENTE.VENDEDOR_EXTERNO_KEY,0)                                             AS cdpessoabluesoft_vendedor,
    COALESCE(CL.bluesoftclientestatus,0)                                                 AS bluesoftclientestatus,
    COALESCE(PS.STATUS,0)                                                                AS bluesoftpessoastatus,
    COALESCE(CL.bluesoftcliente_creditolimite_valor,0)                                   AS bluesoftcliente_creditolimite_valor,
    COALESCE(CL.bluesoftcliente_creditolimite_valor_reservado,0)                         AS bluesoftcliente_creditolimite_valor_reservado,
    COALESCE(CL.bluesoftcliente_creditostatus_cd,0)                                      AS bluesoftcliente_creditostatus_cd,
    COALESCE(CL.bluesoftcliente_ramoatividade_cd,0)                                      AS bluesoftcliente_ramoatividade_cd
FROM 
    PESSOA PS
    
    LEFT JOIN (
        SELECT 
            FORNECEDOR_KEY AS FORNECEDOR_KEY
        FROM 
            FORNECEDOR_PRODUTO
        GROUP BY 
            FORNECEDOR_KEY
    ) FO ON FO.FORNECEDOR_KEY = PS.PESSOA_KEY
    
    LEFT JOIN (
        SELECT 
            FABRICANTE_KEY AS FABRICANTE_KEY
        FROM 
            PRODUTO_D
        GROUP BY 
            FABRICANTE_KEY
    ) FA ON FA.FABRICANTE_KEY = PS.PESSOA_KEY
    
    LEFT JOIN (
        SELECT 
            PESSOA_KEY                                                                  AS CLIENTE_KEY,
            CAST(CASE WHEN COALESCE(STATUS,'INATIVO') = 'INATIVO' THEN 0 ELSE 1 END AS INT) AS bluesoftclientestatus,
            COALESCE(credito_limite,0)                                                 AS bluesoftcliente_creditolimite_valor,
            COALESCE(credito_usado,0)                                                  AS bluesoftcliente_creditolimite_valor_reservado,
            COALESCE(status_credito,0)                                                 AS bluesoftcliente_creditostatus_cd,
            COALESCE(ramo_atividade_key,0)                                             AS bluesoftcliente_ramoatividade_cd
        FROM 
            CLIENTE
    ) CL ON CL.CLIENTE_KEY = PS.PESSOA_KEY
    
    LEFT JOIN (
        SELECT 
            VENDEDOR_EXTERNO_KEY AS VENDEDOR_EXTERNO_KEY 
        FROM 
            GRUPO_ECONOMICO_COMISSAO 
        GROUP BY 
            VENDEDOR_EXTERNO_KEY
    ) VE ON VE.VENDEDOR_EXTERNO_KEY = PS.PESSOA_KEY
    
    LEFT JOIN (
        SELECT 
            PS.PESSOA_KEY                   AS CLIENTE_KEY,
            CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY,
            MIN(GM.VENDEDOR_EXTERNO_KEY)    AS VENDEDOR_EXTERNO_KEY
        FROM 
            PESSOA PS
            INNER JOIN CLIENTE_GRUPO_ECONOMICO CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY
            INNER JOIN GRUPO_ECONOMICO_COMISSAO GM ON GM.CLIENTE_GRUPO_ECONOMICO_KEY = CG.CLIENTE_GRUPO_ECONOMICO_KEY
        GROUP BY 
            PS.PESSOA_KEY,
            CG.GRUPO_ECONOMICO_KEY
    ) CLIENTE ON CLIENTE.CLIENTE_KEY = PS.PESSOA_KEY
    
    LEFT JOIN (
        SELECT 
            PS.PESSOA_KEY          AS CLIENTE_KEY,
            CG.GRUPO_ECONOMICO_KEY AS GRUPO_ECONOMICO_KEY
        FROM 
            PESSOA PS
            INNER JOIN CLIENTE_GRUPO_ECONOMICO CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY
        GROUP BY 
            PS.PESSOA_KEY,
            CG.GRUPO_ECONOMICO_KEY
    ) GRUPO_ECONOMICO ON GRUPO_ECONOMICO.CLIENTE_KEY = PS.PESSOA_KEY

WHERE 
    CAST(PS.CPF_CNPJ AS NUMERIC(14,0)) > 0
    AND PS.pessoa_key <> 0
    AND PS.cpf_cnpj != 0

ORDER BY 
    PS.PESSOA_KEY ASC;