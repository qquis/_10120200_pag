--select * from tbfc_regrafiscal_nfce_produto limit 10
--select * from tbfc_figurafiscal_produto
--select * from tbprodutobluesoft limit 10

select * from tbproduto_composicao limit 10

select 	c.prb_cdprodutobluesoft_unitario
, 		c.prb_cdprodutobluesoft 
,		pb.prb_cdbarra_principal 
,		c.prc_qtde
,		c.prc_percentual_composicao
,		c.prc_percentual_composicao_qtde 
,		c.prc_composicao_qtde_total 
,		c.dtlog_insert
,		c.dtlog_update 
,		f.fc_figurafiscal_cd
,		f.regrafiscal_nfce 
from 		tbproduto_composicao c
left join   tbfc_figurafiscal_produto f on f.prb_cdprodutobluesoft = c.prb_cdprodutobluesoft 
left join  	tbfc_regrafiscal_nfce_produto nfce on nfce.prb_cdprodutobluesoft = c.prb_cdprodutobluesoft
left join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = c.prb_cdprodutobluesoft 



select 			t.tab_pre_descricao
			, 	x.prb_cdprodutobluesoft 
			,	x.pre_embalagem 
			,	x.prc_valor 
from 			tbpreco_aplicacao x 
left join 		tbtabela_preco t on t.tab_pre_cd = x.tab_pre_cd 
where x.prb_cdprodutobluesoft = 4281 limit 10

select * from tbtabela_preco




select   pr.pr_cdproduto 
                                ,   pr.prb_cdprodutobluesoft
                                ,   pr.pr_descricao 
                                ,   pr.pr_embalagemestoque 
                                ,   pr.pr_embalagemcompra
                                ,   pr.pr_embalagemcompra_fator 
                                ,   pr.pr_cdbarra_principal 
                                ,   case when pr.pr_status then 1 else 0 end as pr_status
                                ,   coalescE(pr.dtlog_insert, '1900-01-01 01:01:01') as dtlog_insert
                                ,   coalesce(pr.dtlog_update, '1900-01-01 01:01:01') as dtlog_update
                                ,   coalescE(pr.dtlog_update_api, '1900-01-01 01:01:01') as dtlog_update_api
                                ,   pr.cdpessoabluesoft_fabricante 
                                ,   pr.prb_cdproduto_compra_padrao 
                                ,   pr.prsg_cdsubgrupo 
                                ,   case when coalesce(pr.pr_cesta,'false') = 'true' then 1 else 0 end as pr_cesta 
                                ,   coalesce(pr.pr_status_comercial_preco_inativo, 0) as pr_status_comercial_preco_inativo
                                ,   pb.prb_cdprodutobluesoftunitario as prb_cdprodutobluesoftunitario
                                ,   pb.prb_descricao as prb_descricao
                                ,   fp.fc_figurafiscal_cd
								,	f.fc_figurafiscal_descricao
                                ,   fp.regrafiscal_nfce
                                ,   fp.fc_figurafiscal_versao 



                            from    tbproduto pr
                            left join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                            left join tbfc_figurafiscal_produto fp     on fp.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
							left join tbfc_figurafiscal f on f.fc_figurafiscal_cd = fp.fc_figurafiscal_cd
                            left join tbfc_regrafiscal_nfce_produto nfce    on nfce.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft


                            where   1 = 1

select  * from tbprodutobluesoft_gtins limit 10
select * from tbprodutoembalagem_gtins limit 10
select * from tbzanthus_tributacao_nfce
select 	g.pr_cdproduto 
	,	g.prb_cdprodutobluesoft 
	,	g.preg_cdbarra
	,	gb.prbg_cdbarra_pk
	,	gb.prbg_embalagemdescricao 
	,	pb.prb_cdprodutobluesoftunitario 
	,	z.zanthus_tributacao_nfce_seq 
	,	z.api_regra_fiscal	
	,	z.ncm_codigo
	,	z.cest
	,	z.pis_cst
	,	z.pis_aliquota
	,	z.cofins_cst
	,	z.cofins_aliquota
	,	z.icms_cst
	,	z.icms_aliquota
	,	z.icms_reducao 
	,	z.icms_aliquota_final 
	,	z.r_cod_sit_tributaria_ibs_cbs

from 		tbprodutoembalagem_gtins g 					
left join 	tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = g.prb_cdprodutobluesoft 
left join   tbprodutobluesoft_gtins gb on gb.prbg_cdbarra_pk = g.preg_cdbarra 
left join   tbzanthus_tributacao_nfce z on lpad(z.cod_mercadoria, 17, '0') = lpad(g.preg_cdbarra, 17, '0')
where 1 = 1
and   g.pr_cdproduto = 43
limit 10

