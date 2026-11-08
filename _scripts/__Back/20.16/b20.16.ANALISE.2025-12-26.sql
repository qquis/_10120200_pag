-----delete from tbzanthus_tributacao_nfce

SELect * from tbzanthus_tributacao_nfce 
WHERE 1 = 1
and prb_cdprodutobluesoft = 4816
and COD_MERCADORIA LIKE '%481618';

select * from tbfc_regrafiscal_nfce_produto 
WHERE 1= 1
--and prb_cdprodutobluesoft = 1761
and icms_codigo_origem = 0 
and icms_codigo_tributacao = 0
and icms_aliquota = 0


and icms_codigo_origem = 0 
and icms_codigo_tributacao = 0
and icms_aliquota = 0




SELECT COD_MERCADORIA, DESCRICAO, COD_TRIBUTACAO_MERCADORIA, ALIQUOTA_ICMS, PERCENTUAL_REDUZ_B_CALCULO, COD_SITUACAO_TRIBUTARIA  
FROM TAB_MERCADORIA WHERE COD_MERCADORIA LIKE '%481618'


select * from tbzanthus_tributacao_nfce limit 10

SELECT * FROM tbestoquecusto LIMIT 10

SELect x.api_regra_fiscal
	,	x.prb_cdprodutobluesoft 
	,	x.pr_cdproduto
	,	x.prb_cdprodutobluesoft 
	,	x.cod_mercadoria 
	,	x.cod_tributacao_pdv 
	,	p.pr_cdproduto 
	,	p.pr_descricao 
	,	em.prb_cdprodutobluesoft 
	,	em.pre_embalagem 
	,	es.ec_embalagemestoque_qtde
	,	x.*
from tbzanthus_tributacao_nfce x 
left join tbprodutoembalagem em on em.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft
left join tbproduto p on p.pr_cdproduto = em.pr_cdproduto 
left join tbestoquecusto es on es.pr_cdproduto = em.pr_cdproduto 
WHERE 1 = 1
and x.cod_tributacao_pdv = 99
and x.prb_cdprodutobluesoft <> 0 
and es.ec_embalagemestoque_qtde > 0 
and x.prb_cdprodutobluesoft = 219516


SELect 
		p.pr_cdproduto 
	,	p.prb_cdprodutobluesoft
	,	p.pr_descricao 
	
from tbzanthus_tributacao_nfce x 
left join tbprodutoembalagem em on em.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft
left join tbproduto p on p.pr_cdproduto = em.pr_cdproduto 
left join tbestoquecusto es on es.pr_cdproduto = em.pr_cdproduto 
WHERE 1 = 1
and x.cod_tributacao_pdv = 99
and x.prb_cdprodutobluesoft <> 0 
and es.ec_embalagemestoque_qtde <> 0 
group by p.pr_cdproduto 
	,	p.pr_descricao 
order by p.pr_descricao	

select * from tbfc_regrafiscal_nfce_produto 
WHERE 1= 1
and prb_cdprodutobluesoft = 145879

select * from tbzanthus_tributacao_nfce 
where 1 = 1 
and prb_cdprodutobluesoft = 4281
and icms_cst = '00'
	  and icms_aliquota = 0 

SELECT * FROM TBPRODUTOBLUESOFT_TRIBUTACAO WHERE PRB_CDPRODUTOBLUESOFT = 4281



UPDATE	TAB_MERCADORIA 
	SET 

		cod_sit_tributaria_ibs_cbs = 200
	,	cod_class_tributaria_ibs_cbs = 200014
	,	per_aliquota_ibs_uf = 0.1000
	,	per_reducao_aliquota_ibs_uf = 100.0000
	,	per_diferimento_ibs_mun = 0.0000
	,	per_aliquota_ibs_mun = 0 
	,	per_reducao_aliquota_ibs_mun = 100.0000
	,	per_aliquota_cbs = 0.9000
	,	per_diferimento_cbs = 0.0000
	,	per_reducao_aliquota_cbs = 100
	,	per_cred_presumido_ibs_mono  = 0
	,	per_cred_presumido_cbs_mono = 0
	,	info_complementar = 'I'
where 	1= 1
--and    cod_mercadoria like '%500715'
and	  cod_sit_tributaria_ibs_cbs is null 
and   origem_cadastro is null
and   per_aliquota_ibs_uf is null
and	  per_aliquota_cbs is null 
and  cod_mercadoria in (select 	lpad(i.m43ah, 17, '0') from zan_m43 i
													where	1= 1
													and		i.m00af >= '2025-12-01'
									)





SELECT 	cod_mercadoria 
	,	cod_sit_tributaria_ibs_cbs 
	,	cod_class_tributaria_ibs_cbs 
	,	per_aliquota_ibs_uf
	,	per_reducao_aliquota_ibs_uf 
	,	per_diferimento_ibs_mun 
	,	per_aliquota_ibs_mun 
	,	per_reducao_aliquota_ibs_mun 
	,	per_aliquota_cbs 
	,	per_diferimento_cbs
	,	per_reducao_aliquota_cbs 
	,	per_cred_presumido_ibs_mono 
	,	per_cred_presumido_cbs_mono 
	,	origem_cadastro = null 
FROM TAB_MERCADORIA 
where 	1 = 1 
--and   cod_mercadoria like '%500715'
and		(cod_sit_tributaria_ibs_cbs is null or origem_cadastro is null)
and  cod_mercadoria in (select 	lpad(i.m43ah, 17, '0') from zan_m43 i
													where	1= 1
													and		i.m00af >= '2025-01-01'
									)
and   per_aliquota_ibs_uf is null



select COD_MERCADORIA, ALIQUOTA_ICMS, COD_SITUACAO_TRIBUTARIA from tab_mercadoria where cod_mercadoria like '%102026'