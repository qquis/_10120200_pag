CREATE OR REPLACE FUNCTION public.f0070_25_1012019_faturamentocontrato_processamento
		(		vfaturamento_controle_seq integer
			, 	VCONTRATO_SEQ integer
			, 	vdata_val_ini date
			, 	vdata_val_fim date
		)
 RETURNS void
 LANGUAGE plpgsql
AS $function$

	DECLARE VDATAFATURAMENTO_INI date;
	DECLARE VDATAFATURAMENTO_FIM date;
	DECLARE VCONTRATO_TIPO_CD integer;

begin

	
	/* QUERY UTEIS
	-- SELECT * FROM TBFATURAMENTOITENS LIMIT 10
	-- select * from tbfaturamentocontrato LIMIT 10
	-- select * from tbfaturamentocontrato_tipo
	-- select * from tbfaturamentoitenscontratos LIMIT 10
	*/

	/*  TIPOS DE CONTRATO
		01 - INVESTIMENTO POR PERIODO
		02 - INVESTIMENTO POR PEDIDO/EMBALAGEM
		03 - INVESTIMENTO POR PEDIDO
		04 - REPOSICAO DESCONTO FINANCEIRO
		20 - OXAN | FRETE
	
	
	*/

	/* ATUALIZAÇÕES
	 B19.22
	 	Atualização para lançamento de investimento por período

	 B19.24 de 31/10/2023
	    Lançamento 	de investimento por pedido
	*/

	
	IF (vcontrato_seq <= 0)
	THEN 
		RETURN;
			/* Se não existir o contrato não haverá processamento. */
	END IF;


	VDATAFATURAMENTO_INI := (SELECT contrato_data_val_ini FROM tbfaturamentocontrato WHERE contrato_seq = vcontrato_seq);
	VDATAFATURAMENTO_FIM := (SELECT contrato_data_val_fim FROM tbfaturamentocontrato WHERE contrato_seq = vcontrato_seq);
	VCONTRATO_TIPO_CD := (SELECT contrato_tipo_cd FROM tbfaturamentocontrato WHERE contrato_seq = vcontrato_seq);



	/*	-------------------------------------------------------------------------------------------------------------------------------- 
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		Zerar o valor dos itens de contrato lançado que não fazem mais parte do contrato, para contratos do tipo 1,3
	
	*/
	IF (VCONTRATO_TIPO_CD IN (1,3))
	THEN 

		/*
			Produtos excluidos do contrato
		
		*/
		UPDATE  TBFATURAMENTOITENSCONTRATOS I
		SET     valorinvestimento_unit = 0
			,   valorinvestimento_total = 0
		WHERE   i.contrato_seq = VCONTRATO_SEQ
		  AND   i.pr_cdproduto NOT IN (SELECT pr_cdproduto FROM tbfaturamentocontrato_produto WHERE contrato_seq = VCONTRATO_SEQ)
		;

		/*	Contrato inativado
		
		*/
		UPDATE  TBFATURAMENTOITENSCONTRATOS I
		SET     valorinvestimento_unit = 0
			,   valorinvestimento_total = 0
		FROM    tbfaturamentocontrato_produto  cp
		inner join tbfaturamentocontrato 		c on c.contrato_seq = cp.contrato_seq
		WHERE   1 = 1
		  AND   cp.contrato_seq 	= i.contrato_seq 
		  AND   cp.pr_cdproduto 	= i.pr_cdproduto
		  AND   i.contrato_seq 		= VCONTRATO_SEQ
		  and   c.contrato_status 	= 0
		;

		UPDATE  TBFATURAMENTOITENSCONTRATOS I
		SET     valorinvestimento_unit = 0
			,   valorinvestimento_total = 0
		FROM    tbfaturamentocontrato_produto  cp
		inner join tbfaturamentocontrato 		c on c.contrato_seq = cp.contrato_seq
		WHERE   1 = 1
		  AND   cp.contrato_seq 	= i.contrato_seq 
		  AND   cp.pr_cdproduto 	= i.pr_cdproduto
		  AND   i.contrato_seq 		= VCONTRATO_SEQ
		  and   c.contrato_status 	= 0
		;


	END IF;


	/*	-------------------------------------------------------------------------------------------------------------------------------- 
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------
		Inclir novos itens


	*/

	drop table if exists TMP_tbfaturamentoitenscontratos;
	CREATE TEMPORARY TABLE TMP_tbfaturamentoitenscontratos
		(
					contrato_seq int
				,   seqfaturamentoitem int
				,   seqfaturamentoorigem int
				,   contrato_produto_seq  int
				,   pr_cdproduto int
				,   valorinvestimento_unit numeric(13,2)
				,   valorinvestimento_total numeric(13,2)
				,   faturamento_controle_seq int
		)

	;



	IF (VCONTRATO_TIPO_CD IN (1,3))
	THEN

		/*Contrato TIPO POR PERIODO*/
		insert into TMP_tbfaturamentoitenscontratos

			(
					contrato_seq 
				,   seqfaturamentoitem
				,   seqfaturamentoorigem
				,   contrato_produto_seq 
				,   pr_cdproduto
				,   valorinvestimento_unit
				,   valorinvestimento_total
				,   faturamento_controle_seq
			)

		SELECT  fp.contrato_seq	
			,   i.seqfaturamentoitem
			,   i.seqfaturamentoorigem
			,   fp.contrato_produto_seq
			,   fp.pr_cdproduto
			,   fp.valor_unitario
			,   cast( fp.valor_unitario * i.embalagemestoqueqtde  as numeric(13,2))
			,   fa.faturamento_controle_seq
		FROM 		tbfaturamentocontrato_produto fp
		inner join 	tbfaturamentocontrato  f on f.contrato_seq = fp.contrato_seq
		inner join 	tbfaturamentoitens     i on i.pr_cdproduto = fp.pr_cdproduto
		inner join  tbfaturamentoorigem    o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
		inner join  tbfaturamento          fa on fa.seqfaturamento = o.seqfaturamento
		WHERE   fp.contrato_seq = VCONTRATO_SEQ
		  and   f.contrato_tipo_cd = 1
		  and   fa.op_cdoperacao = f.op_cdoperacao
		  and   fa.statusfaturamento = 1
		  and   i.statusfaturamentoitem = 1
		  and   fa.datafaturamento >= VDATAFATURAMENTO_INI
		  and   fa.datafaturamento <= VDATAFATURAMENTO_FIM
	  
		  ;
		
		/*Contrato TIPO POR PEDIDO*/
		insert into TMP_tbfaturamentoitenscontratos

			(
					contrato_seq 
				,   seqfaturamentoitem
				,   seqfaturamentoorigem
				,   contrato_produto_seq 
				,   pr_cdproduto
				,   valorinvestimento_unit
				,   valorinvestimento_total
				,   faturamento_controle_seq				
			)

		SELECT  fp.contrato_seq	
			,   i.seqfaturamentoitem
			,   i.seqfaturamentoorigem
			,   fp.contrato_produto_seq
			,   fp.pr_cdproduto
			,   fp.valor_unitario
			,   cast( fp.valor_unitario  as numeric(13,2))
			,   fa.faturamento_controle_seq
		FROM 		tbfaturamentocontrato_produto fp
		inner join 	tbfaturamentocontrato  f on f.contrato_seq = fp.contrato_seq
		inner join 	tbfaturamentoitens     i on i.pr_cdproduto = fp.pr_cdproduto
		inner join  tbfaturamentoorigem    o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
		inner join  tbfaturamento          fa on fa.seqfaturamento = o.seqfaturamento
		inner join  tbfaturamento_controle c on c.faturamento_controle_seq = fa.faturamento_controle_seq
		WHERE   fp.contrato_seq = VCONTRATO_SEQ
		  and   f.contrato_tipo_cd = 3
		  and   fa.op_cdoperacao = f.op_cdoperacao
		  and   fa.statusfaturamento = 1
		  and   i.statusfaturamentoitem = 1
		  and   c.faturamento_controle_seq = f.faturamento_controle_seq --- Definição de contrato por pedido


	;


	INSERT INTO tbfaturamentoitenscontratos
			(
					contrato_seq 
				,   seqfaturamentoitem
				,   seqfaturamentoorigem
				,   contrato_produto_seq 
				,   pr_cdproduto
				,   valorinvestimento_unit
				,   valorinvestimento_total
			)
	 		
		SELECT  a.contrato_seq	
			,   a.seqfaturamentoitem
			,   a.seqfaturamentoorigem
			,   a.contrato_produto_seq
			,   a.pr_cdproduto
			,   a.valorinvestimento_unit
			,   a.valorinvestimento_total
		FROM    TMP_tbfaturamentoitenscontratos a

		WHERE   1 = 1 
		AND     NOT EXISTS( SELECT 1 
							FROM   tbfaturamentoitenscontratos b
							WHERE  b.contrato_seq = a.contrato_seq
							AND    b.seqfaturamentoitem = a.seqfaturamentoitem
							AND    b.seqfaturamentoorigem = a.seqfaturamentoorigem
							AND    b.contrato_produto_seq = a.contrato_produto_seq
							and    b.pr_cdproduto = a.pr_cdproduto
							
							)



	;


	UPDATE tbfaturamentoitenscontratos a
	  SET  valorinvestimento_unit = b.valorinvestimento_unit
	    ,  valorinvestimento_total = b.valorinvestimento_total
		,  dtlog_update = current_timestamp
      FROM TMP_tbfaturamentoitenscontratos B
	  WHERE  b.contrato_seq = a.contrato_seq
		AND    b.seqfaturamentoitem = a.seqfaturamentoitem
		AND    b.seqfaturamentoorigem = a.seqfaturamentoorigem
		AND    b.contrato_produto_seq = a.contrato_produto_seq
		and    b.pr_cdproduto = a.pr_cdproduto
	
	
	;




	drop table if exists TMP_tbfaturamentoitenscontratos;

	
	END IF;




	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$


/*

            SELECT * FROM f0070_25_1012019_faturamentocontrato_processamento 
            (
                    vfaturamento_controle_seq:= 0
                ,       vcontrato_seq:= 6825
                ,       vdata_val_ini:= '2026-10-01' 
                ,       vdata_val_fim:= '2026-10-31'
            
            )
*/			


--SELECT * FROM TMP_tbfaturamentoitenscontratos