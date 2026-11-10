-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 


    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbsistema_operacional'
          and   column_name = 'faturamento_data_limite'
          and   data_type = 'integer'
    ) = 1) 
    then 
        alter table tbsistema_operacional drop column faturamento_data_limite;
        alter table tbsistema_operacional add faturamento_data_limite date;
    end if;

end$$
;

update tbsistema_operacional set faturamento_numero_dias_qtde = 5, faturamento_data_limite = '2026-11-03' where competencia_cd = 202611;


/*
select * from tbsistema_operacional
select * from tbcompetencia

*/