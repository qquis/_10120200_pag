-- FUNCTION: public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0070_23_1012018_faturamentoitem_processar(
	vfat_controle_tipo_cd integer,
	vseqfaturamento_uuid character varying,
	vop_cdoperacao integer,
	vnumeropedido integer,
	vnumeropedido_fv integer,
	vdf_nf_seq_blue integer,
	vsat_ecf integer,
	vcupomfiscal integer,
	vcdpessoabluesoft_cliente integer,
	vreprocessaritem integer,
	vfaturamento_controle_seq integer)
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
			,	case when nf.df_nf_tipo = 34 then 1 else 0 end as item_bonificado
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
	inner join  tbdocumentofiscal 			 	nf 
												on 	nf.df_nf_seq_blue = fa.df_nf_Seq_blue
												and	nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente 

	
	inner join  tbfaturamento_controle 	 	ct on ct.numeropedido = fa.numeropedido 
										      and ct.numeropedido_fv = fa.numeropedido_fv 
											  and ct.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
	inner join  tbfaturamento 				 f on f.faturamento_controle_seq = ct.faturamento_controle_seq
	inner join  tbfaturamentoorigem 		 o on o.faturamento_controle_seq = f.faturamento_controle_seq 
	inner join  tbproduto 					 pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft_unitario 
	inner join  tbprodutobluesoft			 pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
	where 		1 = 1
	--and			ct.numeropedido = 213289
	and			fa.numeropedido = vnumeropedido
	and         fa.cdpessoabluesoft_cliente	= vcdpessoabluesoft_cliente
	and			ct.faturamento_controle_seq = vfaturamento_controle_seq
	and			f.faturamento_controle_seq = vfaturamento_controle_seq

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
	--and			ct.numeropedido = 213289
	and 		ct.faturamento_controle_seq = vfaturamento_controle_seq
	and			not exists (	select 1 
								from 	tbfaturamentoitens xx
								where   1 = 1
								and     xx.seqfaturamentoorigem = o.seqfaturamentoorigem 
								and     xx.pr_cdproduto = i.pr_cdproduto 
							)
	group by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	
	order by 	i.seqfaturamentoorigem
			,	i.pr_cdproduto 	asc			

	;




	update tbfaturamentoitens a
	set    valortotalfaturamentoliquido = xb.valortotal_faturamentofiscal
	from   (	select      i.seqfaturamentoorigem
						,	i.pr_cdproduto
						,	sum(i.valortotal_faturamentofiscal) as valortotal_faturamentofiscal 	
				from 		tbfaturamentoitensembalagem 	i
				inner join  tbfaturamentoorigem 			o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
				inner join  tbfaturamento_controle 	 	ct on ct.faturamento_controle_seq = o.faturamento_controle_seq
				inner join  tbproduto 						pr	on pr.pr_cdproduto = i.pr_cdproduto 
				where		1 = 1 
				and 		ct.faturamento_controle_seq = vfaturamento_controle_seq
				group by 	i.seqfaturamentoorigem
						,	i.pr_cdproduto 	
				order by 	i.seqfaturamentoorigem
						,	i.pr_cdproduto 	asc		
			) xb
	where 	a.seqfaturamentoorigem = xb.seqfaturamentoorigem
	and		a.pr_cdproduto = xb.pr_cdproduto
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

	valor_total_a_ratear:= (select df_valor_total - df_valor_total_mercadoria from tbdocumentofiscal where df_nf_seq_blue = vdf_nf_seq_blue)
	;
	
	insert into tbfaturamentoitensinfo
				(
						seqfaturamentoorigem			
					,	seqfaturamentoitem 				
					,	fator_part_total_faturamento 	
					,	valor_desc_acrescimo_total_nf
					,	valor_desc_acrescimo_total_nf_compl
				)

		SELECT		cast(ct.seqfaturamentoorigem as int)
				,	cast(i.seqfaturamentoitem as int)
				,	cast(i.valortotalfaturamento / case when coalesce(valor_total_faturamento,1) = 0 then 1 else coalesce(valor_total_faturamento,1) end  as numeric(17,4))
				,	cast(round(i.valortotalfaturamento / coalesce(valor_total_faturamento,1),4) * valor_total_a_ratear as numeric(13,2))
				,	0
		FROM 		tbfaturamentoitens		i 
		inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
		inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
		inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
		WHERE 	1 = 1 
		AND		ct.numeropedido = vnumeropedido 
		and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
		and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
		and		not exists (	select 1
								from 	tbfaturamentoitensinfo xx
								where 	xx.seqfaturamentoorigem = ct.seqfaturamentoorigem
								and		xx.seqfaturamentoitem = i.seqfaturamentoitem
							)
		;

	update tbfaturamentoitensinfo i
	     set fator_part_total_faturamento = cast(ii.valortotalfaturamento / case when coalesce(valor_total_faturamento,1) = 0 then 1 else coalesce(valor_total_faturamento,1) end  as numeric(17,4))
		 ,	valor_desc_acrescimo_total_nf = cast(round(ii.valortotalfaturamento / coalesce(valor_total_faturamento,1),4) * valor_total_a_ratear as numeric(13,2))
	from tbfaturamentoitens ii
	inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = ii.seqfaturamentoorigem 
	inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
	inner join	 tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
	where 	1 = 1
	and		ct.numeropedido = vnumeropedido
	and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente
	and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
	and		ii.seqfaturamentoitem = i.seqfaturamentoitem
	and		ii.seqfaturamentoorigem = i.seqfaturamentoorigem

	;






	if (valor_total_a_ratear <> 0 )
	then 
		valor_total_diferenca_rateio:=	valor_total_a_ratear - ( 	SELECT SUM(I.valor_desc_acrescimo_total_nf) AS TOTAL 
											FROM tbfaturamentoitensinfo I
											inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
											inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
											inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
											WHERE 	1 = 1 
											AND		ct.numeropedido = vnumeropedido 
											and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
											and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
			  					  ) 
		;
		update   tbfaturamentoitensinfo x
		set      valor_desc_acrescimo_total_nf_compl = valor_total_diferenca_rateio
		from 	 (	SELECT i.seqfaturamentoitem 
					FROM tbfaturamentoitensinfo I
					inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
					inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
					inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
					WHERE 	1 = 1 
					AND		ct.numeropedido = vnumeropedido 
					and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
					and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
					
					
					order by i.fator_part_total_faturamento desc limit 1
				) xx 
		where xx.seqfaturamentoitem = x.seqfaturamentoitem
		;

		if (valor_total_a_ratear < 0)
		then 
			update tbfaturamentoitens a
			set    valortotaldescontofinanceiro = case when i.valor_desc_acrescimo_total_nf < 0 then i.valor_desc_acrescimo_total_nf - i.valor_desc_acrescimo_total_nf_compl else 0 end 
			FROM tbfaturamentoitensinfo I
			inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
			inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
			inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
			WHERE 	1 = 1 
			AND		ct.numeropedido = vnumeropedido 
			and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
			and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
			and		a.seqfaturamentoitem = i.seqfaturamentoitem
			;
		end if;

		if (valor_total_a_ratear > 0)
		then 

			-- select * from tbfaturamentoitens limit 10
			-- select * from tbfaturamentocontrato
			-- select * from tbfaturamentocontrato_tipo
			-- select * from tbfaturamentocontratoproduto
			-- select * from tbfaturamentoitenscontratos
				insert into tbfaturamentocontrato
						(
								faturamento_controle_seq 
							,	contrato_descricao 
							,	contrato_data
							,	contrato_data_val_ini 
							,	contrato_data_val_fim 
							,	op_cdoperacao 
							,	cdparticipante_contratante 
				
						)  select vfaturamento_controle_seq
							,	  'OXAN - RATEIO FRETE / DESC NF PED:' || vnumeropedido
							,	  f.datafaturamento
							,	  f.datafaturamento
							,	  f.datafaturamento
						    ,     vop_cdoperacao 
							,     1
						   FROM   tbfaturamentoorigem 	o 
							inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
							inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
						   WHERE 1 = 1
						   AND		ct.numeropedido = vnumeropedido 
						   and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
			               and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
						   AND NOT EXISTS  ( 	SELECT 1 
						   						FROM   tbfaturamentocontrato xx
												WHERE  xx.faturamento_controle_seq = ct.faturamento_controle_seq
						   					)

				;


				delete from tbfaturamentoitenscontratos
				where seqfaturamentoorigem in (select xx.seqfaturamentoorigem from tbfaturamentoorigem xx where xx.faturamento_controle_seq = vfaturamento_controle_seq )
				
				;

				

				insert into tbfaturamentoitenscontratos
					(		
							seqfaturamentoorigem
						,	seqfaturamentoitem 
						,	contrato_Seq 
						,	contrato_produto_seq 
						,	valorinvestimento_unit 
						,	valorinvestimento_total 
					)
					select  o.seqfaturamentoorigem
						,	i.seqfaturamentoitem
						,	x.contrato_Seq
						,	0 
						,	cast((i.valor_desc_acrescimo_total_nf + valor_desc_acrescimo_total_nf_compl) / case when coalesce(ii.embalagemestoqueqtde,1) = 0 then 1 else coalesce(ii.embalagemestoqueqtde,1) end  as numeric(17,4)) 
						,	cast(i.valor_desc_acrescimo_total_nf + valor_desc_acrescimo_total_nf_compl as numeric(13,2))
					FROM tbfaturamentoitensinfo I
					inner join  tbfaturamentoitens 	ii on ii.seqfaturamentoorigem = i.seqfaturamentoorigem and ii.seqfaturamentoitem = i.seqfaturamentoitem
					inner join  tbfaturamentoorigem 	o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
					inner join  tbfaturamento 			f on f.faturamento_controle_seq = o.faturamento_controle_seq
					inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq
					inner join  tbfaturamentocontrato  x on x.faturamento_controle_seq = ct.faturamento_controle_seq
					WHERE 	1 = 1 
						AND		ct.numeropedido = vnumeropedido 
						and 	ct.cdpessoabluesoft_cliente = vcdpessoabluesoft_cliente 
						and 	ct.faturamento_controle_seq = vfaturamento_controle_seq
						AND     not exists (	select 1  
												from   tbfaturamentoitenscontratos xxx
												where  1 = 1
												and    xxx.seqfaturamentoorigem = o.seqfaturamentoorigem
												and    xxx.seqfaturamentoitem = i.seqfaturamentoitem
												and	   xxx.contrato_Seq = x.contrato_Seq
											)

						   
			;
		end if;
		
	end if;
	
		

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$BODY$;
