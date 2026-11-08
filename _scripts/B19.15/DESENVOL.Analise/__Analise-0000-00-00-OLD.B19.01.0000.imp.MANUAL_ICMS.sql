
---1) EXECUTAR POPULAÇÃO DA TABELA tbzanthus_tributacao_produto

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
		

---2) EXECUTAR O SCRIPT ABAIXO
	insert into tbzanthus_tributacao_icms_pdv
		(
			icms_cd 
		)
	select 		icms_codigo_icms
	from tbzanthus_tributacao_produto x
	where not exists (select 1 from tbzanthus_tributacao_icms_pdv y where y.icms_cd = x.icms_codigo_icms	)
	group by icms_cst						
			,	icms_codigo_icms		



/*
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




select * from tbzanthus_tributacao_icms_pdv
select * from tbfc_icms
*/

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 0 
,      tributacao_icms_pdv_descricao = '000 ICMS 07%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 7
and     i.reducao = 0 
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 4
,      tributacao_icms_pdv_descricao = '060 SUBSTITUICAO'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 0
and     i.reducao = 0 
and     i.codigotributacao = 60
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 5
		,      tributacao_icms_pdv_descricao = 'ISENTO'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 0
and     i.reducao = 0 
and     i.codigotributacao = 40
;
update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 7
,      tributacao_icms_pdv_descricao = '000 ICMS 12%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 12
and     i.reducao = 0 
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 8
,      tributacao_icms_pdv_descricao = '000 ICMS 18%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 18
and     i.reducao = 0 
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 9
,      tributacao_icms_pdv_descricao = '000 ICMS 25%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 25
and     i.reducao = 0 
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 10
,      tributacao_icms_pdv_descricao = '020 ICMS 12% RED 8.33%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 12
and     i.reducao = 8.33
;



update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 13
,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 33.33%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 18
and     i.reducao = 33.33000
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 14
,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 38.88%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 18
and     i.reducao = 38.88000		
;

update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 15
,      tributacao_icms_pdv_descricao = '020 ICMS 12% RED 41.67%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 12
and     i.reducao = 41.67000		
;


update tbzanthus_tributacao_icms_pdv x
set    cod_tributacao_pdv  = 16
,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 61.11%'
from   tbfc_icms i
where   i.icms_cd = x.icms_cd 
and     i.aliquota = 18
and     i.reducao = 61.11
;






select 	i.icms_cd

	,	i.aliquota
	,	i.reducao 
	,	i.codigotributacao
	,	i.icms_descricao 
	,	i.aliquota
	,   i.reducao 
	,	i.codigoorigem 
	,	i.codigotributacao 
	,	coalesce(x.cod_tributacao_pdv,-1) as cod_tributacao_pdv
	,   coalesce(count_produto.qtde_produto,0) as qtde_produto
from 		tbfc_icms i
left join 	tbzanthus_tributacao_icms_pdv x on i.icms_cd = x.icms_cd 
left join   (select x.icms_codigo_icms 
				,   count(distinct(pb.prb_cdprodutobluesoftunitario)) as qtde_produto
			 from 	tbfc_regrafiscal_nfce_produto x
			 left join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = x.prb_cdprodutobluesoft
			 group by x.icms_codigo_icms
			 ) count_produto on count_produto.icms_codigo_icms = x.icms_cd
order by    i.aliquota, i.reducao asc

select * from tbzanthus_tributacao_icms_pdv