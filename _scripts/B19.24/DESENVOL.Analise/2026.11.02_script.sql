
select i.*
from tbfaturamentoitens i
inner join tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem 
inner join tbfaturamento f on f.seqfaturamento = o.seqfaturamento
where 1 = 1
and   f.datafaturamento >= '2026-10-01'
and   f.datafaturamento <= '2026-10-31'
and   f.op_cdoperacao  = 1 
limit 10



update      tbfaturamentoitens i
     set    valortotalfaturamentoliquido = i.valortotalfaturamentobruto + coalesce(i.valortotalsubsidiosaplicados,0)
from tbfaturamentoorigem o 
inner join tbfaturamento f on f.seqfaturamento = o.seqfaturamento
where 1 = 1
and   o.seqfaturamentoorigem = i.seqfaturamentoorigem 
and   f.datafaturamento >= '2026-10-01'
and   f.datafaturamento <= '2026-10-31'
and   f.op_cdoperacao  = 1 
limit 10