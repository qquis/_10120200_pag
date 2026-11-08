-- FUNCTION: public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_23_1012010_faturamento_itens_processar(integer, integer, integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.f0070_39_1012017_faturamentocontrato_lancarporOcorrencia(
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
	


	
	/* LANCAMENTO DE CONTRATO DE INVESTIMENTO POR OCORRENCIA
	   LANCAMENTO DE DESCONTO POR OCORRENCIA 
	*/

	valor_total_a_ratear:= (select df_valor_total - df_valor_total_mercadoria from tbdocumentofiscal where df_nf_seq_blue = vdf_nf_seq_blue)
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
