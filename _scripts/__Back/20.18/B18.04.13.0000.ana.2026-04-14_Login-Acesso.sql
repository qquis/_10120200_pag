SELECT * 
                        FROM   f0001_02_1012015_sistema_login
                        (       SqlCommand:= 'DBINSERT',
                                vsis_id:= 3,
                                vemail_main:= 'elias',
                                vpasswd:= 'ozHZ2Rs4teoLTibHd6WE+w==', 
                                vusuario_login_uuid:= '',
                                vuser_credential:= '', 
                                vuser_credential_number:= ''

                        ) 
SELECT * 
                        FROM   f0001_02_1012015_sistema_login
                        (       SqlCommand:= 'DBINSERT',
                                vsis_id:= 3,
                                vemail_main:= 'elias',
                                vpasswd:= 'KUAxkeMqxIJ+fF6YuI+K5Q==', 
                                vusuario_login_uuid:= '',
                                vuser_credential:= '', 
                                vuser_credential_number:= ''

                        ) 

web 
SELECT * 
                        FROM   f0001_02_1012015_sistema_login
                        (       SqlCommand:= 'DBINSERT',
                                vsis_id:= 5,
                                vemail_main:= 'eliassilva@oxan.com.br',
                                vpasswd:= 'KUAxkeMqxIJ+fF6YuI+K5Q==', 
                                vusuario_login_uuid:= '',
                                vuser_credential:= '', 
                                vuser_credential_number:= ''

                        ) 
select * from tbsistema_usuario where user_name = 'elias'			
KUAxkeMqxIJ+fF6YuI+K5Q==
select * from tbsistema_usuario_login order by dtlog_insert desc
SELECT * FROM f0001_10_1012017_sistema_login_acesso_list (	    vusuario_login_uuid:= '31558df54b' ) 
SELECT * FROM f0001_10_1012017_sistema_login_acesso_list (	    vusuario_login_uuid:= '4ed921acb0' ) 

update tbsistema_usuario set passwd_web = 'Ud7FCK0yCzeTkKcxuZduUA==' where user_name = 'gilvan'
select * from tbsistema_usuario where user_name = 'gilvan'



SELECT * 
                        FROM   f0001_02_1012015_sistema_login
                        (       SqlCommand:= 'DBINSERT',
                                vsis_id:= 3,
                                vemail_main:= 'gilvan',
                                vpasswd:= 'Ud7FCK0yCzeTkKcxuZduUA==', 
                                vusuario_login_uuid:= '',
                                vuser_credential:= '', 
                                vuser_credential_number:= ''

                        ) 


select 		coalesce(u.sis_us_seq,0) as sis_us_seq
							,			coalesce(p.cdparticipante,0) as cdparticipante
							,			u.passwd_web as passwd
							,			p.email_main as email_main
							,			u.user_name  as user_name 
						from 		tbparticipante		 		p 
						left join 	tbparticipante_bluesoft  	b on b.cdparticipante = p.cdparticipante 
						left join tbsistema_usuario 			u on u.cdpessoabluesoft = b.cdpessoabluesoft 
					    where 	   1 = 1 
						  and     u.passwd = 'Ud7FCK0yCzeTkKcxuZduUA=='
						  and     user_name = 'gilvan'
