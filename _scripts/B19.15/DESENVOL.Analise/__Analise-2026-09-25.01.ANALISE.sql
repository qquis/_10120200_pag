select * from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 182779
select * from tbzanthus_tributacao_produto where prb_cdprodutobluesoft = 182779
select * from tbzanthustab_regra_icms 
where prb_cdprodutobluesoft = 179198
and flg_tipo_imposto = 'B'


	/*atualização IBS MUN*/
	update TbZanthusTab_Regra_Icms b
	set   ALIQUOTA = COALESCE(b.ALIQUOTA,0)
		,  CST = b.CST
		,  PERC_REDUCAO = COALESCE(b.PERC_REDUCAO,0)
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
				WHERE P.prb_cdprodutobluesoft = 179198
			) A
	where a.cod_mercadoria = b.cod_mercadoria
	  AND a.flg_tipo_imposto = b.flg_tipo_imposto
	  AND a.flg_revenda = b.flg_revenda
	  and (COALESCE(a.ALIQUOTA,0) != COALESCE(b.ALIQUOTA,0) OR a.CST != b.CST OR a.PERC_REDUCAO != b.PERC_REDUCAO)
	  
      and a.flg_tipo_imposto = 'B' --- IBS MUN
	;


	select dtlog_insert, ibs_mun_cd, ibs_mun_aliquota, ibs_mun_percentual_reducao, nfce_produto_tipo_cd 
	from tbfc_regrafiscal_nfce_produto 
	where 1 = 1 
	and   dtlog_update >= '2026-09-25 17:25:00'
	and   nfce_produto_tipo_cd = 1
	and   prb_cdprodutobluesoft = 179198
