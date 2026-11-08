-- FUNCTION: public.f0001_10_1012011_sistema_login_acesso_list(character varying)

-- DROP FUNCTION IF EXISTS public.f0001_10_1012011_sistema_login_acesso_list(character varying);

CREATE OR REPLACE FUNCTION public.f0001_10_1012017_sistema_login_acesso_list(
	vusuario_login_uuid character varying)
    RETURNS TABLE(sis_us_seq integer, sis_fc_cd integer, sis_ac_cd integer, sis_ac_descricao character varying, sis_ac_menu character, sis_ta_cd integer, sis_ta_descricao character varying, sis_cd integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE SqlCommand text:= '';
BEGIN


                /*Manutenção em 19/02/2026
                    Conferir se existe alguma indicação ao campo sis_cd da tabela tbsistema_tarefa, pois este campo 
                    será excluído no futuro. 

                    Uma Tarefa deve servir para quaisquer sistemas

                    A Tarefa será relacoinada ao sistema através da tabeal tbsistema_permissao

                */

   SqlCommand:= '	SELECT 		us.sis_us_seq 
   							,	us.sis_fc_cd
							,	ac.sis_ac_cd
							,	ac.sis_ac_descricao 
							,	ac.sis_ac_menu
							,	ta.sis_ta_cd
							,	ta.sis_ta_descricao 
							,	s.sis_cd_pk 
					FROM 		TBSISTEMA_USUARIO 		us
					inner join  tbsistema_funcao 		fc on fc.sis_fc_cd = us.sis_fc_cd
					inner join  tbsistema_permissao     pm on pm.sis_fc_cd = fc.sis_fc_Cd 
					inner join  tbsistema_acesso        ac on ac.sis_ac_cd = pm.sis_ac_cd 
					inner join  tbsistema_tarefa        ta on ta.sis_ta_cd = pm.sis_ta_cd 
					inner join  tbsistema				 s on s.sis_cd_pk = ac.sis_cd
					inner join  tbsistema_usuario_login LG on LG.sis_us_seq = us.sis_us_Seq and LG.sis_id = s.sis_cd_pk
					left  join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = us.cdpessoabluesoft 
					left  join  tbparticipante          p on p.cdparticipante = pb.cdparticipante 
					WHERE      	1 = 1

					';

	if (vusuario_login_uuid != '' )
	then 
		SqlCommand:= SqlCommand || ' and  LG.usuario_login_uuid = ' || '''' || cast(vusuario_login_uuid as varchar(60)) || '''' ;
	end if;

	

   RETURN QUERY 
   EXECUTE SqlCommand;
END;
$BODY$;

