CREATE OR REPLACE FUNCTION public.f0070_30_1012019_faturamentocontrato_apuracao
		(	
				VCOMPETENCIA_CD INT
			,	VCONTRATO_SEQ INT	
		)
 RETURNS void
 LANGUAGE plpgsql
AS $function$

	DECLARE VDATA_PROCESSAMENTO_INI date;
	DECLARE VDATA_PROCESSAMENTO_FIM date;


begin

	
	/* QUERY UTEIS
	-- SELECT * FROM TBFATURAMENTOITENS LIMIT 10
	-- select * from tbfaturamentocontrato LIMIT 10
	-- select * from tbfaturamentocontrato_tipo
	-- select * from tbfaturamentoitenscontratos LIMIT 10
	*/

	/*  
	
	
	*/
	/*	HISOTRICO E INFORMAÇÕES
		-------------------------------------------------------------------------------------------------------------------------------- 
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------

			HISTORICO
			B19.24 de 01/11/2026 - CRIAÇÃO DESTE SCRIPT



			TIPOS DE CONTRATO
				01 - INVESTIMENTO POR PERIODO
				02 - INVESTIMENTO POR PEDIDO/EMBALAGEM
				03 - INVESTIMENTO POR PEDIDO
				04 - REPOSICAO DESCONTO FINANCEIRO
				20 - OXAN | FRETE

			QUERY UTEIS
				-- SELECT * FROM TBFATURAMENTOITENS LIMIT 10
				-- select * from tbfaturamentocontrato LIMIT 10
				-- select * from tbfaturamentocontrato_tipo
				-- select * from tbfaturamentoitenscontratos LIMIT 10
				-- SELECT * FROM TBCOMPETENCIA


	*/

	
	


	VDATA_PROCESSAMENTO_INI := (SELECT competencia_data_ini FROM tbcompetencia WHERE competencia_cd = VCOMPETENCIA_CD);
	VDATA_PROCESSAMENTO_FIM := (SELECT competencia_data_fim FROM tbcompetencia WHERE competencia_cd = VCOMPETENCIA_CD);






	UPDATE  TBFATURAMENTOITENS I
	SET     valortotalsubsidiosaplicados = COALESCE(XX.VALORINVESTIMENTO_TOTAL, 0)
		,	valortotalfaturamentoliquido = COALESCE(XX.VALORINVESTIMENTO_TOTAL, 0) + coalesce(i.valortotalfaturamentobruto ,0)
	FROM   	(
				SELECT 	I.SEQFATURAMENTOORIGEM 
					,	I.SEQFATURAMENTOITEM 
					,   c.op_cdoperacao
					,	SUM(I.VALORINVESTIMENTO_TOTAL) as VALORINVESTIMENTO_TOTAL
				FROM    	tbfaturamentoitenscontratos I
				INNER JOIN 	tbfaturamentocontrato 		 c on c.contrato_seq = i.contrato_seq 
				WHERE	1 = 1
				AND     c.contrato_data_val_ini >= VDATA_PROCESSAMENTO_INI
				AND     c.contrato_data_val_fim <= VDATA_PROCESSAMENTO_FIM
				--AND     c.contrato_seq = case when vcontrato_seq <> 0 then vcontrato_seq else c.contrato_seq end
				group by I.SEQFATURAMENTOORIGEM 
					,	I.SEQFATURAMENTOITEM 
					,   c.op_cdoperacao
			) XX 
	INNER JOIN tbfaturamentoorigem o on o.seqfaturamentoorigem = xx.seqfaturamentoorigem
	INNER JOIN tbfaturamento f on f.seqfaturamento = o.seqfaturamento
	WHERE 	XX.SEQFATURAMENTOORIGEM = O.seqfaturamentoorigem
	AND     XX.SEQFATURAMENTOORIGEM = I.SEQFATURAMENTOORIGEM
	AND 	XX.SEQFATURAMENTOITEM = I.SEQFATURAMENTOITEM
	AND     XX.OP_CDOPERACAO = F.OP_CDOPERACAO
	AND     f.datafaturamento >= VDATA_PROCESSAMENTO_INI
	AND     f.datafaturamento <= VDATA_PROCESSAMENTO_FIM
	AND     f.statusfaturamento = 1
	and     i.statusfaturamentoitem = 1
	
	;

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$



