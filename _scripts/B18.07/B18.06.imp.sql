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
select * from tbfaturamento_bluesoft_processo
select * from tbfaturamento_bluesoft_item limit 10
select op_cdoperacao 
	,	numeropedido 
	,	numeropedido_fv
	,	prb_cdprodutobluesoft_unitario 
	,	prb_cdprodutobluesoft 
	,	prb_embalagem 
	,	prb_fatorestoque 
	,	embalagem_descricao 
	,	qtde_unitaria_solicitada 
	,	qtde_unitaria_faturada
	,	qtde_solicitada 
	,	qtde_faturada 
	,	valor_custo_com_icm_unit 
	,	valor_custo 
	,	valor_preco_tabela
	,	valor_preco 
	,	valor_preco_aplicado 
	,	valor_verba 
	,	valor_verba_gerencia 
	,	valor_verba_supervisao 
	,	valor_verba_calculada
	,	valor_desconto_financeiro 
	,	valor_nf_item_bruto 
	,	valor_nf_item 
	,	item_nf_bonificado 
	,	percentual_desconto_financeiro 
	


from 	tbfaturamento_bluesoft_item limit 10

select * from tbforca_venda_tabpreco_versao
select * from tbforca_venda_prazopgto
select * from tbfaturamento_bluesoft_status

*/



do $$
begin 




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbsistema_parametro' 
			  and   column_name = 'sis_pr_descricao'
			  and   data_type = 'character varying'
			  and   character_maximum_length = 60
			) > 0  -->> Se não existir
	   	)	
	then 
			
			alter table tbsistema_parametro ALTER COLUMN sis_pr_descricao type varchar(120)
			;
	end if;
	
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft_status' 
			  and   column_name = 'notificacao_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			
			alter table tbfaturamento_bluesoft_status add notificacao_cd int
			;
	end if;


	drop table if exists tbfaturamento_bluesoft_processo_tipo;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_processo_tipo' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- select * from tbforca_venda_prazopgto
		-- select * from tbfaturamento_bluesoft_processo
		create table tbfaturamento_bluesoft_processo_tipo
			(
					dtlog_insert						timestamp 
				,	fat_blue_processo_tipo_cd			int
				,	fat_blue_processo_tipo_descricao 	varchar(60)
				,	constraint pkfaturamento_bluesoft_processo_tipo	primary key (fat_blue_processo_tipo_cd)
			);
	end if;	
	insert into tbfaturamento_bluesoft_processo_tipo (fat_blue_processo_tipo_cd, fat_blue_processo_tipo_descricao) 
		select 20, 'Notificação Fat. c/ Corte - Varejo'
		where not exists (select 1 from tbfaturamento_bluesoft_processo_tipo 
		where fat_blue_processo_tipo_cd = 20)
		;
	insert into tbfaturamento_bluesoft_processo_tipo (fat_blue_processo_tipo_cd, fat_blue_processo_tipo_descricao) 
		select 30, 'Notificação Fat. c/ Corte - TOP'
		where not exists (select 1 from tbfaturamento_bluesoft_processo_tipo 
		where fat_blue_processo_tipo_cd = 30)
		;


	drop table if exists tbfaturamento_bluesoft_processo;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfaturamento_bluesoft_processo' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- select * from tbforca_venda_prazopgto
		-- select * from tbfaturamento_bluesoft_processo
		create table tbfaturamento_bluesoft_processo
			(
					dtlog_insert				timestamp default (current_timestamp)
				,	fat_blue_processo_seq 		serial 
				,	fat_blue_processo_tipo_cd	int
				,	op_cdoperacao 				int
				,	numeropedido 	 			int
				,	numeropedido_fv 			int
				,	fat_blue_status_cd 			int
				--,	fat_blue_status_desc 		varchar(255)
				,   notificacao_cd              int 
				--,	numero_itens                int 
				--,	valor_pedido                numeric(13,2) 
				--,   valor_faturamento		    numeric(13,2)
				,   notificado                  smallint 
				,	constraint pkfaturamento_bluesoft_processo	primary key (fat_blue_processo_seq, fat_blue_processo_tipo_cd, op_cdoperacao, numeropedido, numeropedido_fv, fat_blue_status_cd)
				,	constraint uqfaturamento_bluesoft_processo  unique (fat_blue_processo_tipo_cd, op_cdoperacao, numeropedido, numeropedido_fv, fat_blue_status_cd)
			);
	end if;	



	/* NOTIFICAÇÕES */

	insert into tbnotificacao (notificacao_cd, notificacao_descricao, notificacao_senD_tipo_cd, notificacao_tipo_body_cd )
		select 1005000010, 'FATURAMENTO BLUESOFT - AVISO DE CORTE', notificacao_senD_tipo_cd, notificacao_tipo_body_cd 
		FROM tbnotificacao 
		where notificacao_cd = 1000000009
		AND NOT EXISTS (SELECT 1 FROM tbnotificacao where notificacao_cd = 1005000010)

	;
	drop table if exists tbnotificacao_permissao_grupo;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbnotificacao_permissao_grupo' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- select * from tbforca_venda_prazopgto
		-- select * from tbfaturamento_bluesoft_processo
		create table tbnotificacao_permissao_grupo
		(
				notificacao_permissao_grupo_cd 				int
			,	notificacao_permissao_grupo_descricao 		varchar(60)
			,	constraint pknotificacao_permissao_grupo primary key (notificacao_permissao_grupo_cd)
		);
		INSERT INTO tbnotificacao_permissao_grupo (notificacao_permissao_grupo_cd, notificacao_permissao_grupo_descricao) SELECT 1, 'SISTEMA';
		INSERT INTO tbnotificacao_permissao_grupo (notificacao_permissao_grupo_cd, notificacao_permissao_grupo_descricao) SELECT 2, 'EQUIPE DE VENDAS';
	end if;	


	drop table if exists tbnotificacao_permissao;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbnotificacao_permissao' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		-- select * from tbforca_venda_prazopgto
		-- select * from tbfaturamento_bluesoft_processo
			create table tbnotificacao_permissao 
			(
						notificacao_cd int	
					,	notificacao_permissao_grupo_cd int
					,	cdparticipante int
			);


				
	end if;	
	






end$$	
		;

		/*NUCLEO DE CONTROLE*/
		insert into TBSISTEMA_NUCLEO (sis_cd_fk, sis_nucleo_cd_pk, sis_nucleo_descricao, sis_nucleo_grupo_id, status)
		select 1, 'M0050', 'Faturamento Bluesoft', 1, true
		where not exists (SELECT  1 from TBSISTEMA_NUCLEO where sis_nucleo_cd_pk =  'M0050' )
		
		;



		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050001;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual
														
														)
			select 	'M0050'
				,	10050001
				,	'JS - Faturamento Bluesoft - SERVICE (Diário e de Atualização Pendente'
				,	1
				,	'JS - Faturamento Bluesoft - SERVICE (Diário e de Atualização Pendente'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050001)
		;



		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050010;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual
														
														)
			select 	'M0050'
				,	10050010
				,	'JS - Faturamento Bluesoft - Importação Redshift'
				,	1
				,   'Prime JS _ Faturamento Bluesoft _ Importação de Vendas Redshift Bluesoft via JS'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050010)
		;



		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050011;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual
														
														)
			select 	'M0050'
				,	10050011
				,	'JS - Faturamento Bluesoft - Importação API'
				,	1
				,   'Prime JS _ Faturamento Bluesoft _ Importação de Vendas API BLUE'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050011)
		;

		

		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050030;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual
														
														)
			select 	'M0050'
				,	10050030
				,	'JS - Faturamento Bluesoft _ FV _ E-mail informaçãoes do Força de Venda'
				,	1
				,   'JS - Faturamento Bluesoft - FV _ E-mail informaçãoes do Força de Venda'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050030)

		;

		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050032;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual )

			select 	'M0050'
				,	10050032
				,	'JS-Faturamento Bluesoft - FV | INfo Pedido c/ corte WHATS-ADM'
				,	1
				,   'JS-Faturamento Bluesoft - FV | INfo Pedido c/ corte WHATS-ADM'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10050032)

		;



		/*NOVO menu faturamento/Cortes -------------------------------------------*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3213;
		select public._local_acesso_web(5, 3213, 'Vendas Bluesoft Online FV - Cortes', 'm3213', 3200, '/pages/operacional/faturamentobluesoft/vendasfvcorte')
		;

		
		

		/*NOVO menu faturamento/Operacao*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3214;
		select public._local_acesso_web(5, 3214, 'Operações', 'm3214', 3200, '/pages/operacional/faturamentobluesoft/operacao')
		;

		/*NOVO menu faturamento/processo -------------------------------------------*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3211;
		select public._local_acesso_web(5, 3211, 'Processos', 'm3211', 3200, '/pages/operacional/faturamentobluesoft/processo')
		;
				insert into   tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select xx.sis_cd, xx.sis_fc_cd, 3211, xx.sis_ta_cd from tbsistema_permissao xx
				where sis_ac_cd = 3210 
				and sis_fc_cd = 1
				and not exists (select 1 from tbsistema_permissao xa where xa.sis_ac_cd = 3211 and xa.sis_cd = xx.sis_cd and xa.sis_fc_cd = xx.sis_fc_cd and xa.sis_ta_cd = xx.sis_ta_cd)
				;
				insert into   tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select xx.sis_cd, 2, sis_ac_cd, xx.sis_ta_cd from tbsistema_permissao xx
				where sis_ac_cd = 3211 
				and sis_fc_cd = 1
				and not exists (select 1 from tbsistema_permissao xa where xa.sis_ac_cd = xx.sis_ac_cd and xa.sis_cd = xx.sis_cd and xa.sis_fc_cd = 2 and xa.sis_ta_cd = xx.sis_ta_cd)
		/*-------------------------------------------------------------------------*/
		
		;
		/*ajuste menu faturamento/zanthus*/
		update tbsistema_acesso set sis_ac_href = '/pages/operacional/zanthus/vendas', sis_ac_descricao = 'Vendas Zanthus Online' where sis_cd = 5 and sis_ac_cd = 3920
		;

		/*ajuste menu faturamento/bluesoft*/
		update tbsistema_acesso set sis_ac_href = '/pages/operacional/faturamentobluesoft/vendas', sis_ac_descricao = 'Vendas Bluesoft Online' where sis_cd = 5 and sis_ac_cd = 3210
		;


		delete from tbsistema_parametro where sis_cd = 1 and sis_pr_cd = 100500010;
		insert into tbsistema_parametro (sis_cd, sis_pr_cd, sis_pr_descricao, sis_pr_value)
			select 1, 100500010,'Faturamento Bluesoft Corte Varejo | Whats - Valor Mínimo Corte', 250 
			where not exists (select 1 from tbsistema_parametro where sis_pr_cd =  100500010)

		;
		


		/*CADASTRO DE VENDEDOR PARA RECEBER WHATS APP MESSAGE CORTE */
		
			insert into tbnotificacao_permissao 
				SELECT 1005000010, 2, 15 WHERE NOT EXISTS (SELECT 1 FROM tbnotificacao_permissao WHERE cdparticipante = 15 and notificacao_cd = 1005000010);
			insert into tbnotificacao_permissao 
				SELECT 1005000010, 2, 12 WHERE NOT EXISTS (SELECT 1 FROM tbnotificacao_permissao WHERE cdparticipante = 12 and notificacao_cd = 1005000010);
			INSERT INTO tbnotificacao_permissao 
				SELECT 1005000010, 2, 18098 WHERE NOT EXISTS (SELECT 1 FROM tbnotificacao_permissao WHERE cdparticipante = 18098 and notificacao_cd = 1005000010);
			INSERT INTO tbnotificacao_permissao 
				SELECT 1005000010, 2, 17 WHERE NOT EXISTS (SELECT 1 FROM tbnotificacao_permissao WHERE cdparticipante = 17 and notificacao_cd = 1005000010);				











		/*
		select * from tbsistema_acesso 
			where 	sis_cd = 5 
			--and 	sis_ac_descricao like 'Venda Bluesoft'
		ORDER BY sis_ac_cd asc

		select sis_pr_cd, sis_pr_descricao, sis_pr_value from tbsistema_parametro

		select * from tbsistema_acesso where sis_ac_href like '/pages/operacional/%'

		select * from tbsistema_log
		*/


/*
select * from tbfaturamento_bluesoft_status
SELECT * FROM tbfaturamento_bluesoft_processo		
select * from tbprocesso
select * from tbprocesso_tipo
select * from tbprocesso_log limit 10
select * from tbfaturamento_bluesoft limit 10
select * from tbnotificacao_send

select 		a.dtlog_insert 
	,		a.sis_log_seq
	,		coalesce(a.proc_log_seq,0) as proc_log_seq
	,		coalesce(a.sis_nucleo_prc_cd, 0) as sis_nucleo_prc_cd
	,		a.sis_log_tag
	,		a.sis_log_info
	,		coalesce(a.sis_batch_run_seq,0) as sis_batch_run_seq
	,		a.uuid 
	,		a.uuid_start 
	,		coalesce(b.sis_nucleo_prc_descritivo,'') as sis_nucleo_prc_descritivo
	,		coalesce(b.sis_nucleo_prc_descricao, '') as sis_nucleo_prc_descricao
from 		tbsistema_log a
left join 	tbsistema_nucleo_procedimento b on a.sis_nucleo_prc_cd = a.sis_nucleo_prc_cd 


select * from tbsistema_nucleo where sis_nucleo_cd_pk = 'M0050'
select * from tbsistema_nucleo_procedimento




DELETE FROM tbfaturamento_bluesoft_processo;
insert into tbfaturamento_bluesoft_processo
	(		op_cdoperacao 
		,	numeropedido
		,	numeropedido_fv
		,	fat_blue_status_cd
		,	fat_blue_processo_tipo_cd
	)
		
SELECT 		f.op_cdoperacao 
	,		f.numeropedido
	,		f.numeropedido_fv
	,		f.fat_blue_status_cd
	,		20
FROM 		tbfaturamento_bluesoft  f
left join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
where	1 = 1
and		f.data_emissao >= '2026-05-25'
and		f.op_cdoperacao = 1
and		s.fat_blue_status_cd in (55, 70)
AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
and     not exists (select 1 
					from 	tbfaturamento_bluesoft_processo xx
					where	xx.op_cdoperacao = f.op_cdoperacao 
					  and   xx.numeropedido = f.numeropedido 
					  and   xx.numeropedido_fv = f.numeropedido_fv 
					  and   xx.fat_blue_status_cd = f.fat_blue_status_cd
					
					)

select 		xx.fat_blue_processo_seq
	,		xt.fat_blue_processo_tipo_cd
	,		xt.fat_blue_processo_tipo_descricao
	,		xx.op_cdoperacao 
	,		xx.numeropedido 
	,		xx.numeropedido_fv
	,		xx.fat_blue_status_cd 
	,		xx.notificacao_cd
	,		xx.notificado 
	,		fb.valor_pedido 
	,		fb.valor_faturamento
	,		xi.qtde_itens
	,		xi.qtde_itens_corte 	
	,		v.nome_razao as vendedor_nome_razao 
	,		c.nome_razao as cliente_nome_razao
	,		g.descricao as grupo_economico_descricao 
	,		fb.data_emissao 
	,		fb.data_faturamento 
	,		pv.celular_dd
	,		pv.celular_numero
from 		tbfaturamento_bluesoft_processo xx
left join   tbfaturamento_bluesoft_processo_tipo xt on xt.fat_blue_processo_tipo_cd = xx.fat_blue_processo_tipo_cd
inner join 	tbfaturamento_bluesoft fb on fb.op_cdoperacao = xx.op_cdoperacao 
									and  fb.numeropedido = xx.numeropedido 
									and  fb.numeropedido_fv = xx.numeropedido_fv 
left join   tbparticipante_bluesoft v  on v.cdpessoabluesoft = fb.cdpessoabluesoft_vendedor
left join   tbparticipante          pv on pv.cdparticipante = v.cdparticipante 
left join   tbparticipante_vendedor vv on vv.cdparticipante = pv.cdparticipante 
left join   tbparticipante_bluesoft c on c.cdpessoabluesoft = fb.cdpessoabluesoft_cliente
left join   tbgrupoeconomico 		g on g.cdgrupoeconomico = c.cdgrupoeconomico 
left join   ( 	select 	i.numeropedido 
					,	i.numeropedido_fv 
					,	i.op_cdoperacao 
					,	count(distinct(i.prb_cdprodutobluesoft)) qtde_itens
					,	count(distinct(case when i.qtde_solicitada > qtde_faturada then i.prb_cdprodutobluesoft else null end )) qtde_itens_corte
				from 	tbfaturamento_bluesoft_item i
				where   1 = 1
				group by i.numeropedido 
					,	i.numeropedido_fv 
					,	i.op_cdoperacao 

			) xi on xi.numeropedido = xx.numeropedido and xi.numeropedido_fv = xi.numeropedido_fv and xi.op_cdoperacao = xx.op_cdoperacao 
									
where   1 = 1 
AND     vv.vendedor_status = 1

select * from tbfaturamento_bluesoft limit 10
select * from tbfaturamento_bluesoft_PROCESSO limit 10
select * from tbfaturamento_bluesoft_item limit 10
select * from tbnotificacao_send_tipo
select * from tbparticipante_VENDEDOR limit 10
select * from tbparticipante_contato where contato_tipo_cd = 2
select * from tbgrupoeconomico
select * from tbfaturamento_bluesoft limit 10
*/