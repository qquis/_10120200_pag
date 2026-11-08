-- Active: 1773758617277@@127.0.0.1@5432@oxan
SELECT 	* 
FROM 	tbfaturamento_bluesoft 
WHERE   1 = 1
and     data_emissao >= '2026-03-05'
and     op_cdoperacao = 1

SELECT * FROM TBPRODUTOBLUESOFT WHERE PRB_CDPRODUTOBLUESOFT_PK = 163922

select 	i.numeropedido
	,	f.numeropedido_fv 
	,	f.fat_blue_status_cd 
	,	f.fat_blue_tipo_cd 
	,	i.prb_cdprodutobluesoft 
	,	i.qtde_solicitada
	,	i.qtde_faturada 
from 		tbfaturamento_bluesoft_item i
inner join 	tbfaturamento_bluesoft f on f.numeropedido = i.numeropedido and f.numeropedido_fv = i.numeropedido_fv
where 1= 1
and     f.data_emissao >= '2026-03-05'
and     f.op_cdoperacao = 1

select prb_cdprodutobluesoft_pk, prb_dtupdate_from_api from tbprodutobluesoft where prb_cdprodutobluesoft_pk =  43

 select 		x.fc_cbenef_cd 
            ,	x.fc_cbenef_dispositivo
            ,	x.fc_cbenef_objetivo 
			,	coalesce(pag.qtde,0)
			,	coalesce(blue.qtde,0)
            ,	x.fc_cbenef_observacao
            ,   x.fc_cbenef_bluesoft_cd
            ,   x.fc_cbenef_bluesoft_dispositivo
            ,   x.fc_cbenef_bluesoft_objetivo

 from tbfc_cbenef x
 left join ( 
 				 select 	pr_pag_fc_cbenef_cd 
					 	,	count(*) as qtde 
					 from 	tbproduto
					    where pr_pag_fc_cbenef_cd is not null
					 group by pr_pag_fc_cbenef_cd 
 			) pag on pag.pr_pag_fc_cbenef_cd = x.fc_cbenef_cd 
  left join ( 
 				 select 	pb.prb_blue_fc_cbenef_cd  
					 	,	count(*) as qtde 
					 from 	tbproduto px
					 inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = px.prb_cdprodutobluesoft
					    where pb.prb_blue_fc_cbenef_cd   is not null
					 group by pb.prb_blue_fc_cbenef_cd  
 			) blue on blue.prb_blue_fc_cbenef_cd = x.fc_cbenef_cd 			 
 where 1 = 1

select * from tbprodutobluesoft


------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
/* 	CARGA ZANTHUS 
	- CODIGO DO BENEFICIO FISCAL

	API BLUESOFT PARA VINCULO DE BENEFICIO FISCAL
	https://ajuda.bluesoft.com.br/integracoes/api/novidade-fiscal-consulta-e-manutencao-de-beneficios-fiscais-por-uf-e-nfe-via-api/153860

*/

	SELECT 
	    column_name, 
	    data_type, 
	    is_nullable, 
	    column_default
	FROM 
	    information_schema.columns
	WHERE 1=1
	and table_name = 'tab_mercadoria'
	and column_name like '%benef%'
		;

	->>> codigo_beneficio_fiscal


select * from tbproduto_subgrupo

select * from tbfc_regrafiscal
select * from tbfc_regrafiscal_produto
select * from tbfc_regrafiscal_nfce_produto

select 		
			r.prsg_cdsubgrupo
		,	r.prsg_descricao 
		,	g.prg_cdgrupo
		,	g.prg_descricao 
		,	d.prd_cddepartamento 
		,	d.prd_descricao 

		,	pr.pr_status
		,	pr.pr_cdproduto
		,	pr.pr_descricao
		,	pb.prb_cdprodutobluesoft_pk 
		,	x.cfop 
		,	x.icms_codigo_origem
		,	x.icms_codigo_tributacao  
from 		tbproduto pr 
inner join  tbprodutobluesoft 				pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
inner join 	tbproduto_subgrupo 				r on r.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
inner join  tbproduto_grupo 				g on g.prg_cdgrupo = r.prg_cdgrupo 
inner join  tbproduto_secao 				s on s.prs_cdsecao = g.prs_cdsecao 
inner join  tbproduto_departamento 			d on d.prd_cddepartamento = s.prd_cddepartamento  
left join   tbfc_regrafiscal_nfce_produto	x on x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
where		1 = 1
  and       pr.pr_descricao like '%CONTRA FILE%'

select * from tbfc_cbenef

select 		
			r.prsg_cdsubgrupo
		,	r.prsg_descricao 
		,	g.prg_cdgrupo
		,	g.prg_descricao 
		,	d.prd_cddepartamento 
		,	d.prd_descricao 
		,	COUNT(distinct(pb.prb_cdprodutobluesoft_pk))
from 		tbproduto pr 
inner join  tbprodutobluesoft 				pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
inner join 	tbproduto_subgrupo 				r on r.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
inner join  tbproduto_grupo 				g on g.prg_cdgrupo = r.prg_cdgrupo 
inner join  tbproduto_secao 				s on s.prs_cdsecao = g.prs_cdsecao 
inner join  tbproduto_departamento 			d on d.prd_cddepartamento = s.prd_cddepartamento  
left join   tbfc_regrafiscal_nfce_produto	x on x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
where		1 = 1
  and  		x.icms_codigo_tributacao in (20,40)
GROUP BY    r.prsg_cdsubgrupo
		,	r.prsg_descricao 
		,	g.prg_cdgrupo
		,	g.prg_descricao 
		,	d.prd_cddepartamento 
		,	d.prd_descricao


select 		
			icms_codigo_tributacao
		,	COUNT(distinct(pb.prb_cdprodutobluesoft_pk))
from 		tbproduto pr 
inner join  tbprodutobluesoft 				pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
inner join 	tbproduto_subgrupo 				r on r.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
inner join  tbproduto_grupo 				g on g.prg_cdgrupo = r.prg_cdgrupo 
inner join  tbproduto_secao 				s on s.prs_cdsecao = g.prs_cdsecao 
inner join  tbproduto_departamento 			d on d.prd_cddepartamento = s.prd_cddepartamento  
left join   tbfc_regrafiscal_nfce_produto	x on x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
where		1 = 1
  --and  		x.icms_codigo_tributacao in (20,40)
GROUP BY   icms_codigo_tributacao



  SELECT * FROM tbfc_regrafiscal_nfce_produto limit 10


--select * from tbproduto_subgrupo
--select * from tbproduto_grupo
--select * from tbproduto_secao
--select * from tbproduto_departamento
--SELECT * FROM tbfc_regrafiscal_nfce_produto limit 10



select 		
                            r.prsg_cdsubgrupo
                        ,	r.prsg_descricao 
                        ,	g.prg_cdgrupo
                        ,	g.prg_descricao 
                        ,	d.prd_cddepartamento 
                        ,	d.prd_descricao 
                        ,   pr.pr_cdproduto
                        ,	pr.prb_cdprodutobluesoft
                        ,   pb.prb_descricao 
                        ,	case when pb.prb_status then 1 else 0 end as prb_status
                        ,	x.icms_codigo_origem
                        ,	x.icms_codigo_tributacao  
                        ,   cbenf_grupo.fc_cbenef_cd subgrupo_fc_cbenef_cd
						,	f.fc_figurafiscal_descricao 
                from 		tbproduto pr 
                inner join  tbprodutobluesoft 				pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                inner join 	tbproduto_subgrupo 				r  on r.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
                inner join  tbproduto_grupo 				g  on g.prg_cdgrupo = r.prg_cdgrupo 
                inner join  tbproduto_secao 				s  on s.prs_cdsecao = g.prs_cdsecao 
                inner join  tbproduto_departamento 			d  on d.prd_cddepartamento = s.prd_cddepartamento  
                left join   tbfc_regrafiscal_nfce_produto	x  on x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
				left join   tbfc_figurafiscal_produto       rp on rp.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
				left join   tbfc_figurafiscal               f  on f.fc_figurafiscal_cd = rp.fc_figurafiscal_cd
  				left join (select 		cc.fc_cbenef_cd
									,	cc.icms_codigo_tributacao
									,	ss.prsg_cdsubgrupo
							from 		tbfc_cbenef_cst cc
							inner join  tbproduto_subgrupo ss on ss.fc_cbenef_cd = cc.fc_cbenef_cd
							) cbenf_grupo on cbenf_grupo.prsg_cdsubgrupo = r.prsg_cdsubgrupo 
									and cbenf_grupo.icms_codigo_tributacao = x.icms_codigo_tributacao  
                where		1 = 1
                and       pb.prb_status = true
                and       x.icms_codigo_tributacao in (20,40) 

select * from tbfc_figurafiscal_produto limit 10
select 	fc_cbenef_cd 
	,	fc_cbenef_dispositivo
	,	fc_cbenef_objetivo 
	,	fc_cbenef_observacao 
from tbfc_cbenef


			select	 	sb.prsg_cdsubgrupo 
                    , 	sb.prsg_descricao
                    ,   coalesce(prodCount.qtdeproduto,0) as qtdeproduto
                    ,   sb.fc_cbenef_cd
                    ,   cben.fc_cbenef_objetivo 
            from 		tbproduto_subgrupo sb 
            left join   tbproduto_grupo gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
            left join   tbproduto_secao sc on sc.prs_cdsecao = gr.prs_cdsecao
            left join   tbproduto_departamento dp on dp.prd_cddepartamento = sc.prd_cddepartamento
            left join   tbfc_cbenef cben on cben.fc_cbenef_cd = sb.fc_cbenef_cd
            left join   (select   count(distinct(pr.pr_cdproduto)) qtdeproduto
                                , pr.prsg_cdsubgrupo
                        from tbproduto pr 
                        group by pr.prsg_cdsubgrupo
                        ) prodCount on prodCount.prsg_cdsubgrupo = sb.prsg_cdsubgrupo
            where 1 = 1 


			select xs.prsg_cdsubgrupo, 
			       count(distinct(case when icms_codigo_tributacao = 20 then  prb_cdprodutobluesoft else null)) as cst_20
				   count(distinct(case when icms_codigo_tributacao = 40 then  prb_cdprodutobluesoft else null)) as cst_40 
			from 			tbfc_regrafiscal_nfce_produto aa
			inner join 		tbproduto xp on xp.prb_cdprodutobluesoft = aa.prb_cdprodutobluesoft
			inner join      tbproduto_subgrupo xs on xs.prsg_cdsubgrupo = xp.prsg_cdsubgrupo
			group by xs.prsg_cdsubgrupo


select 		
                            sb.prsg_cdsubgrupo
                        ,	sb.prsg_descricao 
                        ,	gr.prg_cdgrupo
                        ,	gr.prg_descricao 
                        ,	dp.prd_cddepartamento 
                        ,	dp.prd_descricao 
                        ,   pr.pr_cdproduto
                        ,	pr.prb_cdprodutobluesoft
                        ,   pb.prb_descricao 
                        ,	case when pb.prb_status then 1 else 0 end as prb_status
                        ,   pl.prbt_icms_saida_cst
                        ,	nfce.icms_codigo_tributacao  
						,	ff.fc_figurafiscal_descricao 
                        

                        ,   cbenf_grupo.fc_cbenef_cd subgrupo_fc_cbenef_cd
                        ,   grupo_cbenef.fc_cbenef_objetivo

                        ,   pb.prb_blue_fc_cbenef_cd            as prb_blue_fc_cbenef_cd
                        ,   blue_cbenef.fc_cbenef_objetivo      as cbenef_blue_objetivo



                        ,   pr.pr_pag_fc_cbenef_cd              as pr_pag_fc_cbenef_cd
                        ,   pag_cbenef.fc_cbenef_objetivo       as cbenef_pag_objetivo
               

                from         tbproduto pr
                inner join   tbprodutobluesoft              pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                left join    tbpessoabluesoft               ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                left join    tbfc_regrafiscal_nfce_produto  nfce on nfce.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft            
                left join    tbfc_figurafiscal_produto      rf on rf.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                left join    tbfc_figurafiscal              ff on ff.fc_figurafiscal_cd = rf.fc_figurafiscal_cd 
                left join    tbproduto_subgrupo             sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
                left join    tbproduto_grupo                gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
                left join    tbproduto_secao                sc on sc.prs_cdsecao = gr.prs_cdsecao
                left join    tbproduto_departamento         dp on dp.prd_cddepartamento = sc.prd_cddepartamento
                left join    tbprodutobluesoft_tributacao   pl on pl.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk and pl.op_cdoperacao = 2
                left join    tbprodutobluesoft_tributacao   pdr on pdr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoft_pk and pdr.op_cdoperacao = 1 and pdr.prbt_regimetributario = '${parametro.distribuica_regime_tributacao}'  and pdr.prbt_cfop = '5102'          
                left join    tbestoquecusto                 ec on ec.pr_cdproduto = pr.pr_cdproduto 




  				left join (select 		cc.fc_cbenef_cd
									,	cc.icms_codigo_tributacao
									,	ss.prsg_cdsubgrupo
							from 		tbfc_cbenef_cst cc
							inner join  tbproduto_subgrupo ss on ss.fc_cbenef_cd = cc.fc_cbenef_cd
							) cbenf_grupo on cbenf_grupo.prsg_cdsubgrupo = sb.prsg_cdsubgrupo 
									and cbenf_grupo.icms_codigo_tributacao = nfce.icms_codigo_tributacao  


                left join    tbfc_cbenef                    grupo_cbenef on grupo_cbenef.fc_cbenef_cd = cbenf_grupo.fc_cbenef_cd
                left join    tbfc_cbenef                    pag_cbenef   on pag_cbenef.fc_cbenef_cd   = pr.pr_pag_fc_cbenef_cd
                left join    tbfc_cbenef                    blue_cbenef  on blue_cbenef.fc_cbenef_cd  = pb.prb_blue_fc_cbenef_cd

                where		1 = 1
                and       pb.prb_status = true
                and        (    nfce.icms_codigo_tributacao in (20,40) 
                             or pl.prbt_icms_saida_cst in ('020','040')
                            )		

select * from tbfc_regrafiscal_nfce_produto limit 10		



select fc_cbenef_cd from tbproduto_subgrupo where fc_cbenef_cd is not null and fc_cbenef_cd not in (select fc_cbenef_cd from tbfc_cbenef where fc_cbenef_bluesoft_cd is not null)
group by fc_cbenef_cd
select * from tbfc_cbenef where fc_cbenef_bluesoft_cd is not null


