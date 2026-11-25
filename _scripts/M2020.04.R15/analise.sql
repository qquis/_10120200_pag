
select * from tbpreco_aplicacao_lote WHERE PRG_CDGRUPO = 723
update tbpreco_aplicacao_lote set percentual = 10, margem_limite = 40, data_processamento = '2026-11-24' where prg_cdgrupo IN( 28)
update tbpreco_aplicacao_lote set percentual = 20, margem_limite = 40, data_processamento = '2026-11-24' where prg_cdgrupo IN( 28)
delete from tbpreco_aplicacao_lote_produto

select * from tbestoquecusto

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
					,	0 -- (select proc_log_seq from tbprocesso_log where proc_log_uuid = vuuid)
					,	'X' ---  UUID 
					,   l.percentual 
                    ,   0
					,	ec.ec_valor_custo_precificacao

			from 		tbproduto 				pr
			inner join  tbproduto_subgrupo		sg on sg.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
			inner join  tbproduto_grupo 		gr on gr.prg_cdgrupo = sg.prg_cdgrupo
			inner join  tbproduto_secao 		sc on sc.prs_cdsecao = gr.prs_cdsecao 
			inner join  tbproduto_departamento 	dp on dp.prd_cddepartamento = sc.prd_cddepartamento 
			inner join  tbestoquecusto 			es on es.pr_cdproduto = pr.pr_cdproduto 
			inner join  tbpreco					px on px.pr_cdproduto = pr.pr_cdproduto 
			inner join  tbpreco_aplicacao_lote  l on l.prg_cdgrupo = gr.prg_cdgrupo and l.prs_cdsecao = sc.prs_cdsecao
            left join   tbestoquecusto          ec on ec.pr_cdproduto = pr.pr_cdproduto 
			where		1 = 1
			and         px.tab_pre_cd = 1 
			and			( 		   ( pr.pr_status = 'true' 
									 and pr.pr_cdproduto in ( select 	pr_cdproduto 
											 from 	tbest_faturamento_data 
											 where	datafaturamento >= '2026-06-01'
											 group by pr_cdproduto )
									)
								or es.ec_embalagemestoque_qtde <> 0 )
			and			px.prc_valor <> 0 
			and			l.data_processamento = '2026-11-24'
			and			NOT EXISTS ( select 1 
									 from 	tbpreco_aplicacao_lote_produto pa 
									 WHERE 	pa.PR_CDPRODUTO = pr.pr_cdproduto 
									   and 	pa.prb_cdprodutobluesoft = px.prb_cdprodutobluesoft 
									   and 	pa.data_processamento = '2026-11-24' )
			order by 	pr.pr_cdproduto 
					,	pr.prb_cdprodutobluesoft 
					,	px.prb_cdprodutobluesoft 

			;

			DELETE FROM tbpreco_aplicacao_lote_produto
			select cast( 1 - (percentual/100) as numeric(17,4)) from tbpreco_aplicacao_lote_produto
			