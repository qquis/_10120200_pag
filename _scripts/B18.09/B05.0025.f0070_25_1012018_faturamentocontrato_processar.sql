

CREATE OR REPLACE 
-- drop 
FUNCTION public.f0070_25_1012018_faturamentocontrato_processar(
	vfaturamento_controle_seq integer,
	vcontrato_seq integer,
	vdata_val_ini date,
	vdata_val_fim date)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
 declare  valor_total_a_ratear 		numeric(13,2);
 declare  valor_total_diferenca_rateio numeric(13,2);
 declare  valor_total_faturamento 		numeric(13,2);
begin

	--SELECT * FROM TBFATURAMENTOITENS LIMIT 10
	-- select * from tbfaturamentocontrato
	-- select * from tbfaturamentocontrato_tipo
	-- select * from tbfaturamentoitenscontratos

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
$BODY$;
