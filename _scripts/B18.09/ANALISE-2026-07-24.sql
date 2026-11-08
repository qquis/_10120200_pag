select * from tbfc_cbenef_produtobluesoft
select * from tbfc_cbenef_cst
select * from tbzanthus_tributacao_nfce limit 10
select * from tbfc_regrafiscal_nfce_produto
select * from tbprodutobluesoft where prb_blue_fc_cbenef_cd = 'SP020740';

select 		prb.prb_cdprodutobluesoftunitario 
	,		prn.prb_cdprodutobluesoft
	,  		prn.fc_cbenef_cd 
	,		cst.icms_codigo_tributacao 
	,		n.prb_cdprodutobluesoft 
	,		n.icms_cst 
	,		n.codigo_beneficio_fiscal  
from   		tbfc_cbenef_produtobluesoft prn
inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = prn.prb_cdprodutobluesoft
inner join 	tbfc_cbenef_cst cst on cst.fc_cbenef_cd = prn.fc_cbenef_cd
inner join  tbzanthus_tributacao_nfce   n on n.prb_cdprodutobluesoft = prn.prb_cdprodutobluesoft 
	and cast(n.icms_cst as varchar(2)) = cast(cst.icms_codigo_tributacao as varchar(2))
where       prb.prb_cdprodutobluesoftunitario = prn.prb_cdprodutobluesoft	
order by 	prb.prb_cdprodutobluesoftunitario 
	,		prn.prb_cdprodutobluesoft


select * from tbproduto limit 10
update tbproduto
set pr_pag_fc_cbenef_cd = null
where pr_pag_fc_cbenef_cd = 'SP099999'

update tbprodutobluesoft
set    prb_blue_fc_cbenef_cd = null 
where  prb_blue_fc_cbenef_cd = 'SP099999';

select * from tbprodutobluesoft  limit 10


update tbprodutobluesoft x 
   set prb_blue_fc_cbenef_cd = a.fc_cbenef_cd
from ( 
			select 		prb.prb_cdprodutobluesoftunitario 
				,  		prn.fc_cbenef_cd 
			from   		tbfc_cbenef_produtobluesoft prn
			inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = prn.prb_cdprodutobluesoft
			inner join 	tbfc_cbenef_cst cst on cst.fc_cbenef_cd = prn.fc_cbenef_cd
			inner join  tbzanthus_tributacao_nfce   n on n.prb_cdprodutobluesoft = prn.prb_cdprodutobluesoft 
				and cast(n.icms_cst as varchar(2)) = cast(cst.icms_codigo_tributacao as varchar(2))
			where       prb.prb_cdprodutobluesoftunitario = prn.prb_cdprodutobluesoft	
			order by 	prb.prb_cdprodutobluesoftunitario 
				,		prn.prb_cdprodutobluesoft
		) a 
where 1 = 1
and   a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoftunitario 
and   a.fc_cbenef_cd =  'SP020740'


select cod_tributacao_pdv, icms_cst, cast(icms_aliquota as numeric(13,2)) as aliq, icms_reducao, icms_aliquota_final, count(*) as qtde 
from tbzanthus_tributacao_nfce 
group by cod_tributacao_pdv, icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final 
order by icms_cst, icms_aliquota




