-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 


    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote'
          and   column_name = 'percentual'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote add percentual numeric(13,2);
    end if;

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote'
          and   column_name = 'margem_limite'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote add margem_limite numeric(13,2);
    end if;

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote_produto'
          and   column_name = 'percentual'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote_produto add percentual numeric(13,2);
    end if;    

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote_produto'
          and   column_name = 'ec_valor_custo_precificacao'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote_produto add ec_valor_custo_precificacao numeric(17,4);
    end if;        

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote_produto'
          and   column_name = 'margem_atual'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote_produto add margem_atual numeric(13,2);
    end if; 

    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpreco_aplicacao_lote_produto'
          and   column_name = 'margem_limite'
    ) = 0) 
    then 
        alter table tbpreco_aplicacao_lote_produto add margem_limite numeric(13,2);
    end if;     

end$$
;

