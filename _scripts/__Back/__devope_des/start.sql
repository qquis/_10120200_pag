
update tbsistema_usuario a
    set passwd = x.passwd 
      , passwd_web = x.passwd_web 
from tbsistema_usuario x
where x.user_name = 'elias'
  and (    a.passwd != ''
         or a.passwd_web != '')

;
update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3002' where sis_batch_service_cd = 995002;
update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3003' where sis_batch_service_cd = 995003;
update tbsistema_batch_service set sis_batch_service_host = 'http://localhost:3001' where sis_batch_service_cd = 995001