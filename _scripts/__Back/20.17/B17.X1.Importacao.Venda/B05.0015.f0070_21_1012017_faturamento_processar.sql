-- FUNCTION: public.f0070_21_1012010_faturamento_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_21_1012010_faturamento_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_21_1012017_faturamento_processar(
	vfaturamento_controle_seq integer,
	vop_cdoperacao integer,
	vnumeropedido integer,
	vdf_nf_seq_blue integer,
	vsat_ecf integer,
	vcupomfiscal integer,
	vcdpessoabluesoft_cliente integer)
    RETURNS TABLE(seqfaturamento integer, datafaturamento date, dataemissao date, em_cdempresa integer, op_cdoperacao integer, cdparticipantecliente integer, cdparticipantevendedor integer, statusfaturamento integer, faturamento_controle_seq integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
 --- declare  
begin

		INSERT INTO tbfaturamento
			(	
					faturamento_controle_seq 
				,	op_cdoperacao 
				,	em_cdempresa 
				,	dataemissao 
				,	datafaturamento
				,	cdparticipantecliente
				,	cdparticipantevendedor
				,	statusfaturamento
			)
			select 	ct.faturamento_controle_seq
				,	ct.op_cdoperacao 
				,	op.em_cdempresa
				,	ct.dataemissao
				,	ct.datafaturamento 
				,	p.cdparticipante 
				,	cast(1  as int)
				,	cast(1  as smallint)
			from 		tbfaturamento_controle  ct
			inner join  tboperacao 			 op on op.op_cdoperacao = ct.op_cdoperacao 
			inner join  tbparticipante			 p on p.cdpessoabluesoft = ct.cdpessoabluesoft_cliente 
			where	1 = 1
			and		ct.op_cdoperacao = vop_cdoperacao
			and     ct.numeropedido = vnumeropedido
			and		ct.sat_ecf = vsat_ecf
			and		ct.cupomfiscal = vcupomfiscal
			and		ct.faturamento_controle_seq = vfaturamento_controle_seq
			and		not exists (	select 1 
									from 	tbfaturamento aa
									where	aa.faturamento_controle_seq = ct.faturamento_controle_seq
				)

		;
		update tbfaturamento_controle ct 
			set seqfaturamento = a.seqfaturamento 
		from tbfaturamento a 
		where a.faturamento_controle_seq = ct.faturamento_controle_seq 
		and	  ct.op_cdoperacao = vop_cdoperacao
		and   ct.numeropedido = vnumeropedido
		and	  ct.sat_ecf = vsat_ecf
		and   ct.cupomfiscal = vcupomfiscal		
		
		
		;
		RETURN QUERY 

		SELECT 		cast(f.seqfaturamento as int) 
				,	cast(f.datafaturamento as date)
				,	cast(f.dataemissao  as date)
				,	cast(f.em_cdempresa as int)
				,	cast(f.op_cdoperacao as int)
				,	cast(f.cdparticipantecliente as int)
				,	cast(f.cdparticipantevendedor as int)
				,	cast(f.statusfaturamento as int)
				,	cast(f.faturamento_controle_seq as int)
		FROM 		tbfaturamento f 
		inner join  tbfaturamento_controle ct on ct.seqfaturamento = f.seqfaturamento 
		WHERE 	ct.numeropedido = vnumeropedido 
		and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
		and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
		;

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;

