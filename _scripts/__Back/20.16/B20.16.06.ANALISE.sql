





SELECT * FROM TbZanthustab_produto_decomposicao WHERE prb_cdprodutobluesoft = 199620

SELECT * FROM TbZanthustab_produto_decomposicao_insum 
where cod_mercadoria = '00000000000962222'


select  pr_cdproduto 
    ,   pr_descricao 
    ,   pr_embalagemestoque 
    ,   pr_embalagemcompra_fator 
    ,   pr_cdbarra_principal 
    ,   coalescE(dtlog_insert, '1900-01-01 01:01:01') as dtlog_insert
    ,   coalesce(dtlog_update, '1900-01-01 01:01:01') as dtlog_update
    ,   coalescE(dtlog_update_api, '1900-01-01 01:01:01') as dtlog_update_api
    ,   cdpessoabluesoft_fabricante 
    ,   prb_cdproduto_compra_padrao 
    ,   prsg_cdsubgrupo 
    ,   coalesce(pr_cesta,'false') as pr_cesta 
    ,   pr_status_comercial_preco_inativo 
from    tbproduto limit 10



select      em.pr_cdproduto            as pr_cdproduto
    ,       em.prb_cdprodutobluesoft   as prb_cdprodutobluesoft
    ,       pb.prb_descricao           as prb_descricao 
    ,       em.pre_embalagem           as pre_embalagem
    ,       em.pre_fatorpreco          as pre_fatorpreco
    ,       em.pre_fatorestoque        as pre_fatorestoque
    ,       em.pre_status              as pre_status 
    ,       em.dtlog_insert            as dtlog_insert
    ,       em.dtlog_update            as dtlog_update
    ,       em.dtlog_update_api        as dtlog_update_api
    ,       em.cdbarra_principal       as cdbarra_principal
    ,       em.pre_embalagem_descricao as pre_embalagem_descricao
from        tbprodutoembalagem em 
left join   tbprodutobluesoft  pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft  
where   pr_cdproduto = 43


select 		m.pr_cdproduto
		,	m.prb_cdprodutobluesoft
		,	m.pre_embalagem_descricao 
		,	g.preg_cdbarra 
		, 	m.pre_embalagem 
from 		tbprodutoembalagem_gtins g
inner join  tbprodutoembalagem m on m.pr_cdproduto = g.pr_cdproduto 
				and m.prb_cdprodutobluesoft = g.prb_cdprodutobluesoft
where 		g.pr_cdproduto = 43


select * from tbprodutoembalagem limit 10
select * from tbprodutoembalagem_gtins limit 10

limit 10