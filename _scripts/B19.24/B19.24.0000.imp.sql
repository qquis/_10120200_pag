-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 
	if ((select count(*)
		 from   information_schema.columns
		 where  table_name = 'tbfaturamentocontrato'
		   and  column_name = 'contrato_status'

		) = 0
	)
	then
		alter table tbfaturamentocontrato add column contrato_status smallint;
		update tbfaturamentocontrato set contrato_status = 1;
	end if;


	if ((select count(*)
		 from   information_schema.columns
		 where  table_name = 'tbfaturamentocontrato'
		   and  column_name = 'competencia_cd'

		) = 0
	)
	then
		alter table tbfaturamentocontrato add column competencia_cd int default (0);
		update tbfaturamentocontrato set competencia_cd = to_char(contrato_data_val_ini, 'YYYYMM')::int;

	end if;	

	if ((select count(*)
		 from   information_schema.columns
		 where  table_name = 'tbfaturamentoitenscontratos'
		   and  column_name = 'dtlog_update'

		) = 0
	)
	then
		alter table tbfaturamentoitenscontratos add column dtlog_update timestamp;  

	end if;	

	

	if ((select count(*) 
		from pg_indexes 
		where tablename = 'tbfaturamentocontrato' 
		and indexdef = 'CREATE UNIQUE INDEX uqfaturamentocontrato ON public.tbfaturamentocontrato USING btree (contrato_seq, op_cdoperacao, cdparticipante_contratante, faturamento_controle_seq, contrato_uuid)'
		) = 0)
	then 
		alter table tbfaturamentocontrato drop CONSTRAINT uqfaturamentocontrato;
		alter table tbfaturamentocontrato add constraint uqfaturamentocontrato unique (contrato_seq, op_cdoperacao, cdparticipante_contratante, faturamento_controle_seq, contrato_uuid, competencia_cd);
	end if;
end$$
;


