CREATE OR REPLACE FUNCTION public.f0085_54_1012019_zanthus_carga_tabmercadoria()
 RETURNS void
 LANGUAGE plpgsql
AS $function$
   DECLARE VSOMA_TOTAL numeric(13,2);
   declare vuuid_start varchar(30);
   declare vcod_voucher varchar(8);
begin

	vuuid_start:= 'F0085_54.1012019' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_54.MERCADORIA.V-20.19', 'Zanthus/Carga (5) _ Mercadoria', vuuid_start, vuuid_start)
	;

	
	insert into TbZanthusTab_Mercadoria
		(
					pr_cdproduto								
 				,	prb_cdprodutobluesoft
 				,	preg_cdbarra								
				,	cod_loja 									
				,	controle 									
				,	cod_mercadoria 								
				,	descricao 		
				,	desc_abr 
				,	cod_departamento 

				,	COD_TECLA
				,	PERCENTUAL_DESC_VENDA
				,	PERMISSAO_VENDA

				,	INDICA_MERC_PESO_VARIAVEL
				,	CUSTO_UNITARIO
				,	GRUPO_GARANTIA	
				,	FATOR_SEGURANCA_VENDA_ESTOQUE
				,	UNIDADE_VENDA		
				,	DATA_MODO_PRECO		
				,	MARGEM_MERCADORIA	
				,	QUANTIDADE_EMBALAGEM		
				,	COD_FORNECEDOR
				,	CUSTO_MOEDA_ESTAVEL

				,	QUANTIDADE_BONUS_VENDA	
				,	QUANTIDADE_MAX_PRECO_PROMO		
				,	VALOR_TOTAL_PRECO_PROMOCAO		
				,	CUSTO_CONTABIL					
				,	QUANTIDADE_MAXIMA_VENDA			
				,	MULTIPLICA_PONTOS_VALOR_LIQ		
				,	QUANTIDADE_PONTOS_VENDA	
				,	COD_NCM 
				,	CEST

				,	DATA_CADASTRO 
				,	DATA_ULTIMA_ALTERACAO 

				,	COD_TRIBUTACAO_MERCADORIA	
				,	COD_SITUACAO_TRIBUTARIA		
				,	ALIQUOTA_ICMS	
				,	PERCENTUAL_REDUZ_B_CALCULO				

				,	cfop 
				,	cod_sit_trib_pis
				,	aliquota_pis
				,	cod_sit_trib_cofins
				,	aliquota_cofins				
				,   peso_bruto
				,   peso_liquido
				,	codigo_beneficio_fiscal
				,	flginativo
			)
	
	select 		em.pr_cdproduto												as pr_cdproduto
			,	em.prb_cdprodutobluesoft									as prb_cdprodutobluesoft
			,	gt.preg_cdbarra												as preg_cdbarra
			,	1															as cod_loja
			,	'000'														as controle 
			,	lpad(gt.preg_cdbarra, 17, '0' ) 								as cod_mercadoria 
			,	left(pb.prb_descricao_cupom,50)								as descricao 
			,	left(pb.prb_descricao_cupom,25)								as desc_abr
			,	cast(1 as int ) 											as cod_departamento 

																		
			,	CAST( 0 AS INT ) 											AS COD_TECLA							
			,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
			,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA

			,	CASE WHEN pr.pr_embalagemestoque = 'KG' and length(cast(gt.preg_cdbarra as varchar(17))) = 6 THEN '1' ELSE '0' END as INDICA_MERC_PESO_VARIAVEL
			,	cast(0 as numeric(13,2) ) 									as CUSTO_UNITARIO
			,	cast(0 as int)                                              as GRUPO_GARANTIA	
			,	cast(0 as int)    											as FATOR_SEGURANCA_VENDA_ESTOQUE
			,	em.pre_embalagem										    as UNIDADE_VENDA		
			,	cast(null as date )											as DATA_MODO_PRECO		
			,	cast(0 as numeric(13,2)) 									as MARGEM_MERCADORIA	
			,	cast(em.pre_fatorestoque as numeric(17,4))					as QUANTIDADE_EMBALAGEM		
			,	cast('' as varchar(16))										as COD_FORNECEDOR
			,	cast(0 as numeric(13,2)) 									as CUSTO_MOEDA_ESTAVEL
	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
			,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
			,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
			,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
			, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
			,	COALESCE(XX.ncm_codigo,0)										AS COD_NCM 
			,	COALESCE(XX.CEST, 0)										AS CEST 

			,	current_Date												as data_Cadastro
			,	current_Date												as data_ultima_alteracao 

			/*  ICMS ---------- */
			,	XX.cod_tributacao_pdv										as cod_tributacao_mercadoria

			,	xx.icms_cst													as COD_SITUACAO_TRIBUTARIA 
			,   xx.icms_aliquota											as ALIQUOTA_ICMS
			,	XX.icms_reducao												as  PERCENTUAL_REDUZ_B_CALCULO			

			/*  CFOP */
			,	CASE WHEN cast(xx.icms_cst as int) = 60 
						then 5405
						else 5102
						end  as cfop 

			/*  PIS ---------- */																			
			,	xx.pis_cst
			,	xx.pis_aliquota

			/*  COFINS ---------- */																			
			,	xx.cofins_cst
			,	xx.cofins_aliquota		
			,   cast(pb.prb_pesobruto as numeric(12,3)) as peso_bruto
			,   cast(pb.prb_pesoliquido as numeric(12,3)) as peso_liquido
			,	XX.codigo_beneficio_fiscal 
			,   'N'as flginativo														
	from 		tbprodutoembalagem_gtins		gt
	inner join  tbprodutoembalagem				em on em.prb_cdprodutobluesoft = gt.prb_cdprodutobluesoft 
	inner join  tbproduto						pr on pr.pr_cdproduto = em.pr_cdproduto
	inner join  tbprodutobluesoft				pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft 
	INNER JOIN  tbzanthus_tributacao_produto	XX ON XX.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft and xx.flg_revenda = 'N' 
	where		1 = 1
	and			pr.pr_status = 'true'
	and			em.pre_status = 'true'
	and         xx.flg_revenda = 'N' 
				/* TAB MERCADORIA PREENCHIDA COM A TRIBUTAÇÃO BASICA PARA CONSUMIDOR FINAL */
	--14/04/2022 -------------------------------------------------------------------------------------------	
	AND	(		pb.prb_cdprodutobluesoftunitario in ( select 		PR.PRB_CDPRODUTOBLUESOFT 
														from 		TBPRECO_APLICACAO	PX
														INNER JOIN 	TBPRODUTO			PR ON PR.PR_CDPRODUTO = PX.PR_CDPRODUTO 
														GROUP BY 	PR.PRB_CDPRODUTOBLUESOFT )
		)
	AND gt.preg_cdbarra NOT IN ( SELECT PREG_CDBARRA_INSUMO FROM TbZanthustab_produto_decomposicao_insum)
	AND lpad(gt.preg_cdbarra, 17, '0' ) NOT IN (SELECT cod_mercadoria from TbZanthusTab_Mercadoria)


	;

	/* SELECT DE PRODUTOS QUE FAZEM PARTE DE COMPOSIÇÃO DE CESTA */
	insert into TbZanthusTab_Mercadoria
			(
						pr_cdproduto								
					,	prb_cdprodutobluesoft
					,	preg_cdbarra								
					,	cod_loja 									
					,	controle 									
					,	cod_mercadoria 								
					,	descricao 		
					,	desc_abr 
					,	cod_departamento 

					,	COD_TECLA
					,	PERCENTUAL_DESC_VENDA
					,	PERMISSAO_VENDA

					,	INDICA_MERC_PESO_VARIAVEL
					,	CUSTO_UNITARIO
					,	GRUPO_GARANTIA	
					,	FATOR_SEGURANCA_VENDA_ESTOQUE
					,	UNIDADE_VENDA		
					,	DATA_MODO_PRECO		
					,	MARGEM_MERCADORIA	
					,	QUANTIDADE_EMBALAGEM		
					,	COD_FORNECEDOR
					,	CUSTO_MOEDA_ESTAVEL

					,	QUANTIDADE_BONUS_VENDA	
					,	QUANTIDADE_MAX_PRECO_PROMO		
					,	VALOR_TOTAL_PRECO_PROMOCAO		
					,	CUSTO_CONTABIL					
					,	QUANTIDADE_MAXIMA_VENDA			
					,	MULTIPLICA_PONTOS_VALOR_LIQ		
					,	QUANTIDADE_PONTOS_VENDA	
					,	COD_NCM 
					,	CEST

					,	DATA_CADASTRO 
					,	DATA_ULTIMA_ALTERACAO 

					,	COD_TRIBUTACAO_MERCADORIA	
					,	COD_SITUACAO_TRIBUTARIA		
					,	ALIQUOTA_ICMS	
					,	PERCENTUAL_REDUZ_B_CALCULO				

					,	cfop 
					,	cod_sit_trib_pis
					,	aliquota_pis
					,	cod_sit_trib_cofins
					,	aliquota_cofins				
					,   peso_bruto
					,   peso_liquido
					,	codigo_beneficio_fiscal
					,	flginativo
						)


		select 		im.pr_cdproduto												as pr_cdproduto					--->> CODIGO DA CESTA (COIGO PAI)
				,	im.prb_cdprodutobluesoft									as prb_cdprodutobluesoft		--->> CODIGO DE CADA ITEM, COMO SE FOSSE RELACIONADO 
				,	im.preg_cdbarra_insumo										as preg_cdbarra
				,	1															as cod_loja
				,	'000'														as controle 
				,	im.cod_insumo												as cod_mercadoria 
				,	left(pb.prb_descricao_cupom,50)								as descricao 
				,	left(pb.prb_descricao_cupom,25)								as desc_abr
				,	cast(1 as int ) 											as cod_departamento 
				,	CAST( 0 AS INT ) 											AS COD_TECLA							
				,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
				,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA
				,	CASE WHEN pb.prb_embalagemestoque = 'KG' and length(cast(PB.PRB_CDBARRA_PRINCIPAL as varchar(17))) = 6 THEN '1' ELSE '0' END as INDICA_MERC_PESO_VARIAVEL
				,	cast(0 as numeric(13,2) ) 									as CUSTO_UNITARIO
				,	cast(0 as int)                                              as GRUPO_GARANTIA	
				,	cast(0 as int)    											as FATOR_SEGURANCA_VENDA_ESTOQUE
				,	pb.prb_embalagemestoque									    as UNIDADE_VENDA		
				,	cast(null as date )											as DATA_MODO_PRECO		
				,	cast(0 as numeric(13,2)) 									as MARGEM_MERCADORIA	
				,	cast(1 as numeric(17,4))									as QUANTIDADE_EMBALAGEM		
				,	cast('' as varchar(16))										as COD_FORNECEDOR
				,	cast(0 as numeric(13,2)) 									as CUSTO_MOEDA_ESTAVEL
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
				,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
				,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
				,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
				, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
				,	COALESCE(XX.ncm_codigo,0)									AS COD_NCM 
				,	COALESCE(XX.cest, 0)										AS CEST 
				,	current_Date												as data_Cadastro
				,	current_Date												as data_ultima_alteracao 

				/*  ICMS ---------- */
				,	XX.cod_tributacao_pdv										as cod_tributacao_mercadoria

				,	xx.icms_cst													as COD_SITUACAO_TRIBUTARIA 
				,   xx.icms_aliquota											as ALIQUOTA_ICMS
				,	XX.icms_reducao												as  PERCENTUAL_REDUZ_B_CALCULO			

				/*  CFOP */
				,	CASE WHEN cast(xx.icms_cst as int) = 60 
							then 5405
							else 5102
							end  as cfop 

				/*  PIS ---------- */																			
				,	xx.pis_cst
				,	xx.pis_aliquota

				/*  COFINS ---------- */																			
				,	xx.cofins_cst
				,	xx.cofins_aliquota		
				,   cast(pb.prb_pesobruto as numeric(12,3)) as peso_bruto
				,   cast(pb.prb_pesoliquido as numeric(12,3)) as peso_liquido
				,	XX.codigo_beneficio_fiscal 
				,   'N' as flginativo
				
		from 		TbZanthustab_produto_decomposicao_insum im
		inner join  TbZanthustab_produto_decomposicao 		dc on dc.pr_cdproduto = im.pr_cdproduto 
		inner join  tbproduto								pr on pr.pr_cdproduto = im.pr_cdproduto
		inner join  tbprodutobluesoft						pb on pb.prb_cdprodutobluesoft_pk = im.prb_cdprodutobluesoft 
		INNER JOIN  tbzanthus_tributacao_produto			XX ON XX.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_PK and xx.flg_revenda = 'N' 
		INNER JOIN  ( 	SELECT 
										im.cod_insumo							as cod_mercadoria 
									,	 min(im.pr_cdproduto	)				as pr_cdproduto 
							from 		TbZanthustab_produto_decomposicao_insum im
							inner join  TbZanthustab_produto_decomposicao 		dc on dc.pr_cdproduto = im.pr_cdproduto 
							inner join  tbproduto								pr on pr.pr_cdproduto = im.pr_cdproduto
							inner join  tbprodutobluesoft						pb on pb.prb_cdprodutobluesoft_pk = im.prb_cdprodutobluesoft 
							where		1 = 1
							and			pr.pr_status = 'true'
							--and 		im.cod_insumo = '00000000000101168'
							group by 	im.cod_insumo
					) DUP_INSUM_PROD ON DUP_INSUM_PROD.COD_MERCADORIA = im.cod_insumo AND DUP_INSUM_PROD.pr_cdproduto = im.pr_cdproduto	 
		where		1 = 1
		and			pr.pr_status = 'true'
		and			im.cod_insumo	not in (select cod_mercadoria from TbZanthusTab_Mercadoria )
		and         xx.flg_revenda = 'N' 
		order by pr_cdproduto, im.prb_cdprodutobluesoft, im.cod_insumo 
		;




	UPDATE 		TbZanthusTab_Mercadoria A
	SET         descricao 						= B.descricao 
			,	desc_abr 						= B.desc_abr
			,	INDICA_MERC_PESO_VARIAVEL 		= B.INDICA_MERC_PESO_VARIAVEL
			,	UNIDADE_VENDA 					= B.UNIDADE_VENDA
			,	QUANTIDADE_EMBALAGEM			= B.QUANTIDADE_EMBALAGEM
			,	COD_NCM							= B.COD_NCM
			,	CEST							= B.CEST
			,	cod_tributacao_mercadoria		= B.cod_tributacao_mercadoria
			,	COD_SITUACAO_TRIBUTARIA			= B.COD_SITUACAO_TRIBUTARIA
			,	ALIQUOTA_ICMS					= B.ALIQUOTA_ICMS
			,	PERCENTUAL_REDUZ_B_CALCULO		= B.PERCENTUAL_REDUZ_B_CALCULO
			,	cfop							= B.cfop
			,	cod_sit_trib_pis				= B.cod_sit_trib_pis
			,	aliquota_pis					= B.aliquota_pis
			,	cod_sit_trib_cofins				= B.cod_sit_trib_cofins
			,	aliquota_cofins					= B.aliquota_cofins
			,   peso_bruto						= B.peso_bruto
			,   peso_liquido					= B.peso_liquido
			,	codigo_beneficio_fiscal 		= B.codigo_beneficio_fiscal
			,	flginativo						= B.flginativo
			,	DATA_ULTIMA_ALTERACAO 			= current_timestamp 

	FROM (		
		select 		em.pr_cdproduto												as pr_cdproduto
				,	em.prb_cdprodutobluesoft									as prb_cdprodutobluesoft
				,	gt.preg_cdbarra												as preg_cdbarra
				,	1															as cod_loja
				,	'000'														as controle 
				,	lpad(gt.preg_cdbarra, 17, '0' ) 							as cod_mercadoria 
				,	left(pb.prb_descricao_cupom,50)								as descricao 
				,	left(pb.prb_descricao_cupom,25)								as desc_abr
				,	cast(1 as int ) 											as cod_departamento 

																			
				,	CAST( 0 AS INT ) 											AS COD_TECLA							
				,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
				,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA

				,	CASE WHEN pr.pr_embalagemestoque = 'KG' and length(cast(gt.preg_cdbarra as varchar(17))) = 6 THEN '1' ELSE '0' END as INDICA_MERC_PESO_VARIAVEL
				,	cast(0 as numeric(13,2) ) 									as CUSTO_UNITARIO
				,	cast(0 as int)                                              as GRUPO_GARANTIA	
				,	cast(0 as int)    											as FATOR_SEGURANCA_VENDA_ESTOQUE
				,	em.pre_embalagem										    as UNIDADE_VENDA		
				,	cast(null as date )											as DATA_MODO_PRECO		
				,	cast(0 as numeric(13,2)) 									as MARGEM_MERCADORIA	
				,	cast(em.pre_fatorestoque as numeric(17,4))					as QUANTIDADE_EMBALAGEM		
				,	cast('' as varchar(16))										as COD_FORNECEDOR
				,	cast(0 as numeric(13,2)) 									as CUSTO_MOEDA_ESTAVEL
		
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
				,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
				,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
				,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
				,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
				, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
				,	COALESCE(XX.ncm_codigo,0)									AS COD_NCM 
				,	COALESCE(XX.CEST, 0)										AS CEST 

				,	current_Date												as data_Cadastro
				,	current_Date												as data_ultima_alteracao 

				/*  ICMS ---------- */
				,	XX.cod_tributacao_pdv										as cod_tributacao_mercadoria

				,	xx.icms_cst													as COD_SITUACAO_TRIBUTARIA 
				,   xx.icms_aliquota											as ALIQUOTA_ICMS
				,	XX.icms_reducao												as PERCENTUAL_REDUZ_B_CALCULO			

				/*  CFOP */
				,	CASE WHEN cast(xx.icms_cst as int) = 60 
							then 5405
							else 5102
							end  												as cfop 
		
				/*  PIS ---------- */																			
				,	xx.pis_cst													AS cod_sit_trib_pis
				,	xx.pis_aliquota												AS aliquota_pis

				/*  COFINS ---------- */																			
				,	xx.cofins_cst												as cod_sit_trib_cofins
				,	xx.cofins_aliquota											as aliquota_cofins
				,   cast(pb.prb_pesobruto as numeric(12,3)) 					as peso_bruto
				,   cast(pb.prb_pesoliquido as numeric(12,3)) 					as peso_liquido
				,	XX.codigo_beneficio_fiscal 									as codigo_beneficio_fiscal 
				,   case when pb.prb_status = 'true' then 'N' else 'S' end 		as flginativo
		from 		tbprodutoembalagem_gtins		gt
		inner join  tbprodutoembalagem				em on em.prb_cdprodutobluesoft = gt.prb_cdprodutobluesoft 
		inner join  tbproduto						pr on pr.pr_cdproduto = em.pr_cdproduto
		inner join  tbprodutobluesoft				pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft 
		INNER JOIN  tbzanthus_tributacao_produto	XX ON XX.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft and xx.flg_revenda = 'N' 
		where		1 = 1
	) B 
	WHERE B.cod_mercadoria = A.Cod_mercadoria 
	and (
				A.descricao 					!= B.descricao 
			OR	A.desc_abr 						!= B.desc_abr
			OR	A.INDICA_MERC_PESO_VARIAVEL 	<> B.INDICA_MERC_PESO_VARIAVEL
			OR	A.UNIDADE_VENDA 				!= B.UNIDADE_VENDA
			OR	A.QUANTIDADE_EMBALAGEM			<> B.QUANTIDADE_EMBALAGEM
			OR	A.COD_NCM						<> B.COD_NCM
			OR	A.CEST							<> B.CEST
			OR	A.cod_tributacao_mercadoria		<> B.cod_tributacao_mercadoria
			OR	A.COD_SITUACAO_TRIBUTARIA		!= B.COD_SITUACAO_TRIBUTARIA
			OR	A.ALIQUOTA_ICMS					<> B.ALIQUOTA_ICMS
			OR	A.PERCENTUAL_REDUZ_B_CALCULO	<> B.PERCENTUAL_REDUZ_B_CALCULO
			OR	A.cfop							<> B.cfop
			OR	A.cod_sit_trib_pis				!= B.cod_sit_trib_pis
			OR	A.aliquota_pis					<> B.aliquota_pis
			OR	A.cod_sit_trib_cofins			!= B.cod_sit_trib_cofins
			OR	A.aliquota_cofins				<> B.aliquota_cofins
			OR  A.peso_bruto					<> B.peso_bruto
			OR  A.peso_liquido					<> B.peso_liquido
			OR	A.codigo_beneficio_fiscal 		!= B.codigo_beneficio_fiscal
			OR  A.flginativo					!= B.flginativo


	)
	;

end;
$function$

;
select f0085_54_1012019_zanthus_carga_tabmercadoria()