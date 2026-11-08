-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1777038659657@@172.17.0.166@5432-- Active: 1777038659657@@172.17.0.166@5432

/*

select * from tbest_info
select * from tbest_produto
SELECT * FROM tbdocumentofiscal limit 1
SELECT * FROM tbdocumentofiscal_tipo

CODIGO EAN A SER ANALISADO: 00000000000579025

select * from tbprodutobluesoft_gtins where prbg_cdbarra_pk like '%579025%' limit 10
select * from tbprodutoembalagem where prb_cdprodutobluesoft = 97730

*/



do $$
begin 

/*

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

*/	


end$$	
		;


		/* OPERAÇÕES DE FATURAMENTO PRIME */

		--SELECT * FROM tbsistema_acesso where sis_cd = 5 and sis_ac_gmenu_cd = 3400 and sis_ac_cd = 3920
		--SELECT * FROM tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3921
		
		update tbsistema_acesso set sis_ac_descricao = 'Zanthus - Vendas Online' where sis_cd = 5 and sis_ac_cd = 3920 
		;

		select public._local_acesso_web(5, 3921, 'Zanthus - Pagamentos Online', 'm3921', 3400, '/pages/operacional/zanthus/pagamentos')
			;	



		update tbnotificacao set notificacao_descricao = 'Notificacao Personalizada (User list)' where notificacao_cd = 1000000009;	

		insert into tbnotificacao (notificacao_cd, notificacao_descricao)
		 select 10, 'WHATS APP - PERSONALIZADA' 
		 where not exists (select 1 from tbnotificacao where notificacao_cd = 10);
		 



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

select * from tbnotificacao_send_tipo
select * from tbnotificacao
select * from tbsistema_batch_service
select * from tbnotificacao_send

update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3001' where sis_batch_service_cd = 995001;
update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3002' where sis_batch_service_cd = 995002;
update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3003' where sis_batch_service_cd = 995003;

select * from tbnotificacao_participante

select * from tbfaturamento_bluesoft where numeropedido = 484266
select * from tbfaturamento_bluesoft_item where numeropedido = 484266
select * from tbfaturamento_bluesoft_fv_item where numeropedido = 484266

	*/






