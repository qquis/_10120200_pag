CREATE OR REPLACE FUNCTION public.f0085_51_1012020_zanthus_carga_tributacao()
 RETURNS void
 LANGUAGE plpgsql
AS $function$
   DECLARE VSOMA_TOTAL numeric(13,2);
   declare vuuid_start varchar(30);
   declare vcod_voucher varchar(8);
begin

	vuuid_start:= 'F0085_51.1012017' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_51.zanthus_carga_tributacao.2017', 'Zanthus/Carga (2) _ Tributacao', vuuid_start, vuuid_start)
	;

	/*AJUSTA OS CODIGOS UNITARIOS DA TABELA DE TRIBUTAÇÃO BASICA ZANTHUS */

	UPDATE tbzanthus_tributacao_produto a
	  SET  pr_cdproduto = pr.pr_cdproduto
	  	,  prb_cdprodutobluesoftunitario = b.prb_cdprodutobluesoftunitario
	from 		tbprodutobluesoft b
	inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = b.prb_cdprodutobluesoftunitario 
	where b.prb_cdprodutobluesoft_pk = a.prb_cdprodutobluesoft
	  and (  	a.pr_cdproduto <> pr.pr_cdproduto
	        or 	a.prb_cdprodutobluesoftunitario <> b.prb_cdprodutobluesoftunitario
	      )
	
	;

	  

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

				,	icms_codigo_icms 
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
					,	ic.cod_tributacao_pdv as cod_tributacao_pdv
					,	cast(coalesce(case when prb.prb_ncm = '' then '0' else prb.prb_ncm  end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	cast( coalesce(prb.prb_cest, '0') as int) as cest
					,	lpad(cast(tr.pis_cst as varchar(3)), 3, '0') as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	lpad(cast(tr.cofins_cst as varchar(3)), 3, '0') as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 
					,	tr.icms_codigo_icms as icms_codigo_icms
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
					
					,   coalesce(ibs_aliquota,0)                        as per_aliquota_ibs_uf
					,   coalesce(ibs_percentual_reducao,0)              as per_reducao_aliquota_ibs_uf
					,   coalesce(ibs_percentual_diferimento,0)      	as per_diferimento_ibs_uf 

					,   coalesce(ibs_mun_aliquota,0)           as per_aliquota_ibs_mun
					,   coalesce(ibs_mun_percentual_reducao,0) as per_reducao_aliquota_ibs_mun
					,   coalesce(ibs_mun_percentual_diferimento,0) as per_diferimento_ibs_mun

					,	coalesce(cbs_aliquota,0) 				    	 as per_aliquota_cbs
					,	coalesce(cbs_percentual_reducao,0) 		    	 as per_reducao_aliquota_cbs
					,	coalesce(cbs_percentual_diferimento,0) 			 as per_diferimento_cbs
											
					,   coalesce(ibs_percentual_credito_presumido_monofasico,0) as per_cred_presumido_ibs_mono
					,   coalesce(cbs_percentual_credito_presumido_monofasico,0) as per_cred_presumido_cbs_mono
					,   'I' as info_complementar

		FROM 	 	tbprodutobluesoft					prb 
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = prb.prb_cdprodutobluesoftunitario 
		INNER JOIN  tbproduto pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
		--> REGISTRA APENAS OS PRODUTOS QUE TEM CODIGO DE TRIBUTACAO VINCULADOp
		INNER JOIN  tbzanthus_tributacao_icms_pdv       IC ON IC.icms_cd = tr.icms_codigo_icms 		
		inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
		inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
		inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
		inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
		WHERE       1 = 1
		and         d.prd_cddepartamento in (1, 5)
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
	
	,  icms_codigo_icms = b.icms_codigo_icms 
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
					,	ic.cod_tributacao_pdv as cod_tributacao_pdv
					,	cast(coalesce(case when prb.prb_ncm = '' then '0' else prb.prb_ncm  end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	cast( coalesce(prb.prb_cest, '0') as int) as cest
					,	lpad(cast(tr.pis_cst as varchar(3)), 3, '0') as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	lpad(cast(tr.cofins_cst as varchar(3)), 3, '0') as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 

					,	tr.icms_codigo_icms as icms_codigo_icms	
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
					
					,   coalesce(ibs_aliquota,0)                        as per_aliquota_ibs_uf
					,   coalesce(ibs_percentual_reducao,0)              as per_reducao_aliquota_ibs_uf
					,   coalesce(ibs_percentual_diferimento,0)      	as per_diferimento_ibs_uf 

					,   coalesce(ibs_mun_aliquota,0)           as per_aliquota_ibs_mun
					,   coalesce(ibs_mun_percentual_reducao,0) as per_reducao_aliquota_ibs_mun
					,   coalesce(ibs_mun_percentual_diferimento,0) as per_diferimento_ibs_mun

					,	coalesce(cbs_aliquota,0) 				    	 as per_aliquota_cbs
					,	coalesce(cbs_percentual_reducao,0) 		    	 as per_reducao_aliquota_cbs
					,	coalesce(cbs_percentual_diferimento,0) 			 as per_diferimento_cbs
											
					,   coalesce(ibs_percentual_credito_presumido_monofasico,0) as per_cred_presumido_ibs_mono
					,   coalesce(cbs_percentual_credito_presumido_monofasico,0) as per_cred_presumido_cbs_mono
					,   'I' as info_complementar

		FROM 	 	tbprodutobluesoft					prb 
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = prb.prb_cdprodutobluesoftunitario 
		INNER JOIN  tbproduto 							pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
		INNER JOIN  tbzanthus_tributacao_icms_pdv       IC ON IC.icms_cd = tr.icms_codigo_icms 
		WHERE       1 = 1
		AND         coalesce(rt_codigo_cst_ibs_cbs, '') != ''
		AND         prb.prb_status = 'true'
) b
where a.prb_cdprodutobluesoft = b.prb_cdprodutobluesoft
  and a.flg_revenda = b.flg_revenda

	;

/* CODIGO DE BENEFICIO FISCAL 
   OBS.: Consideramos o codigo do beneficio fiscal relecioando ao produto pai/cst

*/

/*
	UPDATE      tbzanthus_tributacao_produto X
	    SET     codigo_beneficio_fiscal = AA.fc_cbenef_cd
	FROM  	( select 		pb.prb_cdprodutobluesoft_pk
				  ,			cbenef.fc_cbenef_cd
			  from   	tbprodutobluesoft pb 
			  left join   ( select 		pr.prb_cdprodutobluesoft
									,	CASE WHEN COALESCE(pb.prb_blue_fc_cbenef_Cd,'') != '' 
										     THEN COALESCE(pb.prb_blue_fc_cbenef_Cd,'')
											 ELSE 
											 	CASE WHEN COALESCE(pr.pr_pag_fc_cbenef_cd, '') != ''
												     THEN COALESCE(pr.pr_pag_fc_cbenef_cd, '')
													 ELSE sg.fc_cbenef_cd
											    END
										END AS fc_cbenef_cd
							from 		tbproduto pr
							left join   tbprodutobluesoft 			pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
							left join   tbproduto_subgrupo 			sg on sg.prsg_cdsubgrupo = pr.prsg_cdsubgrupo 
						) cbenef on cbenef.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario 
				WHERE cbenef.fc_cbenef_cd IS NOT NULL 
			) AA 
	inner join  tbfc_cbenef_cst cbenef_cst 
	                           on cbenef_cst.fc_cbenef_cd = AA.fc_cbenef_cd 
	WHERE  AA.prb_cdprodutobluesoft_pk = x.prb_cdprodutobluesoft 
	  and  x.ICMS_CST in ('20','40')
	  AND  cbenef_cst.fc_cbenef_cd 			 = AA.fc_cbenef_cd 
	  and  cbenef_cst.icms_codigo_tributacao = cast(x.icms_cst as int) 

*/

	/*ATUALIZAÇÃO CBENEF POR CODIGO PROPRIO*/
	UPDATE tbzanthus_tributacao_produto T
	SET    codigo_beneficio_fiscal = CBENEF.fc_cbenef_cd
	FROM ( 
			SELECT 	A.prb_cdprodutobluesoft 
				,	A.fc_cbenef_cd 
				,	lpad(cast(CST.ICMS_CODIGO_TRIBUTACAO as varchar(2)), 2 , '0') as ICMS_CODIGO_TRIBUTACAO
			FROM 	tbfc_cbenef_produtobluesoft A
			INNER JOIN tbfc_cbenef_cst CST ON A.fc_cbenef_cd = CST.fc_cbenef_cd 
			WHERE  CST.ICMS_CODIGO_TRIBUTACAO IN (20,40)
		) CBENEF
	WHERE 	CBENEF.prb_cdprodutobluesoft = t.prb_cdprodutobluesoft
		and t.icms_cst = CBENEF.ICMS_CODIGO_TRIBUTACAO
		and coalesce(codigo_beneficio_fiscal, '') != coalesce(CBENEF.fc_cbenef_cd,'')
		and  	t.icms_cst in ('20','40')

	;

	/*ATUALIZAÇÃO CBENEF POR CODIGO UNITARIO */
	UPDATE tbzanthus_tributacao_produto T
	SET    codigo_beneficio_fiscal = CBENEF.fc_cbenef_cd
	FROM ( 
			SELECT 	pb.prb_cdprodutobluesoftunitario 
				,	A.fc_cbenef_cd 
				,	lpad(cast(CST.ICMS_CODIGO_TRIBUTACAO as varchar(2)), 2 , '0') as ICMS_CODIGO_TRIBUTACAO
			FROM 	tbfc_cbenef_produtobluesoft A
			INNER JOIN tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = a.prb_cdprodutobluesoft 
			INNER JOIN tbfc_cbenef_cst CST ON A.fc_cbenef_cd = CST.fc_cbenef_cd 
			WHERE  CST.ICMS_CODIGO_TRIBUTACAO IN (20,40)
			GROUP BY pb.prb_cdprodutobluesoftunitario 
				,	A.fc_cbenef_cd 
				,	lpad(cast(CST.ICMS_CODIGO_TRIBUTACAO as varchar(2)), 2 , '0') 
		) CBENEF
		
	WHERE 	CBENEF.prb_cdprodutobluesoftunitario = t.prb_cdprodutobluesoftunitario 
		and t.icms_cst = CBENEF.ICMS_CODIGO_TRIBUTACAO
		and  coalesce(t.codigo_beneficio_fiscal, '') = ''
		and coalesce(t.codigo_beneficio_fiscal, '') != coalesce(CBENEF.fc_cbenef_cd,'')
		and  	t.icms_cst in ('20','40')	

	;
	UPDATE tbzanthus_tributacao_produto 
	set    codigo_beneficio_fiscal = ''
	    ,  dtlog_update = current_timestamp 
	where  ICMS_CST not in ('20','40')
	  and codigo_beneficio_fiscal != ''

  
	;



update tbzanthus_tributacao_produto a
set    ncm_codigo = cast(b.ncm_codigo as int)
from   tbfc_regrafiscal_nfce_produto b
where  b.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
and    b.nfce_produto_tipo_cd = 1 
and    coalesce(a.ncm_codigo,0) = 0 
and    cast(b.ncm_codigo as int) <> 0 
;


update tbzanthus_tributacao_produto a
set    ncm_codigo = cast( x.prbt_ncm as int )
	,  cest = cast( x.prbt_cest as int )
from   (
			select prb_cdprodutobluesoft as prb_cdprodutobluesoft
				,  prbt_ncm as prbt_ncm
				,  prbt_cest as prbt_cest
			from tbprodutobluesoft_tributacao 
				where op_cdoperacao = 2
) x 
where x.prb_cdprodutobluesoft  = a.prb_cdprodutobluesoft
and a.ncm_codigo = 0
and cast( x.prbt_ncm as int ) > 0 
and a.prb_cdprodutobluesoft in (select prb_cdprodutobluesoft from tbzanthus_tributacao_produto where ncm_codigo = 0 )

;

end;
$function$
