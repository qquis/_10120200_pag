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
                       select 
					   
					   
					   				f.data_emissao 
					   
					   		,		f.fat_blue_seq 
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
												and   xx.op_cdoperacao = 1
                                    

                                            )
					and         i.op_cdoperacao = 1


					select * from tbfaturamento_bluesoft where numeropedido_fv = 466577
					select * from tbfaturamento_bluesoft_item where numeropedido = 466577
					select * from tbfaturamento_bluesoft_fv_item where numeropedido = 466577
					select * from tbfaturamento_bluesoft_fv_cliente where numeropedido = 466577
					select * from tbfaturamento_bluesoft where numeropedido = 466577

					SELECT * FROM tbfaturamento_bluesoft WHERE numeropedido_fv = 424287
					SELECT * FROM tbfaturamento_bluesoft_fv_cliente WHERE numeropedido_fv = 424287
                                        SELECT * FROM tbfaturamento_bluesoft_fv_cliente where numeropedido = 466577
					SELECT * FROM tbfaturamento_bluesoft_fv_item where numeropedido_fv = 424056

                                        select * from tbfaturamento_bluesoft_status

                                        SELECT a.numeropedido, a.numeropedido_fv, a.fat_blue_status_cd, st.fat_blue_status_descricao, a.data_emissao, a.df_nf_seq_blue
                                        FROM   tbfaturamento_bluesoft A
                                        left join tbfaturamento_bluesoft_status st on st.fat_blue_status_cd = a.fat_blue_status_cd
                                        WHERE  1 = 1 
                                          AND  NOT EXISTS (SELECT 1
                                                     FROM   tbfaturamento_bluesoft_item B
                                                     WHERE  A.numeropedido = B.numeropedido
                                                        AND A.numeropedido_fv = B.numeropedido_fv
                                                        AND B.op_cdoperacao = 1)
                                          AND   a.op_cdoperacao = 1
                                          AND   a.data_emissao >= '2020-01-01'
                                          and   a.df_nf_seq_blue = 0 
                                          and   a.numeropedido_fv = 484367
                                          


                                 SELECT    a.op_cdoperacao 
                                         , a.numeropedido
                                         , a.numeropedido_fv
                                         , a.fat_blue_status_cd
                                         , st.fat_blue_status_descricao
                                         , a.data_emissao
                                         , a.df_nf_seq_blue
                                    FROM   tbfaturamento_bluesoft A
                                    left join tbfaturamento_bluesoft_status st on st.fat_blue_status_cd = a.fat_blue_status_cd
                                    WHERE  1 = 1 
                                      AND  NOT EXISTS (SELECT 1
                                    FROM   tbfaturamento_bluesoft_item B
                                    WHERE  A.numeropedido = B.numeropedido
                                      AND A.numeropedido_fv = B.numeropedido_fv
                                      AND B.op_cdoperacao = 1)
                                      AND   a.op_cdoperacao = 1
                                      AND   a.data_emissao >= '2020-01-01'
                                      AND   a.df_nf_seq_blue = 0 
                                      and a.numeropedido_fv = 424287

                                    union 

                                    select 	op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	x.fat_blue_status_cd
                                        ,	s.fat_blue_status_descricao 
                                        ,   x.data_emissao
                                        ,   x.df_nf_seq_blue
                                    from tbfaturamento_bluesoft  x
                                    left join tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = x.fat_blue_status_cd 
                                    where not exists ( 
                                                select 1
                                                from tbfaturamento_bluesoft_item a
                                                where 1 = 1
                                                and a.op_cdoperacao = x.op_cdoperacao 
                                                and a.numeropedido = x.numeropedido 
                                                and a.numeropedido_fv = x.numeropedido_fv

                                            )
                                    and x.op_cdoperacao = 1
                                    and x.numeropedido_fv = 424287

                select * from tbfaturamento_bluesoft_fv where numeropedido_fv = 424287
                select * from tbfaturamento_bluesoft_fv_cliente where numeropedido_fv = 424287
                select * from tbfaturamento_bluesoft_fv_item where numeropedido_fv = 424287
                select * from tbfaturamento_bluesoft_fv_nf where numeropedido_fv = 424287


                