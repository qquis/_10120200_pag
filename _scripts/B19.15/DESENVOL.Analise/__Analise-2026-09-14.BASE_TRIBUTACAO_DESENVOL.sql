--select prb_cdprodutobluesoft, prbt_ncm, prbt_cest, * from tbprodutoblueSoft_tributacao limit 10
--select prb_cdprodutobluesoft_pk, prb_ncm, prb_cest from tbprodutobluesoft where prb_ncm is not null
--select * from tbzanthus_tributacao_regra_icms limit 10
--select rt_codigo_class_trib_ibs_cbs  from tbfc_regrafiscal_nfce_produto
--select * from tbzanthus_tributacao_produto

--select * from tbzanthus_tributacao_produto

INSERT INTO tbzanthus_tributacao_produto 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft
				,   prb_cdprodutobluesoftunitario 
				,	codigo_figura_regra_fiscal 
				,   codigo_regra_fiscal 				
				,	flg_revenda						

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

				,	cod_sit_tributaria_ibs_cbs 		
				,	cod_class_tributaria_ibs_cbs 	


				,	per_aliquota_ibs_uf 			
				,	per_reducao_aliquota_ibs_uf 	
				,   per_diferimento_ibs_uf

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
					,	cast(coalesce(prb.prb_cdprodutobluesoftunitario,0) as int) as prb_cdprodutobluesoftunitario
					,	tr.codigo_figura_regra_fiscal 
					,   tr.codigo_regra_fiscal 		
					,   case when tr.nfce_produto_tipo_cd = 1 then 'N' else 'S' end as flg_revenda
					,	0 as cod_tributacao_pdv
					,	cast(coalesce(case when prb.prb_ncm = '' then '0' else prb.prb_ncm  end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	cast( coalesce(prb.prb_cest, '0') as int) as cest
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
					,   cast(case 
							when trim(coalesce(rt_codigo_class_trib_ibs_cbs,'0')) = '' 
							then '0' 
							else trim(coalesce(rt_codigo_class_trib_ibs_cbs,'0'))
							end 
							as int) 		as cod_class_tributaria_ibs_cbs
					
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
		AND         prb.prb_status = 'true'
        and         not exists (select 1 
								 from tbzanthus_tributacao_produto aa 
								where aa.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoft_pk
								  and aa.flg_revenda = case when tr.nfce_produto_tipo_cd = 1 then 'N' else 'S' end 
								)

;



update tbzanthus_tributacao_produto a
set    
	   pr_cdproduto = b.pr_cdproduto
	,  prb_cdprodutobluesoftunitario = b.prb_cdprodutobluesoftunitario
	,  codigo_figura_regra_fiscal = b.codigo_figura_regra_fiscal
	,  codigo_regra_fiscal = b.codigo_regra_fiscal
	,  cod_tributacao_pdv = b.cod_tributacao_pdv
	,  ncm_codigo = b.ncm_codigo
	,  ncm_excecao = b.ncm_excecao
	,  ncm_variacao = b.ncm_variacao
	,  cest = b.cest
	,  pis_cst = b.pis_cst
	,  pis_aliquota = b.pis_aliquota
	,  cofins_cst = b.cofins_cst
	,  cofins_aliquota = b.cofins_aliquota
	,  icms_cst_origem = b.icms_cst_origem
	,  icms_cst = b.icms_cst
	,  icms_aliquota = b.icms_aliquota
	,  icms_reducao = b.icms_reducao
	,  icms_aliquota_final = b.icms_aliquota_final
	,  cod_sit_tributaria_ibs_cbs = b.cod_sit_tributaria_ibs_cbs
	,  cod_class_tributaria_ibs_cbs = b.cod_class_tributaria_ibs_cbs
	,  per_aliquota_ibs_uf = b.per_aliquota_ibs_uf
	,  per_reducao_aliquota_ibs_uf = b.per_reducao_aliquota_ibs_uf
	,  per_diferimento_ibs_uf = b.per_diferimento_ibs_uf
	,  per_aliquota_ibs_mun = b.per_aliquota_ibs_mun
	,  per_reducao_aliquota_ibs_mun = b.per_reducao_aliquota_ibs_mun
	,  per_diferimento_ibs_mun = b.per_diferimento_ibs_mun
	,  per_aliquota_cbs = b.per_aliquota_cbs
	,  per_reducao_aliquota_cbs = b.per_reducao_aliquota_cbs
	,  per_diferimento_cbs = b.per_diferimento_cbs
	,  per_cred_presumido_ibs_mono = b.per_cred_presumido_ibs_mono
	,  per_cred_presumido_cbs_mono = b.per_cred_presumido_cbs_mono
	,  info_complementar = b.info_complementar
from   (
			SELECT 	 	cast(coalesce(pr.pr_cdproduto,0) as int) as pr_cdproduto 
					,	cast(coalesce(prb.prb_cdprodutobluesoft_pk,0) as int) as prb_cdprodutobluesoft
					,	cast(coalesce(prb.prb_cdprodutobluesoftunitario,0) as int) as prb_cdprodutobluesoftunitario
					,	tr.codigo_figura_regra_fiscal 
					,   tr.codigo_regra_fiscal 		
					,   case when tr.nfce_produto_tipo_cd = 1 then 'N' else 'S' end as flg_revenda
					,	0 as cod_tributacao_pdv
					,	cast(coalesce(case when prb.prb_ncm = '' then '0' else prb.prb_ncm  end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	cast( coalesce(prb.prb_cest, '0') as int) as cest
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
					,   cast(case 
							when trim(coalesce(rt_codigo_class_trib_ibs_cbs,'0')) = '' 
							then '0' 
							else trim(coalesce(rt_codigo_class_trib_ibs_cbs,'0'))
							end 
							as int) 		as cod_class_tributaria_ibs_cbs
					
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
		AND         prb.prb_status = 'true'
) b
where a.prb_cdprodutobluesoft = b.prb_cdprodutobluesoft
  and a.flg_revenda = b.flg_revenda





--select * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 219403
select prb_cdprodutobluesoft, count(*) 
from tbzanthus_tributacao_produto 
group by prb_cdprodutobluesoft
having count(*) > 1