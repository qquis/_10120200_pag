-- FUNCTION: public.f0085_50_1012016_zanthus_carga_decomposicao()

-- DROP FUNCTION IF EXISTS public.f0085_50_1012016_zanthus_carga_decomposicao();

CREATE OR REPLACE FUNCTION public.f0085_50_1012017_zanthus_carga_decomposicao(
	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
   DECLARE VSOMA_TOTAL numeric(13,2);
   declare vuuid_start varchar(30);
   declare vcod_voucher varchar(8);
begin

	vuuid_start:= 'fF0085_50.1012017' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	-------------------------------------------------------------------------------------------------------------------------
	/* ITENS CESTA BASICA */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	

	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_50.zanthus_carga_decomposicao.2017', 'Zanthus/Carga (1) _ Decomposicao', vuuid_start, vuuid_start)
	;

	DELETE FROM TbZanthustab_produto_decomposicao_insum;
	DELETE FROM TbZanthustab_produto_decomposicao;

	INSERT INTO TbZanthustab_produto_decomposicao_insum
		(
				pr_cdproduto 				
			,	prb_cdprodutobluesoft		
			,	cod_loja					
			,	cod_mercadoria				
			,	cod_insumo	
			,	preg_cdbarra_insumo			
			,	usuario						
			,	data_cadastro				
			,	data_ultima_alteracao 		
			,	controle											
			,	percentual_insumo			
			,	quantidade_insumo			
		)

	select 		pr.pr_cdproduto
			,	cp.prb_cdprodutobluesoft
			,	1
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
			,	repeat('0', 17 - length(gcp.prb_cdbarra_principal) ) || gcp.prb_cdbarra_principal
			,	gcp.prb_cdbarra_principal
			,	'1'
			,	current_timestamp 
			,	current_timestamp
			,	null
			,	cp.prc_percentual_composicao 
			,	cp.prc_qtde 
	from 		tbproduto_composicao			cp 
	LEFT JOIN   tbproduto						pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft gun on gun.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft gcp on gcp.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft
	;

	insert into TbZanthustab_produto_decomposicao 
		(
				pr_cdproduto 				
			,	prb_cdprodutobluesoft	
			,	preg_cdbarra
			,	cod_loja					
			,	controle										
			,	cod_mercadoria				
			,	forma_decomposicao			
			,	tipo_decomposicao			
			,	usuario						
			,	data_cadastro				 
			,	data_ultima_alteracao 		
		)

	select 		pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft
			,	gun.prb_cdbarra_principal
			,	1
			,	NULL 
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
			,	4
			,	7
			,	1 
			,	CURRENT_TIMESTAMP 
			,	CURRENT_TIMESTAMP 
	from 		tbproduto_composicao			cp 
	LEFT JOIN   tbproduto						pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario 
	LEFT JOIN 	tbprodutobluesoft 				gun on gun.prb_cdprodutobluesoft_pk = cp.prb_cdprodutobluesoft_unitario 
	GROUP BY 	pr.pr_cdproduto
			,	pr.prb_cdprodutobluesoft
			,	gun.prb_cdbarra_principal
			,	repeat('0', 17 - length(gun.prb_cdbarra_principal) ) || gun.prb_cdbarra_principal
	;

	
end;
$BODY$;



