-- Active: 1773758617277@@127.0.0.1@5432@oxan
-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1777038659657@@172.17.0.166@5432-- Active: 1777038659657@@172.17.0.166@5432

/*

select * from tbest_info
select * from tbest_produto
SELECT * FROM tbdocumentofiscal limit 1
SELECT * FROM tbdocumentofiscal_tipo

CODIGO EAN A SER ANALISADO: 00000000000579025

select * from tbprodutobluesoft_gtins where prbg_cdbarra_pk like '%579025%' limit 10
select * from tbprodutoembalagem where prb_cdprodutobluesoft = 97730

*/



do $$
begin 



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfaturamentozanthus' 
			  and   column_name = 'tiponota'
			) = 0
	   	)	
	then 
			alter table tbfaturamentozanthus add column tiponota int;
			
			
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_altura'
			) = 0
	   	)	
	then 
			alter table tbprodutobluesoft add column prb_altura numeric(17,4);
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_largura'
			) = 0
	   	)	
	then 
			alter table tbprodutobluesoft add column prb_largura numeric(17,4);
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_pesoaproximado'
			) = 0
	   	)	
	then 
			alter table tbprodutobluesoft add column prb_pesoaproximado numeric(17,4);
	end if;




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_comprimento'
			) = 0
	   	)	
	then 
			alter table tbprodutobluesoft add column prb_comprimento numeric(17,4);
	end if;





end$$	
		;



insert into tbintegracao_tipo (integracao_tipo_cd, integracao_cd, integracao_tipo_descricao, zanthus, bluesoft_redshift, bluesoft_api, tipo_export, tipo_import)
	SELECT 20008590, 2000, 'Zanthus DADOS BÁSICOS', 1, 0,0,NULL,NULL
	  WHERE NOT EXISTS (SELECT 1 FROM tbintegracao_tipo WHERE integracao_tipo_cd = 20008590);




		select public._local_acesso_web(5, 1150, 'Listagem Produtos Bluesoft', 'm1150', 1150, '/pages/cadastro/produtobluesoft/listagem')
			;	


		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1150, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1150 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;

/*
select 		prb_cdprodutobluesoft_pk
		, 	prb_descricao
		, 	prb_pesobruto
		, 	prb_pesoliquido 
		, 	prb_comprimento
		,   prb_largura
		,   prb_altura
		,   prb_pesoaproximado
from tbprodutobluesoft
where 1= 1
and coalesce(prb_altura,0) <> 0 
and prb_cdprodutobluesoftunitario = 115021
 limit 10
*/

