


insert into tbinterfacefaturamentoinfoitem 
		(   ifaturamentoinfoitem_seq_old
              , seqinterface
			  , seqfaturamento
			  , seqfaturamentoorigem
			  , seqfaturamento_old
			  , seqfaturamentoorigem_old
			  , cdoperacao 
			  , seqinterfacefaturamentoagendamentosimuladoinfoitem
			  , cdparticipantecliente
			  , cdparticipantevendedor 
			  , sat_ecf
			  , cupomfiscal
			  , numeropedido 
			  , datafaturamento
			  , pr_cdproduto
			  , embalagemestoque
			  , embalagemestoqueqtde
			  , embalagemcompra
			  , embalagemcompraqtde 
			  , valortotalfaturamento
			  , datainfoinicial
			  , datainfofinal
			  , seqprocessamentoitemdocumento
			  , seqprocessamentoitemdocumento_old 
			  )
select 	    i.ifaturamentoinfoitem_seq_old 
		,   i.seqinterface
		,	COALESCE(x.seqfaturamento,0) as seqfaturamento
		,	COALESCE(x.seqfaturamentoorigem,0) as seqfaturamentoorigem
		,	i.seqfaturamento_old
		,	i.seqfaturamentoorigem_old 
		,   i.cdoperacao 
		,	i.seqinterfacefaturamentoagendamentosimuladoinfoitem 
		,   i.cdparticipantecliente
		,   i.cdparticipantevendedor 
		,   I.sat_ecf
		,   I.cupomfiscal
		,   I.numeropedido 
		,   I.datafaturamento
		,   I.pr_cdproduto
		,   I.embalagemestoque
		,   I.embalagemestoqueqtde
		,   I.embalagemcompra
		,   I.embalagemcompraqtde 
		,   I.valortotalfaturamento
		,   I.datainfoinicial
		,   I.datainfofinal
		,   I.seqprocessamentoitemdocumento
		,   I.seqprocessamentoitemdocumento_old 
from   		mgtbinterfacefaturamentoinfoitem i
left join 	tbfaturamento_controle x 
				on x.seqfaturamento_old = i.seqfaturamento_old
				and x.seqfaturamento_origem_old = i.seqfaturamentoorigem_old
				and x.fat_controle_tipo_cd = 1 -- TIPO VENDA 
WHERE NOT EXISTS (
	SELECT 1 
	FROM tbinterfacefaturamentoinfoitem aa 
	where aa.seqprocessamentoitemdocumento = i.seqprocessamentoitemdocumento
	  and aa.pr_cdproduto = i.pr_cdproduto 
	  and aa.datafaturamento = i.datafaturamento
	  and aa.cdparticipantecliente = i.cdparticipantecliente 


)


