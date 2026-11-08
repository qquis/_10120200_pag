/*
Select top 10 * from oxan_est.dbo.TbInterfaceFaturamentoInfoItem 
select top 10 * from oxan_est.dbo.TbInterfaceFaturamentoAgendamentoSimuladoInfoItem
select top 10 * from oxan_est.dbo.TbInterfaceEstoqueInfoItem
select top 10 * from oxan_est.dbo.tbinterfacearq
select top 10 * from POSTSQL.oxan.[public].tbinterfacefaturamentoinfoitem
*/

insert into POSTSQL.oxan.[public].tbinterfacefaturamentoinfoitem
	(
			dtlog_insert
		,	dtlog_update
		,	seqfaturamento
		,	seqfaturamento_origem
		,	seqinterface 
		,	seqfaturamento_old 
		,	seqfaturamento_origem_old
		,	seqitem     
		,	datafaturamento 
		,	pr_cdproduto 
		,	pr_embalagemestoque 
		,	pr_embalagemestoqueqtde                 
		,	pr_embalagemcompra 
		,	pr_embalagemcompraqtde                  
		,	cdparticipantevendedor 
		,	cdparticipantecliente 
		,	sat_ecf     
		,	cupomfiscal 
		,	numeropedido 
		,	valortotalfaturamento                   
		,	datainfoinicial 
		,	datainfofinal 
		,	seqprocessamentoitemdocumento
		,	seqprocessamentoitemdocumento_old 
		,	seqinterfacefaturamentoagendamentosimuladoinfoitem 

	)



select		
		
			GETDATE()
		,	GETDATE()
		,	0
		,	0
		,	x.SeqInterfaceInfo 
		,	isnull(x.SeqFaturamento,0)
		,	isnull(x.SeqFaturamentoOrigem,0)
		,	x.SeqItem
		,	x.DataFaturamento 
		,	x.CdProduto
		,	x.EmbalagemEstoque
		,	x.EmbalagemEstoqueQtde
		,	x.EmbalagemCompra
		,	x.EmbalagemCompraQtde
		,	CdParticipanteVendedor
		,	CdParticipanteCliente
		,	x.ECF
		,	x.CupomFiscal
		,	x.NumeroPedido
		,	x.ValorTotalFaturamento
		,	x.DataInfoInicial
		,	x.DataInfoFinal
		,	0
		,	x.SeqProcessamentoItemDocumento
		,	isnull(x.SeqInterfaceFaturamentoAgendamentoSimuladoInfoItem,0)
from		oxan_est.dbo.TbInterfaceFaturamentoInfoItem  x
where		1= 1
and         x.DataFaturamento >= '2025-08-03'
and         x.DataFaturamento <= '2025-09-02'
