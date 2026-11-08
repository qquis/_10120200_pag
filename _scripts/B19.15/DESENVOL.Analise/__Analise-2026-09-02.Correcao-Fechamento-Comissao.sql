select df_nf_seq_blue, * from TBDOCUMENTOFISCAL where df_nf_numero = 47828

SELECT df_nf_numero, df_entrada_saida, df_data_recebimento FROM TBDOCUMENTOFISCAL WHERE DF_NF_TIPO = 105 AND df_data_recebimento >= '2026-04-01'
order by df_data_recebimento asc

select 
			current_timestamp 
	,		current_timestamp 	
		,	202608
		,	0 
		,	nf.df_data_recebimento 
		,	100
		,	ve.cdparticipante
		,	pt.cdparticipante
		,	0
		,	nf.df_nf_seq_blue
		,	-1 * nf.df_valor_total
		,	case when coalesce(ge.johnson_cliente_top,0) = 1 then 2 else 3 end
		,	cast(-1 * nf.df_valor_total * case when coalesce(ge.johnson_cliente_top,0) = 1 then 0.02 else 0.03 end  as numeric(13,2)) 
		,	0
		,	0
		,	0
		,	0
from 		tbdocumentofiscal 		nf
inner join  tbpessoabluesoft  		ps on ps.cdpessoabluesoft = nf.cdpessoabluesoft 
inner join  tbparticipante    		pt on pt.cdpessoabluesoft = ps.cdpessoabluesoft
inner join  tbparticipante_bluesoft cb on cb.cdparticipante = pt.cdparticipante
INNER JOIN  tbgrupoeconomico 		ge on ge.cdgrupoeconomico = cb.cdgrupoeconomico
inner join  tbparticipante			vx on vx.cdpessoabluesoft = cb.cdpessoabluesoft_vendedor
inner join  tbparticipante_vendedor ve on ve.cdparticipante = vx.cdparticipante
inner join  ( 
				select  df_nf_numero
					,	DF_NF_TIPO
					,	cdpessoabluesoft
					,	max(df_nf_seq_blue) as df_nf_seq_blue
				from 	tbdocumentofiscal
				where   1 = 1
				  and   df_nf_tipo = 105
				group by df_nf_numero
					,	DF_NF_TIPO
					,	cdpessoabluesoft

			) mx on mx.df_nf_numero = nf.df_nf_numero 
				and mx.cdpessoabluesoft = nf.cdpessoabluesoft 
				and mx.df_nf_tipo = nf.df_nf_tipo 
				and nf.df_nf_seq_blue = mx.df_nf_seq_blue
			
where 		1 = 1
and			nf.df_nf_tipo = 105
and			nf.df_entrada_saida = 'E'
and			nf.df_data_recebimento >= '2026-08-01'
and			nf.df_data_recebimento <= '2026-08-31'
AND         nf.DF_NF_NUMERO = 47828
order by 	ve.cdparticipante 
		,	pt.cdparticipante 
		,	nf.df_data_emissao 