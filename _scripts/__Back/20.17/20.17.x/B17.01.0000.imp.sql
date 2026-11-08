do $$
begin 




		
	
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbsis_batch_service_tipo' 
			) = 0  -->> Se não existir
	   	)	
	then 

				-- drop table tbsis_batch_service_tipo 
				CREATE TABLE tbsis_batch_service_tipo
				(
					sis_batch_service_tipo_cd      		smallint         NOT NULL,
					sis_batch_service_tipo_descricao    varchar(100)     NOT NULL,
					CONSTRAINT pksis_batch_service_tipo PRIMARY KEY (sis_batch_service_tipo_cd)
				);
				
				


	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbsistema_batch_service' 
			  and   column_name = 'sis_batch_service_tipo_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbsistema_batch_service add sis_batch_service_tipo_cd smallint;
				
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbsistema_batch_service' 
			  and   column_name = 'sis_batch_service_host'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbsistema_batch_service add sis_batch_service_host varchar(150);
				
	end if;	


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbnotificacao_send_tipo' 
			  and   column_name = 'sis_batch_service_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbnotificacao_send_tipo add sis_batch_service_cd int ;
				
	end if;	



end$$

/* MENUS */
;
update tbsistema_acesso_grupomenu 
set sis_ac_gmenu_sub = 'Procedimentos'
where sis_ac_gmenu_cd = 9000
;


insert into tbsistema_acesso_grupomenu 
	(
			sis_ac_gmenu_cd
		,	sis_ac_gmenu
		,	sis_ac_modulo_menu_cd
		
	) 
select 9010, 'Controles', 9000 
where not exists( select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 9010)

;


delete from tbsistema_acesso where sis_ac_cd = 9010 and sis_cd = 5
;

select _local_acesso_web (5,9010,'Batchs/Services', 'm9010', 9010, '/pages/sistema/controle/services')
;




/* INFOS */

		insert into tbsis_batch_service_tipo (sis_batch_service_tipo_cd, sis_batch_service_tipo_descricao)
				SELECT  1, 'JS SERVICE' WHERE NOT EXISTS ( SELECT 1 FROM tbsis_batch_service_tipo WHERE sis_batch_service_tipo_cd = 1);
			
		insert into tbsis_batch_service_tipo (sis_batch_service_tipo_cd, sis_batch_service_tipo_descricao)
				SELECT  2, 'JS WHATS' WHERE NOT EXISTS ( SELECT 1 FROM tbsis_batch_service_tipo WHERE sis_batch_service_tipo_cd = 2);


	---->> Atualiza os registros existentes para o tipo JS SERVICE
		update tbsistema_batch_service 
		set    sis_batch_service_tipo_cd = 1
		where  sis_batch_service_tipo_cd is null;

	---->> CRIANDO SERVIÇOS DO TIPO JS WHATS
	DELETE FROM tbsistema_batch_service WHERE sis_batch_service_cd IN (995001, 995002, 995003) ;
	INSERT INTO tbsistema_batch_service 
		(
				sis_batch_service_cd
			,	sis_batch_service_tipo_cd 
			,   sis_batch_service_descricao 
			,	sis_batch_service_host
		)
		SELECT  995001, 2, 'WHATS APP ADM', 'http://localhost:3001' 
		WHERE NOT EXISTS ( SELECT 1 FROM tbsistema_batch_service WHERE sis_batch_service_cd = 995001);

	INSERT INTO tbsistema_batch_service 
		(
				sis_batch_service_cd
			,	sis_batch_service_tipo_cd 
			,   sis_batch_service_descricao 
			,	sis_batch_service_host
		)
		SELECT  995002, 2, 'WHATS APP PORTARIA', 'http://localhost:3002'
		WHERE NOT EXISTS ( SELECT 1 FROM tbsistema_batch_service WHERE sis_batch_service_cd = 995002);

	INSERT INTO tbsistema_batch_service 
		(
				sis_batch_service_cd
			,	sis_batch_service_tipo_cd 
			,   sis_batch_service_descricao 
			,	sis_batch_service_host			
		)
		SELECT  995003, 2, 'WHATS BOOT LOJA', 'http://localhost:3003'
		WHERE NOT EXISTS ( SELECT 1 FROM tbsistema_batch_service WHERE sis_batch_service_cd = 995003);

	;
	update tbnotificacao_send_tipo set sis_batch_service_cd = 995001 where notificacao_send_tipo_cd = 100

	;
	update tbnotificacao_send_tipo set sis_batch_service_cd = 995002 where notificacao_send_tipo_cd = 200







/*

select * from tbnotificacao_send_tipo




select * from tbsistema_batch_recorrencia
select * from tbsistema_batch
select * from tbsistema_batch_service
select * from tbsistema_batch_time


select 	b.sis_batch_cd 
	,	b.sis_batch_descricao 
	,	b.sis_batch_status 
	,	b.sis_batch_service_cd 
	,	b.module_cd 
from 	tbsistema_batch b


select 		x.sis_batch_cd, 
		,	r.*
from 		tbsistema_batch_time x
inner join 	tbsistema_batch_recorrencia r on r.sis_batch_recorrencia_cd = r.sis_batch_recorrencia_cd

select 	t.sis_batch_cd 
	,	t.sis_batch_recorrencia_cd
	,	r.sis_batch_recorrencia_descricao
	,	t.sis_batch_dt_ini
	,	t.sis_batch_dt_fim
	,	t.sis_batch_hm_ini
	,	t.sis_batch_hm_fim
	,	t.sis_batch_wk_ini
	,	t.sis_batch_wk_fim
	,	t.sis_batch_time_seq 
from  tbsistema_batch_time t
left join tbsistema_batch_recorrencia r on r.sis_batch_recorrencia_cd = t.sis_batch_recorrencia_cd

*/








