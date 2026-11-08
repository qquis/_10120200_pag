CREATE OR REPLACE FUNCTION public.f0070_22_1012019_faturamentoorigem_processar(   
    vdata_processamento date
    
)
 RETURNS VOID 
 LANGUAGE plpgsql
AS $function$
 --- declare  
begin

		insert into tbfaturamentoorigem 
			(
					seqfaturamento
				,	sat_ecf 
				,	cupomfiscal 
				,	numeropedido 
				,	numeronfe 
				,	nfeseq 
				,	prazopgtomedio 
				,	numeronfedevolucao 				
				,	df_nf_seq_blue 
				,	faturamento_controle_seq 
			)

		select 	 	fa.seqfaturamento 
				,	ct.sat_ecf
				,	ct.cupomfiscal
				,	ct.numeropedido
				,	coalesce(nf.df_nf_numero,0)
				,	ct.df_nf_seq_blue 
				,	0
				,	0
				,	ct.df_nf_seq_blue 
				,	ct.faturamento_controle_seq
		from 		tbfaturamento_controle 	ct
		inner join 	tbfaturamento 				fa on fa.faturamento_controle_seq = ct.faturamento_controle_seq
		left  join  tbdocumentofiscal 			nf on nf.df_nf_seq_blue = ct.df_nf_seq_blue 
		where		1 = 1
		and			not exists (	select 1 
									from 	tbfaturamentoorigem aa
									where	aa.faturamento_controle_seq = ct.faturamento_controle_seq
								)
        and ct.processamento_pendente = 1
		;

		update 	tbfaturamento_controle x 
			set seqfaturamentoorigem = a.seqfaturamentoorigem 
		from 	tbfaturamentoorigem a 
		where 	a.faturamento_controle_seq = x.faturamento_controle_seq
		and     x.processamento_pendente = 1


		;

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$
