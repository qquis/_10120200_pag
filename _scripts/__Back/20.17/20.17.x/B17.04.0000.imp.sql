do $$
begin 

	
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_regrafiscal' 
			  and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table public.tbfc_regrafiscal
			create table public.tbfc_regrafiscal
				(
						dtlog_insert timestamp default(current_timestamp)
					,   dtlog_update timestamp
					,	tipo 					char(7)
					,	fc_regrafiscal_cd 		int
					,	cfop 					int
					,	fc_figurafiscal_cd 		int
					,	vigenciainicial 		date 
					,	fc_regrafiscal_status 	smallint

					,	constraint pkfc_regrafiscal primary key (fc_regrafiscal_cd)
					
				)
			;
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_regrafiscal_operacao' 
			and   table_schema = 'public'
			) = 0  -->> Se não existir
	   	)	
	then 
			--drop table public.tbfc_regrafiscal_operacao
		create table public.tbfc_regrafiscal_operacao
		(
				dtlog_insert timestamp default(current_timestamp)
			,   dtlog_update timestamp
			,	fc_regrafiscal_cd 		int
			,	df_nf_tipo				int
			,	constraint pkfc_regrafiscal_operacao primary key (fc_regrafiscal_cd, df_nf_tipo)
		)
		;

	end if;
	


end$$	

/* Ajuste de Menus */
--select * from tbsistema_acesso_grupomenu
;
update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Prime' where sis_ac_gmenu_cd = 1100
;
insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
	select 1200, 'Zanthus', 1000
	where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 1200)
;


/*Novo menu*/
delete from tbsistema_acesso where sis_ac_cd = 1210 and sis_cd = 5;
delete from tbsistema_permissao where sis_ac_cd = 1210 and sis_cd = 5;

select public._local_acesso_web(5, 1210, 'Tabela de Mercadoria', 'm1210', 1200, '/pages/cadastro/zanthus/mercadoria')
;



insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 2, 1210, 1
	where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 1210 and sis_ta_cd = 1 )






/*SCRIPT ANALISE 


select * from tbsistema_acesso_modulomenu
select * from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 4200

select 	cod_mercadoria 
	,	descricao 
	,	cod_ncm
	,	cod_ex
	,	cod_tributacao_mercadoria 
	,	modo_preco
	,	cod_situacao_tributaria
	,	percentual_reduz_b_calculo
	,	aliquota_icms
	,	cod_situacao_tributaria
	,	cod_sit_trib_pis
	,	perc_reduz_b_calculo_pis
	,	aliquota_pis
	,	cod_sit_trib_cofins
	,	perc_reduz_b_calculo_cofins
	,	aliquota_cofins


	
	,	cod_sit_tributaria_ibs_cbs
	,	cod_class_tributaria_is
	,	cod_class_tributaria_ibs_cbs
	,	per_aliquota_is
	,	per_aliquota_is_especifica 
	,	per_aliquota_ibs_uf
	,	per_reducao_aliquota_ibs_uf
	,	per_diferimento_ibs_uf 
	,	per_aliquota_ibs_mun 
	,	per_reducao_aliquota_ibs_mun 
	,	per_diferimento_ibs_mun 
	,	per_aliquota_cbs 
	,	per_diferimento_cbs
	,	per_reducao_aliquota_cbs
	,	per_cred_presumido_ibs_mono 
	,	per_cred_presumido_cbs_mono 
	,	origem_cadastro
	from tab_mercadoria 
	where 1 = 1
	  and cod_mercadoria in (select lpad(m43ah, 17, '0') from zan_m43 where m00af = '2026-01-02'  )
limit 10

--select * from tab_mercadoria limit 10


*/