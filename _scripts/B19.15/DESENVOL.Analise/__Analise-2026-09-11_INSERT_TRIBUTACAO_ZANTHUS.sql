
select 		icms_cst						
		,	icms_aliquota					
		,	icms_reducao 		
		,	icms_codigo_icms
		,	count(distinct(prb_cdprodutobluesoft)) 
from tbzanthus_tributacao_produto
group by icms_cst						
		,	icms_aliquota					
		,	icms_reducao 	
		,	icms_codigo_icms		

INSERT INTO tbzanthus_tributacao_produto 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft

				,	codigo_figura_regra_fiscal 
				,   codigo_regra_fiscal 				
				,	flg_revenda						

				,	cod_tributacao_pdv 	
				,	icms_codigo_icms
				
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

				,	cod_sit_tributaria_ibs_cbs 		
				,	cod_class_tributaria_ibs_cbs 	


				,	per_aliquota_ibs_uf 			
				,	per_reducao_aliquota_ibs_uf 	
				,   per_diferimento_ibs

				,	per_aliquota_ibs_mun 			
				,	per_reducao_aliquota_ibs_mun 	
				,	per_diferimento_ibs_mun 		

				,	per_aliquota_cbs 				
				,	per_reducao_aliquota_cbs 		
				,	per_diferimento_cbs 					

				,	per_cred_presumido_ibs_mono 	
				,	per_cred_presumido_cbs_mono 	
				,	info_complementar 				

				
			)
		SELECT 	 		cast(coalesce(pr.pr_cdproduto,0) as int) as pr_cdproduto 
					,	cast(coalesce(prb.prb_cdprodutobluesoft_pk,0) as int) as prb_cdprodutobluesoft
					,	tr.codigo_figura_regra_fiscal 
					,   tr.codigo_regra_fiscal 		
					,   case when tr.nfce_produto_tipo_cd = 1 then 'N' else 'S' end as flg_revenda
					,	0 as cod_tributacao_pdv
					,	icms_codigo_icms as icms_codigo_icms
					,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	0 as cest
					,	lpad(cast(tr.pis_cst as varchar(3)), 3, '0') as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	lpad(cast(tr.cofins_cst as varchar(3)), 3, '0') as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 
					,	coalesce(tr.icms_codigo_origem, '0')	 as icms_cst_origem
					,	lpad(cast(coalesce(tr.icms_codigo_tributacao, '00') as varchar(2)), 2, '0') as icms_cst
					,	tr.icms_aliquota as icms_aliquota
					,	tr.icms_reducao as icms_reducao 
					,	tr.icms_aliquota_final as icms_aliquota_final 

					,	rt_codigo_cst_ibs_cbs 				as cod_sit_tributaria_ibs_cbs
					,   cast(case when trim(coalesce(rt_codigo_class_trib_ibs_cbs,'0')) = '' then '0' else coalesce(rt_codigo_class_trib_ibs_cbs,'0') end  as int) 		as cod_class_tributaria_ibs_cbs
					
					,   ibs_aliquota                        as per_aliquota_ibs_uf
					,   ibs_percentual_reducao              as per_reducao_aliquota_ibs_uf
					,   ibs_percentual_diferimento      	as per_diferimento_ibs_uf 

					,   ibs_mun_aliquota                     as per_aliquota_ibs_mun
					,   ibs_mun_percentual_reducao           as per_reducao_aliquota_ibs_mun
					,   ibs_mun_percentual_diferimento       as per_diferimento_ibs_mun

					,	cbs_aliquota 				    	 as per_aliquota_cbs
					,	cbs_percentual_reducao 		    	 as per_reducao_aliquota_cbs
					,	cbs_percentual_diferimento 			 as per_diferimento_cbs
											
					,   ibs_percentual_credito_presumido_monofasico as per_cred_presumido_ibs_mono
					,   cbs_percentual_credito_presumido_monofasico as per_cred_presumido_cbs_mono
					,   'I' as info_complementar


		FROM 	 	tbprodutobluesoft					prb 
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = prb.prb_cdprodutobluesoftunitario 
		INNER JOIN  tbproduto pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
		WHERE       1 = 1
		AND         coalesce(rt_codigo_cst_ibs_cbs, '') != ''
		and         coalesce(rt_codigo_class_trib_ibs_cbs, '') != ''
		AND         prb.prb_status = 'true'
		


