-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 

	--drop table if exists tbforca_venda_fab_meta_res_cliente_grupo;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_fab_meta_resultado_cliente_grupo' 
				) = 0
			)	
	then 
		create table tbforca_venda_fab_meta_res_cliente_grupo
			(
					dtlog_insert			timestamp default (current_timestamp)
				,	dtlog_update			timestamp
				,	seqinterface 			int
				,	fv_fab_meta_cd			int 
				,	fv_fab_meta_grupo_cd	int
				,	cdparticipantecliente	int
				,	embalagemestoqueqtde	numeric(17,4)
				,	embalagemcompraqtde		numeric(17,4)
				,   fv_fab_meta_res_cliente_grupo_seq serial
				,	constraint pkforca_venda_fab_meta_res_cliente_grupo primary key (seqinterface, fv_fab_meta_cd, fv_fab_meta_grupo_cd,  cdparticipantecliente)
			);
	end if;


	--drop table if exists tbforca_venda_fab_meta_res_cliente_mix;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_fab_meta_res_cliente_mix' 
				) = 0
			)	
	then 
		create table tbforca_venda_fab_meta_res_cliente_mix
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	dtlog_update				timestamp
				,	seqinterface 				int
				,	fv_fab_meta_cd				int 
				,	cdparticipantecliente		int
				,	fv_fab_meta_mix_cd	    	int
				,   fv_fab_meta_grupo_cd_qtde	int 

				,	constraint pkforca_venda_fab_meta_res_cliente_mix primary key (seqinterface, fv_fab_meta_cd, cdparticipantecliente, fv_fab_meta_mix_cd)
			);
	end if;

	--drop table if exists tbforca_venda_fab_meta_res_vendedor;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_fab_meta_res_vendedor' 
				) = 0
			)	
	then 
		create table tbforca_venda_fab_meta_res_vendedor
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	dtlog_update				timestamp
				,	seqinterface 				int
				,	fv_fab_meta_cd				int 
				,	cdparticipantevendedor		int
				,	fv_fab_meta_mix_cd	    	int
				,	qtde_positivacao			int

				,	constraint pkforca_venda_fab_meta_res_vendedor primary key (seqinterface, fv_fab_meta_cd, cdparticipantevendedor	, fv_fab_meta_mix_cd)
			);
	end if;


	--drop table if exists tbforca_venda_fab_meta_res;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_fab_meta_res' 
				) = 0
			)	
	then 
		create table tbforca_venda_fab_meta_res
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	dtlog_update				timestamp
				,	seqinterface 				int
				,	fv_fab_meta_cd				int 
				,	fv_fab_meta_mix_cd	    	int
				,	qtde_positivacao			int

				,	constraint pkforca_venda_fab_meta_res primary key (seqinterface, fv_fab_meta_cd, fv_fab_meta_mix_cd)
			);
	end if;	




	--drop table if exists tbforca_venda_meta_info;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_meta_info' 
				) = 0
			)	
	then 

		CREATE TABLE tbforca_venda_meta_info 
			(
					fv_meta_cd 			int
				,	fv_fab_meta_cd 		int
				,	fv_fab_meta_mix_cd 	int
				,	constraint pkforca_venda_meta_info primary key (fv_meta_cd, fv_fab_meta_cd, fv_fab_meta_mix_cd)
			);
	end if;	

end$$
;


	
	insert into tbforca_venda_fab_meta_mix (fv_fab_meta_cd, fv_fab_meta_mix_cd, fv_fab_meta_mix_descricao, fv_fab_meta_mix_grupo_qtde_minima)
		select 2026001, 99, 'POS GERAL', 0
		WHERE NOT EXISTS (
			SELECT 1
			FROM tbforca_venda_fab_meta_mix
			WHERE fv_fab_meta_cd = 2026001
			AND fv_fab_meta_mix_cd = 99
		);


	insert into tbforca_venda_meta_info (fv_meta_cd, fv_fab_meta_cd, fv_fab_meta_mix_cd)
		SELECT 254, 2026001, 7
		WHERE NOT EXISTS (
			SELECT 1
			FROM tbforca_venda_meta_info
			WHERE fv_meta_cd = 254
			AND fv_fab_meta_cd = 2026001
			AND fv_fab_meta_mix_cd = 7
		);