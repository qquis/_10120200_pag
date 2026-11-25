-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 


    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbproduto'
          and   column_name = 'pr_unitario_blue_inativo'
    ) = 0) 
    then 
        alter table tbproduto add pr_unitario_blue_inativo smallint;
    end if;

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbproduto'
          and   column_name = 'pr_unitario_blue_inativo_data'
    ) = 0) 
    then 
        alter table tbproduto add pr_unitario_blue_inativo_data timestamp;
    end if;


end$$
;


update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Zanthus' where sis_ac_gmenu_cd = 3400;

update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Bluesoft - Vendas' where sis_ac_gmenu_cd = 3200;


