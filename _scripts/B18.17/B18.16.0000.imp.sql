-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'peso_bruto'
			) = 0
	   	)	
	then 
			alter table tbzanthustab_mercadoria add column peso_bruto numeric(12,3);
			
			
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'peso_liquido'
			) = 0
	   	)	
	then 
			alter table tbzanthustab_mercadoria add column peso_liquido numeric(12,3);
		
	end if;



end$$	
		;

--select * from tbsistema_acesso where sis_cd = 5 and sis_ac_descricao like '%Tabela de Mercadoria%'
--select * from tbsistema_acesso where sis_cd = 5 and sis_ac_href like '%pages/controller/fiscal/op%'

		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 4290;
		deelte from tbsistema_permissao where sis_cd = 5 and sis_ac_cd = 4290;



		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 1290;
		select public._local_acesso_web(5, 1290, 'Operações Zanthus', 'm1290', 1200, '/pages/cadastro/zanthus/operacao')
			;	


		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1290, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1290 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;

		
		update tbprodutobluesoft set prb_blue_fc_cbenef_cd = '' where prb_blue_fc_cbenef_cd = 'SP099999';