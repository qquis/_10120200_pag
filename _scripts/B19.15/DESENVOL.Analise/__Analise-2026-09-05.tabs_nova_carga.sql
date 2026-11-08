select * from tbzanthustab_mercadoria
select * from tbzanthustab_mercadoria_tipo_venda
select * from tbzanthustab_mercadoria_tipo_venda_qtde 
select * from TbZanthustab_produto_decomposicao
select * from TbZanthustab_produto_decomposicao_insum
select * from tbzanthustabtributacao
select * from tbzanthustabtributacao_cod_tributacao 
select * from tbzanthus_tributacao_nfce

drop table tbproduto_zanthus_mercadoria 
create table tbproduto_zanthus_mercadoria 
	(
			dtlog_insert			timestamp default(current_timestamp)
		,	dtlog_update			timestamp 
		,	pr_cdproduto 						int
		,	prb_cdprodutobluesoftunitario		int
		,	prb_cdprodutobluesoft 				int
		,	cod_mercadoria						varchar(17)
		,	cod_loja							int
		,	controle							varchar(3)
		,	descricao							varchar(50)
		,	desc_abr							varchar(25)
		,	cod_departamento					int
		,	fator_seguranca_venda_estoque 		numeric(17,4)
		,	unidade_venda						char(2)
		,	quantidade_embalagem				numeric(17,4)
			
		,	aliquota_interna_icms				numeric(17,4)
		,	data_cadastro						timestamp
		,	data_ultima_alteracao				timestamp
		,	flginativo 							char(1)
		,	peso_bruto							numeric(12,3)
		,	peso_liquido						numeric(17,4)
		,	constraint pkproduto_zanthus_mercadoria primary key(cod_mercadoria)
		,	constraint uqproduto_zanthus_mercadoria unique(pr_cdproduto, prb_cdprodutobluesoftunitario, prb_cdprodutobluesoft, cod_mercadoria)
	)



create table tbproduto_zanthus_decomposicao
	(
			dtlog_insert			timestamp default(current_timestamp)
		,	dtlog_update			timestamp 
		,	pr_cdproduto 			int
		,	prb_cdprodutobluesoft	int
		,	cod_mercadoria			varchar(17)
		,	cod_loja				int
		,	controle				varchar(3)
		,	forma_decomposicao		char(1)
		,	tipo_decomposicao		char(3)
		,	usuario					varchar(35)
		,	data_cadastro			timestamp
		,	data_ultima_alteracao	timestamp 
		,	pkzanthus_produto_decomposicao primary key(cod_mercadoria)
	)

create table tbproduto_zanthus_decomposicao_insum
		(	
			dtlog_insert			timestamp default(current_timestamp)
		,	dtlog_update			timestamp 
		,	pr_cdproduto 			int
		,	prb_cdprodutobluesoft	int
		,	cod_loja				int
		,	cod_mercadoria			varchar(17)
		,	cod_insumo				varchar(17)
		,	usuario					varchar(35)
		,	data_cadastro			timestamp 
		,	data_ultima_alteracao	timestamp
		,	percentual_insumo		numeric(13,2)
		,	quantidade_insumo		numeric(17,4)
		,	pkzanthus_produto_decomposicao_insum primary key(cod_mercadoria, cod_insumo)
		)


select * from tbfc_figurafiscal_produto
select * from tbfc_regrafiscal_nfce_produto

create table tbproduto_zanthus_nfce 
	(
			dtlog_insert						timestamp default(current_timestamp)
		,	dtlog_update						timestamp 
		,	pr_cdproduto 						int
		,	pr_cdproduto 						int
		,	prb_cdprodutobluesoftunitario		int
		,	prb_cdprodutobluesoft 				int
		,	cod_ncm								int
		,	cod_ex								varchar(15)
		,	cest								int
		,	cfop 								int
		,	cod_tributacao_mercadoria			int
		,	cod_situacao_tributaria				varchar(4)
		,	aliquota_icms						numeric(17,4)
		,	aliquota_internta_icms 				numeric(17,4)
		,	percentual_reduz_b_calculo			numeric(17,4)
		,	cod_sit_trib_pis 					varchar(3)
		,	aliquota_pis						numeric(17,4)
		,	cod_sit_trib_cofins					varchar(3)
		,	aliquota_cofins						numeric(17,4)
		,	codigo_beneficio_fiscal				varchar(10)
		,	cod_sit_tributaria_ibs_cbs 			char(4)
		,	cod_class_tributaria_ibs_cbs		int
		,	per_aliquota_ibs_uf					numeric(17,4)
		,	per_reducao_aliquota_ibs_uf			numeric(17,4)
		,	per_diferimento_ibs_mun				numeric(17,4)
		,	per_aliquota_ibs_mun				numeric(17,4)
		,	per_reducao_aliquota_ibs_mun		numeric(17,4)
		,	per_aliquota_cbs					numeric(17,4)
		,	per_diferimento_cbs					numeric(17,4)
		,	per_reducao_aliquota_cbs			numeric(17,4)	
		,	per_cred_presumido_ibs_mono			numeric(17,4)	
		,	per_cred_presumido_cbs_mono			numeric(17,4)
		,	info_complementar 					numeric(17,4)

	)
	
		
