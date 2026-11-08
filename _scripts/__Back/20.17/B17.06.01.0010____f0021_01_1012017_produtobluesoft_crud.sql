-- FUNCTION: public.f0021_01_1012006_produtobluesoft_crud(character varying, integer, integer, character varying, character, numeric, boolean, character, numeric, character, integer, integer, integer, date, date, integer, boolean, character varying, integer, integer, boolean, integer, character varying, character varying, character varying, integer, integer, numeric, numeric, boolean)

-- DROP FUNCTION IF EXISTS public.f0021_01_1012006_produtobluesoft_crud(character varying, integer, integer, character varying, character, numeric, boolean, character, numeric, character, integer, integer, integer, date, date, integer, boolean, character varying, integer, integer, boolean, integer, character varying, character varying, character varying, integer, integer, numeric, numeric, boolean);

--select prb_cdprodutobluesoft_pk, prb_blue_fc_cbenef_cd from tbprodutobluesoft where prb_cdprodutobluesoft_pk = 5282
---select * from tbprodutobluesoft_tributacao where prb_cdprodutobluesoft = 5282

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0021_01_1012017_produtobluesoft_crud(
	sqlcommand character varying,
	vprb_cdprodutobluesoft_pk integer,
	vprb_cdprodutobluesoftunitario integer,
	vprb_descricao character varying,
	vprb_embalagemestoque character,
	vprb_fatorestoque numeric,
	vprb_status_embalagemcaixa boolean,
	vprb_embalagemcompra character,
	vprb_embalagemcompra_qtdeunitaria numeric,
	vprb_cdbarra_principal character,
	vprb_cdprodutobluesoft_controleestoque integer,
	vprb_cdprodutobluesoft_controlepreco integer,
	vprb_cdsubgrupo integer,
	vprb_dt_cadastro date,
	vprb_dt_ultimaalteracao date,
	vprb_cdpessoabluesoft_fabricante integer,
	vprb_vendaexterna boolean,
	vprb_descricao_fiscal character varying,
	vprb_cdproduto_compra_padrao integer,
	vprbf_seq integer,
	vprb_status boolean,
	vprb_tipo_composicao_cd integer,
	vprb_descricao_gondola character varying,
	vprb_descricao_cupom character varying,
	vprb_descricao_balanca character varying,
	vprb_cdpessoabluesoft_fornecedor integer,
	vprb_cdpessoabluesoft_fornecedor_troca integer,
	vprb_pesobruto numeric,
	vprb_pesoliquido numeric,
	vprb_blue_fc_cbenef_cd  varchar(15) ,
	vcommand_api boolean)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
BEGIN 
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
					);
		END IF;

		
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
				
		--select * from tbintegracao_produto limit 10
		
END;
$BODY$;



