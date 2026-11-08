-- FUNCTION: public.f0085_10_1012014_zanthusprocessamento()

-- DROP FUNCTION IF EXISTS public.f0085_10_1012014_zanthusprocessamento();

--SELECT f0085_06_1012014_zanthusprocessamento_tributacao()

CREATE OR REPLACE FUNCTION public.f0085_55_1012016_zanthus_carga_preco_voucher(
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

	vuuid_start:= 'F0085_55.1012016' || replace(cast(random() * 100 as varchar(10)),'.','')
	;
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_55.1012016', 'ZanthusProcessamento - Precos/Voucher', vuuid_start)
	;
	

	DROP TABLE IF EXISTS TMP_ZANTHUS_PRODUTO_PRECO;
	CREATE TEMP TABLE IF NOT EXISTS TMP_ZANTHUS_PRODUTO_PRECO 
		(
				TAB_PRE_CD							INT
			,	PR_CDPRODUTO 						INT
			,	PRB_CDPRODUTOBLUESOFT_UNITARIO		INT
			,	PR_EMBALAGEMESTOQUE 				CHAR(2)
			,	PRC_VALOR_EMBALAGEMESTOQUE 			NUMERIC(13,2)
			,	PRB_CDPRODUTOBLUESOFT 				INT
			,	PRE_EMBALAGEM 						CHAR(2)
			,	PRE_FATORESTOQUE 					NUMERIC(17,4)
			,	PRC_VALOR							NUMERIC(13,2)
			,	PRC_QTDE_PROMOCIONAL 				NUMERIC(17,4)
			,	PRC_VALOR_PROMOCIONAL 				NUMERIC(13,2)
			,	CONSTRAINT pkTMP_ZANTHUS_PRODUTO_PRECO primary  key (PR_CDPRODUTO,PRB_CDPRODUTOBLUESOFT, TAB_PRE_CD )
		);

	DELETE FROM TMP_ZANTHUS_PRODUTO_PRECO;

	INSERT INTO TMP_ZANTHUS_PRODUTO_PRECO 
	(			TAB_PRE_CD
			,	PR_CDPRODUTO 
			,	PRB_CDPRODUTOBLUESOFT_UNITARIO
			,	PR_EMBALAGEMESTOQUE 
			,	PRC_VALOR_EMBALAGEMESTOQUE 
			,	PRB_CDPRODUTOBLUESOFT 
			,	PRE_EMBALAGEM 
			,	PRE_FATORESTOQUE 
			,	PRC_VALOR
			,	PRC_QTDE_PROMOCIONAL 
			,	PRC_VALOR_PROMOCIONAL

	)
		/******** PRODUTOS UN - UNITARIOS **********/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'UN'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO = PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 --14/04/2022 
		UNION 
		/******** PRODUTOS UN - OUTRAS EMBALAGENS CX/BD **********/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	CAST(CASE WHEN COALESCE(PRC_VALOR_PROMOCIONAL,0) < PRC_VALOR AND PRC_VALOR_PROMOCIONAL > 0 AND PRC_QTDE_PROMOCIONAL >= PRE_FATORESTOQUE and coalesce(PRE_FATORESTOQUE,0) > 1
							THEN  PRC_VALOR_PROMOCIONAL * PRE_FATORESTOQUE
							ELSE PRC_VALOR_EMBALAGEMESTOQUE * PRE_FATORESTOQUE
					END AS NUMERIC (13,2)) AS PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) 	AS  PRC_VALOR_PROMOCIONAL			
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'UN'
		  AND       PRC_VALOR_EMBALAGEMESTOQUE > 0 --14/04/2022 
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO <> PRB_CDPRODUTOBLUESOFT

		----------------------------------------------------------------------
		UNION 
		/*PRODUTOS KG - UNITARIO*/
		---------------------------------------------------------------------

		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'KG'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO = PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 -- 14/04/2022
		----------------------------------------------------------------------
		UNION 
		/*PRODUTOS KG - CORTES*/
		SELECT 		TAB_PRE_CD
				,	PR_CDPRODUTO 
				,	PRB_CDPRODUTOBLUESOFT_UNITARIO
				,	PR_EMBALAGEMESTOQUE 
				,	PRC_VALOR_EMBALAGEMESTOQUE 
				,	PRB_CDPRODUTOBLUESOFT 
				,	PRE_EMBALAGEM 
				,	PRE_FATORESTOQUE 
				,	PRC_VALOR 		
				,	PRC_QTDE_PROMOCIONAL 
				,	COALESCE(PRC_VALOR_PROMOCIONAL,0) AS  PRC_VALOR_PROMOCIONAL		
		FROM 		TBPRECO_APLICACAO
		WHERE 		PR_EMBALAGEMESTOQUE = 'KG'
		  AND  		PRB_CDPRODUTOBLUESOFT_UNITARIO <> PRB_CDPRODUTOBLUESOFT
		  AND		PRC_VALOR > 0 -- 14/04/2022
		;	

	-------------------------------------------------------------------------------------------------------------------------
	/* TAB_MERCADORIA_TIPO_VENDA  */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Tipo Venda', vuuid_start)
	;
	
	DELETE FROM TbZanthusTab_Mercadoria_Tipo_Venda;
	INSERT INTO TbZanthusTab_Mercadoria_Tipo_Venda
	(

						tab_pre_cd 
					,	pr_Cdproduto 
					,	prb_cdprodutobluesoft 
					,	preg_cdbarra
					,	cod_loja
					,	controle
					,	cod_mercadoria 
					,	cod_tipo_venda 
					,	usuario 
					,	data_cadastro 
					, 	data_ultima_alteracao 
					,	preco_unitario 
					, 	percentual_comissao_vendedor 
					,	preco_anterior 
			)

	SELECT 		PC.TAB_PRE_CD 
			,	pc.pr_cdproduto 
			,	pc.prb_cdprodutobluesoft 
			,	gt.preg_cdbarra 
			,	1
			,	'000'
			,	gt.cod_mercadoria 
			,	pc.tab_pre_cd 
			,	'ZANTHUS'
			,	current_date 
			,	null 
			,	pc.PRC_VALOR
			,	cast(0 as numeric(13,2))
			,	cast(0 as numeric(13,2))		
	FROM 		TbZanthusTab_Mercadoria			gt
	INNER JOIN 	TMP_ZANTHUS_PRODUTO_PRECO		pc
										on 		gt.prb_cdprodutobluesoft = pc.prb_cdprodutobluesoft 
										and		gt.pr_cdproduto = pc.pr_cdproduto 
	where 	1 = 1 
	AND 	pc.prb_cdprodutobluesoft NOT IN  (	SELECT PRB_CDPRODUTOBLUESOFT FROM TBPRODUTO_COMPOSICAO )
	---AND 	length(gt.preg_cdbarra) in (8, 13, 14, 6)
	;

	-------------------------------------------------------------------------------------------------------------------------
	/* TAB_MERCADORIA_TIPO_VENDA QTDE */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - Tab Tipo Venda Qtde', vuuid_start)
	;
	
	delete from TbZanthusTab_Mercadoria_Tipo_Venda_qtde ;

	INSERT INTO TbZanthusTab_Mercadoria_Tipo_Venda_qtde 
		(		tab_pre_cd									
			,	pr_cdproduto 								 
			,	prb_cdprodutobluesoft						
			,	preg_cdbarra								
			,	cod_loja									
			,	cod_mercadoria 								
			,	cod_tipo_venda								
			,	qtde_venda									
			,	flg_geral 									
			,	preco_unitario 								
			,	perc_desconto 								
			,	flg_ativo									
			,	dth_inclusao								
			,	dth_alteracao 								
			,	idt_usuario_alteracao 						
			)		

	SELECT 		PC.TAB_PRE_CD 						as TAB_PRE_CD
			,	pc.pr_cdproduto 					as pr_cdproduto
			,	pc.prb_cdprodutobluesoft 			as prb_cdprodutobluesoft
			,	gt.preg_cdbarra 					as preg_cdbarra
			, 	cast(1 as int)						as  cod_loja
			,	gt.cod_mercadoria 					as cod_mercadoria
			,	pc.tab_pre_cd 						as cod_tipo_venda
			,	pc.prc_qtde_promocional 			as qtde_venda 
			,	cast(0 as int) 						as flg_geral 
			,	cast( pc.prc_valor_promocional * pre_fatorestoque as numeric(13,2))		as preco_unitario 
			,	cast(0.00 as numeric(13,2)) 		as perce_desconto 
			,	cast('S' as char(1))				as flg_ativo 
			,	current_timestamp 					as dth_inclusao
			,	current_timestamp 					as dth_altercao 
			,	cast(100 as int) 					as idt_usuario_alteracao		

	FROM 		TbZanthusTab_Mercadoria			gt
	INNER JOIN 	TMP_ZANTHUS_PRODUTO_PRECO		pc
										on 		gt.prb_cdprodutobluesoft = pc.prb_cdprodutobluesoft 
										and		gt.pr_cdproduto = pc.pr_cdproduto 
	where 	1 = 1 
	and		prc_qtde_promocional > 0 
	and		prc_valor_promocional > 0 
	and		prc_qtde_promocional >= pre_fatorestoque 
	----AND 	length(gt.preg_cdbarra) in (8, 13, 14, 6)
	;

	-------------------------------------------------------------------------------------------------------------------------
	/* TODOS PROMOCIONAIS VAO FICAR COMO PENDENTES */
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------
	insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info, uuid_start)
			values (850010, 'F0085_10 (V1012007)', 'ZanthusProcessamento - PROMOCIONAL', vuuid_start)
	;
		
		-->> Criamos uma tabela temporária para inserir os produtos que tiveram alteracao 
		---------------------------------------------------------------------------------
	drop table if exists tmpintegracao_produto
	;		
	create TEMPORARY table tmpintegracao_produto
		(
				integracao_produto_seq int
			,	pr_cdproduto int
			,	prb_cdprodutobluesoftunitario int
			,	prb_cdprodutobluesoft int 
			,	integracao_tipo_cd int
			,	integracao_status_cd int
		)
	;
	
	INSERT INTO tmpintegracao_produto 	
		(
				pr_cdproduto 
			,	prb_cdprodutobluesoftunitario 
			,	prb_cdprodutobluesoft
			,	integracao_tipo_cd 
			,	integracao_status_cd 
		)
	
	select 		p.pr_cdproduto
			,	p.prb_cdprodutobluesoft
			,	p.prb_cdprodutobluesoft 
			,	20008501
			,	2
	from 		TbZanthusTab_Mercadoria_Tipo_Venda v
	inner join 	tbproduto p on p.pr_cdproduto = v.pr_cdproduto
	where 		v.cod_tipo_venda = 2 ---->>> PROMOCIONAIS COLOCAR COMO PENDENTES
	group by p.pr_cdproduto
			,	p.prb_cdprodutobluesoft
			,	p.prb_cdprodutobluesoft 

	;

	
		-->> Inserimos os produtos da tabela temporária na tabela de integracao_produto	
		---------------------------------------------------------------------------------
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
	from 		tmpintegracao_produto pr
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
	update tmpintegracao_produto tmp 
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
		,	'F0085_10_CARGA(PRM)'
		,	(select sis_log_seq from tbsistema_log where uuid = vuuid_start)
	from 	tmpintegracao_produto x
	where   1 = 1
	;
	
	
	
		-->> Atualizamos o status dos produtos que ja existiam na tabela 
		---------------------------------------------------------------------------------
	UPDATE 	tbintegracao_produto XX
	  SET   	integracao_status_cd 	= 2
	  	,		dtlog_update 			= current_timestamp 
	FROM 	tmpintegracao_produto	  AA 
	WHERE 	XX.integracao_produto_seq = AA.integracao_produto_seq
	  AND   XX.integracao_tipo_cd = 20008501
	
	;	

	drop table if exists tmpintegracao_produto
	;

	vcod_voucher:= (SELECT TO_CHAR(current_date, 'YYYYMMDD'))
	;

	

	INSERT INTO tbzanthus_voucher_promocional
		(
				cod_voucher
			,	data_voucher 
			,	descricao 
			,	data_validade_inicial 
			,	data_validade_final 
		)	SELECT vcod_voucher
			,	   current_date 
			,	   'PROMOCAO DIA ' || vcod_voucher
			,		current_date 
			, 		current_date 
			WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_voucher_promocional WHERE cod_voucher = vcod_voucher)
	;

	

	 insert into tbzanthus_voucher_promocional_prod
	 	(
				cod_voucher 
			,	cod_produto 
			,	valor_aplicacao 
			,   qtd_maxima
		)

      select		
                       vcod_voucher                                                   as cod_voucher				 
                    ,	m.cod_mercadoria                                               as cod_produto				 
                    ,	cast(v1.preco_unitario - v2.preco_unitario as numeric(13,2))   as valor_aplicacao			 
					,	0
        from		TbZanthusTab_Mercadoria		m
        left join	TbZanthusTab_Mercadoria_Tipo_Venda	v1 on v1.cod_mercadoria = m.cod_mercadoria and v1.cod_tipo_venda = '1'
        left join   TbZanthusTab_Mercadoria_Tipo_Venda	v2 on v2.cod_mercadoria = m.cod_mercadoria and v2.cod_tipo_venda = '2'
        where		1 = 1
        and		    cast(v1.preco_unitario as numeric(13,2)) > cast(v2.preco_unitario as numeric(13,2))
	    and not exists ( select 1 
		                 from   tbzanthus_voucher_promocional_prod x
						 where   x.cod_voucher = vcod_voucher 
						   and   x.cod_produto = m.cod_mercadoria 
						 )
	
	;

end;
$BODY$;