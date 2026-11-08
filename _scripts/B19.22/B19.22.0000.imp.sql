-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 


	
	
end$$
;




		/*MENU INTERFACE CONSULTA*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3306;
		select public._local_acesso_web(5, 3306, 'Consulta / Análise ', 'm3306', 3300, '/pages/operacional/interface/consulta')
			;	


		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3306, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3306 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 45, 3306, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3306 and sis_cd = 5 and sis_fc_cd = 45 and sis_ta_cd = 1)


		;
	 