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


	select cod_mercadoria, codigo_beneficio_fiscal from TbZanthusTab_Regra_Icms limit 10
	SELECT cod_mercadoria, codigo_beneficio_fiscal  FROM tbzanthustab_mercadoria limit 10
*/



do $$
begin 

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthus_tributacao_nfce' 
			  and   column_name = 'codigo_beneficio_fiscal'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbzanthus_tributacao_nfce add codigo_beneficio_fiscal varchar(10) 
			;
			-- select * from tbproduto_subgrupo

	end if;



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'codigo_beneficio_fiscal'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table tbzanthustab_mercadoria add codigo_beneficio_fiscal varchar(10) 
			;
			-- select * from tbproduto_subgrupo

	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_regra_icms' 
			  and   column_name = 'codigo_beneficio_fiscal'
			) = 0  -->> Se não existir
	   	)	
	then 
			alter table TbZanthusTab_Regra_Icms add codigo_beneficio_fiscal varchar(10) 
			;
			-- select * from tbproduto_subgrupo

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