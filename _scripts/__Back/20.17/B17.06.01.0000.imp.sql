-- Active: 1773758617277@@127.0.0.1@5432@oxan


/*
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


	select * from tbfc_figura
*/



do $$
begin 

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbproduto_subgrupo' 
			  and   column_name = 'fc_cbenef_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbproduto_subgrupo add fc_cbenef_cd varchar(8) 
			;
			-- select * from tbproduto_subgrupo

	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamento_bluesoft_status' 
			  and   column_name = 'statusfaturamento'
			) = 0  -->> Se não existir
	   	)	
	then 
		alter table tbfaturamento_bluesoft_status add statusfaturamento int default(0);
			--0	"EM ABERTO"
			--1	"FATURADO"
			--2	"PEDIDO/NF CANCELADO"
			--9	"OUTRO"
			--7	"FATURAMENTO/RECUSADO"
			--select * from tbfaturamento_bluesoft_status
			update tbfaturamento_bluesoft_status set statusfaturamento = 9 where fat_blue_status_cd = 10;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 20;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 25;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 27;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 30;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 40;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 45;
			update tbfaturamento_bluesoft_status set statusfaturamento = 0 where fat_blue_status_cd = 50;
			update tbfaturamento_bluesoft_status set statusfaturamento = 1 where fat_blue_status_cd = 55;
			update tbfaturamento_bluesoft_status set statusfaturamento = 1 where fat_blue_status_cd = 70;
			update tbfaturamento_bluesoft_status set statusfaturamento = 2 where fat_blue_status_cd = 90;
			update tbfaturamento_bluesoft_status set statusfaturamento = 9 where fat_blue_status_cd = 10;
			update tbfaturamento_bluesoft_status set statusfaturamento = 9 where fat_blue_status_cd = 99;
		
	end if
	;



	drop table if exists tbfc_cbenef;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_cbenef' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfc_cbenef
					(		dtlog_insert timestamp default (current_timestamp)
						,	dtlog_update timestamp 
						,	fc_cbenef_seq serial
						,	fc_cbenef_cd varchar(15) 
						,	fc_cbenef_bluesoft_cd int
						,	fc_cbenef_dispositivo text
						,	fc_cbenef_objetivo TEXT
						,	fc_cbenef_observacao TEXT
						,	fc_cbenef_bluesoft_dispositivo text
						,	fc_cbenef_bluesoft_objetivo TEXT
						,	fc_cbenef_bluesoft smallint 
						,	constraint pkfc_cbenef primary key (fc_cbenef_seq, fc_cbenef_cd)
					)
				;
	
	end if;


	
	drop table if exists tbfc_cbenef_cst;
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_cbenef_cst' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
		create table tbfc_cbenef_cst
					(		dtlog_insert 			 timestamp default (current_timestamp)
						,	dtlog_update 			 timestamp 
						,	fc_cbenef_cst_seq 		 serial
						,	fc_cbenef_cd			 varchar(15) 
						,	icms_codigo_tributacao	 int
						,	constraint pkfc_cbenef_cst primary key (fc_cbenef_cst_seq, fc_cbenef_cd, icms_codigo_tributacao)
						,	constraint uqfc_cbenef_cst unique (fc_cbenef_cd, icms_codigo_tributacao)
					)
		;
	end if;				


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_blue_fc_cbenef_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			--alter table prb_blue_fc_cbenef_cd drop column prb_blue_fc_cbenef_cd;
			alter table tbprodutobluesoft add prb_blue_fc_cbenef_cd varchar(15) 
			;


	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbproduto' 
			  and   column_name = 'pr_pag_fc_cbenef_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
			--alter table tbproduto drop column pr_pag_fc_cbenef_cd;
			alter table tbproduto add pr_pag_fc_cbenef_cd varchar(15) 
			;


	end if;	

	
end$$	

;

	-- select * from tbfc_cbenef_cst
	--select * from tbfaturamentostatus
	--select * from tbsistema_acesso_modulomenu 
	--select * from tbsistema_acesso_grupomenu  where sis_ac_modulo_menu_cd = 3000
	--select * from tbsistema_acesso where sis_cd = 5 and sis_ac_gmenu_cd = 3900






	
	

-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------

--- VENDA BLUESOFT -----








	/*INSERINDO NOVOS SUBMENUS*/

	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 3200, 'Vendas | Bluesoft ', 3000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3200)
	;
	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 3300, 'Vendas | VIP ', 3000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3300)
	;
	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 3400, 'Vendas | Zanthus ', 3000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3400)
	;

	/*ALTERANDO A LOCALIZAÇÃO DO MENU ZANTHUS E A DESCRIÇÃO*/
	
	UPDATE tbsistema_acesso set sis_ac_gmenu_cd = 3300, sis_ac_descricao = 'Zanthus' where sis_cd = 5 and sis_ac_cd = 3920
	;
	
	
	delete from tbsistema_acesso where sis_ac_cd in (3210) and sis_cd = 5
	;

	-- TAREFA QUE PERMITE A VISUALIZAÇÃO DE TODOS OS VENDEDORES---------------------------------------------------------------------------------
	INSERT INTO tbsistema_tarefa (sis_cd, sis_ta_cd, sis_ta_descricao, sis_ta_tipo_cd)
		select 0, 110010, 'COMBOBOX - VENDEDOR | LISTA TODOS OS VENDEDORES', 1
			WHERE NOT EXISTS (SELECT 1 FROM tbsistema_tarefa WHERE SIS_TA_CD = 110010)
	;


	
	-- MENU CONSULTA VENDA BLUESOFT ADMINISTRADOR ---------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 3210, 'Venda Bluesoft', 'm3210', 3200, '/pages/operacional/faturamento/bluesoft')
	;	

	
			/* ADMINISTRADOR - ACESSO EMPRESA/OPERACAO NO FORM DE CONSULTA DE VENDA BLUESOFT */
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select 5, 1, 3210, 3000101 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd =1 and sis_ac_cd = 3210 and sis_ta_cd = 3000101)
			;
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select 5, 1, 3210, 3000306 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd =1 and sis_ac_cd = 3210 and sis_ta_cd = 3000306)
			;
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select 5, 1, 3210, 3000304 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd =1 and sis_ac_cd = 3210 and sis_ta_cd = 3000304)
			; --- VISUALIZA TODOS OS VENDEDORES
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				select 5, 1, 3210, 110010 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd =1 and sis_ac_cd = 3210 and sis_ta_cd = 110010)
			;		
	
	---------------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------------

	-- INSERINDO UMA FUNÇÃO PARA O VENDEDOR
			
			/*INSERE UMA NOVA FUNCAO PARA O VENDEDOR*/ 
			INSERT INTO TBSISTEMA_FUNCAO (sis_cd, sis_fc_cd, sis_fc_descricao)	
				SELECT 5, 80, 'Vendedor'
					WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_FUNCAO WHERE SIS_FC_CD = 80)
			; 

			/* VENDEDORA TESTE - KARINA _ CONSULTA */
			UPDATE TBSISTEMA_USUARIO SET sis_fc_cd = 80 where user_name = 'karina'
			;

			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				SELECT 5, 80, 3210, 1 WHERE NOT EXISTS(SELECT 1 FROM tbsistema_permissao WHERE sis_cd = 5 and sis_fc_cd = 80 and sis_ac_cd = 3210 and sis_ta_cd = 1)

			;
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				SELECT 5, 80, 3210, 3000101 WHERE NOT EXISTS(SELECT 1 FROM tbsistema_permissao WHERE sis_cd = 5 and sis_fc_cd = 80 and sis_ac_cd = 3210 and sis_ta_cd = 3000101)
			;


	
	---> Habilitar menu listagem de permissoes tambem para a função 2
	/*
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
			select 5, 2, 1011, 1
			where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 1011 and sis_ta_cd = 1 )
	*/



-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------

--- PRODUTO BLUESOFT -----
	--select * from tbsistema_acesso where sis_cd = 5
	-- MENU FISCAL CBENEF-PRODUTO ---------------------------------------------------------------------------------------------

	-- SELECT * FROM tbsistema_acesso_grupomenu
	-- SELECT * FROM tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 1120

	insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 1150, 'Bluesoft | Produtos ', 1000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 1150)
	;
	
	select public._local_acesso_web(5, 1155, 'Operações', 'm1155', 1150, '/pages/cadastro/produtobluesoft/operacao')
	;	



	
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------

--- FISCAL -----
	--select * from tbsistema_acesso where sis_cd = 5
	-- MENU FISCAL CBENEF-PRODUTO ---------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 4214, 'CBENEF - Produto', 'm4214', 4200, '/pages/controller/fiscal/cbenefproduto')
	;	
	-- MENU FISCAL CBENEF -----------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 4215, 'CBENEF - Lista', 'm4215', 4200, '/pages/controller/fiscal/cbenef')
	;	
	-- MENU FISCAL CBENEF -----------------------------------------------------------------------------------------------------
	select public._local_acesso_web(5, 1115, 'Produto / Sub Grupo', 'm1115', 1100, '/pages/cadastro/produto/subgrupolist')
	;	

	

	
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------




				;

				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP099090','','Benefício concedido por decisão judicial em sentença individual ou coletiva','Indicar o processo judicial nas informações complementares do documento fiscal');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP099000','','Remessas de mercadorias entre estabelecimentos do mesmo titular','Observar as disposições do Anexo XI da Portaria SRE 41/2023');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP099999','','Operações, sem benefício fiscal, para as quais a legislação determine a emissão da NF sem destaque de ICMS','Indicar fundamentação legal nas informações complementares do documento fiscal');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010010','Artigo 001 do Anexo I do RICMS','Isenção - ADJUDICAÇÃO EFETUADA PELO ESTADO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010020','Artigo 002 do Anexo I do RICMS','Isenção - AIDS - MEDICAMENTOS PARA TRATAMENTO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010030','Artigo 003 do Anexo I do RICMS','Isenção - AMOSTRA GRÁTIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010040','Artigo 004 do Anexo I do RICMS','Isenção - APAE - IMPORTAÇÃO DE MEDICAMENTOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010070','Artigo 007 do Anexo I do RICMS','Isenção - ARRENDAMENTO MERCANTIL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010080','Artigo 008 do Anexo I do RICMS','Isenção - BAGAGEM DE VIAJANTE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010090','Artigo 009 do Anexo I do RICMS','Isenção - BANCO DE ALIMENTOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010140','Artigo 014 do Anexo I do RICMS','Isenção - CIRURGIAS - EQUIPAMENTOS E INSUMOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010160','Artigo 016 do Anexo I do RICMS','Isenção - DEFICIENTES - CADEIRA DE RODAS E PRÓTESES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010170','Artigo 017 do Anexo I do RICMS','Isenção - DEFICIENTES - PRODUTOS DIVERSOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010180','Artigo 018 do Anexo I do RICMS','Isenção - DEFICIENTES - PRODUTOS PARA INSTITUIÇÃO PÚBLICA OU ENTIDADE ASSISTENCIAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010190','Artigo 019 do Anexo I do RICMS','Isenção - PESSOA COM DEFICIÊNCIA OU AUTISTA - VEÍCULO AUTOMOTOR','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010220','Artigo 022 do Anexo I do RICMS','Isenção - "DRAWBACK"','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010230','Artigo 023 do Anexo I do RICMS','Isenção - EMBARCAÇÃO NACIONAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010260','Artigo 026 do Anexo I do RICMS','Isenção - EMBRAPA - IMPORTAÇÃO DE PRODUTOS PARA PESQUISA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010270','Artigo 027 do Anexo I do RICMS','Isenção - EMBRAPA - OPERAÇÕES DIVERSAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010280','Artigo 028 do Anexo I do RICMS','Isenção - OÓCITO/EMBRIÃO/SÊMEN','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010290','Artigo 029 do Anexo I do RICMS','Isenção - ENERGIA ELÉTRICA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010300','Artigo 030 do Anexo I do RICMS','Isenção - ENERGIA SOLAR E EÓLICA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010310','Artigo 031 do Anexo I do RICMS','Isenção - ENTIDADE ASSISTENCIAL OU DE EDUCAÇÃO - PRODUÇÃO PRÓPRIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010330','Artigo 033 do Anexo I do RICMS','Isenção - EXPOSIÇÕES/FEIRAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010340','Artigo 034 do Anexo I do RICMS','Isenção - FUNDAÇÃO NACIONAL DE SAÚDE - IMPORTAÇÃO - MEDICAMENTOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010360','Artigo 036 do Anexo I do RICMS','Isenção - HORTIFRUTIGRANJEIROS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010370','Artigo 037 do Anexo I do RICMS','Isenção - IMPORTAÇÃO - HIPÓTESES DIVERSAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010380','Artigo 038 do Anexo I do RICMS','Isenção - IMPORTAÇÃO DE PRODUTOS HOSPITALARES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010390','Artigo 039 do Anexo I do RICMS','Isenção - IMPORTAÇÃO - RETORNO DE EXPORTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010400','Artigo 040 do Anexo I do RICMS','Isenção - IMPORTAÇÃO - SANEAMENTO BÁSICO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010410','Artigo 041 do Anexo I do RICMS','Isenção - INSUMOS AGROPECUÁRIOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010420','Artigo 042 do Anexo I do RICMS','Isenção - ITAIPU BINACIONAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010440','Artigo 044 do Anexo I do RICMS','Isenção - LOJA FRANCA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010510','Artigo 051 do Anexo I do RICMS','Isenção - ÓLEO LUBRIFICANTE USADO OU CONTAMINADO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010520','Artigo 052 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - DOAÇÕES PARA A SECRETARIA DA EDUCAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010530','Artigo 053 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - DOAÇÕES PARA VÍTIMAS DA SECA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010540','Artigo 054 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - DOAÇÕES PARA VÍTIMAS DE CATÁSTROFES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010550','Artigo 055 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - AQUISIÇÃO DE BENS, MERCADORIAS OU SERVIÇOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010560','Artigo 056 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - IMPORTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010590','Artigo 059 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - PRODUTO FARMACÊUTICO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010600','Artigo 060 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - PRODUTOS E EQUIPAMENTOS MÉDICOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010630','Artigo 063 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - VEÍCULOS PARA AS SECRETARIAS DA FAZENDA E DE SEGURANÇA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010640','Artigo 064 do Anexo I do RICMS','Isenção - PENITENCIÁRIAS - MERCADORIAS PRODUZIDAS POR DETENTOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010680','Artigo 068 do Anexo I do RICMS','Isenção - PRÓ-TAMAR','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010710','Artigo 071 do Anexo I do RICMS','Isenção - REPRESENTAÇÕES DIPLOMÁTICAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010730','Artigo 073 do Anexo I do RICMS','Isenção - REPRODUTOR/MATRIZ','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010750','Artigo 075 do Anexo I do RICMS','Isenção - SANGUE - IMPORTAÇÃO DE INSUMOS POR ENTIDADE DE HEMATOLOGIA OU HEMOTERAPIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010760','Artigo 076 do Anexo I do RICMS','Isenção - SENAI, SENAC E SENAR','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010770','Artigo 077 do Anexo I do RICMS','Isenção - TÁXI - PRESTAÇÃO DE SERVIÇO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010780','Artigo 078 do Anexo I do RICMS','Isenção - TRANSPORTE DE PASSAGEIROS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010800','Artigo 080 do Anexo I do RICMS','Isenção - TRENS METROPOLITANOS - IMPORTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010820','Artigo 082 do Anexo I do RICMS','Isenção - VASILHAME/RECIPIENTE/EMBALAGEM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010830','Artigo 083 do Anexo I do RICMS','Isenção - VÍTIMAS DE CALAMIDADES - DOAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010840','Artigo 084 do Anexo I do RICMS','Isenção - ZONA FRANCA DE MANAUS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010880','Artigo 088 do Anexo I do RICMS','Isenção - TÁXI - VEÍCULO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010890','Artigo 089 do Anexo I do RICMS','Isenção - AGROTÓXICO - EMBALAGEM - VAZIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010910','Artigo 091 do Anexo I do RICMS','Isenção - FUNDO SOCIAL DE SOLIDARIEDADE- DOAÇÕES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010920','Artigo 092 do Anexo I do RICMS','Isenção - MEDICAMENTOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010940','Artigo 094 do Anexo I do RICMS','Isenção - MEDICAMENTOS - ÓRGÃOS PÚBLICOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010970','Artigo 097 do Anexo I do RICMS','Isenção - PROGRAMA DE SEGURANÇA ALIMENTAR E NUTRICIONAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010980','Artigo 098 do Anexo I do RICMS','Isenção - ALGODÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP010990','Artigo 099 do Anexo I do RICMS','Isenção - BORRACHA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011010','Artigo 101 do Anexo I do RICMS','Isenção - COELHO E AVE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011020','Artigo 102 do Anexo I do RICMS','Isenção - GADO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011030','Artigo 103 do Anexo I do RICMS','Isenção - LEITE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011040','Artigo 104 do Anexo I do RICMS','Isenção - HORTIFRUTIGRANJEIROS PARA INDUSTRIALIZAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011050','Artigo 105 do Anexo I do RICMS','Isenção - PARTES E PEÇAS PARA FABRICAÇÃO DE TRATOR, CAMINHÃO E ÔNIBUS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011070','Artigo 107 do Anexo I do RICMS','Isenção - INDÚSTRIA NAVAL/INFRA-ESTRUTURA PORTUÁRIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011090','Artigo 109 do Anexo I do RICMS','Isenção - AERONAVES - INSUMOS PARA A FABRICAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011120','Artigo 112 do Anexo I do RICMS','Isenção - FUNDAÇÃO ZERBINI','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011130','Artigo 113 do Anexo I do RICMS','Isenção - AMIGOS DO BEM - DOAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011150','Artigo 115 do Anexo I do RICMS','Isenção - FARMÁCIA POPULAR DO BRASIL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011160','Artigo 116 do Anexo I do RICMS','Isenção - REPORTO - MODERNIZAÇÃO DE ZONAS PORTUÁRIAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011170','Artigo 117 do Anexo I do RICMS','Isenção - DEPÓSITO AFIANÇADO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011190','Artigo 119 do Anexo I do RICMS','Isenção - PILHAS E BATERIAS USADAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011200','Artigo 120 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - PROGRAMAS DE FORTALECIMENTO E MODERNIZAÇÃO ESTADUAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011230','Artigo 123 do Anexo I do RICMS','Isenção - FARINHA DE MANDIOCA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011270','Artigo 127 do Anexo I do RICMS','Isenção - PEÇA DE VEÍCULO AUTOMOTOR SUBSTITUÍDA EM GARANTIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011290','Artigo 129 do Anexo I do RICMS','Isenção - REAGENTE PARA DIAGNÓSTICO DA DOENÇA DE CHAGAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011300','Artigo 130 do Anexo I do RICMS','Isenção - MEDICAMENTOS E EQUIPAMENTOS DESTINADOS À PESQUISA COM SERES HUMANOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011320','Artigo 132 do Anexo I do RICMS','Isenção - PEÇA SUBSTITUÍDA EM VIRTUDE DE GARANTIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011330','Artigo 133 do Anexo I do RICMS','Isenção - METRÔ - IMPLANTAÇÃO DA LINHA 4','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011340','Artigo 134 do Anexo I do RICMS','Isenção - PROGRAMA CAMINHO DA ESCOLA - MINISTÉRIO DA EDUCAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011350','Artigo 135 do Anexo I do RICMS','Isenção - FARINHA DE TRIGO E PRODUTOS RESULTANTES DE SUA INDUSTRIALIZAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011360','Artigo 136 do Anexo I do RICMS','Isenção - GESAC - GOVERNO FEDERAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011370','Artigo 137 do Anexo I do RICMS','Isenção - ÓLEO COMESTÍVEL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011400','Artigo 140 do Anexo I do RICMS','Isenção - OPERAÇÕES INTERNAS COM MAÇÃ E PÊRA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011420','Artigo 142 do Anexo I do RICMS','Isenção - AACD','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011430','Artigo 143 do Anexo I do RICMS','Isenção - PEÇA DE AERONAVE SUBSTITUÍDA EM VIRTUDE DE GARANTIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011470','Artigo 147 do Anexo I do RICMS','Isenção - ÓRGÃOS PÚBLICOS - EQUIPAMENTOS DE SEGURANÇA ELETRÔNICA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011480','Artigo 148 do Anexo I do RICMS','Isenção - IMPORTAÇÃO - FORÇAS ARMADAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011490','Artigo 149 do Anexo I do RICMS','Isenção - SERVIÇO DE TRANSPORTE - EXPORTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011500','Artigo 150 do Anexo I do RICMS','Isenção - GRIPE A - MEDICAMENTO PARA TRATAMENTO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011510','Artigo 151 do Anexo I do RICMS','Isenção - LOCOMOTIVA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011520','Artigo 152 do Anexo I do RICMS','Isenção - UNIÃO DOS ESCOTEIROS DO BRASIL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011530','Artigo 153 do Anexo I do RICMS','Isenção - FUNDAÇÃO FACULDADE DE MEDICINA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011540','Artigo 154 do Anexo I do RICMS','Isenção - TRATAMENTO DE CÂNCER','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011550','Artigo 155 do Anexo I do RICMS','Isenção - TRANSPORTE DE PASSAGEIROS - CPTM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011560','Artigo 156 do Anexo I do RICMS','Isenção - OBRA SOCIAL NOSSA SENHORA DA GLÓRIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011570','Artigo 157 do Anexo I do RICMS','Isenção - HEMOBRÁS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011580','Artigo 158 do Anexo I do RICMS','Isenção - TREM, LOCOMOTIVA OU VAGÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011590','Artigo 159 do Anexo I do RICMS','Isenção - MATÉRIA-PRIMA, MATERIAL SECUNDÁRIO, EMBALAGENS, PARTES, PEÇAS, MÁQUINAS E EQUIPAMENTOS - TRANSPORTE PÚBLICO SOBRE TRILHOS DE PASSAGEIROS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011600','Artigo 160 do Anexo I do RICMS','Isenção - METRÔ - IMPLANTAÇÃO DA LINHA 6','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011610','Artigo 161 do Anexo I do RICMS','Isenção - METRÔ - IMPLANTAÇÃO DA LINHA 18','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011620','Artigo 162 do Anexo I do RICMS','Isenção - PARCERIA PÚBLICO-PRIVADA - HOSPITAIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011660','Artigo 166 do Anexo I do RICMS','Isenção - ENERGIA ELÉTRICA - MICROGERADORES E  MINIGERADORES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011680','Artigo 168 do Anexo I do RICMS','Isenção - ARROZ','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011690','Artigo 169 do Anexo I do RICMS','Isenção - FEIJÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011700','Artigo 170 do Anexo I do RICMS','Isenção - ENERGIA SOLAR - PRÉDIOS PÚBLICOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011710','Artigo 171 do Anexo I do RICMS','Isenção - IPT - MATERIAIS DE REFERÊNCIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011730','Artigo 173 do Anexo I do RICMS','Isenção - AME - MEDICAMENTO PARA TRATAMENTO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011740','Artigo 174 do Anexo I do RICMS','Isenção - AUTOMATED PEOPLE MOVER','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011760','Artigo 176 do Anexo I do RICMS','Isenção - ABSORVENTES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011770','Artigo 177 do Anexo I do RICMS','Isenção - ACELERADORES LINEARES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011780','Artigo 178 do Anexo I do RICMS','Isenção - METRÔ - EXPANSÃO DA LINHA 2','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011790','Artigo 179 do Anexo I do RICMS','Isenção - FIBROSE CÍSTICA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011810','Artigo 181 do Anexo I do RICMS','Isenção - EQUIPAMENTOS RECREATIVOS PARA USO EM PARQUE DE DIVERSÃO - IMPORTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011820','Artigo 182 do Anexo I do RICMS','Isenção - REFEIÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011830','Artigo 183 do Anexo I do RICMS','Isenção - LEVEDURAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011840','Artigo 184 do Anexo I do RICMS','Isenção - TREM INTERCIDADES - TIC EIXO NORTE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP011850','Artigo 185 do Anexo I do RICMS','Isenção - ÁREAS DE LIVRE COMÉRCIO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020010','Artigo 001 do Anexo II do RICMS','Redução de Base de Cálculo - AERONAVES, PARTES E PEÇAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020030','Artigo 003 do Anexo II do RICMS','Redução de Base de Cálculo - CESTA BÁSICA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020080','Artigo 008 do Anexo II do RICMS','Redução de Base de Cálculo - GÁS NATURAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020090','Artigo 009 do Anexo II do RICMS','Redução de Base de Cálculo - INSUMOS AGROPECUÁRIOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020100','Artigo 010 do Anexo II do RICMS','Redução de Base de Cálculo - INSUMOS AGROPECUÁRIOS - RAÇÕES E ADUBOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020110','Artigo 011 do Anexo II do RICMS','Redução de Base de Cálculo - MÁQUINAS, APARELHOS E VEÍCULOS USADOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020120','Artigo 012 do Anexo II do RICMS','Redução de Base de Cálculo - MÁQUINAS INDUSTRIAIS E IMPLEMENTOS AGRÍCOLAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020150','Artigo 015 do Anexo II do RICMS','Redução de Base de Cálculo - PÓ DE ALUMÍNIO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020190','Artigo 019 do Anexo II do RICMS','Redução de Base de Cálculo - TRANSPORTE DE LEITE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020260','Artigo 026 do Anexo II do RICMS','Redução de Base de Cálculo - DESENVOLVIMENTO INDUSTRIAL E AGROPECUÁRIO - EMBALAGENS PARA OVO IN NATURA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020290','Artigo 029 do Anexo II do RICMS','Redução de Base de Cálculo - CARROÇARIA DE ÔNIBUS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020300','Artigo 030 do Anexo II do RICMS','Redução de Base de Cálculo - PRODUTOS DE COURO, SAPATOS, BOLSAS, CINTOS, CARTEIRAS E OUTROS ACESSÓRIOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020320','Artigo 032 do Anexo II do RICMS','Redução de Base de Cálculo - ATACADISTA DE COURO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020330','Artigo 033 do Anexo II do RICMS','Redução de Base de Cálculo - VINHO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020340','Artigo 034 do Anexo II do RICMS','Redução de Base de Cálculo - PERFUMES, COSMETICOS E PRODUTOS DE HIGIENE PESSOAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020350','Artigo 035 do Anexo II do RICMS','Redução de Base de Cálculo - INSTRUMENTOS MUSICAIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020370','Artigo 037 do Anexo II do RICMS','Redução de Base de Cálculo - BRINQUEDOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020380','Artigo 038 do Anexo II do RICMS','Redução de Base de Cálculo - REGIME DE ADMISSÃO TEMPORÁRIA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020390','Artigo 039 do Anexo II do RICMS','Redução de Base de Cálculo - PRODUTOS ALIMENTÍCIOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020450','Artigo 045 do Anexo II do RICMS','Redução de Base de Cálculo - CARNE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020520','Artigo 052 do Anexo II do RICMS','Redução de Base de Cálculo - PRODUTOS TÊXTEIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020530','Artigo 053 do Anexo II do RICMS','Redução de Base de Cálculo - HIDROCARBONETOS LÍQUIDOS - SOLVENTES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020550','Artigo 055 do Anexo II do RICMS','Redução de Base de Cálculo - LÂMPADAS LED, LUMINÁRIAS LED, REFLETORES LED, FITAS LED E PAINÉIS LED','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020560','Artigo 056 do Anexo II do RICMS','Redução de Base de Cálculo - MDP, MDF e CHAPAS DE FIBRAS DE MADEIRA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020580','Artigo 058 do Anexo II do RICMS','Redução de Base de Cálculo - BARRAS DE AÇO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020590','Artigo 059 do Anexo II do RICMS','Redução de Base de Cálculo - TRATAMENTO DE EFLUENTES DOMÉSTICOS E INDUSTRIAIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020610','Artigo 061 do Anexo II do RICMS','Redução de Base de Cálculo - SUCO DE LARANJA','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020620','Artigo 062 do Anexo II do RICMS','Redução de Base de Cálculo - SOLUÇÃO PARENTERAL','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020630','Artigo 063 do Anexo II do RICMS','Redução de Base de Cálculo - REGIME DE TRIBUTAÇÃO UNIFICADA - RTU','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020650','Artigo 065 do Anexo II do RICMS','Redução de Base de Cálculo - CARROCERIAS SOBRE CHASSI, VAGÕES FERROVIÁRIOS DE CARGA, CARROCERIAS PARA VEÍCULOS AUTOMÓVEIS, REBOQUES E SEMIRREBOQUES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020660','Artigo 066 do Anexo II do RICMS','Redução de Base de Cálculo - TUBOS, LAMINADOS E LIGAS DE COBRE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020690','Artigo 069 do Anexo II do RICMS','Redução de Base de Cálculo - BIOGÁS E BIOMETANO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020710','Artigo 071 do Anexo II do RICMS','Redução de Base de Cálculo - AMIDO DE MILHO, GLICOSE E XAROPE DE GLICOSE, OUTROS AÇÚCARES E XAROPES DE AÇÚCARES ORIUNDOS DO MILHO, AMIDO MODIFICADO E DEXTRINA DE MILHO, COLAS À BASE DE AMIDOS DE MILHO, DE DEXTRINA OU DE OUTROS AMIDOS MODIFICADOS DE MILHO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP050710','Artigo 071 do Anexo II do RICMS, § 1º','Diferimento amparado por regime especial concedido nos termos do § 1º do artigo 71 do Anexo II do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020740','Artigo 074 do Anexo II do RICMS','Redução de Base de Cálculo - CARNE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020750','Artigo 075 do Anexo II do RICMS','Redução de Base de Cálculo - PNEUS E CÂMARAS DE AR - SAÍDAS INTERNAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020770','Artigo 077 do Anexo II do RICMS','Redução de Base de Cálculo - INSUMOS AGROPECUÁRIOS - ADUBOS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020780','Artigo 078 do Anexo II do RICMS','Redução de Base de Cálculo - FABRICANTE DE ÔNIBUS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP020800','Artigo 080 do Anexo II do RICMS','Redução de Base de Cálculo - IMPORTAÇÃO POR REMESSAS POSTAIS OU EXPRESSAS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP040100','Decreto 51.597/07','Tributação sobre a Receita Bruta - FORNECIMENTO DE ALIMENTAÇÃO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP040200','Decreto 62.647/17','Tributação sobre a Receita Bruta - COMÉRCIO VAREJISTA DE CARNES','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP018000','Decreto 63.208/18','Isenção - REPETRO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP028000','Decreto 63.208/18','Redução de Base de Cálculo - REPETRO','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP029000','Decreto 51.624/07','Redução de Base de Cálculo - Indústria de informática','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070010','Artigo 7º, I do RICMS','Não incidência - Saída de mercadoria com destino a armazém geral situado neste Estado, para depósito em nome do remetente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070020','Artigo 7º, II do RICMS','Não incidência - Saída de mercadoria com destino a depósito fechado, localizado neste Estado, do próprio contribuinte','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070030','Artigo 7º, III do RICMS','Não incidência - Saída de mercadoria de estabelecimento referido no inciso I ou II, em retorno ao estabelecimento depositante','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070040','Artigo 7º, IV do RICMS','Não incidência - Saída de mercadoria, pertencente a terceiro, de estabelecimento de empresa de transporte ou de depósito, por conta e ordem desta, ressalvada a aplicação do disposto no inciso X do Artigo 2º','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070050','Artigo 7º, V do RICMS','Não incidência - Saída de mercadoria com destino ao exterior e a prestação que destine serviço ao exterior','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070060','Artigo 7º, VI do RICMS','Não incidência - Saída com destino a outro Estado de energia elétrica ou de petróleo, inclusive lubrificante ou combustível líquido ou gasoso, dele derivados','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070070','Artigo 7º, VII do RICMS','Não incidência - Saída e o correspondente retorno de equipamentos e materiais, promovidos por pessoa ou entidade adiante indicada, utilizados exclusivamente nas operações vinculadas às suas atividades ou finalidades essenciais, observado o disposto no § 4º: a) a União, os Estados e os Municípios; b) os templos de qualquer culto; c) os partidos políticos e suas fundações, as entidades sindicais dos trabalhadores e as instituições de educação ou de assistência social, sem fins lucrativos, atendidos os requisitos da lei','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070080','Artigo 7º, VIII do RICMS','Não incidência - Saída, de estabelecimento prestador de serviço de qualquer natureza definido em lei complementar como de competência tributária do município, de mercadoria a ser ou que tenha sido utilizada na prestação de tal serviço, ressalvadas as hipóteses previstas na alínea "b" do inciso III do artigo 2º','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070090','Artigo 7º, IX do RICMS','Não incidência - Saída de máquinas, equipamentos, ferramentas ou objetos de uso do contribuinte, bem como de suas partes e peças, com destino a outro estabelecimento para lubrificação, limpeza, revisão, conserto, restauração ou recondicionamento ou em razão de empréstimo ou locação, desde que os referidos bens voltem ao estabelecimento de origem','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070100','Artigo 7º, X do RICMS','Não incidência - Saída, em retorno ao estabelecimento de origem, de bem mencionado no inciso anterior, ressalvadas as hipóteses de fornecimento de mercadoria previstas no inciso III do artigo 2º','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070110','Artigo 7º, XI do RICMS','Não incidência - Operação com ouro, quando definido em lei como ativo financeiro ou instrumento cambial','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070120','Artigo 7º, XII do RICMS','Não incidência - Operação decorrente de alienação fiduciária em garantia, bem como sobre a operação posterior ao vencimento do respectivo contrato de financiamento efetuada pelo credor fiduciário em razão do inadimplemento do devedor;','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070130','Artigo 7º, XIII do RICMS','Não incidência - Operação ou prestação que envolver livro, jornal ou periódico ou o papel destinado à sua impressão','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070140','Artigo 7º, XIV do RICMS','Não incidência - Saída de bem do ativo permanente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070150','Artigo 7º, XV do RICMS','Não incidência - Saída, com destino a outro estabelecimento do mesmo titular, de material de uso ou consumo','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070160','Artigo 7º, XVI do RICMS','Não incidência - Operação de qualquer natureza de que decorra a transmissão de bens móveis salvados de sinistro para companhias seguradoras.','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070170','Artigo 7º, XVII do RICMS','Não incidência - Saída de bem ou mercadoria com destino ao exterior sob amparo do Regime Aduaneiro Especial de Exportação Temporária, bem como a posterior reimportação, em retorno, desse mesmo bem ou mercadoria, desde que observados os prazos e condições previstos na legislação federal','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP070180','Artigo 7º, XVIII do RICMS','Não incidência - Operações e prestações praticadas por órgãos da administração pública direta estadual paulista, bem como pelas autarquias e fundações instituídas e mantidas pelo Estado de São Paulo','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP052600','Artigo 260 do RICMS','Diferimento - Saída promovida por produtor situado em território paulista com destino a comerciante, industrial, cooperativa ou qualquer outro contribuinte, exceto produtor','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053160','Artigo 316 do RICMS','Diferimento - Prestação de serviço de transporte de carga, com início em território paulista, realizada por transportador autônomo, qualquer que seja o seu domicílio, ou por empresa transportadora estabelecida fora do território paulista, inclusive a optante pelo Regime Especial Unificado de Arrecadação de Tributos e Contribuições devidos pelas Microempresas e Empresas de Pequeno Porte - “Simples Nacional” e não inscrita no Cadastro de Contribuintes','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053190','Artigo 319 do RICMS','Suspensão - Saída de mercadoria remetida para demonstração, inclusive com destino a consumidor ou usuário final, até o momento em que ocorrer a transmissão de sua propriedade','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053191','Artigo 319-A do RICMS','Suspensão - Saída de mercadoria remetida para mostruário, condicionada ao seu retorno ao estabelecimento de origem em até 180 (cento e oitenta) dias','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053260','Artigo 326 do RICMS','Suspensão - Saída, de estabelecimento fabricante, de produtos específicos com destino a hospitais para utilização em cirurgia cardiovascular ou de implantação de prótese de silicone','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053270','Artigo 327 do RICMS','Suspensão - Saída de moldes, matrizes, gabaritos, padrões, chapelonas, modelos e estampos, não integrados ao ativo imobilizado, para fornecimento de trabalho fora do estabelecimento, ou com destino a outro estabelecimento inscrito como contribuinte para serem utilizados na elaboração de produtos encomendados pelo remetente, e desde que devam retornar ao estabelecimento de origem dentro do prazo de 180 (cento e oitenta) dias','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053271','Artigo 327-A do RICMS','Suspensão - Desembaraço aduaneiro de mercadoria ou bem importados sem cobertura cambial, destinados à manutenção e ao reparo de aeronave pertencente a empresa autorizada a operar no transporte comercial internacional, e utilizados nessa atividade para estocagem no Regime Aduaneiro Especial de Depósito Afiançado (DAF), nos termos da legislação federal','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053272','Artigo 327-D do RICMS','Suspensão - Saída de partes, peças e componentes aeronáuticos para estoque próprio em poder de terceiros','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053273','Artigo 327-H do RICMS','Suspensão - Desembaraço aduaneiro de mercadoria ou bem importado do exterior e admitido nos Regimes Aduaneiros Especiais de Depósito Especial, Entreposto Aduaneiro na Importação e Trânsito Aduaneiro','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053274','Artigo 327-I do RICMS','Suspensão - Desembaraço aduaneiro de cátodo de cobre, NCM 7403.11.00, quando a importação for efetuada diretamente por estabelecimento industrial que realize a metalurgia do cobre importado em seu próprio estabelecimento localizado em território paulista, na proporção de 33,33% (trinta e três inteiros e trinta e três centésimos por cento) do valor da respectiva base de cálculo, para o momento em que o estabelecimento importador promover a saída do produto resultante da industrialização','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053275','Artigo 327-J do RICMS','Suspensão ou diferimento amparado por regime especial concedido nos termos do artigo 327-J do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053276','Artigo 327-K do RICMS','Suspensão - Desembaraço aduaneiro de bens destinados à integração ao ativo imobilizado, importados do exterior por estabelecimento industrial paulista classificado na CNAE 29.10-7/01 – “Fabricação de automóveis, camionetas e utilitários”','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053280','Artigo 328 do RICMS','Diferimento - Saída de mercadoria, promovida por estabelecimento rural com destino a cooperativa de que fizer parte, situado neste Estado','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053290','Artigo 329 do RICMS','Diferimento - Saídas de algodão em caroço de produção paulista','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053300','Artigo 330 do RICMS','Diferimento - Saídas de algodão em pluma ou de caroço de algodão, resultantes do beneficiamento de algodão em caroço de produção paulista','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053330','Artigo 333 do RICMS','Diferimento - Saídas de café cru, em coco ou em grão','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053450','Artigo 345 do RICMS','Diferimento - Saídas internas das matérias-primas de produção paulista e subprodutos destinados à fabricação de açúcar, álcool ou melaço','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053460','Artigo 346 do RICMS','Diferimento - Saída interna dos produtos resultantes da industrialização de matérias-primas de produção paulista e subprodutos relacionados no § 4º do artigo 345, com destino à cooperativa de que faça parte o remetente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053461','Artigo 346-A do RICMS','Diferimento - Saídas com destino a empresa geradora de energia termoelétrica de bagaço e torta de filtro resultantes da fabricação de açúcar, álcool ou melaço, palha, cavaco e outros resíduos da colheita das matérias- primas indicadas no item 1 do § 4º do artigo 345 e água ou vapor d’água','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053462','Artigo 346-B do RICMS','Diferimento - Saídas internas de energia elétrica e de energia térmica (vapor d’água), promovidas por empresa geradora de energia termoelétrica, com destino a estabelecimento fabricante de açúcar, álcool ou melaço','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053480','Artigo 348 do RICMS','Diferimento - Saídas de feijão','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053500','Artigo 3​50 do RICMS','Diferimento - Saídas de produtos agropecuários relacionados no artigo 350 do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053512','Artigo 351-B do RICMS','Diferimento - Saída interna de amendoim em baga ou em grão de estabelecimento industrial beneficiador com destino a outro estabelecimento industrial, na proporção de 40% (quarenta por cento) do valor da operação.','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053520','Artigo 352 do RICMS','Diferimento - Ope​rações com cominho','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053521','Artigo 352-A do RICMS','Diferimento - Operações internas com trigo em grão, exceto para semeadura, classificado na posição 1001.00 da Nomenclatura Brasileira de Mercadorias - Sistema Harmonizado - NBM/SH','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053522','Artigo 352-B do RICMS','Diferimento - Operações internas com triticale, exceto para semeadura, classificado na posição 1008.60 da Nomenclatura Comum do Mercosul - Sistema Harmonizado - NCM/SH','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053530','Artigo 353 do RICMS','Diferimento - Saída dos produtos hortifrutigranjeiros em estado natural relacionados no artigo 36 do Anexo I do RICMS com destino a estabelecimento industrial localizado neste Estado, para fins de industrialização','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053540','Artigo 354 do RICMS','Diferimento - Primeira saída, para o território do Estado, de produto "in natura" relacionado no artigo 354 do RICMS, ainda que acondicionado ou embalado para transporte, promovida pelo estabelecimento em que tiver sido produzido, com destino a estabelecimento comercial ou industrial','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053550','Artigo 355 do RICMS','Diferimento - Operações com semente destinada ao plantio','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053560','Artigo 356 do RICMS','Diferimento - Operações com ração animal, concentrado ou suplemento, sendo o fabricante ou importador registrado no Ministério da Agricultura e do Abastecimento','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053570','Artigo 357 do RICMS','Diferimento - Operações com amônia, ácido nítrico, ácido sulfúrico, ácido fosfórico, cloreto de potássio, enxofre, fosfato de amônia, fosfato natural bruto, nitrato de amônio, ou de suas soluções, nitrocálcio, uréia, sulfato de amônio, MAP (mono-amônio-fosfato), DAP (di-amônio fosfato)','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053580','Artigo 358 do RICMS','Diferimento - Operações com adubo, simples ou composto, fertilizante, calcário ou gesso, destinados exclusivamente a uso na agricultura','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053590','Artigo 359 do RICMS','Diferimento - Operações com acaricida, carrapaticida, desfolhante, desinfetante, dessecante, espalhante adesivo, estimulador ou inibidor de crescimento (regulador), germicida, fungicida, formicida, herbicida, inseticida, nematicida, parasiticida, raticida, sarnicida, soro ou medicamento de uso veterinário, vacina, vermífugo, vermicida, com destinação exclusiva a uso na agricultura, pecuária, apicultura, aqüicultura, avicultura, cunicultura, ranicultura ou sericicultura','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053600','Artigo 360 do RICMS','Diferimento - Operações realizadas com insumos destinados à alimentação animal ou a emprego na composição ou fabricação de ração animal, concentrado ou suplemento, em qualquer caso com destinação exclusiva a uso na pecuária, apicultura, aqüicultura, avicultura, cunicultura, ranicultura, ou sericicultura','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053610','Artigo 361 do RICMS','Diferimento - Operações realizadas com insumos agropecuários indicados no artigo 361 do RICMS','Aplicação suspensa enquanto vigorar o benefício fiscal de isenção previsto no artigo 41 do Anexo I e de redução da base de cálculo previsto no artigo 77 do Anexo II, exclusivamente em relação aos produtos ali indicados, conforme artigo 17 DDTT do RICMS (diferimento dos artigos 355 a 361).');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053611','Artigo 361-A do RICMS','Diferimento - Primeira saída de levedura inativa seca, levedura autolisada, levedura hidrolisada, parede celular de levedura e extrato de levedura','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053620','Artigo 362 do RICMS','Diferimento - Saídas de coelho','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053630','Artigo 363 do RICMS','Diferimento - Saídas de aves','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053640','Artigo 364 do RICMS','Diferimento - Operações com gado em pé bovino ou suíno','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053650','Artigo 365 do RICMS','Diferimento - Operações com gado em pé das demais espécies','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053830','Artigo 383 do RICMS','Diferimento - Saídas internas de subprodutos da matança do gado (couro ou pele, em estado fresco, salmourado ou salgado, de produto gorduroso não comestível de origem animal, inclusive o sebo, de osso, de chifre ou de casco)','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053880','Artigo 388, § 13 do RICMS','Suspensão - Saída de equino de raça com idade superior a 3 (três) anos para fora do Estado, para cobertura ou para participação em provas ou para treinamento, e cujo imposto ainda não tenha sido pago, desde que emitida a Nota Fiscal respectiva e que o retorno do animal ocorra dentro do prazo de 60 (sessenta) dias, prorrogável, uma única vez, por período igual ou menor, a critério da repartição fiscal a que estiver vinculado o remetente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053890','Artigo 389 do RICMS','Diferimento - Saídas de leite cru, pasteurizado ou reidratado','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053910','Artigo 391 do RICMS','Diferimento - Operações internas com pescados, exceto os crustáceos e os moluscos, em estado natural, resfriados, congelados, salgados, secos, eviscerados, filetados, postejados ou defumados para conservação, desde que não enlatados ou cozidos, excluídas as saídas internas realizadas por estabelecimento que tenha como CNAE principal os códigos 1020-1/01 ou 1020-1/02','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053920','Artigo 392 do RICMS','Diferimento - Saídas de papel usado ou apara de papel, sucata de metal, caco de vidro, retalho, fragmento ou resíduo de plástico, de borracha ou de tecido','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053941','Artigo 394-A do RICMS','Diferimento - Saídas de garrafas PET usadas e do produto resultante de sua moagem ou trituração','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053942','Artigo 394-B do RICMS','Diferimento - Saídas internas de garrafas de vidro com valor comercial','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053951','Artigo 395-A do RICMS','Diferimento - Operação interna promovida pelo estabelecimento fabricante de partes, peças e componentes destinados ao estabelecimento fabricante de máquinas e equipamentos de uso na extração mineral e na construção, classificado no código do grupo 285 da Classificação Nacional de Atividades Econômicas - CNAE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053952','Artigo 395-B do RICMS','Suspensão - Desembaraço aduaneiro de partes, peças e componentes, quando a importação for efetuada diretamente por estabelecimento fabricante de máquinas e equipamentos de uso na extração mineral e na construção, classificado no código do grupo 285 da Classificação Nacional de Atividades Econômicas - CNAE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053953','Artigo 395-C do RICMS','Diferimento - Saída interna de matéria-prima e produto intermediário destinados a estabelecimento fabricante de fogões, refrigeradores, congeladores (freezers), máquinas de lavar louça, máquinas de lavar roupa ou máquinas de secar roupa, fornos elétricos de cozinha do tipo fritadeira a ar, ventiladores de mesa e liquidificadores de uso doméstico.','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053954','Artigo 395-C1 do RICMS','Diferimento - Saída interna de matéria-prima e produto intermediário destinados a estabelecimento fabricante de compressores para uso não industrial, classificado no código 2814-3/02 da Classificação Nacional de Atividades Econômicas - CNAE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053955','Artigo 395-D do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima e produto intermediário, quando a importação for efetuada diretamente por estabelecimento fabricante de fogões, refrigeradores, congeladores (freezers), máquinas de lavar louça, máquinas de lavar roupa ou máquinas de secar roupa, fornos elétricos de cozinha do tipo fritadeira a ar, ventiladores de mesa e liquidificadores de uso doméstico.','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053956','Artigo 395-F do RICMS','Diferimento - Saída interna de matéria-prima e produto intermediário, destinados estabelecimento fabricante classificado no código 2740-6/01 da CNAE, para fabricação de lâmpada LED (NCM 8543.70.99), luminária LED (NCM 9405.10.99), refletor LED (NCM 9405.10.93), fita LED (NCM 9405.40.90) e painel LED (NCM 8531.20.00) ou no código 2740-6/02 da CNAE, para fabricação de luminária LED (NCM 9405.40.90).','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053957','Artigo 395-G do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima e produto intermediário, quando a importação for efetuada diretamente por estabelecimento fabricante classificado no código 2740-6/01 da CNAE, para fabricação de lâmpada LED (NCM 8543.70.99), luminária LED (NCM 9405.10.99), refletor LED (NCM 9405.10.93), fita LED (NCM 9405.40.90) e painel LED (NCM 8531.20.00) ou no código 2740-6/02 da CNAE, para fabricação de luminária LED (NCM 9405.40.90).','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053958','Artigo 395-I do RICMS','Diferimento - Saída interna de matéria-prima e produto intermediário destinados a estabelecimento fabricante de células fotovoltaicas em módulos ou painéis, classificadas nos códigos 8541.40.31 ou 8541.40.32 da Nomenclatura Comum do Mercosul - NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053959','Artigo 395-J do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima e produto intermediário, quando a importação for efetuada diretamente por estabelecimento fabricante de células fotovoltaicas em módulos ou painéis, classificadas nos códigos 8541.40.31 ou 8541.40.32 da Nomenclatura Comum do Mercosul - NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053960','Artigo 395-L do RICMS','Diferimento - Saída interna efetuada pelo estabelecimento fabricante de resina de uréia-formaldeído, classificada nos códigos 3909.10.00 ou 3909.20.29 da Nomenclatura Comum do Mercosul - NCM, com destino a estabelecimento fabricante dos produtos relacionados no Artigo 395-L do RICMS, na proporção de 33,33% (trinta e três inteiros e trinta e três centésimos por cento) do valor da operação','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059900','Artigo 395-M do RICMS','Diferimento - Saída interna de matéria-prima e outros insumos produzidos em território paulista e destinados ao processo de industrialização de biodiesel ou máquinas, equipamentos, peças, partes e acessórios destinados a integrar o ativo imobilizado de estabelecimento fabricante de biodiesel','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059901','Artigo 395-N do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima e outros insumos produzidos em território paulista e destinados ao processo de industrialização de biodiesel ou máquinas, equipamentos, peças, partes e acessórios destinados a integrar o ativo imobilizado de estabelecimento fabricante de biodiesel','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059902','Artigo 395-P do RICMS','Diferimento - Saída interna de matéria-prima e insumos exclusivamente a estabelecimento fabricante de ônibus ou carroçaria de ônibus ou máquinas e equipamentos destinados a estabelecimento fabricante de ônibus ou carroçaria de ônibus para integração ao ativo imobilizado','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059903','Artigo 395-Q do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima e insumos importados diretamente por estabelecimento fabricante de ônibus ou carroçaria de ônibus ou máquinas e equipamentos destinados a integrar o ativo imobilizado de estabelecimento fabricante de ônibus ou carroçaria de ônibus','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059904','Artigo 395-V do RICMS','Diferimento - Saída interna de máquinas e equipamentos destinados a integrar o ativo imobilizado de estabelecimento fabricante de sucos de fruta e sucos mistos','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059905','Artigo 395-W do RICMS','Suspensão - Desembaraço aduaneiro de máquinas e equipamentos destinados a integrar o ativo imobilizado de estabelecimento fabricante de sucos de fruta e sucos mistos','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP053961','Artigo 396-A do RICMS','Suspensão - Desembaraço aduaneiro de partes, peças, componentes e matérias-primas, quando a importação for efetuada diretamente por estabelecimento fabricante de produtos da indústria de processamento eletrônico de dados, abrangido pelo artigo 4° da Lei federal n° 8.248, de 23 de outubro de 1991, para serem utiliza dos na fabricação de produto da referida indústria','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054001','Artigo 400-D do RICMS','Diferimento - Operações internas com alumínio em formas brutas, alumínio não ligado, ligas de alumínio, inclusive a granalha de alumínio, e quaisquer outras mercadorias classificadas na posição 7601 da Nomenclatura Brasileira de Mercadorias - Sistema Harmonizado - NBM/SH','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054002','Artigo 400-E1 do RICMS','Diferimento - Saída interna de vergalhão de alumínio classificado na posição 7605 da Nomenclatura Comum do Mercosul - NCM, promovida pelo estabelecimento fabricante com destino a estabelecimento fabricante de fios e cabos classificados na posição 7614 ou 8544 da Nomenclatura Comum do Mercosul - NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054003','Artigo 400-F do RICMS','Diferimento - Saída interna dos insumos relacionados no § 1º promovida pelo estabelecimento fabricante com destino a estabelecimento fabricante dos aminoácidos especificados no artigo 400-F do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054004','Artigo 400-G do RICMS','Suspensão - Desembaraço aduaneiro das mercadorias relacionadas no § 1º do artigo 400-F, quando a importação for efetuada diretamente por estabelecimento fabricante dos aminoácidos relacionados','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054005','Artigo 400-G1 do RICMS','Diferimento - Saída interna de lisina, classificada nos códigos 2922.41.10, 2922.41.90 e 2309.90.90 da Nomenclatura Comum do Mercosul - NCM, de triptofano, classificado nos códigos 2933.99.19, 2922.49.90 e 2309.90.90 da NCM, e de treonina, classificada nos códigos 2922.49.90, 2922.50.99 e 2309.90.90 da NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054006','Artigo 400-H do RICMS','Diferimento - Saída interna de mercadoria utilizada como matéria-prima ou produto intermediário na fabricação dos produtos para produção de energia eólica indicados no § 1º do Artigo 400-H do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054007','Artigo 400-I do RICMS','Suspensão - Desembaraço aduaneiro da mercadoria, sem similar produzida no país, utilizada como matéria-prima ou produto intermediário na fabricação dos produtos indicados no § 1º do artigo 400-H do RICMS, quando a importação for efetuada diretamente por estabelecimento fabricante dos referidos produtos','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054008','Artigo 400-J do RICMS','Diferimento - Saídas das embalagens industriais usadas indicadas no § 3º do Artigo 400-J do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054009','Artigo 400-K do RICMS','Diferimento - Saída interna de mercadoria utilizada como matéria-prima ou produto intermediário na fabricação de aquecedores solares de água, classificados no código 8419.19.10 da Nomenclatura Comum do MERCOSUL - NCM, fica diferido','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054010','Artigo 400-L do RICMS','Suspensão - Desembaraço aduaneiro da mercadoria, sem similar produzida no país, utilizada como matéria-prima ou produto intermediário na fabricação de aquecedor solar de água indicado no "caput" do artigo 400-K do RICMS, quando a importação for efetuada diretamente por estabelecimento fabricante do referido produto','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054011','Artigo 400-M do RICMS','Diferimento - Saída interna de mercadoria destinada a sociedade de propósito específico, localizada neste Estado, para posterior fornecimento como matéria-prima ou produto intermediário na fabricação de medicamento pela Fundação para o Remédio Popular - FURP','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054012','Artigo 400-N do RICMS','Suspensão - Desembaraço aduaneiro de mercadoria, sem similar produzida no país, destinada a sociedade de propósito específico, localizada neste Estado, para posterior fornecimento como matériaprima ou produto intermediário na fabricação de medicamento pela Fundação para o Remédio Popular - FURP, quando a importação for efetuada diretamente pela referida sociedade','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054013','Artigo 400-O do RICMS','Diferimento - Saídas internas de nafta para petroquímica, NCM 2710.12.41','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054014','Artigo 400-P do RICMS','Diferimento - Saídas internas de etileno, NCM 2901.21.00, e propeno, NCM 2901.22.00, destinadas a estabelecimento fabricante de polietileno, NCM 39.01, polipropileno, NCM 39.02, e policloreto de vinila, NCM 39.04','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054015','Artigo 400-S do RICMS','Suspensão - Desembaraço aduaneiro de nafta para petroquímica, NCM 2710.12.41, etileno, NCM 2901.21.00, e propeno, NCM 2901.22.00, quando a importação for efetuada diretamente por estabelecimento fabricante das referidas mercadorias ou de polietileno, NCM 39.01, polipropileno, NCM 39.02, e policloreto de vinila, NCM 39.04','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054016','Artigo 400-T do RICMS','Diferimento - Saída interna, promovida pelo estabelecimento fabricante, de mercadoria utilizada como embalagem para acondicionamento de leite esterilizado “longa vida” (UHT – Ultra High Temperature), classificada nos códigos 3920.10.99, 3923.30.00 e 4811.59.23 da NCM, com destino a estabelecimento fabricante classificado nas CNAEs 1051-1/00 e 1052-0/00','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054017','Artigo 400-U do RICMS','Diferimento - Saída interna de mercadoria utilizada como matéria-prima ou produto intermediário na fabricação de embarcações para esporte e lazer, classificadas na posição 8903 da Nomenclatura Comum do MERCOSUL - NCM, com destino a fabricante das referidas embarcações','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054018','Artigo 400-V do RICMS','Suspensão - Desembaraço aduaneiro de mercadoria, sem similar produzida no país, utilizada como matéria-prima ou produto intermediário na fabricação das embarcações indicadas no "caput" do artigo 400-U, quando a importação for efetuada diretamente por estabelecimento fabricante das referidas embarcações','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054019','Artigo 400-W do RICMS','Diferimento - Saída interna de insumos agropecuários indicados no § 1º do Artigo 400-W do RICMS, realizada por estabelecimento centralizador de aquisição de insumos que pertença a sociedade que exerça exclusivamente atividade agropecuária, com destino a estabelecimento do mesmo titular','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054021','Artigo 400-X do RICMS','Diferimento - Saída interna, promovida pelo estabelecimento fabricante, de “stand up pouche” para embalagens de atomatados ou vegetais (NCM 3921.90.19 e 3923.29.10), de latas próprias para serem fechadas por soldadura ou cravação - próprias para acondicionar produtos alimentícios (NCM 7310.21.10), e de embalagem do tipo caixas e cartonagens, dobráveis, de papel ou cartão, não ondulados (NCM 4819.20.00) para acondicionamento de ervilha em conserva (NCM 2005.40.00), milho em conserva (NCM 2005.80.00), ervilha e cenoura, ervilha e milho, jardineira ou seleta (NCM 2005.90.00), com destino a estabelecimento fabricante classificado nas CNAEs 1031-7/00, 1069-4/00 e 1032-5/99','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054023','Artigo 400-Y do RICMS','Diferimento - Saída interna promovida pelo estabelecimento fabricante de partes, peças, componentes, matérias-primas e materiais de embalagem com destino a estabelecimento fabricante beneficiado pelo Programa de Apoio ao Desenvolvimento Tecnológico da Indústria de Semicondutores e Displays – PADIS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054024','Artigo 400-Z do RICMS','Suspensão - Desembaraço aduaneiro de partes, peças, componentes e matérias-primas, quando a importação for efetuada diretamente por estabelecimento fabricante beneficiado pelo Programa de Apoio ao Desenvolvimento Tecnológico da Indústria de Semicondutores e Displays – PADIS,','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054022','Artigo 400-Z1 do RICMS','Diferimento - Saída interna de negros-de-carbono (NCM 2803.00.19) e óleos combustíveis (NCM 2710.19.22) obtidos por meio da reciclagem de pneus e de resíduos de borracha, promovida pelo estabelecimento reciclador, com destino a estabelecimento industrial','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054025','Artigo 400-Z2 do RICMS','Diferimento - saída interna de resina de polipropileno, classificada no código 3902.10.20 da Nomenclatura Comum do Mercosul - NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054026','Artigo 400-Z3 do RICMS','Diferimento - Desembaraço aduaneiro e saída interna de insumos, matérias-primas, produtos intermediários e embalagens com destino a estabelecimento fabricante de máquinas e equipamentos para integração ao ativo imobilizado de fabricantes de celulose e de produtos de papel para uso doméstico e higiênico sanitário','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054027','Artigo 400-Z4 do RICMS','Diferimento - saída interna de cimento asfáltico de petróleo, classificado no código 2713.20.00 da Nomenclatura Comum do Mercosul - NCM, destinado a estabelecimento fabricante de cimento asfáltico de petróleo','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054028','Artigo 400-Z5 do RICMS','Diferimento - Saída interna de resíduo de óleo, classificado no código 2710.99.00 da Nomenclatura Comum do Mercosul - NCM, obtido por meio da reciclagem do material oleoso retirado de embarcações, promovida pelo estabelecimento reciclador','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054020','Artigo 402 do RICMS e Portaria CAT 22/2007','Suspensão ou diferimento - Saída de mercadoria com destino a outro estabelecimento ou a trabalhador autônomo ou avulso que prestar serviço pessoal, num e noutro caso, para industrialização por encomenda','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054110','Artigo 411 do RICMS','Diferimento - Operações com petróleo bruto, desde a importação ou extração, desde que o contribuinte que realize tais operações seja credenciado perante a Secretaria da Fazenda conforme disciplina por ela estabelecida.','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054111','Artigo 411-A do RICMS','Diferimento - Saída interna de óleo lubrificante básico decorrente do re-refino do óleo lubrificante usado ou contaminado, processado de acordo com a legislação em vigor por empresas devidamente autorizadas pelo órgão federal competente, quando destinado a fabricante de óleo lubrificante para utilização exclusiva como matéria-prima na sua produção','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054112','Artigo 411-B do RICMS','Diferimento - Saída interna de lubrificantes derivados de petróleo classificados nos códigos 2710.19.31 e 2710.19.32 da NCM, de aditivos classificados no código 3811 da NCM e de material de embalagem, quando destinados a fabricante localizado neste Estado de óleo ou graxa lubrificantes derivados de petróleo, para utilização exclusiva como matéria-prima na sua produção ou como embalagem para o seu acondicionamento','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054113','Artigo 411-C do RICMS','Suspensão - Desembaraço aduaneiro, que ocorra em território paulista, de lubrificantes derivados do petróleo classificados nos códigos 2710.19.31 e 2710.19.32 da NCM, de aditivos classificados no código 3811 da NCM e de material de embalagem, quando a importação for realizada por fabricante localizado neste Estado de óleo ou graxa lubrificantes derivados de petróleo, para utilização exclusiva como matéria-prima na sua produção ou como embalagem para o seu acondicionamento','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054114','Artigo 411-D do RICMS','Diferimento - Saída interna de matéria prima, material secundário ou intermediário e material de embalagem, quando destinados a estabelecimento rerrefinador de óleo lubrificante usado e contaminado localizado nesse Estado, devidamente autorizado por órgão federal competente e classificado no código 1922-5/02 - “Rerrefino de óleos lubrificantes” da Classificação Nacional de Atividades Econômicas - CNAE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054115','Artigo 411-E do RICMS','Suspensão - Desembaraço aduaneiro, que ocorra em território paulista, de matéria prima, material secundário ou intermediário e material de embalagem, quando a importação for realizada por estabelecimento rerrefinador de óleo lubrificante usado e contaminado localizado nesse Estado, devidamente autorizado por órgão federal competente e classificado no código 1922-5/02 - “Rerrefino de óleos lubrificantes” da Classificação Nacional de Atividades Econômicas - CNAE','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054181','Artigo 418-B, II do RICMS','Diferimento - Saída de etanol hidratado combustível - EHC promovida por fabricante, cooperativa de produtores ou empresa comercializadora de etanol localizado em território paulista, não credenciado nos termos do Artigo 418-A do RICMS, com destino a contribuinte credenciado','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054182','Artigo 418-F do RICMS','Diferimento - Saídas internas de etanol hidratado combustível - EHC, promovidas por distribuidor de combustíveis com destino a outro distribuidor de combustíveis, em ambos os casos como definido e autorizado por órgão federal competente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054190','Artigo 419 do RICMS','Diferimento - Operação interna ou interestadual que destinar etanol anidro combustível - EAC a estabelecimento do distribuidor de combustíveis, como tal definido e autorizado por órgão federal competente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054191','Artigo 419-B do RICMS','Diferimento - Saída interna de etanol anidro combustível - EAC com destino a estabelecimento localizado em território paulista','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054201','Artigo 420-A do RICMS','Diferimento - Operação interna ou interestadual que destinar biodiesel puro - B100 a estabelecimento do distribuidor de combustíveis, como tal definido e autorizado por órgão federal competente','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054210','Artigo 421 do RICMS','Diferimento - Operações anteriores com querosene de aviação, querosene iluminante, gasolina de aviação e óleo combustível, assim como com o petróleo bruto utilizado na sua fabricação','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054220','Artigo 422 do RICMS','Diferimento - Operações internas com gás natural, biogás e biometano a serem consumidos em processo de industrialização em usina geradora de energia elétrica','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054221','Artigo 422-B do RICMS','Diferimento - Saída interna de gás natural destinado a estabelecimento fabricante de vidro classificado nas posições 7003, 7005, 7006, 7007, 7009 e 7010 da Nomenclatura Comum do Mercosul - NCM','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054250','Artigo 425 do RICMS','Diferimento - Operações internas com energia elétrica, desde a sua importação ou produção','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054251','Artigo 425-C do RICMS','Diferimento - Imposto devido sobre o valor dos encargos de conexão e de uso da rede básica de transmissão nas operações internas com energia elétrica','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054501','Artigo 450-B do RICMS','Diferimento - Saída interna de matéria-prima, produto intermediário e material de embalagem, com destino a contribuinte beneficiário do Regime Especial Simplificado de Exportação para fabricação de mercadoria a ser exportada, quando o contribuinte fornecedor constar do despacho relativo ao credenciamento','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054502','Artigo 450-C do RICMS','Suspensão - Desembaraço aduaneiro de matéria-prima, produto intermediário e material de embalagem empregados na fabricação de mercadoria destinada à exportação, quando a importação seja promovida por contribuinte beneficiário do Regime Especial Simplificado de Exportação','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP054890','Artigo 489 do RICMS','Diferimento ou suspensão com amparo em regime especial de ofício no interesse do contribuinte ou do fisco, estabelecido nos termos do Artigo 489 do RICMS','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058270','Artigo 27 DDTT do RICMS','Diferimento - Saída interna promovida pelo estabelecimento fabricante das mercadorias relacionadas no § 1° do Artigo 27 DDTT do RICMS diretamente a estabelecimento fabricante de vagão ferroviário de carga','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058290','Artigo 29 DDTT do RICMS','Suspensão - Desembaraço aduaneiro de bens destinados à integração ao ativo imobilizado','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058810','Decreto 46.082/01','Diferimento - Operações internas com insumos, materiais e equipamentos, para construção, conservação, modernização e reparo de embarcações, enquanto igual tratamento for concedido pelo Estado do Rio de Janeiro','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058811','Decreto 51.608/07','Diferimento - Saídas internas de máquinas ou implementos agrícolas','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058820','Artigo 11 do Decreto 53.051/08','Suspensão ou diferimento amparado por regime especial concedido nos termos do artigo 11 do Decreto 53.051/08, que instutuiu o Programa de Incentivo ao Investimento pelo Fabricante de Veículo Automotor - ProVeículo','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058821','Artigo 11 do Decreto 54.904/09','Suspensão ou diferimento amparado por regime especial concedido nos termos do artigo 11 do Decreto 54.904/09, que instutuiu o Programa de Incentivo ao Investimento pelo Fabricante de Produtos da Indústria de Processamento Eletrônico de Dados - Pro-Informática','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058822','Decreto 55.901/10','Suspensão ou diferimento - Programa de Incentivo ao Setor Ferroviário - Pro-Trens','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058823','Decreto 58.977/13','Diferimento - Saída de etanol a ser utilizado na operacionalização de transporte dutoviário','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP058830','Artigo 1º-A do Decreto 63.208/18','Diferimento ou suspensão - Operações realizadas por fabricante de bens finais ou por fabricante intermediário, devidamente habilitados no Repetro','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059001','Artigo 8º do Anexo XVII do RICMS','Diferimento - Prestação de serviços de telecomunicação entre empresas sujeitas a regime especial na cessão de meios de rede, relacionadas em Ato Cotepe','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059002','Artigo 9º do Anexo XVII do RICMS','Diferimento - Prestações de serviço de comunicação realizadas em território paulista para empresas de comunicações','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059003','Artigo 7º do Anexo XIX do RICMS','Diferimento - Saída interna promovida por produtor ou cooperativa com destino a estabelecimento da CONAB','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059004','Artigo 1º do Anexo VIII do RICMS','Diferimento - Sucessivas operações com produto primário agrícola realizadas por intermédio de Bolsa quando a mercadoria se encontra depositada em armazém geral, salvo se houver regra específica','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP019010','Artigo 2º do Anexo XXI do RICMS','Isenção - Produto de artesanato','');
				insert into tbfc_cbenef (fc_cbenef_cd,fc_cbenef_dispositivo,fc_cbenef_objetivo,fc_cbenef_observacao ) values ('SP059010','Artigo 3º do Anexo XXI do RICMS','Diferimento - Produto de artesanato','');




	
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------



					;
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',40);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',41);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',53);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',70);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099090',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099000',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099999',41);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP099999',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010010',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010010',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010020',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010020',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010030',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010030',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010040',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010040',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010070',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010070',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010080',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010080',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010090',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010090',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010140',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010140',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010160',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010160',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010170',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010170',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010180',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010180',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010190',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010190',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010220',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010220',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010230',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010230',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010260',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010260',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010270',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010270',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010280',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010280',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010290',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010290',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010300',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010300',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010310',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010310',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010330',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010330',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010340',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010340',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010360',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010360',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010370',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010370',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010380',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010380',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010390',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010390',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010400',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010400',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010410',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010410',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010420',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010420',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010440',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010440',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010510',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010510',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010520',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010520',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010530',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010530',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010540',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010540',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010550',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010550',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010560',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010560',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010590',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010590',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010600',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010600',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010630',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010630',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010640',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010640',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010680',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010680',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010710',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010710',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010730',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010730',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010750',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010750',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010760',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010760',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010770',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010770',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010780',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010780',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010800',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010800',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010820',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010820',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010830',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010830',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010840',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010840',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010880',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010880',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010890',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010890',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010910',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010910',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010920',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010920',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010940',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010940',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010970',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010970',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010980',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010980',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010990',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP010990',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011010',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011010',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011020',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011020',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011030',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011030',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011040',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011040',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011050',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011050',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011070',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011070',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011090',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011090',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011120',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011120',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011130',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011130',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011150',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011150',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011160',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011160',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011170',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011170',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011190',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011190',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011200',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011200',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011230',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011230',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011270',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011270',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011290',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011290',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011300',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011300',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011320',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011320',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011330',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011330',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011340',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011340',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011350',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011350',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011360',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011360',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011370',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011370',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011400',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011400',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011420',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011420',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011430',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011430',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011470',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011470',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011480',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011480',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011490',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011490',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011500',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011500',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011510',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011510',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011520',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011520',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011530',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011530',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011540',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011540',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011550',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011550',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011560',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011560',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011570',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011570',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011580',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011580',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011590',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011590',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011600',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011600',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011610',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011610',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011620',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011620',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011660',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011660',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011680',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011680',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011690',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011690',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011700',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011700',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011710',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011710',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011730',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011730',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011740',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011740',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011760',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011760',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011770',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011770',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011780',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011780',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011790',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011790',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011810',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011810',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011820',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011820',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011830',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011830',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011840',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011840',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011850',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP011850',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020010',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020010',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020030',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020030',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020080',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020080',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020090',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020090',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020100',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020100',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020110',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020110',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020120',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020120',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020150',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020150',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020190',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020190',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020260',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020260',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020290',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020290',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020300',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020300',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020320',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020320',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020330',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020330',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020340',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020340',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020350',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020350',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020370',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020370',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020380',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020380',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020390',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020390',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020450',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020450',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020520',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020520',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020530',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020530',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020550',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020550',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020560',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020560',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020580',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020580',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020590',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020590',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020610',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020610',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020620',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020620',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020630',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020630',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020650',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020650',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020660',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020660',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020690',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020690',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020710',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020710',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP050710',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020740',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020740',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020750',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020750',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020770',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020770',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020780',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020780',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020800',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP020800',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP040100',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP040200',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP018000',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP018000',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP028000',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP028000',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP029000',20);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP029000',70);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070010',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070020',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070030',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070040',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070050',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070060',30);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070060',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070070',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070080',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070090',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070100',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070110',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070120',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070130',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070140',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070150',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070160',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070170',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP070180',41);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP052600',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053160',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053190',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053191',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053260',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053270',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053271',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053272',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053273',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053274',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053275',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053275',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053275',90);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053276',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053280',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053290',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053300',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053330',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053450',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053460',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053461',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053462',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053480',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053500',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053512',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053520',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053521',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053522',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053530',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053540',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053550',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053560',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053570',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053580',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053590',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053600',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053610',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053611',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053620',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053630',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053640',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053650',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053830',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053880',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053890',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053910',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053920',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053941',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053942',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053951',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053952',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053953',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053954',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053955',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053956',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053957',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053958',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053959',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053960',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059900',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059901',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059902',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059903',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059904',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059905',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP053961',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054001',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054002',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054003',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054004',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054005',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054006',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054007',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054008',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054009',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054010',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054011',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054012',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054013',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054014',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054015',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054016',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054017',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054018',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054019',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054021',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054023',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054024',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054022',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054025',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054026',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054027',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054028',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054020',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054020',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054110',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054110',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054111',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054111',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054112',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054112',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054113',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054114',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054115',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054181',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054181',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054182',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054182',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054190',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054190',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054191',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054191',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054201',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054201',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054210',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054210',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054220',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054220',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054221',51);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054221',53);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054250',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054251',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054501',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054502',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054890',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP054890',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058270',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058290',50);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058810',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058811',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058820',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058820',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058821',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058821',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058822',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058822',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058823',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058830',50);insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP058830',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059001',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059002',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059003',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059004',51);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP019010',40);
					insert into tbfc_cbenef_cst (fc_cbenef_cd, icms_codigo_tributacao) values ('SP059010',51);














































update tbproduto_subgrupo set fc_cbenef_cd = 'SP020610' where prsg_cdsubgrupo = 20;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 41;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 42;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 64;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 67;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 69;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011680' where prsg_cdsubgrupo = 70;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011680' where prsg_cdsubgrupo = 71;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011680' where prsg_cdsubgrupo = 74;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011680' where prsg_cdsubgrupo = 75;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 76;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 77;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 79;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020030' where prsg_cdsubgrupo = 80;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011690' where prsg_cdsubgrupo = 82;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011690' where prsg_cdsubgrupo = 83;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011690' where prsg_cdsubgrupo = 84;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011690' where prsg_cdsubgrupo = 85;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011690' where prsg_cdsubgrupo = 86;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011030' where prsg_cdsubgrupo = 89;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011370' where prsg_cdsubgrupo = 91;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011370' where prsg_cdsubgrupo = 92;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 93;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 94;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 103;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 111;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 112;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 113;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 114;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 115;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 116;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 138;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 139;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020610' where prsg_cdsubgrupo = 144;



update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 157;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 160;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020340' where prsg_cdsubgrupo = 165;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020340' where prsg_cdsubgrupo = 167;


update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 192;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 195;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 196;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 198;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 201;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011010' where prsg_cdsubgrupo = 212;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011010' where prsg_cdsubgrupo = 213;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP011010' where prsg_cdsubgrupo = 214;











update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 234;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 238;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 246;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 247;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 248;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 249;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 250;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 251;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 252;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 253;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 254;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 255;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 256;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 257;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 258;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 259;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 260;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 261;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 262;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 263;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 264;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 265;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 267;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 268;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 269;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 270;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 271;



update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 321;

update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 336;

update tbproduto_subgrupo set fc_cbenef_cd = 'SP011350' where prsg_cdsubgrupo = 347;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 353;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 355;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 356;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 357;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 360;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 361;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 362;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 363;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 364;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 365;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 366;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 367;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 368;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 369;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 370;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 371;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 372;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 373;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 374;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 376;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 377;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 378;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 379;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 381;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 382;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 383;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 384;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 385;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 386;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 387;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 389;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 390;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 391;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 392;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 393;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 394;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 395;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 396;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 397;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 398;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 399;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 402;


update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 406;

update tbproduto_subgrupo set fc_cbenef_cd = 'SP020390' where prsg_cdsubgrupo = 411;


update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 554;

update tbproduto_subgrupo set fc_cbenef_cd = 'SP020610' where prsg_cdsubgrupo = 635;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 654;
update tbproduto_subgrupo set fc_cbenef_cd = 'SP010360' where prsg_cdsubgrupo = 655;



