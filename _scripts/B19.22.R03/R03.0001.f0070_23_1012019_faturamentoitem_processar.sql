-- FUNCTION: public.f0070_23_1012019_faturamentoitem_processar(integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_23_1012019_faturamentoitem_processar(integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_23_1012019_faturamentoitem_processar(
	vfaturamento_controle_seq integer,
	vnumeropedido integer,
	vnumeropedido_fv integer,
	vcdpessoabluesoft_cliente integer,
	vop_cdoperacao integer,
	vdf_nf_seq_blue integer)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
 declare  fator_entrada numeric(13,0);
 declare  percentual_desconto_financeiro numeric(13,2);
 declare  vdf_nf_seq_blue_origem int;
 declare  vdf_nf_seq_blue_origem_bonificado smallint;
begin
	

	fator_entrada = (select case when df_entrada_saida = 'E' then -1 else 1 end from tbdocumentofiscal where df_nf_seq_blue = vdf_nf_seq_blue);

	percentual_desconto_financeiro = (select case when coalesce(fa.descontofinanceiro,0) > 0 then fa.descontofinanceiro/100 else 0 end 
											from tbfaturamento_bluesoft fa 
											where 1 = 1
											    and fa.numeropedido = vnumeropedido
												and fa.numeropedido_fv = vnumeropedido_fv 
												and fa.op_cdoperacao = vop_cdoperacao
												and fa.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
												and fa.df_nf_seq_blue = vdf_nf_seq_blue
									);
	vdf_nf_seq_blue_origem = (select x.df_nf_seq_blue_origem from tbdocumentofiscalorigem x where x.df_nf_seq_blue = vdf_nf_seq_blue);									

	vdf_nf_seq_blue_origem_bonificado = 
			(	select 1 
				from tbdocumentofiscal xx 
				where xx.df_nf_seq_blue = vdf_nf_seq_blue_origem 
				and (df_nf_tipo = 34 or df_cfop_generico = '5910') 
	)

	;
	

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
			,	case when nf.df_nf_tipo = 34 
			              then 1 
						  else 
						  	   case when vdf_nf_seq_blue_origem_bonificado = 1
								    then 1
									else 0
									end 
						  end 
						
						as item_bonificado
			,	pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	i.valor_custo_com_icm  	* fator_entrada		as	ec_valor_custo_precificacao 
			,	i.valor_custo_com_icm 	* fator_entrada		as  ec_valor_custo_faturamento
			,	i.prb_cdprodutobluesoft  		as  embalagem_prb_cdproduto
			,	pb.prb_cdbarra_principal 		as  embalagem_cdbarra
			,	i.qtde_unitaria_faturada * fator_entrada		as  embalagem_qtde
			,	i.prb_fatorestoque * fator_entrada				as  embalagem_fatorestoque
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1) * fator_entrada  as numeric(13,2)) embalagem_ec_valor_custo_precificacao
			,	cast( i.valor_custo_com_icm / coalesce(i.prb_fatorestoque,1) * fator_entrada  as numeric(13,2)) embalagem_ec_valor_custo_faturamento
			,	i.qtde_unitaria_faturada * fator_entrada as embalagemestoque_qtde
			,	cast(i.valor_preco_tabela * i.qtde_faturada * fator_entrada as numeric(13,2)) as valortotal_faturamentobase
			,	cast(i.valor_preco * i.qtde_faturada * fator_entrada as numeric(13,2)) as valortotal_faturamento
			,	cast(i.valor_preco_aplicado * i.qtde_faturada * fator_entrada as numeric(13,2)) as valortotal_faturamentofiscal
			,	cast(i.valor_verba * fator_entrada as numeric(13,2)) as valortotal_subsidioscorrente
			
	from 		tbfaturamento_bluesoft_item 	i
	inner join  tbfaturamento_bluesoft 	 		fa 
												on 	fa.fat_blue_seq = i.fat_blue_seq 
												and fa.numeropedido = i.numeropedido 
												and fa.numeropedido_fv = i.numeropedido_fv 
												and fa.op_cdoperacao = i.op_cdoperacao
												and fa.cdpessoabluesoft_cliente = i.cdpessoabluesoft_cliente
												and fa.df_nf_seq_blue = i.df_nf_seq_blue

	
	inner join  tbfaturamento_controle 	 	ct on ct.numeropedido = fa.numeropedido 
										      and ct.numeropedido_fv = fa.numeropedido_fv 
											  and ct.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
	inner join  tbdocumentofiscal 			 	nf 
												on	nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente 
												and nf.df_nf_seq_blue = ct.df_nf_seq_blue
	
	
	inner join  tbfaturamento 				 f on f.faturamento_controle_seq = ct.faturamento_controle_seq
	inner join  tbfaturamentoorigem 		 o on o.faturamento_controle_seq = f.faturamento_controle_seq 
	inner join  tbproduto 					 pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario 
	inner join  tbprodutobluesoft			 pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
	where 		1 = 1
	and  ct.faturamento_controle_seq = vfaturamento_controle_seq
	and  ct.numeropedido = vnumeropedido
	and  ct.numeropedido_fv = vnumeropedido_fv
	and  ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
	and  ct.op_cdoperacao = vop_cdoperacao
	and  ct.df_nf_seq_blue = vdf_nf_seq_blue
	and  ct.processamento_pendente = 1

	and			not exists	( 	select 1 
								from 	tbfaturamentoitensembalagem xx 
								where 	1 = 1
								and 	xx.seqfaturamentoorigem = o.seqfaturamentoorigem
								and		xx.seqitem = i.fat_blue_item_seq 
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
	select 		i.seqfaturamentoorigem													as seqfaturamentoorigem
			,	 ROW_NUMBER() OVER (ORDER BY i.pr_cdproduto 	 DESC) as seqitem
			,	i.pr_cdproduto 															as pr_cdproduto
			,	sum(i.embalagemestoque_qtde) 											as embalagemestoqueqtde
			,	sum(i.embalagemestoque_qtde / coalesce(pr.pr_embalagemcompra_fator,1) ) 
																						as embalagemcompraqtde
			,	sum(i.ec_valor_custo_faturamento) 										as ec_valorcusto_faturamento_total
			,	sum(i.ec_valor_custo_precificacao) 										as ec_valorcusto_precificacao_total
			,	sum(i.valortotal_faturamentobase) 										as valortotalfaturamentobase
			,	sum(case i.item_bonificado 
					   when 0 then i.valortotal_faturamentofiscal - valortotal_faturamento
					   when 1 then -1 * i.valortotal_faturamentofiscal
					   end
					   )    		as valortotalsubsidioscorrentes
			,	sum(case i.item_bonificado 
					   when 0 then i.valortotal_faturamentofiscal
					   when 1 then 0
					   end
					   ) 									as valortotalfaturamento
			,	sum(case i.item_bonificado 
					   when 0 then cast( i.valortotal_faturamentofiscal * percentual_desconto_financeiro as numeric(13,2)) 
					   when 1 then 0
					   end
					   )	as valortotaldescontofinanceiro
			,	sum( case i.item_bonificado 
					   when 0 then i.valortotal_faturamentofiscal - cast( i.valortotal_faturamentofiscal * percentual_desconto_financeiro as numeric(13,2))
					   when 1 then 0
					   end
					) as valortotalfaturamentobruto
			,	0																		as valortotalsubsidiosaplicados
			,	sum( case i.item_bonificado 
					   when 0 then i.valortotal_faturamentofiscal - cast( i.valortotal_faturamentofiscal * percentual_desconto_financeiro as numeric(13,2))
					   when 1 then 0
					   end
					) as valortotalfaturamentoliquido /* INICIALMENTE O FATURAMENTO BRUTO É O FATURAMENTO LIQUIDO */
			,	case ct.fat_controle_tipo_cd
			         when 1 then 1 --> faturamento valido
					 when 2 then 4 --> estorno de faturamento
				end as statusfaturamentoitem
	from 		tbfaturamentoitensembalagem 	i
	inner join  tbfaturamentoorigem 			o   on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
	inner join  tbfaturamento_controle 	 		ct  on ct.faturamento_controle_seq = o.faturamento_controle_seq

	inner join  tbproduto 						pr	on pr.pr_cdproduto = i.pr_cdproduto 
	where		1 = 1 
	and  ct.faturamento_controle_seq = vfaturamento_controle_seq
	and  ct.numeropedido = vnumeropedido
	and  ct.numeropedido_fv = vnumeropedido_fv
	and  ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
	and  ct.op_cdoperacao = vop_cdoperacao
	and  ct.processamento_pendente = 1
	and			not exists (	select 1 
								from 	tbfaturamentoitens xx
								where   1 = 1
								and     xx.seqfaturamentoorigem = o.seqfaturamentoorigem 
								and     xx.pr_cdproduto = i.pr_cdproduto 
							)
	group by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	
			,	case ct.fat_controle_tipo_cd
			         when 1 then 1 --> faturamento valido
					 when 2 then 4 --> estorno de faturamento
				end
	order by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	asc			

	;

		

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;

insert into tbsistema_versao_script_db
	(versao_ecosystem, script_name)
		select 2019 , 'R3.f0070_23_1012019_faturamentoitem_processar.sql'
			WHERE NOT EXISTS (SELECT 1 FROM tbsistema_versao_script_db
								WHERE versao_ecosystem = 2019
								AND script_name = 'R3.f0070_23_1012019_faturamentoitem_processar.sql'
		)