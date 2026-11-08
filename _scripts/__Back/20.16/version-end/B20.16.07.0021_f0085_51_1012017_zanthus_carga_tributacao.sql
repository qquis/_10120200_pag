-- FUNCTION: public.f0085_51_1012016_zanthus_carga_tributacao()

-- DROP FUNCTION IF EXISTS public.f0085_51_1012016_zanthus_carga_tributacao();

CREATE OR REPLACE FUNCTION public.f0085_51_1012017_zanthus_carga_tributacao(
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

	vuuid_start:= 'F0085_51.1012017' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_51.zanthus_carga_tributacao.2017', 'Zanthus/Carga (2) _ Tributacao', vuuid_start, vuuid_start)
	;

	INSERT INTO tbzanthus_tributacao_nfce 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft
				,	preg_cdbarra					
				,	cod_mercadoria 					
				,	cod_tributacao_pdv 	
				,	ncm_codigo 
				,	ncm_excecao 
				,	ncm_variacao 
				,	cest 
				,	pis_cst 
				,	pis_aliquota 
				,	cofins_cst 
				,	cofins_aliquota 
				
				,	icms_cst_origem					
				,	icms_cst						
				,	icms_aliquota					
				,	icms_reducao 					
				,	icms_aliquota_final			
				,	api_regra_fiscal	
				
			)
		SELECT 	 		cast(coalesce(GTX.pr_cdproduto,0) as int) as pr_cdproduto 
					,	cast(coalesce(GTX.prb_cdprodutobluesoft,0) as int) as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') as cod_mercadoria 
					,	0 as cod_tributacao_pdv
					,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	0 as cest
					,	tr.pis_cst as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	tr.cofins_cst as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 
					,	coalesce(tr.icms_codigo_origem, '0')	 as icms_codigo_origem
					,	coalesce(tr.icms_codigo_tributacao, '00') as icms_codigo_tributacao 
					,	tr.icms_aliquota as icms_aliquota
					,	tr.icms_reducao as icms_reducao 
					,	tr.icms_aliquota_final as icms_aliquota_final 
					,	cast(1 as SMALLINT) as regra_fiscal
								
		FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
		INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'false'
		and			lpad(gt.prbg_cdbarra_pk, 17, '0') not in (SELECT cod_mercadoria from tbzanthus_tributacao_nfce)
		
		UNION 
		
			SELECT 	 		cast(coalesce(GTX.pr_cdproduto,0) as int) as pr_cdproduto 
					,	cast(coalesce(GTX.prb_cdprodutobluesoft,0) as int) as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') as cod_mercadoria 
					,	0 as cod_tributacao_pdv 
					,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	0 as cest
					,	tr.pis_cst as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	tr.cofins_cst as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 
					,	coalesce(tr.icms_codigo_origem, '0')	 as icms_codigo_origem
					,	coalesce(tr.icms_codigo_tributacao, '00') as icms_codigo_tributacao 
					,	tr.icms_aliquota as icms_aliquota
					,	tr.icms_reducao as icms_reducao 
					,	tr.icms_aliquota_final as icms_aliquota_final 
					,	cast(1 as SMALLINT) as regra_fiscal
								
		FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
		INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'true'
		and			lpad(gt.prbg_cdbarra_pk, 17, '0') not in (SELECT cod_mercadoria from tbzanthus_tributacao_nfce)		

	;

UPDATE tbzanthus_tributacao_nfce X
	SET
			pr_cdproduto				= AA.pr_cdproduto
		,	prb_cdprodutobluesoft		= AA.prb_cdprodutobluesoft
		,	preg_cdbarra				= AA.preg_cdbarra
		--,	cod_tributacao_pdv			= AA.cod_tributacao_pdv
		,	ncm_codigo					= AA.ncm_codigo
		,	ncm_excecao					= AA.ncm_excecao	
		,	ncm_variacao				= AA.ncm_variacao
		,	cest						= AA.cest
		,	pis_cst						= AA.pis_cst
		,	pis_aliquota				= AA.pis_aliquota
		,	cofins_cst					= AA.cofins_cst
		,	cofins_aliquota				= AA.cofins_aliquota
		,	icms_cst_origem				= AA.icms_codigo_origem
		,	icms_cst					= AA.icms_codigo_tributacao
		,	icms_aliquota				= AA.icms_aliquota
		,	icms_reducao				= AA.icms_reducao
		,	icms_aliquota_final			= AA.icms_aliquota_final
        ,   dtlog_update                = current_timestamp
		,	api_regra_fiscal 			    = cast(1 as SMALLINT)

	FROM (
			SELECT 	 		cast(coalesce(GTX.pr_cdproduto,0) as int) as pr_cdproduto 
						,	cast(coalesce(GTX.prb_cdprodutobluesoft,0) as int) as prb_cdprodutobluesoft
						,	gt.prbg_cdbarra_pk as preg_cdbarra
						,	lpad(gt.prbg_cdbarra_pk, 17, '0') as cod_mercadoria 
						,	0 as cod_tributacao_pdv
						,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
						,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
						,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
						,	0 as cest
						,	tr.pis_cst as pis_cst
						,	tr.pis_aliquota  as pis_aliquota
						,	tr.cofins_cst as cofins_cst
						,	tr.cofins_aliquota as cofins_aliquota 
						,	coalesce(tr.icms_codigo_origem, '0')	 as icms_codigo_origem
						,	coalesce(tr.icms_codigo_tributacao, '00') as icms_codigo_tributacao 
						,	tr.icms_aliquota as icms_aliquota
						,	tr.icms_reducao as icms_reducao 
						,	tr.icms_aliquota_final as icms_aliquota_final 
									
			FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
			INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
			LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
			INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
			where		1 = 1 
			and			pr.prb_status_embalagemcaixa = 'false'
			
			UNION 
			
				SELECT 	 		cast(coalesce(GTX.pr_cdproduto,0) as int) as pr_cdproduto 
						,	cast(coalesce(GTX.prb_cdprodutobluesoft,0) as int) as prb_cdprodutobluesoft
						,	gt.prbg_cdbarra_pk as preg_cdbarra
						,	lpad(gt.prbg_cdbarra_pk, 17, '0') as cod_mercadoria 
						,	0 as cod_tributacao_pdv 
						,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
						,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
						,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
						,	0 as cest
						,	tr.pis_cst as pis_cst
						,	tr.pis_aliquota  as pis_aliquota
						,	tr.cofins_cst as cofins_cst
						,	tr.cofins_aliquota as cofins_aliquota 
						,	coalesce(tr.icms_codigo_origem, '0')	 as icms_codigo_origem
						,	coalesce(tr.icms_codigo_tributacao, '00') as icms_codigo_tributacao 
						,	tr.icms_aliquota as icms_aliquota
						,	tr.icms_reducao as icms_reducao 
						,	tr.icms_aliquota_final as icms_aliquota_final 
									
			FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
			INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
			LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
			INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
			where		1 = 1 
			and			pr.prb_status_embalagemcaixa = 'true'
	) AS AA

	WHERE 1 = 1
	AND X.cod_mercadoria = AA.cod_mercadoria
	AND ( 

				X.pr_cdproduto				!= AA.pr_cdproduto
			OR	X.prb_cdprodutobluesoft		!= AA.prb_cdprodutobluesoft
			OR	X.preg_cdbarra				!= AA.preg_cdbarra
			--OR	X.cod_tributacao_pdv		!= AA.cod_tributacao_pdv
			OR	X.ncm_codigo				!= AA.ncm_codigo 
			OR	X.ncm_excecao				<> AA.ncm_excecao	
			OR	X.ncm_variacao				<> AA.ncm_variacao
			OR	X.cest						<> AA.cest
			OR	CAST(X.pis_cst AS INT)		<> AA.pis_cst
			OR	X.pis_aliquota				<> AA.pis_aliquota
			OR	CAST(X.cofins_cst AS INT)	<> AA.cofins_cst
			OR	X.cofins_aliquota			<> AA.cofins_aliquota
			OR	CAST(X.icms_cst_origem AS INT)	<> CAST(AA.icms_codigo_origem AS INT)
			OR	CAST(X.icms_cst AS INT)		<> CAST(AA.icms_codigo_tributacao AS INT)
			OR	X.icms_aliquota				<> AA.icms_aliquota
			OR	X.icms_reducao				<> AA.icms_reducao
			OR	X.icms_aliquota_final		<> AA.icms_aliquota_final
			OR  X.api_regra_fiscal = 0 

	)

;

	/*exluir regra inconsistente */

	delete from tbzanthus_tributacao_nfce
	where icms_cst = '00'
	  and icms_aliquota = 0 
	
	;

	delete from tbzanthus_tributacao_nfce
	where icms_cst = '60'
	  and icms_aliquota > 0 
	;

	delete from tbzanthus_tributacao_nfce
	where icms_cst = '40'
	  and icms_aliquota > 0 
	;

	/*
	delete from tbzanthus_tributacao_nfce
	where api_regra_fiscal = 1 
	and prb_cdprodutobluesoft not in (select prb_cdprodutobluesoft from tbfc_regrafiscal_nfce_produto)
	;*/
	

	INSERT INTO tbzanthus_tributacao_nfce 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft
				,	preg_cdbarra					
				,	cod_mercadoria 					
				,	cod_tributacao_pdv 	
				,	ncm_codigo 
				,	ncm_excecao 
				,	ncm_variacao 
				,	cest 
				,	pis_cst 
				,	pis_aliquota 
				,	cofins_cst 
				,	cofins_aliquota 
				,	icms_cst_origem					
				,	icms_cst						
				,	icms_aliquota					
				,	icms_reducao 					
				,	icms_aliquota_final		
				,	api_regra_fiscal		
				
			)
	SELECT 	 			coalesce(GTX.pr_cdproduto,0) 				as pr_cdproduto
					,	coalesce(GTX.prb_cdprodutobluesoft,0) 		as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk 							as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') 			as cod_mercadoria 		
					,	cast(0 as smallint) 						as cod_tributacao_pdv
					,	cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as ncm_codigo 				
					,	cast(0 as int)  							as ncm_excecao 
					,	cast(0 as int)  							as ncm_variacao
					,	cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest
					,	TR.prbt_pis_saida_cst 	as pis_cst					
					,	TR.prbt_pis_saida_aliquota as pis_aliquota		
					,	TR.prbt_cofins_saida_cst 	as cofins_cst				
					,	TR.prbt_cofins_saida_aliquota	 as cofins_aliquota
					,	left(TR.prbt_icms_saida_cst,1) 	as icms_codigo_origem
					,	right(TR.prbt_icms_saida_cst,2) as icms_codigo
					,	TR.prbt_icms_aliquota_interna as icms_aliquota
					,	TR.prbt_icms_reducao as icms_reducao
					,	0 as icms_aliquota_final
					,   cast(0 as smallint) as api_regra_fiscal 

			FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
			INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
			LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
			LEFT JOIN 	TBPRODUTOBLUESOFT_TRIBUTACAO 		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
														AND 	TR.OP_CDOPERACAO = 2 
														AND		TR.PRBT_REGRAFISCAL_VERSAO = 99999


			where		1 = 1 
			and			pr.prb_status_embalagemcaixa = 'false'
			and         lpad(gt.prbg_cdbarra_pk, 17, '0') not in ( select cod_mercadoria from tbzanthus_tributacao_nfce )
;

	INSERT INTO tbzanthus_tributacao_nfce 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft
				,	preg_cdbarra					
				,	cod_mercadoria 					
				,	cod_tributacao_pdv 	
				,	ncm_codigo 
				,	ncm_excecao 
				,	ncm_variacao 
				,	cest 
				,	pis_cst 
				,	pis_aliquota 
				,	cofins_cst 
				,	cofins_aliquota 
				,	icms_cst_origem					
				,	icms_cst						
				,	icms_aliquota					
				,	icms_reducao 					
				,	icms_aliquota_final		
				,	api_regra_fiscal		
				
			)
	SELECT 	 			coalesce(GTX.pr_cdproduto,0) 				as pr_cdproduto
					,	coalesce(GTX.prb_cdprodutobluesoft,0) 		as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk 							as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') 			as cod_mercadoria 		
					,	cast(0 as smallint) 						as cod_tributacao_pdv
					,	cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as ncm_codigo 				
					,	cast(0 as int)  							as ncm_excecao 
					,	cast(0 as int)  							as ncm_variacao
					,	cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest
					,	TR.prbt_pis_saida_cst 	as pis_cst					
					,	TR.prbt_pis_saida_aliquota as pis_aliquota		
					,	TR.prbt_cofins_saida_cst 	as cofins_cst				
					,	TR.prbt_cofins_saida_aliquota	 as cofins_aliquota
					,	left(TR.prbt_icms_saida_cst,1) 	as icms_codigo_origem
					,	right(TR.prbt_icms_saida_cst,2) as icms_codigo
					,	TR.prbt_icms_aliquota_interna as icms_aliquota
					,	TR.prbt_icms_reducao as icms_reducao
					,	0 as icms_aliquota_final
					,   cast(0 as smallint) as api_regra_fiscal 

			FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
			INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
			LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
			LEFT JOIN 	TBPRODUTOBLUESOFT_TRIBUTACAO 		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
														AND 	TR.OP_CDOPERACAO = 2 
														AND		TR.PRBT_REGRAFISCAL_VERSAO = 99999

			where		1 = 1 
			and			pr.prb_status_embalagemcaixa = 'true'
			and         lpad(gt.prbg_cdbarra_pk, 17, '0') not in ( select cod_mercadoria from tbzanthus_tributacao_nfce )
;

UPDATE tbzanthus_tributacao_nfce X
	SET
			pr_cdproduto				= AA.pr_cdproduto
		,	prb_cdprodutobluesoft		= AA.prb_cdprodutobluesoft
		,	preg_cdbarra				= AA.preg_cdbarra
		--,	cod_tributacao_pdv			= AA.cod_tributacao_pdv
		,	ncm_codigo					= AA.ncm_codigo
		,	ncm_excecao					= AA.ncm_excecao	
		,	ncm_variacao				= AA.ncm_variacao
		,	cest						= AA.cest
		,	pis_cst						= AA.pis_cst
		,	pis_aliquota				= AA.pis_aliquota
		,	cofins_cst					= AA.cofins_cst
		,	cofins_aliquota				= AA.cofins_aliquota
		,	icms_cst_origem				= AA.icms_codigo_origem
		,	icms_cst					= AA.icms_codigo
		,	icms_aliquota				= AA.icms_aliquota
		,	icms_reducao				= AA.icms_reducao
		,	icms_aliquota_final			= AA.icms_aliquota_final
        ,   dtlog_update                = current_timestamp

	FROM (
		
			SELECT 	 	coalesce(GTX.pr_cdproduto,0) 				as pr_cdproduto
					,	coalesce(GTX.prb_cdprodutobluesoft,0) 		as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk 							as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') 			as cod_mercadoria 		
					,	cast(0 as smallint) 						as cod_tributacao_pdv
					,	cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as ncm_codigo 				
					,	cast(0 as int)  							as ncm_excecao 
					,	cast(0 as int)  							as ncm_variacao
					,	cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest
					,	TR.prbt_pis_saida_cst 	as pis_cst					
					,	TR.prbt_pis_saida_aliquota as pis_aliquota		
					,	TR.prbt_cofins_saida_cst 	as cofins_cst				
					,	TR.prbt_cofins_saida_aliquota	 as cofins_aliquota
					,	left(TR.prbt_icms_saida_cst,1) 	as icms_codigo_origem
					,	right(TR.prbt_icms_saida_cst,2) as icms_codigo
					,	TR.prbt_icms_aliquota_interna as icms_aliquota
					,	TR.prbt_icms_reducao as icms_reducao
					,	0 as icms_aliquota_final
					,   cast(0 as smallint) as regra_fiscal 

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

	        UNION 

			SELECT 	 	coalesce(GTX.pr_cdproduto,0) 				as pr_cdproduto
					,	coalesce(GTX.prb_cdprodutobluesoft,0) 		as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk 							as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') 			as cod_mercadoria 		
					,	cast(0 as smallint) 						as cod_tributacao_pdv
					,	cast(case when prbt_ncm = '' then '0' else prbt_ncm end as int) as ncm_codigo 				
					,	cast(0 as int)  							as ncm_excecao 
					,	cast(0 as int)  							as ncm_variacao
					,	cast(case when prbt_cest = '' then '0' else prbt_cest end as int) as cest
					,	TR.prbt_pis_saida_cst 	as pis_cst					
					,	TR.prbt_pis_saida_aliquota as pis_aliquota		
					,	TR.prbt_cofins_saida_cst 	as cofins_cst				
					,	TR.prbt_cofins_saida_aliquota	 as cofins_aliquota
					,	left(TR.prbt_icms_saida_cst,1) 	as icms_codigo_origem
					,	right(TR.prbt_icms_saida_cst,2) as icms_codigo
					,	TR.prbt_icms_aliquota_interna as icms_aliquota
					,	TR.prbt_icms_reducao as icms_reducao
					,	0 as icms_aliquota_final
					,   cast(0 as smallint) as regra_fiscal 

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

	) AS AA

	WHERE 1 = 1
	AND X.cod_mercadoria = AA.cod_mercadoria
	AND (x.api_regra_fiscal = 0)

	AND ( 

				X.pr_cdproduto				!= AA.pr_cdproduto
			OR	X.prb_cdprodutobluesoft		!= AA.prb_cdprodutobluesoft
			OR	X.preg_cdbarra				!= AA.preg_cdbarra
			--OR	X.cod_tributacao_pdv		!= AA.cod_tributacao_pdv
			OR	X.ncm_codigo				!= AA.ncm_codigo 
			OR	X.ncm_excecao				<> AA.ncm_excecao	
			OR	X.ncm_variacao				<> AA.ncm_variacao
			OR	X.cest						<> AA.cest
			OR	CAST(X.pis_cst AS INT)		<> cast(AA.pis_cst as int)
			OR	X.pis_aliquota				<> AA.pis_aliquota
			OR	CAST(X.cofins_cst AS INT)	<> cast(AA.cofins_cst as int)
			OR	X.cofins_aliquota			<> AA.cofins_aliquota
			OR	CAST(X.icms_cst_origem AS INT)	<> CAST(AA.icms_codigo_origem AS INT)
			OR	CAST(X.icms_cst AS INT)		<> CAST(AA.icms_codigo AS INT)
			OR	X.icms_aliquota				<> AA.icms_aliquota
			OR	X.icms_reducao				<> AA.icms_reducao
			OR	X.icms_aliquota_final		<> AA.icms_aliquota_final
	)

	;

	UPDATE tbzanthus_tributacao_nfce
	SET icms_cst = lpad(icms_cst, 2, '0')
	WHERE length(icms_cst) = 1

	;

	update tbzanthus_tributacao_nfce set icms_aliquota_final = cast(icms_aliquota * (1 - (icms_reducao/100)) as numeric(13,2) ) 
	where coalesce(api_regra_fiscal,0) = 0 
	and icms_cst = '20'
	and icms_aliquota_final <> cast(icms_aliquota * (1 - (icms_reducao/100)) as numeric(13,2) ) 

	;

	update tbzanthus_tributacao_nfce set icms_aliquota_final = icms_aliquota
	where coalesce(api_regra_fiscal,0) = 0 
	and icms_cst = '00'
	and icms_aliquota_final <> icms_aliquota

	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	----------------------- TABELA DE DE/PARA CODIGO DE TRIBUTACAO ZANTHUS

	-- ORIUNDOS DA NFCE COM REGRA FISCAL
	
	;
	INSERT INTO tbzanthus_tributacao_nfce_cod_tributacao 
		(		cod_tributacao_pdv 
			,	icms_cst 
			,	icms_aliquota 
			,	icms_reducao 
			,	icms_aliquota_final 
			,	api_regra_fiscal
		)
	select 	99, icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final , 1
	from	 tbzanthus_tributacao_nfce 
	where api_regra_fiscal = 1
	and  not exists (
				select 1 
				from tbzanthus_tributacao_nfce_cod_tributacao tbtc
				where tbtc.icms_cst = tbzanthus_tributacao_nfce.icms_cst
				and tbtc.icms_aliquota = tbzanthus_tributacao_nfce.icms_aliquota
				and tbtc.icms_reducao = tbzanthus_tributacao_nfce.icms_reducao
				and tbtc.icms_aliquota_final = tbzanthus_tributacao_nfce.icms_aliquota_final
				)
	group by icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final 

	;
	-- ORIUNDOS DA NFCE SEM REGRA FISCAL 
	INSERT INTO tbzanthus_tributacao_nfce_cod_tributacao 
		(		cod_tributacao_pdv 
			,	icms_cst 
			,	icms_aliquota 
			,	icms_reducao 
			,	icms_aliquota_final 
		)
	select 	99, icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final 
	from	 	tbzanthus_tributacao_nfce 
	where api_regra_fiscal = 0
	and  not exists (
				select 1 
				from tbzanthus_tributacao_nfce_cod_tributacao tbtc
				where tbtc.icms_cst = tbzanthus_tributacao_nfce.icms_cst
				and tbtc.icms_aliquota = tbzanthus_tributacao_nfce.icms_aliquota
				and tbtc.icms_reducao = tbzanthus_tributacao_nfce.icms_reducao
				and tbtc.icms_aliquota_final = tbzanthus_tributacao_nfce.icms_aliquota_final
				)
	group by icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final

	;

	-- AJUSTE DE ICMS_ST DOIS DIGITOS 
	update tbzanthus_tributacao_nfce_cod_tributacao set API_REGRA_FISCAL = 0 
	where API_REGRA_FISCAL is null
	--;

	-- AJUSTE DE ICMS_ST DOIS DIGITOS 
	--update tbzanthus_tributacao_nfce_cod_tributacao set icms_aliquota_final = cast(icms_aliquota * (1 - (icms_reducao/100)) as numeric(13,2) ) 
	--where coalesce(api_regra_fiscal,0) = 0 
	--and icms_cst = '20'

	--;
	-- AJUSTE ALIQUOTA FINAL PARA ICMS CST 000 
	--update tbzanthus_tributacao_nfce_cod_tributacao set icms_aliquota_final = icms_aliquota 
	--where coalesce(api_regra_fiscal,0) = 0 
	--and icms_cst = '00'

	;
	--->>> CST 000 _ 07.00% REDUCAO 0 _ COD ZANTHUS 00
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 0
	where		ICMS_CST = '00'
		and		ICMS_ALIQUOTA_FINAL = 7
		and		ICMS_REDUCAO = 0 
		AND     cod_tributacao_pdv = 99

	;
	--->>> CST 000 _ 12.00% REDUCAO 0 _ COD ZANTHUS 07
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 07
	where		ICMS_CST = '00'
		and		ICMS_ALIQUOTA_FINAL = 12
		and		ICMS_REDUCAO = 0 
		AND     cod_tributacao_pdv = 99
	;
	--->>> CST 000 _ 18.00% REDUCAO 0 _ COD ZANTHUS 08
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 08
	where		ICMS_CST = '00'
		and		ICMS_ALIQUOTA_FINAL = 18
		and		ICMS_REDUCAO = 0 
		AND     cod_tributacao_pdv = 99

	;
	--->>> CST 000 _ 25.00% REDUCAO 0 _ COD ZANTHUS 09
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 09
	where		ICMS_CST = '00'
		and		ICMS_ALIQUOTA_FINAL = 25
		and		ICMS_REDUCAO = 0 
		AND     cod_tributacao_pdv = 99

	;
	--->>> CST 020 COM REDUÇÕES 
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 10
	where		ICMS_CST = '20'
		and		ICMS_ALIQUOTA_FINAL = 11
		and		ICMS_REDUCAO > 0
		AND     cod_tributacao_pdv = 99

	;
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 0
	where		ICMS_CST = '20'
		and		ICMS_ALIQUOTA_FINAL = 7
		and		ICMS_REDUCAO > 0  
		AND     cod_tributacao_pdv = 99

	;
		update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 7
	where		ICMS_CST = '20'
		and		ICMS_ALIQUOTA_FINAL = 12
		and		ICMS_REDUCAO > 0  
		AND     cod_tributacao_pdv = 99

	;

	--->>> CST ALIQUOTA FINAL 11.20
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 11
	where		ICMS_ALIQUOTA_FINAL = 11.20
		AND     cod_tributacao_pdv = 99

	;
	--->>> CST ALIQUOTA FINAL 13.3
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 12
	where		ICMS_ALIQUOTA_FINAL = 13.3
		AND     cod_tributacao_pdv = 99

	;	
	--->>> CST 040 ISENTO
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 5
	where		ICMS_CST IN( '40', '41', '50' )
	AND     ICMS_ALIQUOTA_FINAL = 0 
	AND     cod_tributacao_pdv = 99

	;
	--->>> CST 060 SUBSTITUICAO
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 4
	where		ICMS_CST = '60'
	AND     cod_tributacao_pdv = 99

	;
	--------------------------------------------------------------------------------
	--------------------------------------------------------------------------------
	-- Atualização do cod_tributacao_pdv na tabela de tributação nfce

	update tbzanthus_tributacao_nfce x
	set cod_tributacao_pdv = AA.cod_tributacao_pdv 
		, dtlog_update = current_timestamp
	FROM tbzanthus_tributacao_nfce_cod_tributacao AA
	WHERE 1 = 1
	AND x.icms_cst = AA.icms_cst
	AND x.icms_aliquota = AA.icms_aliquota
	AND x.icms_reducao = AA.icms_reducao
	AND x.icms_aliquota_final = AA.icms_aliquota_final
	and x.cod_tributacao_pdv !=  AA.cod_tributacao_pdv 

;	
end;
$BODY$;



