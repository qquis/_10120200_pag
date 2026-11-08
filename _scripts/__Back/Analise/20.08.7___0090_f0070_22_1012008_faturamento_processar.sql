/*
"11fb86550d-3365-429d-b214-a4703cd7701a  "
SELECT * from public.f0070_20_1012008_faturamento_controle_processar
	(
		vfat_controle_tipo_cd:= 1
	,	vseqfaturamento_uuid:= ''
	,	vop_cdoperacao:= 1
	,	vnumeropedido:= 327123
	,	vdf_nf_seq_blue:= 0
	,	vsat_ecf:= 0  
	,	vcupomfiscal:= 0
	,	vcdpessoabluesoft_cliente:= 45101
	
	)

delete from  tbfaturamento_controle where seqfaturamento_uuid = 'a5c2fd41-a01c-445_FV20250403000000327123'
	
*/

--select * from tbfaturamento_controle limit 10
--select * from tbfaturamento limit 10

CREATE OR REPLACE
 -- drop 
FUNCTION public.f0070_22_1012008_faturamento_processar
(
		vfat_controle_tipo_cd       	int
	,	vseqfaturamento_uuid 			varchar(40)
	,	vop_cdoperacao 					int
	,	vnumeropedido 					int
	,	vdf_nf_seq_blue 				int
	,	vsat_ecf						int 
	,	vcupomfiscal					int
	,	vcdpessoabluesoft_cliente		int
	,	vseqfaturamento 				int 

)
	
    RETURNS TABLE(
			seqfaturamento_uuid 			varchar(40)
		,	faturamento_controle_seq 		bigint
		,	op_cdoperacao 					int
		,	dataemissao						date 
		,	datafaturamento					date 
		,	numeropedido 					int
		,	df_nf_seq_blue					int 
		, 	sat_ecf 						int
		,	cupomfiscal 					int 
		,	fat_controle_tipo_cd			int
		,	seqfaturamento					int
		,	seqfaturamentoorigem			int 
	)
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
	
AS $BODY$
 --- declare  
begin
		if (	select 	count(*) 
				from   	tbfaturamento_controle l
				where	l.fat_controle_tipo_cd = vfat_controle_tipo_cd 
				  and   l.numeropedido = vnumeropedido
				  and   l.sat_ecf = vsat_ecf
				  and   l.cupomfiscal = vcupomfiscal
				  and   l.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
			) > 0 
		then 
			if  (select  	coalesce(ct.seqfaturamento,0)
				from 		tbfaturamento_controle ct
				where	ct.fat_controle_tipo_cd = vfat_controle_tipo_cd 
				  and   ct.numeropedido = vnumeropedido
				  and   ct.sat_ecf = vsat_ecf
				  and   ct.cupomfiscal = vcupomfiscal
				  and   ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente)
				) = 0 
				then 
					insert into tbfaturamento 
						(
								faturamento_controle_seq
							,	seqfaturamento_uuid
							,	dataemissao 
							,	datafaturamento
							,	em_cdempresa
							,	op_cdoperacao 
							,	cdparticipantecliente
							,	cdparticipantevendedor
							,	statusfaturamento	

						)
					select 		ct.faturamento_controle_seq
							,	ct.seqfaturamento_uuid
							,	bf.dataemissao
							,	bf.datafaturamento
							,	op.em_cdempresa
							,	op.op_cdoperacao 
							,	cl.cdparticipante 
							,	ve.cdparticipante
							,	vstatusfaturamento 
					from 		tbfaturamento_bluesoft 		bf 
					inner join  tbfaturamento_controle 	ct 	on 	ct.numeropedido = bf.numeropedido 
															and ct.cdpessoabluesoft_cliente = bf.cdpessoabluesoft_cliente
					inner join  tboperacao 					op  on  op.op_cdoperacao = ct.op_cdoperacao 										
					inner join  tbparticipante_bluesoft 	cl  on	cl.cdpessoabluesoft = bf.cdpessoabluesoft_cliente
					inner join  tbparticipante_bluesoft 	ve  on	ve.cdpessoabluesoft = bf.cdpessoabluesoft_vendedor
					where		ct.numeropedido = vnumeropedido
					  and       ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
				;

						
				
				
				end if;
		else
			RAISE EXCEPTION 'Nenhum registro encontrado na tabela de controle para o faturamento indicado!';
		end if;
		



		/* DEVOLVER O REGISTRO CRIADO/CONSULTADO */
		RETURN QUERY 
		SELECT 		CAST(ct.seqfaturamento_uuid AS VARCHAR(40))
				,	ct.faturamento_controle_seq
				,	ct.op_cdoperacao 
				,	ct.dataemissao						
				,	ct.datafaturamento					
				,	ct.numeropedido 					
				,	ct.df_nf_seq_blue					
				, 	ct.sat_ecf 						
				,	ct.cupomfiscal 					
				,	CAST(ct.fat_controle_tipo_cd AS INT)
				,	ct.seqfaturamento 
				,	ct.seqfaturamentoorigem			
		FROM 	tbfaturamento_controle ct
		WHERE 	ct.numeropedido = vnumeropedido 
		and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
		and 	ct.fat_controle_tipo_cd = vfat_controle_tipo_cd
		;




		
	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;
