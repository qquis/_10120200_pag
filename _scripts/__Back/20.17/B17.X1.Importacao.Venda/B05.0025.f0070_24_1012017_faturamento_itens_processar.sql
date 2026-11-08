-- FUNCTION: public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_24_1012017_faturamento_itens_processar(
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
	inner join  tbfaturamento_controle 	 		ct on ct.faturamento_controle_seq = o.faturamento_controle_seq
	inner join  tbproduto 						pr	on pr.pr_cdproduto = i.pr_cdproduto 
	where		1 = 1 
	and   		ct.faturamento_controle_seq = vfaturamento_controle_seq
	and			not exists (	select 1 
								from 	tbfaturamentoitens 		xx
								INNER JOIN tbfaturamentoorigem 	ox on ox.seqfaturamentoorigem = xx.seqfaturamentoorigem
								INNER JOIN tbfaturamento 		fx on fx.seqfaturamento = ox.seqfaturamento 
								where   1 = 1
								and     xx.seqfaturamentoorigem = o.seqfaturamentoorigem 
								and     xx.pr_cdproduto = i.pr_cdproduto 
								and     fx.faturamento_controle_seq = vfaturamento_controle_seq
							)
	group by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	
	order by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	asc			

	;
	
	/*
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
	*/


	
		

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;
