-- FUNCTION: public.f0011_15_1012015_tbparticipante_vip_crud(character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, date, character varying)

-- DROP FUNCTION IF EXISTS public.f0011_15_1012015_tbparticipante_vip_crud(character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, date, character varying);

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0011_15_1012017_tbparticipante_vip_crud(
	sqlcommand character varying,
	vvip_id int, 
	vvip_cliente_id character varying,
	vvip_cpf_cnpj character varying,
	vvip_cpf character varying,
	vvip_cnpj character varying,
	vcdparticipante integer,
	vvip_nome_completo character varying,
	vvip_nome character varying,
	vvip_sobre_nome character varying,
	vvip_email character varying,
	vvip_data_nascimento date,
	vvip_telefone_celular character varying)
    RETURNS TABLE(vip_id int, vip_cliente_id character varying, cdparticipante integer, cpf_cnpj character varying, nome character varying, sobre_nome character varying, email character varying, data_nascimento date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
	if sqlcommand = 'DBCRUD' OR sqlcommand = 'DBINSERT' or sqlcommand = 'DBUPDATE'
	then 

		INSERT INTO tbparticipante 
				(
						cpf_cnpj 
					,	nome_razao 
					,	pessoajuridica
					,	participante_status
					,	email_main 
					,	celular_dd
					,	celular_numero			
				)

		SELECT 		lpad(vvip_cpf_cnpj	,14,'0')
				,	vvip_nome_completo
				,	case when coalesce(vvip_cnpj,'') != '' then 1 else 0 end
				,	1
				,	vvip_email
				,	0
				,	0
		WHERE not exists (select 1 from tbparticipante x where lpad(x.cpf_cnpj,14,'0') = lpad(vvip_cpf_cnpj	,14,'0'))

		;


		INSERT INTO tbparticipante_vip 
				(		vip_id 
					,	vip_cliente_id			
					,	cdparticipante 		
					,	vip_cpf_cnpj
					,	vip_cpf					
					,	vip_cnpj				
					,	vip_nome					
					,	vip_sobre_nome				
					,	vip_email					
					,   vip_data_nascimento		
				)
		SELECT 		vvip_id
				,	vvip_cliente_id			
				,	x.cdparticipante 	
				,	lpad(vvip_cpf_cnpj	,14,'0')		
				,	vvip_cpf
				,	vvip_cnpj
				,	vvip_nome					
				,	vvip_sobre_nome				
				,	vvip_email					
				,   vvip_data_nascimento
		FROM 		tbparticipante x

		WHERE	1 = 1
		and     x.cpf_cnpj = lpad(vvip_cpf_cnpj	,14,'0')
		and		not exists (select 1 from tbparticipante_vip x where x.vip_cliente_id = vvip_cliente_id)

		;

		insert into tbparticipante_tipo_reg 
				(
						cdparticipante
					,	participante_tipo_cd
					,	participante_tipo_reg_status 
				)
				SELECT 		x.cdparticipante
						,	300
						,	1
				FROM 		tbparticipante x
				WHERE	1 = 1
				and     x.cpf_cnpj = lpad(vvip_cpf_cnpj	,14,'0')
				and		not exists (select 1 from tbparticipante_tipo_reg z 
									where z.cdparticipante = x.cdparticipante 
									and z.participante_tipo_cd = 300)

		;

		
		UPDATE			tbparticipante_vip X
			set			
						vip_email = vvip_email
					,	vip_nome = vvip_nome
					,	vip_sobre_nome = vvip_sobre_nome
					,	vip_data_nascimento = vvip_data_nascimento
					,	dtlog_update = current_timestamp 
		where			x.vip_cliente_id = vvip_cliente_id	 
		
		;		
	end if
	;
	
	
	SqlCommand:= 	'	SELECT 			vip_id
									,	vip_cliente_id	
									,	p.cdparticipante 	
									,	p.cpf_cnpj
									,	vip_nome			
									,	vip_sobre_nome		
									,	vip_email			
									,   vip_data_nascimento	
						FROM 		tbparticipante_vip x
						INNER JOIN  tbparticipante p
							ON 		x.cdparticipante = p.cdparticipante
						WHERE 		x.vip_cliente_id = ' || '''' || cast(vvip_cliente_id as varchar(100)) || ''''
 		
		;
    RETURN QUERY EXECUTE SqlCommand;
END;
$BODY$;

