-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 
    if ((
        select count(*) 
        from information_schema.tables where table_name = 'tbsistema_nucleo_procedimento_operacional'
    ) > 0) 
    then 
            drop table tbsistema_nucleo_procedimento_operacional

       ;
    end if;

end$$
;

select * from tbforca_venda_fab_meta

create table tbsistema_operacional
    (
            sis_operacional_cd      int
        ,   sis_operacional_status  int
        ,   competencia_cd          int
        ,   data_processamento_ini  date 
        ,   data_processamento_fim  date 


    )