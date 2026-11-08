-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 
	if ((	SELECT 	count(*)
			FROM    information_schema.columns
			WHERE   table_name = 'tbfaturamentocontrato'
			AND   column_name = 'contrato_uuid'
		) = 0
		)	
	then 
		alter table tbfaturamentocontrato add contrato_uuid varchar(10) default 'SEM_UUID';
		update tbfaturamentocontrato set contrato_uuid = 'SEM_UUID' where contrato_uuid is null;
		
	end if;

	if ((	SELECT 	count(*)
			FROM    pg_indexes
			WHERE   tablename = 'tbfaturamentocontrato'
			AND   indexdef like 'CREATE UNIQUE INDEX uqfaturamentocontrato ON public.tbfaturamentocontrato USING btree (contrato_seq, op_cdoperacao, cdparticipante_contratante, faturamento_controle_seq)'
			and   indexname = 'uqfaturamentocontrato'
		) > 0 
		)	
	then 
		alter table tbfaturamentocontrato drop constraint uqfaturamentocontrato;
		alter table tbfaturamentocontrato add constraint uqfaturamentocontrato unique (contrato_seq, op_cdoperacao, cdparticipante_contratante, faturamento_controle_seq, contrato_uuid);
	end if;
	
	if ((	SELECT 	count(*)
			FROM    pg_indexes
			WHERE   tablename = 'tbfaturamentoitenscontratos'
			  and   indexname = 'pkfaturamentoitenscontratos'
			  and   indexdef = 'CREATE UNIQUE INDEX pkfaturamentoitenscontratos ON public.tbfaturamentoitenscontratos USING btree (contrato_seq, contrato_produto_seq, seqfaturamentoorigem, seqfaturamentoitem)'
		))
	
	then
		    -- select * from tbfaturamentoitenscontratos limit 10 
			alter table tbfaturamentoitenscontratos drop constraint pkfaturamentoitenscontratos;
			alter table tbfaturamentoitenscontratos add pr_cdproduto int default(0);
			alter table tbfaturamentoitenscontratos add constraint pkfaturamentoitenscontratos unique (contrato_seq, contrato_produto_seq, seqfaturamentoorigem, seqfaturamentoitem, pr_cdproduto);

			update  tbfaturamentoitenscontratos i
			set pr_cdproduto =  x.pr_cdproduto
			from    tbfaturamentoitens x
			where  x.seqfaturamentoitem = i.seqfaturamentoitem

	end if;

end$$
;


	/*MENUS*/

		/*select * from tbsistema_acesso where sis_ac_gmenu_cd = 3000*/


		/*MENU FATURAMENTO LIST*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3005;
		select public._local_acesso_web(5, 3005, 'Consultar', 'm3005', 3000, '/pages/operacional/faturamento/list')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3005, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3005 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 45, 3005, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3005 and sis_cd = 5 and sis_fc_cd = 45 and sis_ta_cd = 1)
		;



		/*MENU FATURAMENTO CONTRATO*/
		delete from tbsistema_acesso where sis_cd = 5 and sis_ac_cd = 3050;
		select public._local_acesso_web(5, 3050, 'Contratos', 'm3050', 3000, '/pages/operacional/faturamento/contrato')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 3050, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3050 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 45, 3050, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 3050 and sis_cd = 5 and sis_fc_cd = 45 and sis_ta_cd = 1)
		;
	 