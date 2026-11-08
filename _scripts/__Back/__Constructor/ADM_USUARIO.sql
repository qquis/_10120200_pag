select * from tbsistema_acesso where sis_ac_descricao like '%Blue%'

select * from tbsistema_usuario where user_name like '%patri%'
select * from tbsistema_usuario where user_name like '%regi%'


select * from tbsistema_permissao where sis_fc_cd = 1 and sis_ac_cd = 5143
select * from tbsistema_permissao where sis_fc_cd = 15 and sis_ac_cd = 5143

insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 15, 5143, 1 -- FLUXO BLUE

insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 15, 5142, 1 -- FINANCEIRO BLUE

select * from tbsistema_funcao where sis_fc_cd = 2	

insert into tbsistema_funcao (sis_cd, sis_fc_cd, sis_fc_descricao)
select sis_cd, 70, 'SUPORTE FINANCEIRO' from tbsistema_funcao where sis_fc_cd = 2

insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
select sis_cd, 70, sis_ac_cd, sis_ta_cd from tbsistema_permissao where sis_fc_cd = 2

update tbsistema_usuario set sis_fc_cd = 70 where sis_us_seq = 36

insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 70, 5143, 1 -- FLUXO BLUE

insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
	select 5, 70, 5142, 1 -- FINANCEIRO BLUE