-- Active: 1773758617277@@127.0.0.1@5432@oxan@public@public

do $$
begin 


    if ((select count(*)
        from    information_schema.columns 
        where   table_name = 'tbpessoabluesoft_status_credito'
          and   column_name = 'bluesoftcliente_creditostatus_referencia'

    ) = 0) 
    then 
        alter table tbpessoabluesoft_status_credito
        add column bluesoftcliente_creditostatus_referencia varchar(20)
       ;
    end if;

    if ((select count(*)
        from    information_schema.tables
        where   table_name = 'tbforma_pgto_bluesoft'
    ) = 0) 
    then 
        --drop table if exists tbforma_pgto_bluesoft;
        create table tbforma_pgto_bluesoft (
              forma_pgto_cd serial
            , forma_pgto_descricao varchar(60)
            , forma_pgto_ref_blue varchar(60)
            , CONSTRAINT pkforma_pgto_bluesoft PRIMARY KEY (forma_pgto_cd, forma_pgto_ref_blue)
        ) 
        ;
        insert into tbforma_pgto_bluesoft (forma_pgto_descricao, forma_pgto_ref_blue)
        select 'NAO DEFINIDA', 'NAO DEFINIDA'
        WHERE NOT EXISTS (SELECT 1 FROM tbforma_pgto_bluesoft WHERE forma_pgto_descricao = 'NAO DEFINIDA' AND forma_pgto_ref_blue = 'NAO DEFINIDA')
       ;
    end if;  


    if ((select count(*)
        from    information_schema.COLUMNS
        where   table_name = 'tbgrupoeconomico'
          and   column_name = 'forma_pgto_cd_padrao'
    ) = 0) 
    then 
        
        alter table tbgrupoeconomico add column forma_pgto_cd_padrao int
       ;
       
       Update tbgrupoeconomico set forma_pgto_cd_padrao = 1
       ;
    end if;        

end$$
;


    
    

    update tbpessoabluesoft_status_credito set bluesoftcliente_creditostatus_referencia = 'CREDITO_OK'  WHERE bluesoftcliente_creditostatus_cd = 1;
    update tbpessoabluesoft_status_credito set bluesoftcliente_creditostatus_referencia = 'BLOQUEADO'   WHERE bluesoftcliente_creditostatus_cd = 2;
    update tbpessoabluesoft_status_credito set bluesoftcliente_creditostatus_referencia = 'DEVEDOR'     WHERE bluesoftcliente_creditostatus_cd = 3;
    update tbpessoabluesoft_status_credito set bluesoftcliente_creditostatus_referencia = 'PROTESTADO'  WHERE bluesoftcliente_creditostatus_cd = 4;
    update tbpessoabluesoft_status_credito set bluesoftcliente_creditostatus_referencia = 'EM_ANALISE'  WHERE bluesoftcliente_creditostatus_cd = 5;





        /*CADASTROS | BLUESOFT COMPLEMENTOS*/

        --SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_gmenu like 'Prime | Participante'
        --SELECT * FROM tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 1000 order by sis_ac_modulo_menu_cd
        
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







		/*MENU GRUPO ECONOMICO*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 1015;
		select public._local_acesso_web(5, 1015, 'Participante/Grupo Economico', 'm1015', 1010, '/pages/cadastro/participante/listagemgrupoeconomico')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1015, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1015 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

        ;
        insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd) 
        select a.sis_cd, a.sis_fc_cd as sis_fc_cd, 1015, a.sis_ta_cd 
        from tbsistema_permissao a 
        where sis_ac_cd = 3210
        and   sis_fc_Cd = 1
        and   not exists (  select 1 
                            from tbsistema_permissao xx 
                            where sis_ac_cd = 1015 
                            and sis_cd = a.sis_cd 
                            and sis_fc_cd = a.sis_fc_cd 
                            and sis_ta_cd = a.sis_ta_cd
                            
                        )
        AND   sis_ta_cd = 110010
        ;

        insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd) 
        select a.sis_cd, 2 as sis_fc_cd, 1015, a.sis_ta_cd 
        from tbsistema_permissao a 
        where sis_ac_cd = 3210
        and   sis_fc_Cd = 1
        and   not exists (  select 1 
                            from tbsistema_permissao xx 
                            where sis_ac_cd = 1015 
                            and sis_cd = a.sis_cd 
                            and sis_fc_cd = 2 
                            and sis_ta_cd = a.sis_ta_cd
                            
                        )
        AND   sis_ta_cd = 110010
        ;


