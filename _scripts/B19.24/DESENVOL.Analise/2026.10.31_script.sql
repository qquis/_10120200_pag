update tbfaturamentoitens i
set     valortotalsubsidiosaplicados = 0, valortotalfaturamentoliquido = 0 
from       tbfaturamentoorigem o
inner join tbfaturamento f on f.seqfaturamento = o.seqfaturamento
where  1 = 1 
and    f.datafaturamento >= '2026-09-01' 
and    f.datafaturamento <= '2026-09-30'
and    o.seqfaturamentoorigem = i.seqfaturamentoorigem
and    i.valortotalsubsidiosaplicados <> 0
and    f.op_cdoperacao in (1,4)





SELECT TO_CHAR(contrato_data_val_ini, 'YYYYMM'), EXTRACT(MONTH FROM contrato_data_val_ini), EXTRACT(MONTH FROM contrato_data_val_fim) 
FROM TBfaturamentoCONTRATO 
where EXTRACT(MONTH FROM contrato_data_val_ini) = EXTRACT(MONTH FROM contrato_data_val_fim)