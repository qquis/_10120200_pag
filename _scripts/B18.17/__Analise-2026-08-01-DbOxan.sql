-- Active: 1773758617277@@127.0.0.1@5432@oxan


    select * from tbfaturamento_bluesoft_item limit 10

                insert into tbfaturamento_bluesoft_item (
                                 fat_blue_seq
                            ,    op_cdoperacao 
                            ,    numeropedido 
                            ,    numeropedido_fv
                            ,    df_nf_seq_blue
                            ,    cdpessoabluesoft_cliente
                            ,    prb_cdprodutobluesoft
                            ,    prb_cdprodutobluesoft_unitario
                            ,    prb_embalagem
                            ,    prb_fatorestoque
                            ,    embalagem_descricao
                            ,    qtde_unitaria_solicitada
                            ,    qtde_unitaria_faturada
                            ,    qtde_solicitada
                            ,    qtde_faturada
                            ,    valor_custo_com_icm_unit
                            ,    valor_custo_com_icm
                            ,    valor_custo
                            ,    valor_preco_tabela
                            ,    valor_preco 
                            ,    valor_preco_aplicado 
                            ,    valor_verba 
                            ,    valor_verba_gerencia 
                            ,    valor_verba_calculada 
                            ,    valor_desconto_financeiro 
                            ,    valor_nf_item_bruto 
                            ,    valor_nf_item 
                            ,    item_nf_bonificado 
                            ,    percentual_desconto_financeiro 
                )
                       select 		f.fat_blue_seq 
                            ,		1 											as op_cdoperacao 
                            ,		i.numeropedido 
                            ,		i.numeropedido_fv
                            ,		coalesce(nf.df_nf_seq_blue,0) 				as df_nf_seq_blue
                            ,		pc.cdpessoabluesoft_cliente					as cdpessoabluesoft_cliente
                            ,		i.prb_cdprodutobluesoft
                            ,		pb.prb_cdprodutobluesoftunitario 
                            ,		cast(left(pb.prb_embalagemestoque,2) as varchar(2)) as prb_embalagem
                            ,		pb.prb_fatorestoque 
                            ,		'' 											as embalagem_descricao
                            ,		pb.prb_fatorestoque * i.qtde_pedida 		as qtde_unitaria_solicitada
                            ,		pb.prb_fatorestoque * i.qtde_separada 		as qtde_unitaria_faturada
                            ,		i.qtde_pedida 								as qtde_solicitada
                            ,		i.qtde_separada 							as qtde_faturada
                            ,		0											as valor_custo_com_icm_unit
                            ,		0											as valor_custo_com_icm
                            ,		0											as valor_custo
                            ,		i.valor_preco								as valor_preco_tabela
                            ,		0           								as valor_preco 
                            ,		i.valor_preco_final 						as valor_preco_aplicado 
                            ,		0                                    		as valor_verba 
                            ,		0											as valor_verba_gerencia 
                            ,		0                                           as valor_verba_calculada 
                            ,		0 											as valor_desconto_financeiro 
                            ,		0											as valor_nf_item_bruto 
                            ,		0											as valor_nf_item 
                            ,		case when nf.df_nf_tipo = 34 
                                                then 1 
                                                else 0 end 						as item_nf_bonificado 
                            ,		p.descontofinanceiro 						as percentual_desconto_financeiro 
	
                    from 		tbfaturamento_bluesoft_fv_item 				i
                    inner join 	tbfaturamento_bluesoft_fv_cliente 			pc on pc.numeropedido = i.numeropedido and pc.numeropedido_fv = i.numeropedido_fv
                    inner join  tbfaturamento_bluesoft						f  on f.numeropedido = pc.numeropedido and f.numeropedido_fv = pc.numeropedido_fv
                            inner join 	tbfaturamento_bluesoft_fv 			p  on p.numeropedido_fv = pc.numeropedido_fv
                            inner join  tbfaturamento_bluesoft_status 		st on st.pedido_status_cd = pc.pedido_status_cd
                            inner join  tbfaturamento_bluesoft_tipo         t  on t.pedido_tipo_cd = p.pedido_tipo_cd 
                            left join   tbfaturamento_bluesoft_fv_nf		nf on nf.numeropedido = pc.numeropedido 
                                    and nf.numeropedido_fv = p.numeropedido_fv and nf.df_nf_tipo in( 104, 34)

                    inner join  tbprodutobluesoft 							pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
                    WHERE		1 = 1
                    AND			NOT EXISTS (	Select 1
                                                FROM 	tbfaturamento_bluesoft_item XX
                                                WHERE	XX.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft 
                                                and   XX.numeropedido = i.numeropedido 
                                                and   xx.numeropedido_fv = i.numeropedido_fv 
                                    

                                            )
                    and         i.numeropedido = 472420



