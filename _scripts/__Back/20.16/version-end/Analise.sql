

/*
	INSERT INTO TbProduto
		(	    pr_cdproduto
			,	prb_cdprodutobluesoft
			,	pr_descricao 
			,	pr_status
			,	pr_cdbarra_principal		
			, 	pr_embalagemestoque
			,	pr_embalagemcompra
			, 	pr_embalagemcompra_fator
			,	dtlog_insert 
		 	,	dtlog_update 
		 	,	dtlog_update_api 
		)
*/





	SELECT 		BL.prb_cdprodutobluesoft_pk 
			,	BL.prb_cdprodutobluesoft_pk
			,	left(BL.prb_descricao,60) 	/*Alteração em 15/12/2022*/
			,	BL.prb_status
			,   BL.prb_cdbarra_principal
			,	BL.prb_embalagemestoque 
			,	BL.prb_embalagemestoque ---- Embalagem de Compra será definida inicialmente como embalagemestoque
			,	1
			,	current_timestamp
			,	current_timestamp
			,	current_timestamp

	FROM 		TbProdutoBlueSoft  			BL
	INNER JOIN  tbproduto_subgrupo 			SG ON SG.prsg_cdsubgrupo = BL.prb_cdsubgrupo 
	INNER JOIN  tbproduto_grupo 			GR ON GR.prg_cdgrupo = SG.prg_cdgrupo
	INNER JOIN  tbproduto_secao             SR ON SR.prs_cdsecao = GR.prs_cdsecao
	INNER JOIN  tbproduto_Departamento      DP ON DP.prd_cddepartamento = SR.prd_cddepartamento 
	where 		1 = 1 
	and	  		BL.prb_cdprodutobluesoftunitario = BL.prb_cdprodutobluesoft_pk
	and   		BL.prb_cdprodutobluesoftunitario not in ( select prb_cdprodutobluesoft from tbproduto )
	and   		BL.prb_status = '1'
	and			DP.prd_habilita_integracao_zanthus = 'true'
	and			BL.prb_embalagemestoque in ('UN','KG')
--	and			bl.prb_cdprodutobluesoft_pk not in ( select prb_cdprodutobluesoft from tbproduto_composicao  GROUP BY prb_cdprodutobluesoft )

	order by 	BL.prb_descricao ASC; 





	select * from tbproduto where pr_descricao like '*C%'

	SELECT * FROM tbfc_figurafiscal_produto where prb_cdprodutobluesoft = 223134
	SELECT * FROM tbfc_regrafiscal_nfce_produto WHERE PRB_CDPRODUTOBLUESOFT = 223134

	select * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 223134

	select * from tbzanthus_tributacao_nfce where pr_cdproduto in (223133,223134,223135,223166,223199,223200,223201,223232,223233,223235,223234,223236,223100) and pr_cdproduto = 223236
	select * from TbZanthusTab_Regra_Icms where pr_cdproduto in (223133,223134,223135,223166,223199,223200,223201,223232,223233,223235,223234,223236,223100) and pr_cdproduto = 223236

	select cod_mercadoria, cod_situacao_tributaria, aliquota_icms, percentual_reduz_b_calculo, cod_sit_trib_pis, aliquota_pis, cod_sit_trib_cofins, aliquota_cofins   
	from tbzanthustab_mercadoria 
	where pr_cdproduto in (223133,223134,223135,223166,223199,223200,223201,223232,223233,223235,223234,223236,223100)
	and pr_cdproduto = 223100














select * from TbZanthustab_produto_decomposicao_insum where cod_insumo like '%102044'




















SELECT	me.pr_cdproduto				
                            ,   pr.prb_cdprodutobluesoft as prb_cdprodutobluesoftunitario 				
                            ,	me.prb_cdprodutobluesoft						
                            ,	me.preg_cdbarra								
                            ,	me.cod_loja 									
                            ,	me.controle 									
                            ,	me.cod_mercadoria 								
                            ,	me.descricao 									
                            ,	me.desc_abr             as descricao_abr								
                            ,	me.cod_departamento 							
                            ,	me.cod_tributacao_mercadoria					
                            ,	me.cod_tecla 									
                            ,	me.percentual_desc_venda						
                            ,	me.permissao_venda  							
                            ,	me.percentual_reduz_b_calculo					
                            ,	me.indica_merc_peso_variavel					
                            ,	me.custo_unitario 								
                            ,	me.grupo_garantia								
                            ,	me.fator_seguranca_venda_estoque				
                            ,	me.unidade_venda								
                            ,	me.data_modo_preco 							
                            ,	me.margem_mercadoria 							
                            ,	me.quantidade_embalagem 						
                            ,	me.cod_fornecedor								
                            ,	me.custo_moeda_estavel							
                            ,	me.aliquota_icms 								
                            ,	me.quantidade_bonus_venda						
                            ,	me.quantidade_max_preco_promo 					
                            ,	me.valor_total_preco_promocao 					
                            ,	me.custo_contabil 								
                            ,	me.quantidade_maxima_venda 					
                            ,	me.multiplica_pontos_valor_liq 				
                            ,	me.quantidade_pontos_venda 					
                            ,	me.cod_situacao_tributaria 					
                            ,   me.data_cadastro 								
                            ,	me.data_ultima_alteracao 						
                            ,	me.cod_ncm										
                            ,	me.cod_produto_pai	
                            ,	me.cest 
                            ,   me.cfop
                            ,   me.cod_sit_trib_pis
                            ,   me.aliquota_pis
                            ,   me.cod_sit_trib_cofins
                            ,   me.aliquota_cofins
                FROM            tbzanthustab_mercadoria me
                inner join      tbproduto pr on pr.pr_cdproduto = me.pr_cdproduto
                WHERE   1 = 1 
				 -- and   me.prb_cdprodutobluesoft = 223134

				and ( 			pr.pr_cdproduto in (
		                                               select x.pr_cdproduto 
		                                               from   tbintegracao_produto x 
		                                               where  1 = 1
		                                                 and  x.integracao_tipo_cd = 20008501
		                                                 and  x.integracao_status_cd = 2
		                  
		                                            )
					 or 
							   pr.prb_cdprodutobluesoft in (select xx.prb_cdprodutobluesoft 
							                       from   TbZanthustab_produto_decomposicao_insum xx
		                                            where xx.pr_cdproduto in (select ax.pr_cdproduto 
							                                               from   tbintegracao_produto ax 
							                                               where  1 = 1
							                                                 and  ax.integracao_tipo_cd = 20008501
							                                                 and  ax.integracao_status_cd = 2
																			group by ax.pr_cdproduto 
																		  )
													group by  xx.prb_cdprodutobluesoft 
												)
					)



				select * from 	TbZanthustab_produto_decomposicao_insum	where pr_cdproduto = 223100									















	

	