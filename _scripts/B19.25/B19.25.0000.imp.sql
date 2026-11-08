-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 
    if ((
        select count(*) 
        from information_schema.tables where table_name = 'tbsistema_nucleo_procedimento_operacional'
    ) = 0) 
    then 
            create table tbsistema_nucleo_procedimento_operacional
            (
                     sis_nucleo_prc_cd int
                ,    is_nucleo_prd_operacional serial 
                ,    competencia_cd int
                ,    fv_fab_meta_cd int
                ,    sis_nucleo_prd_operacional_default smallint
                ,    data_processamento_ini date 
                ,    data_processamento_fim date
                ,    constraint pksistema_nucleo_procedimento_operacional primary key (sis_nucleo_prc_cd, is_nucleo_prd_operacional)
            )
    ;
    end if;

end$$
;





INSERT INTO tbsistema_nucleo (sis_cd_fk, sis_nucleo_cd_pk, sis_nucleo_descricao, sis_nucleo_grupo_id, status)
    select 1, 'M0005', 'FORCA VENDA META',1, true
    WHERE NOT EXISTS(SELECT 1 FROM tbsistema_nucleo WHERE sis_nucleo_cd_pk = 'M0005')
;

    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
    SELECT 'M0005', 100050010, 'Atualização Meta Força Venda', 0
        WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 100050010)
    ;


    insert into tbsistema_nucleo_procedimento_operacional
        (sis_nucleo_prc_cd, competencia_cd, fv_fab_meta_cd, sis_nucleo_prd_operacional_default, data_processamento_ini, data_processamento_fim )
        SELECT 100050010,202610,0,0,'2026-10-01', '2026-10-31'
            where not exists (select 1 from tbsistema_nucleo_procedimento_operacional where sis_nucleo_prc_cd = 100050010 and competencia_cd = 202610)
;

    insert into tbsistema_nucleo_procedimento_operacional
        (sis_nucleo_prc_cd, competencia_cd, fv_fab_meta_cd, sis_nucleo_prd_operacional_default, data_processamento_ini, data_processamento_fim )
        SELECT 100050010,202611,0,1,'2026-11-01', '2026-11-30'
            where not exists (select 1 from tbsistema_nucleo_procedimento_operacional where sis_nucleo_prc_cd = 100050010 and competencia_cd = 202611)
;

INSERT INTO tbsistema_nucleo (sis_cd_fk, sis_nucleo_cd_pk, sis_nucleo_descricao, sis_nucleo_grupo_id, status)
    select 1, 'M0070', 'FATURAMENTO',1, true
    WHERE NOT EXISTS(SELECT 1 FROM tbsistema_nucleo WHERE sis_nucleo_cd_pk = 'M0070')
;
    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M0070', 100700010, 'Faturamento PRIME - Processamento Venda BlueSoft', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 100700010)
;
    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M0070', 100700015, 'Faturamento PRIME - Processamento Contrato', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 100700015)
;

INSERT INTO tbsistema_nucleo (sis_cd_fk, sis_nucleo_cd_pk, sis_nucleo_descricao, sis_nucleo_grupo_id, status)
    select 1, 'M0071', 'INTERFACE',1, true
    WHERE NOT EXISTS(SELECT 1 FROM tbsistema_nucleo WHERE sis_nucleo_cd_pk = 'M0071')
;
    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M0071', 100710010, 'Interfacec / Metas de Interface', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 100710010)    
    ;

INSERT INTO tbsistema_nucleo (sis_cd_fk, sis_nucleo_cd_pk, sis_nucleo_descricao, sis_nucleo_grupo_id, status)
    select 1, 'M1000', 'INFORMATIVOS',1, true
    WHERE NOT EXISTS(SELECT 1 FROM tbsistema_nucleo WHERE sis_nucleo_cd_pk = 'M1000')
;
    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M1000', 101000010, 'IF0100 - E-mail Venda ', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 101000010)
    ;

    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M1000', 101000015, 'IF0045 - E-mail Venda Mix', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 101000015)
    ;    

    insert into tbsistema_nucleo_procedimento (sis_nucleo_cd_fk, sis_nucleo_prc_cd, sis_nucleo_prc_descritivo, permite_execucao_manual )
        SELECT 'M1000', 101000020, 'IF0110 - E-mail Comissão', 0
            WHERE NOT EXISTS (SELECT 1 FROM tbsistema_nucleo_procedimento WHERE sis_nucleo_prc_cd = 101000020)
    ;        

/*
F0004 - forca venda --OK
M0005 - FORCA VENDA META
M0070 - FATURAMENTO
M0071 - INTERFACE
M1000 - INFORMATIVOS

select * from tbsistema_nucleo where sis_nucleo_cd_pk like '%1000'
select sis_nucleo_prc_cd, permite_execucao_manual, * from tbsistema_nucleo_procedimento WHERE SIS_NUCLEO_PRC_CD = 100050010
select * from tbsistema_nucleo_procedimento_operacional
*/

