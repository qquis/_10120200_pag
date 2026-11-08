





				WITH params AS (
    SELECT DATE '2026-10-01' AS dt_ini
         , DATE '2026-10-31' AS dt_fim
),
dias AS (
    SELECT d::DATE AS data
    FROM   params
    CROSS JOIN LATERAL generate_series(dt_ini, LEAST(dt_fim, dt_ini + 30), INTERVAL '1 day') AS d
),
produtos AS (
    SELECT  p.pr_cdproduto
          , p.pr_descricao
          , p.prb_cdprodutobluesoft
          , b.prb_cdpessoabluesoft_fabricante
          , ps.nome_razao
          , ps.nome_abreviado
          , ps.cpf_cnpj
          , b.prb_vendaexterna
          , b.prb_cdproduto_compra_padrao
          , x.prbf_codigo_referencia
          , bx.prb_cdbarra_principal
          , bx.prb_descricao AS prb_descricao_compra
          , p.pr_embalagemcompra_fator as pr_embalagemcompra_fator
    FROM        tbproduto p
    INNER JOIN  tbprodutobluesoft b   ON b.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft
    INNER JOIN  tbpessoabluesoft  ps  ON ps.cdpessoabluesoft = b.prb_cdpessoabluesoft_fabricante
    INNER JOIN  tbprodutobluesoft_fornecedor x
                                      ON x.prb_cdprodutobluesoft = b.prb_cdproduto_compra_padrao
                                     AND x.prbf_cdpessoabluesoft = ps.cdpessoabluesoft
    INNER JOIN  tbprodutobluesoft bx  ON bx.prb_cdprodutobluesoft_pk = b.prb_cdproduto_compra_padrao
    INNER JOIN  tbforca_venda_fabricante f ON f.fv_fabricante_cdpessoabluesoft = ps.cdpessoabluesoft
    WHERE f.fv_fabricante_cdpessoabluesoft = 13752 -- PRODUTOS CERAS JOHNSON
)
SELECT  



       ROW_NUMBER() OVER (ORDER BY pr.pr_cdproduto)
      , 'DIALSTOCK01BR'                                                                    || ';' ||  -- RecordType
        '40870'                                                                            || ';' ||  -- [DistributGO]
        COALESCE(TO_CHAR( dd.data, 'YYYYMMDD'), '')                                   || ';' ||  -- [DATE]
        COALESCE(LEFT(COALESCE(pr.prbf_codigo_referencia::TEXT, ''), 20), '')                       || ';' ||  -- [SCJ Produ]
        COALESCE(LEFT(pr.pr_cdproduto::TEXT, 10), '')                                          || ';' ||  -- [Distribut]
        COALESCE(LEFT(pr.pr_descricao, 40), '')                                                || ';' ||  -- [Distribut]
        COALESCE(LEFT(ROUND(GREATEST(es.ecdb_embalagemestoque_qtde / pr.pr_embalagemcompra_fator, 0)::NUMERIC, 2)::TEXT, 10), '') || ';' ||  -- [Qty]
        '00'                                                                               || ';' ||  -- [WareHouse]
        'Main Warehouse'                                                                   || ';' ||  -- [Warehouse]
        '1'                                                                                || ';' ||  -- [fraction]
        COALESCE(LEFT(pr.prb_cdbarra_principal::TEXT, 20), '')                                           || ';' ||  -- [Ean Code]
        ''                                                                                 || ';' ||  -- [Sales Qty]
        ''                                                                                 || ';' ||  -- [ExDO]
        ''                                                                                 || ';' ||  -- [BONus Sam]
        ''      
FROM        produtos pr
CROSS JOIN  dias dd
LEFT JOIN   tbestoquecusto_diariobluesoft es
       ON   es.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
      AND   es.ecdb_data::DATE = dd.data

union 
select 0 ,'Record Type;Distributor Code;Date;SCJ Product Code;Distributor Product Code;Distributor Product DescriptiON;Qty;Warehouse Code;Warehouse Name;FractiON;EAN Code;Sales Qty;ExDO;BONus Sample;Others'


ORDER BY    1

select * from tbproduto



/*
SELECT @SeqArquivoHistorico , 0 ,'Record Type;Distributor Code;Date;SCJ Product Code;Distributor Product Code;Distributor Product DescriptiON;Qty;Warehouse Code;Warehouse Name;FractiON;EAN Code;Sales Qty;ExDO;BONus Sample;Others'
						UNION
						SELECT				@SeqArquivoHistorico 
									,		ROW_NUMBER() OVER (ORDER BY I.CDPRODUTO )		
									,		'DIALSTOCK01BR'																														+';'+	--RecordType
											'40870'																																+';'+	--[DistributGO
											ISNULL(CONVERT(CHAR(8)    ,i.DataEstoque ,112),'')																					+';'+	--[DATE]
											ISNULL(CONVERT(VARCHAR(20),ISNULL(o.cd_prod_fabric,'')),'')																			+';'+   --[SCJ Produ
											ISNULL(CONVERT(VARCHAR(10),i.cdProduto ),'')																						+';'+	--[Distribut
											ISNULL(CONVERT(VARCHAR(40),o.descricao),'')																							+';'+	--[Distribut
											ISNULL(CONVERT(VARCHAR(10),CONVERT(NUMERIC(13,2),CASE WHEN i.EmbalagemCompraQtde < 0 THEN 0 ELSE i.EmbalagemCompraQtde END )),'')	+';'+	--[Qty]
											'00'																																+';'+	--[WareHouse
											'Main Warehouse'																													+';'+	--[Warehouse
											'1'																																	+';'+   --[fractiON]
											ISNULL(CONVERT(VARCHAR(20),c.cd_barra),'')																							+';'+	--[Ean Code]
											''																																	+';'+	--[Sales Qty
											''																																	+';'+	--[ExDO]
											''																																	+';'+	--[BONus Sam
											''																																			--[Others]

				FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem	i
				INNER JOIN	srv01.moinho.dbo.produto				o ON o.cd_prod = i.CdProduto
				LEFT JOIN   srv01.moinho.dbo.cd_barra_unprd			c ON c.cd_prod = o.cd_prod 
																				and  c.unid_vda		=	o.unid_cmp 
																				and  c.seq			=	1 
																				and  c.tp_cd_barra	in	('EAN13','DUN14')

				WHERE		i.DataEstoque					>=	@Data
				and			i.DataEstoque					<=	@DataFim
				and			i.SeqINTerfaceInfo				=	@INTerface
				and			ISNULL(o.cd_prod_fabric,'')		!=  ''*/
*/