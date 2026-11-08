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

;

select public._local_acesso_web(5, 4213, 'Fiscal - Figura', 'm4213', 4200, '/pages/controller/fiscal/figura')
;


insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 2, 4213, 1
	where not exists (select 1 from tbsistema_permissao where sis_cd = 5 and sis_fc_cd = 2 and sis_ac_cd = 4213 and sis_ta_cd = 1 )



/*
drop table if exists tbfc_regrafiscal
drop table if exists tbfc_regrafiscal_operacao


select * from tbfc_regrafiscal
select * from tbfc_regrafiscal_operacao

SELECT 	*
			FROM 	information_schema.tables 
where 	table_name = 'tbfc_regrafiscal' 


-- select * from tbfc_regrafiscal_operacao
select 	fc_figurafiscal_cd 
                                    ,	count(*) as qtde_regra 
                            from 	 tbfc_regrafiscal_operacao  
                            where  1 = 1
                            group by fc_figurafiscal_cd 
*/