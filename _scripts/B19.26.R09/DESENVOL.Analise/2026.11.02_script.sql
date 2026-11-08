
select * from tbforca_venda_fab_meta
select * from tbforca_venda_meta 
select * from tbfaturamento   

select * from tbprocesso_log limit 10
select * from tbsistema_nucleo_procedimento

select * from tbsistema_nucleo_procedimento
select * from tbinformativo

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

