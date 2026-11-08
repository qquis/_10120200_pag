

SELECT * FROM tbfc_regrafiscal_nfce_produto
SELECT * FROM tbfc_regrafiscal_nfce_produto_tipo

select * from tbproduto_composicao
select * from tbprodutobluesoft_composicao
select * from tbzanthus_carga
update tbzanthus_carga set carga_data = '2026-10-07'
select * from tbzanthustab_mercadoria_tipo_venda where cod_mercadoria = '00000000000101516' 


select * from tbsistema_nucleo_procedimento
select * from tbsistema_nucleo
select * from tbsistema_scriptdb


select * from tbzanthustab_mercadoria_tipo_venda where tab_pre_cd = 2 limit 10


select * from tbsistema_acesso where sis_ac_href like  '%pages/cadastro/produto/listagem'
select * from tbsistema_acesso where sis_ac_href like  '%pages/cadastro/produtobluesoft/listagem'

1110 - menu 1100
1150 - menu 1150

select * from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 1150
select * from tbsistema_acesso where sis_ac_gmenu_cd = 1150


update tbsistema_acesso_grupomenu set sis_ac_gmenu = 'Produto' where sis_ac_gmenu_cd = 1150
;

update tbsistema_acesso set     sis_ac_gmenu_cd = 1150     ,   sis_ac_descricao = 'Lista Produto Prime' where sis_ac_cd = 1110;
update tbsistema_acesso set     sis_ac_gmenu_cd = 1150     ,   sis_ac_descricao = 'Grupo de Produto' where sis_ac_cd = 1115;

update tbsistema_acesso set     sis_ac_descricao = '* * Produto' where sis_ac_cd = 1150;
