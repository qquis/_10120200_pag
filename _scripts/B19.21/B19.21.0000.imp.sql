-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 





if ((	SELECT 	count(*)
		FROM    information_schema.columns
		WHERE   table_name = 'tbinterfacefaturamentoinfoitem'
		  AND   column_name = 'cdparticipantecliente_original'
	) = 0
   	)	
then 
	alter table tbinterfacefaturamentoinfoitem add cdparticipantecliente_original int;

end if;

if ((	SELECT 	count(*)
		FROM    information_schema.columns
		WHERE   table_name = 'tbinterfacefaturamentoinfoitem'
		  AND   column_name = 'cdparticipantevendedor_original'
	) = 0
   	)	
then 
	alter table tbinterfacefaturamentoinfoitem add cdparticipantevendedor_original int;

end if;

	
	
end$$
;


		/*MENUS*/
		--select * from tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 3000 order by sis_ac_gmenu_cd asc
        --select * from tbsistema_acesso where sis_ac_cd = 3310
		insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
		select 3300, 'Interfaces', 3000
			where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 3300 and sis_ac_modulo_menu_cd = 3000)
		;

        update tbsistema_acesso_grupomenu
        set sis_ac_gmenu = 'Interfaces'
        where sis_ac_gmenu_cd = 3300 and sis_ac_modulo_menu_cd = 3000
        ;


		/*MENU INTERFACE PROCESSAMENTO*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3305;
		select public._local_acesso_web(5, 3305, 'Processamento', 'm3305', 3300, '/pages/operacional/interface/processamento')
			;	

		/*MENU INTERFACE DIAL*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3310;
		select public._local_acesso_web(5, 3310, 'DIAL', 'm3310', 3300, '/pages/operacional/interface/dial')
			;


		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3305, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3305 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3310, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3310 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)


		;
	 