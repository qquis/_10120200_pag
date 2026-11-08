select * from tbforca_venda_fab_meta_res_vendedor where seqinterface = 0



			Select	i.seqinterface
				,	m.fv_fab_meta_cd
				,	I.cdparticipantevendedor
				,	99
				,   count(distinct I.cdparticipantecliente)

			From		tbinterfacefaturamentoinfoitem					i	
			inner join  tbproduto							pr  on pr.pr_cdproduto = i.pr_cdproduto
			inner join  tbprodutobluesoft                   pb  on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
			inner join  tbforca_venda_fab_meta              m   on m.fv_fabricante_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante 
			WHERE		1 = 1
			and         m.fv_fab_meta_cd = 2026001
			and			i.DataFaturamento >= '2026-07-01'
			and			i.DataFaturamento <= '2027-06-30'
			group by  i.seqinterface
				,	m.fv_fab_meta_cd
				,	I.cdparticipantevendedor

select * from tbinterfacefaturamentoinfoitem 
where DataFaturamento >= '2026-07-01'
and DataFaturamento <= '2027-06-30'
				

select * from tbsistema_log