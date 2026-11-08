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

UPDATE tbsistema_acesso set sis_ac_descricao = 'Fiscal - Produto/NFCE ***' WHERE SIS_AC_CD = 4211