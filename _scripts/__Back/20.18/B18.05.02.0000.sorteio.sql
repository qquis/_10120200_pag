/*
select * from tbcrm_sorteio_cupom 
where dtlog_insert >= '2026-05-07 01:01:01' 
and sat_ecf <> 99
order by data_emissao asc
select * from tbcrm_sorteio
select * from tbcrm_sorteio_temporada 
select * from tbcrm_sorteio_tipo
*/

UPDATE tbcrm_sorteio_temporada set  crm_so_temp_status = 0 where crm_so_temp_cd = 1
;
delete from tbcrm_sorteio_temporada  where crm_so_temp_cd = 2;
insert into tbcrm_sorteio_temporada 
	(crm_so_temp_cd, crm_so_temp_descricao, crm_so_temp_valor_minimo, crm_so_temp_data_ini, crm_so_temp_data_fim, crm_so_temp_status)
		SELECT 2, 'Temporada 2026/1', 100, '2025-03-01', '2025-03-31', 1
			WHERE NOT EXISTS (SELECT 1 FROM tbcrm_sorteio_temporada WHERE  crm_so_temp_cd = 2 )

;
delete from tbcrm_sorteio  where crm_so_temp_cd = 2;
insert into tbcrm_sorteio 			
	(crm_so_cd, crm_so_temp_cd, crm_so_descricao, crm_so_data_ini, crm_so_data_fim, crm_so_data_sorteio, crm_so_tipo_cd, crm_numero_oficial)
		select 20, 2, 'SORTEIO TESTE', '2026-03-01', '2026-03-31', '2026-05-07', 1, null
			WHERE NOT EXISTS (SELECT 1 FROM tbcrm_sorteio WHERE crm_so_cd = 20 )


			