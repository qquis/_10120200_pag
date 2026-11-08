-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 

	--drop table if exists tbforca_venda_fab_meta_res_item;
	if ((	SELECT 	count(*)
				FROM 	information_schema.tables 
				where 	table_name = 'tbforca_venda_fab_meta_res_item' 
				) = 0
			)	
	then 
		create table tbforca_venda_fab_meta_res_item
			(
					dtlog_insert					timestamp default (current_timestamp)
				,	dtlog_update					timestamp
				,	seqinterface 					int
				,   datafaturamento         		date
				,   op_cdoperacao           		int
				,   seqfaturamento          		int
				,   seqfaturamentoorigem    		int
				,   seqprocessamentoitemdocumento	int
				,   cdparticipantecliente         		int
				,   pr_cdproduto            		int
				,	fv_fab_meta_cd					int 
				,	fv_fab_meta_grupo_cd			int
				,   embalagemestoqueqtde            int
				,   embalagemcompraqtde             int


				,	constraint pkforca_venda_fab_meta_res_item primary key (	seqinterface 					
															,   datafaturamento         		
															,   op_cdoperacao           		
															,   seqfaturamento          		
															,   seqfaturamentoorigem    		
															,   seqprocessamentoitemdocumento	
															,   cdparticipantecliente
															,   pr_cdproduto            		
															,	fv_fab_meta_cd					
															,	fv_fab_meta_grupo_cd			
							)
			);
	end if;
	
end$$
;

