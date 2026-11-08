-- FUNCTION: public.f0070_22_1012010_faturamento_origem_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_22_1012010_faturamento_origem_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_22_1012017_faturamento_origem_processar(
	vfaturamento_controle_seq integer,
	vop_cdoperacao integer,
	vnumeropedido integer,
	vdf_nf_seq_blue integer,
	vsat_ecf integer,
	vcupomfiscal integer,
	vcdpessoabluesoft_cliente integer)
    RETURNS TABLE(seqfaturamento integer, seqfaturamentoorigem integer, sat_ecf integer, cupomfiscal integer, numeropedido integer, numeronfe integer, nfeseq integer, prazomedio integer, numeronfedevolucao integer, cupomfiscalcancelador integer, hora_fim time without time zone, hora_ini time without time zone, df_nf_seq_blue integer, faturamento_controle_seq integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
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
		and			ct.op_cdoperacao = vop_cdoperacao
		and			not exists (	select 1 
									from 	tbfaturamentoorigem aa
									where	aa.faturamento_controle_seq = ct.faturamento_controle_seq
								)
		;
		update 	tbfaturamento_controle x 
			set seqfaturamentoorigem = a.seqfaturamentoorigem 
		from 	tbfaturamentoorigem a 
		where 	a.faturamento_controle_seq = vfaturamento_controle_seq
		and 	x.op_cdoperacao = vop_cdoperacao 
		and 	x.seqfaturamentoorigem = 0

		;
		RETURN QUERY 
		SELECT 		cast(o.seqfaturamento as int)
				,	cast(o.seqfaturamentoorigem as int)
				,	cast(o.sat_ecf as int)
				,	cast(o.cupomfiscal as int)
				,	cast(o.numeropedido as int)
				,	cast(o.numeronfe as int)
				,	cast(o.nfeseq as int)
				,	cast(o.prazopgtomedio as int)
				,	cast(o.numeronfedevolucao as int)
				,	cast(o.cupomfiscalcancelador as int)
				,	cast(o.hora_fim as time)
				,	cast(o.hora_ini as time)
				,	cast(o.df_nf_seq_blue as int)
				,	cast(o.faturamento_controle_seq  as int)
		FROM 		tbfaturamentoorigem 	o 
		inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
		inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq 
		WHERE 	ct.numeropedido = vnumeropedido 
		and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
		and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
		;
		-- select * from tbfaturamentoorigem limit 20

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;

ALTER FUNCTION public.f0070_22_1012010_faturamento_origem_processar(integer, integer, integer, integer, integer, integer, integer)
    OWNER TO postgres;

