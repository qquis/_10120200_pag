-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 


drop table if exists tbzanthus_carga;
drop table if exists tbzanthus_carga_produto;
drop table if exists tbzanthus_carga_processos;
--drop table if exists tbzanthus_carga_tipo;
--drop table if exists tbzanthus_carga_status;
--select * from pg_indexes where tablename = 'tbproduto_composicao'
--alter table tbproduto_composicao add constraint pkproduto_composicao primary key (prb_cdprodutobluesoft_unitario, prb_cdprodutobluesoft);
--select * from tbprodutobluesoft_composicao





if ((	SELECT 	count(*)
		FROM    information_schema.columns
		WHERE   table_name = 'tbfaturamento_controle'
		  AND   column_name = 'processamento_pendente'
	) = 0
   	)	
then 
	alter table tbfaturamento_controle add processamento_pendente smallint;
end if;

if ((	SELECT 	count(*)
		FROM    information_schema.columns
		WHERE   table_name = 'tbfaturamento_controle'
		  AND   column_name = 'cdpessoabluesoft_vendedor'
	) = 0
   	)	
then 
	alter table tbfaturamento_controle add cdpessoabluesoft_vendedor int;
end if;



if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbsistema_versao' 
			) = 0
	   	)	
then 
		--drop table tbsistema_versao
		create table tbsistema_versao (
				  dtlog_insert                                      timestamp default(current_timestamp)
				, dtlog_update                                      timestamp without time zone
				, versao_ecosystem                                  int
				, versao			                                int
				, versao_commit                                     int
				, versao_desktop_revision							  int
				, constraint pksistema_versao primary key (versao_ecosystem)
				);
		insert into tbsistema_versao (versao_ecosystem, versao, versao_commit, versao_desktop_revision)
		    select 2019, 16, 10, 15
			where not EXISTS 
					(select 1 from tbsistema_versao 
							where versao_ecosystem = 2019 
							and versao = 16 
							and versao_commit = 10 
							and versao_desktop_revision = 15
							);
end if;


if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbsistema_versao_script_db' 
			) = 0
	   	)	
then 
		--drop table tbsistema_versao_script_db
		create table tbsistema_versao_script_db (
				  dtlog_insert                                      timestamp default(current_timestamp)
				, dtlog_update                                      timestamp without time zone
				, seq												serial
				, versao_ecosystem                                  int
				, script_name                                       varchar(110)
			
				, constraint pksistema_versao_script_db primary key (versao_ecosystem, script_name)
				);
		insert into tbsistema_versao_script_db (versao_ecosystem, script_name)
		    select 2019, 'B19.16.01.0000.imp.sql'
			where not EXISTS 
					(select 1 from tbsistema_versao_script_db 
							where versao_ecosystem = 2019 
							and script_name = 'B19.16.01.0000.imp.sql'
							);
end if;



if ((	SELECT 	count(*)
		FROM    information_schema.columns
		WHERE   table_name = 'tbfc_regrafiscal_nfce_produto_tipo'
		  AND   column_name = 'nfce_produto_padrao_pdv_consumidor'
	) = 0
   	)	
then 
	alter table tbfc_regrafiscal_nfce_produto_tipo add nfce_produto_padrao_pdv_consumidor smallint;
	
	update tbfc_regrafiscal_nfce_produto_tipo 
	set nfce_produto_padrao_pdv_consumidor = 1 
	where nfce_produto_tipo_cd = 1;
end if;

if ((	SELECT 	count(*)
			from pg_indexes 
			where tablename = 'tbproduto_composicao'
			  and indexname = 'pkproduto_composicao'
			  and indexdef = 'CREATE UNIQUE INDEX pkproduto_composicao ON public.tbproduto_composicao USING btree (prbc_bluesoft_seq)'
			) >= 1
	   	)	
	then 
			alter table tbproduto_composicao drop constraint pkproduto_composicao;

	end if;

if ((	SELECT 	count(*)
			from pg_indexes 
			where tablename = 'tbproduto_composicao'
			  and indexname = 'uqproduto_composicao_1'
			  and indexdef = 'CREATE UNIQUE INDEX uqproduto_composicao_1 ON public.tbproduto_composicao USING btree (prb_cdprodutobluesoft_unitario, prb_cdprodutobluesoft)'
			) >= 1
	   	)	
	then 
			alter table tbproduto_composicao drop constraint uqproduto_composicao_1;
	end if;

if ((	SELECT 	count(*)
			from pg_indexes 
			where tablename = 'tbproduto_composicao'
			  and indexname = 'pkproduto_composicao'
			  and indexdef = 'CREATE UNIQUE INDEX pkproduto_composicao ON public.tbproduto_composicao USING btree (prb_cdprodutobluesoft_unitario, prb_cdprodutobluesoft)'
			) = 0
	   	)	
	then 
		alter table tbproduto_composicao add constraint pkproduto_composicao primary key (prb_cdprodutobluesoft_unitario, prb_cdprodutobluesoft);
	end if;


if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_carga_status' 
			) = 0
	   	)	
	then 
		-- drop table tbzanthus_carga
		create table tbzanthus_carga_status (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				carga_status_cd 								  int,
				carga_status_descricao                            varchar(30),
				constraint pkzanthus_carga_status primary key (carga_status_cd)
			);
			insert into tbzanthus_carga_status (carga_status_cd, carga_status_descricao) select 1, 'Aguardando Processamento' where not exists (select 1 from tbzanthus_carga_status where carga_status_cd = 1);
			insert into tbzanthus_carga_status (carga_status_cd, carga_status_descricao) select 2, 'Em Processamento' where not exists (select 1 from tbzanthus_carga_status where carga_status_cd = 2);
			insert into tbzanthus_carga_status (carga_status_cd, carga_status_descricao) select 3, 'Processamento Concluído' where not exists (select 1 from tbzanthus_carga_status where carga_status_cd = 3);
			insert into tbzanthus_carga_status (carga_status_cd, carga_status_descricao) select 9, 'Processamento Falhou' where not exists (select 1 from tbzanthus_carga_status where carga_status_cd = 9);
	end if;

if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_carga' 
			) = 0
	   	)	
	then 
		-- drop table tbzanthus_carga
		create table tbzanthus_carga (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				carga_uuid 										  varchar(15),
				carga_seq                                         serial,
				carga_data                                        date default(current_date),
				carga_status_cd                                   int,
				carga_hora_ini                                    timestamp default(current_timestamp),
				carga_hora_fim                                    timestamp,
				carga_tipo_cd                                     int,
				carga_usr_seq_create                              int,
				constraint pkzanthus_carga primary key (carga_uuid)
				,constraint uqzanthus_carga_carga_seq unique (carga_seq, carga_uuid)

			);

	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_carga_tipo' 
			) = 0
	   	)	
	then 
		create table tbzanthus_carga_tipo (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				carga_tipo_cd                                     int,
				carga_tipo_descricao                              varchar(100),
				constraint pkzanthus_carga_tipo primary key (carga_tipo_cd)
			);
		insert into tbzanthus_carga_tipo (carga_tipo_cd, carga_tipo_descricao) SELECT 1, 'Atualização Padrão' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_carga_tipo WHERE carga_tipo_cd = 1);
		insert into tbzanthus_carga_tipo (carga_tipo_cd, carga_tipo_descricao) SELECT 2, 'Atualização Fiscal' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_carga_tipo WHERE carga_tipo_cd = 2);
		insert into tbzanthus_carga_tipo (carga_tipo_cd, carga_tipo_descricao) SELECT 3, 'Atualização Preços Pendentes' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_carga_tipo WHERE carga_tipo_cd = 3);
		insert into tbzanthus_carga_tipo (carga_tipo_cd, carga_tipo_descricao) SELECT 4, 'Atualização Geral' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_carga_tipo WHERE carga_tipo_cd = 4);


	end if;


if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_carga_produto' 
			) = 0
	   	)	
	then 
		create table tbzanthus_carga_produto (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				carga_uuid                                        varchar(15),
				carga_produto_seq                                 serial,
				pr_cdproduto                                      int,
				prb_cdprodutobluesoftunitario                     int, 
				prb_cdprodutobluesoft                             int, 
				cod_mercadoria                                    varchar(17),
				constraint pkzanthus_carga_produto primary key (carga_produto_seq, cod_mercadoria)

			);

	end if;


if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_carga_processos' 
			) = 0
	   	)	
	then 
		-- drop table tbzanthus_carga
		create table tbzanthus_carga_processos (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				carga_uuid                                        varchar(15),
				carga_processo_seq                                serial,
				carga_processo			                          varchar(255),
				carga_processo_start                              timestamp,
				carga_processo_end                                timestamp,
				constraint pkzanthus_carga_processos primary key (carga_uuid, carga_processo_seq)

			);

	end if;


end$$	
;




/*
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
*/

/*MENUS*/

		--select * from tbsistema_acesso where sis_cd = 5 and sis_ac_href like '%operacional/zanthus%'


		/*TABELA ICMS*/
		select public._local_acesso_web(5, 1212, 'Tabela de Regra ICMS', 'm1212', 1200, '/pages/cadastro/zanthus/tabregraicms')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1212, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1212 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)
		;


		/*MENU CARGA ZANTHUS*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3922;
		select public._local_acesso_web(5, 3922, 'Carga Zanthus', 'm3922', 3400, '/pages/operacional/zanthus/carga')
			;
				
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3922, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3922 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)
		;


		/*AJUSTE DO MENU DE PRODUTOS*/
		update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Produto' where sis_ac_gmenu_cd = 1150
		;

		update tbsistema_acesso set     sis_ac_gmenu_cd = 1150     ,   sis_ac_descricao = 'Lista Produto Prime' where sis_ac_cd = 1110;
		update tbsistema_acesso set     sis_ac_gmenu_cd = 1150     ,   sis_ac_descricao = 'Grupo de Produto' where sis_ac_cd = 1115;

		update tbsistema_acesso set     sis_ac_descricao = '* * Produto' where sis_ac_cd = 1150;





/*
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
*/

/*COMPOSICAO
	Exclusão dos registros da tabela de composição
	Imediatamente depois deve ser fazer a importação geral de produtos
*/



	delete from tbproduto_composicao;
	delete from tbprodutobluesoft_composicao;












/* VERSAO
*/

update tbsistema_versao set versao_commit = 12 where versao_ecosystem = 2019;


