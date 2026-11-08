-- Active: 1755690272902@@oxan.dw.bluesoft.com.br@5432@oxan
select * from autorizacao_pagamento limit 10

select      cadastro_caixa_key              as mv_caixa_seq
        ,   loja_key                        as em_cdempresa
        ,   tipo_mov_caixa_key              as mv_caixa_bluesoft_tipo_cd
        ,   tipo_caixa_key                  as caixa_bluesoft_cd 
        ,   administradora_key              as administradora_cdpessoabluesoft
        ,   data                            as mv_caixa_data
        ,   valor                           as mv_caixa_valor
        ,   descricao                       as mv_caixa_descricao
        ,   numero_pdv                      as sat_ecf
        ,   valor_parcela                   as mv_caixa_vl_parcela
        ,   valor_taxa                      as mv_caixa_vl_taxa
        ,   valor_taxa_operacao             as mv_caixa_vl_taxa_operacao
        ,   valor_juros                     as mv_caixa_vl_juros
        ,   data_para_deposito              as mv_caixa_data_deposito
        ,   data_entrega                    as mv_caixa_data_entrega
        ,   data_previsao_credito           as mv_caixa_data_previsao_credito
        ,   codigo_autorizacao              as mv_caixa_autorizacao_cd
        ,   nsu                             as mv_caixa_nsu
        --,   status_transacao    
        ,   updated_at                      as mv_caixa_updated_at
        ,   cpf                             as mv_caixa_cpf
from        CADASTRO_CAIXA 
where 1 = 1
limit 10