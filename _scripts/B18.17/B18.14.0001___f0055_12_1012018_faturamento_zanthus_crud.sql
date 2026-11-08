-- FUNCTION: public.f0055_12_1011970_faturamento_zanthus_crud(character varying, date, integer, integer, character varying, integer, integer, integer, character, integer, numeric, character varying, time without time zone, time without time zone, integer, character varying, numeric, integer, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0055_12_1011970_faturamento_zanthus_crud(character varying, date, integer, integer, character varying, integer, integer, integer, character, integer, numeric, character varying, time without time zone, time without time zone, integer, character varying, numeric, integer, integer, integer, integer);

Select * from f0055_12_1012018_faturamento_zanthus_crud
    (           sqlcommand:= 'DBINSERT'
            ,   vfat_zanthus_data_m00af:= '2026-01-03'        
            ,   vfat_zanthus_sat_ecf_m00ac:= 13
            ,   vfat_zanthus_cupomfiscal_m00ad:= 35080
            ,   vfat_zanthus_cupomfiscalid_M00_id_unico:= 'undefined'
            ,   vfat_zanthus_cupomfiscal_cancelado_m45bo:= 35080
            ,   vfat_zanthus_notafiscal_numnota:= 17982
            ,   vfat_zanthus_notafiscal_serie_nf:= 13
            ,   vfat_zanthus_notafiscal_chave_m45xb:= '35260157895328000130650130000179821270481030'
            ,   vfat_zanthus_status_cancelado:= 0
            ,   vfat_zanthus_cpf_cnpj_m45bv:= '46674668800'
            ,   vfat_zanthus_hora_ini_m45ai:= '20:54:00'
            ,   vfat_zanthus_hora_fim_m45au:= '20:58:00'
            ,   vfat_zanthus_cupomfiscal_valor_m45ak:= 316.57
            ,   vfat_zanthus_cod_funcionario_m45ah:= 123507
            ,   vfat_zanthus_voucher_cod_m50ar:= '20260103'
            ,   vfat_zanthus_voucher_valor_m50at:= 21.08
            ,   vfat_zanthus_voucher_count_m50ag:= 2
            ,   vfat_zanthus_conferencia:= 0
            ,   vfat_zanthus_processado:= 0
            ,   vfat_zanthus_pag:= 0
            ,   vtiponota:= 8
        )


CREATE OR REPLACE 
-- DROP 
FUNCTION public.f0055_12_1012018_faturamento_zanthus_crud(
	sqlcommand character varying,
	vfat_zanthus_data_m00af date,
	vfat_zanthus_sat_ecf_m00ac integer,
	vfat_zanthus_cupomfiscal_m00ad integer,
	vfat_zanthus_cupomfiscalid_m00_id_unico character varying,
	vfat_zanthus_cupomfiscal_cancelado_m45bo integer,
	vfat_zanthus_notafiscal_numnota integer,
	vfat_zanthus_notafiscal_serie_nf integer,
	vfat_zanthus_notafiscal_chave_m45xb character,
	vfat_zanthus_status_cancelado integer,
	vfat_zanthus_cupomfiscal_valor_m45ak numeric,
	vfat_zanthus_cpf_cnpj_m45bv character varying,
	vfat_zanthus_hora_ini_m45ai time without time zone,
	vfat_zanthus_hora_fim_m45au time without time zone,
	vfat_zanthus_cod_funcionario_m45ah integer,
	vfat_zanthus_voucher_cod_m50ar character varying,
	vfat_zanthus_voucher_valor_m50at numeric,
	vfat_zanthus_voucher_count_m50ag integer,
	vfat_zanthus_conferencia integer,
	vfat_zanthus_processado integer,
	vfat_zanthus_pag integer,
	vtiponota integer)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
begin
if (SQLCOMMAND = 'DBINSERT')
		THEN
			
			insert into tbfaturamentozanthus
				(		fat_zanthus_data_m00af						
					,   fat_zanthus_sat_ecf_m00ac					
					,   fat_zanthus_cupomfiscal_m00ad				
					,   fat_zanthus_cupomfiscalid_M00_id_unico		
					,	fat_zanthus_cupomfiscal_cancelado_m45bo	
					,   fat_zanthus_notafiscal_numnota				
					,   fat_zanthus_notafiscal_serie_nf				
					,	fat_zanthus_notafiscal_chave_m45xb			
					,	fat_zanthus_status_cancelado				
					,	fat_zanthus_cupomfiscal_valor_m45ak	
					,	fat_zanthus_cpf_cnpj_m45bv	
					,	fat_zanthus_hora_ini_m45ai
					,	fat_zanthus_hora_fim_m45au
					,	fat_zanthus_cod_funcionario_m45ah
					,	fat_zanthus_voucher_cod_m50ar		
					,	fat_zanthus_voucher_valor_m50at		
					,	fat_zanthus_voucher_count_m50ag	
					,	fat_zanthus_conferencia 	
					,	fat_zanthus_processado 		
					,	fat_zanthus_pag 	
					,   tiponota 		
				)

			SELECT 		vfat_zanthus_data_m00af						
					,   vfat_zanthus_sat_ecf_m00ac					
					,   vfat_zanthus_cupomfiscal_m00ad				
					,   vfat_zanthus_cupomfiscalid_M00_id_unico		
					,	vfat_zanthus_cupomfiscal_cancelado_m45bo	
					,   vfat_zanthus_notafiscal_numnota				
					,   vfat_zanthus_notafiscal_serie_nf				
					,	vfat_zanthus_notafiscal_chave_m45xb			
					,	vfat_zanthus_status_cancelado				
					,	vfat_zanthus_cupomfiscal_valor_m45ak	
					,	vfat_zanthus_cpf_cnpj_m45bv	
					,	vfat_zanthus_hora_ini_m45ai
					,	vfat_zanthus_hora_fim_m45au
					,	vfat_zanthus_cod_funcionario_m45ah
					,	vfat_zanthus_voucher_cod_m50ar		
					,	vfat_zanthus_voucher_valor_m50at		
					,	vfat_zanthus_voucher_count_m50ag	
					,	cast(vfat_zanthus_conferencia as smallint) 	
					,	cast(vfat_zanthus_processado as smallint)
					,	cast(vfat_zanthus_pag as smallint)
					,   vtiponota
				where 1 = 1
				and not exists	( 	select 1
									from 	tbfaturamentozanthus X
									WHERE 	1 = 1
									  AND	X.fat_zanthus_data_m00af = vfat_zanthus_data_m00af
									  and 	X.fat_zanthus_sat_ecf_m00ac = vfat_zanthus_sat_ecf_m00ac
									  and 	X.fat_zanthus_cupomfiscal_m00ad = vfat_zanthus_cupomfiscal_m00ad
								)
					;

			UPDATE 	tbfaturamentozanthus
			set 	fat_zanthus_cupomfiscal_cancelado_m45bo = vfat_zanthus_cupomfiscal_cancelado_m45bo
				,	fat_zanthus_status_cancelado 			= vfat_zanthus_status_cancelado
				,	fat_zanthus_conferencia 				= cast(vfat_zanthus_conferencia as smallint)
				,	fat_zanthus_processado 					= cast(vfat_zanthus_processado as smallint)
				,	fat_zanthus_pag 						= cast(vfat_zanthus_pag as smallint)
				,   tiponota                               = vtiponota 
				,	dtlog_update = current_timestamp 
			WHERE 	1 = 1
			  AND	fat_zanthus_data_m00af = vfat_zanthus_data_m00af
			  and 	fat_zanthus_sat_ecf_m00ac = vfat_zanthus_sat_ecf_m00ac
			  and 	fat_zanthus_cupomfiscal_m00ad = vfat_zanthus_cupomfiscal_m00ad
			  ;
		End if;		
	
		
		IF (SQLCOMMAND = 'DBUPDATE')
		THEN
			UPDATE 	tbfaturamentozanthus
			set 	fat_zanthus_cupomfiscal_cancelado_m45bo = vfat_zanthus_cupomfiscal_cancelado_m45bo
				,	fat_zanthus_status_cancelado 			= vfat_zanthus_status_cancelado
				,	fat_zanthus_conferencia 				= cast(vfat_zanthus_conferencia as smallint)
				,	fat_zanthus_processado 					= cast(vfat_zanthus_processado as smallint)
				,	fat_zanthus_pag 						= cast(vfat_zanthus_pag as smallint)
				,   tiponota                               = vtiponota 
				,	dtlog_update = current_timestamp 
			WHERE 	1 = 1
			  AND	fat_zanthus_data_m00af = vfat_zanthus_data_m00af
			  and 	fat_zanthus_sat_ecf_m00ac = vfat_zanthus_sat_ecf_m00ac
			  and 	fat_zanthus_cupomfiscal_m00ad = vfat_zanthus_cupomfiscal_m00ad
			  ;
		End if;	

end;
$BODY$;


