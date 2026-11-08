-- Active: 1773758617277@@127.0.0.1@5432@oxan
---select current_timestamp; SELECT current_setting('timezone'); SET timezone = 'America/Sao_Paulo';

/*

select * from tbforca_venda_tabpreco order by fv_tabelapreco_descricao
select * from tbforca_venda_comis_tabpreco

select * from tboperacao
select * from tbsistema_tarefa where sis_ta_tipo_cd = 3
select * from tbsistema_permissao where sis_ac_cd = 3210
select * from tbsistema_tarefa_tipo
select * from tbsistema_tarefa_inter
select * from tbempresa
select * from tboperacao

select * from tbfaturamento_bluesoft_status

select 		i.sis_ta_cd 
	,		i.em_cdempresa
	,		e.em_descricao 
	,		i.op_cdoperacao
	,		o.op_descricao 
	,		p.sis_ac_cd
	,		u.user_name
	,		u.sis_us_seq 
from 		tbsistema_tarefa_inter 	i
inner join 	tbsistema_tarefa 	t on t.sis_ta_cd = i.sis_ta_cd 
inner join  tbsistema_permissao p on p.sis_ta_cd = t.sis_ta_cd 
inner join  tbsistema_funcao 	f on f.sis_fc_cd = p.sis_fc_Cd 
inner join  tbsistema_usuario   u on u.sis_fc_cd = f.sis_fc_cd 
inner join  tboperacao  		o on o.op_cdoperacao = i.op_cdoperacao 
inner join  tbempresa   		e on e.em_cdempresa = i.em_cdempresa 
where		1 = 1
  AND       P.SIS_AC_CD = 3210
  AND       u.user_name = 'elias'
select op_cdoperacao from tbfaturamento_bluesoft group by op_cdoperacao limit 10

select * from tbsistema_permissao where sis_ac_cd = 3210

SELECT * FROM TBPARTICIPANTE_TIPO
select * from tbsistema_usuario


	SELECT 		sf.statusfaturamento
			,	sf.statusfaturamento_descricao 
			,	s.fat_blue_status_cd
			,	s.fat_blue_status_descricao 
	from 		tbfaturamento_bluesoft_status s
	inner join 	tbfaturamentostatus sf on sf.statusfaturamento = s.statusfaturamento
	order by sf.statusfaturamento, s.fat_blue_status_descricao 


	select cod_mercadoria, codigo_beneficio_fiscal from TbZanthusTab_Regra_Icms limit 10
	SELECT cod_mercadoria, codigo_beneficio_fiscal  FROM tbzanthustab_mercadoria limit 10
*/

--select * from tbfc_regrafiscal where coalesce(icms_cd ,0) <> 0
--select * from tbprodutobluesoft_tributacao where op_cdoperacao = 2 and prb_cdprodutobluesoft = 43



do $$
begin 

	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbforca_venda_prazopgto' 
			  and   column_name = 'custofinanceiro'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbforca_venda_prazopgto add custofinanceiro numeric(17,5);
			alter table tbforca_venda_prazopgto add coefCustoFinanceiro numeric(17,5);
			alter table tbforca_venda_prazopgto add tipo varchar(25);
			alter table tbforca_venda_prazopgto add tipoCusto varchar(25);
			alter table tbforca_venda_prazopgto add status smallint ;
			alter table tbforca_venda_prazopgto add versao int ;
			alter table tbforca_venda_prazopgto add listapadraoorder int ;
			alter table tbforca_venda_prazopgto add dtlog_insert timestamp default (current_timestamp);
			alter table tbforca_venda_prazopgto add dtlog_update timestamp 
			;


	end if;
	



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbforca_venda_tabpreco' 
			  and   column_name = 'dtlog_update'
			) = 0  -->> Se não existir
	   	)	
	then 
			-- select * from tbforca_venda_tabpreco
			alter table tbforca_venda_tabpreco add dtlog_update timestamp
			;
	end if;


	--drop table if exists tbforca_venda_tabpreco_versao;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbforca_venda_tabpreco_versao' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 

			create table  tbforca_venda_tabpreco_versao
				(			dtlog_insert 					timestamp default (current_timestamp)
				    	,	dtlog_update 					timestamp 
						,	fv_tabelapreco_cd 				int
						,	versao 							int
						,	descontoMaximo  				numeric(13,2)
						,	descontoPadrao  				numeric(13,2)
						,	acrescimoMaximo 				numeric(13,2)
						,	dataInicioVigencia 				timestamp 
						,	dataFimVigencia 				timestamp 						,	ativo 							smallint			
						,	tabelaReferencia 				smallint
						,	publicada 						smallint
					,	constraint pkforca_venda_tabpreco_versao primary key (fv_tabelapreco_cd, versao)
				);

			

	end if;	



	--drop table if exists tbforca_venda_tabprecoprodutobluesoft;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbforca_venda_tabprecoprodutobluesoft' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table tbforca_venda_tabpreco_produto;
			--select * from tbforca_venda_tabprecoprodutobluesoft
			create table  tbforca_venda_tabprecoprodutobluesoft
				(		dtlog_insert 					timestamp default (current_timestamp)
				    ,	dtlog_update 					timestamp 
					,	fv_tabelapreco_cd 				int
					,	fv_tabelapreco_prod_seq_blue	int
					,	prb_cdprodutobluesoft			int 
					,	precoEmbalagem 					numeric(13,2)
					,	precoUnitario 					numeric(17,5)
					,	descontoMaximo				 	numeric(13,2)
					,	descontoPadrao 					numeric(13,2)
					,	acrescimoMaximo 				numeric(13,2)
					,	produtoKey 						int
					,	fatorPreco  					numeric(17,4)
					,	fatorEstoque 					numeric(17,4)
					,	versao 							int
					,	precoPromocional 				numeric(13,2)
					,	constraint pkforca_venda_tabpreco_produto primary key (fv_tabelapreco_cd, versao, prb_cdprodutobluesoft)
				);

				/*
				alter table tbforca_venda_tabprecoprodutobluesoft drop constraint pkforca_venda_tabpreco_produto;
				alter table tbforca_venda_tabprecoprodutobluesoft 
					add constraint pkforca_venda_tabpreco_produto primary key (fv_tabelapreco_cd, versao, prb_cdprodutobluesoft)
				*/
	end if;	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   column_name = 'tipocliente'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbfc_regrafiscal add tipocliente varchar(30)
			;

	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   column_name = 'icms_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbfc_regrafiscal add icms_cd int 
			;

	end if;
	


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   column_name = 'pis_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			-- alter table tbfc_regrafiscal drop column pis_cd
			alter table tbfc_regrafiscal add pis_cd int 
			;

	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   column_name = 'cofins_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			--- alter table tbfc_regrafiscal drop column cofins_cd
			alter table tbfc_regrafiscal add cofins_cd int 
			;

	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   column_name = 'regimeincidenciapiscofins'
			) = 0  -->> Se não existir
	   	)	
	then 
			--- alter table tbfc_regrafiscal drop column cofins_cd
			alter table tbfc_regrafiscal add regimeincidenciapiscofins varchar(20)
			;

	end if;

	

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_icms' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table tbfc_icms;
			create table  tbfc_icms 
				(		dtlog_insert timestamp default (current_timestamp)
					,	dtlog_update timestamp 
					,	icms_cd int
					,	codigoOrigem int
					,	codigoTributacao int
					,	icms_descricao varchar(60)
					,	sigla varchar(10)
					,	aliquota numeric(13,2)
					,	reducao numeric(17,5)
					,	porcentagemDiferimento numeric(17,5)
					,	constraint pkfc_icms primary key(icms_cd)
					
				);
	
	end if;

	drop table if exists tbfc_pis;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_pis' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table tbfc_pis;
			create table  tbfc_pis
				(		dtlog_insert timestamp default (current_timestamp)
				    ,	dtlog_update timestamp 
				    ,	pis_cd int
					,   tipo_entrada smallint
					,	pis_descricao varchar(60)
				    ,   cst int
				    ,   pisAliquota numeric(17,5)
				    ,   pisReducao numeric(17,5)
					,	cofinsRelacionado int
					,	constraint pkfc_pis  primary key(pis_cd)
					
				);
	end if;	

	drop table if exists tbfc_cofins;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_cofins' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table tbfc_piscofins;
			create table  tbfc_cofins
				(		dtlog_insert timestamp default (current_timestamp)
				    ,	dtlog_update timestamp 
				    ,	cofins_cd int
					,   tipo_entrada smallint					
					,	cofins_descricao varchar(60)
				    ,   cst int
				    ,   cofinsAliquota numeric(17,5)
				    ,   cofinsReducao numeric(17,5)
					,	pisrelacionado int
					,	constraint pkfc_cofins  primary key(cofins_cd)
					
				);
	end if;		
	
	



	
end$$	

;


/* SCRIPT MANUAL - PRAZO PGTO */
--- 1 __ select * into back_tbforca_venda_prazopgto from tbforca_venda_prazopgto;
--- 2 __ DELETE FROM tbforca_venda_prazopgto
/*
update tbfaturamento_bluesoft aa
set    fv_prazopgto_cd = x.new_fv_prazopgto_cd
from  (
		select 	a.fv_prazopgto_cd new_fv_prazopgto_cd
			,	b.fv_prazopgto_cd old_fv_prazopgto_cd
		from   tbforca_venda_prazopgto a
		inner join back_tbforca_venda_prazopgto b on b.fv_prazopgto_descricao = a.fv_prazopgto_descricao
	   ) x 
where    x.old_fv_prazopgto_cd = aa.fv_prazopgto_cd


update tbforca_venda_prazopgto set listapadraoorder = 1 where fv_prazopgto_cd = 121;
update tbforca_venda_prazopgto set listapadraoorder = 2 where fv_prazopgto_cd = 122;
update tbforca_venda_prazopgto set listapadraoorder = 3 where fv_prazopgto_cd = 123;
update tbforca_venda_prazopgto set listapadraoorder = 4 where fv_prazopgto_cd = 124;

*/
	
	

-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------

delete from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 10004001 and sis_nucleo_cd_fk = 'F0004';
insert into tbsistema_nucleo_procedimento 
    (
            sis_nucleo_cd_fk
        ,   sis_nucleo_prc_cd
        ,   sis_nucleo_prc_descritivo
        ,   sis_nucleo_prc_tipo 
        ,   data_reprocessamento_default 
        ,   data_reprocessamento_default_fim 
        ,   permite_execucao_manual
        ,   sis_nucleo_prc_descricao
        ,   notificacao_cd
    ) select 'F0004', 10004001, 'Força de Venda (JS) - Integração Geral', 1, '1900-01-01', '1900-01-01', 0, 'Força de Venda (JS) - Integração Geral', 1009030001
    where not exists (
        select 1 from tbsistema_nucleo_procedimento where sis_nucleo_prc_cd = 10004001 and sis_nucleo_cd_fk = 'F0004'
    )

	insert into tbsistema_batch_nucleo_procedimento (sis_batch_cd, sis_nucleo_prc_cd, sis_batch_nucleo_order)
    select 90301, 10004001, 150
    where not exists (
        select 1 from tbsistema_batch_nucleo_procedimento where sis_batch_cd = 90301 and sis_nucleo_prc_cd = 10004001
    );
	


	update tbsistema_nucleo_procedimento set sis_nucleo_prc_descricao = 'PARTICIPANTE VIP - Importacao'
	where sis_nucleo_prc_cd = 1105;





	-- CORREÇÃO DO SUBMENU PARA A CONSULTA DE VENDAS ZANTHUS
	update tbsistema_acesso set sis_ac_gmenu_cd = 3400
	where sis_cd = 5
	 and  sis_ac_cd = 3920
	;
	

	
	/* OPERACIONAL - FORÇA DE VENDA */
		/*VENDAS GERAIS - BLUESOFT _ AJUSTE DO TITULO DE MENU*/	
		/*SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 3000*/
		/*SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3100*/
		update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Bluesoft - Vendas | Registros Gerais' where sis_ac_gmenu_cd = 3200;

		insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
			select 3100, 'Bluesoft - Força de Venda', 3000
			where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3100)
		;

		/*NOVOS ACESSOS*/	
		delete from tbsistema_permissao where sis_cd = 5 and sis_ac_cd in (3215,3216,3217,3218,3230);
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd in (3215,3216,3217,3218,3230);
		select public._local_acesso_web(5, 3215, 'Prazos de Pagamento', 'm3215', 3100, '/pages/operacional/forcavenda/prazopgto');
		select public._local_acesso_web(5, 3216, 'Tabela de Preços', 'm3216', 3100, '/pages/operacional/forcavenda/tabela');
		select public._local_acesso_web(5, 3217, 'Tabela de Preços/Produto - List', 'm3217', 3100, '/pages/operacional/forcavenda/tabelaproduto');
		select public._local_acesso_web(5, 3218, 'Tabela de Preços - Tabela Padrão', 'm3218', 3100, '/pages/operacional/forcavenda/tabelapadrao');
		select public._local_acesso_web(5, 3230, 'Força de Venda | Operações', 'm3230', 3100, '/pages/operacional/forcavenda/operacao');

	
	
	/* ___ INSERINDO NOVOS SUBMENUS*/
		/* __ EXEMPLO 
		insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
			select 3200, 'Vendas | Bluesoft ', 3000
			where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3200)
		*/

	/*ALTERANDO A LOCALIZAÇÃO DO MENU ZANTHUS E A DESCRIÇÃO*/
		/* __ EXEMPLO 
		UPDATE tbsistema_acesso set sis_ac_gmenu_cd = 3300, sis_ac_descricao = 'Zanthus' where sis_cd = 5 and sis_ac_cd = 3920
		;
		*/
	


	
	-- MENU CONSULTA VENDA BLUESOFT ADMINISTRADOR ---------------------------------------------------------------------------------------------
		/* __ EXEMPLO 
		select public._local_acesso_web(5, 3210, 'Venda Bluesoft', 'm3210', 3200, '/pages/operacional/faturamento/bluesoft')
			;	
		*/

		/* ADMINISTRADOR - ACESSO EMPRESA/OPERACAO NO FORM DE CONSULTA DE VENDA BLUESOFT */
		/*
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select 5, 1, 3210, 3000101 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd =1 and sis_ac_cd = 3210 and sis_ta_cd = 3000101)
		*/