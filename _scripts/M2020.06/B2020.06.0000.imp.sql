-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 


end$$
;


        ---select * from tbsistema_acesso_grupomenu where sis_ac_gmenu like 'Interface%'

        ---select * from tbsistema_acesso where sis_ac_gmenu_cd = 3300


		/*MENU INTERFACE PROCESSAMENTO*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3370;
		select public._local_acesso_web(5, 3370, 'Metas', 'm3370', 3300, '/pages/operacional/interface/meta')
			;	