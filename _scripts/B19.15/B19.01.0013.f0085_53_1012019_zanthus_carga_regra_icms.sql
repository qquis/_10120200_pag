CREATE OR REPLACE FUNCTION public.f0085_53_1012019_zanthus_carga_regra_icms(
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

	/*
	BRANCH 20.19 | M19.10.12 _ 26/09/2026, sábado 15h50m
	1) Ajuste das referencias dos updates que estavam gravemente erradas a,b
	

	*/

	vuuid_start:= 'F0085_53.1012019' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_53 - 2019', 'Zanthus/Carga (4) _ Tributacao', vuuid_start, vuuid_start)
	;



	UPDATE TbZanthusTab_Regra_Icms a
	  SET  pr_cdproduto = pr.pr_cdproduto

	from 		tbprodutobluesoft b
	inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = b.prb_cdprodutobluesoftunitario 
	where b.prb_cdprodutobluesoft_pk = a.prb_cdprodutobluesoft
	  and   	a.pr_cdproduto <> pr.pr_cdproduto
	;
	  

	



	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		ICMS




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
					,   codigo_beneficio_fiscal
				)
		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO 
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
					,   codigo_beneficio_fiscal 
			FROM 	(		
				select 		COALESCE(p.pr_cdproduto,0)									AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)							AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS COD_MERCADORIA 
						,	'ICM_' || right(cb.prbg_cdbarra_pk,21)		AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	cast( coalesce(icms_aliquota,7) as numeric(13,2))					AS ALIQUOTA
						,	lpad(cast(CAST(icms_cst AS INT) as varchar(3)), 3, '0')				AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))											AS PERC_SUBSTITUICAO 
						,	icms_reducao								AS PERC_REDUCAO 
						,	'0'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
						,   p.codigo_beneficio_fiscal                     as codigo_beneficio_fiscal 

				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true
			) A
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.COD_MERCADORIA
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
		;















	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		PIS

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
		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO 
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
				FROM (
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS COD_MERCADORIA 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'PIS_' || right(cb.prbg_cdbarra_pk,21)		AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	pis_aliquota 								AS ALIQUOTA
						,	lpad(cast(cast(pis_cst	as int)	as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	'1'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true												
				) a
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.cod_mercadoria
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
	
		; 
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		COFINS

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

		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO 
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
				FROM (
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS COD_MERCADORIA 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'COF_' || right(cb.prbg_cdbarra_pk,21)		AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	cofins_aliquota 								AS ALIQUOTA
						,	lpad(cast(cast(cofins_cst	as int)	as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	'2'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true												
				) a
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.cod_mercadoria
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
		; 

	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		IBS UF __ FLG_TIPO_IMPOSTO = 'A'


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
					,   cod_class_tributaria
					,   per_cred_presumido_ibs_mono
				)


		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO 
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
					,   cod_class_tributaria
					,   per_cred_presumido_ibs_mono

					
				FROM (
				select 		COALESCE(p.pr_cdproduto,0)									AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)							AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'IBSUF_' || right(cb.prbg_cdbarra_pk,21)						AS DESCRICAO 
						,	CAST(1 AS INT)												AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))										AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)										AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)										AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))										AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))										AS UF_DESTINO 
						,	per_aliquota_ibs_uf											AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))									AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_ibs_uf									AS PERC_REDUCAO 
						,	'A'															AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda												AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)									AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)			AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))										AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))								AS USUARIO 
						,	CURRENT_TIMESTAMP											AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP											AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 									AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 									AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    				AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))									AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))									AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)												AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 										AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 										AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 												AS COD_LOJA 		
						,	cod_class_tributaria_ibs_cbs								as cod_class_tributaria
						,	per_cred_presumido_ibs_mono 								as per_cred_presumido_ibs_mono
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true											
				) a
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.cod_mercadoria
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
		; 


-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		IBS UF MUNICIPAL __ FLG_TIPO_IMPOSTO = 'B'


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
					,   cod_class_tributaria
				)


		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO
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
					,   cod_class_tributaria

					
				FROM (
				select 		COALESCE(p.pr_cdproduto,0)										AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)								AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')								AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')					AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'IBSMUN_' || right(cb.prbg_cdbarra_pk,21)							AS DESCRICAO 
						,	CAST(1 AS INT)													AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))											AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)											AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)											AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))											AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))											AS UF_DESTINO 
						,	per_aliquota_ibs_mun												AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))										AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_ibs_mun										AS PERC_REDUCAO 
						,	'B'																AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda													AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)										AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)				AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))											AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))									AS USUARIO 
						,	CURRENT_TIMESTAMP												AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP												AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 										AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 										AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    					AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))										AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))										AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)													AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 											AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 											AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 													AS COD_LOJA 		
						,	cod_class_tributaria_ibs_cbs									as cod_class_tributaria
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true												
				) a
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.cod_mercadoria
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
		; 




-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------
	--		CBS __ FLG_TIPO_IMPOSTO = 'D'


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
					,   cod_class_tributaria
					,   per_cred_presumido_cbs_mono
				)


		SELECT 	pr_cdproduto								
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
					,	coalesce(ALIQUOTA,0) as ALIQUOTA
					,	CST 
					,	COALESCE(PERC_SUBSTITUICAO,0) AS PERC_SUBSTITUICAO 
					,	COALESCE(PERC_REDUCAO,0) AS PERC_REDUCAO
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
					,   cod_class_tributaria
					,   per_cred_presumido_cbs_mono

					
				FROM (
				select 		COALESCE(p.pr_cdproduto,0)									AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)							AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
						,	'CBS_' || right(cb.prbg_cdbarra_pk,21)						AS DESCRICAO 
						,	CAST(1 AS INT)												AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))										AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)										AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)										AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))										AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))										AS UF_DESTINO 
						,	per_aliquota_cbs											AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))									AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_cbs									AS PERC_REDUCAO 
						,	'D'															AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda												AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)									AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)			AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))										AS CST_ORIG
						,	CAST('ZANTHUS' as VARCHAR(15))								AS USUARIO 
						,	CURRENT_TIMESTAMP											AS DATA_CADASTRO 
						,	CURRENT_TIMESTAMP											AS DATA_ULTIMA_ALTERACAO 		
						,	CAST(0 AS NUMERIC(17,4)) 									AS ALIQUOTA_INTERESTADUAL 
						,	CAST(0 AS NUMERIC(17,4)) 									AS VALOR_IMPOSTO  
						,	CAST(0 AS INT) 							    				AS TIPO_LISTA_ST 
						,	CAST(0 AS NUMERIC(17,4))									AS PERC_REDUCAO_ST 
						,	CAST(0 AS NUMERIC(17,4))									AS PERC_DIFERIMENTO 
						,	CAST(0 AS INT)												AS EXIGIBILIDADE_ISS
						,	CAST('N' AS CHAR(1)) 										AS FLG_INCENTIVO_FISCAL_ISS
						,	CAST('01' AS CHAR(2)) 										AS TIPO_DOCUMENTO
						,	CAST(0 AS INT) 												AS COD_LOJA 		
						,	cod_class_tributaria_ibs_cbs								as cod_class_tributaria
						,	per_cred_presumido_cbs_mono 								as per_cred_presumido_cbs_mono
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
				inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
				inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
				inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
				inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
				inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
				where d.prd_cddepartamento in (1, 5)
				and   prb.prb_status = true													
				) a
		where not exists 
					(	select 1 
						from TbZanthusTab_Regra_Icms	x
						where x.cod_mercadoria = A.cod_mercadoria
						  and x.flg_tipo_imposto = A.FLG_TIPO_IMPOSTO
						  and x.FLG_REVENDA = A.FLG_REVENDA
		
		)			
		; 





	/* ATUALIZAÇÕES */

	--- NCMS
	update TbZanthusTab_Regra_Icms a
	       set  COD_NCM_INI = cast(b.prb_ncm as int)
		      , cod_ncm_fim = cast(b.prb_ncm as int) 
	from   tbprodutobluesoft b
	where b.prb_cdprodutobluesoft_pk = a.prb_cdprodutobluesoft
	  and  ( lpad(cast(a.cod_ncm_ini as varchar(8)), 8, '0') != lpad(CAST(b.prb_ncm as varchar(8)), 8, '0')
	     or lpad(cast(a.cod_ncm_fim as varchar(8)), 8, '0') != lpad(CAST(b.prb_ncm as varchar(8)), 8, '0') )

	;	     


	/*atualização ICMS*/

	update TbZanthusTab_Regra_Icms b
	set    ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)		
		,  codigo_beneficio_fiscal = a.codigo_beneficio_fiscal

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)									AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)							AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS COD_MERCADORIA 
				
						,	cast( coalesce(icms_aliquota,7) as numeric(13,2))					AS ALIQUOTA
						,	lpad(cast(CAST(icms_cst AS INT) as varchar(3)), 3, '0')				AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))											AS PERC_SUBSTITUICAO 
						,	icms_reducao								AS PERC_REDUCAO 
						,	'0'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
						,	CAST(CURRENT_DATE AS DATE)								AS DTA_VAL_INICIAL
						,	CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)		AS DTA_VAL_FINAL 
						,	CAST('0' AS CHAR(3))						AS CST_ORIG
						,   p.codigo_beneficio_fiscal                     as codigo_beneficio_fiscal	


				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) OR a.CST != b.CST OR COALESCE(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0))
      and a.flg_tipo_imposto = '0' --- ICMS 	  

;


	/*atualização PIS*/
	update TbZanthusTab_Regra_Icms b
	set    ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
				
						,	pis_aliquota 								AS ALIQUOTA
						,	lpad(cast(cast(pis_cst	as int)	as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	'1'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 						
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) OR a.CST != b.CST OR COALESCE(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0))
	  
      and a.flg_tipo_imposto = '1' --- PIS 

	;

	/*atualização COFINS*/
	update TbZanthusTab_Regra_Icms b
	set    ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
				
						,	cofins_aliquota 								AS ALIQUOTA
						,	lpad(cast(cast(cofins_cst	as int)	as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_SUBSTITUICAO 
						,	CAST(0.00 AS NUMERIC(17,4))					AS PERC_REDUCAO 
						,	'2'											AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 						
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (	COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) 
	  		OR a.CST != b.CST 
			OR coalesce(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0))
	  
      and a.flg_tipo_imposto = '2' --- COFINS
	;



	/*atualização IBS UF*/
	update TbZanthusTab_Regra_Icms b
	set    ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)
		,  cod_class_tributaria = a.cod_class_tributaria
		,  per_cred_presumido_ibs_mono = a.per_cred_presumido_ibs_mono

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
				
						,	per_aliquota_ibs_uf											AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))									AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_ibs_uf									AS PERC_REDUCAO 
						,	'A'															AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
						,	cod_class_tributaria_ibs_cbs								as cod_class_tributaria
						,	per_cred_presumido_ibs_mono 								as per_cred_presumido_ibs_mono						
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 						
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (	COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) 
	  		OR a.CST != b.CST 
			OR COALESCE(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0)
		)
	  
      and a.flg_tipo_imposto = 'A' --- IBS UF
	;



	/*atualização IBS MUN*/
	update TbZanthusTab_Regra_Icms b
	set   ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
				
						,	per_aliquota_ibs_mun												AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))										AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_ibs_mun										AS PERC_REDUCAO 
						,	'B'																AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 						
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (	COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) 
	  		OR a.CST != b.CST 
			OR COALESCE(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0)
			)
	  
      and a.flg_tipo_imposto = 'B' --- IBS MUN
	;



	/*atualização CBS*/
	update TbZanthusTab_Regra_Icms b
	set   ALIQUOTA = COALESCE(a.ALIQUOTA,0)
		,  CST = a.CST
		,  PERC_REDUCAO = COALESCE(a.PERC_REDUCAO,0)
		,  DATA_ULTIMA_ALTERACAO = CURRENT_TIMESTAMP
		,  DTA_VAL_FINAL = CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)
		,  cod_class_tributaria = a.cod_class_tributaria
		,  per_cred_presumido_cbs_mono = a.per_cred_presumido_cbs_mono	
	

	from   (		
				select 		COALESCE(p.pr_cdproduto,0)					AS pr_cdproduto
						,	COALESCE(p.prb_cdprodutobluesoft,0)			AS prb_cdprodutobluesoft
						,	COALESCE(cb.prbg_cdbarra_pk,'0')							AS preg_cdbarra
						,	lpad(COALESCE(cb.prbg_cdbarra_pk,'0'), 17, '0')				AS cod_mercadoria 
						--,	200000 + ROW_NUMBER () OVER (ORDER BY pr_cdproduto DESC)
						--												AS COD_REGRA_ICMS
				
						,	per_aliquota_cbs											AS ALIQUOTA
						,	lpad(cast(cod_sit_tributaria_ibs_cbs as varchar(3)), 3, '0')	AS CST 
						,	CAST(0.00 AS NUMERIC(17,4))									AS PERC_SUBSTITUICAO 
						,	per_reducao_aliquota_cbs									AS PERC_REDUCAO 
						,	'D'															AS FLG_TIPO_IMPOSTO 
						,	p.flg_revenda								AS FLG_REVENDA 
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
						,	cod_class_tributaria_ibs_cbs								as cod_class_tributaria
						,	per_cred_presumido_cbs_mono 								as per_cred_presumido_cbs_mono									
				from 		tbzanthus_tributacao_produto p
				inner join 	tbprodutobluesoft_gtins		 cb on cb.prb_cdprodutobluesoft = p.prb_cdprodutobluesoft 						
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (		COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) 
	  			OR a.CST != b.CST OR 
				COALESCE(a.PERC_REDUCAO,0) != COALESCE(b.PERC_REDUCAO,0) 
				or COALESCE(a.cod_class_tributaria,0) != COALESCE(b.cod_class_tributaria,0) 
				or COALESCE(a.per_cred_presumido_cbs_mono,0) != COALESCE(b.per_cred_presumido_cbs_mono,0)
				)
	  
      and a.flg_tipo_imposto = 'D' --- CBS

	;




end;
$BODY$;


;
SELECT f0085_53_1012019_zanthus_carga_regra_icms();