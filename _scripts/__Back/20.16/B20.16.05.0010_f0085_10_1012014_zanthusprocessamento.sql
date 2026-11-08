-- FUNCTION: public.f0085_10_1012014_zanthusprocessamento()

-- DROP FUNCTION IF EXISTS public.f0085_10_1012014_zanthusprocessamento();

----select f0085_10_1012014_zanthusprocessamento()

CREATE OR REPLACE FUNCTION public.f0085_10_1012014_zanthusprocessamento(
	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
   DECLARE VSOMA_TOTAL numeric(13,2);
   declare vuuid_start varchar(30);
   declare vcod_voucher varchar(8);
begin

	vuuid_start:= 'f0085_10_1012007____' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	-------------------------------------------------------------------------------------------------------------------------
	/* ITENS CESTA BASICA */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	

	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - start', vuuid_start, vuuid_start)
	;

	DELETE FROM TbZanthustab_produto_decomposicao_insum;
	DELETE FROM TbZanthustab_produto_decomposicao;

	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Decomposicao', vuuid_start)
	;

	INSERT INTO TbZanthustab_produto_decomposicao_insum
		(
				pr_cdproduto 				
			,	prb_cdprodutobluesoft		
			,	cod_loja					
			,	cod_mercadoria				
			,	cod_insumo	
			,	preg_cdbarra_insumo			
			,	usuario						
			,	data_cadastro				
			,	data_ultima_alteracao 		
			,	controle											
			,	percentual_insumo			
			,	quantidade_insumo			
		)

	select 		pr.pr_cdproduto
			,	cp.prb_cdprodutobluesoft
			,	1
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
			,	repeat('0', 17 - length(gcp.prb_cdbarra_principal) ) || gcp.prb_cdbarra_principal
			,	gcp.prb_cdbarra_principal
			,	'1'
			,	current_timestamp 
			,	current_timestamp
			,	null
			,	cp.prc_percentual_composicao 
			,	cp.prc_qtde 
	from 		tbproduto_composicao			cp 
	LEFT JOIN   tbproduto						pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft gun on gun.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft gcp on gcp.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft
	;

	insert into TbZanthustab_produto_decomposicao 
		(
				pr_cdproduto 				
			,	prb_cdprodutobluesoft	
			,	preg_cdbarra
			,	cod_loja					
			,	controle										
			,	cod_mercadoria				
			,	forma_decomposicao			
			,	tipo_decomposicao			
			,	usuario						
			,	data_cadastro				 
			,	data_ultima_alteracao 		
		)

	select 		pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft
			,	gun.prb_cdbarra_principal
			,	1
			,	NULL 
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
			,	4
			,	7
			,	1 
			,	CURRENT_TIMESTAMP 
			,	CURRENT_TIMESTAMP 
	from 		tbproduto_composicao			cp 
	LEFT JOIN   tbproduto						pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft 				gun on gun.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft_unitario 
	GROUP BY 	pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft
			,	gun.prb_cdbarra_principal
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
	;

	-------------------------------------------------------------------------------------------------------------------------
	/* TRIBUTACAO  */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------	
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tributacao Base', vuuid_start)
	;
	
	DELETE FROM TbZanthusTabTributacao;

	INSERT INTO TbZanthusTabTributacao
		(
				pr_cdproduto 							
			,	prb_cdprodutobluesoft	
			,	preg_cdbarra
			,	prbt_icms_saida_cst						
			,	prbt_icms_aliquota_interna	
			,	prbt_icms_reducao
 			,	prbt_pis_saida_cst 						
 			,	prbt_pis_saida_aliquota					
 			,	prbt_cofins_saida_cst 					
 			,	prbt_cofins_saida_aliquota			
			,	cod_mercadoria 
			,	cod_tributacao_mercadoria	
			,	ALIQUOTA_ICMS						
 			,	PERCENTUAL_REDUZ_B_CALCULO	
			,	COD_SITUACAO_TRIBUTARIA 
			,	COD_NCM 	
			,	cest
		)
	SELECT 	 		coalesce(GTX.pr_cdproduto,0)
				,	coalesce(GTX.prb_cdprodutobluesoft,0)
				,	gt.prbg_cdbarra_pk
				,	TR.prbt_icms_saida_cst
				,	TR.prbt_icms_aliquota_interna
				,	TR.prbt_icms_reducao
				,	TR.prbt_pis_saida_cst 						
				,	TR.prbt_pis_saida_aliquota					
				,	TR.prbt_cofins_saida_cst 					
				,	TR.prbt_cofins_saida_aliquota			
				,	repeat('0', 17 - length(cast(gt.prbg_cdbarra_pk as varchar(17)))) || cast(gt.prbg_cdbarra_pk as varchar(17))
								AS COD_MERCADORIA 
				,	Coalesce(Z.cod_tributacao_pdv, 0 ) AS cod_tributacao_mercadoria
				,	coalesce(z.aliquota, 7) as ALIQUOTA_ICMS
				,	coalesce(z.perc_reducao,0) as PERCENTUAL_REDUZ_B_CALCULO
				,	coalesce(z.cst, '00') as codigo_situacao_tributaria 

			,		cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as cod_ncm 
			,		cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest

		FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
		INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
		LEFT JOIN 	TBPRODUTOBLUESOFT_TRIBUTACAO 		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
													AND 	TR.OP_CDOPERACAO = 2 
													AND		TR.PRBT_REGRAFISCAL_VERSAO = 99999

		LEFT JOIN 	tbzanthustabtributacao_cod_tributacao	Z ON Z.prbt_icms_saida_cst = TR.prbt_icms_saida_cst 
															and  Z.prbt_icms_aliquota_interna = TR.prbt_icms_aliquota_interna 
															and  Z.prbt_icms_reducao = TR.prbt_icms_reducao 

		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'false'
		
		UNION 		----<<<<<<<<<<<<<<<<<<<<<<<<<<<< UNION <<<<<<<<<<<<<<<<<<<<<<
		
		SELECT 	 	coalesce(GTX.pr_cdproduto,0)
				,	coalesce(GTX.prb_cdprodutobluesoft,0)
				,	gt.prbg_cdbarra_pk
				,	TR.prbt_icms_saida_cst
				,	TR.prbt_icms_aliquota_interna
				,	TR.prbt_icms_reducao
				,	TR.prbt_pis_saida_cst 						
				,	TR.prbt_pis_saida_aliquota					
				,	TR.prbt_cofins_saida_cst 					
				,	TR.prbt_cofins_saida_aliquota			
				,	repeat('0', 17 - length(cast(gt.prbg_cdbarra_pk as varchar(17)))) || cast(gt.prbg_cdbarra_pk as varchar(17))
								AS COD_MERCADORIA 
				,	Coalesce(Z.cod_tributacao_pdv, 0 ) AS cod_tributacao_mercadoria
				,	coalesce(z.aliquota, 7) as ALIQUOTA_ICMS
				,	coalesce(z.perc_reducao,0) as PERCENTUAL_REDUZ_B_CALCULO
				,	coalesce(z.cst, '00') as codigo_situacao_tributaria 
			,		cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as cod_ncm 
			,		cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest
		FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
		INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
		LEFT JOIN 	TBPRODUTOBLUESOFT_TRIBUTACAO 		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
													AND 	TR.OP_CDOPERACAO = 2 
													AND		TR.PRBT_REGRAFISCAL_VERSAO = 99999

		LEFT JOIN 	tbzanthustabtributacao_cod_tributacao	Z ON Z.prbt_icms_saida_cst = TR.prbt_icms_saida_cst 
															and  Z.prbt_icms_aliquota_interna = TR.prbt_icms_aliquota_interna 
															and  Z.prbt_icms_reducao = TR.prbt_icms_reducao 

		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'true'

	;

	

	/*
	SELECT * FROM TbZanthusTabTributacao WHERE PRB_CDPRODUTOBLUESOFT = 0
	SELECT * FROM TbZanthustab_produto_decomposicao_insum where cod_insumo = '00000000000100809'
	SELECT * FROM TbZanthusTabTributacao WHERE cod_mercadoria = '00000000000012173'
	"00000000000012173"
	*/

	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Regra ICMS', vuuid_start)
	;

	drop table if exists tmpintegracao_produto_8510
	;
	
	create TEMPORARY table tmpintegracao_produto_8510
		(
				integracao_produto_seq int
			,	pr_cdproduto int
			,	prb_cdprodutobluesoftunitario int
			,	prb_cdprodutobluesoft int 
			,	integracao_tipo_cd int
			,	integracao_status_cd int
		)
	;

	INSERT INTO tmpintegracao_produto_8510 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)

	SELECT		XXX.pr_cdproduto 
			,	XXX.prb_cdprodutobluesoft -- unitario 
			,	XXX.prb_cdprodutobluesoft 
			,	20008501
			,	2				

	FROM (
					SELECT 			pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
		
					FROM TbZanthusTabTributacao X
					inner join      tbproduto              	pr on pr.pr_cdproduto = x.pr_cdproduto 
					  WHERE NOT EXISTS ( 	SELECT 1 
											FROM 	TbZanthusTab_Regra_Icms A 
											WHERE 	A.cod_mercadoria = x.cod_mercadoria 
				
										 )
						AND   X.PR_CDPRODUTO != 0 
						AND   X.PRB_CDPRODUTOBLUESOFT != 0 						 
				UNION 
					SELECT 			pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
			
					from 			TbZanthusTabTributacao 		a
					inner join      TbZanthusTab_Regra_Icms 	x on  x.cod_mercadoria = x.cod_mercadoria 
					inner join      tbproduto              	pr on pr.pr_cdproduto = a.pr_cdproduto 
						WHERE  A.cod_mercadoria = x.cod_mercadoria 
						  AND  x.flg_tipo_imposto = 0
						  and (	    COD_NCM_INI  != a.COD_NCM
								or  COD_NCM_FIM  != a.COD_NCM
								or  ALIQUOTA     != a.aliquota_icms
								or  CST          != cast(CAST(COD_SITUACAO_TRIBUTARIA AS INT) as varchar(3))
								or  PERC_REDUCAO != a.PERCENTUAL_REDUZ_B_CALCULO
							  )
			
				UNION 
					SELECT 			pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
		
					from 			TbZanthusTabTributacao 		a
					inner join      TbZanthusTab_Regra_Icms 	x on  x.cod_mercadoria = x.cod_mercadoria 
					inner join      tbproduto              	pr on pr.pr_cdproduto = a.pr_cdproduto
					WHERE  A.cod_mercadoria = x.cod_mercadoria 
					  AND  x.flg_tipo_imposto = 1
					  and (	    COD_NCM_INI  != a.COD_NCM
							or  COD_NCM_FIM  != a.COD_NCM
							or  ALIQUOTA     != a.prbt_pis_saida_aliquota
							or  CST          != cast(cast(prbt_pis_saida_cst	as int)	as varchar(3))
						  )
			
				UNION 
			
						SELECT 		pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
				
					from 			TbZanthusTabTributacao 		a
					inner join      TbZanthusTab_Regra_Icms 	x on  x.cod_mercadoria = x.cod_mercadoria 
					inner join      tbproduto              	pr on pr.pr_cdproduto = a.pr_cdproduto
					WHERE  A.cod_mercadoria = x.cod_mercadoria 
					  AND  x.flg_tipo_imposto = 2
					  and (	    COD_NCM_INI  != a.COD_NCM
							or  COD_NCM_FIM  != a.COD_NCM
							or  ALIQUOTA     != a.prbt_cofins_saida_aliquota
							or  CST          != cast(cast(prbt_COFINS_saida_cst	as int)	as varchar(3))
						  )
			) XXX 

	GROUP BY 		XXX.pr_cdproduto 
				,	XXX.prb_cdprodutobluesoft -- unitario 
				,	XXX.prb_cdprodutobluesoft 

	-->> Inserimos os produtos da tabela temporária na tabela de integracao_produto	
	---------------------------------------------------------------------------------
	;
	INSERT INTO tbintegracao_produto 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)
	SELECT 		pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	pr.prb_cdprodutobluesoft 
			,	20008501
			,	2
	from 		tmpintegracao_produto_8510 pr
	where		1 = 1
	  and       not exists ( 	select 1 
								from   tbintegracao_produto x
								where  x.pr_cdproduto = pr.pr_cdproduto 
								  and  x.prb_cdprodutobluesoftunitario  = pr.prb_cdprodutobluesoft 
								  and  x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 		
								  and  x.integracao_tipo_cd = 20008501
						   )
	group by    pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 

	;

		-->> Atualizamos a tabela temporaria com os sequenciais gerados
		---------------------------------------------------------------------------------
	update tmpintegracao_produto_8510 tmp 
	   set integracao_produto_seq = x.integracao_produto_seq
	from   tbintegracao_produto  x
	where  x.pr_cdproduto = tmp.pr_cdproduto
	  and  x.prb_cdprodutobluesoftunitario = tmp.prb_cdprodutobluesoftunitario		
	  and  x.prb_cdprodutobluesoft = tmp.prb_cdprodutobluesoft
	  and  x.integracao_tipo_cd = 20008501
		
	;

		-->> Vamos inserir na tabela de lancamento de integracao o log destes registros
		---------------------------------------------------------------------------------

	insert into tbintegracao_lancamento
	(
		--	dtlog_insert 					
		--,	integracao_lancamento_seq 		
			integracao_tipo_cd 				
		,	integracao_produto_seq 			
		,	integracao_descricao 			
		,	sis_log_seq
	)
	select  2000
		,	x.integracao_produto_seq
		,	'F0085_10_zant_proc'
		,	(select sis_log_seq from tbsistema_log where uuid = vuuid_start)
	from 	tmpintegracao_produto_8510 x
	where   1 = 1
	and		( 
		
				not exists (	select 	1 
								from 	tbintegracao_produto a
								where 	a.integracao_produto_seq = x.integracao_produto_seq 
								  and   a.integracao_status_cd = 2
					  		 
						   )
				and 
					not exists ( select 1 from tbintegracao_lancamento b where b.integracao_produto_seq = x.integracao_produto_seq)
			)
	;
	
	
	
		-->> Atualizamos o status dos produtos que ja existiam na tabela 
		---------------------------------------------------------------------------------
	UPDATE 	tbintegracao_produto XX
	  SET   integracao_status_cd = 2
	  	,	dtlog_update = current_timestamp 
	FROM tmpintegracao_produto_8510	  AA 
	WHERE XX.integracao_produto_seq = AA.integracao_produto_seq
	
	;	

	DROP TABLE IF EXISTS tmpintegracao_produto_8510
	;

	insert into tbsistema_log(proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
	values (0, 21, 'PROC', 'ProdutoBluesoft Processamento Versão: 1012007 _ Fim', vuuid_start)
	;

	UPDATE      TbZanthusTab_Regra_Icms
		SET		DTA_VAL_INICIAL = CAST(CURRENT_DATE AS DATE)	
		,		DTA_VAL_FINAL	= CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)

	;
	
	
	INSERT INTO TbZanthusTab_Regra_Icms
		(
				pr_cdproduto								
			,	prb_cdprodutobluesoft 						
			,	preg_cdbarra								
			,	cod_mercadoria 	
			--,	COD_REGRA_ICMS
			,	DESCRICAO 
			,	PRIORIDADE
			,	FLG_REGISTRO
			,	COD_NCM_INI 
			,	COD_NCM_FIM 
			,	UF_ORIGEM
			,	UF_DESTINO 		
			,	ALIQUOTA 
			,	CST 
			,	PERC_SUBSTITUICAO 
			,	PERC_REDUCAO 
			,	FLG_TIPO_IMPOSTO
			,	FLG_REVENDA
			,	DTA_VAL_INICIAL 
			,	DTA_VAL_FINAL 
			,	CST_ORIG
			,	USUARIO 
			,	DATA_CADASTRO 
			,	DATA_ULTIMA_ALTERACAO 
			,	ALIQUOTA_INTERESTADUAL
			,	VALOR_IMPOSTO
			,	TIPO_LISTA_ST 
			,	PERC_REDUCAO_ST 
			,	PERC_DIFERIMENTO 
			,	EXIGIBILIDADE_ISS
			,	FLG_INCENTIVO_FISCAL_ISS
			,	TIPO_DOCUMENTO
			,	COD_LOJA 

		)

	SELECT pr_cdproduto								
			,	prb_cdprodutobluesoft 						
			,	preg_cdbarra								
			,	cod_mercadoria 	
			--,	COD_REGRA_ICMS
			,	DESCRICAO 
			,	PRIORIDADE
			,	FLG_REGISTRO
			,	COD_NCM_INI 
			,	COD_NCM_FIM 
			,	UF_ORIGEM
			,	UF_DESTINO 		
			,	ALIQUOTA 
			,	CST 
			,	PERC_SUBSTITUICAO 
			,	PERC_REDUCAO 
			,	FLG_TIPO_IMPOSTO
			,	FLG_REVENDA
			,	DTA_VAL_INICIAL 
			,	DTA_VAL_FINAL 
			,	CST_ORIG
			,	USUARIO 
			,	DATA_CADASTRO 
			,	DATA_ULTIMA_ALTERACAO 
			,	ALIQUOTA_INTERESTADUAL
			,	VALOR_IMPOSTO
			,	TIPO_LISTA_ST 
			,	PERC_REDUCAO_ST 
			,	PERC_DIFERIMENTO 
			,	EXIGIBILIDADE_ISS
			,	FLG_INCENTIVO_FISCAL_ISS
			,	TIPO_DOCUMENTO
			,	COD_LOJA 
	FROM 	(		
				select 		COALESCE(pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(preg_cdbarra,'0')					AS preg_cdbarra
						,	COALESCE(cod_mercadoria,'0')				AS COD_MERCADORIA 
						--,	100000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'ICM_' || right(cod_mercadoria,21)			AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	COD_NCM 									AS COD_NCM_INI 
						,	COD_NCM 									AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	cast( coalesce(Aliquota_icms,7) as numeric(13,2))					AS ALIQUOTA
						,	cast(CAST(COD_SITUACAO_TRIBUTARIA AS INT) as varchar(3))		AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	PERCENTUAL_REDUZ_B_CALCULO					AS PERC_REDUCAO 
						,	CAST(0 AS INT)								AS FLG_TIPO_IMPOSTO 
						,	CAST('N' AS CHAR(1))						AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)								AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)		AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))						AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))				AS USUARIO 
						,	CURRENT_TIMESTAMP								AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP								AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 					AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 					AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)								AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 						AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 						AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 								AS COD_LOJA 		

				from 	TbZanthusTabTributacao

						----------------------------
						union 
						----------------------------

				select 		COALESCE(pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(preg_cdbarra,'0')					AS preg_cdbarra
						,	COALESCE(cod_mercadoria,'0')				AS COD_MERCADORIA 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'PIS_' || right(cod_mercadoria,21)			AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	COD_NCM 									AS COD_NCM_INI 
						,	COD_NCM 									AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	prbt_pis_saida_aliquota 					AS ALIQUOTA
						,	cast(cast(prbt_pis_saida_cst	as int)	as varchar(3))			AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	CAST(1 AS INT)								AS FLG_TIPO_IMPOSTO 
						,	CAST('N' AS CHAR(1))						AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)								AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)		AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))						AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))				AS USUARIO 
						,	CURRENT_TIMESTAMP								AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP								AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 					AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 					AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)								AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 						AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 						AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 								AS COD_LOJA 		
				from 	TbZanthusTabTributacao

						----------------------------
						union 
						----------------------------

				select 		COALESCE(pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(preg_cdbarra,'0')					AS preg_cdbarra
						,	COALESCE(cod_mercadoria,'0')				AS COD_MERCADORIA 
						--,	300000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'COF_' || right(cod_mercadoria,21)			AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	COD_NCM 									AS COD_NCM_INI 
						,	COD_NCM 									AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	prbt_COFINS_saida_aliquota 					AS ALIQUOTA
						,	cast(cast(prbt_COFINS_saida_cst	as int)	as varchar(3))			AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	CAST(2 AS INT)								AS FLG_TIPO_IMPOSTO 
						,	CAST('N' AS CHAR(1))						AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)								AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)		AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))						AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))				AS USUARIO 
						,	CURRENT_TIMESTAMP							AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP							AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 					AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 					AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))					AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)								AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 						AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 						AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 								AS COD_LOJA 		
				from 	TbZanthusTabTributacao
	) AS X
	WHERE 	(			prb_cdprodutobluesoft <> 0 
			 		or  cod_mercadoria in (select cod_insumo from  TbZanthustab_produto_decomposicao_insum)
			 )
			
	  AND NOT EXISTS ( 	SELECT 1 
						FROM 	TbZanthusTab_Regra_Icms A 
						WHERE 	A.cod_mercadoria = x.cod_mercadoria 
						 AND    A.flg_tipo_imposto = x.flg_tipo_imposto

					 )
	;

	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = a.COD_NCM
		,  COD_NCM_FIM = a.COD_NCM
		,  ALIQUOTA    = a.aliquota_icms
		,  CST         = cast(CAST(COD_SITUACAO_TRIBUTARIA AS INT) as varchar(3))
		,  PERC_REDUCAO = a.PERCENTUAL_REDUZ_B_CALCULO
		,  dtlog_update = current_timestamp 
	FROM   TbZanthusTabTributacao a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 0
	  and (	    COD_NCM_INI  != a.COD_NCM
			or  COD_NCM_FIM  != a.COD_NCM
			or  ALIQUOTA     != a.aliquota_icms
			or  CST          != cast(CAST(COD_SITUACAO_TRIBUTARIA AS INT) as varchar(3))
			or  PERC_REDUCAO != a.PERCENTUAL_REDUZ_B_CALCULO
		  )
	;
	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = a.COD_NCM
		,  COD_NCM_FIM = a.COD_NCM
		,  ALIQUOTA    = a.prbt_pis_saida_aliquota
		,  CST         = cast(cast(prbt_pis_saida_cst	as int)	as varchar(3))
		,  PERC_REDUCAO = 0
		,  dtlog_update = current_timestamp 
	FROM   TbZanthusTabTributacao a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 1
	  and (	    COD_NCM_INI  != a.COD_NCM
			or  COD_NCM_FIM  != a.COD_NCM
			or  ALIQUOTA     != a.prbt_pis_saida_aliquota
			or  CST          != cast(cast(prbt_pis_saida_cst	as int)	as varchar(3))
		  )
	;
	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = a.COD_NCM
		,  COD_NCM_FIM = a.COD_NCM
		,  ALIQUOTA    = a.prbt_cofins_saida_aliquota
		,  CST         = cast(cast(prbt_COFINS_saida_cst	as int)	as varchar(3))
		,  PERC_REDUCAO = 0
		,  dtlog_update = current_timestamp 
	FROM   TbZanthusTabTributacao a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 2
	  and (	    COD_NCM_INI  != a.COD_NCM
			or  COD_NCM_FIM  != a.COD_NCM
			or  ALIQUOTA     != a.prbt_cofins_saida_aliquota
			or  CST          != cast(cast(prbt_COFINS_saida_cst	as int)	as varchar(3))
		  )
	;

	
	
	-------------------------------------------------------------------------------------------------------------------------
	/* MERCADORIA  */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------	
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Mercadoria', vuuid_start)
	;
	
	DELETE FROM TbZanthusTab_Mercadoria;	
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
				,	COD_TRIBUTACAO_MERCADORIA
				,	COD_TECLA
				,	PERCENTUAL_DESC_VENDA
				,	PERMISSAO_VENDA
				,	PERCENTUAL_REDUZ_B_CALCULO
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
				,	ALIQUOTA_ICMS	
				,	QUANTIDADE_BONUS_VENDA	
				,	QUANTIDADE_MAX_PRECO_PROMO		
				,	VALOR_TOTAL_PRECO_PROMOCAO		
				,	CUSTO_CONTABIL					
				,	QUANTIDADE_MAXIMA_VENDA			
				,	MULTIPLICA_PONTOS_VALOR_LIQ		
				,	QUANTIDADE_PONTOS_VENDA	
				,	COD_NCM 
				,	CEST
				,	COD_SITUACAO_TRIBUTARIA
				,	DATA_CADASTRO 
				,	DATA_ULTIMA_ALTERACAO 
				,	cfop
				,	cod_sit_trib_pis
				,	aliquota_pis
				,	cod_sit_trib_cofins
				,	aliquota_cofins

				
					)
	select 		em.pr_cdproduto												as pr_cdproduto
			,	em.prb_cdprodutobluesoft									as prb_cdprodutobluesoft
			,	gt.preg_cdbarra												as preg_cdbarra
			,	1															as cod_loja
			,	'000'														as controle 
			,	repeat('0', 17 - length(cast(gt.preg_cdbarra as varchar(17)))) || cast(gt.preg_cdbarra as varchar(17))		as cod_mercadoria 
			,	left(pb.prb_descricao_cupom,50)									as descricao 
			,	left(pb.prb_descricao_cupom,25)								as desc_abr
			,	cast(1 as int ) 											as cod_departamento 
			,	COALESCE(XX.cod_tributacao_mercadoria,8)					as cod_tributacao_mercadoria
			,	CAST( 0 AS INT ) 											AS COD_TECLA							
			,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
			,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA
			,	COALESCE(XX.PERCENTUAL_REDUZ_B_CALCULO,0)					AS PERCENTUAL_REDUZ_B_CALCULO
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
			,   cast( coalesce(xx.Aliquota_icms,0.18) as numeric(13,2))		as ALIQUOTA_ICMS	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
			,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
			,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
			,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
			, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
			,	COALESCE(XX.COD_NCM,0)										AS COD_NCM 
			,	COALESCE(XX.CEST, 0)										AS CEST 
			,	xx.COD_SITUACAO_TRIBUTARIA									as COD_SITUACAO_TRIBUTARIA 
			,	current_Date												as data_Cadastro
			,	current_Date												as data_ultima_alteracao 
			,	5102
			,	xx.prbt_pis_saida_cst
			,	xx.prbt_pis_saida_aliquota 
			,	xx.prbt_cofins_saida_cst 
			,	xx.prbt_cofins_saida_aliquota 
	from 		tbprodutoembalagem_gtins		gt
	inner join  tbprodutoembalagem				em on em.prb_cdprodutobluesoft = gt.prb_cdprodutobluesoft 
	inner join  tbproduto						pr on pr.pr_cdproduto = em.pr_cdproduto
	inner join  tbprodutobluesoft				pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft 
	INNER JOIN  TbZanthusTabTributacao			XX ON XX.preg_cdbarra = gt.preg_cdbarra
	where		1 = 1
	and			pr.pr_status = 'true'
	and			em.pre_status = 'true'
	--14/04/2022 -------------------------------------------------------------------------------------------	
	AND	(		pb.prb_cdprodutobluesoftunitario in ( select 		PR.PRB_CDPRODUTOBLUESOFT 
														from 		TBPRECO_APLICACAO	PX
														INNER JOIN 	TBPRODUTO			PR ON PR.PR_CDPRODUTO = PX.PR_CDPRODUTO 
														GROUP BY 	PR.PRB_CDPRODUTOBLUESOFT )
		)
	AND gt.preg_cdbarra NOT IN ( SELECT PREG_CDBARRA_INSUMO FROM TbZanthustab_produto_decomposicao_insum)
			-- NÃO INSERIR NESTE MOMENTO AS MERCADORIAS QUE SÃO INSUMOS DE CESTA BASICA
			-- ESTES ITENS SERÃO INSERIDOS A PARTE NO SCRIPT LOGO ABAIXO
	;

	/* 	INSERINDO ITENS DE CESTA 
		
		
		23/09/2025 	PROBLEMA COM DUPLICIDADE DE ITENS (O MESMO ITEM DENTRO DE DUAS CESTAS)
			
			1) Problema: A Arquitetura desenvolvida para a tabela tbzanthustab_mercadoria contempla o codigo interno e o codigo bluesoft e isso acaba trazendo um problema pois,
			o mesmo codigo de barra pode estar dentro da tabela porém com codigos pais diferente. 

			2) Correção: Implementamos uma solução que será inserido o codigo de barra porém com o cd_produto (menor) a partir de um group by 
	
	
	*/

		
	
	
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
				,	COD_TRIBUTACAO_MERCADORIA
				,	COD_TECLA
				,	PERCENTUAL_DESC_VENDA
				,	PERMISSAO_VENDA
				,	PERCENTUAL_REDUZ_B_CALCULO
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
				,	ALIQUOTA_ICMS	
				,	QUANTIDADE_BONUS_VENDA	
				,	QUANTIDADE_MAX_PRECO_PROMO		
				,	VALOR_TOTAL_PRECO_PROMOCAO		
				,	CUSTO_CONTABIL					
				,	QUANTIDADE_MAXIMA_VENDA			
				,	MULTIPLICA_PONTOS_VALOR_LIQ		
				,	QUANTIDADE_PONTOS_VENDA	
				,	COD_NCM 
				,	CEST
				,	COD_SITUACAO_TRIBUTARIA
				,	DATA_CADASTRO 
				,	DATA_ULTIMA_ALTERACAO 
				,	cfop
				,	cod_sit_trib_pis
				,	aliquota_pis
				,	cod_sit_trib_cofins
				,	aliquota_cofins				
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
			,	COALESCE(XX.cod_tributacao_mercadoria,8)					as cod_tributacao_mercadoria
			,	CAST( 0 AS INT ) 											AS COD_TECLA							
			,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
			,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA
			,	COALESCE(XX.PERCENTUAL_REDUZ_B_CALCULO,0)					AS PERCENTUAL_REDUZ_B_CALCULO
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
			,   cast( coalesce(xx.Aliquota_icms,0.18) as numeric(13,2))		as ALIQUOTA_ICMS	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
			,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
			,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
			,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
			,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
			, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
			,	COALESCE(XX.COD_NCM,0)										AS COD_NCM 
			,	COALESCE(XX.CEST, 0)										AS CEST 
			,	xx.COD_SITUACAO_TRIBUTARIA									as COD_SITUACAO_TRIBUTARIA 
			,	current_Date												as data_Cadastro
			,	current_Date												as data_ultima_alteracao 
			,	5102
			,	xx.prbt_pis_saida_cst
			,	xx.prbt_pis_saida_aliquota 
			,	xx.prbt_cofins_saida_cst 
			,	xx.prbt_cofins_saida_aliquota 			
	from 		TbZanthustab_produto_decomposicao_insum im
	inner join  TbZanthustab_produto_decomposicao 		dc on dc.pr_cdproduto = im.pr_cdproduto 
	inner join  tbproduto								pr on pr.pr_cdproduto = im.pr_cdproduto
	inner join  tbprodutobluesoft						pb on pb.prb_cdprodutobluesoft_pk = im.prb_cdprodutobluesoft 
	INNER JOIN  TbZanthusTabTributacao					xx on xx.preg_cdbarra  =  im.preg_cdbarra_insumo
	INNER JOIN  ( 	SELECT 
									im.cod_insumo							as cod_mercadoria 
								,	 min(im.pr_cdproduto	)				as pr_cdproduto 
						from 		TbZanthustab_produto_decomposicao_insum im
						inner join  TbZanthustab_produto_decomposicao 		dc on dc.pr_cdproduto = im.pr_cdproduto 
						inner join  tbproduto								pr on pr.pr_cdproduto = im.pr_cdproduto
						inner join  tbprodutobluesoft						pb on pb.prb_cdprodutobluesoft_pk = im.prb_cdprodutobluesoft 
						INNER JOIN  TbZanthusTabTributacao					xx on xx.preg_cdbarra  =  im.preg_cdbarra_insumo
						
						where		1 = 1
						and			pr.pr_status = 'true'
						--and 		im.cod_insumo = '00000000000101168'
						group by 	im.cod_insumo
				) DUP_INSUM_PROD ON DUP_INSUM_PROD.COD_MERCADORIA = im.cod_insumo AND DUP_INSUM_PROD.pr_cdproduto = im.pr_cdproduto	 

	
	where		1 = 1
	and			pr.pr_status = 'true'
	and			im.cod_insumo	not in (select cod_mercadoria from TbZanthusTab_Mercadoria )
	--and 		im.cod_insumo != '00000000000101168'
	order by pr_cdproduto, im.prb_cdprodutobluesoft, im.cod_insumo 

	;

	/* desenvolvimrnto 

	SELECT 
				
				im.cod_insumo							as cod_mercadoria 
			,	 min(im.pr_cdproduto	)				as pr_cdproduto 
	from 		TbZanthustab_produto_decomposicao_insum im
	inner join  TbZanthustab_produto_decomposicao 		dc on dc.pr_cdproduto = im.pr_cdproduto 
	inner join  tbproduto								pr on pr.pr_cdproduto = im.pr_cdproduto
	inner join  tbprodutobluesoft						pb on pb.prb_cdprodutobluesoft_pk = im.prb_cdprodutobluesoft 
	INNER JOIN  TbZanthusTabTributacao					xx on xx.preg_cdbarra  =  im.preg_cdbarra_insumo
	
	where		1 = 1
	and			pr.pr_status = 'true'
	and			im.cod_insumo	not in (select cod_mercadoria from TbZanthusTab_Mercadoria )
	--and 		im.cod_insumo = '00000000000101168'
	group by 	im.cod_insumo

	*/

	--------------- EXCLUIMOS OS REGISTROS QUE NÃO TEM REFERENCIA COM O PAG 09/12/2024
					-->>  TbZanthusTab_Mercadoria WHERE PR_CDPRODUTO = 0

		/*
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
							,	COD_TRIBUTACAO_MERCADORIA
							,	COD_TECLA
							,	PERCENTUAL_DESC_VENDA
							,	PERMISSAO_VENDA
							,	PERCENTUAL_REDUZ_B_CALCULO
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
							,	ALIQUOTA_ICMS	
							,	QUANTIDADE_BONUS_VENDA	
							,	QUANTIDADE_MAX_PRECO_PROMO		
							,	VALOR_TOTAL_PRECO_PROMOCAO		
							,	CUSTO_CONTABIL					
							,	QUANTIDADE_MAXIMA_VENDA			
							,	MULTIPLICA_PONTOS_VALOR_LIQ		
							,	QUANTIDADE_PONTOS_VENDA	
							,	COD_NCM 
							,	CEST 
							,	COD_SITUACAO_TRIBUTARIA
							,	DATA_CADASTRO 
							,	DATA_ULTIMA_ALTERACAO 
								)

				select 		0															as pr_cdproduto
						,	pb.prb_cdprodutobluesoft_pk									as prb_cdprodutobluesoft
						,	PB.PRB_CDBARRA_PRINCIPAL											as preg_cdbarra
						,	1															as cod_loja
						,	'000'														as controle 
						,	repeat('0', 17 - length(cast(PB.PRB_CDBARRA_PRINCIPAL as varchar(17)))) || cast(PB.PRB_CDBARRA_PRINCIPAL as varchar(17))		as cod_mercadoria 
						,	left(pb.prb_descricao_cupom,50)									as descricao 
						,	left(pb.prb_descricao_cupom,25)								as desc_abr
						,	cast(1 as int ) 											as cod_departamento 
						,	COALESCE(XX.cod_tributacao_mercadoria,8)					as cod_tributacao_mercadoria
						,	CAST( 0 AS INT ) 											AS COD_TECLA							
						,	CAST( 0 AS INT )											AS PERCENTUAL_DESC_VENDA							
						,	CAST( '0' AS CHAR(1)) 										AS PERMISSAO_VENDA
						,	COALESCE(XX.PERCENTUAL_REDUZ_B_CALCULO,0)					AS PERCENTUAL_REDUZ_B_CALCULO
						,	CASE PB.PRB_EMBALAGEMESTOQUE WHEN 'KG' THEN '1' ELSE '0' END as INDICA_MERC_PESO_VARIAVEL
						,	cast(0 as numeric(13,2) ) 									as CUSTO_UNITARIO
						,	cast(0 as int)                                              as GRUPO_GARANTIA	
						,	cast(0 as int)    											as FATOR_SEGURANCA_VENDA_ESTOQUE
						,	PB.PRB_EMBALAGEMESTOQUE									    as UNIDADE_VENDA		
						,	cast(null as date )											as DATA_MODO_PRECO		
						,	cast(0 as numeric(13,2)) 									as MARGEM_MERCADORIA	
						,	cast(1 as numeric(17,4))								    as QUANTIDADE_EMBALAGEM		
						,	cast('' as varchar(16))										as COD_FORNECEDOR
						,	cast(0 as numeric(13,2)) 									as CUSTO_MOEDA_ESTAVEL
						,   cast( coalesce(xx.Aliquota_icms,7) as numeric(13,2))		as ALIQUOTA_ICMS	
						,	cast(0 as numeric(13,2)) 									as QUANTIDADE_BONUS_VENDA	
						,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAX_PRECO_PROMO		
						,	cast(0 as numeric(13,2)) 									as VALOR_TOTAL_PRECO_PROMOCAO		
						,	cast(0 as numeric(13,2)) 									as CUSTO_CONTABIL					
						,	cast(0 as numeric(13,2)) 									as QUANTIDADE_MAXIMA_VENDA			
						,	cast(0 as numeric(13,2)) 									as MULTIPLICA_PONTOS_VALOR_LIQ	
						, 	cast(0 as numeric(13,2))                                    as QUANTIDADE_PONTOS_VENDA
						,	COALESCE(XX.COD_NCM,0)										AS COD_NCM 
						,	COALESCE(XX.CEST, 0)										AS CEST 
						,	xx.COD_SITUACAO_TRIBUTARIA									as COD_SITUACAO_TRIBUTARIA 
						,	current_Date												as data_Cadastro
						,	current_Date												as data_ultima_alteracao 
			FROM 		(SELECT PRB_CDPRODUTOBLUESOFT AS PRB_CDPRODUTOBLUESOFT FROM  tbproduto_composicao GROUP BY PRB_CDPRODUTOBLUESOFT)	CP
			INNER JOIN  TBPRODUTOBLUESOFT	 	PB ON PB.PRB_CDPRODUTOBLUESOFT_PK = CP.PRB_CDPRODUTOBLUESOFT 
			LEFT  JOIN  TbZanthusTabTributacao	XX ON XX.preg_cdbarra = PB.PRB_CDBARRA_PRINCIPAL
			WHERE		1 = 1
			AND			repeat('0', 17 - length(cast(PB.PRB_CDBARRA_PRINCIPAL as varchar(17)))) || cast(PB.PRB_CDBARRA_PRINCIPAL as varchar(17)) NOT IN ( SELECT COD_MERCADORIA FROM TbZanthusTab_Mercadoria )
			--and			pb.prb_status = 'true'
			ORDER BY 6 ASC

			;
		*/

	-------------------------------------------------------------------------------------------------------------------------
	/* TMP_ZANTHUS_PRECO  */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Precos', vuuid_start)
	;
	

	DROP TABLE IF EXISTS TMP_ZANTHUS_PRODUTO_PRECO;
	CREATE TEMP TABLE IF NOT EXISTS TMP_ZANTHUS_PRODUTO_PRECO 
		(
				TAB_PRE_CD							INT
			,	PR_CDPRODUTO 						INT
			,	PRB_CDPRODUTOBLUESOFT_UNITARIO		INT
			,	PR_EMBALAGEMESTOQUE 				CHAR(2)
			,	PRC_VALOR_EMBALAGEMESTOQUE 			NUMERIC(13,2)
			,	PRB_CDPRODUTOBLUESOFT 				INT
			,	PRE_EMBALAGEM 						CHAR(2)
			,	PRE_FATORESTOQUE 					NUMERIC(17,4)
			,	PRC_VALOR							NUMERIC(13,2)
			,	PRC_QTDE_PROMOCIONAL 				NUMERIC(17,4)
			,	PRC_VALOR_PROMOCIONAL 				NUMERIC(13,2)
			,	CONSTRAINT pkTMP_ZANTHUS_PRODUTO_PRECO primary  key (PR_CDPRODUTO,PRB_CDPRODUTOBLUESOFT, TAB_PRE_CD )
		);

	DELETE FROM TMP_ZANTHUS_PRODUTO_PRECO;

	INSERT INTO TMP_ZANTHUS_PRODUTO_PRECO 
	(			TAB_PRE_CD
			,	PR_CDPRODUTO 
			,	PRB_CDPRODUTOBLUESOFT_UNITARIO
			,	PR_EMBALAGEMESTOQUE 
			,	PRC_VALOR_EMBALAGEMESTOQUE 
			,	PRB_CDPRODUTOBLUESOFT 
			,	PRE_EMBALAGEM 
			,	PRE_FATORESTOQUE 
			,	PRC_VALOR
			,	PRC_QTDE_PROMOCIONAL 
			,	PRC_VALOR_PROMOCIONAL

	)
		/******** PRODUTOS UN - UNITARIOS **********/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'UN'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO = PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 --14/04/2022 
		UNION 
		/******** PRODUTOS UN - OUTRAS EMBALAGENS CX/BD **********/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	CAST(CASE WHEN COALESCE(PRC_VALOR_PROMOCIONAL,0) < PRC_VALOR AND PRC_VALOR_PROMOCIONAL > 0 AND PRC_QTDE_PROMOCIONAL >= PRE_FATORESTOQUE and coalesce(PRE_FATORESTOQUE,0) > 1
							THEN  PRC_VALOR_PROMOCIONAL * PRE_FATORESTOQUE
							ELSE PRC_VALOR_EMBALAGEMESTOQUE * PRE_FATORESTOQUE
					END AS NUMERIC (13,2)) AS PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) 	AS  PRC_VALOR_PROMOCIONAL			
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'UN'
		  AND       PRC_VALOR_EMBALAGEMESTOQUE > 0 --14/04/2022 
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO <> PRB_CDPRODUTOBLUESOFT

		----------------------------------------------------------------------
		UNION 
		/*PRODUTOS KG - UNITARIO*/
		---------------------------------------------------------------------

		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'KG'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO = PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 -- 14/04/2022
		----------------------------------------------------------------------
		UNION 
		/*PRODUTOS KG - CORTES*/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'KG'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO <> PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 -- 14/04/2022
		;	

	-------------------------------------------------------------------------------------------------------------------------
	/* TAB_MERCADORIA_TIPO_VENDA  */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Tipo Venda', vuuid_start)
	;
	
	DELETE FROM TbZanthusTab_Mercadoria_Tipo_Venda;
	INSERT INTO TbZanthusTab_Mercadoria_Tipo_Venda
	(

						tab_pre_cd 
					,	pr_Cdproduto 
					,	prb_cdprodutobluesoft 
					,	preg_cdbarra
					,	cod_loja
					,	controle
					,	cod_mercadoria 
					,	cod_tipo_venda 
					,	usuario 
					,	data_cadastro 
					, 	data_ultima_alteracao 
					,	preco_unitario 
					, 	percentual_comissao_vendedor 
					,	preco_anterior 
			)

	SELECT 		PC.TAB_PRE_CD 
			,	pc.pr_cdproduto 
			,	pc.prb_cdprodutobluesoft 
			,	gt.preg_cdbarra 
			,	1
			,	'000'
			,	gt.cod_mercadoria 
			,	pc.tab_pre_cd 
			,	'ZANTHUS'
			,	current_date 
			,	null 
			,	pc.PRC_VALOR
			,	cast(0 as numeric(13,2))
			,	cast(0 as numeric(13,2))		
	FROM 		TbZanthusTab_Mercadoria			gt
	INNER JOIN 	TMP_ZANTHUS_PRODUTO_PRECO		pc
										on 		gt.prb_cdprodutobluesoft = pc.prb_cdprodutobluesoft 
										and		gt.pr_cdproduto = pc.pr_cdproduto 
	where 	1 = 1 
	AND 	pc.prb_cdprodutobluesoft NOT IN  (	SELECT PRB_CDPRODUTOBLUESOFT FROM TBPRODUTO_COMPOSICAO )
	---AND 	length(gt.preg_cdbarra) in (8, 13, 14, 6)
	;

	-------------------------------------------------------------------------------------------------------------------------
	/* TAB_MERCADORIA_TIPO_VENDA QTDE */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Tipo Venda Qtde', vuuid_start)
	;
	
	delete from TbZanthusTab_Mercadoria_Tipo_Venda_qtde ;

	INSERT INTO TbZanthusTab_Mercadoria_Tipo_Venda_qtde 
		(		tab_pre_cd									
			,	pr_cdproduto 								 
			,	prb_cdprodutobluesoft						
			,	preg_cdbarra								
			,	cod_loja									
			,	cod_mercadoria 								
			,	cod_tipo_venda								
			,	qtde_venda									
			,	flg_geral 									
			,	preco_unitario 								
			,	perc_desconto 								
			,	flg_ativo									
			,	dth_inclusao								
			,	dth_alteracao 								
			,	idt_usuario_alteracao 						
			)		

	SELECT 		PC.TAB_PRE_CD 						as TAB_PRE_CD
			,	pc.pr_cdproduto 					as pr_cdproduto
			,	pc.prb_cdprodutobluesoft 			as prb_cdprodutobluesoft
			,	gt.preg_cdbarra 					as preg_cdbarra
			, 	cast(1 as int)						as  cod_loja
			,	gt.cod_mercadoria 					as cod_mercadoria
			,	pc.tab_pre_cd 						as cod_tipo_venda
			,	pc.prc_qtde_promocional 			as qtde_venda 
			,	cast(0 as int) 						as flg_geral 
			,	cast( pc.prc_valor_promocional * pre_fatorestoque as numeric(13,2))		as preco_unitario 
			,	cast(0.00 as numeric(13,2)) 		as perce_desconto 
			,	cast('S' as char(1))				as flg_ativo 
			,	current_timestamp 					as dth_inclusao
			,	current_timestamp 					as dth_altercao 
			,	cast(100 as int) 					as idt_usuario_alteracao		

	FROM 		TbZanthusTab_Mercadoria			gt
	INNER JOIN 	TMP_ZANTHUS_PRODUTO_PRECO		pc
										on 		gt.prb_cdprodutobluesoft = pc.prb_cdprodutobluesoft 
										and		gt.pr_cdproduto = pc.pr_cdproduto 
	where 	1 = 1 
	and		prc_qtde_promocional > 0 
	and		prc_valor_promocional > 0 
	and		prc_qtde_promocional >= pre_fatorestoque 
	----AND 	length(gt.preg_cdbarra) in (8, 13, 14, 6)
	;

	-------------------------------------------------------------------------------------------------------------------------
	/* TODOS PROMOCIONAIS VAO FICAR COMO PENDENTES */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - PROMOCIONAL', vuuid_start)
	;
		
		-->> Criamos uma tabela temporária para inserir os produtos que tiveram alteracao 
		---------------------------------------------------------------------------------
	drop table if exists tmpintegracao_produto
	;		
	create TEMPORARY table tmpintegracao_produto
		(
				integracao_produto_seq int
			,	pr_cdproduto int
			,	prb_cdprodutobluesoftunitario int
			,	prb_cdprodutobluesoft int 
			,	integracao_tipo_cd int
			,	integracao_status_cd int
		)
	;
	
	INSERT INTO tmpintegracao_produto 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)
	
	select 		p.pr_cdproduto
			,	p.prb_cdprodutobluesoft
			,	p.prb_cdprodutobluesoft 
			,	20008501
			,	2
	from 		TbZanthusTab_Mercadoria_Tipo_Venda v
	inner join 	tbproduto p on p.pr_cdproduto = v.pr_cdproduto
	where 		v.cod_tipo_venda = 2 ---->>> PROMOCIONAIS COLOCAR COMO PENDENTES
	group by p.pr_cdproduto
			,	p.prb_cdprodutobluesoft
			,	p.prb_cdprodutobluesoft 

	;

	
		-->> Inserimos os produtos da tabela temporária na tabela de integracao_produto	
		---------------------------------------------------------------------------------
	INSERT INTO tbintegracao_produto 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)
	SELECT 		pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	pr.prb_cdprodutobluesoft 
			,	20008501
			,	2
	from 		tmpintegracao_produto pr
	where		1 = 1
	  and       not exists ( 	select 1 
								from   tbintegracao_produto x
								where  x.pr_cdproduto = pr.pr_cdproduto 
								  and  x.prb_cdprodutobluesoftunitario  = pr.prb_cdprodutobluesoft 
								  and  x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 		
								  and  x.integracao_tipo_cd = 20008501
						   )
	group by    pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 

	;

		-->> Atualizamos a tabela temporaria com os sequenciais gerados
		---------------------------------------------------------------------------------
	update tmpintegracao_produto tmp 
	   set integracao_produto_seq = x.integracao_produto_seq
	from   tbintegracao_produto  x
	where  x.pr_cdproduto = tmp.pr_cdproduto
	  and  x.prb_cdprodutobluesoftunitario = tmp.prb_cdprodutobluesoftunitario		
	  and  x.prb_cdprodutobluesoft = tmp.prb_cdprodutobluesoft
	  and  x.integracao_tipo_cd = 20008501
		
	;
	
	
		-->> Vamos inserir na tabela de lancamento de integracao o log destes registros
		---------------------------------------------------------------------------------

	insert into tbintegracao_lancamento
	(
		--	dtlog_insert 					
		--,	integracao_lancamento_seq 		
			integracao_tipo_cd 				
		,	integracao_produto_seq 			
		,	integracao_descricao 			
		,	sis_log_seq
	)
	select  2000
		,	x.integracao_produto_seq
		,	'F0085_10_CARGA(PRM)'
		,	(select sis_log_seq from tbsistema_log where uuid = vuuid_start)
	from 	tmpintegracao_produto x
	where   1 = 1
	;
	
	
	
		-->> Atualizamos o status dos produtos que ja existiam na tabela 
		---------------------------------------------------------------------------------
	UPDATE 	tbintegracao_produto XX
	  SET   	integracao_status_cd 	= 2
	  	,		dtlog_update 			= current_timestamp 
	FROM 	tmpintegracao_produto	  AA 
	WHERE 	XX.integracao_produto_seq = AA.integracao_produto_seq
	  AND   XX.integracao_tipo_cd = 20008501
	
	;	

	drop table if exists tmpintegracao_produto
	;

	vcod_voucher:= (SELECT TO_CHAR(current_date, 'YYYYMMDD'))
	;

	

	INSERT INTO tbzanthus_voucher_promocional
		(
				cod_voucher
			,	data_voucher 
			,	descricao 
			,	data_validade_inicial 
			,	data_validade_final 
		)	SELECT vcod_voucher
			,	   current_date 
			,	   'PROMOCAO DIA ' || vcod_voucher
			,		current_date 
			, 		current_date 
			WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_voucher_promocional WHERE cod_voucher = vcod_voucher)
	;

	

	 insert into tbzanthus_voucher_promocional_prod
	 	(
				cod_voucher 
			,	cod_produto 
			,	valor_aplicacao 
			,   qtd_maxima
		)

      select		
                       vcod_voucher                                                   as cod_voucher				 
                    ,	m.cod_mercadoria                                               as cod_produto				 
                    ,	cast(v1.preco_unitario - v2.preco_unitario as numeric(13,2))   as valor_aplicacao			 
					,	0
        from		TbZanthusTab_Mercadoria		m
        left join	TbZanthusTab_Mercadoria_Tipo_Venda	v1 on v1.cod_mercadoria = m.cod_mercadoria and v1.cod_tipo_venda = '1'
        left join   TbZanthusTab_Mercadoria_Tipo_Venda	v2 on v2.cod_mercadoria = m.cod_mercadoria and v2.cod_tipo_venda = '2'
        where		1 = 1
        and		    cast(v1.preco_unitario as numeric(13,2)) > cast(v2.preco_unitario as numeric(13,2))
	    and not exists ( select 1 
		                 from   tbzanthus_voucher_promocional_prod x
						 where   x.cod_voucher = vcod_voucher 
						   and   x.cod_produto = m.cod_mercadoria 
						 )
	
	;
end;
$BODY$;

ALTER FUNCTION public.f0085_10_1012014_zanthusprocessamento()
    OWNER TO postgres;

