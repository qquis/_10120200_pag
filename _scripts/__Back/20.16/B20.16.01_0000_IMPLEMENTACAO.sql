--select sis_ac_cd, sis_ac_descricao, sis_ac_href, sis_ac_gmenu_cd from tbsistema_acesso where sis_cd = 5
--select * from tbsistema_acesso_grupomenu
--select * from tbsistema_acesso_modulomenu


select 	ac.sis_ac_cd, 
		ac.sis_ac_descricao, 
		ac.sis_ac_href, 
		ac.sis_ac_gmenu_cd,
		m.sis_ac_gmenu ,
		d.sis_ac_modulo_menu_cd,
		d.sis_ac_modulo_menu_descricao 
		
from 	tbsistema_acesso ac 
left join tbsistema_acesso_grupomenu m on m.sis_ac_gmenu_cd = ac.sis_ac_gmenu_cd
left join tbsistema_acesso_modulomenu d on d.sis_ac_modulo_menu_cd = m.sis_ac_modulo_menu_cd 
where 	ac.sis_cd = 5


insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_modulo_menu_cd)
	select 5110, 'Folha de Pgto', 5000
	where not exists( select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 5110);

update tbsistema_acesso set sis_ac_gmenu_cd = 5110
	where sis_ac_cd = 5130

	
/*



SELECT 		us.sis_us_seq 
   							,	us.sis_fc_cd
							,	ac.sis_ac_cd
							,	ac.sis_ac_descricao 
							,	ac.sis_ac_menu
							,	ta.sis_ta_cd
							,	ta.sis_ta_descricao 
							,	s.sis_cd_pk 
							,	ac.sis_ac_gmenu_cd
							,	sis_ac_gmenu			
							,	sis_ac_gmenu_sub		
							,	sis_ac_gmenu_sub_item	
                            ,   md.sis_ac_modulo_menu_cd
                            ,   md.sis_ac_modulo_menu_descricao 
                            ,   ac.sis_ac_href  							
					FROM 		TBSISTEMA_USUARIO 		us
					inner join  tbsistema_funcao 		fc on fc.sis_fc_cd = us.sis_fc_cd
					inner join  tbsistema_permissao     pm on pm.sis_fc_cd = fc.sis_fc_Cd 
					inner join  tbsistema_acesso        ac on ac.sis_ac_cd = pm.sis_ac_cd 
                                                and ac.sis_cd = pm.sis_cd
					inner join  tbsistema_tarefa        ta on ta.sis_ta_cd = pm.sis_ta_cd 
					inner join  tbsistema				 s on s.sis_cd_pk = ac.sis_cd 
					inner join  tbsistema_acesso_grupomenu x on x.sis_ac_gmenu_cd = ac.sis_ac_gmenu_cd
                    inner join  tbsistema_acesso_modulomenu md on md.sis_ac_modulo_menu_cd = x.sis_ac_modulo_menu_cd
					left  join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = us.cdpessoabluesoft 
					left  join  tbparticipante          p on p.cdparticipante = pb.cdparticipante 
					where us.sis_us_seq = 1*/

CONSULTA DE ITEM DE CUPOM 
select 	i.m00af 
	,	i.m00ad 
	,	i.m00ac 
	,	i.m43ah 
	,	m.descricao
	,	i.m43ap
	,	i.m43aq
	,	i.val_liquido
	,	i.m43ao
from 	zan_m43 i
left join tab_mercadoria m on m.cod_mercadoria = lpad(i.m43ah, 17, '0')
where	1= 1
and		i.m00af = '2025-12-28'
and		i.m00ac = 18
and		i.m00ad = 32668
limit 100
