

						

CREATE OR REPLACE FUNCTION public.f0001_02_1012018_sistema_login(
	sqlcommand character varying,
	vsis_id integer,
	vemail_main character varying,
	vpasswd character varying,
	vusuario_login_uuid character varying,
	vuser_credential character varying,
	vuser_credential_number character varying)
    RETURNS TABLE(usuario_login_uuid character varying, sis_us_seq integer, user_name character varying, dtlog_insert timestamp without time zone, autorizado integer, email_login character varying, user_credential character varying, user_credential_number character varying, sis_id integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$

BEGIN

	if SqlCommand = 'DBINSERT'
	then 
		vusuario_login_uuid:= (SELECT substr(md5(random()::text), 1, 10))
		;
		insert into tbsistema_usuario_login 
		(				usuario_login_uuid 
					,	sis_id
					,	sis_us_seq 			
					,	cdparticipante		
					,	email_login				
					,	passwd			
					,	autorizado 			
		)
		select			vusuario_login_uuid
					,	vsis_id
					,	coalesce(b.sis_us_seq,0)
					,	coalesce(b.cdparticipante,0)
					,	vemail_main
					,	vpasswd
					,	case vsis_id 
					         when 5 then 
							 		case when coalesce(b.sis_us_seq,0) > 0 then 1 else 0 end 
					         when 3 then 
							 		case when coalesce(b.sis_us_seq,0) > 0 then 1 else 0 end 									 
							 when 6 then 1
							 else 0
						end
			from (select vemail_main as email_main, vpasswd as password) a
			left join    (select 		coalesce(u.sis_us_seq,0) as sis_us_seq
							,			coalesce(p.cdparticipante,0) as cdparticipante
							,			u.passwd_web as passwd
							,			p.email_main as email_main
							,			u.user_name  as user_name 
						from 		tbparticipante		 		p 
						left join 	tbparticipante_bluesoft  	b on b.cdparticipante = p.cdparticipante 
						left join tbsistema_usuario 			u on u.cdpessoabluesoft = b.cdpessoabluesoft 
					    where 	   1 = 1 
				) b on a.password = b.passwd 
				and    (		b.email_main = a.email_main	
							or  b.user_name = a.email_main	
						)
			
	
		;
	end if

	;

	if SqlCommand = 'DBUPDATE'
	then 
		UPDATE 		tbsistema_usuario_login x
			set 	user_credential 		= vuser_credential 
			,		user_credential_number 	= vuser_credential_number
		where 		x.usuario_login_uuid = vusuario_login_uuid
		;
	end if
	;

	return query 
	select 		l.usuario_login_uuid							as usuario_login_uuid
			,	coalesce(l.sis_us_seq ,0) 						as sis_us_seq		
			,	coalesce(u.user_name,'') 						as user_name		
			,	l.dtlog_insert 									as dtlog_insert				
			,	cast(l.autorizado as int)						as autorizado
			,	l.email_login									as email_login
			,	l.user_credential								as user_credential
			,	l.user_credential_number						as user_credential_number
			,	cast(l.sis_id as int)							as sis_id
	from 		tbsistema_usuario_login l 
	left join   tbsistema_usuario 		 u on u.sis_us_seq = l.sis_us_seq
	where		1 = 1 
	  and  		l.usuario_login_uuid 		= vusuario_login_uuid	
	  and		l.email_login 				= vemail_main
	  --and       l.passwd = vpasswd
	

	;

END;
$BODY$;


