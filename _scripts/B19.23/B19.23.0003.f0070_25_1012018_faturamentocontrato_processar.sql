CREATE OR REPLACE FUNCTION public.f0070_25_1012018_faturamentocontrato_processar(vfaturamento_controle_seq integer, vcontrato_seq integer, vdata_val_ini date, vdata_val_fim date)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
begin

	--SELECT * FROM TBFATURAMENTOITENS LIMIT 10
	-- select * from tbfaturamentocontrato
	-- select * from tbfaturamentocontrato_tipo
	-- select * from tbfaturamentoitenscontratos LIMIT 10


	/* ATUALIZANDO BASE DE DADOS DE CONTRATO DO TIPO INVESTIMENTO POR PERIODO */


	if (vcontrato_seq > 0 or (vdata_val_ini != '1900-01-01' and vdata_val_fim != '1900-01-01') ) 
	then
    
		DELETE FROM TBFATURAMENTOITENSCONTRATOS X
		WHERE EXISTS (
			SELECT 1
			FROM   tbfaturamentocontrato_produto i 
			inner join tbfaturamentocontrato     f on f.contrato_seq = i.contrato_seq
			WHERE F.CONTRATO_SEQ = X.CONTRATO_SEQ
			and f.contrato_tipo_cd in (1,3)
			and f.contrato_data_val_ini >= case when vdata_val_ini != '1900-01-01' then vdata_val_ini else f.contrato_data_val_ini end
			and f.contrato_data_val_fim <= case when vdata_val_fim != '1900-01-01' then vdata_val_fim else f.contrato_data_val_fim end
			and f.contrato_seq = case when vcontrato_seq > 0 then vcontrato_seq else f.contrato_seq end
			and i.pr_cdproduto = x.pr_cdproduto

		)
		;



		insert into tbfaturamentoitenscontratos

			(
					contrato_seq 
				,   seqfaturamentoitem
				,   seqfaturamentoorigem
				,   contrato_produto_seq 
				,   pr_cdproduto
				,   valorinvestimento_unit
				,   valorinvestimento_total
			)

		SELECT  fp.contrato_seq	
			,   i.seqfaturamentoitem
			,   i.seqfaturamentoorigem
			,   fp.contrato_produto_seq
			,   fp.pr_cdproduto
			,   fp.valor_unitario
			,   cast( fp.valor_unitario * i.embalagemestoqueqtde  as numeric(13,2))
		FROM 		tbfaturamentocontrato_produto fp
		inner join 	tbfaturamentocontrato  f on f.contrato_seq = fp.contrato_seq
		inner join 	tbfaturamentoitens     i on i.pr_cdproduto = fp.pr_cdproduto
		inner join  tbfaturamentoorigem    o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
		inner join  tbfaturamento          fa on fa.seqfaturamento = o.seqfaturamento
		WHERE   fp.contrato_seq = vcontrato_seq
		  and f.contrato_tipo_cd in (1,3)
		  and f.contrato_data_val_ini >= case when vdata_val_ini != '1900-01-01' then vdata_val_ini else f.contrato_data_val_ini end
		  and f.contrato_data_val_fim <= case when vdata_val_fim != '1900-01-01' then vdata_val_fim else f.contrato_data_val_fim end
		  and f.contrato_seq = case when vcontrato_seq > 0 then vcontrato_seq else f.contrato_seq end
		  and   fa.op_cdoperacao = f.op_cdoperacao
		  and   fa.statusfaturamento = 1
		  and   i.statusfaturamentoitem = 1

			;

	end if;


	UPDATE TBFATURAMENTOITENS I
	SET     valortotalsubsidiosaplicados = XX.VALORINVESTIMENTO_TOTAL
		,	valortotalfaturamentoliquido = XX.VALORINVESTIMENTO_TOTAL + coalesce(i.valortotalfaturamentobruto ,0) 
	FROM   	(
				SELECT 	I.SEQFATURAMENTOORIGEM 
					,	I.SEQFATURAMENTOITEM 
					,	SUM(I.VALORINVESTIMENTO_TOTAL) as VALORINVESTIMENTO_TOTAL
				FROM    	tbfaturamentoitenscontratos I
				INNER JOIN 	tbfaturamentocontrato 		 c on c.contrato_seq = i.contrato_seq 
				WHERE	1 = 1
				AND     c.contrato_data_val_ini >= case when vdata_val_ini != '1900-01-01' then vdata_val_ini else c.contrato_data_val_ini end
				AND     c.contrato_data_val_fim <= case when vdata_val_ini != '1900-01-01' then vdata_val_fim else c.contrato_data_val_ini end
				AND     c.faturamento_controle_seq = case when vfaturamento_controle_seq <> 0 then vfaturamento_controle_seq else c.faturamento_controle_seq end
				group by I.SEQFATURAMENTOORIGEM 
					,	I.SEQFATURAMENTOITEM 
			) XX 
	WHERE XX.SEQFATURAMENTOORIGEM = I.SEQFATURAMENTOORIGEM
	AND XX.SEQFATURAMENTOITEM = I.SEQFATURAMENTOITEM
	
	;

	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$

