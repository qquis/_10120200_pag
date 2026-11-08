SELECT 2
		 , 0
		 , 'Record Type;Distributor Code;Invoice Number;Date;SCJ Product Code;Distributor Product Code;Product DescriptiON;Salesman Code;Salesman Name;Supervisor Code;Supervisor Name;Warehouse Code;Warehouse Name;Outlet Type Code;Outlet Type Desc;Client INTernal Code;Client Federal ID;Client Name;City;Zip Code;Delivery Adress;Qty;Gross Value;Net Value;FractiON;EAN Code'
	UNION 
	SELECT  
		2
		,	ROW_NUMBER() OVER (ORDER BY i.pr_cdproduto) 
	,
    'DIALSALES01BR;40870;'
    || COALESCE(CAST(I.SeqProcessamentoItemDocumento AS VARCHAR(20)), '') || ';'
    || COALESCE(TO_CHAR(i.DataFaturamento, 'YYYYMMDD'), '') || ';'
    || CAST(COALESCE(w.prbf_codigo_referencia, '') AS VARCHAR(20)) || ';'
    || COALESCE(CAST(o.pr_cdproduto AS VARCHAR(20)), '') || ';'
    || COALESCE(CAST(o.pr_descricao AS VARCHAR(100)), '') || ';'
    --|| COALESCE(REPLACE(CAST(RTRIM(p.ErpTargetCD_VEND) AS VARCHAR(15)), 'V', ''), '9999') || ';'
    || CAST(COALESCE(p.cdpessoabluesoft, 2046) AS VARCHAR(15)) || ';'  -- CODIGO BLUE VENDEDOR
    || COALESCE(CAST(VENDEDOR_BLUESOFT.nome_razao AS VARCHAR(50)), 'LOJA OXAN') || ';'
    || COALESCE(CAST(1 AS VARCHAR(10)), '99') || ';'
    || CAST(COALESCE('EQUIPE OXAN', '9999') AS VARCHAR(25)) || ';'
    || '00' || ';'
    || 'Main Warehouse' || ';'
    || COALESCE(CAST(COALESCE(CATEG.descricaoresumida, '2') AS VARCHAR(10)), '') || ';'
    || COALESCE(CAST(COALESCE(CATEG.descricao, 'TRADICIONAIS') AS VARCHAR(50)), '') || ';'
    -->>> ALTERAÇÃO EM 16/08 TICKET #25501
    || CAST(COALESCE(i.CdParticipanteCliente, 1) AS VARCHAR(10)) || ';'
    || COALESCE(CAST(CAST(Cliente.cpf_cnpj AS NUMERIC(14,0)) AS VARCHAR(14)), '57895328000130') || ';'
    || COALESCE(CAST(Cliente_BLUESOFT.nome_razao AS VARCHAR(40)), 'LOJA OXAN') || ';'
    || COALESCE(CAST(ENDereco.endereco_municipio AS VARCHAR(30)), 'SAO PAULO') || ';'
    || COALESCE(
           CAST(
               REPEAT('0', 8 - LENGTH(CAST(endereco.endereco_cep AS VARCHAR(8))))
               || CAST(ENDereco.endereco_cep AS VARCHAR(8))
           AS VARCHAR(8))
       , '03453000') || ';'
    || COALESCE(
           CAST(
               COALESCE(ENDereco.endereco_logradouro, 'AV. RIO DAS PEDRAS, 729')
               || ',' || CAST(COALESCE(ENDereco.endereco_numero, '') AS VARCHAR(4))
           AS VARCHAR(60))
       , '') || ';'
    || COALESCE(CAST(CAST(i.EmbalagemCompraQtde AS NUMERIC(13,2)) AS VARCHAR(15)), '') || ';'
    || COALESCE(CAST(CAST(i.ValorTotalFaturamento AS NUMERIC(13,2)) AS VARCHAR(15)), '') || ';'
    || COALESCE(CAST('00.00' AS VARCHAR(15)), '') || ';'
    || '1' || ';'
    || COALESCE(CAST(W.PRB_CDBARRA_PRINCIPAL AS VARCHAR(20)), '') || ';'
				from		tbinterfacefaturamentoinfoitem				i
				left join	tbproduto						o					on	o.pr_cdproduto	=	i.pr_cdproduto 
				left join  (
								select			p.pr_cdproduto
										,		p.pr_descricao 
										,		p.prb_cdprodutobluesoft
										,		b.prb_cdpessoabluesoft_fabricante
										,		ps.nome_razao 
										,		ps.nome_abreviado 
										,		ps.cpf_cnpj
										,		b.prb_vendaexterna 
										,		b.prb_cdproduto_compra_padrao 
										,		b.prb_cdbarra_principal 
										,		max(x.prbf_codigo_referencia) AS prbf_codigo_referencia
		
								from			tbproduto				p
								inner join		tbprodutobluesoft		b	on b.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
								inner join      tbpessoabluesoft		ps	on ps.cdpessoabluesoft = b.prb_cdpessoabluesoft_fabricante
								inner join      tbprodutobluesoft_fornecedor x on x.prb_cdprodutobluesoft = b.prb_cdproduto_compra_padrao and x.prbf_cdpessoabluesoft = ps.cdpessoabluesoft
								inner join      tbforca_venda_fabricante f  on f.fv_fabricante_cdpessoabluesoft = ps.cdpessoabluesoft 

								where			f.fv_fabricante_cdpessoabluesoft = 13752 -- PRODUTOS CERAS JOHNSON
								group by p.pr_cdproduto
										,		p.pr_descricao 
										,		p.prb_cdprodutobluesoft
										,		b.prb_cdpessoabluesoft_fabricante
										,		ps.nome_razao 
										,		ps.nome_abreviado 
										,		ps.cpf_cnpj
										,		b.prb_vendaexterna 
										,		b.prb_cdproduto_compra_padrao
										,       b.prb_cdbarra_principal 
				)							w			on	w.pr_cdproduto		=	o.pr_cdproduto 
				left join	tbparticipante				p			on	p.cdparticipante	= i.cdparticipantevendedor 
				left join   tbpessoabluesoft			vendedor_bluesoft on vendedor_bluesoft.cdpessoabluesoft = p.cdpessoabluesoft 				
				left join	tbparticipante 			cliente			 on cliente.cdparticipante = i.cdparticipantecliente 
				left join   tbpessoabluesoft			cliente_bluesoft on cliente_bluesoft.cdpessoabluesoft = cliente.cdpessoabluesoft 
				left join   tbparticipante_endereco    endereco		 on endereco.cdparticipante = cliente.cdparticipante and endereco_tipo_cd = 1
				left join   (			select		categoria.descricaoresumida, 
													categoria.descricao, 
													categoria_item.cdparticipante 
										from		tbinterfacecategoria		categoria
										inner join	tbinterfacecategoriaitem	categoria_item on categoria_item.seqinterfacecategoria = categoria.seqinterfacecategoria
										where		seqinterfacetipo = 6
										and			coalesce(categoria_item.cdparticipante,0) <> 0 
							) categ on categ.cdparticipante = cliente.cdparticipante 
				where	i.datafaturamento	>=	'2026-10-01'
				and		i.datafaturamento	<=	'2026-10-01'
				and		i.seqinterface	=	1
		ORDER BY 1 ASC


		;





















