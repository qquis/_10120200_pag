-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1777038659657@@172.17.0.166@5432-- Active: 1777038659657@@172.17.0.166@5432

/*

select * from tbest_info
select * from tbest_produto



*/



do $$
begin 



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbest_produto' 
			  and   column_name = 'data_ultima_venda'
			) = 0
	   	)	
	then 
			alter table tbest_produto add column data_ultima_venda date;
			
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbest_info' 
			  and   column_name = 'data_base_estatistica'
			) = 0
	   	)	
	then 
			alter table tbest_info add column data_base_estatistica date;
	end if;

	


end$$	
		;

		/*LIMITA OS CALCULOS DE ULTIMA VENDA / ULTIMA COMPRA DE PRODUTOS DENTRE OUTRAS INFORMAÇÕES*/
		
		update tbest_info set data_base_estatistica = '2020-01-01'
		;

		/* NOVA SUBDIVISÃO DE MENU */
		insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_gmenu_sub, sis_ac_modulo_menu_cd)
			 select 3500, 'Estoque Custo', 'EstoqueCusto', 3000			
			 where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3500 and sis_ac_modulo_menu_cd = 3000)
		;


		

		/* OPERAÇÕES DE FATURAMENTO PRIME */
		
		select public._local_acesso_web(5, 3510, 'Análise de Giro', 'm3510', 3500, '/pages/operacional/estoquecusto/analise')
			;	

			-- loja
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				SELECT 5, 1, 3510, 3000102 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 1 and sis_ac_cd = 3090 and sis_ta_cd = 3000102)
			;
			-- distribuicao
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				SELECT 5, 1, 3510, 3000101 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 1 and sis_ac_cd = 3090 and sis_ta_cd = 3000101)
			;	
			-- e-commerce 
			insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
				SELECT 5, 1, 3510, 3000304 where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 1 and sis_ac_cd = 3090 and sis_ta_cd = 3000304)
			;		


		DELETE FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE SIS_NUCLEO_CD_FK = 'F0150';

		UPDATE TBSISTEMA_NUCLEO SET SIS_NUCLEO_CD_PK = 'M0150', sis_nucleo_descricao = 'Base Estatística' where SIS_NUCLEO_CD_PK = 'F0150';

		delete from TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10150010;
		INSERT INTO TBSISTEMA_NUCLEO_PROCEDIMENTO (			sis_nucleo_cd_fk
														, 	sis_nucleo_prc_cd
														, 	sis_nucleo_prc_descritivo
														,	sis_nucleo_prc_tipo
														,	sis_nucleo_prc_descricao 
														,	notificacao_cd 
														,	permite_execucao_manual
														
														)
			select 	'M0150'
				,	10150010
				,	'Dados Estatísticos de Faturamento (Atual. Diária D-30)'
				,	1
				,	'Dados Estatísticos de Faturamento (Atual. Diária D-30)'
				,	0
				,	1
				WHERE NOT EXISTS (SELECT 1 FROM TBSISTEMA_NUCLEO_PROCEDIMENTO WHERE sis_nucleo_prc_cd = 10150010)
		;



/*
select * from tbsistema_nucleo_procedimento where sis_nucleo_cd_fk = 'M0150'

select * from tbsistema_nucleo where sis_nucleo_cd_pk = 'M0150'


		select sis_ac_gmenu_cd, sis_ac_cd, sis_ac_descricao from tbsistema_acesso where sis_ac_gmenu_cd in (3900, 3300, 3400, 3200, 3100)
		order by sis_ac_gmenu_cd, sis_ac_cd asc

		select sis_ac_gmenu_cd, sis_ac_cd, sis_ac_descricao from tbsistema_acesso where sis_ac_cd = 3095

		select * from tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 3000
		select * from tbsistema_acesso_modulomenu where sis_ac_modulo_menu_cd = 3000
	select * from tbsistema_nucleo_procedimento WHERE sis_nucleo_cd_fk = 'F0011' AND sis_nucleo_prc_cd = 1102


SELECT 		f.em_cdempresa 
    ,       em.em_descricao
	,	    f.op_cdoperacao
	,       op.op_descricao  
	,		sum(I.valortotalfaturamentobase) as valortotalfaturamentobase
	,		sum(i.valortotalsubsidioscorrentes) as valortotalsubsidioscorrentes
	,		sum(i.valortotalfaturamento) as valortotalfaturamento
	,		sum(i.valortotaldescontofinanceiro) as valortotaldescontofinanceiro
	,		sum(i.valortotalsubsidiosaplicados) as valortotalsubsidiosaplicados
	,		sum(i.valortotalfaturamentoliquido) as valortotalfaturamentoliquido
FROM 		TBFATURAMENTO 		f
inner join 	tbfaturamentoorigem o on o.seqfaturamento = f.seqfaturamento
inner join  tbfaturamentoitens  i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
inner join  tboperacao         op on op.op_cdoperacao = f.op_cdoperacao
inner join  tbempresa          em on em.em_cdempresa = f.em_cdempresa 
WHERE 		1 = 1
AND 		f.datafaturamento = '2026-07-01'
group by 	f.em_cdempresa 
    ,       em.em_descricao
	,	    f.op_cdoperacao
	,       op.op_descricao  


	select * from tbsistema_tarefa where sis_ta_descricao like '%EMPRESA%'
	select * from tbsistema_permissao where sis_ac_cd = 3210
	select * from tbsistema_permissao where sis_ac_cd = 3090

	select * from tbsistema_nucleo_procedimento limit 10



	*/

