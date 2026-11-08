using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.scripts
{
    public static class redShift
    {
        public static string AutorizacaoPagamentoSelect(DateTime data_inicial, DateTime data_final)
        {
            try
            {
                string SQL = string.Format(
                    " select  p.favorecido                              as autpgto_cdpessoabluesoft  " +
                    "       , p.ap_key                                  as autpgto_seq_pk  " +
                    "       , left(p.pagar_receber,1)                   as autpgto_tipo  " +
                    "       , left(p.descritivo,100)                    as descritivo  " +
                    "       , isnull(p.data_emissao,'1900-01-01')       as autpgto_dataemissao  " +
                    "       , isnull(p.data_vencimento,'1900-01-01')    as autpgto_datavencimento  " +
                    "       , isnull(p.data_quitacao,'1900-01-01')      as autpgto_dataquitacao  " +
                    "       , isnull(p.valor_fatura,0)                  as autpgto_valorfatura  " +
                    "       , isnull(p.valor_total,0)                   as autpgto_valortotal  " +
                    "       , isnull(p.valor_pago,0)                    as autpgto_valorpago  " +
                    "       , isnull(p.numero_documento,0)              as autpgto_nf_numero  " +
                    "       , isnull(p.desconto_financeiro,0)           as autpgto_valorDescontoFinanceiro  " +
                    "       , isnull(p.parcela,0)                       as autpgto_numeroparcela  " +
                    "       , isnull(p.data_pagamento,'1900-01-01')     as autpgto_datapagamento  " +
                    "       , isnull(p.data_emissao_nf,'1900-01-01')    as autpgto_nf_dataemissao  " +
                    "       , isnull(p.valor_liquido,0)                 as autpgto_valorliquido  " +
                    "       , isnull(p.data_criacao,'1900-01-01')       as autpgto_datacriacao  " +
                    "       , isnull(p.data_cancelamento,'1900-01-01')  as autpgto_datacancelamento  " +
                    "       , isnull(p.updated_at,'1900-01-01')         as autpgto_DtLog_update_redshift  " +
                    "       , isnull(p.status_duplicata_key,0)          as autpgto_status_bluesoft_cd  " +
                    "       , isnull(p.cancelada,0)                     as autpgto_cancelada " +
                    "       , isnull(p.codigo_barra,'')                 as autpgto_codigobarra " +
                    "       , cast(right(competencia_key,4) + left(competencia_key, 2) as int) as competencia_cd " +
                    "       , isnull(p.conta_contabil_key,0)            as plc_conta_cd " +
                    "       , isnull(p.conta_contabil_destino_key,0)    as plc_conta_cd_destino " +
                    "       , coalesce(p.juro_diario,0)                 as autpgto_juro_diario  " +
                    "       , coalesce(p.multa,0)                       as autpgto_valor_multa " +
                    "       , coalesce(p.abatimento,0)                  as autpgto_valor_abatimento " +
                    "       , coalesce(p.valor_juros,0)                 as autpgto_valor_juros " +
                    "       , coalesce(p.juros_fixo,0)                  as autpgto_valor_juros_fixo " +
                    "       , coalesce(p.bordero_key,0)                 as bordero_seq " +
                    "       , coalesce(p.loja_key)                      as em_cdpessoabluesoft " +
                    "       , 0                                         as em_cdempresa " +
                    "       , coalesce(contrato_servico_key,0)          as contrato_bluesoft_seq " + 
                    " from          autorizacao_pagamento p  " +
                    " left  join    status_duplicata      st on st.status_duplicata_key = p.status_duplicata_key   " +
                    " where         1 = 1 " +
                    "   and  (     isnull(p.updated_at,'1900-01-01') >= '{0}'  " +
                    "           or isnull(p.data_emissao,'1900-01-01') >= '{0}'  " +
                    "   ) order by p.data_emissao desc ", data_inicial.ToString("yyyy-MM-dd"));


                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}



/* -------------------- Query Select Test ------------------------------------------
 * 07/06/2024
 
                    select  p.favorecido                              as autpgto_cdpessoabluesoft  
                          , p.ap_key                                  as autpgto_seq_pk  
                          , left(p.pagar_receber,1)                   as autpgto_tipo  
                          , left(p.descritivo,100)                    as autpgto_descritivo  
                          , isnull(p.data_emissao,'1900-01-01')       as autpgto_dataemissao  
                          , isnull(p.data_vencimento,'1900-01-01')    as autpgto_datavencimento  
                          , isnull(p.data_quitacao,'1900-01-01')      as autpgto_dataquitacao  
                          , isnull(p.valor_fatura,0)                  as autpgto_valorfatura  
                          , isnull(p.valor_total,0)                   as autpgto_valortotal  
                          , isnull(p.valor_pago,0)                    as autpgto_valorpago  
                          , isnull(p.numero_documento,0)              as autpgto_nf_numero  
                          , isnull(p.desconto_financeiro,0)           as autpgto_valorDescontoFinanceiro  
                          , isnull(p.parcela,0)                       as autpgto_numeroparcela  
                          , isnull(p.data_pagamento,'1900-01-01')     as autpgto_datapagamento  
                          , isnull(p.data_emissao_nf,'1900-01-01')    as autpgto_nf_dataemissao  
                          , isnull(p.valor_liquido,0)                 as autpgto_valorliquido  
                          , isnull(p.data_criacao,'1900-01-01')       as autpgto_datacriacao  
                          , isnull(p.data_cancelamento,'1900-01-01')  as autpgto_datacancelamento  
                          , isnull(p.updated_at,'1900-01-01')         as autpgto_DtLog_update_redshift  
                          , isnull(p.status_duplicata_key,0)          as autpgto_status_cd  
                          , isnull(p.cancelada,0)                     as autpgto_cancelada 
                          , isnull(p.codigo_barra,'')                 as autpgto_codigobarra 
                          , cast(right(competencia_key,4) + left(competencia_key, 2) as int) as competencia_cd 
                          , isnull(p.conta_contabil_key,0)            as plc_conta_cd 
                          , isnull(p.conta_contabil_destino_key,0)    as plc_conta_cd_destino 
                          , coalesce(p.juro_diario,0)                 as autpgto_juro_diario  
                          , coalesce(p.multa,0)                       as autpgto_valor_multa 
                          , coalesce(p.abatimento,0)                  as autpgto_valor_abatimento 
                          , coalesce(p.valor_juros,0)                 as autpgto_valor_juros 
                          , coalesce(p.juros_fixo,0)                  as autpgto_valor_juros_fixo 
                          , coalesce(p.bordero_key,0)                 as bordero_seq 
                          , coalesce(p.loja_key)                      as em_cdempresa 
                          , coalesce(contrato_servico_key,0)          as contrato_bluesoft_seq
                    from          autorizacao_pagamento p 
                    left  join    status_duplicata      st on st.status_duplicata_key = p.status_duplicata_key  
                    where         1 = 1
                      and  coalesce(p.updated_at,'1900-01-01') >= '2024-05-01'

SELECT * FROM AUTORIZACAO_PAGAMENTO WHERE updated_at >= '2024-05-01' LIMIT 10 
 




*/