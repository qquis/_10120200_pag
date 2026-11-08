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
CREATE OR REPLACE
 -- drop 
FUNCTION public.f0070_20_1012008_faturamento_controle_processar
(
		vfat_controle_tipo_cd       	int
	,	vseqfaturamento_uuid 			varchar(40)
	,	vop_cdoperacao 					int
	,	vnumeropedido 					int
	,	vdf_nf_seq_blue 				int
	,	vsat_ecf						int 
	,	vcupomfiscal					int
	,	vcdpessoabluesoft_cliente		int

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
			) < 1
		then 
			insert into tbfaturamento_controle
					         (
									seqfaturamento_uuid 
								,	fat_controle_tipo_cd 
								,	op_cdoperacao 
								,	dataemissao 
								,	datafaturamento 
								,	numeropedido 
								,	numeropedido_fv 
								,	df_nf_seq_blue 
								,	numeronfe
								,	sat_ecf 
								, 	cupomfiscal 
								,	seqfaturamento
								,	seqfaturamentoorigem 
								,	seqfaturamento_old
								,	seqfaturamento_origem_old
								,	cdpessoabluesoft_cliente
						)
						select 	case vop_cdoperacao 
						             when 1 -- blue
						                  then CONCAT(left(cast(gen_random_uuid () as varchar(40)),17),'_FV', TO_CHAR(p.data_emissao, 'YYYYMMDD'), TO_CHAR(p.numeropedido, 'FM000000000000'))
									 when 2 --- ZANTHUS	
									      then CONCAT(left(cast(gen_random_uuid () as varchar(40)),17),'_FV')
									 when 4 --- BLUE
						                  then CONCAT(left(cast(gen_random_uuid () as varchar(40)),17),'_FV', TO_CHAR(p.data_emissao, 'YYYYMMDD'), TO_CHAR(p.numeropedido, 'FM000000000000'))
									 when 6 --- BLUE
									 	  then CONCAT(left(cast(gen_random_uuid () as varchar(40)),17),'_FV', TO_CHAR(p.data_emissao, 'YYYYMMDD'), TO_CHAR(p.numeropedido, 'FM000000000000'))
								end
									
							,	vfat_controle_tipo_cd
							,	p.op_cdoperacao 
							,	p.data_emissao
							,	p.data_faturamento  
							,	p.numeropedido 
							,	p.numeropedido_fv 
							,	o.df_nf_seq_blue
							,	nf.df_nf_numero 
							,	0
							,	0
							,	0
							,	0
							,	0
							,	0
							,	p.cdpessoabluesoft_cliente
			
						from 		tbfaturamento_bluesoft 			p
						inner join 	tbfaturamento_bluesoft_origem 	o 	on o.numeropedido = p.numeropedido and o.numeropedido_fv = p.numeropedido_fv 
						left  join  tbdocumentofiscal 				nf on nf.df_nf_seq_blue = o.df_nf_seq_blue 
						WHERE 	p.numeropedido = vnumeropedido 
						  and 	p.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
						  and   not exists(  select 	1
						                     from   	tbfaturamento_controle xx
											  where 	xx.numeropedido = vnumeropedido 
						 					  and 		xx.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
											  and 	    xx.fat_controle_tipo_cd = vfat_controle_tipo_cd
										   )
	
					;
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
