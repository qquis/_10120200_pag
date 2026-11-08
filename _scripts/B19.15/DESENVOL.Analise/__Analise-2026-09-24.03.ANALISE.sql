select  prb_cdprodutobluesoft 
	,	prb_descrica
	from tbfc_regrafiscal_nfce_produto
	where nfce_produto_tipo_cd = 3


select 	prb_cdprodutobluesoft_pk as cd
,		prb_descricao 
, 		prb_cdprodutobluesoftunitario as unit
, 		prb_ncm
, 		prb_cest
, 		dtlog_insert as ins
, 		dtlog_update as up 
from tbprodutobluesoft
where dtlog_update >= '2026-09-01 01:01:01'
and prb_cdprodutobluesoft_pk = 229404


select * from tbprodutobluesoft limit 10
select * from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 90764
select * from tbproduto_subgrupo
select * from tbproduto_secao
select * from tbproduto_departamento


select prb_cdprodutobluesoft, nfce_produto_tipo_cd, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 90764
select prb_cdprodutobluesoft, nfce_produto_tipo_cd, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 80086
limit 10


select nfce_produto_tipo_cd, count(*) from tbfc_regrafiscal_nfce_produto group by nfce_produto_tipo_cd
select * from tbzanthus_tributacao_produto limit 10
select * from tbzanthus_tributacao_icms_pdv

select * from tbfc_regrafiscal_nfce_produto where nfce_produto_tipo_cd = 3 and api_ncm = 0








