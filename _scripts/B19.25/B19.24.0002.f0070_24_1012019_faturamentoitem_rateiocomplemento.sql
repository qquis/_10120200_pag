CREATE OR REPLACE FUNCTION public.f0070_24_1012019_faturamentoitem_rateiocomplemento(vfaturamento_controle_seq integer, vnumeropedido integer, vnumeropedido_fv integer, vcdpessoabluesoft_cliente integer, vop_cdoperacao integer, vdf_nf_seq_blue integer)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
begin

/* ALTERACOES 
	B19.23 __ 30/10/2026 - ADICIONARO CAMPO PR_CDPRODUTO AO tbfaturamentoitenscontratos


*/


	
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
						,   pr_cdproduto
						,	contrato_Seq 
						,	contrato_produto_seq 
						,	valorinvestimento_unit 
						,	valorinvestimento_total 
					)
					select  o.seqfaturamentoorigem
						,	i.seqfaturamentoitem
						,	ii.pr_cdproduto
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
$function$
