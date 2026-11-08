-- FUNCTION: public.f0085_52_1012016_zanthus_carga_log()

-- DROP FUNCTION IF EXISTS public.f0085_52_1012016_zanthus_carga_log();

CREATE OR REPLACE FUNCTION public.f0085_52_1012017_zanthus_carga_log(
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

	vuuid_start:= 'F0085_52.1012017' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid, uuid_start)
			values (850010, 'F0085_52.zanthus_carga_log.2017', 'Zanthus/Carga (3) _ Log Tributacao', vuuid_start, vuuid_start)
	;

	drop table if exists tmpintegracao_produto_8510
	;
	
	create TEMPORARY table tmpintegracao_produto_8510
		(
				integracao_produto_seq int
			,	pr_cdproduto int
			,	prb_cdprodutobluesoftunitario int
			,	prb_cdprodutobluesoft int 
			,	integracao_tipo_cd int
			,	integracao_status_cd int
		)
	;

	INSERT INTO tmpintegracao_produto_8510 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)

	SELECT		XXX.pr_cdproduto 
			,	XXX.prb_cdprodutobluesoft -- unitario 
			,	XXX.prb_cdprodutobluesoft 
			,	20008501
			,	2				

	FROM (
					SELECT 			pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
		
					FROM tbzanthus_tributacao_nfce X
					inner join      tbproduto              	pr on pr.pr_cdproduto = x.pr_cdproduto 
					  WHERE NOT EXISTS ( 	SELECT 1 
											FROM 	TbZanthusTab_Regra_Icms A 
											WHERE 	A.cod_mercadoria = x.cod_mercadoria 
				
										 )
						AND   X.PR_CDPRODUTO != 0 
						AND   X.PRB_CDPRODUTOBLUESOFT != 0 						 
				UNION 
					SELECT 			pr.pr_cdproduto 
								,	pr.prb_cdprodutobluesoft -- unitario 
			
					from 			tbzanthus_tributacao_nfce 		a
					inner join      TbZanthusTab_Regra_Icms 	x on  x.cod_mercadoria = x.cod_mercadoria 
					inner join      tbproduto              	pr on pr.pr_cdproduto = a.pr_cdproduto 
						WHERE  A.cod_mercadoria = x.cod_mercadoria 
						  AND  x.flg_tipo_imposto = 0
						  and (	    COD_NCM_INI  != a.ncm_codigo
								or  COD_NCM_FIM  != a.ncm_codigo
								or  ALIQUOTA     != a.icms_aliquota
								or  CST          != cast(CAST(icms_cst AS INT) as varchar(3))
								or  PERC_REDUCAO != a.icms_reducao 
							  )
			
			) XXX 

	GROUP BY 		XXX.pr_cdproduto 
				,	XXX.prb_cdprodutobluesoft -- unitario 
				,	XXX.prb_cdprodutobluesoft 

	-->> Inserimos os produtos da tabela temporária na tabela de integracao_produto	
	---------------------------------------------------------------------------------
	;
	INSERT INTO tbintegracao_produto 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)
	SELECT 		pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 
			,	pr.prb_cdprodutobluesoft 
			,	20008501
			,	2
	from 		tmpintegracao_produto_8510 pr
	where		1 = 1
	  and       not exists ( 	select 1 
								from   tbintegracao_produto x
								where  x.pr_cdproduto = pr.pr_cdproduto 
								  and  x.prb_cdprodutobluesoftunitario  = pr.prb_cdprodutobluesoft 
								  and  x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 		
								  and  x.integracao_tipo_cd = 20008501
						   )
	group by    pr.pr_cdproduto 
			,	pr.prb_cdprodutobluesoft 

	;

		-->> Atualizamos a tabela temporaria com os sequenciais gerados
		---------------------------------------------------------------------------------
	update tmpintegracao_produto_8510 tmp 
	   set integracao_produto_seq = x.integracao_produto_seq
	from   tbintegracao_produto  x
	where  x.pr_cdproduto = tmp.pr_cdproduto
	  and  x.prb_cdprodutobluesoftunitario = tmp.prb_cdprodutobluesoftunitario		
	  and  x.prb_cdprodutobluesoft = tmp.prb_cdprodutobluesoft
	  and  x.integracao_tipo_cd = 20008501
		
	;

		-->> Vamos inserir na tabela de lancamento de integracao o log destes registros
		---------------------------------------------------------------------------------

	insert into tbintegracao_lancamento
	(
		--	dtlog_insert 					
		--,	integracao_lancamento_seq 		
			integracao_tipo_cd 				
		,	integracao_produto_seq 			
		,	integracao_descricao 			
		,	sis_log_seq
	)
	select  2000
		,	x.integracao_produto_seq
		,	'F0085_10_zant_proc'
		,	(select sis_log_seq from tbsistema_log where uuid = vuuid_start)
	from 	tmpintegracao_produto_8510 x
	where   1 = 1
	and		( 
		
				not exists (	select 	1 
								from 	tbintegracao_produto a
								where 	a.integracao_produto_seq = x.integracao_produto_seq 
								  and   a.integracao_status_cd = 2
					  		 
						   )
				and 
					not exists ( select 1 from tbintegracao_lancamento b where b.integracao_produto_seq = x.integracao_produto_seq)
			)
	;
	
	
	
		-->> Atualizamos o status dos produtos que ja existiam na tabela 
		---------------------------------------------------------------------------------
	UPDATE 	tbintegracao_produto XX
	  SET   integracao_status_cd = 2
	  	,	dtlog_update = current_timestamp 
	FROM tmpintegracao_produto_8510	  AA 
	WHERE XX.integracao_produto_seq = AA.integracao_produto_seq
	
	;	

	DROP TABLE IF EXISTS tmpintegracao_produto_8510
	;

	insert into tbsistema_log(proc_log_seq, sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
	values (0, 21, 'PROC', 'ProdutoBluesoft Processamento Versão: 1012007 _ Fim', vuuid_start)
	;

end;
$BODY$;


