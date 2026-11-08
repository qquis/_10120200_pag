/*
  select * from POSTSQL.oxan.[public].tbforca_venda_fabricante


select		
			x.CdFabricante
		,	f.fv_fabricante_descricao 
		,	b.cdparticipante 
from		oxan_adm.dbo.tbcontrato	c
inner join	oxan_adm.dbo.TbContratoComercial x on x.seqcontrato = c.SeqContrato
left  join	POSTSQL.oxan.[public].tbfaturamento_controle a on a.numeropedido = x.NumeroPedido and a.op_cdoperacao = 1
left join   POSTSQL.oxan.[public].tbforca_venda_fabricante f on f.fv_fabricante_referencia = x.CdFabricante 
left join   POSTSQL.oxan.[public].tbparticipante_bluesoft b on b.cdpessoabluesoft = f.fv_fabricante_cdpessoabluesoft 
where		1 = 1
  and       c.DataInicio >= '2025-01-01'
group by x.CdFabricante
		,	f.fv_fabricante_descricao 
		,	b.cdparticipante 

*/


--select * from oxan_adm.dbo.TbContratoComercial
--select * from oxan_adm.dbo.tbfabricante

--POSTSQL.oxan.[public].tbfaturamentoitenscontratos_integ 
--delete  from POSTSQL.oxan.[public].tbfaturamentoitenscontratos_integ

insert into POSTSQL.oxan.[public].tbfaturamentoitenscontratos_integ 
	(
			seqfaturamentoorigem
		,	seqfaturamentoitenscontrato
		,	contratoitem_seq 
		,	seqfaturamento
		,	datafaturamento

		,	pr_cdproduto
		,	pr_embalagemestoque
		,	pre_fatorestoque

		,	embalagemestoqueqtde
		,	contratoitem_prb_embalagem
		,	pre_embalagemfaturamento 
		,	contratoitem_valorinvestimento_unitario 


		,	valorinvestimentototal
	)

SELECT		x.seqfaturamentoorigem
		,	x.SeqFaturamentoItensContratos
		,	x.SeqContratoItem
		,	f.SeqFaturamento
		,   f.DataFaturamento

		,	x.CdProduto
		,	pr.pr_embalagemestoque
		,	1

		,	x.EmbalagemEstoqueQtde
		,	x.EmbalagemFaturamento
		,	x.EmbalagemFaturamento
		,	x.ValorInvestimentoUnitario
		
		,	x.ValorInvestimentoTotal 
FROM		OXAN_EST.DBO.TbFaturamentoItensContratos	x
inner join  POSTSQL.oxan.[public].tbproduto				pr on pr.pr_cdproduto = x.CdProduto
inner join  OXAN_EST.DBO.TbFaturamentoOrigem O on o.SeqFaturamentoOrigem = x.SeqFaturamentoOrigem
inner join  OXAN_EST.DBO.TbFaturamento f on f.SeqFaturamento = o.SeqFaturamento 
where		1 = 1
and			f.DataFaturamento >= '2025-08-02'
and			f.DataFaturamento <= '2025-10-31'
and			not exists (	select 1 
							from	POSTSQL.oxan.[public].tbfaturamentoitenscontratos_integ  xx
							where   1 = 1
							and     xx.seqfaturamentoorigem = x.seqfaturamentoorigem
							and     xx.seqfaturamentoitenscontrato = x.SeqFaturamentoItensContratos
							and     xx.contratoitem_seq = x.SeqContratoItem
							and     xx.pr_cdproduto = x.CdProduto
							)




insert into POSTSQL.oxan.[public].tbfaturamentocontrato
			(
					contrato_seq_old
				,	contrato_descricao  
				,	contrato_data 
				,	contrato_data_val_ini
				,	contrato_data_val_fim
				,	op_cdoperacao 
				,	cdparticipante_contratante 
				,	contrato_tipo_cd 
				,	faturamento_controle_seq 
				
			)

select		c.SeqContrato 
		,	C.Descricao
		,	c.DataLancamento
		,	c.DataInicio
		,	c.DataFim
		,	1
		,	coalesce(b.cdparticipante,0) as cdparticipante
		,	case isnull(c.CdTipoContrato, '') 
				when 'IV_IT' then 1 
				when '' then 3
			end as contrato_tipo_cd
		,	coalesce(a.faturamento_controle_seq ,0) as faturamento_controle_seq
from		oxan_adm.dbo.tbcontrato	c
inner join	oxan_adm.dbo.TbContratoComercial x on x.seqcontrato = c.SeqContrato
left  join	POSTSQL.oxan.[public].tbfaturamento_controle a on a.numeropedido = x.NumeroPedido and a.op_cdoperacao = 1
left join   POSTSQL.oxan.[public].tbforca_venda_fabricante f on f.fv_fabricante_referencia = x.CdFabricante 
left join   POSTSQL.oxan.[public].tbparticipante_bluesoft b on b.cdpessoabluesoft = f.fv_fabricante_cdpessoabluesoft 
where		1 = 1
  and       c.DataInicio >= '2025-07-01'
  and       not exists (select 1
                        from POSTSQL.oxan.[public].tbfaturamentocontrato xx
						where 1 = 1
						and   xx.contrato_seq_old = c.SeqContrato 
						)


insert into POSTSQL.oxan.[public].tbfaturamentocontrato_produto 
	(
			contrato_Seq 
		,	contrato_produto_seq_old 
		,	pr_cdproduto 
		,	prb_cdprodutobluesoft 
		,	valor_unitario 
	)
select		aa.contrato_seq 
		,	i.SeqContratoItem
		,	i.CdProduto 
		,	p.prb_cdprodutobluesoft 
		,	i.ValorInvestimento
from	oxan_adm.dbo.TbContratoItem i
inner join  oxan_adm.dbo.tbcontrato	c			on c.SeqContrato = i.SeqContrato 
inner join	oxan_adm.dbo.TbContratoComercial x	on x.seqcontrato = c.SeqContrato
inner join  POSTSQL.oxan.[public].tbproduto p on p.pr_cdproduto = i.CdProduto 
inner join  POSTSQL.oxan.[public].tbfaturamentocontrato aa on isnull(contrato_seq_old,0) = x.SeqContrato 
where		1 = 1
  and       c.DataInicio >= '2025-07-01'
  and       not exists( select 1 
						from  POSTSQL.oxan.[public].tbfaturamentocontrato_produto  xx
						where xx.contrato_produto_seq_old = i.SeqContratoItem
						  and xx.pr_cdproduto = i.CdProduto
					)
	







