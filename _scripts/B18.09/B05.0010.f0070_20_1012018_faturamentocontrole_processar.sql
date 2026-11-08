-- FUNCTION: public.f0070_20_1012010_faturamento_controle_processar(integer, character varying, integer, integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_20_1012010_faturamento_controle_processar(integer, character varying, integer, integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0070_20_1012018_faturamentocontrole_processar(
	vfat_controle_tipo_cd integer,
	vseqfaturamento_uuid character varying,
	vop_cdoperacao integer,
	vnumeropedido integer,
	vnumeropedido_fv integer,
	vdf_nf_seq_blue integer,
	vsat_ecf integer,
	vcupomfiscal integer,
	vcdpessoabluesoft_cliente integer,
	vreprocessaritem integer)
    RETURNS TABLE(seqfaturamento_uuid character varying, faturamento_controle_seq bigint, op_cdoperacao integer, dataemissao date, datafaturamento date, numeropedido integer, df_nf_seq_blue integer, sat_ecf integer, cupomfiscal integer, fat_controle_tipo_cd integer, seqfaturamento integer, seqfaturamentoorigem integer, cdpessoabluesoft_cliente integer, numeropedido_fv integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
  declare  NUMERO_seqfaturamento_uuid VARCHAR(12);
  DECLARE  NUMERO_faturamento_controle_seq INT;
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
				
				insert into   tbfaturamento_controle 
						(
								seqfaturamento_uuid
							,	dataemissao 
							,	datafaturamento 
							,	numeropedido
							,	numeropedido_fv 
							,	df_nf_seq_blue
							,	numeronfe 
							,	sat_ecf 
							,	cupomfiscal 
							,	fat_controle_tipo_cd
							,	seqfaturamento
							,	seqfaturamentoorigem
							,	seqfaturamento_old
							,	seqfaturamento_origem_old
							,	cdpessoabluesoft_cliente
							,	op_cdoperacao 
						)
					
					select 	
					       		cast(gen_random_uuid () as varchar(3)) || TO_CHAR(fa.numeropedido, '0000000')
							,	fa.data_emissao
							,	fa.data_faturamento 
							,	fa.numeropedido 
							,	fa.numeropedido_fv
							,	fa.df_nf_seq_blue  
							,	coalesce(nf.df_nf_numero,0) as df_nf_numero 
							,	0 as sat_ecf 
							,	0 as cupomfiscal 
							,	1 as fat_controle_tipo_cd ----- TIPO VENDA INICIAL 
							,	0 as seqfaturamento
							,	0 as seqfaturamentoorigem
							,	0 as seqfaturamento_old
							,	0 as seqfaturamento_origem_old
							,	fa.cdpessoabluesoft_cliente
							,	fa.op_cdoperacao 
					from 			tbfaturamento_bluesoft				fa
					inner join 		tbfaturamento_bluesoft_status		st on st.fat_blue_status_cd = fa.fat_blue_status_cd
					left  join      tbdocumentofiscal 					nf on nf.df_nf_seq_blue = fa.df_nf_seq_blue and nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente
					where	1 = 1


					and		fa.op_cdoperacao in(1,2,4)
					and		fa.fat_blue_status_cd 
									in (
											20, -- Aguardando Analise Gerencial
											25, -- Em Analise Gerencial
											27, -- Em Analise de Credito
											30, -- Fechado
											40, -- Em sepracao 
											45, -- Separado
											50, -- Faturando
											55, -- FATURADO POR NOTA FISCAL
											70  -- ENTREGUE
					
									)
					and		coalesce(fa.df_nf_seq_blue_dev,0) = 0 			
					
					and		not exists ( 	select 1 
											from 	tbfaturamento_controle aa
											where 	aa.numeropedido = fa.numeropedido
											and		aa.numeropedido_fv = fa.numeropedido_fv 
											and		aa.op_cdoperacao = fa.op_cdoperacao 
											and		aa.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
										)
					and     fa.numeropedido = vnumeropedido 
					and     fa.numeropedido_fv = vnumeropedido_fv
					and     fa.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
					and     fa.op_cdoperacao = vop_cdoperacao
					
			;
		end if;
		
		NUMERO_faturamento_controle_seq:= ( 	select  aa.faturamento_controle_seq 
												from 	tbfaturamento_controle aa
												where 	aa.numeropedido = vnumeropedido
												and		aa.op_cdoperacao = vop_cdoperacao 
												and		aa.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
											)

		;

		if (vreprocessaritem = 1 AND NUMERO_faturamento_controle_seq > 0)
		then
				delete from tbfaturamentoitens aa where aa.seqfaturamentoorigem in (select xx.seqfaturamentoorigem from tbfaturamentoorigem xx where xx.faturamento_controle_seq = NUMERO_faturamento_controle_seq );
				delete from tbfaturamentoitensembalagem aa where aa.seqfaturamentoorigem in (select xx.seqfaturamentoorigem from tbfaturamentoorigem xx where xx.faturamento_controle_seq = NUMERO_faturamento_controle_seq );
				delete from tbfaturamentoitensinfo aa where aa.seqfaturamentoorigem in (select xx.seqfaturamentoorigem from tbfaturamentoorigem xx where xx.faturamento_controle_seq = NUMERO_faturamento_controle_seq );
				delete from tbfaturamentoitenscontratos  aa where aa.seqfaturamentoorigem in (select xx.seqfaturamentoorigem from tbfaturamentoorigem xx where xx.faturamento_controle_seq = NUMERO_faturamento_controle_seq );
		end if;

		/* DEVOLVER O REGISTRO CRIADO/CONSULTADO */
		RETURN QUERY 
		SELECT 		CAST(ct.seqfaturamento_uuid AS VARCHAR(40))
				,	ct.faturamento_controle_seq
				,	ct.op_cdoperacao 
				,	cast(ct.dataemissao	as date)
				,	cast(ct.datafaturamento as date)
				,	ct.numeropedido
				,	ct.df_nf_seq_blue					
				, 	ct.sat_ecf 						
				,	ct.cupomfiscal 					
				,	CAST(ct.fat_controle_tipo_cd AS INT)
				,	ct.seqfaturamento 
				,	ct.seqfaturamentoorigem			
				,	ct.cdpessoabluesoft_cliente 
				,	ct.numeropedido_fv
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



