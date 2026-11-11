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

update tbsistema_operacional set faturamento_numero_dias_qtde = 5, faturamento_data_limite = '2026-12-01' where competencia_cd = 202611;


/*
select * from tbsistema_operacional
select * from tbcompetencia
select * from tbsistema_acesso where sis_ac_href like '%faturamento/operacao'
select * from tbsistema_permissao where sis_ac_cd = 3090
select * from tbsistema_tarefa where sis_ta_descricao like '%OP%'

  SELECT 
                                us.sis_operacional_cd 
                            ,   us.sis_operacional_default 
                            ,   us.data_processamento_venda_ini 
                            ,   us.data_processamento_venda_fim 
                            ,   us.competencia_cd 
                            ,   us.fv_fab_meta_cd 
                            ,   us.faturamento_numero_dias_qtde
                            ,   us.faturamento_data_limite
                            ,   c.competencia_data_ini
                            ,   c.competencia_data_fim                            
                FROM            tbsistema_operacional us
                INNER JOIN  tbcompetencia c on c.competencia_cd = us.competencia_cd
                WHERE 1=1
         AND us.competencia_cd = 202611 