update tbzanthus_tributacao_produto a
set    ncm_codigo = cast(b.ncm_codigo as int)
from   tbfc_regrafiscal_nfce_produto b
where  b.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
and    b.nfce_produto_tipo_cd = 1 
and    coalesce(a.ncm_codigo,0) = 0 
and    cast(b.ncm_codigo as int) <> 0 
and    b.prb_cdprodutobluesoft = 183558

select * from tbfc_regrafiscal_nfce_produto limit 10
select prb_cdprodutobluesoft, ncm_codigo from tbzanthus_tributacao_produto where prb_cdprodutobluesoft = 183558

select * from tbproduto_departamento 
select * from tbproduto_secao where prd_cddepartamento = 5 and prs_descricao LIKE 'BAZAR'
select * from tbproduto_grupo where prs_cdsecao = 18
select * from tbproduto_subgrupo where prg_cdgrupo = 133

226598
59225
update tbprodutobluesoft set prb_cdsubgrupo = 352 where prb_cdprodutobluesoft_pk in (226598, 59225)

select * from tbfc_figurafiscal where fc_figurafiscal_cd = 561
select * from tbfc_regrafiscal where fc_figurafiscal_cd = 561 and tipo = 'SAIDA'
select prb_cdprodutobluesoft_pk, prb_ncm, prb_status, prb_cdsubgrupo from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 59225


select prb_cdprodutobluesoft, ncm_codigo, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 59225  limit 12
select prb_cdprodutobluesoft, codigo_beneficio_fiscal from tbzanthus_tributacao_produto where prb_cdprodutobluesoft = 183558  limit 12
select prb_cdprodutobluesoft, cod_ncm, codigo_beneficio_fiscal  from tbzanthustab_mercadoria where prb_cdprodutobluesoft = 183558  limit 12
select prb_cdprodutobluesoft, *  from tbzanthustab_regra_icms where prb_cdprodutobluesoft = 59225  limit 12


select 		i.pr_cdproduto
		  , i.prb_cdprodutobluesoft 
		  , prb.prb_cdprodutobluesoftunitario 
		  , i.cod_mercadoria 
from 		TbZanthustab_produto_decomposicao_insum i
left join 	tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
where		prb.prb_status = 'true'

select      pr.pr_cdproduto
		,	i.prb_cdprodutobluesoftunitario 	
		,	m.cod_mercadoria 
from     	tbintegracao_produto i
inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoftunitario
inner join  tbzanthustab_mercadoria m on m.pr_cdproduto = pr.pr_cdproduto 
where    	i.integracao_tipo_cd = 20008501
and         i.integracao_status_cd = 2








update tbprodutobluesoft a
set    prb_ncm = b.ncm_codigo
from   tbfc_regrafiscal_nfce_produto b 
where  a.prb_cdprodutobluesoft_pk = b.prb_cdprodutobluesoft 
and    lpad( coalesce(a.prb_ncm, '0') , 8, '0') !=  lpad( coalesce(b.ncm_codigo, '0') , 8, '0')
and    lpad( coalesce(a.prb_ncm, '0') , 8, '0') = '00000000'
and    lpad( coalesce(b.ncm_codigo, '0') , 8, '0') != '00000000'
