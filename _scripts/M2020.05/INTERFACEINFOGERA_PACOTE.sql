USE [DBAMAIN]
GO

/****** Object:  StoredProcedure [dbo].[UspINTerfaceInfoGeracaoPacotes]    Script Date: 03/10/2026 14:16:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









---select * from OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico where DataGeracao = '2023-03-18'


---EXEC DBAMAIN.DBO.UspINTerfaceInfoGeracaoPacotes '2023-08-21', 5


ALTER PROC	[dbo].[UspINTerfaceInfoGeracaoPacotes]
	(
				@DataGeracao				SMALLDATETIME		=		NULL
			,	@seqinterfaceinfo			smallint  = 0 
	)
AS

SET NOCOUNT ON
--DECLARE @DataGeracao			SMALLDATETIME		=		NULL
DECLARE	@Arquivo				VARCHAR(15)
DECLARE	@Interface				INT
DECLARE @SeqArquivoHistorico	INT
DECLARE @SeqTipoArquivo			INT
DECLARE	@Data					SMALLDATETIME
DECLARE	@DataFim				SMALLDATETIME
DECLARE	@i						INT
DECLARE @icount					INT


IF		@DataGeracao is NULL
BEGIN
	SELECT	@DataGeracao = CONVERT(VARCHAR(8), GETDATE()-1, 112)
END


---- INSERE NOVOS REGISTROS DE ARQUIVOS PARA GERACAO -------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

IF OBJECT_ID('TempDb.Dbo.#TbArquivo') is not null drop table #TbArquivo

SELECT		SEQTIPOARQUIVO		=	x.SEQTIPOARQUIVO 
		,	DESCRICAO			=	x.DESCRICAOTIPOARQUIVO 
		,	PathPadrao			=	x.PathPadrao 
		,	LINHA				=	ROW_NUMBER() OVER (ORDER BY x.SEQTIPOARQUIVO)
INTO		#TbArquivo	
FROM		OXAN_EST.dbo.TbINTerfaceInfoArquivo x
where		1 = 1
and			SeqInterfaceInfo = (case when @seqinterfaceinfo <> 0 then @seqinterfaceinfo else x.seqinterfaceinfo end)

-- SELECT * FROM OXAN_EST.dbo.TbINTerfaceInfoArquivo


DECLARE @DataHoje SMALLDATETIME = CONVERT(SMALLDATETIME, CONVERT(CHAR(8), @DataGeracao , 112) )

DECLARE @PATH_DIRETORIO_ANO VARCHAR(4) = (SELECT LTRIM(RTRIM(CONVERT(VARCHAR(4), YEAR(@DataHoje)))))
DECLARE @PATH_DIRETORIO_MES VARCHAR(2) = (SELECT REPLICATE('0', 2- LEN(LTRIM(RTRIM(CONVERT(VARCHAR(2), MONTH(@DataHoje)))))) + LTRIM(RTRIM(CONVERT(VARCHAR(2), MONTH(@DataHoje)))) )
DECLARE @PATH_DIRETORIO_DIA VARCHAR(2) = (SELECT REPLICATE('0', 2- LEN(LTRIM(RTRIM(CONVERT(VARCHAR(2), DAY(@DataHoje)))))) + LTRIM(RTRIM(CONVERT(VARCHAR(2), DAY(@DataHoje)))) )
DECLARE @PATH_DIRETORIO VARCHAR(50) = @PATH_DIRETORIO_ANO + '\' + @PATH_DIRETORIO_MES + '\' + @PATH_DIRETORIO_DIA
DECLARE @REGISTROS							INT = ( SELECT COUNT(*) from #TbArquivo)
DECLARE @LINHA								INT = 1
DECLARE @SeqTipoArquivo_EmProcessamento		INT 
DECLARE @DESCRICAO							VARCHAR(15)
DECLARE @PathPadrao							VARCHAR(50)

WHILE   @LINHA <= @REGISTROS 
BEGIN
	--SELECT * FROM #TBARQUIVO WHERE LINHA = @LINHA 
	
	SELECT		@SeqTipoArquivo_EmProcessamento =	SEQTIPOARQUIVO 
			,	@DESCRICAO						=	DESCRICAO
			,	@PathPadrao						=	PathPadrao 
	FROM		#TBARQUIVO 
	WHERE LINHA = @LINHA 
	
	
	if (	select	count(*) 
			from	OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
			where   seqtipoarquivo = @SeqTipoArquivo_EmProcessamento
			and		datageracao = @datahoje 
		) < 1
	begin 
		
		/* JOHNSON - ARQUIVOS */
		IF @SeqTipoArquivo_EmProcessamento = 1 and datepart(DW,@datahoje) = 1 
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'DIALCLIENT01BR_' + CONVERT(CHAR(8), @DATAHOJE - 7, 112) + '-' + CONVERT(CHAR(8), @DATAHOJE - 1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 7
								,	@DATAHOJE - 1
								)
		end

		
		if @SeqTipoArquivo_EmProcessamento = 2 and datepart(dw,@datahoje) = 1 
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'DIALSALES01BR_' + CONVERT(CHAR(8), @DATAHOJE - 7, 112) + '-' + CONVERT(CHAR(8), @DATAHOJE - 1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 7
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 3 and datepart(DW,@datahoje) = 1 
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'DIALSTOCK01BR_' + CONVERT(CHAR(8), @DATAHOJE - 7, 112) + '-' + CONVERT(CHAR(8), @DATAHOJE - 1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 7
								,	@DATAHOJE - 1
								)
		end
	
	/* MELITTA - ARQUIVOS */
		if @SeqTipoArquivo_EmProcessamento = 4
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'CLIENTEOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end
	
		if @SeqTipoArquivo_EmProcessamento = 5
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'FORCAVENDAOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 6
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'ESTOQUEOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 7
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'PRODUTOOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 8
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'VENDAOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 14
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'CLIENTEOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end
	
		if @SeqTipoArquivo_EmProcessamento = 15
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'FORCAVENDAOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 16
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'ESTOQUEOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 17
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'PRODUTOOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end

		if @SeqTipoArquivo_EmProcessamento = 18
		begin 
			INSERT INTO OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico
						(		SeqTipoArquivo 
							,	DataGeracao 
							,	NomeArquivo 
							,	PathArquivo 
							,	Data 
							,	DataFim 
						)
						VALUES (	@SeqTipoArquivo_EmProcessamento
								,	@datahoje 
								,	'VENDAOXAN' + CONVERT(CHAR(8), @DATAHOJE -1, 112) + '.txt'
								,   @PathPadrao + @PATH_DIRETORIO
								,	@DATAHOJE - 1
								,	@DATAHOJE - 1
								)
		end
	end
	SELECT @LINHA = @LINHA + 1
END



------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------


IF OBJECT_ID('TEMPDB.DBO.#ListaDeGeracao')		IS NOT NULL DROP TABLE #ListaDeGeracao
				SELECT		ROW_NUMBER() OVER(ORDER BY a.DescricaoTipoArquivo) AS Seq
						,	a.SeqINTerfaceInfo
						,	a.DescricaoTipoArquivo
						,	h.DataGeracao
						,	h.Data
						,	h.DataFim
						,	H.SeqTipoArquivo
						,	H.SeqArquivoHistorico 
				INTo	#ListaDeGeracao		
				FROM		OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico	h
				INNER JOIN	OXAN_EST.dbo.TbINTerfaceInfoArquivo				a ON a.SeqTipoArquivo = h.SeqTipoArquivo
				WHERE		h.DataGeracao = @DataGeracao



	if OBJECT_ID('tempdb.dbo.#base_melitta_clientes') is not null drop table #base_melitta_clientes
	create table #base_melitta_clientes
		(
			cdparticipante int 
		)

	if OBJECT_ID('tempdb.dbo.#base_cliente_sinter') is not null drop table #base_cliente_sinter

	create table #base_cliente_sinter
		(
			cdparticipante int 
		)

--- CLIENTES PARA A BASE MTRIX MELITTA E SINTER 
if (@seqinterfaceinfo in(0,2)) 
begin
	INSERT INTO		#base_melitta_clientes

	
	select			qa.cdparticipantecliente 
	--into			#base_melitta_clientes
	from			oxan_est.dbo.TbInterfaceFaturamentoInfoItem qa
	INNER JOIN		postsql.oxan.[public].tbparticipante		t	on t.cdparticipante = qa.CdParticipanteCliente 
	INNER JOIN		postsql.oxan.[public].tbgrupoeconomico 		g   on g.cdgrupoeconomico = t.cdgrupoeconomico
	where	qa.SeqInterfaceInfo IN( 2, 5) 
	and		qa.DataFaturamento >= getdate() - 70
	group by qa.cdparticipantecliente
end 

if (@seqinterfaceinfo in(0,5)) 
begin


	insert into #base_cliente_sinter

	select			qa.cdparticipantecliente 
	--into			#base_melitta_clientes
	from			oxan_est.dbo.TbInterfaceFaturamentoInfoItem qa
	INNER JOIN		postsql.oxan.[public].tbparticipante		t	on t.cdparticipante = qa.CdParticipanteCliente 
	INNER JOIN		postsql.oxan.[public].tbgrupoeconomico 		g   on g.cdgrupoeconomico = t.cdgrupoeconomico
	where	qa.SeqInterfaceInfo = 5
	and		qa.DataFaturamento >= getdate() - 120
	group by qa.cdparticipantecliente

	union 

	select		a.cdparticipante  
	from		POSTSQL.oxan.[public].tbparticipante   a
	inner join  POSTSQL.oxan.[public].tbpessoabluesoft b on b.cdpessoabluesoft = a.cdpessoabluesoft 
	where		a.cdgrupoeconomico <> 0 
	  and       coalesce(a.pessoajuridica,0) = 1
	  and       a.bluesoftcliente = 1
	  and		b.bluesoftpessoastatus = 1
	  and		a.cdparticipante in (select cdparticipantecliente from oxan_est.dbo.TbInterfaceFaturamentoInfoItem where DataFaturamento >= getdate() - 120 and seqinterfaceinfo =5 group by cdparticipantecliente)
	  
end 




--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT	@i = 1
SELECT	@icount = (SELECT count(*) FROM #ListaDeGeracao)
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
WHILE  (@i <= @icount)
	BEGIN

		SELECT		@DataGeracao			=	a.DataGeracao
				,	@INTerface				=	a.SeqINTerfaceInfo	
				,	@Arquivo				=	a.DescricaoTipoArquivo	
				,	@Data					=	a.Data					
				,	@DataFim				=	a.DataFim		
				,	@SeqArquivoHistorico	=	A.SeqArquivoHistorico 
		FROM		#ListaDeGeracao			a
		WHERE		a.seq = @i
		UPDATE OXAN_EST.dbo.TbINTerfaceInfoArquivoHistorico SET DataEnvio = GETDATE() WHERE SeqArquivoHistorico = @SeqArquivoHistorico 
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
						/*********************************************************    INTERFACE		-    J O H N S O N	-	GERACAO DOS PACOTES		*********************************************************/
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		IF( @INTerface = 1 AND	@Arquivo = 'SALES')
			BEGIN

						IF OBJECT_ID('tempdb.dbo.#TMP_INFO_PRODUTO') is not null drop table #TMP_INFO_PRODUTO 
						select			p.pr_cdproduto
								,		p.pr_descricao 
								,		p.prb_cdprodutobluesoft
								,		b.prb_cdpessoabluesoft_fabricante
								,		ps.nome_razao 
								,		ps.nome_abreviado 
								,		ps.cpf_cnpj
								,		b.prb_vendaexterna 
								,		b.prb_cdproduto_compra_padrao 
								,		prbf_codigo_referencia = max(x.prbf_codigo_referencia)
								,		b.prb_cdbarra_principal 
						into			#TMP_INFO_PRODUTO 
						from			POSTSQL.oxan.[public].tbproduto				p
						inner join		POSTSQL.oxan.[public].tbprodutobluesoft		b	on b.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
						inner join      POSTSQL.oxan.[public].tbpessoabluesoft		ps	on ps.cdpessoabluesoft = b.prb_cdpessoabluesoft_fabricante
						inner join      POSTSQL.oxan.[public].tbprodutobluesoft_fornecedor x on x.prb_cdprodutobluesoft = b.prb_cdproduto_compra_padrao and x.prbf_cdpessoabluesoft = ps.cdpessoabluesoft
						inner join      POSTSQL.oxan.[public].tbforca_venda_fabricante f  on f.fv_fabricante_cdpessoabluesoft = ps.cdpessoabluesoft 
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
						order by		p.pr_cdproduto asc
						
						

						/*
						select * from POSTSQL.oxan.[public].tbprodutobluesoft
						SELECT pr_cdproduto, count(*) FROM #TMP_INFO_PRODUTO group by pr_Cdproduto having count(*) 
						1
						SELECT * FROM #TMP_INFO_PRODUTO
						*/
			
						DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
						INSERT  oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
								(		SeqArquivoHistorico 
									,	SeqLinha 
									,	Linha 
								)
						SELECT @SeqArquivoHistorico , 0 ,'Record Type;Distributor Code;Invoice Number;Date;SCJ Product Code;Distributor Product Code;Product DescriptiON;Salesman Code;Salesman Name;Supervisor Code;Supervisor Name;Warehouse Code;Warehouse Name;Outlet Type Code;Outlet Type Desc;Client INTernal Code;Client Federal ID;Client Name;City;Zip Code;Delivery Adress;Qty;Gross Value;Net Value;FractiON;EAN Code'						
						UNION
				SELECT				 @SeqArquivoHistorico
								,		ROW_NUMBER() OVER (ORDER BY I.SeqProcessamentoItemDocumento, o.pr_cdproduto  )		
									,		'DIALSALES01BR;40870;'
											+	ISNULL(CONVERT( VARCHAR(20),I.SeqProcessamentoItemDocumento),'')+ ';'
											+	ISNULL(CONVERT( char(8),i.DataFaturamento, 112),'')+ ';'
											+	CONVERT( VARCHAR(20),ISNULL(w.prbf_codigo_referencia,''))+ ';'
											+	ISNULL(CONVERT( VARCHAR(20),o.pr_cdproduto  ),'')+ ';'
											+   ISNULL(CONVERT( VARCHAR(100),o.pr_descricao ),'')+ ';'
											--+	ISNULL(REPLACE(CONVERT( VARCHAR(15), RTRIM(p.ErpTargetCD_VEND) ),'V',''), '9999' ) + ';'
											+   CONVERT(VARCHAR(15), isnull(p.cdpessoabluesoft, 2046)) + ';'-- CODIGO BLUE VENDEDOR
											+	ISNULL(CONVERT( VARCHAR(50), VENDEDOR_BLUESOFT.nome_razao),'LOJA OXAN') 		+ ';'				
											+	ISNULL(CONVERT( VARCHAR(10), 1),'99')+ ';'
											+	CONVERT( VARCHAR(25), ISNULL('EQUIPE OXAN','9999'))	+ ';'		
											+	'00'	+ ';'
											+	'Main Warehouse'	+ ';'
											+	ISNULL(CONVERT( VARCHAR(10), ISNULL(CATEG.descricaoresumida,'2')	) ,'')+ ';'
											+   ISNULL(CONVERT( VARCHAR(50), ISNULL(CATEG.descricao,'TRADICIONAIS') ),'') + ';'
											-->>> ALTERA��O EM 16/08 TICKET #25501
											+   CONVERT( VARCHAR(10), isnull(i.CdParticipanteCliente,1) )	+ ';' 
											+	ISNULL(CONVERT( VARCHAR(14), convert(numeric(14,0), Cliente.cpf_cnpj) ),'57895328000130') +  ';' 
											+   ISNULL(CONVERT( VARCHAR(40), Cliente_BLUESOFT.nome_razao),'LOJA OXAN')				+ ';'
											+   ISNULL(CONVERT( VARCHAR(30), ENDereco.endereco_municipio ),'SAO PAULO')			+ ';'
											+   ISNULL(CONVERT( VARCHAR(8),  REPLICATE('0', 8 - LEN(CONVERT(VARCHAR(8), endereco.endereco_cep))) + CONVERT( VARCHAR(8),ENDereco.endereco_cep) )	,'03453000')			+ ';'
											+ 	ISNULL(CONVERT( VARCHAR(60), ISNULL(ENDereco.endereco_logradouro,'AV. RIO DAS PEDRAS, 729') ) + ',' + CONVERT( VARCHAR(4), ISNULL(ENDereco.endereco_numero,'')) ,'')+ ';' 						
											+ 	ISNULL(CONVERT( VARCHAR(15), CONVERT(NUMERIC(13,2),i.EmbalagemCompraQtde )),'') + ';'
											+ 	ISNULL(CONVERT( VARCHAR(15), CONVERT(NUMERIC(13,2), i.ValorTotalFaturamento )),'')	+ ';'
											+ 	ISNULL(CONVERT( VARCHAR(15),  '00.00' ),'') + ';'
											+	'1' + ';'
											+	ISNULL(CONVERT( VARCHAR(20),W.PRB_CDBARRA_PRINCIPAL), '')+ ';'

		---------------------------------------------------------------------FATURAMENTO------------------------------------------------------------------------------------------------------------------------------------
				from		oxan_est.dbo.tbinterfacefaturamentoinfoitem				i	
		---------------------------------------------------------------------produto----------------------------------------------------------------------------------------------------------------------------------------
				left join	postsql.oxan.[public].tbproduto						o	
						left join   #tmp_info_produto							w			on	w.pr_cdproduto		=	o.pr_cdproduto 

						on	o.pr_cdproduto	=	i.cdproduto
		---------------------------------------------------------------------vendedor---------------------------------------------------------------------------------------------------------------------------------------
				left join	postsql.oxan.[public].tbparticipante				p			on	p.cdparticipante	= i.cdparticipantevendedor 
				left join   postsql.oxan.[public].tbpessoabluesoft			vendedor_bluesoft on vendedor_bluesoft.cdpessoabluesoft = p.cdpessoabluesoft 
		---------------------------------------------------------------------cliente----------------------------------------------------------------------------------------------------------------------------------------
				
				left join	postsql.oxan.[public].tbparticipante 			cliente
				left join   postsql.oxan.[public].tbpessoabluesoft			cliente_bluesoft on cliente_bluesoft.cdpessoabluesoft = cliente.cdpessoabluesoft 
				--left join   postsql.oxan.[public].tbendereco_participante   endereco		 on endereco.cdparticipante = cliente.cdparticipante 
				left join   postsql.oxan.[public].tbparticipante_endereco   endereco		 on endereco.cdparticipante = cliente.cdparticipante 
				left join   (			select		categoria.descricaoresumida, 
													categoria.descricao, 
													categoria_item.cdparticipante 
										from		postsql.oxan.[public].tbinterfacecategoria		categoria
										inner join	postsql.oxan.[public].tbinterfacecategoriaitem	categoria_item on categoria_item.seqinterfacecategoria = categoria.seqinterfacecategoria
										where		seqinterfacetipo = 6
										and			isnull(categoria_item.cdparticipante,0) <> 0 
							) categ on categ.cdparticipante = cliente.cdparticipante 

						on cliente.cdparticipante = i.cdparticipantecliente 
		---------------------------------------------------------------------filtros----------------------------------------------------------------------------------------------------------------------------------------
				where	i.datafaturamento	>=	@data
				and		i.datafaturamento	<=	@datafim
				and		i.seqinterfaceinfo	=	@interface
				

				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		
		IF(	@INTerface = 1 AND	@Arquivo = 'STOCK')
			BEGIN


					IF OBJECT_ID('tempdb.dbo.#TMP_INFO_PRODUTO_X') is not null drop table #TMP_INFO_PRODUTO_X
						select			p.pr_cdproduto
								,		p.pr_descricao 
								,		p.prb_cdprodutobluesoft
								,		b.prb_cdpessoabluesoft_fabricante
								,		ps.nome_razao 
								,		ps.nome_abreviado 
								,		ps.cpf_cnpj
								,		b.prb_vendaexterna 
								,		b.prb_cdproduto_compra_padrao 
								,		x.prbf_codigo_referencia 
								,		bx.prb_cdbarra_principal 
								,		bx.prb_descricao 
						into			#TMP_INFO_PRODUTO_X
						from			POSTSQL.oxan.[public].tbproduto				p
						inner join		POSTSQL.oxan.[public].tbprodutobluesoft		b	on b.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
						inner join      POSTSQL.oxan.[public].tbpessoabluesoft		ps	on ps.cdpessoabluesoft = b.prb_cdpessoabluesoft_fabricante
						inner join      POSTSQL.oxan.[public].tbprodutobluesoft_fornecedor x on x.prb_cdprodutobluesoft = b.prb_cdproduto_compra_padrao and x.prbf_cdpessoabluesoft = ps.cdpessoabluesoft
						inner join		POSTSQL.oxan.[public].tbprodutobluesoft		bx	on bx.prb_cdprodutobluesoft_pk = b.prb_cdproduto_compra_padrao 
						inner join      POSTSQL.oxan.[public].tbforca_venda_fabricante f  on f.fv_fabricante_cdpessoabluesoft = ps.cdpessoabluesoft 
						where			f.fv_fabricante_cdpessoabluesoft = 13752 -- PRODUTOS CERAS JOHNSON
						order by		p.pr_cdproduto asc


						---select * from #TMP_INFO_PRODUTO_X
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








						DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
						INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
								(		SeqArquivoHistorico 
									,	SeqLinha 
									,	Linha 
								)
						SELECT @SeqArquivoHistorico , 0 ,'Record Type;Distributor Code;Date;SCJ Product Code;Distributor Product Code;Distributor Product DescriptiON;Qty;Warehouse Code;Warehouse Name;FractiON;EAN Code;Sales Qty;ExDO;BONus Sample;Others'
						UNION
						SELECT				@SeqArquivoHistorico 
									,		ROW_NUMBER() OVER (ORDER BY i.cdproduto )		
									,		'DIALSTOCK01BR'																														+';'+	--RecordType
											'40870'																																+';'+	--[DistributGO
											ISNULL(CONVERT(CHAR(8)    ,i.DataEstoque ,112),'')																					+';'+	--[DATE]
											ISNULL(CONVERT(VARCHAR(20),ISNULL(o.prbf_codigo_referencia,'')),'')																			+';'+   --[SCJ Produ
											ISNULL(CONVERT(VARCHAR(10),i.cdProduto ),'')																						+';'+	--[Distribut
											ISNULL(CONVERT(VARCHAR(40),o.pr_descricao),'')																							+';'+	--[Distribut
											ISNULL(CONVERT(VARCHAR(10),CONVERT(NUMERIC(13,2),CASE WHEN i.EmbalagemCompraQtde < 0 THEN 0 ELSE i.EmbalagemCompraQtde END )),'')	+';'+	--[Qty]
											'00'																																+';'+	--[WareHouse
											'Main Warehouse'																													+';'+	--[Warehouse
											'1'																																	+';'+   --[fractiON]
											ISNULL(CONVERT(VARCHAR(20),o.prb_cdbarra_principal),'')																							+';'+	--[Ean Code]
											''																																	+';'+	--[Sales Qty
											''																																	+';'+	--[ExDO]
											''																																	+';'+	--[BONus Sam
											''																																			--[Others]

				FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem	i
				INNER JOIN	#TMP_INFO_PRODUTO_X						o ON o.pr_cdproduto = i.cdproduto 
				WHERE		i.DataEstoque					>=	@Data
				and			i.DataEstoque					<=	@DataFim
				and			i.SeqINTerfaceInfo				=	@INTerface
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
		IF(	@INTerface = 1 AND	@Arquivo = 'CLIENT')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	0
							,	'RecordType;Distributor code;Client code;Client Federal ID;Client name;Client status;Salesman code;Salesman name;SalesmanType'
				
				UNION
				SELECT			@SeqArquivoHistorico
							,	ROW_NUMBER() OVER (ORDER BY a.cdparticipante )		
							,	'DIALCLIENT01BR'
							+	';'
							+	'40870'
							+	';'
							+	CONVERT(VARCHAR(10), ISNULL(a.cdparticipante,1))
							+	';'
							+	LEFT( ISNULL(CONVERT(VARCHAR(14), convert(numeric(14,0), a.cpf_cnpj)), '57895328000130'), 14)
							+	';'
							+	ISNULL(CONVERT(VARCHAR(40), ps.nome_razao), 'OXAN ATACADISTA LTDA')
							+	';'
							+	ISNULL(CASE ps.bluesoftclientestatus WHEN 0 THEN 'Closed' ELSE 'Active' END, 'Closed')
							+	';'
							--+	ISNULL(CONVERT(VARCHAR(5), REPLACE(pv.erptargetcd_vend, 'V', '')), '236')
							+	ISNULL(CONVERT(VARCHAR(5), psv.cdpessoabluesoft), '2046')
							+	';'
							+	ISNULL(CONVERT(VARCHAR(40),psv.nome_razao), 'FRANCISCO EDUARDO DA SILVA')
							+	';'
							+	'COMUM' 
				----------------------------------------------------------------------------------------------------------------------------------------------
				FROM		POSTSQL.oxan.[public].tbparticipante			a	 
				inner join  POSTSQL.oxan.[public].tbpessoabluesoft			ps on ps.cdpessoabluesoft = a.cdpessoabluesoft
				left join  POSTSQL.oxan.[public].tbparticipante			pv on pv.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor and ps.cdpessoabluesoft_vendedor <> 0 
				left join  POSTSQL.oxan.[public].tbpessoabluesoft			psv on psv.cdpessoabluesoft = pv.cdpessoabluesoft
				WHERE	1 = 1 
				and		(	a.cdparticipante in (	SELECT	x.CdParticipanteCliente
													FROM	OXAN_EST.dbo.TbINTerfaceFaturamentoInfoItem x
													WHERE	x.DataFaturamento		>=	@Data
													and		x.DataFaturamento		<=	@DataFim
													and		x.SeqINTerfaceInfo	=	@INTerface
												)
							or
							( ps.bluesoftclientestatus = 1 and isnull(ps.cdgrupoeconomico,0) > 0 )

						)

/*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				
				SELECT			@SeqArquivoHistorico
							,	((SELECT MAX(SeqLinha) FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha WHERE SeqArquivoHistorico = @SeqArquivoHistorico) + 1)
							,	'DIALCLIENT01BR;40870;0;57895328000130;SISTEMA PAG;Active;0;SISTEMA PAG;COMUM'
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	((SELECT MAX(SeqLinha) FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha WHERE SeqArquivoHistorico = @SeqArquivoHistorico) + 1)
							,	'DIALCLIENT01BR;40870;1;57895328000130;LOJA OXAN;Active;9999;OXAN;COMUM'*/
		END

		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



						/*********************************************************    MELITTA MTRIX	-	 GERACAO DOS PACOTES	*********************************************************/
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
		IF( @INTerface = 2 AND @Arquivo = 'VENDA')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	0
							,	'HVENDA1162000278000701'
	
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqInterfaceFaturamentoInfoItem
							,	SeqLinha 
							,	Linha 
							
						)
				SELECT			@SeqArquivoHistorico
							,	x.SeqInterfaceFaturamentoInfoItem
							,	ROW_NUMBER() OVER(ORDER BY X.SeqProcessamentoItemDocumento)

							,	CONVERT(CHAR(01),	'D')/*TIPO DE REGISTRO*/																						
							+	CONVERT(CHAR(14),	'57895328000130')/*CNPJ AGENTE DE DISTRIBUI��O*/																				
							+	CONVERT(CHAR(18),	ISNULL(c.cpf_cnpj,'57895328000130'))/*IDENTIFICA��O DO CLIENTE(CNPJ)*/																			
							+	CONVERT(CHAR(08),	X.DataFaturamento,112)/*DATA TRANSA��O*/																							
							+	'001'/*SERIE*/
							+	CONVERT(CHAR(17),	X.SeqProcessamentoItemDocumento)/*NUMERO DO DOCUMENTO (NOTA FISCAL)*/
							+	CONVERT(CHAR(14),	cb.prb_cdbarra_principal)/*C�DIGO DO PRODUTO (EAN13 OU DUN14 - CONFORME TIPO DE UNIDADE COMERCIALIZADA)*/
							+	CONVERT(CHAR(20),	CASE WHEN x.EmbalagemEstoqueQtde < 0 
														 THEN				'-'+ REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),x.EmbalagemEstoqueQtde))) + CONVERT(CHAR(20),x.EmbalagemEstoqueQtde),'-','')
														 ELSE CONVERT(CHAR(20),	 REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),x.EmbalagemEstoqueQtde))) + CONVERT(CHAR(20),x.EmbalagemEstoqueQtde),'-','')) 
													END)/*QUANTIDADE*/
							+	CONVERT(CHAR(08),	REPLICATE('0',08 -len(CONVERT(CHAR(08),CONVERT(NUMERIC(5,2),x.ValorTotalFaturamento / x.EmbalagemEstoqueQtde)))) + CONVERT(CHAR(08),CONVERT(NUMERIC(5,2),x.ValorTotalFaturamento / x.EmbalagemEstoqueQtde)))/*PRE�O DE VENDA*/
							+	CONVERT(CHAR(20),	ISNULL(v.cdpessoabluesoft,'2046'))/*C�DIGO DO VENDEDOR*/
							
							+	CONVERT(CHAR(10),	'')/*CAMPO RESERVADO*/
							+	CONVERT(CHAR(01),	CASE WHEN CONVERT(NUMERIC(13,5), x.ValorTotalFaturamento) = 0 and CONVERT(NUMERIC(13,5), X.EMBALAGEMESTOQUEQTDE) > 0 
														 THEN 'B' ELSE 'N'
													END)/*TIPO DO DOCUMENTO (TIPO DA VENDA : NORMAL OU  BONIFICADO)*/
							+	CONVERT(CHAR(09),	SUBSTRING(REPLICATE('0',8 -len(CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000))))+ CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000)),1,5) + '-' + SUBSTRING(REPLICATE('0',8 -len(CONVERT(CHAR(09), ISNULL(e.endereco_cep,03453000))))+CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000)),6,3))/*CEP*/
							+	CONVERT(CHAR(13),	'')/*CODIGO DO LOTE*/
							+	CONVERT(CHAR(06),	'')/*VALIDADE DO LOTE	'AAAAMM'*/
							+	CONVERT(CHAR(02),	'')/*DIA VALIDADE DO LOTE 'DD'*/
							+	CONVERT(CHAR(01),	'')/*PEDIDO SUGERIDO*/
							+	CONVERT(CHAR(08),	'')/*PRE�O DE VENDA US$ (EM DOLAR)*/
							+	CONVERT(CHAR(04),	CASE WHEN X.EmbalagemEstoque = 'KG' THEN '0002' ELSE '0001' END)/*TIPO DE UNIDADE (CONFORME TABELA:   TP_UN: 0001 = UNIDADE DE CONSUMO	|	TP_UN: 0002 = QUILOS(KG))*/
				FROM			OXAN_EST.dbo.TbINTerfaceFaturamentoInfoItem		x
				left join		postsql.oxan.[public].tbproduto					pr  on pr.pr_cdproduto = x.cdproduto 
				left join       postsql.oxan.[public].tbprodutobluesoft			cb	on cb.prb_cdprodutobluesoft_pk =  pr.prb_cdprodutobluesoft 
				left join		postsql.oxan.[public].tbparticipante			v	on	v.cdparticipante	=	x.cdparticipantevendedor
				left join		postsql.oxan.[public].tbparticipante			c	on	c.cdparticipante	=	x.cdparticipantecliente
				--left join       postsql.oxan.[public].tbendereco_participante	e	on  e.cdparticipante	=	c.cdparticipante 
				left join       postsql.oxan.[public].tbparticipante_endereco	e	on  e.cdparticipante	=	c.cdparticipante 
				
				WHERE		x.SeqINTerfaceInfo	=	2
				and			CONVERT(VARCHAR(8), x.datafaturamento,112)	>= @Data
				and			CONVERT(VARCHAR(8), x.datafaturamento,112)	<=	@DataFim
				group by		isnull(c.cpf_cnpj,'57895328000130')
							,	cb.prb_cdbarra_principal 
							,	x.seqprocessamentoitemdocumento
							,	x.datafaturamento
							,	v.cdpessoabluesoft
							,	e.endereco_cep
							,	x.embalagemestoque
							,	x.embalagemestoqueqtde
							,	x.valortotalfaturamento
							,	x.SeqInterfaceFaturamentoInfoItem
				order by		x.datafaturamento
							,	x.seqprocessamentoitemdocumento
							,	x.SeqInterfaceFaturamentoInfoItem
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		IF( @INTerface = 2 AND @Arquivo = 'ESTOQUE')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		isnull(SeqArquivoHistorico,0) = isnull(@SeqArquivoHistorico ,0)
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,  'HESTOQ1162000278000701'
								+	CONVERT(CHAR(08), @Data, 112)
					FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem		e
					UNION
					SELECT			@SeqArquivoHistorico
								,	ROW_NUMBER() OVER(ORDER BY  cb.prb_cdbarra_principal )
								,	'E'/*TIPO DO REGISTRO*/
								+	'57895328000130'/*CNPJ AGENDE DE DISTRIBUI��O*/
								+	CONVERT(CHAR(14), cb.prb_cdbarra_principal )/*C�DIGO DO PRODUTO*/
								+	CONVERT(CHAR(20),	CASE WHEN sum(e.EmbalagemEstoqueQtde) <= 0 
															 THEN			REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),CONVERT(NUMERIC(15,4),0))))	  + CONVERT(CHAR(20),CONVERT(NUMERIC(15,4),0)),'-','') 
														     ELSE CONVERT(CHAR(20),	REPLICATE('0',20 -len(CONVERT(CHAR(20),sum(isnull(e.EmbalagemEstoqueQtde,0))))) + CONVERT(CHAR(20),sum(isnull(e.EmbalagemEstoqueQtde,0)))) 
														END)/*QUANTIDADE*/
								+	CONVERT(CHAR(20),	'')/*CODIGO DO LOTE*/
								+	CONVERT(CHAR(08),	'')/*VALIDADE DO LOTE	'AAAAMM'*/
								+	CONVERT(CHAR(04),	'0001')/*TIPO DE UNIDADE (CONFORME TABELA:   TP_UN: 0001 = UNIDADE DE CONSUMO	|	TP_UN: 0002 = QUILOS(KG))*/
					FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem		e
					left join	POSTSQL.oxan.[public].tbproduto				pr on pr.pr_cdproduto = e.CdProduto 
					left join   POSTSQL.oxan.[public].tbprodutobluesoft		cb on cb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
					--LEFT JOIN	SRV01.MOINHO.DBO.CD_BARRA_UNPRD				CB ON CB.Cd_Prod = e.cdproduto and cb.UNID_VDA =	e.embalagemestoque
					WHERE		e.SeqINTerfaceInfo		=	2
					AND			e.EmbalagemEstoque		=	'un'
					AND			e.DataEstoque			>=	@Data
					AND			e.DataEstoque			<=	@DataFim
					/*
					AND			CB.Seq					=	(	SELECT MAX(s.seq)
																FROM	SRV01.MOINHO.DBO.CD_BARRA_UNPRD	S
																WHERE	s.tp_cd_barra = 'ean13'
																AND		s.Cd_Prod = E.CdProduto
																AND		s.ATIVO = 1
																AND		s.Cd_Barra LIKE '789%'
																GROUP BY S.Cd_Prod
															)*/
					GROUP BY	cb.prb_cdbarra_principal 
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		IF( @INTerface = 2 AND @Arquivo = 'CLIENTE')
			BEGIN

				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 

					INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,	'HPDV10  62000278000701'
					INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	ROW_NUMBER() OVER (ORDER BY  pa.nome_razao)
								,	'D'
								+	'57895328000130'
								+	CONVERT(CHAR(18),	ISNULL(a.cpf_cnpj,'57895328000130'))
								+	CONVERT(CHAR(40),	LEFT(ISNULL(pa.nome_razao,'CLIENTE OXAN'),40))
								+	CONVERT(CHAR(40),	LEFT(ISNULL(c.endereco_logradouro,'AV. RIO DAS PEDRAS, 729'),40))
								+	CONVERT(CHAR(30),   left(ISNULL(c.endereco_bairro,'VILA FORMOSA'),30))
								+	CONVERT(CHAR(09),	SUBSTRING(REPLICATE('0',8 -LEN(CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)))) + CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)),1,5) + '-' + SUBSTRING(REPLICATE('0',8 -LEN(CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)))) + CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)),6,3))
								+	CONVERT(CHAR(30),	LEFT(ISNULL(c.endereco_municipio,'SAO PAULO'),30))
								+	CONVERT(CHAR(30),	ISNULL(c.endereco_uf,'SP'))
								+	CONVERT(CHAR(20),	left(ISNULL(e.ErpTargetCD_VEND,'ELIAS'),20))                                         
								+	CONVERT(CHAR(40),	'00' + CONVERT(CHAR(38), '027825200'))
								+	CONVERT(CHAR(18),	ISNULL(a.cpf_cnpj,'57895328000130'))
								+	CONVERT(CHAR(10),	left(ISNULL(c.endereco_bairro,''),10))
								+	CONVERT(CHAR(10),	'')
								+	CONVERT(CHAR(10),	ISNULL(F.CODIGO,'112'))
								+	CONVERT(CHAR(06),	'')
								--- ELIAS ---

				FROM			POSTSQL.oxan.[public].tbparticipante				a
					LEFT JOIN       POSTSQL.oxan.[public].tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
					LEFT JOIN		POSTSQL.oxan.[public].tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
					LEFT JOIN 		POSTSQL.oxan.[public].tbparticipante			e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
					left join       POSTSQL.oxan.[public].tbparticipante_endereco	c	on c.cdparticipante = a.cdparticipante 
					

					LEFT JOIN		(	select		CODIGO						=			CONVERT(CHAR(10),LEFT(itc.DescricaoResumida , 10))
												,	CDPARTICIPANTE				=			iti.CdParticipante 
										from		postsql.oxan.[public].tbinterface				itf
										inner join  postsql.oxan.[public].tbinterfacetipo			itt on itt.seqinterface			= itf.seqinterface 
										inner join	postsql.oxan.[public].tbinterfacecategoria		itc on itc.seqinterfacetipo		= itt.seqinterfacetipo 
										inner join  postsql.oxan.[public].tbinterfacecategoriaitem	iti on iti.seqinterfacecategoria = itc.seqinterfacecategoria 
										where		itf.SeqInterface		= 2		---> SEQ INTERFACE = 2 | MELITTA
										and			itt.SeqInterfaceTipo	= 3		---> SEQ SeqInterfaceTipo = 2 | MELITTA MTRIX
									)										F	ON	f.cdparticipante = a.cdparticipante
					WHERE			1 = 1 
					AND	(		(ISNULL(pa.cdgrupoeconomico,0) <> 0 and pa.bluesoftclientestatus = 1)
								or	a.cdparticipante in (	select qa.cdparticipante from #base_melitta_clientes qa	GROUP BY qa.cdparticipante)
																	)
					order by 2
/*
					INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	((SELECT MAX(SeqLinha) FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha WHERE SeqArquivoHistorico = @SeqArquivoHistorico) + 1)
								,	'D'
								+	'57895328000130'
								+	CONVERT(CHAR(18),	'1')
								+	convert(char(40),	'SISTEMA PAG')
								+	CONVERT(CHAR(40),	'AV. RIO DAS PEDRAS, 729')
								+	CONVERT(CHAR(30),	'JARDIM ARICANDUVA')
								+	CONVERT(CHAR(09),	'03453-000')
								+	CONVERT(CHAR(30),	'S�O PAULO')
								+	CONVERT(CHAR(30),	'SP')
								+	CONVERT(CHAR(20),	'SISTEMA PAG')
								+	CONVERT(CHAR(40),	 '1127825200')
								+	CONVERT(CHAR(18),	'57895328000130')
								+	CONVERT(CHAR(10),	'JARDIM ARICANDUVA')
								+	CONVERT(CHAR(10),	'')
								+	CONVERT(CHAR(10),	'182')
								+	CONVERT(CHAR(06),	'')*/
				--if OBJECT_ID('tempdb.dbo.#base_melitta_clientes') is not null drop table #base_melitta_clientes

		END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------							
		IF( @INTerface = 2 AND @Arquivo = 'VENDEDOR')
			BEGIN
				
				/*
				if OBJECT_ID('tempdb.dbo.#base_melitta_clientes') is not null drop table #base_melitta_clientes
				select	qa.cdparticipantecliente 
				into	#base_melitta_clientes
				from	oxan_est.dbo.TbInterfaceFaturamentoInfoItem qa
				where	qa.SeqInterfaceInfo = 2
				and		qa.DataFaturamento >= getdate() - 70
				group by qa.cdparticipantecliente
				*/

				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,  'HFV10   62000278000701'
					UNION
					SELECT			@SeqArquivoHistorico	
								,	ROW_NUMBER() OVER(ORDER BY  pe.cdpessoabluesoft)
								,	'D'
								+	'57895328000130'
								+	CONVERT(CHAR(18), ISNULL(a.cpf_cnpj,'00077109970825'))
								+	CONVERT(CHAR(13), 'TM')
								+	CONVERT(CHAR(50), 'FRANCISCO EDUARDO')
								+	CONVERT(CHAR(13), 'EQUIPE GERAL')
								+	CONVERT(CHAR(50), 'EQUIPE GERAL')
								+	CONVERT(CHAR(20), isnull(pe.cdpessoabluesoft,2166))
								+	CONVERT(CHAR(50), LEFT(ISNULL(pe.nome_razao, 'FRANCISCO EDUARDO'),50))
					/*
					FROM		OXAN_ADM.DBO.TBPARTICIPANTE	C
					INNER JOIN	OXAN_ADM.DBO.TBPARTICIPANTE	V	ON  C.bluesoftfvclientevendedorcnpj = V.cnpjcpf and V.representanteforcadevenda = 1  
					WHERE		1 = 1 
					AND			ISNULL(C.BlueSoftFVGrupoEconomicoKey,0) <> 0*/

					FROM			POSTSQL.oxan.[public].tbparticipante			a
					LEFT JOIN       POSTSQL.oxan.[public].tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
					LEFT JOIN		POSTSQL.oxan.[public].tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
					LEFT JOIN 		POSTSQL.oxan.[public].tbparticipante			e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
					left join       POSTSQL.oxan.[public].tbparticipante_endereco	c	on c.cdparticipante = a.cdparticipante 
					WHERE			1 = 1 
					AND	(		a.cdparticipante = 1
								or	(ISNULL(pa.cdgrupoeconomico,0) <> 0 and pa.bluesoftclientestatus = 1)
								or	a.cdparticipante in (	select qa.cdparticipante from #base_melitta_clientes qa	)
																	)
																	

					order by 2
				---if OBJECT_ID('tempdb.dbo.#base_melitta_clientes') is not null drop table #base_melitta_clientes

			
		END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------						
		IF( @INTerface = 2 AND @Arquivo = 'PRODUTO')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		isnull(SeqArquivoHistorico,0) = isnull(@SeqArquivoHistorico ,0)
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	0
							,	CONVERT(CHAR(01),	'H')
							+	CONVERT(CHAR(10),	'CADPROD')
							+	CONVERT(CHAR(08),	@Data,112)
				UNION
				SELECT			@SeqArquivoHistorico
							,	1
							,	CONVERT(CHAR(01),	'I')
							+	CONVERT(CHAR(14),	'57895328000130')
				UNION
				SELECT			@SeqArquivoHistorico
							,	ROW_NUMBER() OVER(ORDER BY  P.pr_cdproduto) + 1 ---->>> ALTERA��O EM 25/08/2020 | Eviar linha com chave 0 duplicada 
							,	CONVERT(CHAR(01),	'V')
							+	CONVERT(CHAR(18),	'62000278000701')
							+	CONVERT(CHAR(30),	'MELITTA')
							+	CONVERT(CHAR(14),	P.pr_cdproduto)
							+	CONVERT(CHAR(01),	0)
							+	CONVERT(CHAR(14),	CB.prb_cdbarra_principal)
							+	CONVERT(CHAR(01),	1)
							+	CONVERT(CHAR(100),	P.pr_descricao)
							+	CONVERT(CHAR(40),	'MELITTA DO BRASIL IN')
							+	CONVERT(CHAR(30),	'')
							+	CONVERT(CHAR(01),	'A')
							+	CONVERT(CHAR(27),	'')
				FROM		POSTSQL.oxan.[public].tbproduto					p 
				INNER JOIN  POSTSQL.oxan.[public].tbprodutobluesoft			CB ON CB.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
				INNER JOIN  POSTSQL.oxan.[public].tbforca_venda_fabricante  f on f.fv_fabricante_cdpessoabluesoft = cb.prb_cdpessoabluesoft_fabricante
				/*INNER JOIN	(
													SELECT		X.CD_PROD							CD_PROD
															,	X.UNID_VDA							UNID_VDA
															,	X.CD_BARRA							CD_BARRA
													FROM		SRV01.MOINHO.DBO.CD_BARRA_UNPRD		X
													WHERE		X.Seq	=	(	
																				SELECT		MAX(S.SEQ)
																				FROM		SRV01.MOINHO.DBO.CD_BARRA_UNPRD	S
																				WHERE		S.tp_cd_barra	=	 'ean13'
																				AND			S.Cd_Prod		=	 x.Cd_PROD
																				AND			S.ATIVO			=	 1
																				AND			S.Cd_Barra		LIKE '789%'
																				GROUP BY	S.Cd_Prod
																			)
												)												CB	ON	CB.Cd_Prod			=	P.CdProduto
				INNER JOIN	SRV01.MOINHO.DBO.FABRIC				F	ON	F.CD_FABRIC	=	P.CdFabricante*/
				WHERE		f.fv_fabricante_Seq = 2
				AND			P.pr_status			=	1
				AND			p.pr_embalagemestoque	=	'UN'
			
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				


						/*********************************************************    INTERFACE		-   SINTER / MTRIX 	-	 GERACAO DOS PACOTES	*********************************************************/
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
		IF( @INTerface = 5 AND @Arquivo = 'VENDA')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	0
							,	'HVENDA1174222563000160'
	
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqInterfaceFaturamentoInfoItem
							,	SeqLinha 
							,	Linha 
							
						)
				SELECT			@SeqArquivoHistorico
							,	x.SeqInterfaceFaturamentoInfoItem
							,	ROW_NUMBER() OVER(ORDER BY X.SeqProcessamentoItemDocumento)

							,	CONVERT(CHAR(01),	'D')/*TIPO DE REGISTRO*/																						
							+	CONVERT(CHAR(14),	'57895328000130')/*CNPJ AGENTE DE DISTRIBUI��O*/																				
							+	CONVERT(CHAR(18),	case when isnull(c.pessoajuridica,0) = 0 then right(ISNULL(c.cpf_cnpj,'77109970825'),11) else right(ISNULL(c.cpf_cnpj,'57895328000130'),14) end)/*IDENTIFICA��O DO CLIENTE(CNPJ)*/																			
							+	CONVERT(CHAR(08),	X.DataFaturamento,112)/*DATA TRANSA��O*/																							
							+	'001'/*SERIE*/
							+	CONVERT(CHAR(17),	X.SeqProcessamentoItemDocumento)/*NUMERO DO DOCUMENTO (NOTA FISCAL)*/
							+	CONVERT(CHAR(14),	cb.prb_cdbarra_principal)/*C�DIGO DO PRODUTO (EAN13 OU DUN14 - CONFORME TIPO DE UNIDADE COMERCIALIZADA)*/
							+	CONVERT(CHAR(20),	CASE WHEN x.EmbalagemEstoqueQtde < 0 
														 THEN				'-'+ REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),x.EmbalagemEstoqueQtde))) + CONVERT(CHAR(20),x.EmbalagemEstoqueQtde),'-','')
														 ELSE CONVERT(CHAR(20),	 REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),x.EmbalagemEstoqueQtde))) + CONVERT(CHAR(20),x.EmbalagemEstoqueQtde),'-','')) 
													END)/*QUANTIDADE*/
							+	CONVERT(CHAR(08),	REPLICATE('0',08 -len(CONVERT(CHAR(08),CONVERT(NUMERIC(5,2),x.ValorTotalFaturamento / x.EmbalagemEstoqueQtde)))) + CONVERT(CHAR(08),CONVERT(NUMERIC(5,2),x.ValorTotalFaturamento / x.EmbalagemEstoqueQtde)))/*PRE�O DE VENDA*/
							+	CONVERT(CHAR(20),	ISNULL(v.cdpessoabluesoft,'2046'))/*C�DIGO DO VENDEDOR*/
							
							+	CONVERT(CHAR(10),	'')/*CAMPO RESERVADO*/
							+	CONVERT(CHAR(01),	CASE WHEN CONVERT(NUMERIC(13,5), x.ValorTotalFaturamento) = 0 and CONVERT(NUMERIC(13,5), X.EMBALAGEMESTOQUEQTDE) > 0 
														 THEN 'B' ELSE 'N'
													END)/*TIPO DO DOCUMENTO (TIPO DA VENDA : NORMAL OU  BONIFICADO)*/
							+	CONVERT(CHAR(09),	SUBSTRING(REPLICATE('0',8 -len(CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000))))+ CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000)),1,5) + '-' + SUBSTRING(REPLICATE('0',8 -len(CONVERT(CHAR(09), ISNULL(e.endereco_cep,03453000))))+CONVERT(CHAR(09),ISNULL(e.endereco_cep,03453000)),6,3))/*CEP*/
							+	CONVERT(CHAR(13),	'')/*CODIGO DO LOTE*/
							+	CONVERT(CHAR(06),	'')/*VALIDADE DO LOTE	'AAAAMM'*/
							+	CONVERT(CHAR(02),	'')/*DIA VALIDADE DO LOTE 'DD'*/
							+	CONVERT(CHAR(01),	'')/*PEDIDO SUGERIDO*/
							+	CONVERT(CHAR(08),	'')/*PRE�O DE VENDA US$ (EM DOLAR)*/
							+	CONVERT(CHAR(04),	CASE WHEN X.EmbalagemEstoque = 'KG' THEN '0002' ELSE '0001' END)/*TIPO DE UNIDADE (CONFORME TABELA:   TP_UN: 0001 = UNIDADE DE CONSUMO	|	TP_UN: 0002 = QUILOS(KG))*/
				FROM			OXAN_EST.dbo.TbINTerfaceFaturamentoInfoItem		x
				left join		postsql.oxan.[public].tbproduto					pr  on pr.pr_cdproduto = x.cdproduto 
				left join       postsql.oxan.[public].tbprodutobluesoft			cb	on cb.prb_cdprodutobluesoft_pk =  pr.prb_cdprodutobluesoft 
				left join		postsql.oxan.[public].tbparticipante			v	on	v.cdparticipante	=	x.cdparticipantevendedor
				left join		postsql.oxan.[public].tbparticipante			c	on	c.cdparticipante	=	x.cdparticipantecliente
				left join       postsql.oxan.[public].tbparticipante_endereco	e	on  e.cdparticipante	=	c.cdparticipante 
				
				WHERE		x.SeqINTerfaceInfo	=	5
				and			CONVERT(VARCHAR(8), x.datafaturamento,112)	>= @Data
				and			CONVERT(VARCHAR(8), x.datafaturamento,112)	<=	@DataFim
				group by		case when isnull(c.pessoajuridica,0) = 0 then right(ISNULL(c.cpf_cnpj,'77109970825'),11) else right(ISNULL(c.cpf_cnpj,'57895328000130'),14) end
							,	cb.prb_cdbarra_principal 
							,	x.seqprocessamentoitemdocumento
							,	x.datafaturamento
							,	v.cdpessoabluesoft
							,	e.endereco_cep
							,	x.embalagemestoque
							,	x.embalagemestoqueqtde
							,	x.valortotalfaturamento
							,	x.SeqInterfaceFaturamentoInfoItem
				order by		x.datafaturamento
							,	x.seqprocessamentoitemdocumento
							,	x.SeqInterfaceFaturamentoInfoItem
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		IF( @INTerface = 5 AND @Arquivo = 'ESTOQUE')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,  'HESTOQ1174222563000160'
								+	CONVERT(CHAR(08), @Data, 112)
					FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem		e
					UNION
					SELECT			@SeqArquivoHistorico
								,	ROW_NUMBER() OVER(ORDER BY  cb.prb_cdbarra_principal )
								,	'E'/*TIPO DO REGISTRO*/
								+	'57895328000130'/*CNPJ AGENDE DE DISTRIBUI��O*/
								+	CONVERT(CHAR(14), cb.prb_cdbarra_principal )/*C�DIGO DO PRODUTO*/
								+	CONVERT(CHAR(20),	CASE WHEN sum(e.EmbalagemEstoqueQtde) <= 0 
															 THEN			REPLACE(REPLICATE('0',20 -len(CONVERT(CHAR(20),CONVERT(NUMERIC(15,4),0))))	  + CONVERT(CHAR(20),CONVERT(NUMERIC(15,4),0)),'-','') 
														     ELSE CONVERT(CHAR(20),	REPLICATE('0',20 -len(CONVERT(CHAR(20),sum(isnull(e.EmbalagemEstoqueQtde,0))))) + CONVERT(CHAR(20),sum(isnull(e.EmbalagemEstoqueQtde,0)))) 
														END)/*QUANTIDADE*/
								+	CONVERT(CHAR(20),	'')/*CODIGO DO LOTE*/
								+	CONVERT(CHAR(08),	'')/*VALIDADE DO LOTE	'AAAAMM'*/
								+	CONVERT(CHAR(04),	'0001')/*TIPO DE UNIDADE (CONFORME TABELA:   TP_UN: 0001 = UNIDADE DE CONSUMO	|	TP_UN: 0002 = QUILOS(KG))*/
					FROM		OXAN_EST.dbo.TbINTerfaceEstoqueInfoItem		e
					left join	POSTSQL.oxan.[public].tbproduto				pr on pr.pr_cdproduto = e.CdProduto 
					left join   POSTSQL.oxan.[public].tbprodutobluesoft		cb on cb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
					--LEFT JOIN	SRV01.MOINHO.DBO.CD_BARRA_UNPRD				CB ON CB.Cd_Prod = e.cdproduto and cb.UNID_VDA =	e.embalagemestoque
					WHERE		e.SeqINTerfaceInfo		=	5
					AND			e.EmbalagemEstoque		=	'UN'
					AND			e.DataEstoque			>=	@Data
					AND			e.DataEstoque			<=	@DataFim
					/*
					AND			CB.Seq					=	(	SELECT MAX(s.seq)
																FROM	SRV01.MOINHO.DBO.CD_BARRA_UNPRD	S
																WHERE	s.tp_cd_barra = 'ean13'
																AND		s.Cd_Prod = E.CdProduto
																AND		s.ATIVO = 1
																AND		s.Cd_Barra LIKE '789%'
																GROUP BY S.Cd_Prod
															)*/
					GROUP BY	cb.prb_cdbarra_principal 
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		IF( @INTerface = 5 AND @Arquivo = 'CLIENTE')
			BEGIN

				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 

					INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,	'HPDV10  74222563000160'
					INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
								,	ROW_NUMBER() OVER (ORDER BY  pa.nome_razao)
								,	'D'
								+	'57895328000130'
								+	CONVERT(CHAR(18),	case when isnull(a.pessoajuridica,0) = 0 then right(ISNULL(a.cpf_cnpj,'77109970825'),11) else right(ISNULL(a.cpf_cnpj,'57895328000130'),14) end)
								+	CONVERT(CHAR(40),	LEFT(ISNULL(pa.nome_razao,'CLIENTE OXAN'),40))
								+	CONVERT(CHAR(40),	LEFT(ISNULL(c.endereco_logradouro,'AV. RIO DAS PEDRAS, 729'),40))
								+	CONVERT(CHAR(30),   left(case when ISNULL(c.endereco_bairro,'VILA FORMOSA') = '' then 'VILA FORMOSA' else ISNULL(c.endereco_bairro,'VILA FORMOSA') end ,30))
								+	CONVERT(CHAR(09),	SUBSTRING(REPLICATE('0',8 -LEN(CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)))) + CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)),1,5) + '-' + SUBSTRING(REPLICATE('0',8 -LEN(CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)))) + CONVERT(VARCHAR(9),ISNULL(c.endereco_cep,03453000)),6,3))
								+	CONVERT(CHAR(30),	LEFT(ISNULL(c.endereco_municipio,'SAO PAULO'),30))
								+	CONVERT(CHAR(30),	ISNULL(c.endereco_uf,'SP'))
								+	CONVERT(CHAR(20),	left(ISNULL(e.ErpTargetCD_VEND,'ELIAS'),20))                                         
								+	CONVERT(CHAR(40),	'00' + CONVERT(CHAR(38), '027825200'))
								+	CONVERT(CHAR(18),	case when isnull(a.pessoajuridica,0) = 0 then right(ISNULL(a.cpf_cnpj,'77109970825'),11) else right(ISNULL(a.cpf_cnpj,'57895328000130'),14) end)
								+	CONVERT(CHAR(10),	left(ISNULL(c.endereco_bairro,''),10))
								+	CONVERT(CHAR(10),	'')
								+	CONVERT(CHAR(10),	ISNULL(F.CODIGO,'10'))
								+	CONVERT(CHAR(06),	'')
								--- ELIAS ---

				FROM			POSTSQL.oxan.[public].tbparticipante				a
					LEFT JOIN       POSTSQL.oxan.[public].tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
					LEFT JOIN		POSTSQL.oxan.[public].tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
					LEFT JOIN 		POSTSQL.oxan.[public].tbparticipante			e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
					left join       POSTSQL.oxan.[public].tbparticipante_endereco	c	on c.cdparticipante = a.cdparticipante 
					

					LEFT JOIN		(	select		CODIGO						=			CONVERT(CHAR(10),LEFT(itc.DescricaoResumida , 10))
												,	CDPARTICIPANTE				=			iti.CdParticipante 
										from		postsql.oxan.[public].tbinterface				itf
										inner join  postsql.oxan.[public].tbinterfacetipo			itt on itt.seqinterface			= itf.seqinterface 
										inner join	postsql.oxan.[public].tbinterfacecategoria		itc on itc.seqinterfacetipo		= itt.seqinterfacetipo 
										inner join  postsql.oxan.[public].tbinterfacecategoriaitem	iti on iti.seqinterfacecategoria = itc.seqinterfacecategoria 
										where		itf.SeqInterface		= 5	---> SEQ INTERFACE = 5 | SINTER
										and			itt.SeqInterfaceTipo	= 8	---> SEQ SeqInterfaceTipo = 8 | SINTER INTERFACE TIPO
									)										F	ON	f.cdparticipante = a.cdparticipante
					WHERE			1 = 1 
					  AND	a.cdparticipante in (	select qa.cdparticipante from #base_cliente_sinter qa	)
											
					order by 2
		END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------							
		IF( @INTerface = 5 AND @Arquivo = 'VENDEDOR')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
					SELECT			@SeqArquivoHistorico
								,	0
								,  'HFV10   74222563000160'
											
					UNION
					SELECT			@SeqArquivoHistorico	
								,	ROW_NUMBER() OVER(ORDER BY  pe.cdpessoabluesoft)
								,	'D'
								+	'57895328000130'
								+	CONVERT(CHAR(18), case when isnull(a.pessoajuridica,0) = 0 then right(ISNULL(a.cpf_cnpj,'77109970825'),11) else right(ISNULL(a.cpf_cnpj,'57895328000130'),14) end)
								+	CONVERT(CHAR(13), '01')
								+	CONVERT(CHAR(50), 'FRANCISCO EDUARDO')
								+	CONVERT(CHAR(13), '001') -- +	CONVERT(CHAR(13), 'EQUIPE GERAL')
								+	CONVERT(CHAR(50), 'EQUIPE GERAL')
								+	CONVERT(CHAR(20), isnull(pe.cdpessoabluesoft,2166))
								+	CONVERT(CHAR(50), LEFT(ISNULL(pe.nome_razao, 'FRANCISCO EDUARDO'),50))

					FROM			POSTSQL.oxan.[public].tbparticipante			a
					LEFT JOIN       POSTSQL.oxan.[public].tbpessoabluesoft			pa  on pa.cdpessoabluesoft = a.cdpessoabluesoft
					LEFT JOIN		POSTSQL.oxan.[public].tbpessoabluesoft			pe  on pe.cdpessoabluesoft = pa.cdpessoabluesoft_vendedor
					LEFT JOIN 		POSTSQL.oxan.[public].tbparticipante			e	ON e.cdpessoabluesoft = pe.cdpessoabluesoft
					left join       POSTSQL.oxan.[public].tbparticipante_endereco	c	on c.cdparticipante = a.cdparticipante 
					WHERE			1 = 1 
					AND	(	a.cdparticipante = 1
							or 
							(	ISNULL(pa.cdgrupoeconomico,0) <> 0 
								and pa.bluesoftclientestatus = 1
								and	a.cdparticipante in (	select qa.cdparticipante from #base_cliente_sinter qa	)
							)
						)										

					order by 2
				--if OBJECT_ID('tempdb.dbo.#base_melitta_clientes') is not null drop table #base_melitta_clientes

			
		END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------						
		IF( @INTerface = 5 AND @Arquivo = 'PRODUTO')
			BEGIN
				DELETE FROM oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
				WHERE		SeqArquivoHistorico = @SeqArquivoHistorico 
			
				INSERT oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha
						(		SeqArquivoHistorico 
							,	SeqLinha 
							,	Linha 
						)
				SELECT			@SeqArquivoHistorico
							,	0
							,	CONVERT(CHAR(01),	'H')
							+	CONVERT(CHAR(10),	'CADPROD')
							+	CONVERT(CHAR(08),	@Data,112)
				UNION
				SELECT			@SeqArquivoHistorico
							,	1
							,	CONVERT(CHAR(01),	'I')
							+	CONVERT(CHAR(14),	'57895328000130')
				UNION
				SELECT			@SeqArquivoHistorico
							,	ROW_NUMBER() OVER(ORDER BY  P.pr_cdproduto) + 1 ---->>> ALTERA��O EM 25/08/2020 | Eviar linha com chave 0 duplicada 
							,	CONVERT(CHAR(01),	'V')
							+	CONVERT(CHAR(18),	'74222563000160')
							+	CONVERT(CHAR(30),	'SINTER')
							+	CONVERT(CHAR(14),	P.pr_cdproduto)
							+	CONVERT(CHAR(01),	0)
							+	CONVERT(CHAR(14),	CB.prb_cdbarra_principal)
							+	CONVERT(CHAR(01),	1)
							+	CONVERT(CHAR(100),	P.pr_descricao)
							+	CONVERT(CHAR(40),	'SINTER')
							+	CONVERT(CHAR(30),	'')
							+	CONVERT(CHAR(01),	'A')
							+	CONVERT(CHAR(27),	'')
				FROM		POSTSQL.oxan.[public].tbproduto					p 
				INNER JOIN  POSTSQL.oxan.[public].tbprodutobluesoft			CB ON CB.prb_cdprodutobluesoft_pk = p.prb_cdprodutobluesoft 
				INNER JOIN  POSTSQL.oxan.[public].tbforca_venda_fabricante  f on f.fv_fabricante_cdpessoabluesoft = cb.prb_cdpessoabluesoft_fabricante
				WHERE		f.fv_fabricante_Seq = 17
				AND			P.pr_status			=	1
				AND			p.pr_embalagemestoque	=	'UN'
			
			END
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				


		SET @i = @i + 1	
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
		--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------				
	END
	SELECT 'PACOTES GERADOS PARA O DIA' + CONVERT(CHAR(8), @DataGeracao, 112) 



	---->> EXCLUS�O DE MOVIMENTOS ANTIGOS 
	declare @data_mv_so smalldatetime = convert(smalldatetime, convert(char(8), getdate() - 90, 112))



	insert into OXAN_eST.DBO.SoInterfaceInfoArquivoHistorico
		(		DtLog_insert_so
			,	SeqTipoArquivo
			,	SeqArquivoHistorico
			,	DataGeracao
			,	DataEnvio
			,	DataConfirmacao
			,	cd_usr_geracao
			,	cd_usr_envio
			,	NomeArquivo
			,	PathArquivo
			,	Data
			,	DataFim
			,	DtLogInsert
		) 
	select		getdate()
			,	x.SeqTipoArquivo
			,	x.SeqArquivoHistorico
			,	x.DataGeracao
			,	x.DataEnvio
			,	x.DataConfirmacao
			,	x.cd_usr_geracao
			,	x.cd_usr_envio
			,	x.NomeArquivo
			,	x.PathArquivo
			,	x.Data
			,	x.DataFim
			,	x.DtLogInsert
	from		oxan_Est.dbo.TbInterfaceInfoArquivoHistorico	x
	where		not exists (	select	1 
								from	OXAN_EST.DBO.soInterfaceInfoArquivoHistorico a 
								where	a.SeqArquivoHistorico = x.SeqArquivoHistorico 
							)
	AND			X.DataGeracao <= @data_mv_so 


	insert into  oxan_est.dbo.SoInterfaceInfoArquivoHistoricoLinha 
		(		DtLog_insert_so
			,	SeqLinha 
			,	SeqArquivoHistorico 
			,	Linha 
		)
	select		getdate() 
			,	l.SeqLinha 
			,	l.SeqArquivoHistorico 
			,	l.Linha 
	from		oxan_est.dbo.TbInterfaceInfoArquivoHistoricoLinha	l
	inner join	oxan_est.dbo.SoInterfaceInfoArquivoHistorico		h on h.SeqArquivoHistorico = l.SeqArquivoHistorico  
	where		1 = 1
	and			not exists (	select	1
								from	OXAN_EST.DBO.SoInterfaceInfoArquivoHistoricoLinha x 
								where	x.SeqArquivoHistorico = l.SeqArquivoHistorico 
								  and	x.SeqLinha = l.SeqLinha 
							)
	AND			H.DtLog_insert_so >= GETDATE() -1 


	/*
	DELETE		A
	FROM		oxan_est.dbo.TbInterfaceInfoArquivoHistoricoLinha A
	INNER JOIN	oxan_est.dbo.SoInterfaceInfoArquivoHistoricoLinha B ON B.SeqArquivoHistorico = A.SeqArquivoHistorico  AND B.SeqLinha = A.SeqLinha 
	INNER JOIN  OXAN_EST.DBO.SoInterfaceInfoArquivoHistorico X ON X.SeqArquivoHistorico = B.SeqArquivoHistorico 
	WHERE		B.SeqArquivoHistorico = A.SeqArquivoHistorico 
	AND			B.SeqLinha = A.SeqLinha 



	delete		A
	from		OXAN_EST.DBO.TBInterfaceInfoArquivoHistorico a
	INNER JOIN  OXAN_eST.DBO.SoInterfaceInfoArquivoHistorico B ON B.SeqTipoArquivo = A.SeqTipoArquivo AND B.SeqArquivoHistorico = A.SeqArquivoHistorico 
	WHERE		B.SeqTipoArquivo = A.SeqTipoArquivo 
	AND			B.SeqArquivoHistorico = A.SeqArquivoHistorico 
	*/

UPDATE oxan_est.dbo.TbINTerfaceInfoArquivoHistoricoLinha 
SET Linha = REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(
            REPLACE(LINHA, '�', 'C'), '�', 'c'),
            '�', 'A'), '�', 'A'),
            '�', 'A'), '�', 'A'),
            '�', 'A'), '�', 'A'),
            '�', 'A'), '�', 'A'),
            '�', 'E'), '�', 'E'),
            '�', 'E'), '�', 'E'),
            '�', 'I'), '�', 'I'),
            '�', 'O'), '�', 'O'),
            '�', 'O'), '�', 'O'),
            '�', 'O'), '�', 'O'),
            '�', 'U'), '�', 'U'),
            '�', 'U'), '�', 'U'),
            '�', 'N'), '�', 'N')
WHERE SeqArquivoHistorico = @SeqArquivoHistorico
GO


