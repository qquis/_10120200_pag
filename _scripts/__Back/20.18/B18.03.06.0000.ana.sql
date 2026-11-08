select version()
select prb_cdprodutobluesoft_pk, prb_descricao, prb_status
from tbprodutobluesoft where prb_status = true and prb_descricao = 1






SELECT pr_cdproduto, 
       prb_cdprodutobluesoft, 
	   descricao, 
       coalesce(codigo_beneficio_fiscal,''), 
	   cod_situacao_tributaria
FROM   tbzanthustab_mercadoria 
where  cod_situacao_tributaria in ('40','20')
and  coalesce(codigo_beneficio_fiscal,'') != ''