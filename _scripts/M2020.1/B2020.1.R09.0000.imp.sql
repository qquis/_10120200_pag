-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 



    if ((select count(*)
        from    information_schema.tables
        where   table_name = 'tbsistema_operacional'
    ) = 0) 
    then 
        --drop table if exists tbsistema_operacional;
        create table tbsistema_operacional (
                sis_operacional_cd serial
            ,   sis_operacional_default smallint
            ,   data_processamento_venda_ini date
            ,   data_processamento_venda_fim date
            ,   competencia_cd int
            ,   fv_fab_meta_cd int 
            ,   faturamento_numero_dias_qtde int
            ,   faturamento_data_limite int 
            ,   constraint pksistema_operacional primary key (sis_operacional_cd, competencia_cd)
        ) 
        ;

        insert into tbsistema_operacional (sis_operacional_default, data_processamento_venda_ini, data_processamento_venda_fim, competencia_cd, fv_fab_meta_cd)
        select 1, '2026-10-01', '2026-12-01', 202611, 2026001
        where not exists (select 1 from tbsistema_operacional where competencia_cd = 202611);
        
    end if;  



end$$
;


        select * from tbsistema_operacional

        /*CADASTROS | BLUESOFT COMPLEMENTOS*/

        --SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_gmenu like 'Prime | Participante'
        --SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 1000 order by sis_ac_modulo_menu_cd

        /*        
        insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
        select 1300, 'Complementares', 1000
        where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 1300 and sis_ac_modulo_menu_cd = 1000);
       
        delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 1310;
		select public._local_acesso_web(5, 1310, 'Operações', 'm1310', 1300, '/pages/cadastro/complementares/operacao')
        ;
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1310, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1310 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

        ;

        */




