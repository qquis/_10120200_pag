select 	  lpad(nfce.preg_cdbarra,14, '0')
		, nfce.pr_cdproduto
		, nfce.prb_cdprodutobluesoft 
		, blue.prb_cdprodutobluesoft
		, em.pr_cdproduto
		, em.prb_cdprodutobluesoft
from	  tbzanthus_tributacao_nfce nfce
left join tbprodutobluesoft_gtins blue on lpad(blue.prbg_cdbarra_pk,14,'0') = lpad(nfce.preg_cdbarra,14, '0')
left join tbprodutoembalagem_gtins em on lpad(em.preg_cdbarra, 14,'0') =  lpad(nfce.preg_cdbarra,14, '0')
where     1 = 1
and   (    coalesce(em.prb_cdprodutobluesoft,0) = 0 
       or coalesce(blue.prb_cdprodutobluesoft,0) = 0 )


select 		pr.prb_cdprodutobluesoft
		,	pb.prb_cdprodutobluesoft_pk 
		,	pr.pr_pag_fc_cbenef_cd
		,	pb.prb_blue_fc_cbenef_Cd  
		,	sg.fc_cbenef_cd 
		,   CASE WHEN COALESCE(pb.prb_blue_fc_cbenef_Cd,'') != '' 
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
where		1 = 1
AND         PR.PR_CDPRODUTO = 5282

select 		nfce.prb_cdprodutobluesoft
	,		nfce.icms_cst 
	,		cbenef.prb_cdprodutobluesoft 
	,		cbenef.fc_cbenef_cd
	
from 		tbzanthus_tributacao_nfce nfce
left join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = nfce.prb_cdprodutobluesoft 
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
where 		  nfce.pr_cdproduto = 5282



select prb_cdprodutobluesoft, cod_mercadoria, codigo_beneficio_fiscal from TbZanthusTab_Mercadoria 
where pr_cdproduto = 5282
limit 10 

select version()

