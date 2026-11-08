select * from tbzanthustab_mercadoria
select * from tbzanthustab_mercadoria_tipo_venda
select * from tbzanthustab_mercadoria_tipo_venda_qtde 
select * from TbZanthustab_produto_decomposicao
select * from TbZanthustab_produto_decomposicao_insum
select * from tbzanthustabtributacao
select * from tbzanthustabtributacao_cod_tributacao 
select * from tbfc_regrafiscal
select * from tbzanthus_tributacao_nfce limit 10
select * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoftunitario = 43

select * from tbfc_figurafiscal_produto
select * from tbfc_regrafiscal_operacao
select * from tbfc_regrafiscal
select * from tbfc_icms
select * from tbfc_regrafiscal_nfce_produto limit 10
select * from tbfc_ibs
select * from tbparticipante_endereco_tipo

select 		a.prb_cdprodutobluesoft
	,		a.fc_figurafiscal_cd 
	,		r.fc_regrafiscal_cd 
	,		r.cfop 
	,		r.tipocliente
	,		r.icms_cd 
	,		icm.codigotributacao
	,		icm.codigoorigem
	,		icm.aliquota
	,		icm.reducao 
	,		a.*
from   		tbfc_figurafiscal_produto a 
left join 	tbfc_regrafiscal		  r 	on r.fc_figurafiscal_cd = a.fc_figurafiscal_cd
left join   tbfc_regrafiscal_operacao x 	on x.fc_regrafiscal_cd = r.fc_regrafiscal_cd
left join   tbfc_icms 				 icm 	on icm.icms_cd = r.icms_cd 
where		1 = 1
and 		x.df_nf_tipo = 26 
and			r.tipocliente = 'TIPO_CONSUMIDOR'




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
                            ,   coalesce(me.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal
							,	f.rt_codigo_cst_ibs_cbs
							,	f.rt_codigo_class_trib_ibs_cbs
							,	f.

                FROM            tbzanthustab_mercadoria me
                inner join      tbproduto pr on pr.pr_cdproduto = me.pr_cdproduto
				inner join      tbfc_regrafiscal_nfce_produto f on f.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft and f.nfce_produto_tipo_cd = 1