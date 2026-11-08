-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- FUNCTION: public.f0150_01_1011914_estatistica_processamento()

-- DROP FUNCTION IF EXISTS public.f0150_01_1011914_estatistica_processamento();

--select from f0150_01_1012018_estatistica_processamento('2026-04-01', '2026-07-31', 0)
--select from f0150_01_1012018_estatistica_processamento('2026-07-31', '2026-07-31')

-- select * from tbest_produto where pr_cdproduto = 47077
-- select * from tbest_info

/*

select 		i.pr_cdproduto
						,	max(f.datafaturamento) AS data_ultima_venda
				FROM		TbFaturamentoItens  i 
				inner join	TbFaturamentoOrigem	o 	on o.SeqFaturamentoOrigem = i.SeqFaturamentoOrigem 
				inner join  TbFaturamento		f 	on f.SeqFaturamento = o.SeqFaturamento
				inner join  tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto
				where		1 = 1
				and			i.StatusFaturamentoItem = 1
				and			f.StatusFaturamento = 1
				and			f.em_cdempresa = 1
				and			f.datafaturamento >= (select data_base_estatistica from tbest_info where est_info_seq = 1)
				and			f.datafaturamento <= current_date 
				and         pr.prb_cdprodutobluesoft = 47077
				group by 	i.pr_cdproduto

*/




CREATE OR REPLACE 
-- DROP 
FUNCTION public.f0150_01_1012018_estatistica_processamento(
		dataFaturamento_ini Date,
		dataFaturamento_fim Date,
		vprocessamento_parcial int

	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
declare VDATA_INI date;
declare VDATA_FIM date;
declare vsemana_atual_data_fim date;
declare vsemana_atual_data_ini date;
declare vsemana_s4_data_fim date;
declare vsemana_s4_data_ini date;
declare vsemana_s3_data_fim date;
declare vsemana_s3_data_ini date;
declare vsemana_s2_data_fim date;
declare vsemana_s2_data_ini date;
declare vsemana_s1_data_fim date;
declare vsemana_s1_data_ini date;
declare vdow_info int; 

begin


	VDATA_INI:= current_date;
	VDATA_FIM:= current_date;
	
	
	
	
		
		
	
	
	
/***************************************************************************************
DADOS DE ULTIMA COMPRA / ULTIMA VENDA COM BASE NO MOVIMENTO GERAL (PROCESSAMENTO GERAL)
****************************************************************************************/
	if vprocessamento_parcial = 0
	then 
		INSERT INTO tbest_produto
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft 
				,	data_ultima_compra
				,	data_ultima_venda 
			)

		select 		pr.pr_cdproduto
				,	pr.prb_cdprodutobluesoft 
				,	'1900-01-01'
				,	'1900-01-01'
		from 		tbproduto pr
		where pr.pr_cdproduto not in (select pr_cdproduto from tbest_produto)
		
		;

		UPDATE		tbest_produto A
		SET			data_ultima_compra = B.data_ultima_compra
			,		dtlog_update = current_timestamp 
		FROM 		(
						SELECT 		p.pr_cdproduto 				as pr_cdproduto 
								,	i.prb_cdprodutobluesoft 	as prb_cdprodutobluesoft  	
								,	max(x.df_data_recebimento) 	as data_ultima_compra
						FROM 		TBdocumentofiscal			x
						inner join 	tbdocumentofiscalitem 		i on i.df_nf_seq_blue = x.df_nf_seq_blue 
						inner join  tbproduto					p on p.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft 
						where		x.df_entrada_saida = 'E'
						and			x.df_cdpessoabluesoft_cancelamento = 0
						and			x.df_data_recebimento >= (select data_base_estatistica from tbest_info where est_info_seq = 1)
						and			x.df_status_recebimento = 'Recebido'
						group by 	p.pr_cdproduto ,i.prb_cdprodutobluesoft 
					)	B 
		WHERE 	1 = 1
		AND 	B.pr_cdproduto = A.pr_cdproduto 
		and		coalesce(b.data_ultima_compra,'1900-01-01') != coalesce(a.data_ultima_compra,'1900-01-01')

		;

		UPDATE		tbest_produto A
		SET			data_ultima_venda = B.data_ultima_venda
			,		dtlog_update = current_timestamp 
		FROM ( 
				select 		i.pr_cdproduto
						,	max(f.datafaturamento) AS data_ultima_venda
				FROM		TbFaturamentoItens  i 
				inner join	TbFaturamentoOrigem	o 	on o.SeqFaturamentoOrigem = i.SeqFaturamentoOrigem 
				inner join  TbFaturamento		f 	on f.SeqFaturamento = o.SeqFaturamento
				inner join  tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto
				where		1 = 1
				and			i.StatusFaturamentoItem = 1
				and			f.StatusFaturamento = 1
				and			f.em_cdempresa = 1
				and			f.datafaturamento >= (select data_base_estatistica from tbest_info where est_info_seq = 1)
				and			f.datafaturamento <= current_date 
				group by 	i.pr_cdproduto
			)   B
		WHERE 1 = 1
		  AND 	B.pr_cdproduto = A.pr_cdproduto 
		  AND	coalesce(b.data_ultima_venda,'1900-01-01') != coalesce(a.data_ultima_venda,'1900-01-01')
		;
	end if
	;






/* ATUALIZAÇÃO DE DADOS DE ULTIMA VENDA DO DIA */

UPDATE		tbest_produto A
SET			data_ultima_compra = B.data_ultima_compra
	,		dtlog_update = current_timestamp 
FROM 		(
				SELECT 		p.pr_cdproduto 				as pr_cdproduto 
						,	i.prb_cdprodutobluesoft 	as prb_cdprodutobluesoft  	
						,	max(x.df_data_recebimento) 	as data_ultima_compra
				FROM 		TBdocumentofiscal			x
				inner join 	tbdocumentofiscalitem 		i on i.df_nf_seq_blue = x.df_nf_seq_blue 
				inner join  tbproduto					p on p.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft 
				where		x.df_entrada_saida = 'E'
				and			x.df_cdpessoabluesoft_cancelamento = 0
				and			x.df_data_recebimento >= current_date
				and			x.df_status_recebimento = 'Recebido'
				group by 	p.pr_cdproduto ,i.prb_cdprodutobluesoft 
			)	B 
WHERE 	1 = 1
AND 	B.pr_cdproduto = A.pr_cdproduto 
		and		coalesce(b.data_ultima_compra,'1900-01-01') != coalesce(a.data_ultima_compra,'1900-01-01')

;


UPDATE		tbest_produto A
SET			data_ultima_venda = B.data_ultima_venda
	,		dtlog_update = current_timestamp 
FROM ( 
				select 		i.pr_cdproduto
						,	max(f.datafaturamento) AS data_ultima_venda
				FROM		TbFaturamentoItens  i 
				inner join	TbFaturamentoOrigem	o 	on o.SeqFaturamentoOrigem = i.SeqFaturamentoOrigem 
				inner join  TbFaturamento		f 	on f.SeqFaturamento = o.SeqFaturamento
				inner join  tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto
				where		1 = 1
				and			i.StatusFaturamentoItem = 1
				and			f.StatusFaturamento = 1
				and			f.em_cdempresa = 1
				and			f.datafaturamento >= current_date
				and			f.datafaturamento <= current_date 
				group by 	i.pr_cdproduto
			)   B
		WHERE 1 = 1
		  AND 	B.pr_cdproduto = A.pr_cdproduto 
		  AND	coalesce(b.data_ultima_venda,'1900-01-01') != coalesce(a.data_ultima_venda,'1900-01-01')		  
		;











/***************************************************************************************
Tabela de Estatisca Basica de venda
Nome: tbest_faturamento_data
Objetivo: Registrar venda por DADOS/DATA 
****************************************************************************************/

	DROP TABLE if exists TMP_est_faturamento_data
	;
	CREATE TEMPORARY TABLE TMP_est_faturamento_data
		(		
				datafaturamento						date
			,	ano 								int
			,	mes									int
			,	dia									int 
			,	dia_semana							int 
			,	em_cdempresa						int 
			,	op_cdoperacao 						int
			,	cdparticipantecliente				int 
			,	cdparticipantevendedor				int 
			,	pr_cdproduto						int
			,	prb_cdprodutobluesoft 				int
			,	embalagemestoqueqtde				numeric(17,3)
			,	embalagemcompraqtde 				numeric(17,3)
			, 	ec_valorcusto_faturamento_total 	numeric(13,2)
			,	ec_valorcusto_precificacao_total 	numeric(13,2)
			,	valortotalfaturamentobase 			numeric(13,2)
			,	valortotalsubsidioscorrentes		numeric(13,2)	 
			,	valortotalfaturamento				numeric(13,2)	 
			,	valortotaldescontofinanceiro 		numeric(13,2)	 
			,	valortotalsubsidiosaplicados		numeric(13,2)	 
			,	valortotalfaturamentoliquido		numeric(13,2)	
			, constraint TMP_PK_est_faturamento_data  primary key (datafaturamento, em_cdempresa, op_cdoperacao, cdparticipantecliente, cdparticipantevendedor, pr_cdproduto, prb_cdprodutobluesoft)	 

		)		
	;
	INSERT INTO TMP_est_faturamento_data
	(		datafaturamento				
		,	ano 							
		,	mes								
		,	dia								
		,	dia_semana						
		,	em_cdempresa					
		,	op_cdoperacao 					
		,	cdparticipantecliente			
		,	cdparticipantevendedor			
		,	pr_cdproduto					
		,	prb_cdprodutobluesoft 			
		,	embalagemestoqueqtde			
		,	embalagemcompraqtde 			
		, 	ec_valorcusto_faturamento_total 
		,	ec_valorcusto_precificacao_total
		,	valortotalfaturamentobase 		
		,	valortotalsubsidioscorrentes	
		,	valortotalfaturamento			
		,	valortotaldescontofinanceiro 	
		,	valortotalsubsidiosaplicados	
		,	valortotalfaturamentoliquido	
	)
	SELECT		f.DataFaturamento 																					
			,	date_part('year',f.datafaturamento)			as ano										
			,	date_part('month',f.datafaturamento)		as mes						
			,	date_part('day',f.datafaturamento)			as dia												
			,	date_part('dow',f.datafaturamento)			as dia_semana																						
			,	f.em_cdempresa																			
			,	f.op_cdoperacao 																
			,	f.cdparticipantecliente																		
			,	f.cdparticipantevendedor																		
			,	pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft 		
			,	sum(coalesce(i.EmbalagemEstoqueQtde,0) )	as EmbalagemEstoqueQtde												
			,	sum(coalesce(i.EmbalagemCompraQtde,0))		as EmbalagemCompraQtde
			, 	sum(coalesce(i.ec_valorcusto_faturamento_total,0))	as ec_valorcusto_faturamento_total											
			, 	sum(coalesce(i.ec_valorcusto_precificacao_total,0))	as ec_valorcusto_precificacao_total												
			,	sum(coalesce(valortotalfaturamentobase ))	as 	valortotalfaturamentobase													
			,	sum(coalesce(valortotalsubsidioscorrentes	))	as valortotalsubsidioscorrentes															
			,	sum(coalesce(valortotalfaturamento			))	as valortotalfaturamento											
			,	sum(coalesce(valortotaldescontofinanceiro 	))	as valortotaldescontofinanceiro												
			,	sum(coalesce(valortotalsubsidiosaplicados	)) 	as valortotalsubsidiosaplicados
			,	sum(coalesce(valortotalfaturamentoliquido	))	as valortotalfaturamentoliquido

	FROM		TbFaturamento			f
	inner join	TbFaturamentoOrigem	o on o.SeqFaturamento = f.SeqFaturamento 
	inner join  TbFaturamentoItens		i on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
	inner join  tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto
	where		1 = 1
	and			i.StatusFaturamentoItem = 1
	and			f.StatusFaturamento = 1
	and			f.DataFaturamento >= dataFaturamento_ini
	and			f.DataFaturamento <= dataFaturamento_fim
	group by f.DataFaturamento 
			,	date_part('year',f.datafaturamento)
			,	date_part('month',f.datafaturamento)
			,	date_part('day',f.datafaturamento)
			,	date_part('dow',f.datafaturamento)
			,	f.em_cdempresa
			,	f.op_cdoperacao 					
			,	f.cdparticipantecliente			
			,	f.cdparticipantevendedor			
			,	pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft 		
	;

	INSERT INTO tbest_faturamento_data
	(		datafaturamento				
		,	ano 							
		,	mes								
		,	dia								
		,	dia_semana						
		,	em_cdempresa					
		,	op_cdoperacao 					
		,	cdparticipantecliente			
		,	cdparticipantevendedor			
		,	pr_cdproduto					
		,	prb_cdprodutobluesoft 			
		,	embalagemestoqueqtde			
		,	embalagemcompraqtde 			
		, 	ec_valorcusto_faturamento_total 
		,	ec_valorcusto_precificacao_total
		,	valortotalfaturamentobase 		
		,	valortotalsubsidioscorrentes	
		,	valortotalfaturamento			
		,	valortotaldescontofinanceiro 	
		,	valortotalsubsidiosaplicados	
		,	valortotalfaturamentoliquido	
	)
	SELECT 	datafaturamento				
		,	ano 							
		,	mes								
		,	dia								
		,	dia_semana						
		,	em_cdempresa					
		,	op_cdoperacao 					
		,	cdparticipantecliente			
		,	cdparticipantevendedor			
		,	pr_cdproduto					
		,	prb_cdprodutobluesoft 			
		,	embalagemestoqueqtde			
		,	embalagemcompraqtde 			
		, 	ec_valorcusto_faturamento_total 
		,	ec_valorcusto_precificacao_total
		,	valortotalfaturamentobase 		
		,	valortotalsubsidioscorrentes	
		,	valortotalfaturamento			
		,	valortotaldescontofinanceiro 	
		,	valortotalsubsidiosaplicados	
		,	valortotalfaturamentoliquido	
	FROM 	TMP_est_faturamento_data	A
	WHERE	NOT EXISTS ( 	SELECT 	1 
							FROM 	tbest_faturamento_data		X
							WHERE 	X.datafaturamento = a.datafaturamento 
							AND		x.em_cdempresa = a.em_cdempresa
							AND 	x.op_cdoperacao = a.op_cdoperacao
							AND		x.cdparticipantecliente = a.cdparticipantecliente
							AND		x.cdparticipantevendedor = a.cdparticipantevendedor
							AND		x.pr_cdproduto = a.pr_cdproduto
							AND 	x.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft
					   )

	;

	DELETE FROM tbest_faturamento_data X
	WHERE 	1 = 1
	AND		X.datafaturamento >= VDATA_INI 
	AND		X.datafaturamento <= VDATA_FIM
	AND 	NOT EXISTS ( 	SELECT 	1 
							FROM 	TMP_est_faturamento_data	A
							WHERE 	X.datafaturamento = a.datafaturamento 
							AND		x.em_cdempresa = a.em_cdempresa
							AND 	x.op_cdoperacao = a.op_cdoperacao
							AND		x.cdparticipantecliente = a.cdparticipantecliente
							AND		x.cdparticipantevendedor = a.cdparticipantevendedor
							AND		x.pr_cdproduto = a.pr_cdproduto
							AND 	x.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft
					   )
	;

	DROP TABLE if exists TMP_est_faturamento_data
	;
end;
$BODY$;


