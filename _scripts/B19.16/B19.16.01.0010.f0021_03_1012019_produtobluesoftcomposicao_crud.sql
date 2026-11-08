-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- FUNCTION: public.f0021_03_1011924_produtobluesoftcomposicao_crud(character varying, integer, integer, numeric, character varying, numeric, integer, date, boolean)

-- DROP FUNCTION IF EXISTS public.f0021_03_1011924_produtobluesoftcomposicao_crud(character varying, integer, integer, numeric, character varying, numeric, integer, date, boolean);


/* 	SCRIPT REGISTRATION 
	----------------------------------------------------------------------------
	----------------------------------------------------------------------------
	----------------------------------------------------------------------------
	----------------------------------------------------------------------------			
*/

insert into tbsistema_versao_script_db (versao_ecosystem, script_name)
    select 2019, 'B19.16.01.0010.f0021_03_1012019_produtobluesoftcomposicao_crud.sql'
	where not EXISTS 
			(select 1 from tbsistema_versao_script_db 
					where versao_ecosystem = 2019 
					and script_name = 'B19.16.01.0010.f0021_03_1012019_produtobluesoftcomposicao_crud.sql'
							);

	UPDATE tbsistema_versao_script_db
	SET dtlog_update = current_timestamp
	WHERE script_name = 'B19.16.01.0010.f0021_03_1012019_produtobluesoftcomposicao_crud.sql';
/* 	----------------------------------------------------------------------------
	----------------------------------------------------------------------------
	----------------------------------------------------------------------------
	----------------------------------------------------------------------------			
*/							
								  
CREATE OR REPLACE FUNCTION public.f0021_03_1012019_produtobluesoftcomposicao_crud(
	sqlcommand character varying,
	vprb_cdprodutobluesoft integer,
	vprb_cdprodutobluesoft_unitario integer,
	vprbc_qtde numeric,
	vprbc_descricao character varying,
	vprbc_percentual_composicao numeric,
	vgtin_principal character varying,
	vcommand_api boolean)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
begin
			INSERT INTO tbprodutobluesoft_composicao 
				(		prb_cdprodutobluesoft			
					,	prb_cdprodutobluesoft_unitario	
					,	prbc_qtde 						
					,	prbc_descricao					
					,	prbc_percentual_composicao	
				 	,	prbc_bluesoft_seq
				 	,	prbc_data
					
				)
			SELECT 		vprb_cdprodutobluesoft			
					,	vprb_cdprodutobluesoft_unitario	
					,	vprbc_qtde 						
					,	vprbc_descricao					
					,	vprbc_percentual_composicao	
					,	0
					,	current_date
				WHERE NOT EXISTS ( 	SELECT 	1 
								 	FROM 	tbprodutobluesoft_composicao
								 	WHERE	1 = 1	
								   	AND		prb_cdprodutobluesoft	= vprb_cdprodutobluesoft
									and     prb_cdprodutobluesoft_unitario = vprb_cdprodutobluesoft_unitario
								 )
			    ;

				UPDATE 	tbprodutobluesoft_composicao
					set 		prbc_qtde 						= vprbc_qtde
							,	prbc_descricao					= vprbc_descricao
							,	prbc_percentual_composicao		= vprbc_percentual_composicao
							,	prbc_data						= current_date
							,	dtlog_update					= current_timestamp
							,	dtlog_update_api				= current_timestamp 
				WHERE 	1 = 1
				  AND	prb_cdprodutobluesoft	= vprb_cdprodutobluesoft
				  and   prb_cdprodutobluesoft_unitario = vprb_cdprodutobluesoft_unitario
;

end;
$BODY$;

select * from tbsistema_versao_script_db where versao_ecosystem = 2019;