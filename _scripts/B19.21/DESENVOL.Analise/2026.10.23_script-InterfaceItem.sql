select  
            i.seqinterface
    ,       i.datafaturamento 
    ,       i.cdoperacao 
    ,       i.seqfaturamento
    ,       i.seqfaturamentoorigem
    ,       i.sat_ecf
    ,       i.cupomfiscal
    ,       i.numeropedido
    ,       i.pr_cdproduto 
    ,       i.embalagemestoque
    ,       i.embalagemestoqueqtde 
    ,       i.embalagemcompra 
    ,       i.embalagemcompraqtde 
    ,       i.cdparticipantecliente 
    ,       c.nome_razao 
    ,       g.cdgrupoeconomico 
    ,       g.descricao 
    ,       i.cdparticipantevendedor
    ,       i.seqprocessamentoitemdocumento
    ,       i.valortotalfaturamento
from        tbinterfacefaturamentoinfoitem i
left join   tbparticipante_bluesoft c on c.cdparticipante = i.cdparticipantecliente
left join   tbgrupoeconomico        g on g.cdgrupoeconomico = c.cdgrupoeconomico

where       1 = 1
and         i.datafaturamento >= '2026-07-01'
and         i.datafaturamento <= '2026-07-15'