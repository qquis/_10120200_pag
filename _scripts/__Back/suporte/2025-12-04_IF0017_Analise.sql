

select 		i.prb_cdprodutobluesoft 
		,	f.numeropedido
		,	f.numeropedido_fv 

		,	pr.pr_cdproduto						as cdproduto
		,	pr.prb_cdprodutobluesoft 			as cdprodutobluesoft 
		,	pr.pr_descricao						as descricao
		,	pr.pr_embalagemestoque				as embp
		,	pr.pr_embalagemcompra				as empc
		,	pr.pr_embalagemcompra_fator			as emf
		,	pb.prb_cdpessoabluesoft_fabricante 		as fabric
		,	pb.prb_embalagemcompra 				as fabric_emb_cmp 
		,	pb.prb_embalagemcompra_qtdeunitaria as fabric_emb_cmp_unit
		,	pb.prb_cdproduto_compra_padrao		as fabric_cd_prod
		,	pc.prb_fatorestoque					as fabric_cd_prod_fator
		,	i.prb_cdprodutobluesoft_unitario 				as cdprod_unit
		,	i.prb_cdprodutobluesoft							as cdprod
		,	i.prb_embalagem									as emb
		,	i.prb_fatorestoque 								as fator
		
		,	cast(i.faturamento_fv_i_qtde_solicitado 	as numeric(13,1))		as qtde_solicitado
		,	cast(i.faturamento_fv_i_qtde_solicitado * i.prb_fatorestoque   as numeric(13,1)) as qtde_unit 
		,	cast(i.faturamento_fv_i_qtde_solicitado / pc.prb_fatorestoque   as numeric(13,1))	 as qtde_cmp 		
from 		tbfaturamento_forca_venda			f
inner join 	tbfaturamento_forca_venda_origem	o on o.faturamento_fv_seq = f.faturamento_fv_seq  and f.numeropedido = f.numeropedido and f.numeropedido_fv = o.numeropedido_fv
inner join  tbfaturamento_forca_venda_item		i on i.faturamento_fv_origem_seq = o.faturamento_fv_origem_seq 
inner join  tbfaturamento_forca_venda_status 	s on s.faturamento_fv_status_cd = f.faturamento_fv_status_cd
inner join  tbproduto							pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario
inner join  tbprodutobluesoft					pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft_unitario
inner join  tbprodutobluesoft					pc on pc.prb_cdprodutobluesoft_pk = pb.prb_cdproduto_compra_padrao
where 		f.faturamento_fv_status_cd in (20,25,27,30,40,45,50)
and i.prb_cdprodutobluesoft = 54502


select * from tbfaturamento_forca_venda limit 10
faturamento_fv_data_emissao







select 		

			pr.pr_cdproduto						as cdproduto
		,	pr.prb_cdprodutobluesoft 			as cdprodutobluesoft 

		

		,	sum(cast(i.faturamento_fv_i_qtde_solicitado / pc.prb_fatorestoque   as numeric(13,1)))	 as qtde_cmp 		
from 		tbfaturamento_forca_venda			f
inner join 	tbfaturamento_forca_venda_origem	o on o.faturamento_fv_seq = f.faturamento_fv_seq  and f.numeropedido = f.numeropedido and f.numeropedido_fv = o.numeropedido_fv
inner join  tbfaturamento_forca_venda_item		i on i.faturamento_fv_origem_seq = o.faturamento_fv_origem_seq 
inner join  tbfaturamento_forca_venda_status 	s on s.faturamento_fv_status_cd = f.faturamento_fv_status_cd
inner join  tbproduto							pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario
inner join  tbprodutobluesoft					pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft_unitario
inner join  tbprodutobluesoft					pc on pc.prb_cdprodutobluesoft_pk = pb.prb_cdproduto_compra_padrao
where 		f.faturamento_fv_status_cd in (20,25,27,30,40,45,50)
and i.prb_cdprodutobluesoft = 54502
group by pr.pr_cdproduto

,	pr.prb_cdprodutobluesoft 

select prb_cdprodutobluesoft_pk, prb_descricao, prb_cdproduto_compra_padrao, * from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 54502
select * from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 88474
--select * from tbfaturamento_forca_venda_item limit 10