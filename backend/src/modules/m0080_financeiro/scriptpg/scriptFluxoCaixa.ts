import { clsTools, clsBase} from '../../../model/modelbase';
export default class scriptSQLSelectFluxoCaixa {
    static sql (parametros: any = {}, list : boolean = true) : string { 
        try { 


            let tipovisualizacao = parametros.tipovisualizacao || 'FLUXO';

            let sql = `` 

            if (tipovisualizacao == 'FLUXO') {
            
                sql = ` select     data_previsao
                                ,  count(distinct(autpgto_seq_pk))                  as qtde
                                ,  sum(valor_cartao)                                as valor_cartao
                                ,  sum(valor_receber)                               as valor_receber
                                ,  sum(valor_pagar)                                 as valor_pagar
                                ,  sum(valor_adm_previsao)                          as valor_adm_previsao
                                ,  sum(valor_receber + valor_cartao - valor_pagar + valor_adm_previsao)  as saldo 


                `
            }

            if (tipovisualizacao == 'LIST') {
            
                sql = ` select     data_previsao
                                ,  autpgto_datavencimento
                                ,  autpgto_datapagamento
                                ,  autpgto_dataquitacao
                                ,  descricao
                                ,  autpgto_seq_pk
                                ,  autpgto_valorfatura
                                ,  autpgto_valordescontofinanceiro
                                ,  valor_cartao
                                ,  valor_receber
                                ,  valor_pagar
                                ,  (valor_receber + valor_cartao - valor_pagar + valor_adm_previsao) as saldo
                                ,  registro_adm 

                `
            }
            




            sql  += ` 
            
                FROM (
            
                        select      mv_caixa_seq                                        as autpgto_seq_pk
                                ,   mv_caixa_descricao                                  as descricao 
                                ,   mv_caixa_data_deposito                              as autpgto_datavencimento
                                ,   mv_caixa_data_deposito                              as autpgto_datapagamento
                                ,   mv_caixa_data_deposito                              as autpgto_dataquitacao
                                ,   CASE DATE_PART('dow', mv_caixa_data_deposito) 
                                        WHEN 0 THEN mv_caixa_data_deposito + 1 
                                        WHEN 6 THEN mv_caixa_data_deposito + 2
                                        ELSE mv_caixa_data_deposito
                                    END                                                 AS data_previsao 
                                ,   coalesce(mv_caixa_valor,0)                          as autpgto_valorfatura
                                ,   coalesce(mv_caixa_vl_taxa,0)                        as autpgto_valordescontofinanceiro
                                ,   cast(0 as numeric(13,2))                             as autpgto_valorpago
                                ,   coalesce(mv_caixa_valor,0) - coalesce(mv_caixa_vl_taxa,0) as valor_cartao
                                ,   cast(0 as numeric(13,2)) as valor_receber
                                ,   cast(0 as numeric(13,2)) as valor_pagar
                                ,   cast(0 as numeric(13,2)) as valor_adm_previsao 
                                ,   cast(0 as numeric(13,2)) as valor_executivo_previsao 
                                ,   cast(0 as int) as registro_adm 

                        from        tbmovimento_caixa_bluesoft
                        where    1 = 1
                        and       em_cdempresa = 1
                        and       debitocredito = 1
                        and       CASE DATE_PART('dow', mv_caixa_data_deposito) 
                                        WHEN 0 THEN mv_caixa_data_deposito + 1 
                                        WHEN 6 THEN mv_caixa_data_deposito + 2
                                        ELSE mv_caixa_data_deposito
                                    END >= CURRENT_DATE 
                        union
                        
                        select 		autpgto_seq_pk 
                                ,   d.descritivo as descricao
                                ,	autpgto_datavencimento
                                ,   autpgto_datapagamento
                                ,   autpgto_dataquitacao
                                ,	CASE DATE_PART('dow', X.autpgto_datavencimento) 
                                WHEN 0 THEN X.autpgto_datavencimento + 2 -- domingo recebe na terca
                                WHEN 5 THEN X.autpgto_datavencimento + 3 -- sexta -> recebe na segunda                  
                                WHEN 6 THEN X.autpgto_datavencimento + 3 -- sabado -> recebe na terça
                                ELSE X.autpgto_datavencimento + 1 end as data_previsao
                                ,	autpgto_valorfatura
                                , 	autpgto_valordescontofinanceiro
                                , 	autpgto_valorpago 		
                                ,   cast(0 as numeric(13,2)) as valor_cartao  
                                ,	cast(autpgto_valorfatura - autpgto_valordescontofinanceiro - autpgto_valorpago as numeric(13,2)) as valor_receber 		 
                                ,   cast(0 as numeric(13,2)) as valor_pagar
                                ,   cast(0 as numeric(13,2)) as valor_adm_previsao 
                                ,   cast(0 as numeric(13,2)) as valor_executivo_previsao                                 
                                ,   cast(0 as int) as registro_adm 
                        from 		tbautorizacaopagamento x
                        left join   tbautorizacaopagamento_descritivo d on d.autpgto_seq_fk = x.autpgto_seq_pk
                        where		1 = 1
                        and			em_cdempresa = 1
                        and 		autpgto_cancelada = 0  
                        and			autpgto_tipo = 'R'
                        and			autpgto_valorpago = 0
                        and 		coalesce(autpgto_datapagamento, '1900-01-01') = '1900-01-01'
                        AND CASE DATE_PART('dow', X.autpgto_datavencimento) 
                                WHEN 0 THEN X.autpgto_datavencimento + 2 -- domingo recebe na terca
                                WHEN 5 THEN X.autpgto_datavencimento + 3 -- sexta -> recebe na segunda                  
                                WHEN 6 THEN X.autpgto_datavencimento + 3 -- sabado -> recebe na terça
                                ELSE X.autpgto_datavencimento + 1 
                            END >= CURRENT_DATE 
                        union
                        select 		autpgto_seq_pk 
                                ,   d.descritivo as descricao
                                ,	autpgto_datavencimento
                                ,   autpgto_datapagamento
                                ,   autpgto_dataquitacao                                
                                ,	CASE DATE_PART('dow',  X.autpgto_datavencimento) 
                                        WHEN 0 THEN X.autpgto_datavencimento + 1 
                                        WHEN 6 THEN X.autpgto_datavencimento + 2
                                        ELSE X.autpgto_datavencimento
                                    END AS DATA_PREVISAO
                                ,	autpgto_valorfatura
                                , 	autpgto_valordescontofinanceiro
                                , 	autpgto_valorpago 
                                ,   cast(0 as numeric(13,2)) as valor_cartao 		 
                                ,	cast(0 as numeric(13,2)) as valor_receber		
                                ,	cast(autpgto_valorfatura - autpgto_valordescontofinanceiro as numeric(13,2)) as valor_pagar 
                                ,   cast(0 as numeric(13,2)) as valor_adm_previsao 
                                ,   cast(0 as numeric(13,2)) as valor_executivo_previsao 
                                ,   cast(0 as int) as registro_adm                                                                 		 		 
                        from 		tbautorizacaopagamento x
                        left join   tbautorizacaopagamento_descritivo d on d.autpgto_seq_fk = x.autpgto_seq_pk
                        where		1 = 1
                        and			em_cdempresa = 1
                        and 		autpgto_cancelada = 0  
                        and			autpgto_tipo = 'P'
                        --and			autpgto_valorpago = 0
                        and 		coalesce(autpgto_dataquitacao, '1900-01-01') = '1900-01-01'
                        AND CASE DATE_PART('dow', X.autpgto_datavencimento) 
                                        WHEN 0 THEN X.autpgto_datavencimento + 1 
                                        WHEN 6 THEN X.autpgto_datavencimento + 2
                                        ELSE X.autpgto_datavencimento
                                    END >= CURRENT_DATE 
                        union 
                        select 	x.aut_pgto_pag_seq 				as autpgto_seq_pk
                            ,	x.aut_pgto_pag_obs 			    as descricao
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_datavencimento
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_datapagamento
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_dataquitacao
                            ,   x.aut_pgto_pag_data_pgto		as data_previsao 
                            ,   x.aut_pgto_pag_valor			as autpgto_valorfatura
                            ,	cast(0 as numeric(13,2))								as autpgto_valordescontofinanceiro
                            ,   cast(0 as numeric(13,2))                             as autpgto_valorpago                            
                            ,   cast(0 as numeric(13,2))								as valor_cartao
                            ,   cast(0 as numeric(13,2))								as valor_receber
                            ,   cast(0 as numeric(13,2))								as valor_pagar
                            ,	cast(aut_pgto_pag_valor * x.debitocredito as numeric(13,2))				
                                                                as valor_adm_previsao	
                            ,	cast(0 as numeric(13,2))								as valor_executivo_previsao
                            ,   cast(1 as int) as registro_adm 
                        from 	tbautorizacaopagamentopag x
                        where   1 = 1 
                        and		x.aut_pgto_pag_tipo_cd = 2
                        and		aut_pgto_pag_cancelado = 0
                        and     aut_pgto_pag_data_pgto >= CURRENT_DATE
                        union
                        select 	x.aut_pgto_pag_seq 				as autpgto_seq_pk
                            ,	x.aut_pgto_pag_obs 			    as descricao
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_datavencimento
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_datapagamento
                            ,   x.aut_pgto_pag_data_pgto		as autpgto_dataquitacao
                            ,   x.aut_pgto_pag_data_pgto		as data_previsao 
                            ,   x.aut_pgto_pag_valor			as autpgto_valorfatura
                            ,	cast(0 as numeric(13,2))								as autpgto_valordescontofinanceiro
                            ,   cast(0 as numeric(13,2))                                as autpgto_valorpago                          
                            ,   cast(0 as numeric(13,2))								as valor_cartao
                            ,   cast(0 as numeric(13,2))								as valor_receber
                            ,   cast(0 as numeric(13,2))								as valor_pagar
                            ,	cast(0 as numeric(13,2))               				    as valor_adm_previsao	
                            ,	cast(aut_pgto_pag_valor * x.debitocredito as numeric(13,2))
                                            		as valor_executivo_previsao
                            ,   cast(0 as int) as registro_adm 
                        from 	tbautorizacaopagamentopag x
                        where   1 = 1 
                        and		x.aut_pgto_pag_tipo_cd = 999
                        and		aut_pgto_pag_cancelado = 0
                        and     aut_pgto_pag_data_pgto >= CURRENT_DATE                        


                         ) a
                where 1 = 1
                        `
            if (parametros.filterdata && parametros.filterdata == 1) { 
                sql += ` and data_previsao between '${clsTools._datemomentDateToStr(parametros.data_ini, "YYYY-MM-DD")}' and '${clsTools._datemomentDateToStr(parametros.data_fim, "YYYY-MM-DD")}' `
            }
            
            
            
            if (tipovisualizacao == 'FLUXO') {
                sql += ` group by data_previsao `
            }

            return sql 
        } catch (e) { 
            clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);   
            return ''       
        }
    }
 
        }