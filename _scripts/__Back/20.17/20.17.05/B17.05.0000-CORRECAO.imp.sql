

/*
	--drop table if exists tbfaturamento_vip
	select tipo_pedido, antifraude_session_id, tipo_fiscal,  * from tbfaturamento_vip
	delete from tbfaturamento_vip
	select * from tbfaturamento_vip

select * from tbfaturamento_vip_compra_status
select * from tbnotificacao_participante

select * from tbnotificacao_grupo
select * from tbnotificacao_send limit 10
select * from tbnotificacao where notificacao_cd = 1000030091

select * from tbparticipante_vip

select * from tbnotificacao_send
select * from tbnotificacao_send_message
select * from tb

delete from tbnotificacao_send
delete from tbnotificacao_send_message

SELECT   	p.cdparticipante
      ,    	p.nome_razao 
      ,    	coalesce(p.email_main, '') as email_main
      ,    	cast(coalesce(p.celular_dd,0) as varchar(2)) as celular_dd 
      ,    	cast(coalesce(p.celular_numero,0) as varchar(15)) as celular_numero
FROM          tbnotificacao_participante i 
INNER JOIN    tbparticipante p on p.cdparticipante = i.cdparticipante
  WHERE       i.notificacao_cd = 1000030091
UNION
SELECT		0 as cdparticipante
		,	'GRUPO' as nome_razao
		,	'suporte@oxan.com.br' as email_main
		,	cast('' as varchar(2))  as celular_dd
		,	cast(notificacao_gp_whats as varchar(20)) as celular_numero
from 		tbnotificacao_grupo g
where		g.notificacao_cd = 1000030091


select * from tbnotificacao
select * from tbfaturamento_vip_compra_status
SELECT id, compra_status_id FROM TBFATURAMENTO_VIP








delete from tbnotificacao_send; delete from tbnotificacao_send_message; delete from tbfaturamento_vip_notificacao

insert into tbfaturamento_vip_notificacao
			(
				 	id					
				,	notificacao_cd		
				,	compra_status_id 	
				,	notificado

			)
select 			f.id
			,	s.notificacao_cd 
			,	f.compra_status_id
			,	0
from 			tbfaturamento_vip f
left join 		tbfaturamento_vip_compra_status s on s.compra_status_id = f.compra_status_id
where			1 = 1 
and             f.created >= date_trunc('day', current_timestamp) -- primeira hora do dia corrente
and				not exists
						( 	select 	1 
						 	from 	tbfaturamento_vip_notificacao aa
							where	1 = 1
							and     aa.id = f.id
							and     aa.compra_status_id = f.compra_status_id
							and     aa.notificacao_cd = s.notificacao_cd
						)
and				coalesce(s.notificacao_cd ,0) > 0


select date_trunc('day', current_timestamp)
			
--select * from tbfaturamento_vip
--select * from tbfaturamento_vip_compra_status

select 	n.id
	,	f.data_entrega
	,	f.qtd_itens
	,	f.qtd_produtos
	,	coalesce(f.valor_final ,0) as valor_final 
from 	tbfaturamento_vip_notificacao n
inner join tbfaturamento_vip f on f.id = n.id

select * from tbfaturamento_vip_notificacao
select * from tbparticipante_vip
select * from tbfaturamento_vip limit 10


SELECT * FROM TBFATURAMENTO_VIP WHERE DTLOG_INSERT >= '2023-03-06 01:01:01'
SELECT * FROM TBFATURAMENTO_VIP_NOTIFICACAO
select * from tbfaturamento_vip_compra_status
update tbfaturamento_vip_compra_status set notificacao_cd = 1000510010 where compra_status_id = 15


select * from tbparticipante_vip where vip_cpf_cnpj like '%46487533807'

select 			f.id
			,	s.notificacao_cd 
			,	f.compra_status_id
			,	s.compra_status_descricao 
			,	s.notificacao_cd 
			,	f.*
from 			tbfaturamento_vip f
left join 		tbfaturamento_vip_compra_status s on s.compra_status_id = f.compra_status_id
where			1 = 1 
--and             f.created >= date_trunc('day', current_timestamp) -- primeira hora do dia corrente
and 			f.id = 1001520


select * from tbnotificacao_grupo
select * from tbfaturamento_vip_compra_status
update tbnotificacao_grupo set notificacao_gp_whats = '120363176123541455' where notificacao_cd = 1000510010

select * from tbsistema_batch_nucleo_procedimento
select 		sis_nucleo_cd_fk
		, 	sis_nucleo_prc_cd
		, 	sis_nucleo_prc_descritivo
		, 	sis_nucleo_prc_tipo
		, 	dateadd_ini
		, 	dateadd_fim
		, 	data_default_ini
		, 	data_default_fim
		,	permite_execucao_manual 
		,	sis_nucleo_prc_descricao
from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 95011


*/






drop table if exists tbparticipante_vip;


do $$
begin 



	/*

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbnotificacao_participante' 
			  and   column_name = 'grupo_whats'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbnotificacao_participante add grupo_whats smallint default(0);
				
	end if;

	*/

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbparticipante_vip' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		drop table if exists tbparticipante_vip;
		create table tbparticipante_vip
					(		dtlog_insert timestamp default (current_timestamp)
						,	dtlog_update timestamp default (current_timestamp)
						,	vip_id int
						,	vip_cliente_id	varchar(100)		
						,	cdparticipante 	int
						,	vip_cpf_cnpj varchar(14)
						,	vip_cpf	varchar(14)				
						,	vip_cnpj varchar(14)					
						,	vip_nome varchar(60)
						,	vip_nome_completo varchar(60)
						,	vip_sobre_nome	varchar(60)							
						,	vip_email	varchar(60)				
						,   vip_data_nascimento	date
						,	constraint pkparticipante_vip primary key (vip_cliente_id)
					)
					;
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_vip' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- drop table if exists tbfaturamento_vip
		
		CREATE TABLE tbfaturamento_vip (
			dtlog_insert timestamp default(current_timestamp),
			dtlog_update timestamp ,
			id BIGINT PRIMARY KEY,
			centro_distribuicao_id INTEGER,
			filial_id INTEGER,
			compra_status_id INTEGER,
			tipo_entrega_id INTEGER,
			cliente_id INTEGER,
			endereco_id INTEGER,
			usuario_id INTEGER,
			api_usuario_id INTEGER,
			external_compra_id VARCHAR(100),
			cnpj_gerador_pedido VARCHAR(20),
			foreign_key VARCHAR(100),
			parent_id BIGINT,
			data_entrega TIMESTAMP WITH TIME ZONE,
			data_entregue TIMESTAMP WITH TIME ZONE,
			data_faturamento TIMESTAMP WITH TIME ZONE,
			faturamento BOOLEAN,
			tipo_fiscal VARCHAR(10),
			numero_fiscal VARCHAR(30),
			prevenda BOOLEAN,
			numero_prevenda VARCHAR(100),
			frete NUMERIC(13,2),
			taxa_de_servico NUMERIC(13,2),
			valor_inicial NUMERIC(13,2),
			valor_desconto NUMERIC(13,2),
			observacoes_do_cliente TEXT,
			observacoes_do_atendimento TEXT,
			observacoes_na_entrega TEXT,
			intervalo INTEGER,
			qtd_itens INTEGER,
			qtd_produtos INTEGER,
			valor_produtos NUMERIC(13,2),
			retirada_loja BOOLEAN,
			notificacao_retirada INTEGER,
			antifraude_session_id UUID,
			score_priorizacao NUMERIC(13,2),
			informacoes_cashback TEXT,
			desconto_aplicado BOOLEAN,
			fonte_compra VARCHAR(10),
			marketplace INTEGER,
			loja_autonoma BOOLEAN,
			livre_do_represamento BOOLEAN,
			valida BOOLEAN,
			created TIMESTAMP WITH TIME ZONE,
			modified TIMESTAMP WITH TIME ZONE,
			uuid UUID,
			codigo VARCHAR(50),
			status VARCHAR(30),
			valor_final NUMERIC(13,2),
			tipo_pedido VARCHAR(30),
			volumes_frios INTEGER,
			volumes_comuns INTEGER
		);
	end if;




	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_vip_notificacao' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
	    drop table if exists tbfaturamento_vip_notificacao;
		create table tbfaturamento_vip_notificacao
			(
					dtlog_insert 		timestamp default (current_timestamp)
				,	faturamento_vip_notificacao_seq serial 
				, 	id					int
				,	notificacao_cd		int
				,	compra_status_id 	int
				,	notificado			smallint 
				,	constraint pkfaturamento_vip_notificacao primary key (id, notificacao_cd, compra_status_id)
			)
		;
	end if;





	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_vip_compra_status' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfaturamento_vip_compra_status
					(		dtlog_insert 				timestamp default (current_timestamp)
						,	dtlog_update 				timestamp default (current_timestamp)
						,	compra_status_id			int
						,	compra_status_descricao 	varchar(30)
						,	notificacao_cd				int
						,	constraint pkfaturamento_vip_compra_status_id primary key (compra_status_id)
					)
			;
	end if;
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 15, 'Pedido Finalizado' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 15  );
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 17, 'Pedido Cancelado' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 17  );

	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 16, 'Em Processamento de Compra' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 16  );
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 38, 'Em Análise de Fraude' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 38  );						
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 12, 'Aguardando Separação' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 12  );		
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 13, 'Em separação' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 13  );								
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 11, 'Em atendimento/Pendente' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 11  );														
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 10, 'Em andamento' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 10  );
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 18, 'Aguardando empacotamento' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 18  );
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 19, 'Aguardando empacotamento' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 19  );						
	insert into tbfaturamento_vip_compra_status (compra_status_id,compra_status_descricao) 
		select 21, 'Aguardando faturamento' where not exists (select 1 from tbfaturamento_vip_compra_status where compra_status_id = 21  );

	update  tbfaturamento_vip_compra_status set notificacao_cd = 0;
	update tbfaturamento_vip_compra_status set notificacao_cd = 1000510010 where compra_status_id in (38,11,12)
	;
end$$	

;


/* NOVO CODIGO DE MENSAGEM WHATS POR GRUPO */

insert into tbnotificacao (notificacao_cd, notificacao_descricao, notificacao_whatsapp, notificacao_send_tipo_cd, notificacao_tipo_body_cd, notificacao_whats_user_show)
select 1000510010, 'STATUS VIP', 1, 1, 1, 1
where not exists (select 1 from tbnotificacao where notificacao_cd = 1000510010)

;

delete from tbnotificacao_grupo where notificacao_cd = 1000510010;
insert into tbnotificacao_grupo (notificacao_cd, notificacao_gp_email, notificacao_gp_whats, notificacao_grupo_cd)
/*SELECT 1000510010, '', '120363176123541455', 2 
where not exists (select  1 from tbnotificacao_grupo where notificacao_gp_whats = '120363176123541455')
*/
SELECT 1000510010, '', '120363311311733537', 2 
where not exists (select  1 from tbnotificacao_grupo where notificacao_gp_whats = '120363311311733537')

;

/* ANALISE AJUSTE DE E-MAIL CADASTRADO EM DUPLICAIDADE NO E-MAIL MAIN DA TABELA TBPARTICPANTE */
update tbparticipante set email_main = '' where email_main = 'eliassilva@oxan.com.br' and cdparticipante <> 15206



/* NOVA TAREFA */

;





/* AJUSTE DE DESCRIÇÃO DE GRUPO DE MENU
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
*/
UPDATE tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Prime | Produtos' where sis_ac_gmenu_cd = 1100;
UPDATE tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Zanthus' where sis_ac_gmenu_cd = 1200

;


/* GRUPO DE MENU PERMISSÕES 
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
*/
	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 9005, 'Sistema - Permissões', 9000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 9005)
	;

	-- MENU LISTAGEM DE TAREFAS --------------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 9005, 'Tarefas', 'm9005', 9000, '/pages/sistema/acesso/tarefa')
	;
	---> Habilitar menu listagem tarefas tambem para a função 2
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
			select 5, 2, 9005, 1
			where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 9005 and sis_ta_cd = 1 )
		;

	-- MENU LISTAGEM DE PERMISSOES ----------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 9006, 'Permissões', 'm9006', 9000, '/pages/sistema/acesso/permissao')
	;
	---> Habilitar menu listagem de permissoes tambem para a função 2
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
			select 5, 2, 9006, 1
			where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 9006 and sis_ta_cd = 1 )

;

/* GRUPO DE MENU PERMISSÕES 
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
*/
	--select * from tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 1000
	--select * from tbsistema_acesso where sis_ac_cd = 1011
	
	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 1010, 'Prime | Participante', 1000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 1010)
	;			

	delete from tbsistema_acesso where sis_ac_cd in (1011, 1012) and sis_cd = 5
	;
	-- MENU LISTAGEM DE PERMISSOES ----------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 1011, 'Listagem de Participantes', 'm1011', 1010, '/pages/cadastro/participante/listagem')
	;	
		---> Habilitar menu listagem de permissoes tambem para a função 2
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
			select 5, 2, 1011, 1
			where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 1011 and sis_ta_cd = 1 )
	;
	-- MENU LISTAGEM DE PERMISSOES ----------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 1012, 'Operações', 'm1012', 1010, '/pages/cadastro/participante/operacao')
	;		
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
			select 5, 2, 1012, 1
			where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 1012 and sis_ta_cd = 1 )

	----------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------
	;
	delete from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 1105
	;
	INSERT INTO tbsistema_nucleo_procedimento
		(
				sis_nucleo_cd_fk
			, 	sis_nucleo_prc_cd
			, 	sis_nucleo_prc_descritivo
			, 	sis_nucleo_prc_tipo
			, 	dateadd_ini
			, 	dateadd_fim
			, 	data_default_ini
			, 	data_default_fim
			,	permite_execucao_manual 
			,	sis_nucleo_prc_descricao
			,	notificacao_cd 
		)
	
	SELECT 		'F0011' 							as	sis_nucleo_cd_fk
			, 	1105 								as	sis_nucleo_prc_cd
			, 	'PARTICIPANTE VIP - Importacao ' 	as 	sis_nucleo_prc_descritivo
			, 	1									as  sis_nucleo_prc_tipo
			, 	-15									as  dateadd_ini
			, 	-1									as  dateadd_fim
			, 	0									as  data_default_ini
			, 	0 									as  data_default_fim
			,	0									as  permite_execucao_manual 
			,	''									as sis_nucleo_prc_descricao
			,	1009030001
	where not exists (select 1 from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 1105)
	;
	INSERT INTO tbsistema_batch_nucleo_procedimento (sis_batch_cd, sis_nucleo_prc_cd, sis_batch_nucleo_order)
		SELECT 90301, 1105, 5
		WHERE NOT EXISTS (SELECT 1 FROM tbsistema_batch_nucleo_procedimento WHERE sis_batch_cd = 90301 and sis_nucleo_prc_cd = 1105)

	
	--delete from tbsistema_batch_run 
	--select * from tbsistema_batch_nucleo_procedimento where sis_batch_cd = 90301
		