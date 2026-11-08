-- FUNCTION: public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_23_1012017_faturamento_itens_embalagem_processar(
	vfaturamento_controle_seq integer,
	vop_cdoperacao integer,
	vnumeropedido integer,
	vdf_nf_seq_blue integer,
	vsat_ecf integer,
	vcupomfiscal integer,
	vcdpessoabluesoft_cliente integer)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
begin
	


	insert into tbfaturamentoitensembalagem 
			(
					seqfaturamentoorigem
				,	seqitem
				,	item_bonificado
				,	pr_cdproduto
				,	prb_cdprodutobluesoft 
				,	ec_valor_custo_precificacao 
				,	ec_valor_custo_faturamento
				,	embalagem_prb_cdproduto 
				,	embalagem_cdbarra
				,	embalagem_qtde 
				,	embalagem_fatorestoque 
				,	embalagem_ec_valor_custo_precificacao
				,	embalagem_ec_valor_custo_faturamento
				,	embalagemestoque_qtde 
				,	valortotal_faturamentobase 
				,	valortotal_faturamento
				,	valortotal_faturamentofiscal
				,	valortotal_subsidioscorrentes 
			)
	
	
	select 		o.seqfaturamentoorigem 
			,	i.fat_blue_item_seq 
			,	case when FA.FAT_BLUE_TIPO_CD = 20 then 1 else 0 end as item_bonificado
			,	pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	i.valor_custo_com_icm  			as	ec_valor_custo_precificacao 
			,	i.valor_custo_com_icm 			as  ec_valor_custo_faturamento
			,	i.prb_cdprodutobluesoft 		as  embalagem_prb_cdproduto
			,	pb.prb_cdbarra_principal 		as  embalahem_cdbarra
			,	i.qtde_unitaria_faturada		as  embalagem_qtde
			,	i.prb_fatorestoque 				as  embalagem_fatorestoque
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_precificacao
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1)  as numeric(13,2)) embalagem_ec_valor_custo_faturamento
			,	i.qtde_unitaria_faturada as embalagemestoque_qtde
			,	cast(i.valor_preco_tabela * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentobase
			,	cast(i.valor_preco * i.qtde_faturada as numeric(13,2)) as valortotal_faturamento
			,	cast(i.valor_preco_aplicado * i.qtde_faturada as numeric(13,2)) as valortotal_faturamentofiscal
			,	cast(i.valor_verba as numeric(13,2)) as valortotal_subsidioscorrente
			
	from 		tbfaturamento_bluesoft_item 	i
	inner join  tbfaturamento_bluesoft 	 		fa 
												on 	fa.fat_blue_seq = i.fat_blue_seq 
												and fa.numeropedido = i.numeropedido 
												and fa.numeropedido_fv = i.numeropedido_fv 
												and fa.op_cdoperacao = i.op_cdoperacao
												and fa.cdpessoabluesoft_cliente = i.cdpessoabluesoft_cliente
	
	inner join  tbfaturamento_controle 	 	ct on ct.numeropedido = fa.numeropedido 
										      and ct.numeropedido_fv = fa.numeropedido_fv 
											  and ct.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
	inner join  tbfaturamento 				 f on f.faturamento_controle_seq = ct.faturamento_controle_seq
	inner join  tbfaturamentoorigem 		 o on o.faturamento_controle_seq = f.faturamento_controle_seq 
	inner join  tbproduto 					 pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario 
	inner join  tbprodutobluesoft			 pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
	where 		1 = 1
	--and			ct.numeropedido = 213289
	and			f.faturamento_controle_seq = vfaturamento_controle_seq

	and			not exists	( 	select 		1 
								from 		tbfaturamentoitensembalagem xx 
								inner join 	tbfaturamentoorigem 		ox on ox.seqfaturamentoorigem = xx.seqfaturamentoorigem
								inner join  tbfaturamento 				fx on fx.seqfaturamento = ox.seqfaturamento 
								where 	1 = 1
								and 	xx.seqfaturamentoorigem = o.seqfaturamentoorigem
								and		xx.seqitem = i.fat_blue_item_seq 
								and     fx.faturamento_controle_seq = vfaturamento_controle_seq
							)
	;

	insert into tbfaturamentoitens 
			(
					seqfaturamentoorigem
				,	seqitem 
				,	pr_cdproduto 
				,	embalagemestoqueqtde 
				,	embalagemcompraqtde 
				,	ec_valorcusto_faturamento_total 
				,	ec_valorcusto_precificacao_total 
				,	valortotalfaturamentobase 
				,	valortotalsubsidioscorrentes
				,	valortotalfaturamento
				,	valortotaldescontofinanceiro 
				,	valortotalfaturamentobruto
				,	valortotalsubsidiosaplicados
				,	valortotalfaturamentoliquido
				,	statusfaturamentoitem 
			)
	select 		i.seqfaturamentoorigem								as seqfaturamentoorigem
			,	 ROW_NUMBER() OVER (ORDER BY i.pr_cdproduto 	 DESC) as seqitem
			,	i.pr_cdproduto 										as pr_cdproduto
			,	sum(i.embalagemestoque_qtde) 						as embalagemestoqueqtde
			,	sum(i.embalagemestoque_qtde / coalesce(pr.pr_embalagemcompra_fator,1) ) 
																	as embalagemcompraqtde
			,	sum(i.ec_valor_custo_faturamento) 					as ec_valorcusto_faturamento_total
			,	sum(i.ec_valor_custo_precificacao) 				as ec_valorcusto_precificacao_total
			,	sum(i.valortotal_faturamentobase) 					as valortotalfaturamentobase
			,	sum(i.valortotal_faturamentofiscal - valortotal_faturamento) 
																	as valortotalsubsidioscorrentes
			,	sum(i.valortotal_faturamentofiscal) 				as valortotalfaturamento
			,	0 													as valortotaldescontofinanceiro
			,	sum(i.valortotal_faturamentofiscal) 				as valortotalfaturamentobruto
			,	0													as valortotalsubsidiosaplicados
			,   sum(i.valortotal_faturamentofiscal)				as valortotalfaturamentoliquido
			,	1 
	from 		tbfaturamentoitensembalagem 	i
	inner join  tbfaturamentoorigem 			o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
	inner join  tbfaturamento_controle 	 	ct on ct.faturamento_controle_seq = o.faturamento_controle_seq
	inner join  tbproduto 						pr	on pr.pr_cdproduto = i.pr_cdproduto 
	where		1 = 1 
	and   		ct.dataemissao = '2026-02-05'
	and			not exists (	select 1 
								from 	tbfaturamentoitens 		xx
								INNER JOIN tbfaturamentoorigem 	ox on ox.seqfaturamentoorigem = xx.seqfaturamentoorigem
								INNER JOIN tbfaturamento 		fx on fx.seqfaturamento = ox.seqfaturamento 
								where   1 = 1
								and     xx.seqfaturamentoorigem = o.seqfaturamentoorigem 
								and     xx.pr_cdproduto = i.pr_cdproduto 
									and     fx.dataemissao = '2026-02-05'
							)
	group by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	
	order by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	asc			

	;
	
	valor_total_faturamento:= (	select sum(i.valortotalfaturamento) 
										FROM 		tbfaturamentoitens		i 
										inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
										inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
										inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
										WHERE 	1 = 1 
										AND		ct.numeropedido = vnumeropedido 
										and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
										and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
									)
	;


	
		

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;
