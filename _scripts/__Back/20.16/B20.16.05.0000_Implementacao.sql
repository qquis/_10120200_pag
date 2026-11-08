-- Active: 1758901528917@@192.168.1.6@5432@oxan



do $$
begin 
	/* Novos campos na tabela tbzanthustab_mercadoria - cfop */
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'cfop'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbzanthustab_mercadoria add cfop numeric(7,0);
	end if;



	/* Novos campos na tabela tbzanthustab_mercadoria - cod_sit_trib_pis */
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'cod_sit_trib_pis'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table TbZanthusTab_Mercadoria add cod_sit_trib_pis char(3);
	end if;


	/* Novos campos na tabela tbzanthustab_mercadoria - aliquota_pis */
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'aliquota_pis'
			) = 0  -->> Se não existir
	   	)	
	then 
		alter table TbZanthusTab_Mercadoria add aliquota_pis numeric(17,4);
	end if;

	/* Novos campos na tabela tbzanthustab_mercadoria - cod_sit_trib_cofins */
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'cod_sit_trib_cofins'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table TbZanthusTab_Mercadoria add cod_sit_trib_cofins char(3);
	end if;


	/* Novos campos na tabela tbzanthustab_mercadoria - aliquota_pis */
	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			  and   column_name = 'aliquota_cofins'
			) = 0  -->> Se não existir
	   	)	
		   
	then 
		alter table TbZanthusTab_Mercadoria add aliquota_cofins numeric(17,4);
	end if;

	
end$$
