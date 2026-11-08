-- Active: 1773758617277@@127.0.0.1@5432@oxan
---select current_timestamp; SELECT current_setting('timezone'); SET timezone = 'America/Sao_Paulo';

/*

fazendo o back dos campos do modelo antigo
select * from back_tbfaturamento_forca_venda 
select * into back_tbfaturamento_forca_venda from tbfaturamento_forca_venda  limit 10
select * into back_tbfaturamento_forca_venda_origem from tbfaturamento_forca_venda_origem limit 10
select * into back_tbfaturamento_forca_venda_status from tbfaturamento_forca_venda_status limit 10
select * into back_tbfaturamento_forca_venda_item from tbfaturamento_forca_venda_item limit 10
select * from tbfaturamento_bluesoft
*/



do $$
begin 

	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft' 
			  and   column_name = 'data_emissao'
			  and   data_type = 'date'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbfaturamento_bluesoft alter column data_emissao type timestamp 
			;
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft' 
			  and   column_name = 'descontofinanceiro'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbfaturamento_bluesoft add descontofinanceiro numeric(17,4)
			;
	end if;
	
	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft_tipo' 
			  and   column_name = 'pedido_tipo_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			
			alter table tbfaturamento_bluesoft_tipo add pedido_tipo_cd int
			;
	end if;

		--- updates
		--select * from tbfaturamento_bluesoft_tipo
		update tbfaturamento_bluesoft_tipo set pedido_tipo_cd = 1 where fat_blue_tipo_cd = 10
		;
		update tbfaturamento_bluesoft_tipo set pedido_tipo_cd = 2 where fat_blue_tipo_cd = 20
		;
	



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft_status' 
			  and   column_name = 'pedido_status_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			
			alter table tbfaturamento_bluesoft_status add pedido_status_cd int
			;
	end if;

	update tbfaturamento_bluesoft_status set pedido_status_cd = 18 where fat_blue_status_cd = 90; -- CANCELADO
	update tbfaturamento_bluesoft_status set pedido_status_cd = 16 where fat_blue_status_cd = 70; -- ENTREGUE
	update tbfaturamento_bluesoft_status set pedido_status_cd = 6 where fat_blue_status_cd = 55; -- FATURADO POR NOTA FISCAL
	
	update tbfaturamento_bluesoft_status set pedido_status_cd = 9 where fat_blue_status_cd = 10; -- EM DIGITACAO
	update tbfaturamento_bluesoft_status set pedido_status_cd = 2 where fat_blue_status_cd = 30; -- FECHADO
	update tbfaturamento_bluesoft_status set pedido_status_cd = 19 where fat_blue_status_cd = 27; -- EM ANALISE DE CREDITO
	update tbfaturamento_bluesoft_status set pedido_status_cd = 11 where fat_blue_status_cd = 20; -- AGUARDANDO ANALISE GERENCIAL
	update tbfaturamento_bluesoft_status set pedido_status_cd = 3 where fat_blue_status_cd = 40; -- EM SEPARACAO 
	update tbfaturamento_bluesoft_status set pedido_status_cd = 4 where fat_blue_status_cd = 45; -- EM SEPARACAO 	
	update tbfaturamento_bluesoft_status set pedido_status_cd = 12 where fat_blue_status_cd = 25; -- EM ANALISE GERENCIAL


	drop table if exists tbfaturamento_bluesoft_fv_status;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_fv_status' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfaturamento_bluesoft_fv_status
			(
					dtlog_insert				timestamp default (current_timestamp) 
				,	dtlog_update				timestamp 
				,	pedido_status_cd 			int
				,	pedido_status_descricao  	varchar(60)
				,	constraint pkfaturamento_bluesoft_fv_status primary key (pedido_status_cd)
			)
		;
		
	end if;


	drop table if exists tbfaturamento_bluesoft_fv;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_fv' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- select * from tbforca_venda_prazopgto
		create table tbfaturamento_bluesoft_fv
			(
					dtlog_insert				timestamp default (current_timestamp) 
				,	dtlog_update				timestamp 
				,	numeropedido_fv				int
				,	cdpessoabluesoft_vendedor	int
				,	tabelapreco_cd				int 
				,	tabelapreco_versao_cd		int
				,	fv_prazopgto_cd				int
				,	data_emissao				timestamp 
				,   cdgrupoeconomico 			int		
				,	origem_pedido				varchar(50)
				,	pedido_tipo_cd				int 
				,	descontoFinanceiro			numeric(17,4)
				,	constraint pkfaturamento_bluesoft_fv primary key (numeropedido_fv)
			)
		;

		
		
	end if;


	drop table if exists tbfaturamento_bluesoft_fv_cliente;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_fv_cliente' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfaturamento_bluesoft_fv_cliente
			(		
					dtlog_insert						timestamp default (current_timestamp)
				,	dtlog_update						timestamp 
				,	numeropedido 						int
				,	numeropedido_fv 					int
				,	cdpessoabluesoft_cliente			int
				,	pedido_status_cd					int 
				,	pedido_status_descricao_redshift	varchar(60)
				,	constraint pkfaturamento_bluesoft_fv_cliente primary key (numeropedido, numeropedido_fv, cdpessoabluesoft_cliente)
			)
		;
		
	end if;

	drop table if exists tbfaturamento_bluesoft_fv_nf;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_fv_nf' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfaturamento_bluesoft_fv_nf
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	dtlog_update				timestamp 
				,	numeropedido 				int
				,	numeropedido_fv 			int
				,	cdpessoabluesoft_cliente	int	
				,	df_nf_seq_blue				int
				,	df_nf_numero				int
				,	df_nf_tipo					int
				,	df_valor					numeric(13,2)
				,	df_data_emissao				date 
				,	constraint pkfaturamento_bluesoft_fv_nf primary key (numeropedido, numeropedido_fv, cdpessoabluesoft_cliente, df_nf_seq_blue)
			)
		;
		
	end if;	



	drop table if exists tbfaturamento_bluesoft_fv_item;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_fv_item' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfaturamento_bluesoft_fv_item
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	dtlog_update				timestamp 
				,	numeropedido 				int
				,	numeropedido_fv 			int
				,	cdpessoabluesoft_cliente	int	
				,	prb_cdprodutobluesoft		int 
				,	qtde_pedida					int
				,	qtde_bonificada 			int
				,	qtde_separada				int
				,	valor_preco					numeric(13,2)
				,	valor_preco_final			numeric(13,2)
				,	valor_total					numeric(13,2)
				,	valor_total_separado		numeric(13,2)
				,	constraint pkfaturamento_bluesoft_fv_item primary key (numeropedido, numeropedido_fv, cdpessoabluesoft_cliente, prb_cdprodutobluesoft)
			)
		;
		
	end if;	



	

end$$	

;

UPDATE tbcrm_sorteio_temporada set  crm_so_temp_status = 0 where crm_so_temp_cd = 1
;
delete from tbcrm_sorteio_temporada  where crm_so_temp_cd = 2;
insert into tbcrm_sorteio_temporada 
	(crm_so_temp_cd, crm_so_temp_descricao, crm_so_temp_valor_minimo, crm_so_temp_data_ini, crm_so_temp_data_fim, crm_so_temp_status)
		SELECT 2, 'Temporada 2026/1', 100, '2025-05-15', '2025-07-14', 1
			WHERE NOT EXISTS (SELECT 1 FROM tbcrm_sorteio_temporada WHERE  crm_so_temp_cd = 2 )

;
delete from tbcrm_sorteio  where crm_so_temp_cd = 2;
insert into tbcrm_sorteio 			
	(crm_so_cd, crm_so_temp_cd, crm_so_descricao, crm_so_data_ini, crm_so_data_fim, crm_so_data_sorteio, crm_so_tipo_cd, crm_numero_oficial)
		select 20, 2, 'SORTEIO COPA 1', '2026-03-01', '2025-05-15', '2025-07-14', 1, null
			WHERE NOT EXISTS (SELECT 1 FROM tbcrm_sorteio WHERE crm_so_cd = 20 )



/*
select * from tbfaturamento_bluesoft where dtlog_update >= '2026-04-30 16:41'
select * from tbfaturamento_bluesoft_fv limit 10
select * from tbfaturamento_bluesoft_fv_cliente limit 10
select * from tbfaturamento_bluesoft_fv_nf
select * from tbfaturamento_bluesoft_fv_status limit 10
select * from tbgrupoeconomico
select * from tbforca_venda_pedido_cliente
select * from tbdocumentofiscal limit 10


*/
;
select * from tbfaturamento_bluesoft_status