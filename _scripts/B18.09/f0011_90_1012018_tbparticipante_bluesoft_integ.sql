-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- FUNCTION: public.f0011_90_1011950_tbparticipante_bluesoft_integ(character varying, integer, character varying, character varying, integer, character varying, character varying, character varying, date, integer, character varying, character varying, character varying, character varying, character varying, character varying, numeric, numeric, integer, date, integer, integer, integer, integer, integer, integer, integer, integer, numeric, numeric, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0011_90_1011950_tbparticipante_bluesoft_integ(character varying, integer, character varying, character varying, integer, character varying, character varying, character varying, date, integer, character varying, character varying, character varying, character varying, character varying, character varying, numeric, numeric, integer, date, integer, integer, integer, integer, integer, integer, integer, integer, numeric, numeric, integer, integer);

CREATE OR REPLACE FUNCTION public.f0011_90_1012018_tbparticipante_bluesoft_integ(
	sqlcommand character varying,
	vcdpessoabluesoft integer,
	vcpf_cnpj character varying,
	vnome_razao character varying,
	vpessoajuridica integer,
	vemail_main character varying,
	vnome_abreviado character varying,
	vpf_sexo character varying,
	vpf_data_nascimento date,
	vendereco_cep integer,
	vendereco_logradouro character varying,
	vendereco_numero character varying,
	vendereco_complemento character varying,
	vendereco_bairro character varying,
	vendereco_municipio character varying,
	vendereco_uf character varying,
	vendereco_latitude numeric,
	vendereco_longitude numeric,
	vbluesoft_pessoa_status integer,
	vbluesoft_pessoa_data_cadastro date,
	vbluesoftcliente integer,
	vbluesoftvendedor integer,
	vbluesoftfornecedor integer,
	vbluesoftfabricante integer,
	vbluesoftmotorista integer,
	vcdgrupoeconomico integer,
	vcdpessoabluesoft_vendedor integer,
	vbluesoftclientestatus integer,
	vbluesoftcliente_creditolimite_valor numeric,
	vbluesoftcliente_creditolimite_valor_reservado numeric,
	vbluesoftcliente_creditostatus_cd integer,
	vbluesoftcliente_ramoatividade_cd integer)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
BEGIN

	vcpf_cnpj:= repeat('0',14-length(vcpf_cnpj)) || vcpf_cnpj   

	;
	
	INSERT INTO tbparticipante 
				(
						cpf_cnpj 
					,	cdpessoabluesoft 
					,	nome_razao
					,	nome_abreviado 
					,	pessoajuridica 
					,	participante_status
					, 	email_main 
					,	bluesoftcliente 
					,	bluesoftvendedor 
					,	bluesoftfornecedor 
					,	bluesoftfabricante 
					,	cdgrupoeconomico 
					,	cdpessoabluesoft_vendedor 
					,	tipo_clienteloja 
					,	johnson_cliente_top 
				)
		SELECT 			vcpf_cnpj 
					,	vcdpessoabluesoft 
					,	vnome_razao 
					,	left(vnome_abreviado,30)
					,	vpessoajuridica 
					,	1
					, 	vemail_main 
					,	vbluesoftcliente 
					,	vbluesoftvendedor 
					,	vbluesoftfornecedor 
					,	vbluesoftfabricante 
					,	vcdgrupoeconomico 
					,	vcdpessoabluesoft_vendedor 
										--- Ao inserir um cliente novo cujo o grupo seja cliente top o cliente 
										--- ja sera inserido como cliente top johnson
					,	(select coalesce(johnson_cliente_top,0) from tbgrupoeconomico where cdgrupoeconomico = vcdgrupoeconomico )
					,	0
		WHERE 			NOT EXISTS (Select 1 from tbparticipante where cpf_cnpj = vcpf_cnpj)
		
		; 
		
		insert into tbparticipante_bluesoft
		(				cdparticipante 
		 			,	cdpessoabluesoft 
		 			,	cpf_cnpj 
		 			, 	pessoajuridica 
		 			,	bluesoft_pessoa_data_cadastro 
		 			,	bluesoft_pessoa_status
		 			,	nome_razao 
		 			,	nome_abreviado		 
					,	bluesoftcliente
		 			,	bluesoftclientestatus
					,	cdgrupoeconomico 								
					,	cdpessoabluesoft_vendedor						
					,	bluesoftvendedor								
					,	bluesoftfornecedor								
					,	bluesoftfabricante 								
					,	bluesoftmotorista 								
					,	bluesoftcliente_creditolimite_valor				
					,	bluesoftcliente_creditolimite_valor_reservado	
					,	bluesoftcliente_creditostatus_cd				
					,	bluesoftcliente_ramoatividade_cd						 
		)
		SELECT 			0
					,	vcdpessoabluesoft 
					,	vcpf_cnpj 
					,	vpessoajuridica
					,	vbluesoft_pessoa_data_cadastro
					,	vbluesoft_pessoa_status
					, 	vnome_razao 
					,	left(vnome_abreviado,30)
					,	vbluesoftcliente
					,	vbluesoftclientestatus 
					,	vcdgrupoeconomico 								
					,	vcdpessoabluesoft_vendedor						
					,	vbluesoftvendedor								
					,	vbluesoftfornecedor								
					,	vbluesoftfabricante 								
					,	vbluesoftmotorista 								
					,	vbluesoftcliente_creditolimite_valor				
					,	vbluesoftcliente_creditolimite_valor_reservado	
					,	vbluesoftcliente_creditostatus_cd				
					,	vbluesoftcliente_ramoatividade_cd
		WHERE			vcdpessoabluesoft not in (select xa.cdpessoabluesoft from tbparticipante_bluesoft xa )
		;		
	

		UPDATE 		tbparticipante_bluesoft a
		SET				cpf_cnpj 										= vcpf_cnpj 												
		 			, 	pessoajuridica 									= vpessoajuridica 											
		 			,	bluesoft_pessoa_data_cadastro 					= vbluesoft_pessoa_data_cadastro 						
					,	bluesoft_pessoa_status							= vbluesoft_pessoa_status					
		 			,	nome_razao 										= vnome_razao 															
		 			,	nome_abreviado									= left(vnome_abreviado,30)												 
					,	bluesoftcliente									= vbluesoftcliente										
		 			,	bluesoftclientestatus							= vbluesoftclientestatus																	
					,	cdgrupoeconomico 								= vcdgrupoeconomico 																	
					,	cdpessoabluesoft_vendedor						= vcdpessoabluesoft_vendedor							
					,	bluesoftvendedor								= vbluesoftvendedor										
					,	bluesoftfornecedor								= vbluesoftfornecedor									
					,	bluesoftfabricante 								= vbluesoftfabricante 									
					,	bluesoftmotorista 								= case when vbluesoftmotorista = 1 then 1 else a.bluesoftmotorista end
					,	bluesoftcliente_creditolimite_valor				= vbluesoftcliente_creditolimite_valor						
					,	bluesoftcliente_creditolimite_valor_reservado	= vbluesoftcliente_creditolimite_valor_reservado			
					,	bluesoftcliente_creditostatus_cd				= vbluesoftcliente_creditostatus_cd					
					,	bluesoftcliente_ramoatividade_cd				= vbluesoftcliente_ramoatividade_cd					
		WHERE			1 = 1 
   	    AND			a.cdpessoabluesoft = vcdpessoabluesoft 

		;

	UPDATE 		tbparticipante_bluesoft a
		SET			cdparticipante 									= c.cdparticipante  	
				,	dtlog_update									= current_timestamp 		
  	    FROM 		tbparticipante c
		WHERE		1 = 1 
		AND			a.cdpessoabluesoft = vcdpessoabluesoft 
		AND			c.cpf_cnpj = a.cpf_cnpj 
		;
		
	UPDATE		tbparticipante 
			set		cdpessoabluesoft = 0 
		where		cpf_cnpj = vcpf_cnpj 
		  and       vcpf_cnpj not in (select x1.cpf_cnpj from tbparticipante_bluesoft x1 )
		;
		
	UPDATE 		tbparticipante a
		SET			cdpessoabluesoft								= c.cdpessoabluesoft 
				,	dtlog_update									= current_timestamp 		
  	    FROM 		tbparticipante_bluesoft c
		WHERE		1 = 1 
		AND			c.cpf_cnpj = a.cpf_cnpj 
		and			c.cpf_cnpj = vcpf_cnpj
		;
				
		
		UPDATE 			tbparticipante  	x
			SET		 	email_main 											= 	coalesce(email_main, vemail_main)
					,	nome_razao 											=   vnome_razao 
					,	nome_abreviado 										= 	left(vnome_abreviado,30)
					,	pessoajuridica										= 	vpessoajuridica
					,	bluesoftcliente 									= 	vbluesoftcliente
					--,	bluesoftvendedor 									= 	vbluesoftvendedor 		
					,	bluesoftfornecedor 									= 	vbluesoftfornecedor 					
					,	bluesoftfabricante 									= 	vbluesoftfabricante 		
					,	cdgrupoeconomico 									= 	vcdgrupoeconomico 	
					,	cdpessoabluesoft_vendedor 							= 	vcdpessoabluesoft_vendedor 	
					,	dtlog_update										=   current_timestamp 
		WHERE			x.cpf_cnpj = vcpf_cnpj 
		; 
		
		
	INSERT INTO tbparticipante_endereco 
			(			cdparticipante				
					,	endereco_tipo_cd 		
					,	endereco_cep 				
					,	endereco_numero 			
					,	endereco_logradouro 		
					,	endereco_bairro				
					,	endereco_municipio 			
					,	endereco_uf					
					,	endereco_complemento 		
					,	endereco_latitude 			
					,	endereco_longitude 			
			)
			select 		x3.cdparticipante				
					,	1
					,	vendereco_cep 				
					,	vendereco_numero 			
					,	vendereco_logradouro 		
					,	vendereco_bairro				
					,	vendereco_municipio 			
					,	vendereco_uf					
					,	vendereco_complemento 		
					,	vendereco_latitude 			
					,	vendereco_longitude 			
			from		tbparticipante x3
			where		x3.cpf_cnpj = vcpf_cnpj 
			and         x3.cdparticipante not in ( select cdparticipante from tbparticipante_endereco x31 group by x31.cdparticipante  )
					
		;	
		
		

		
	INSERT INTO 	tbparticipante_contato
		(
					cdparticipante				
				,	contato_tipo_cd 	
				,	contato_email
				,	contato_celular_dd			
				,	contato_celular_numero 		
		)
		select 		x4.cdparticipante				
					,	1
					,	vemail_main
					,	0
					,	0
		from		tbparticipante x4
		where		x4.cpf_cnpj = vcpf_cnpj 
		and         x4.cdparticipante not in ( select cdparticipante from tbparticipante_contato x41 group by x41.cdparticipante  )
			
	;
	
	insert into tbparticipante_pf 
		(
				cdparticipante 
			,	pf_sexo 
			,	pf_data_nascimento 
		)
	select 		x5.cdparticipante 
			,	vpf_sexo
			,	vpf_data_nascimento
	from 		tbparticipante x5 
	where		x5.cdpessoabluesoft = vcdpessoabluesoft 
	  and		x5.cdparticipante <> 0 
	  and		x5.cdparticipante not in (select x5a.cdparticipante from tbparticipante_pf x5a)
		
	;
	
	INSERT INTO tbparticipante_vendedor			
		(		cdparticipante						
			,	vendedor_status						
			,	vendedor_cdparticipante_pj			
			,	vendedor_cdparticipante_contador	
			,	vendedor_fv_comis_mail 	
		)
	select 		x5.cdparticipante				
			,	vbluesoft_pessoa_status
			,	0
			,	0
			,	0			
	from		tbparticipante x5
	where		x5.cpf_cnpj = vcpf_cnpj 
	  AND       vbluesoftvendedor = 1
	  AND       x5.cdparticipante not in ( select cdparticipante from tbparticipante_vendedor x51 group by x51.cdparticipante  )

	;	
	
	insert into tbparticipante_tipo_reg (cdparticipante, participante_tipo_cd) select x.cdparticipante, 120 from tbparticipante_bluesoft x where cdpessoabluesoft = vcdpessoabluesoft and vbluesoftcliente 		= 1 and x.cdparticipante not in (select cdparticipante from tbparticipante_tipo_reg ax where ax.cdparticipante = x.cdparticipante and participante_tipo_cd =120 );
	insert into tbparticipante_tipo_reg (cdparticipante, participante_tipo_cd) select x.cdparticipante, 121 from tbparticipante_bluesoft x where cdpessoabluesoft = vcdpessoabluesoft and vbluesoftvendedor 	= 1 and x.cdparticipante not in (select cdparticipante from tbparticipante_tipo_reg ax where ax.cdparticipante = x.cdparticipante and participante_tipo_cd =121 );
	insert into tbparticipante_tipo_reg (cdparticipante, participante_tipo_cd) select x.cdparticipante, 140 from tbparticipante_bluesoft x where cdpessoabluesoft = vcdpessoabluesoft and vbluesoftfabricante 	= 1 and x.cdparticipante not in (select cdparticipante from tbparticipante_tipo_reg ax where ax.cdparticipante = x.cdparticipante and participante_tipo_cd =140 );	
	insert into tbparticipante_tipo_reg (cdparticipante, participante_tipo_cd) select x.cdparticipante, 141 from tbparticipante_bluesoft x where cdpessoabluesoft = vcdpessoabluesoft and vbluesoftfornecedor 	= 1 and x.cdparticipante not in (select cdparticipante from tbparticipante_tipo_reg ax where ax.cdparticipante = x.cdparticipante and participante_tipo_cd =141 );	
	insert into tbparticipante_tipo_reg (cdparticipante, participante_tipo_cd) select x.cdparticipante, 122 from tbparticipante_bluesoft x where cdpessoabluesoft = vcdpessoabluesoft and vbluesoftmotorista 	= 1 and x.cdparticipante not in (select cdparticipante from tbparticipante_tipo_reg ax where ax.cdparticipante = x.cdparticipante and participante_tipo_cd =122 )
	
	;	
	
			
	
	
	
	-----------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------------------------------------------------------------------
	-->> TABELAS ANTIGAS
	
	
		

		/* Inserindo dados complementares na tabela de pessoa */
		--select * from tbpessoa
		insert into tbpessoa 
			(		cdparticipante 
				,	cpf_cnpj 
				,	endereco_cep 
				, 	endereco_logradouro
				,	endereco_bairro 
				,	endereco_municipio 
				,	endereco_uf 
				,	endereco_complemento 
				,	endereco_numero
				,	celular_dd 
				,	celular_numero
				,	latitude
				,	longitude 
			)
		select 		ap.cdparticipante 
				,	ap.cpf_cnpj 
				,	vendereco_cep 
				, 	vendereco_logradouro
				,	vendereco_bairro 
				,	vendereco_municipio 
				,	vendereco_uf 
				,	vendereco_complemento 
				,	vendereco_numero
				,	0
				,	0
				,	vendereco_latitude
				,	vendereco_longitude 
		from 		tbparticipante ap
		where		ap.cpf_cnpj = vcpf_cnpj 
		  and       ap.cpf_cnpj not in ( select cpf_cnpj from tbpessoa )
		  
		; 
		
		INSERT INTO 	tbpessoabluesoft 
		(				cdparticipante 
					,	cdpessoabluesoft 
					,	cpf_cnpj 
					, 	nome_razao 
					,	nome_abreviado 
					, 	data_nascimento 
					, 	email_main 
					,	bluesoftclientestatus
					,	bluesoftpessoastatus 
					,	bluesoftcliente_creditolimite_valor
					,	bluesoftcliente_creditolimite_valor_reservado 
					,	bluesoftpessoa_data_cadastro 
					, 	bluesoftcliente_creditostatus_cd 
					,	bluesoftcliente_ramoatividade_cd 
		)
		SELECT 			a.cdparticipante 
					,	a.cdpessoabluesoft 
					,	a.cpf_cnpj 
					, 	a.nome_razao 
					,	a.nome_abreviado 
					, 	vpf_data_nascimento 
					, 	vemail_main 
					,	vbluesoftclientestatus
					,	vbluesoft_pessoa_status 
					,	vbluesoftcliente_creditolimite_valor
					,	vbluesoftcliente_creditolimite_valor_reservado 
					,	vbluesoft_pessoa_data_cadastro 
					, 	vbluesoftcliente_creditostatus_cd 
					,	vbluesoftcliente_ramoatividade_cd 
		FROM 			tbparticipante a 
		WHERE 			cpf_cnpj = vcpf_cnpj
		  AND			cdpessoabluesoft not in (select cdpessoabluesoft from tbpessoabluesoft )
		; 

		
		UPDATE			tbpessoa 					ps
				set 		sexo							= vpf_sexo							
						,	data_nascimento					= vpf_data_nascimento				
						,	endereco_cep 					= vendereco_cep 					
						,	endereco_logradouro				= vendereco_logradouro			
						,	endereco_bairro					= vendereco_bairro				
						,	endereco_municipio 				= vendereco_municipio 			
						,	endereco_numero 				= vendereco_numero 		
						,	endereco_uf						= vendereco_uf 
						,	dtlog_update					= current_timestamp 
		WHERE			ps.cpf_cnpj = vcpf_cnpj 
		;
		
		UPDATE			tbpessoabluesoft 			n
			SET 		nome_razao 											=   vnome_razao 
					,	nome_abreviado 										= 	vnome_abreviado 
					,	email_main 											= 	vemail_main 
					,	bluesoftcliente 									= 	vbluesoftcliente
					--,	bluesoftvendedor 									= 	vbluesoftvendedor 		
					,	bluesoftfornecedor 									= 	vbluesoftfornecedor 					
					,	bluesoftfabricante 									= 	vbluesoftfabricante 		
					,	cdgrupoeconomico 									= 	vcdgrupoeconomico 	
					,	cdpessoabluesoft_vendedor 							= 	vcdpessoabluesoft_vendedor 	
					,	bluesoftclientestatus								= 	vbluesoftclientestatus							
					,	bluesoftpessoastatus								= 	vbluesoft_pessoa_status								
					,	bluesoftpessoa_data_cadastro 						= 	vbluesoft_pessoa_data_cadastro 						
					,	bluesoftcliente_creditolimite_valor					= 	vbluesoftcliente_creditolimite_valor			
					,	bluesoftcliente_creditolimite_valor_reservado 		= 	vbluesoftcliente_creditolimite_valor_reservado 	
					,	bluesoftcliente_creditostatus_cd					= 	vbluesoftcliente_creditostatus_cd				
					,	bluesoftcliente_ramoatividade_cd					= 	vbluesoftcliente_ramoatividade_cd	
					,	dtlog_update									= current_timestamp 
		WHERE			n.cpf_cnpj = vcpf_cnpj 
		; 
		
		

END;
$BODY$;

