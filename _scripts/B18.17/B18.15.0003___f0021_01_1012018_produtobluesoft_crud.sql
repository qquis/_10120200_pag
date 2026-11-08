



CREATE OR REPLACE 
-- DROP 
FUNCTION public.f0021_01_1012018_produtobluesoft_crud(
          sqlcommand character varying
        , vprb_cdprodutobluesoft_pk integer
        , vprb_cdprodutobluesoftunitario integer
        , vprb_descricao character varying
        , vprb_embalagemestoque character
        , vprb_fatorestoque numeric
        , vprb_status_embalagemcaixa boolean
        , vprb_embalagemcompra character
        , vprb_embalagemcompra_qtdeunitaria numeric
        , vprb_cdbarra_principal character
        , vprb_cdprodutobluesoft_controleestoque integer
        , vprb_cdprodutobluesoft_controlepreco integer
        , vprb_cdsubgrupo integer
        , vprb_dt_cadastro date
        , vprb_dt_ultimaalteracao date
        , vprb_cdpessoabluesoft_fabricante integer
        , vprb_vendaexterna boolean
        , vprb_descricao_fiscal character varying
        , vprb_cdproduto_compra_padrao integer
        , vprbf_seq integer
        , vprb_status boolean
        , vprb_tipo_composicao_cd integer
        , vprb_descricao_gondola character varying
        , vprb_descricao_cupom character varying
        , vprb_descricao_balanca character varying
        , vprb_cdpessoabluesoft_fornecedor integer
        , vprb_cdpessoabluesoft_fornecedor_troca integer
        , vprb_pesobruto numeric
        , vprb_pesoliquido numeric
        , vprb_largura numeric
        , vprb_altura numeric
        , vprb_pesoaproximado numeric
        , vprb_comprimento numeric
        , vprb_blue_fc_cbenef_cd character varying
        , vcommand_api boolean
        , vatualizalog int
        
        )
 RETURNS void
 LANGUAGE plpgsql
AS $function$
BEGIN 

			

			-------------------------------------------------------------------------------------------------------------------------------
			-------------------------------------------------------------------------------------------------------------------------------
			-------------------------------------------------------------------------------------------------------------------------------
			-------------------------------------------------------------------------------------------------------------------------------
			-------------------------------------------------------------------------------------------------------------------------------	
			/*Prepara o log para enviar para a base zanthus caso ocorra alteração */		

			Insert into tbintegracao_produto 
					(
							pr_cdproduto
						,	prb_cdprodutobluesoftunitario 
						,	prb_cdprodutobluesoft 
						,	integracao_tipo_cd 
						,	integracao_status_cd 
					)
				
				Select 		coalesce(B.pr_cdproduto,0)
						,	A.prb_cdprodutobluesoftunitario
						,	A.prb_cdprodutobluesoftunitario
						,	20008590
						,	2
				FROM		tbprodutobluesoft A
				INNER join 	tbproduto         B ON B.prb_cdprodutobluesoft = a.prb_cdprodutobluesoftunitario 
				WHERE 1 = 1
				  and a.prb_cdprodutobluesoft_pk = vprb_cdprodutobluesoft_pk
				  and (			 a.prb_descricao != vprb_descricao
				  			or	 a.prb_embalagemestoque != vprb_embalagemestoque		
							or   a.prb_fatorestoque != vprb_fatorestoque
							or   a.prb_cdbarra_principal != vprb_cdbarra_principal
							or   a.prb_status != vprb_status
							or   a.prb_descricao_cupom != vprb_descricao_cupom
							or   a.prb_descricao_balanca != vprb_descricao_balanca
							or   coalesce(a.prb_pesobruto,0) != coalesce(vprb_pesobruto,0)
							or   coalesce(a.prb_pesoliquido,0) != coalesce(vprb_pesoliquido,0)
							or   coalesce(a.prb_altura,0) != coalesce(vprb_altura,0)
							or   coalesce(a.prb_largura,0) != coalesce(vprb_largura,0)
							or   coalesce(a.prb_pesoaproximado,0) != coalesce(vprb_pesoaproximado,0)
							or   coalesce(a.prb_comprimento,0) != coalesce(vprb_comprimento,0)
						)

	  			and       not exists ( 	select 1 
								from   tbintegracao_produto x
								where  x.pr_cdproduto = B.pr_cdproduto 
								  and  x.prb_cdprodutobluesoftunitario  = A.prb_cdprodutobluesoftunitario 
								  and  x.integracao_tipo_cd = 20008590
						   )						
				;   

			UPdate tbintegracao_produto XX
				  set  dtlog_update = current_timestamp
					,   integracao_status_cd = 2
				from    	tbprodutobluesoft A
				inner join 	tbproduto B ON B.prb_cdprodutobluesoft = A.prb_cdprodutobluesoftunitario
				WHERE 1 = 1 
			      --------------------------------------------------------------------------------
				  and xx.prb_cdprodutobluesoft = a.prb_cdprodutobluesoftunitario 
				  and xx.prb_cdprodutobluesoftunitario = a.prb_cdprodutobluesoftunitario
				  and xx.integracao_tipo_cd = 20008590
				  --------------------------------------------------------------------------------
				  and a.prb_cdprodutobluesoft_pk = vprb_cdprodutobluesoft_pk
				  --------------------------------------------------------------------------------
 				  and (			 a.prb_descricao != vprb_descricao
				  			or	 a.prb_embalagemestoque != vprb_embalagemestoque		
							or   a.prb_fatorestoque != vprb_fatorestoque
							or   a.prb_cdbarra_principal != vprb_cdbarra_principal
							or   a.prb_status != vprb_status
							or   a.prb_descricao_cupom != vprb_descricao_cupom
							or   a.prb_descricao_balanca != vprb_descricao_balanca
							or   coalesce(a.prb_pesobruto,0) != coalesce(vprb_pesobruto,0)
							or   coalesce(a.prb_pesoliquido,0) != coalesce(vprb_pesoliquido,0)
							or   coalesce(a.prb_altura,0) != coalesce(vprb_altura,0)
							or   coalesce(a.prb_largura,0) != coalesce(vprb_largura,0)
							or   coalesce(a.prb_pesoaproximado,0) != coalesce(vprb_pesoaproximado,0)
							or   coalesce(a.prb_comprimento,0) != coalesce(vprb_comprimento,0)
						) 
				;

		-------------------------------------------------------------------------------------------------------------------------------
		-------------------------------------------------------------------------------------------------------------------------------
		-------------------------------------------------------------------------------------------------------------------------------
		-------------------------------------------------------------------------------------------------------------------------------
		-------------------------------------------------------------------------------------------------------------------------------
		/*Processa o registro*/

		IF (SQLCOMMAND = 'DBINSERT' OR SQLCOMMAND = 'DBINSERT_API')
		THEN
			if exists (	SELECT 	1 
					  	FROM 	tbprodutobluesoft
					  	WHERE 	prb_cdprodutobluesoft_pk = vprb_cdprodutobluesoft_pk)
			THEN
				SQLCOMMAND:= 'DBUPDATE';
			ELSE
				SQLCOMMAND:= 'DBINSERT';

			END IF;
		END IF;
		
		IF (SQLCOMMAND = 'DBUPDATE')
		THEN


	
	

		
			if vcommand_api = 'true'
			THEN
				UPDATE tbprodutobluesoft
					SET		     prb_cdprodutobluesoftunitario 				=vprb_cdprodutobluesoftunitario
							  ,  prb_descricao 								=vprb_descricao
							  ,  prb_embalagemestoque						=vprb_embalagemestoque
							  ,  prb_fatorestoque 							=vprb_fatorestoque
							  ,  prb_embalagemcompra_qtdeunitaria			=vprb_embalagemcompra_qtdeunitaria
							  ,  prb_cdbarra_principal 						=vprb_cdbarra_principal
							  ,  prb_cdprodutobluesoft_controleestoque		=vprb_cdprodutobluesoft_controleestoque
							  ,  prb_cdprodutobluesoft_controlepreco		=vprb_cdprodutobluesoft_controlepreco
							  ,  prb_cdsubgrupo								=vprb_cdsubgrupo
							  ,  prb_dt_cadastro							=vprb_dt_cadastro
							  ,  prb_dt_ultimaalteracao						=vprb_dt_ultimaalteracao
							  ,  prb_cdpessoabluesoft_fabricante			=vprb_cdpessoabluesoft_fabricante
							  ,  prb_vendaexterna							=vprb_vendaexterna
							  ---,  prb_cdproduto_compra_padrao                =vprb_cdproduto_compra_padrao 
							  ,  prb_status									=vprb_status
							  ,  prb_descricao_fiscal					    = case when vprb_descricao_fiscal = 'undefined' then null else vprb_descricao_fiscal end
							  ,	 prb_descricao_gondola						= left(vprb_descricao_gondola,60) 
							  ,	 prb_descricao_cupom						= left(vprb_descricao_cupom,60) 							  
							  ,	 prb_descricao_balanca						= left(vprb_descricao_balanca,20)								  
							  ,  prb_dtupdate_from_api						= current_timestamp 
							  ,	 dtlog_update								= current_timestamp 
							  ,	 prb_blue_fc_cbenef_cd						= vprb_blue_fc_cbenef_cd
                              ,  prb_pesobruto                              = vprb_pesobruto
                              ,  prb_pesoliquido                            = vprb_pesoliquido
                              ,  prb_largura                                = vprb_largura
                              ,  prb_altura                                 = vprb_altura
                              ,  prb_comprimento                            = vprb_comprimento
                              ,  prb_pesoaproximado                        = vprb_pesoaproximado
				WHERE prb_cdprodutobluesoft_pk 								=vprb_cdprodutobluesoft_pk;
			ELSE
				UPDATE tbprodutobluesoft
					SET		     prb_cdprodutobluesoftunitario 				=vprb_cdprodutobluesoftunitario
							  ,  prb_descricao 								=vprb_descricao
							  ,  prb_embalagemestoque						=vprb_embalagemestoque
							  ,  prb_fatorestoque 							=vprb_fatorestoque
							  ,  prb_status_embalagemcaixa 					=vprb_status_embalagemcaixa 
							  ,  prb_embalagemcompra						=vprb_embalagemcompra
							  ,  prb_embalagemcompra_qtdeunitaria			=vprb_embalagemcompra_qtdeunitaria
							  ,  prb_cdbarra_principal 						=vprb_cdbarra_principal
							  ,  prb_cdprodutobluesoft_controleestoque		=vprb_cdprodutobluesoft_controleestoque
							  ,  prb_cdprodutobluesoft_controlepreco		=vprb_cdprodutobluesoft_controlepreco
							  ,  prb_cdsubgrupo								=vprb_cdsubgrupo
							  ,  prb_dt_cadastro							=vprb_dt_cadastro
							  ,  prb_dt_ultimaalteracao						=vprb_dt_ultimaalteracao
							  ,  prb_cdpessoabluesoft_fabricante			=vprb_cdpessoabluesoft_fabricante
							  ,  prb_vendaexterna							=vprb_vendaexterna
							  ,  prb_cdproduto_compra_padrao                =vprb_cdproduto_compra_padrao 
							  ,	 prbf_seq									=vprbf_seq 
							  ,  prb_tipo_composicao_cd                     =vprb_tipo_composicao_cd
							  ,  prb_status									=vprb_status
							  ,	 prb_descricao_gondola						= left(vprb_descricao_gondola,60) 
							  ,	 prb_descricao_cupom						= left(vprb_descricao_cupom,60) 							  
							  ,	 prb_descricao_balanca						= left(vprb_descricao_balanca,20)
							  ,  prb_cdpessoabluesoft_fornecedor 			= vprb_cdpessoabluesoft_fornecedor
	                          ,  prb_cdpessoabluesoft_fornecedor_troca 		= vprb_cdpessoabluesoft_fornecedor_troca							  
							  ,	 prb_pesobruto								= vprb_pesobruto
							  ,	 prb_pesoliquido							= vprb_pesoliquido
							  ,	 dtlog_update								= current_timestamp 
				WHERE prb_cdprodutobluesoft_pk 						=	vprb_cdprodutobluesoft_pk;
			END IF;

		END IF;

		IF (SQLCOMMAND = 'DBINSERT')
		THEN
			INSERT INTO tbprodutobluesoft
				(		 prb_cdprodutobluesoft_pk 						
					  ,  prb_cdprodutobluesoftunitario 				
					  ,  prb_descricao 								
					  ,  prb_embalagemestoque							
					  ,  prb_fatorestoque 								
					  ,  prb_status_embalagemcaixa 					
					  ,  prb_embalagemcompra							
					  ,  prb_embalagemcompra_qtdeunitaria				
					  ,  prb_cdbarra_principal 						
					  ,  prb_cdprodutobluesoft_controleestoque			
					  ,  prb_cdprodutobluesoft_controlepreco			
					  ,  prb_cdsubgrupo								
					  ,  prb_dt_cadastro								
					  ,  prb_dt_ultimaalteracao						
					  ,  prb_cdpessoabluesoft_fabricante				
					  ,  prb_vendaexterna								
					  ,  prb_descricao_fiscal
				      ,  prb_cdproduto_compra_padrao
				 	  ,  prbf_seq 
				      ,  prb_status	
				 	  ,  prb_tipo_composicao_cd
				 	  ,	 prb_descricao_gondola		
					  ,	 prb_descricao_cupom		
					  ,	 prb_descricao_balanca		
					  ,  prb_cdpessoabluesoft_fornecedor 			
	                  ,  prb_cdpessoabluesoft_fornecedor_troca 		
					  ,	 prb_pesobruto								
					  ,	 prb_pesoliquido	
					  ,	 prb_blue_fc_cbenef_cd
                      ,  prb_largura           
                      ,  prb_altura            
                      ,  prb_comprimento       
                      ,  prb_pesoaproximado   
				   	  				    
				 	)
			VALUES ( 	 vprb_cdprodutobluesoft_pk 						
					  ,  vprb_cdprodutobluesoftunitario 				
					  ,  vprb_descricao 								
					  ,  vprb_embalagemestoque							
					  ,  vprb_fatorestoque 								
					  ,  vprb_status_embalagemcaixa 					
					  ,  vprb_embalagemcompra							
					  ,  vprb_embalagemcompra_qtdeunitaria				
					  ,  vprb_cdbarra_principal 						
					  ,  vprb_cdprodutobluesoft_controleestoque			
					  ,  vprb_cdprodutobluesoft_controlepreco			
					  ,  vprb_cdsubgrupo								
					  ,  vprb_dt_cadastro								
					  ,  vprb_dt_ultimaalteracao						
					  ,  vprb_cdpessoabluesoft_fabricante				
					  ,  vprb_vendaexterna								
					  ,  case when vprb_descricao_fiscal = 'undefined' then null else vprb_descricao_fiscal end
					  ,  vprb_cdproduto_compra_padrao
					  ,  vprbf_seq 
					  ,  vprb_status
					  ,  vprb_tipo_composicao_cd
				 	  ,	 left(vprb_descricao_gondola,60)		
					  ,	 left(vprb_descricao_cupom,60)
					  ,	 left(vprb_descricao_balanca,20)
					  ,  coalesce(vprb_cdpessoabluesoft_fornecedor,0)
	                  ,  coalesce(vprb_cdpessoabluesoft_fornecedor_troca,0)
					  ,	 coalesce(vprb_pesobruto,0)								
					  ,	 coalesce(vprb_pesoliquido,0)
					  ,  coalesce(vprb_blue_fc_cbenef_cd, '')
                      ,  vprb_largura
                      ,  vprb_altura
                      ,  vprb_comprimento
                      ,  vprb_pesoaproximado
					);
		END IF;


        if (vatualizalog = 0)
		then 
            insert into tbintegracao_produto (dtlog_update, pr_cdproduto, prb_cdprodutobluesoft, prb_cdprodutobluesoftunitario, integracao_tipo_cd, integracao_status_cd)
                    select 	current_timestamp 
                        ,	0
                        ,	x.prb_cdprodutobluesoft_pk
                        ,	x.prb_cdprodutobluesoftunitario 
                        ,	20002090
                        ,	1
                    from 	tbprodutobluesoft x
                    where 	prb_cdprodutobluesoft_pk = vprb_cdprodutobluesoft_pk
                    and     prb_cdprodutobluesoftunitario = vprb_cdprodutobluesoftunitario
                    and		not exists( select 	1 
                                        from 	tbintegracao_produto xx
                                        where 	xx.prb_cdprodutobluesoft = vprb_cdprodutobluesoft_pk
                                        and     xx.prb_cdprodutobluesoftunitario = vprb_cdprodutobluesoftunitario
                                        and		integracao_tipo_cd = 20002090
                                    
                                    )
                
            ;
            
            update 	tbintegracao_produto 
                set dtlog_update 			= current_timestamp 	
                ,	integracao_status_cd 	= 1
            where 	prb_cdprodutobluesoft = vprb_cdprodutobluesoft_pk
            and     prb_cdprodutobluesoftunitario = vprb_cdprodutobluesoftunitario 
            and		integracao_tipo_cd = 20002090

            ;
        end if
        ;	
END;
$function$
