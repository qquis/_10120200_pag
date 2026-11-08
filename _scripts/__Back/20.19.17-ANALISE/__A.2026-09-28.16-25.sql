select * from tbproduto_composicao where prb_cdprodutobluesoft_unitario = 223100

select * from tbzanthus_tributacao_icms_pdv

SELECT prb_cdprodutobluesoft,  flg_revenda, count(*)

FROM TbZanthusTab_Regra_Icms  X
WHERE prb_cdprodutobluesoft in (
select  
		cesta.prb_cdprodutobluesoft
from 	tbprodutobluesoft_composicao cesta
left join tbproduto pr on pr.prb_cdprodutobluesoft = cesta.prb_cdprodutobluesoft 

where prb_cdprodutobluesoft_unitario = 223100

)
group by prb_cdprodutobluesoft,  flg_revenda
order by prb_cdprodutobluesoft,  flg_revenda

LIMIT 10

select  cesta.prb_cdprodutobluesoft_unitario
	,	cesta.prb_cdprodutobluesoft
	,	pr.pr_cdproduto
	,	pr.prb_cdprodutobluesoft 
from 	tbprodutobluesoft_composicao cesta
left join tbproduto pr on pr.prb_cdprodutobluesoft = cesta.prb_cdprodutobluesoft 

where prb_cdprodutobluesoft_unitario = 223100


select * from TbZanthustab_produto_decomposicao
select  *from TbZanthustab_produto_decomposicao_insum