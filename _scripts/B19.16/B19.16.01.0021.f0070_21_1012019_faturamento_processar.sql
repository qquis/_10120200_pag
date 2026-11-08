CREATE OR REPLACE FUNCTION public.f0070_21_1012019_faturamento_processar(   
    vdata_processamento date
    
)
 RETURNS VOID 
 LANGUAGE plpgsql
AS $function$
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
			,	v.cdparticipante
			,	cast(1  as smallint)
			from 		tbfaturamento_controle  ct
			inner join  tboperacao 			 		op on op.op_cdoperacao = ct.op_cdoperacao 
			inner join  tbparticipante		 		p on p.cdpessoabluesoft = ct.cdpessoabluesoft_cliente 
			inner join  tbparticipante_bluesoft		v on v.cdpessoabluesoft = ct.cdpessoabluesoft_vendedor 
			where	1 = 1
			and		not exists (	select 1 
									from 	tbfaturamento aa
									where	aa.faturamento_controle_seq = ct.faturamento_controle_seq
				)
			and     coalesce(ct.processamento_pendente,0) = 1

		;
		update tbfaturamento_controle ct 
			set seqfaturamento = a.seqfaturamento 
		from tbfaturamento a 
		where a.faturamento_controle_seq = ct.faturamento_controle_seq 
		and     coalesce(ct.processamento_pendente,0) = 1		

		
		;
	
	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$
