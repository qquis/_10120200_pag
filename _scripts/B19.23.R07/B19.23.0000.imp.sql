-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 

	if ((select count(*)
		from information_schema.columns
		where table_name = 'tbsistema_permissao'
		and   column_name = 'dtlog_insert'
			) = 0
	) then
		alter table tbsistema_permissao add column dtlog_insert timestamp default (current_timestamp);
	end if;


end$$
;



	insert into tbsistema_permissao(sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select a.sis_cd, 2, a.sis_ac_Cd, 3000101 from tbsistema_permissao a 
		where sis_cd = 5 
		and sis_fc_cd = 2 
		and sis_ta_cd = 1
	    and not exists(select 1 from tbsistema_permissao where sis_cd = a.sis_cd and sis_fc_cd = 2 and sis_ac_cd = a.sis_ac_cd and sis_ta_cd = 3000101)
	;
	insert into tbsistema_permissao(sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select a.sis_cd, 2, a.sis_ac_Cd, 3000306 from tbsistema_permissao a 
		where sis_cd = 5 
		and sis_fc_cd = 2 
		and sis_ta_cd = 1
	    and not exists(select 1 from tbsistema_permissao where sis_cd = a.sis_cd and sis_fc_cd = 2 and sis_ac_cd = a.sis_ac_cd and sis_ta_cd = 3000306)
	;
	insert into tbsistema_permissao(sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select a.sis_cd, 2, a.sis_ac_Cd, 3000304 from tbsistema_permissao a
		where sis_cd = 5 
		and sis_fc_cd = 2 
		and sis_ta_cd = 1
	    and not exists(select 1 from tbsistema_permissao where sis_cd = a.sis_cd and sis_fc_cd = 2 and sis_ac_cd = a.sis_ac_cd and sis_ta_cd = 3000304)
	;
		
