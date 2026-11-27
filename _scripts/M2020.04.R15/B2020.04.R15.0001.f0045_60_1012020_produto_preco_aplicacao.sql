-- FUNCTION: public.p0045_60_1012014_produto_preco_aplicacao()

-- DROP FUNCTION IF EXISTS public.p0045_60_1012014_produto_preco_aplicacao();

CREATE OR REPLACE FUNCTION public.f0045_60_1012020_produto_preco_aplicacao(
	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

----------------------->> PROCESSAMENTO DE PREÇOS EM LOTE 
declare vdata_processamento date:= '1900-01-01';
declare vuuid varchar(50):= '';
---------------------------------------------------------

begin

if current_time >= '00:00:00' and current_time <= '10:00:59' then 
	INSERT INTO tbsistema_log (dtlog_insert, proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
		SELECT current_timestamp, 0, 99110, 'CARGA_LOJA', 'Aplicação de Preços Padrão - LOJA'
	;
end if
;

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
---- APLICAÇÃO DE PREGOS GERANCIADOS POR LOTE --------------------------------------------
if current_time >= '16:30:00' and current_time <= '23:59:59' then 
	INSERT INTO tbsistema_log (dtlog_insert, proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
		SELECT current_timestamp, 0, 99112, 'CARGA_LOJA', 'Aplicação de Preços HORÁRIO NÃO PADRÃO'
	;
	if 	(		select 	count(*) 
		 		from 	tbpreco_aplicacao_lote 
		 		where 	data_processamento = current_date 
		) 		>= 1
		and (	select 	count(*) 
			 	from	tbsistema_log 
			 	where 	sis_nucleo_prc_cd = 99113
			 	  and   cast(dtlog_insert as date) = current_date 
			) < 1
	then 
		INSERT INTO tbsistema_log (dtlog_insert, proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
			SELECT current_timestamp, 0, 99113, 'CARGA_LOJA', 'Aplicação de Preços | Alteração de Preços GERAIS PLANEJADO _ INI'
			;

		vdata_processamento:= current_Date ; 
		vuuid:= cast(vdata_processamento as varchar(10));
		vuuid:= '999999999999999999999999999999999999999999' || (select replace(cast(vdata_processamento as varchar(10)), '-',''));

		delete from tbprocesso_log where proc_log_uuid = vuuid;

		insert into tbprocesso_log (dtlog_insert, proc_tipo_cd, proc_log_dtlancamento, sis_us_seq, proc_log_uuid)
		select current_timestamp , 100101, current_date, 1, vuuid
		;


		drop table if exists tmp_faturamento_f0045_60;
		create temporary table tmp_faturamento_f0045_60 (pr_cdproduto int)
		;
		insert into tmp_faturamento_f0045_60 (pr_cdproduto)
		select 		i.pr_cdproduto
		from   		tbfaturamentoitens i
		inner join 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
		inner join  tbfaturamento f on f.seqfaturamento = o.seqfaturamento
		where		1 = 1 
		and         f.datafaturamento >= current_date - 720
		and         f.datafaturamento <= current_date 
		and         f.op_cdoperacao <> 1
		group by    i.pr_cdproduto
		;
		
		

		INSERT INTO tbpreco_aplicacao_lote_produto
			(
					prd_descricao 						
				,	prs_descricao 						
				,	prg_descricao 						
				,	tab_pre_cd 							
				,	pr_cdproduto 						
				,	prb_cdprodutobluesoft_unitario 		
				,	prb_cdprodutobluesoft 
				,	pr_descricao 
				,	embalagemestoque
				,	old_prc_valor						
				,	prc_qtde_promocional				
				,	old_prc_valor_promocional   	
				,	data_processamento
				,	proc_log_seq
				,	proc_log_uuid
				,	percentual 
                ,   ec_valor_custo_precificacao
				,	margem_limite
				,	processado 

			)

			select 		dp.prd_descricao 
					,	sc.prs_descricao 
					,	gr.prg_descricao 
					,	cast(1 as smallint)
					,	pr.pr_cdproduto 
					,	pr.prb_cdprodutobluesoft 
					,	px.prb_cdprodutobluesoft 
					,	pr.pr_descricao 
					,	pr.pr_embalagemestoque
					,	px.prc_valor
					,	px.prc_qtde_promocional
					,	px.prc_valor_promocional 
					,	current_date 
					,	(select proc_log_seq from tbprocesso_log where proc_log_uuid = vuuid)
					,	vuuid 
					,	l.percentual
					,	ec.ec_valor_custo_precificacao * bb.prb_fatorestoque 	
					,	l.margem_limite
					,	0
			from 		tbproduto 				pr
			inner join  tbproduto_subgrupo		sg on sg.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
			inner join  tbproduto_grupo 		gr on gr.prg_cdgrupo = sg.prg_cdgrupo
			inner join  tbproduto_secao 		sc on sc.prs_cdsecao = gr.prs_cdsecao 
			inner join  tbproduto_departamento 	dp on dp.prd_cddepartamento = sc.prd_cddepartamento 
			inner join  tbestoquecusto 			es on es.pr_cdproduto = pr.pr_cdproduto 
			inner join  tbpreco					px on px.pr_cdproduto = pr.pr_cdproduto 
			left join   tbprodutobluesoft       bb on bb.prb_cdprodutobluesoft_pk = px.prb_cdprodutobluesoft 				
			inner join  tbpreco_aplicacao_lote  l on l.prg_cdgrupo = gr.prg_cdgrupo and l.prs_cdsecao = sc.prs_cdsecao 			
            left join   tbestoquecusto          ec on ec.pr_cdproduto = pr.pr_cdproduto 			
			where		1 = 1
			and         px.tab_pre_cd = 1 
			and			( 		   ( pr.pr_status = 'true' 
									 and pr.pr_cdproduto in ( select pr_cdproduto from tmp_faturamento_f0045_60 xxx )
									)
								or es.ec_embalagemestoque_qtde <> 0 )
			and			px.prc_valor <> 0 
			and			gr.prg_cdgrupo 		in (select aa.prg_cdgrupo from tbpreco_aplicacao_lote aa where data_processamento = vdata_processamento )
			and			NOT EXISTS ( select 1 
									 from 	tbpreco_aplicacao_lote_produto pa 
									 WHERE 	pa.PR_CDPRODUTO = pr.pr_cdproduto 
									   and 	pa.prb_cdprodutobluesoft = px.prb_cdprodutobluesoft 
									   and 	pa.data_processamento = vdata_processamento )
			order by 	pr.pr_cdproduto 
					,	pr.prb_cdprodutobluesoft 
					,	px.prb_cdprodutobluesoft 

			;

			drop table if exists tmp_faturamento_f0045_60;
			

			update tbpreco_aplicacao_lote_produto set margem_atual = cast( ((old_prc_valor - ec_valor_custo_precificacao) / old_prc_valor) * 100 as numeric(13,2)) 
			where old_prc_valor > ec_valor_custo_precificacao
			and   ec_valor_custo_precificacao > 0 
			and   old_prc_valor > 0 
			;
			

			update 	tbpreco_aplicacao_lote_produto 
			set 	new_prc_valor 				= old_prc_valor / (1 - (percentual/100))
				,	new_prc_valor_promocional	= case when coalesce(old_prc_valor_promocional,0) > 0 then  old_prc_valor_promocional / 0.95 else 0 end 
			where	coalesce(processado, 0) = 0
			and     data_processamento = vdata_processamento 
			;

			update tbpreco_aplicacao_lote_produto 
					set 	new_prc_valor_arred = CASE right(cast(new_prc_valor as varchar(15)),1) 
														WHEN '0' THEN new_prc_valor + 0.05
														WHEN '1' THEN new_prc_valor + 0.04
														WHEN '2' THEN new_prc_valor + 0.03
														WHEN '3' THEN new_prc_valor + 0.02
														WHEN '4' THEN new_prc_valor + 0.01
														WHEN '6' THEN new_prc_valor + 0.03
														WHEN '7' THEN new_prc_valor + 0.02
														WHEN '8' THEN new_prc_valor + 0.01
														ELSE new_prc_valor 
													END
						, 	new_prc_valor_promocional_arred = case when new_prc_valor_promocional > 0 then
																CASE right(cast(new_prc_valor_promocional as varchar(15)),1) 
																	WHEN '0' THEN new_prc_valor_promocional + 0.05
																	WHEN '1' THEN new_prc_valor_promocional + 0.04
																	WHEN '2' THEN new_prc_valor_promocional + 0.03
																	WHEN '3' THEN new_prc_valor_promocional + 0.02
																	WHEN '4' THEN new_prc_valor_promocional + 0.01
																	WHEN '6' THEN new_prc_valor_promocional + 0.03
																	WHEN '7' THEN new_prc_valor_promocional + 0.02
																	WHEN '8' THEN new_prc_valor_promocional + 0.01
																	ELSE new_prc_valor 
																END												
															else 
																0 end
			where	coalesce(processado, 0) = 0
			and   	data_processamento = vdata_processamento 
			;

			update 	tbpreco  		a
			set			prc_valor 					= x.new_prc_valor_arred 
					,	prc_valor_promocional 		= x.new_prc_valor_promocional_arred
			from 	tbpreco_aplicacao_lote_produto x 
			where	x.pr_cdproduto 				= a.pr_cdproduto 
			and 	x.prb_cdprodutobluesoft 	= a.prb_cdprodutobluesoft 
			and 	a.tab_pre_cd 				= x.tab_pre_cd 
			and		coalesce(x.processado, 0) 	= 0
			and   	data_processamento 			= vdata_processamento 
			and     x.margem_atual < x.margem_limite

			;
			INSERT INTO tbpreco_log 
						(	proc_log_seq			, 
							prc_data_aplicacao		, 
							tab_pre_cd				, 
							pr_cdproduto			, 
							pr_embalagemestoque		, 
							prb_cdprodutobluesoft	, 
							pre_embalagem			, 
							prc_valor				,
							valor_anterior_prc_valor
						)
			select 		proc_log_seq
					, 	current_date
					, 	tab_pre_cd
					, 	pr_cdproduto
					, 	embalagemestoque
					, 	prb_cdprodutobluesoft
					, 	'XX'
					, 	new_prc_valor_arred
					, 	old_prc_valor 
			from   	tbpreco_aplicacao_lote_produto
			where 	coalesce(processado, 0) 	= 0
			and   	data_processamento 			= vdata_processamento 
			;

			update 	tbpreco_aplicacao_lote_produto 
				set processado = 1
			where 	data_processamento = vdata_processamento
			;

			INSERT INTO TBINTEGRACAO_PRODUTO 
				(		pr_cdproduto
					,	prb_cdprodutobluesoftunitario 
					,	prb_cdprodutobluesoft 
					,	integracao_tipo_cd
					,	integracao_status_cd
				)
							   
			select 		pr_cdproduto
					, 	prb_cdprodutobluesoft_unitario
					, 	prb_cdprodutobluesoft 
					,	20008501 
					,	2
			from  tbpreco_aplicacao_lote_produto x
			where x.prb_cdprodutobluesoft_unitario = x.prb_cdprodutobluesoft
			  and x.data_processamento = vdata_processamento
			and not exists (	select 1 
										from  TBINTEGRACAO_PRODUTO a
								   		where 1 = 1
									      and a.pr_cdproduto = x.pr_cdproduto 
										  and a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoft_unitario 
									      and a.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft
									      and a.integracao_tipo_cd = 20008501
										  
								   );
			
			UPDATE  TBINTEGRACAO_PRODUTO A SET integracao_status_cd = 2
			FROM    tbpreco_aplicacao_lote_produto X
			where   x.prb_cdprodutobluesoft_unitario = x.prb_cdprodutobluesoft
			  and   x.data_processamento = vdata_processamento 
			  and   a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoft_unitario 
	          and   a.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft
			  and   a.integracao_tipo_cd = 20008501

			;

			

		INSERT INTO tbsistema_log (dtlog_insert, proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
		SELECT current_timestamp, 0, 99113, 'CARGA_LOJA', 'Aplicação de Preços | Alteração de Preços GERAIS PLANEJADO _ FIM'
		;

	end if;

end if;

	/* #21141 | Alteração para exclusão de preços filhos com valor e pai sem valor */

	/* Limpeza de Produtos sem preço PAI / Com preços filhos */
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
				drop table if exists tmp_preco_error ;
				create temp table tmp_preco_error 
				(
					tab_pre_cd 				int
				,	prb_cdprodutobluesoft 	int	
				)
				;
				insert into tmp_preco_error (tab_pre_cd , prb_cdprodutobluesoft )
				select 		px.tab_pre_cd 
						,	em.prb_cdprodutobluesoft
				from 		tbproduto				pr
				inner join 	tbprodutoembalagem		em on em.pr_cdproduto = pr.pr_cdproduto
				inner join  tbpreco 				px on px.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
				inner join  tbpreco 				p1 on p1.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft 	and	p1.tab_pre_cd = px.tab_pre_cd 

				where		1 = 1
				and			coalesce(p1.prc_valor,0) > 0 
				and			px.prc_valor = 0
				;
				update 	tbpreco 			x
				set    	prc_valor = 0
					,	prc_valor_promocional = 0 
				from  	tmp_preco_error 	er 
				where 	1 = 1 
				and 	er.tab_pre_cd = x.tab_pre_cd 
				and 	er.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft
				;				
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------------------------------------

	delete from tbpreco_aplicacao
	;
	
	insert into tbpreco_aplicacao 
	(		preco_aplicacao_data
		,	tab_pre_cd 					
		,	pr_cdproduto
	 	,	prb_cdprodutobluesoft_unitario 
		,	pr_embalagemestoque			
		,	prc_valor_embalagemestoque	
		,	pre_fatorestoque			
		,	prb_cdprodutobluesoft		
		,	pre_embalagem				
		,	prc_valor					
	 	,	prc_qtde_promocional 
	 	,	prc_valor_promocional 
	)
		select 		current_date 	
				,	pu.tab_pre_cd 				as tab_pre_cd
				,	pr.pr_cdproduto 			as pr_cdproduto
				,	pr.prb_cdprodutobluesoft	as pr_cdprodutobluesoft_unitario 
				,	pr.pr_embalagemestoque		as pr_embalagemestoque
				,	pu.prc_valor 				as prc_valor_embalagemestoque
				,	em.pre_fatorestoque			as pre_fatorestoque
				,	em.prb_cdprodutobluesoft	as prb_cdprodutobluesoft
				,	em.pre_embalagem			as pre_embalagem
				,	pg.prc_valor 				as prc_valor
				,	pu.prc_qtde_promocional		as prc_qtde_promocional
				,	pu.prc_valor_promocional    as prc_valor_promocional
		from 		tbproduto 					pr
		inner join  tbprodutoembalagem			em on em.pr_cdproduto = pr.pr_cdproduto 
		inner join  tbpreco 					pu on pu.pr_cdproduto = pr.pr_cdproduto and pu.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
		inner join  tbpreco 					pg on pg.pr_cdproduto = pr.pr_cdproduto and pg.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft and pg.tab_pre_cd = pu.tab_pre_cd 
		where		pr.pr_status = 'true'
		  and       coalesce(pg.prc_valor,0) <> 0
	;

	insert into tbpreco_aplicacao 
	(		preco_aplicacao_data
		,	tab_pre_cd 					
		,	pr_cdproduto
	 	,	prb_cdprodutobluesoft_unitario 
		,	pr_embalagemestoque			
		,	prc_valor_embalagemestoque	
		,	pre_fatorestoque			
		,	prb_cdprodutobluesoft		
		,	pre_embalagem				
		,	prc_valor					
	 	,	prc_qtde_promocional 
	 	,	prc_valor_promocional 
	)
		select 		current_date 	
				,	pu.tab_pre_cd 				as tab_pre_cd
				,	pr.pr_cdproduto 			as pr_cdproduto
				,	pr.prb_cdprodutobluesoft	as pr_cdprodutobluesoft_unitario 
				,	pr.pr_embalagemestoque		as pr_embalagemestoque
				,	pu.prc_valor 				as prc_valor_embalagemestoque
				,	em.pre_fatorestoque			as pre_fatorestoque
				,	em.prb_cdprodutobluesoft	as prb_cdprodutobluesoft
				,	em.pre_embalagem			as pre_embalagem
				,	pg.prc_valor 				as prc_valor
				,	pu.prc_qtde_promocional		as prc_qtde_promocional
				,	pu.prc_valor_promocional    as prc_valor_promocional
		from 		tbproduto 					pr
		inner join  tbprodutoembalagem			em on em.pr_cdproduto = pr.pr_cdproduto 
		inner join  tbpreco_agendamento			pu on pu.pr_cdproduto = pr.pr_cdproduto and pu.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
		inner join  tbpreco_agendamento			pg on pg.pr_cdproduto = pr.pr_cdproduto and pg.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft and pg.tab_pre_cd = pu.tab_pre_cd and pg.prca_dt_aplicacao = pu.prca_dt_aplicacao 
		where		1 =  1 
		and 		pr.pr_status = 'true'
		and       	coalesce(pg.prc_valor,0) <> 0
		and			pu.prca_dt_aplicacao = current_date 
		and			not exists	( 	
										select 	1 
										from 	tbpreco_aplicacao		aa
										where	aa.tab_pre_cd 				= pu.tab_pre_cd 
										  and 	aa.pr_cdproduto 			= pr.pr_cdproduto 
										  and   aa.prb_cdprodutobluesoft	= em.prb_cdprodutobluesoft 
								)

		;
		UPDATE tbpreco_aplicacao		A
				SET			prc_valor_embalagemestoque 	= UP.prc_valor_embalagemestoque
						,	prc_valor						= UP.prc_valor
						,	prc_qtde_promocional			= UP.prc_qtde_promocional
						,	prc_valor_promocional			= UP.prc_valor_promocional
		
		FROM 	(			select 		current_date 	
									,	pu.tab_pre_cd 				as tab_pre_cd
									,	pr.pr_cdproduto 			as pr_cdproduto
									,	pr.prb_cdprodutobluesoft	as prb_cdprodutobluesoft_unitario 
									,	pr.pr_embalagemestoque		as pr_embalagemestoque
									,	pu.prc_valor 				as prc_valor_embalagemestoque
									,	em.pre_fatorestoque			as pre_fatorestoque
									,	em.prb_cdprodutobluesoft	as prb_cdprodutobluesoft
									,	em.pre_embalagem			as pre_embalagem
									,	pg.prc_valor 				as prc_valor
									,	pu.prc_qtde_promocional		as prc_qtde_promocional
									,	pu.prc_valor_promocional    as prc_valor_promocional
							from 		tbproduto 					pr
							inner join  tbprodutoembalagem			em on em.pr_cdproduto = pr.pr_cdproduto 
							inner join  tbpreco_agendamento			pu on pu.pr_cdproduto = pr.pr_cdproduto and pu.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
							inner join  tbpreco_agendamento			pg on pg.pr_cdproduto = pr.pr_cdproduto and pg.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft and pg.tab_pre_cd = pu.tab_pre_cd and pg.prca_dt_aplicacao = pu.prca_dt_aplicacao 
							where		1 =  1 
							and 		pr.pr_status 				= 'true'
							and       	coalesce(pg.prc_valor,0) 	<> 0
							and			pu.prca_dt_aplicacao 		= current_date 
			
				) UP
		WHERE 	1 = 1
		AND		UP.TAB_PRE_CD 						= A.TAB_PRE_CD 
		AND		UP.pr_cdproduto						= A.PR_CDPRODUTO 
		AND		UP.prb_cdprodutobluesoft_unitario	= A.prb_cdprodutobluesoft_unitario
		AND		UP.prb_cdprodutobluesoft			= A.PRB_CDPRODUTOBLUESOFT 
	
		;
		/* APLICAÇÃO PERMANENTE AGENDADA PERMANENTE PARA TABELA PADRÃO */
		update	tbpreco a
		set		prc_valor 				= b.prc_valor
			,	prc_qtde_promocional 	= b.prc_qtde_promocional
			,	prc_valor_promocional 	= b.prc_valor_promocional
		from 	tbpreco_agendamento b
		where 	1 = 1 
		and		a.tab_pre_cd = 1
		and		a.pr_cdproduto = b.pr_cdproduto 
		and		a.prb_cdprodutobluesoft = b.prb_cdprodutobluesoft 
		and 	coalesce(prca_aplicacao_definitiva,0) = 1
		and		coalesce(b.prca_dt_aplicacao, '1900-01-01') = current_date 

	;
	

--------------------------------------------------------------------------------------------
-----https://oxan.acelerato.com/tickets/29331 - 04/08/2023
--------------------------------------------------------------------------------------------

/* 145559198038CERVEJA BRAHMA 300ML + GARRAFA */
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 145559
--select * from tbpreco_aplicacao where pr_cdproduto = 52634
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 52634 and prb_cdprodutobluesoft = 145559  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 52634 and prb_cdprodutobluesoft = 145559  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 52634 and prb_cdprodutobluesoft = 145559  and tab_pre_cd = 1)
where pr_cdproduto = 52634
and prb_cdprodutobluesoft = 198038
;
/*139894198039CERVEJA BOHEMIA PURO MALTE 300ML + GARRAFA10003*/
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 139894
--select * from tbpreco_aplicacao where pr_cdproduto = 62821
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 62821 and prb_cdprodutobluesoft = 139894  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 62821 and prb_cdprodutobluesoft = 139894  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 62821 and prb_cdprodutobluesoft = 139894  and tab_pre_cd = 1)
where pr_cdproduto = 62821
and prb_cdprodutobluesoft = 198039
;

/*163278198058CERVEJA SKOL PURO MALTE 300ML + GARRAFA10004*/
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 163278
--select * from tbpreco_aplicacao where pr_cdproduto = 65697
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 65697 and prb_cdprodutobluesoft = 163278  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 65697 and prb_cdprodutobluesoft = 163278  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 65697 and prb_cdprodutobluesoft = 163278  and tab_pre_cd = 1)
where pr_cdproduto = 65697
and prb_cdprodutobluesoft = 198058
;

/*52633198060CERVEJA SKOL 300ML + GARRAFA10005*/
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 52633
--select * from tbpreco_aplicacao where pr_cdproduto = 65697
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 52633 and prb_cdprodutobluesoft = 52633  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 52633 and prb_cdprodutobluesoft = 52633  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 52633 and prb_cdprodutobluesoft = 52633  and tab_pre_cd = 1)
where pr_cdproduto = 52633
and prb_cdprodutobluesoft = 198060
;

/*176898198061CERVEJA ANTARCTICA 300ML + GARRAFA10006*/
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 176898
--select * from tbpreco_aplicacao where pr_cdproduto = 66921
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 66921 and prb_cdprodutobluesoft = 176898  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 66921 and prb_cdprodutobluesoft = 176898  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 66921 and prb_cdprodutobluesoft = 176898  and tab_pre_cd = 1)
where pr_cdproduto = 66921
and prb_cdprodutobluesoft = 198061
;

/*CERV. ANTARCTICA ORIGINAL 300ML + GARRAFA + GARRAFA 04/08/2023 */
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 59800
--select * from tbpreco_aplicacao where pr_cdproduto = 66921
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 59800 and prb_cdprodutobluesoft = 59800  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 59800 and prb_cdprodutobluesoft = 59800  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 59800 and prb_cdprodutobluesoft = 59800  and tab_pre_cd = 1)
where pr_cdproduto = 59800
and prb_cdprodutobluesoft = 205748
;

/*CERVEJA BUDWEISER 300ML + GARRAFA 04/08/2023 */
--select pr_cdproduto, prb_cdprodutobluesoft from tbproduto where prb_cdprodutobluesoft = 203938
--select * from tbpreco_aplicacao where pr_cdproduto = 66921
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque + 1 from tbpreco_aplicacao where pr_cdproduto = 203938 and prb_cdprodutobluesoft = 203938  and tab_pre_cd = 1)
,prc_valor_promocional = (select prc_valor_promocional + 1 from tbpreco_aplicacao where pr_cdproduto = 203938 and prb_cdprodutobluesoft = 203938  and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 203938 and prb_cdprodutobluesoft = 203938  and tab_pre_cd = 1)
where pr_cdproduto = 203938
and prb_cdprodutobluesoft = 205749
;

-----> VALOR COM DESOCNTO ------ 
--- ALTERAÇÃO EM 08/09/2025 _ JOCELIO 
--select * from tbpreco_aplicacao where pr_cdproduto = 57149
update tbpreco_aplicacao
set prc_valor_embalagemestoque = (select prc_valor_embalagemestoque - 1  from tbpreco_aplicacao where pr_cdproduto = 57149 and prb_cdprodutobluesoft = 57149  and tab_pre_cd = 1)
--,prc_valor_promocional = (select prc_valor_promocional - 2 from tbpreco_aplicacao where pr_cdproduto = 57149 and prb_cdprodutobluesoft = 57149 and tab_pre_cd = 1)
,prc_valor = (select prc_valor + 1 from tbpreco_aplicacao where pr_cdproduto = 57149 and prb_cdprodutobluesoft = 57149  and tab_pre_cd = 1)
where pr_cdproduto = 57149
and prb_cdprodutobluesoft = 199728
and tab_pre_cd = 1
;

end;
$BODY$;

ALTER FUNCTION public.p0045_60_1012014_produto_preco_aplicacao()
    OWNER TO postgres;

