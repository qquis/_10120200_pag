-- FUNCTION: public.f0085_53_1012016_zanthus_carga_regra_icms()

-- DROP FUNCTION IF EXISTS public.f0085_53_1012016_zanthus_carga_regra_icms();

CREATE OR REPLACE FUNCTION public.f0085_53_1012017_zanthus_carga_regra_icms(
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

	vuuid_start:= 'F0085_53.1012017' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_53.zanthus_carga_regra_icms.2017', 'Zanthus/Carga (4) _ Tributacao', vuuid_start, vuuid_start)
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
				select 		COALESCE(pr_cdproduto,0)									AS pr_cdproduto
						,	COALESCE(prb_cdprodutobluesoft,0)							AS prb_cdprodutobluesoft
						,	COALESCE(preg_cdbarra,'0')									AS preg_cdbarra
						,	COALESCE(cod_mercadoria,'0')								AS COD_MERCADORIA 
						,	'ICM_' || right(cod_mercadoria,21)			AS DESCRICAO 
						,	CAST(1 AS INT)								AS PRIORIDADE 
						,	CAST('P' AS CHAR(1))						AS FLG_REGISTRO
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	cast( coalesce(icms_aliquota,7) as numeric(13,2))					AS ALIQUOTA
						,	cast(CAST(icms_cst AS INT) as varchar(3))							AS CST 		
						,	CAST(0.00 AS NUMERIC(17,4))											AS PERC_SUBSTITUICAO 
						,	icms_reducao								AS PERC_REDUCAO 
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

				from 	tbzanthus_tributacao_nfce

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
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	pis_aliquota 								AS ALIQUOTA
						,	cast(cast(pis_cst	as int)	as varchar(3))	AS CST 		
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
				from 	tbzanthus_tributacao_nfce

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
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_INI 
						,	CAST(ncm_codigo AS INT)						AS COD_NCM_FIM
						,	CAST('SP' AS CHAR(2))						AS UF_ORIGEM
						,	CAST('SP' AS CHAR(2))						AS UF_DESTINO 
						,	cofins_aliquota 								AS ALIQUOTA
						,	cast(cast(cofins_cst	as int)	as varchar(3))	AS CST 		
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
				from 	tbzanthus_tributacao_nfce
	) AS X
	WHERE 	(			prb_cdprodutobluesoft <> 0 
			 		or  cod_mercadoria in (select cod_insumo from  TbZanthustab_produto_decomposicao_insum)
			 )
	--------------------------------------------------------------------------
	--and x.cod_mercadoria = '00000000000471619' ---- TESTE			
	--------------------------------------------------------------------------
	--------------------------------------------------------------------------
	AND NOT EXISTS ( 	SELECT 1 
						FROM 	TbZanthusTab_Regra_Icms A 
						WHERE 	A.cod_mercadoria = x.cod_mercadoria 
						 AND    A.flg_tipo_imposto = x.flg_tipo_imposto

					 )

	;

	

	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = cast(a.ncm_codigo as int)
		,  COD_NCM_FIM = cast(a.ncm_codigo as int)
		,  ALIQUOTA    = a.icms_aliquota
		,  CST         = cast(CAST(icms_cst AS INT) as varchar(3))
		,  PERC_REDUCAO = a.icms_reducao
		,  API_REGRA_FISCAL = a.api_regra_fiscal 
		,  dtlog_update = current_timestamp 
	FROM   tbzanthus_tributacao_nfce a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 0 ---- ICMS 
	  and (	    COD_NCM_INI  != cast(a.ncm_codigo as int)
			or  COD_NCM_FIM  != cast(a.ncm_codigo as int) 
			or  ALIQUOTA     != a.icms_aliquota
			or  CST          != cast(CAST(icms_cst AS INT) as varchar(3))
			or  PERC_REDUCAO != a.icms_reducao
			or  x.API_REGRA_FISCAL != a.api_regra_fiscal 
		  )

	;

	/*PRODUTO SEM CODIGO DE TRIBUTACAO DEFINIDO - ANTIGOS*/

	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = cast(a.ncm_codigo as int)
		,  COD_NCM_FIM = cast(a.ncm_codigo as int)
		,  ALIQUOTA    = 7
		,  CST         = 0
		,  PERC_REDUCAO = 0
		,  API_REGRA_FISCAL = a.api_regra_fiscal 
		,  dtlog_update = current_timestamp 
	FROM   tbzanthus_tributacao_nfce a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 0 ---- ICMS 
      AND  a.cod_tributacao_pdv = 99 

	--------------------------------------------------------------------------
	--and x.cod_mercadoria = '00000000000471619' ---- TESTE			
	--------------------------------------------------------------------------
	--------------------------------------------------------------------------
	;

	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = cast(a.ncm_codigo as int)
		,  COD_NCM_FIM = cast(a.ncm_codigo as int)
		,  ALIQUOTA    = a.pis_aliquota
		,  CST         = cast(cast(pis_cst	as int)	as varchar(3))
		,  PERC_REDUCAO = 0
		,  API_REGRA_FISCAL = a.api_regra_fiscal 
		,  dtlog_update = current_timestamp 
	FROM   tbzanthus_tributacao_nfce a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 1
	  and (	    COD_NCM_INI  != cast(a.ncm_codigo as int)
			or  COD_NCM_FIM  != cast(a.ncm_codigo as int)
			or  ALIQUOTA     != a.pis_aliquota
			or  CST          != cast(cast(pis_cst	as int)	as varchar(3))
			or  x.API_REGRA_FISCAL != a.api_regra_fiscal 
		  )
	--------------------------------------------------------------------------
	--and x.cod_mercadoria = '00000000000471619' ---- TESTE			
	--------------------------------------------------------------------------
	--------------------------------------------------------------------------
	;

	update TbZanthusTab_Regra_Icms x
	 set   COD_NCM_INI = cast(a.ncm_codigo as int)
		,  COD_NCM_FIM = cast(a.ncm_codigo as int)
		,  ALIQUOTA    = a.cofins_aliquota
		,  CST         = cast(cast(cofins_cst	as int)	as varchar(3))
		,  PERC_REDUCAO = 0
		,  API_REGRA_FISCAL = a.api_regra_fiscal
		,  dtlog_update = current_timestamp 
	FROM   tbzanthus_tributacao_nfce a
	WHERE  A.cod_mercadoria = x.cod_mercadoria 
	  AND  x.flg_tipo_imposto = 2
	  and (	    COD_NCM_INI  != cast(a.ncm_codigo as int)
			or  COD_NCM_FIM  != cast(a.ncm_codigo as int)
			or  ALIQUOTA     != a.cofins_aliquota
			or  CST          != cast(cast(cofins_cst	as int)	as varchar(3))
			or  x.API_REGRA_FISCAL != a.api_regra_fiscal
		  )
	--------------------------------------------------------------------------
	--and x.cod_mercadoria = '00000000000471619' ---- TESTE			
	--------------------------------------------------------------------------
	--------------------------------------------------------------------------
	;

	UPDATE      TbZanthusTab_Regra_Icms
		SET		DTA_VAL_INICIAL = CAST(CURRENT_DATE AS DATE)	
		,		DTA_VAL_FINAL	= CAST(CURRENT_DATE + INTERVAL '1200 day'  AS DATE)
	WHERE		DTA_VAL_FINAL < CURRENT_DATE
	;
	

end;
$BODY$;


