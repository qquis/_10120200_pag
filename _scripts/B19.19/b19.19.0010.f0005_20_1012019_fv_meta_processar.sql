-- FUNCTION: public.f0021_90_1012019_produtobluesoft_processamento()

-- DROP FUNCTION IF EXISTS public.f0021_90_1012019_produtobluesoft_processamento();

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0005_20_1012019_fv_meta_processar(vcompetencia_cd int)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
	declare vvdata_faturamento_ini date;
	declare vvdata_faturamento_fim date;
BEGIN 	

	

	vvdata_faturamento_ini := (select competencia_data_ini from tbcompetencia where competencia_cd = vcompetencia_cd);
	vvdata_faturamento_fim := (select competencia_data_fim from tbcompetencia where competencia_cd = vcompetencia_cd);






/*  *************************************LIMPANDO OS REGISTROS ANTERIORES **************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/


	UPDATE		tbforca_venda_meta_vendedor X 
	SET			fv_meta_rz_pos	 		= 0
			,	fv_meta_rz_qtde	 		= 0
			,	fv_meta_rz_valor	 	= 0
			,	fv_meta_base_pos	 	= 0
			,	fv_meta_base_qtde	 	= 0
			,	fv_meta_base_valor 		= 0
			,	fv_meta_bonus_percentual = 0 
			,	fv_meta_resultado_valor = 0 
	FROM		tbforca_venda_meta		  MA 
	WHERE		1 = 1
	AND			MA.fv_meta_cd = x.fv_meta_cd 
	and			MA.competencia_cd = @COMPETENCIA_CD -- @COMPETENCIA_CD


;



/*  *************************************ATUALIZNADO METAS FIXAS TIPO 99 ***************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/

	UPDATE      tbforca_venda_meta_vendedor A
	   set      fv_meta_rz_pos	 = MR.qtde_positivacao
			,	fv_meta_rz_qtde	 = 0
			,	fv_meta_rz_valor = 0
    FROM       (
					SELECT 	    a.cdparticipantevendedor
							,	a.qtde_positivacao 
							,   m.fv_meta_cd
					FROM 		tbforca_venda_fab_meta_res_vendedor a
					INNER JOIN  tbforca_venda_meta_info 			mi on mi.fv_fab_meta_cd = a.fv_fab_meta_cd 
																and mi.fv_fab_meta_mix_cd = a.fv_fab_meta_mix_cd
					INNER JOIN  tbforca_venda_meta 					m  on m.fv_meta_cd = mi.fv_meta_cd
					WHERE       m.competencia_cd = vcompetencia_cd
					AND         m.fv_meta_tipo_cd = 99 -->> DO TIPO MIX
					and         a.seqinterface = 0 ---> BASE DE DADOS REAL
				) MR 
	WHERE      A.fv_meta_cdparticipantevendedor = MR.cdparticipantevendedor
	  AND      A.fv_meta_cd = MR.fv_meta_cd

	;





/*  *************************************LEVANTAMENTO DO RESULTADO DE VENDAS ************************************* 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/


	drop table if EXISTS tmp_base_venda_produto;
	create temporary table tmp_base_venda_produto (
		SeqFaturamento int,
		SeqFaturamentoOrigem int,
		CdParticipanteVendedor int,
		CdParticipanteCliente int,
		DataEmissao date,
		DataFaturamento date,
		NumeroNfe int,
		NumeroPedido int, 
		Nfe int,
		CdProduto int,
		cdprodutobluesoft int,
		descricao varchar(60),
		prb_cdpessoabluesoft_fabricante int,
		cdgrupoeconomico int,
		EmbalagemEstoqueQtde numeric,
		EmbalagemCompraQtde numeric,
		ValorTotalFaturamento numeric

	);

	insert into tmp_base_venda_produto (
			SeqFaturamento,
			SeqFaturamentoOrigem,
			CdParticipanteVendedor,
			CdParticipanteCliente,
			DataEmissao,
			DataFaturamento,
			NumeroNfe,
			NumeroPedido,
			CdProduto,
			cdprodutobluesoft,
			descricao,
			prb_cdpessoabluesoft_fabricante,
			cdgrupoeconomico,
			EmbalagemEstoqueQtde,
			EmbalagemCompraQtde,
			ValorTotalFaturamento
	)
	SELECT			F.SeqFaturamento 
				,	O.SeqFaturamentoOrigem 
				,	F.CdParticipanteVendedor		
				,	F.CdParticipanteCliente 
				,	f.DataEmissao 
				,	f.DataFaturamento 
				,	O.NumeroNfe 
				,	O.NumeroPedido 
				,	I.pr_cdproduto										    
				,	pr.prb_cdprodutobluesoft 							as cdprodutobluesoft
				,	pr.pr_descricao                                     as descricao 
				,	pb.prb_cdpessoabluesoft_fabricante					as prb_cdpessoabluesoft_fabricante
				,	coalesce(g.cdgrupoeconomico,0) 						as cdgrupoeconomico
				
				,	SUM(I.EmbalagemEstoqueQtde)                           as EmbalagemEstoqueQtde
				,	SUM(I.EmbalagemCompraQtde)                            as EmbalagemCompraQtde
				,	SUM(I.ValorTotalFaturamento)                           as ValorTotalFaturamento

	FROM		TbFaturamento			f
	INNER JOIN	TbFaturamentoOrigem		o 	on o.SeqFaturamento = f.SeqFaturamento 
	INNER JOIN	TbFaturamentoItens		i 	on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
	INNER JOIN  tbproduto             	pr 	on pr.pr_cdproduto = i.pr_cdproduto 
	INNER JOIN  tbprodutobluesoft       pb  on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
	INNER JOIN  tbparticipante_bluesoft c   on c.cdparticipante = f.cdparticipantecliente
	INNER JOIN  tbgrupoeconomico        g   on g.cdgrupoeconomico = c.cdgrupoeconomico

	WHERE		1 = 1
	AND			F.em_cdempresa = 1
	AND			F.op_cdoperacao = 1
	AND			f.StatusFaturamento  = 1
	and			i.StatusFaturamentoItem = 1
	AND			F.DataFaturamento >= vvdata_faturamento_ini
	AND			F.DataFaturamento <= vvdata_faturamento_fim 
	GROUP BY		
		F.SeqFaturamento 
				,	O.SeqFaturamentoOrigem 
				,	F.CdParticipanteVendedor		
				,	F.CdParticipanteCliente 
				,	f.DataEmissao 
				,	f.DataFaturamento 
				,	O.NumeroNfe 
				,	O.NumeroPedido 
				,	I.pr_cdproduto										    
				,	pr.prb_cdprodutobluesoft 							
				,	pr.pr_descricao                                     
				,	pb.prb_cdpessoabluesoft_fabricante					
				,	coalesce(g.cdgrupoeconomico,0) 						
				


		;

	drop table if exists tmp_meta_realizada;
	CREATE TEMPORARY TABLE tmp_meta_realizada (
		fv_meta_cd				INT,
		cdparticipantevendedor	INT,
		fv_meta_rz_pos			INT,
		fv_meta_rz_qtde			DECIMAL(18,2),
		fv_meta_rz_valor		DECIMAL(18,2)


	);

	INSERT INTO tmp_meta_realizada 
	(
			fv_meta_cd
		, 	cdparticipantevendedor
		, 	fv_meta_rz_pos
		, 	fv_meta_rz_qtde
		, 	fv_meta_rz_valor
	)
	SELECT		RQ.fv_meta_cd				
			,	BASE.CdParticipanteVendedor 
			,	COUNT(DISTINCT(BASE.CdParticipanteCliente))
			,	SUM(BASE.EmbalagemCompraQtde)
			,	SUM(BASE.ValorTotalFaturamento)

	FROM		tmp_base_venda_produto	BASE 

	INNER JOIN  tbforca_venda_meta_vendedor   VM ON VM.fv_meta_cdparticipantevendedor = BASE.CdParticipanteVendedor
	INNER JOIN  tbforca_venda_meta            M  ON M.fv_meta_cd = VM.fv_meta_cd  
	INNER JOIN	tbforca_venda_meta_composicao RQ on
							 RQ.fv_meta_cd = M.fv_meta_cd
						 AND RQ.fv_meta_composicao_tipo_cd = 1
						 AND base.CdParticipanteVendedor		  = CASE WHEN coalesce(RQ.cdparticipantevendedor,0)		= 0 then base.CdParticipanteVendedor		  else  RQ.cdparticipantevendedor end 
						 AND base.prb_cdpessoabluesoft_fabricante = CASE WHEN coalesce(RQ.cdpessoabluesoftfabricante,0) = 0 then base.prb_cdpessoabluesoft_fabricante else  RQ.cdpessoabluesoftfabricante end 
						 AND base.cdgrupoeconomico				  = CASE WHEN coalesce(RQ.cdgrupoeconomico,0)			= 0 then base.cdgrupoeconomico				  else  RQ.cdgrupoeconomico end 
						 AND base.CdParticipanteCliente			  = CASE WHEN coalesce(RQ.cdparticipantecliente,0)		= 0 then base.CdParticipanteCliente			  else  RQ.cdparticipantecliente end 
						 AND base.CdProduto						  = CASE WHEN coalesce(RQ.pr_cdproduto,0)				= 0 then base.CdProduto						  else  RQ.pr_cdproduto end 
	LEFT JOIN   tbforca_venda_meta_composicao EX on
							 EX.fv_meta_cd = M.fv_meta_cd
						 AND EX.fv_meta_composicao_tipo_cd = 2
						 AND base.CdParticipanteVendedor		  = CASE WHEN coalesce(EX.cdparticipantevendedor,0)		= 0 then base.CdParticipanteVendedor		  else  EX.cdparticipantevendedor end 
						 AND base.prb_cdpessoabluesoft_fabricante = CASE WHEN coalesce(EX.cdpessoabluesoftfabricante,0) = 0 then base.prb_cdpessoabluesoft_fabricante else  EX.cdpessoabluesoftfabricante end 
						 AND base.cdgrupoeconomico				  = CASE WHEN coalesce(EX.cdgrupoeconomico,0)			= 0 then base.cdgrupoeconomico				  else  EX.cdgrupoeconomico end 
						 AND base.CdParticipanteCliente			  = CASE WHEN coalesce(EX.cdparticipantecliente,0)		= 0 then base.CdParticipanteCliente			  else  EX.cdparticipantecliente end 
						 AND base.CdProduto						  = CASE WHEN coalesce(EX.pr_cdproduto,0)				= 0 then base.CdProduto						  else  EX.pr_cdproduto end 
	WHERE		1 = 1
	and         M.competencia_cd = vcompetencia_cd
	and         EX.fv_meta_cd is null 
	GROUP BY	RQ.fv_meta_cd 
			,	BASE.CdParticipanteVendedor 


	;

	UPDATE		tbforca_venda_meta_vendedor X
	SET			fv_meta_rz_pos	 = MR.fv_meta_rz_pos 
			,	fv_meta_rz_qtde	 = MR.fv_meta_rz_qtde
			,	fv_meta_rz_valor = MR.fv_meta_rz_valor
			,   dtlog_update = current_timestamp 
	FROM		tbforca_venda_meta         M 
	INNER JOIN  tmp_meta_realizada		   MR ON MR.fv_meta_cd = M.fv_meta_cd 
	WHERE		1 = 1
	AND			M.competencia_cd = vcompetencia_cd
	AND         M.fv_meta_cd = X.fv_meta_cd 
	AND         MR.FV_META_CD = M.FV_META_CD
	AND 		mR.cdparticipantevendedor = x.fv_meta_cdparticipantevendedor

	;







/*  *************************************BASE DO PREMIO ********************************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/




	drop table if exists tmp_meta_base;
	CREATE TEMPORARY TABLE tmp_meta_base (
		fv_meta_cd				INT,
		cdparticipantevendedor	INT,
		fv_meta_base_pos		INT,
		fv_meta_base_qtde		DECIMAL(18,2),
		fv_meta_base_valor		DECIMAL(18,2)


	);

	INSERT INTO tmp_meta_base 
	(
		fv_meta_cd,				
		cdparticipantevendedor,
		fv_meta_base_pos,
		fv_meta_base_qtde,
		fv_meta_base_valor
	)
	SELECT		RQ.fv_meta_cd				
			,	BASE.CdParticipanteVendedor 
			,	COUNT(DISTINCT(BASE.CdParticipanteCliente))
			,	SUM(BASE.EmbalagemCompraQtde)
			,	SUM(BASE.ValorTotalFaturamento)

	FROM		tmp_base_venda_produto	BASE 

	INNER JOIN  tbforca_venda_meta_vendedor   VM ON VM.fv_meta_cdparticipantevendedor = BASE.CdParticipanteVendedor
	INNER JOIN  tbforca_venda_meta            M  ON M.fv_meta_cd = VM.fv_meta_cd  
	INNER JOIN	tbforca_venda_meta_composicao RQ on
							 RQ.fv_meta_cd = M.fv_meta_cd
						 AND RQ.fv_meta_composicao_tipo_cd = 3
						 AND base.CdParticipanteVendedor		  = CASE WHEN coalesce(RQ.cdparticipantevendedor,0)		= 0 then base.CdParticipanteVendedor		  else  RQ.cdparticipantevendedor end 
						 AND base.prb_cdpessoabluesoft_fabricante = CASE WHEN coalesce(RQ.cdpessoabluesoftfabricante,0) = 0 then base.prb_cdpessoabluesoft_fabricante else  RQ.cdpessoabluesoftfabricante end 
						 AND base.cdgrupoeconomico				  = CASE WHEN coalesce(RQ.cdgrupoeconomico,0)			= 0 then base.cdgrupoeconomico				  else  RQ.cdgrupoeconomico end 
						 AND base.CdParticipanteCliente			  = CASE WHEN coalesce(RQ.cdparticipantecliente,0)		= 0 then base.CdParticipanteCliente			  else  RQ.cdparticipantecliente end 
						 AND base.CdProduto						  = CASE WHEN coalesce(RQ.pr_cdproduto,0)				= 0 then base.CdProduto						  else  RQ.pr_cdproduto end 
	LEFT JOIN   tbforca_venda_meta_composicao EX on
							 EX.fv_meta_cd = M.fv_meta_cd
						 AND EX.fv_meta_composicao_tipo_cd = 4
						 AND base.CdParticipanteVendedor		  = CASE WHEN coalesce(EX.cdparticipantevendedor,0)		= 0 then base.CdParticipanteVendedor		  else  EX.cdparticipantevendedor end 
						 AND base.prb_cdpessoabluesoft_fabricante = CASE WHEN coalesce(EX.cdpessoabluesoftfabricante,0) = 0 then base.prb_cdpessoabluesoft_fabricante else  EX.cdpessoabluesoftfabricante end 
						 AND base.cdgrupoeconomico				  = CASE WHEN coalesce(EX.cdgrupoeconomico,0)			= 0 then base.cdgrupoeconomico				  else  EX.cdgrupoeconomico end 
						 AND base.CdParticipanteCliente			  = CASE WHEN coalesce(EX.cdparticipantecliente,0)		= 0 then base.CdParticipanteCliente			  else  EX.cdparticipantecliente end 
						 AND base.CdProduto						  = CASE WHEN coalesce(EX.pr_cdproduto,0)				= 0 then base.CdProduto						  else  EX.pr_cdproduto end 
	WHERE		1 = 1
	and         M.competencia_cd = vcompetencia_cd
	and         EX.fv_meta_cd is null 
	GROUP BY	RQ.fv_meta_cd 
			,	BASE.CdParticipanteVendedor 


	;

	UPDATE		tbforca_venda_meta_vendedor X
	SET			fv_meta_base_pos	 = MR.fv_meta_base_pos 
			,	fv_meta_base_qtde	 = MR.fv_meta_base_qtde
			,	fv_meta_base_valor = MR.fv_meta_base_valor
			,   dtlog_update = current_timestamp 
	FROM		tbforca_venda_meta         M 
	INNER JOIN  tmp_meta_base		   MR ON MR.fv_meta_cd = M.fv_meta_cd 
	WHERE		1 = 1
	AND			M.competencia_cd = vcompetencia_cd
	AND         M.fv_meta_cd = X.fv_meta_cd 
	AND         MR.FV_META_CD = M.FV_META_CD
	AND 		mR.cdparticipantevendedor = x.fv_meta_cdparticipantevendedor

	;




/*  *************************************CALCULOS **************************************************************** 
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************
	**************************************************************************************************************

*/






	--- METAS TIPO 1 - Positivação Fixa 
	UPDATE		tbforca_venda_meta_vendedor	MV 
		SET		fv_meta_bonus_percentual = M.fv_meta_bonus_percentual 
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor * M.fv_meta_bonus_percentual/100 as numeric(13,2) )
			,   dtlog_update = current_timestamp 
	FROM		tbforca_venda_meta m
	WHERE		1 = 1
	AND         M.fv_meta_cd = MV.fv_meta_cd 
	AND			M.competencia_cd = vcompetencia_cd
	AND			M.fv_meta_tipo_cd = 1
	AND			MV.fv_meta_rz_pos >= MV.fv_meta_rq_pos 



	;

	--- METAS TIPO 2 - POSITIVACAO PROPORCIONAL
	update		tbforca_venda_meta_vendedor	MV
		set		fv_meta_bonus_percentual = cast((M.fv_meta_bonus_percentual / M.fv_meta_bonus_percentual_proporcional)  * ( ( case when MV.fv_meta_rz_pos > MV.fv_meta_rq_pos_maximo then MV.fv_meta_rq_pos_maximo else MV.fv_meta_rz_pos end )  ) as numeric(13,2))
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor *
																	 (M.fv_meta_bonus_percentual / M.fv_meta_bonus_percentual_proporcional)  
																	 * ( ( case when MV.fv_meta_rz_pos > MV.fv_meta_rq_pos_maximo then MV.fv_meta_rq_pos_maximo else MV.fv_meta_rz_pos end ))/100
																	 as numeric(13,2))
	from		tbforca_venda_meta			M 
	where		1 = 1 
	AND         M.fv_meta_cd = MV.fv_meta_cd 
	and			M.competencia_cd = vcompetencia_cd
	AND			M.fv_meta_tipo_cd = 2
	and			MV.fv_meta_rz_pos >= MV.fv_meta_rq_pos_minimo 

	;


	--- METAS TIPO 3 - Percentual VOLUME Fixo
	UPDATE		tbforca_venda_meta_vendedor	MV 
		SET		fv_meta_bonus_percentual = M.fv_meta_bonus_percentual 
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor * M.fv_meta_bonus_percentual/100 as numeric(13,2))
	FROM		tbforca_venda_meta			M 
	WHERE		1 = 1
	AND         M.fv_meta_cd = MV.fv_meta_cd
	AND			M.competencia_cd = vcompetencia_cd
	AND			M.fv_meta_tipo_cd = 3
	AND			MV.fv_meta_rz_qtde >= MV.fv_meta_rq_qtde 
	AND         MV.fv_meta_rq_qtde > 0


	;
	--- METAS TIPO 4 - Percentual VALOR Fixo
	UPDATE		tbforca_venda_meta_vendedor	MV 
		SET		fv_meta_bonus_percentual = M.fv_meta_bonus_percentual 
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor * M.fv_meta_bonus_percentual/100 as numeric(13,2))

	FROM		tbforca_venda_meta	m		
	WHERE		1 = 1
	and         M.fv_meta_cd = MV.fv_meta_cd 
	AND			M.competencia_cd = vcompetencia_cd
	AND			M.fv_meta_tipo_cd = 4
	AND			MV.fv_meta_rz_valor >= MV.fv_meta_rq_valor 

	;


	--- METAS TIPO 5 - Valor PROPORCIONAL 
	update		tbforca_venda_meta_vendedor	MV
		set		fv_meta_bonus_percentual = cast((M.fv_meta_bonus_percentual / M.fv_meta_bonus_percentual_proporcional)  * ( ( case when MV.fv_meta_rz_valor > MV.fv_meta_rq_valor_maximo then M.fv_meta_bonus_percentual else floor((MV.fv_meta_rz_valor - mv.fv_meta_rq_valor_minimo ) / m.fv_meta_bonus_numero_proporcional) end )  ) as numeric(13,2))
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor *
																	 (M.fv_meta_bonus_percentual / M.fv_meta_bonus_percentual_proporcional)  * ( ( case when MV.fv_meta_rz_valor > MV.fv_meta_rq_valor_maximo then M.fv_meta_bonus_percentual else floor((MV.fv_meta_rz_valor - mv.fv_meta_rq_valor_minimo ) / m.fv_meta_bonus_numero_proporcional) end )  )/100 as numeric(13,2)
																	 )
	from		tbforca_venda_meta			M 
	where		1 = 1 
	and         M.fv_meta_cd = MV.fv_meta_cd 
	and			M.competencia_cd = vcompetencia_cd --@COMPETENCIA_CD
	AND			M.fv_meta_tipo_cd = 5
	and			MV.fv_meta_rz_valor >= coalesce(MV.fv_meta_rq_valor_minimo, MV.fv_meta_rq_valor)


	;




	--- METAS TIPO 99 - COMPOSICAO FIXA (TIPO POSITIVACAO)
	UPDATE		tbforca_venda_meta_vendedor	MV  
		SET		fv_meta_bonus_percentual = M.fv_meta_bonus_percentual 
			,	fv_meta_resultado_valor = cast(mv.fv_meta_base_valor * M.fv_meta_bonus_percentual/100 as numeric(13,2))

	FROM		tbforca_venda_meta		m	
	WHERE		1 = 1
	AND         M.fv_meta_cd = MV.fv_meta_cd 
	AND			M.competencia_cd = vcompetencia_cd
	AND			M.fv_meta_tipo_cd = 99
	AND			MV.fv_meta_rz_pos >= MV.fv_meta_rq_pos 

	;

	end;
$BODY$;

SELECT f0005_20_1012019_fv_meta_processar(202610);

