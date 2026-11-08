-- FUNCTION: public.f0070_20_1012010_faturamento_controle_processar(integer, character varying, integer, integer, integer, integer, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0070_20_1012010_faturamento_controle_processar(integer, character varying, integer, integer, integer, integer, integer, integer, integer, integer);


/*

select 	f.op_cdoperacao 
	,   o.op_descricao 
	,	f.numeropedido 
	,   f.numeropedido_fv 
	,   f.cdpessoabluesoft_cliente 
	,   f.fat_blue_status_cd
	,   f.fat_blue_tipo_cd 
	,   f.cdpessoabluesoft_vendedor
	,   f.data_emissao 
	,   f.data_faturamento
	,	f.fat_blue_tipo_cd
	,	t.fat_blue_tipo_descricao 
	,   f.fat_blue_status_cd 
	,	s.fat_blue_status_descricao 
	,	f.*
from 	tbfaturamento_bluesoft f
left join tboperacao o on o.op_cdoperacao = f.op_cdoperacao
left join tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd
left join tbfaturamento_bluesoft_tipo t on t.fat_blue_tipo_cd  = f.fat_blue_tipo_cd
where   1=1
  and   f.data_emissao >= '2026-02-05'
  and   f.data_emissao <= '2026-02-05'
  and   o.op_cdoperacao = 4


select 	f.op_cdoperacao 
	,   o.op_descricao 
	,	f.numeropedido 
	,   f.numeropedido_fv 
	,   f.cdpessoabluesoft_cliente 
	,   f.fat_blue_status_cd
	,	s.fat_blue_status_descricao 
	,   f.fat_blue_tipo_cd 
	,	t.fat_blue_tipo_descricao 
	,   f.cdpessoabluesoft_vendedor
	,   f.data_emissao 
	,   f.data_faturamento
from 	tbfaturamento_bluesoft f
left join tboperacao o on o.op_cdoperacao = f.op_cdoperacao
left join tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd
left join tbfaturamento_bluesoft_tipo t on t.fat_blue_tipo_cd = f.fat_blue_tipo_cd
where   1 = 1
  and   f.data_faturamento >= '2026-02-05'
  and   f.data_faturamento <= '2026-02-05'
  and   f.numeropedido in (247407, 247506)

select * from tbfaturamento_bluesoft_status
select * from tbfaturamento_bluesoft_tipo

select * from tboperacao


select 	
	   seqfaturamento_uuid 
	,	faturamento_controle_seq
	,	op_cdoperacao 
	,	dataemissao 
	,   datafaturamento 
	,   numeropedido 
	,   numeropedido_fv 
	,   df_nf_seq_blue
	,   numeronfe 
	,   sat_ecf 
	,   cupomfiscal 
	,   seqfaturamento 
	,   seqfaturamentoorigem 
from 	tbfaturamento_controle 
where 	datafaturamento >= '2025-02-05'
and     datafaturamento <= '2025-02-05'
limit 10

select * from tbfaturamento_controle_tipo
select * from tbfaturamentostatus
select * from tbfaturamentostatusitem limit 10


SELECT * FROM tbfaturamentoorigem limit 10

select * from tbfaturamentoorigem limit 10
alter table tbfaturamentoorigem 

SELECT
    constraint_name,
    table_name,
    constraint_type
FROM information_schema.table_constraints
WHERE table_name = 'tbfaturamento';


		select * from tbfaturamento where dataemissao = '2026-02-16' and op_cdoperacao <> 2
		select * from tbfaturamentoorigem where seqfaturamento = 8861502
		select * from tbfaturamentoitens where seqfaturamentoorigem = 9632837
		select * from tbfaturamentoitensembalagem where seqfaturamentoorigem = 9632837
		select * from tbfaturamento_bluesoft where numeropedido = 250641
		select * from tbfaturamento_bluesoft_item where numeropedido = 247407
		select * from tbfaturamento_bluesoft_item where op_cdoperacao not in (1,4) limit 10

*/


		delete from tbfaturamentoitens
			where seqfaturamentoorigem in (
										select 		o.seqfaturamentoorigem
										
										from   		tbfaturamentoorigem o
										inner join  tbfaturamento f 			on f.seqfaturamento = o.seqfaturamento
										inner join  tbfaturamento_controle c 	on c.faturamento_controle_Seq = f.faturamento_controle_Seq 
										where		1 = 1
										and         c.dataemissao = '2026-02-05'
										and         c.numeropedido in (247506)
										
 		)
		;

		delete from tbfaturamentoitensembalagem
			where seqfaturamentoorigem in (
										select 		o.seqfaturamentoorigem
										
										from   		tbfaturamentoorigem o
										inner join  tbfaturamento f 			on f.seqfaturamento = o.seqfaturamento
										inner join  tbfaturamento_controle c 	on c.faturamento_controle_Seq = f.faturamento_controle_Seq 
										where		1 = 1
										and         c.dataemissao = '2026-02-05'
										and         c.numeropedido in (247506)
										
 		)
		;

		delete from tbfaturamentoorigem
			where seqfaturamento in (
										select 		f.seqfaturamento 
										from   		tbfaturamento f
										inner join  tbfaturamento_controle c on c.faturamento_controle_Seq = f.faturamento_controle_Seq 
										where		1 = 1
										and         c.dataemissao = '2026-02-05'
										and         c.numeropedido in (247506)
										
 		)

		;
		delete from tbfaturamentoorigem 
		   where faturamento_controle_seq in ( 
												select faturamento_controle_seq from tbfaturamento_controle 
													where numeropedido in  (247506)
												  and dataemissao = '2026-02-05'
												)
		;

		delete from tbfaturamento
		   where faturamento_controle_seq in ( 
												select faturamento_controle_seq from tbfaturamento_controle 
												where numeropedido in  (247506)
												  and dataemissao = '2026-02-05'
												)
		;





		/* FATURAMENTO CONTROLE */

			insert into   tbfaturamento_controle 
						(
								seqfaturamento_uuid
							,	dataemissao 
							,	datafaturamento 
							,	numeropedido
							,	numeropedido_fv 
							,	df_nf_seq_blue
							,	numeronfe 
							,	sat_ecf 
							,	cupomfiscal 
							,	fat_controle_tipo_cd
							,	seqfaturamento
							,	seqfaturamentoorigem
							,	seqfaturamento_old
							,	seqfaturamento_origem_old
							,	cdpessoabluesoft_cliente
							,	op_cdoperacao 
						)
					
					select 	
					       		cast(gen_random_uuid () as varchar(3)) || TO_CHAR(fa.numeropedido, '0000000')
							,	fa.data_emissao
							,	fa.data_faturamento 
							,	fa.numeropedido 
							,	fa.numeropedido_fv
							,	fa.df_nf_seq_blue  
							,	coalesce(nf.df_nf_numero,0) as df_nf_numero 
							,	0 as sat_ecf 
							,	0 as cupomfiscal 
							,	1 as fat_controle_tipo_cd ----- TIPO VENDA INICIAL 
							,	0 as seqfaturamento
							,	0 as seqfaturamentoorigem
							,	0 as seqfaturamento_old
							,	0 as seqfaturamento_origem_old
							,	fa.cdpessoabluesoft_cliente
							,	fa.op_cdoperacao 
					from 			tbfaturamento_bluesoft				fa
					inner join 		tbfaturamento_bluesoft_status		st on st.fat_blue_status_cd = fa.fat_blue_status_cd
					left  join      tbdocumentofiscal 					nf on nf.df_nf_seq_blue = fa.df_nf_seq_blue and nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente
					where	1 = 1


					and		fa.op_cdoperacao in(1,2,4)

					--- TESTE
					and 	fa.data_emissao = '2026-02-05'
					and     fa.numeropedido in  (247506)
					---
					
					and		fa.fat_blue_status_cd 
									in (
											20, -- Aguardando Analise Gerencial
											25, -- Em Analise Gerencial
											27, -- Em Analise de Credito
											30, -- Fechado
											40, -- Em sepracao 
											45, -- Separado
											50, -- Faturando
											55, -- FATURADO POR NOTA FISCAL
											70  -- ENTREGUE
					
									)
					and		coalesce(fa.df_nf_seq_blue_dev,0) = 0 			
					
					and		not exists ( 	select 1 
											from 	tbfaturamento_controle aa
											where 	aa.numeropedido = fa.numeropedido
											and		aa.numeropedido_fv = fa.numeropedido_fv 
											and		aa.op_cdoperacao = fa.op_cdoperacao 
											and		aa.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
										)
		;

		
		INSERT INTO tbfaturamento
			(	
					faturamento_controle_seq 
				,	op_cdoperacao 
				,	em_cdempresa 
				,	dataemissao 
				,	datafaturamento
				,	cdparticipantecliente
				,	cdparticipantevendedor
				,	statusfaturamento
			)
			select 	ct.faturamento_controle_seq
				,	ct.op_cdoperacao 
				,	op.em_cdempresa
				,	ct.dataemissao
				,	ct.datafaturamento 
				,	coalesce(p.cdparticipante, 0)
				,	0
				,	cast( case fa.fat_blue_status_cd
						 when 20 then 0         -- Aguardando Analise Gerencial
						 when 25 then 0 		-- Em Analise Gerencial
						 when 27 then 0  		-- Em Analise de Credito
						 when 30 then 0         -- Fechado
						 when 40 then 0         -- Em sepracao 
						 when 45 then 1         -- Separado
						 when 50 then 1         -- Faturando
						 when 55 then 1         -- FATURADO POR NOTA FISCAL
						 when 70 then 1         -- ENTREGUE
						 else         0
					end as smallint )

			from 		tbfaturamento_controle  ct
			left join   tbfaturamento_bluesoft  fa 	 on fa.numeropedido = ct.numeropedido
												and		fa.numeropedido_fv = ct.numeropedido_fv 
												and		fa.op_cdoperacao = ct.op_cdoperacao 
												and		fa.cdpessoabluesoft_cliente = ct.cdpessoabluesoft_cliente
											
			inner join  tboperacao 			 	op on op.op_cdoperacao = ct.op_cdoperacao 
			left  join  tbparticipante_bluesoft  p on p.cdpessoabluesoft = ct.cdpessoabluesoft_cliente 
			where	1 = 1
            and     ct.dataemissao = '2026-02-05'
			and		ct.faturamento_controle_seq not in 
								(	select  aa.faturamento_controle_seq 
									from 	tbfaturamento aa
									where	1 = 1
									  and   aa.dataemissao = '2026-02-05'
									group by aa.faturamento_controle_seq 
								)

		

		
		
		;
		update tbfaturamento_controle ct 
			set seqfaturamento = a.seqfaturamento 
		from tbfaturamento a 
		where a.faturamento_controle_seq = ct.faturamento_controle_seq 
          and a.dataemissao = '2026-02-05'
		  and coalesce(ct.seqfaturamento,0) <>  a.seqfaturamento 


		;


		insert into tbfaturamentoorigem 
			(
					seqfaturamento
				,	sat_ecf 
				,	cupomfiscal 
				,	numeropedido 
				,	numeronfe 
				,	nfeseq 
				,	prazopgtomedio 
				,	numeronfedevolucao 				
				,	df_nf_seq_blue 
				,	faturamento_controle_seq 
			)

		select 	 	fa.seqfaturamento 
				,	ct.sat_ecf
				,	ct.cupomfiscal
				,	ct.numeropedido
				,	coalesce(nf.df_nf_numero,0)
				,	ct.df_nf_seq_blue 
				,	0
				,	0
				,	ct.df_nf_seq_blue 
				,	ct.faturamento_controle_seq
		from 		tbfaturamento_controle 	ct
		inner join 	tbfaturamento 				fa on fa.faturamento_controle_seq = ct.faturamento_controle_seq
		left  join  tbdocumentofiscal 			nf on nf.df_nf_seq_blue = ct.df_nf_seq_blue 
		where		1 = 1
            and     ct.dataemissao = '2026-02-05'
		and			ct.faturamento_controle_seq not in 
								(	select aa.faturamento_controle_seq  
									from 	tbfaturamentoorigem aa
									group by aa.faturamento_controle_seq  
									  

								)
		;
		update 	tbfaturamento_controle 	ct 
			set seqfaturamentoorigem 	= a.seqfaturamentoorigem 
		from 	tbfaturamentoorigem 	a 
		where 	a.faturamento_controle_seq 	= ct.faturamento_controle_seq
		  and   ct.dataemissao 				= '2026-02-05'
		and 	ct.seqfaturamentoorigem 	<> a.seqfaturamentoorigem 

		;

		/*
			AVERIGUAR 
			UPDATE 978 LINHAS NA PRIMEIRA EXECUCAO

		*/
		
		/*REVISAO DE SEQUENCIAL seqfaturamento na tabela SEQFATURAMENTO ORIGEM */
		UPDATE 	tbfaturamentoorigem o
			set seqfaturamento = ct.seqfaturamento
		from 	tbfaturamento_controle ct
		where	ct.faturamento_controle_seq = o.faturamento_controle_seq
		  and   ct.dataemissao = '2026-02-05'
          and   o.seqfaturamento <> ct.seqfaturamento




	;
	-----------------------------------------------------------------------
	-----------------------------------------------------------------------
	-- ITENS EMBALAGEM
	-----------------------------------------------------------------------
	-----------------------------------------------------------------------

	



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
	and   		ct.dataemissao = '2026-02-05'

	and			not exists	( 	select 		1 
								from 		tbfaturamentoitensembalagem xx 
								inner join 	tbfaturamentoorigem 		ox on ox.seqfaturamentoorigem = xx.seqfaturamentoorigem
								inner join  tbfaturamento 				fx on fx.seqfaturamento = ox.seqfaturamento 
								where 	1 = 1
								and 	xx.seqfaturamentoorigem = o.seqfaturamentoorigem
								and		xx.seqitem = i.fat_blue_item_seq 
								and     fx.dataemissao = '2026-02-05'
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
	


		  
