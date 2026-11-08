-- Active: 1758901528917@@192.168.1.6@5432@oxan
do $$
begin 
-- CRIAR TABELA DE LOGIN --------------------------------------------------------------------------
	-- TBRH_SALARIO

	/*

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbautorizacaopagamento' 
			  and   column_name = 'bluesoft_competencia_cd'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbautorizacaopagamento add bluesoft_competencia_cd int default(0);
				update tbautorizacaopagamento set bluesoft_competencia_cd = competencia_cd where coalesce(competencia_cd,0) <> 0 
				;		 
	end if;
	
	
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbrh_salario_old' 
			) = 0  -->> Se não existir
	   	)	
	then 
			
		    CREATE TABLE tbrh_salario_old AS 
		    SELECT * FROM tbrh_salario;

			
			drop table if exists tbrh_salario;
			create table  tbrh_salario
					(
							competencia_cd 						int
						,	cdparticipante 						int
						,	rh_funcionario_cd 					int
						,	rh_tipo_contrato_cd  				int
						,	rh_setor_operacional_cd 			int
						,	rh_vl_salario 						numeric(13,2)
						,	rh_vl_salario_liq					numeric(13,2)
						,	rh_vl_pj 							numeric(13,2)
						,	rh_vl_outros						numeric(13,2)
						,	constraint pkrh_salario primary key (competencia_cd, rh_funcionario_cd)
					)
					;
	end if
	;
	*/


/*

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbrh_dtm_funcionario' 
			  and   column_name = 'dtm_resciscao'
			) > 0  -->> Se existir
	   	)	
	then 
				alter table tbrh_dtm_funcionario rename column dtm_resciscao to dtm_rescisao;
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbrh_dtm_funcionario' 
			  and   column_name = 'dtlog_insert'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table tbrh_dtm_funcionario add dtlog_insert timestamp default (current_timestamp)
				;
				alter table tbrh_dtm_funcionario add dtlog_update timestamp 
				;		 
	end if;
	;*/

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_tributacao_nfce' 
			) = 0  -->> Se não existir
	   	)	
	then 
	--drop table if exists tbzanthus_tributacao_nfce;
	CREATE TABLE tbzanthus_tributacao_nfce
		(			
					dtlog_insert		            timestamp default (current_timestamp)
				,	dtlog_update		            timestamp
				,	zanthus_tributacao_nfce_seq		serial 
				,	api_regra_fiscal				smallint 
				,	pr_cdproduto 					int				
				,	prb_cdprodutobluesoft			int
				,	preg_cdbarra					varchar(14)
				,	cod_mercadoria 					varchar(17)
				,	cod_tributacao_pdv		 		int
				,	ncm_codigo						int
				,	ncm_excecao 					int
				,	ncm_variacao 					int
				,	cest							int
				,	pis_cst 						char(3)
				,	pis_aliquota					numeric(17,4)
				,	cofins_cst 						char(4)
				,	cofins_aliquota					numeric(17,4)
				,	icms_cst_origem					char(1)
				,	icms_cst						char(2)
				,	icms_aliquota					numeric(17,4)
				,	icms_reducao 					numeric(17,4)
				,	icms_aliquota_final				numeric(17,4)
				,	r_cod_sit_tributaria_ibs_cbs 	char(4)
				,	r_cod_class_tributaria_ibs_cbs	numeric(17,4)
				,	r_PER_ALIQUOTA_IBS_UF			numeric(17,4)
				,	r_PER_DIFERIMENTO_IBS_UF		numeric(17,4)
				,	r_PER_REDUCAO_ALIQUOTA_IBS_UF	numeric(17,4)
				,	r_PER_CRED_PRESUMIDO_IBS_MONO	numeric(17,4)
				,	r_PER_ALIQUOTA_CBS				numeric(17,4)
				,	r_PER_DIFERIMENTO_CBS			numeric(17,4)
				,	r_PER_REDUCAO_ALIQUOTA_CBS		numeric(17,4)
				,	r_PER_CRED_PRESUMIDO_CBS_MONO	numeric(17,4)
			,	constraint pkzanthus_tributacao_nfce primary key (cod_mercadoria)
			,	constraint uqzanthus_tributacao_nfce unique (zanthus_tributacao_nfce_seq, pr_cdproduto, prb_cdprodutobluesoft, preg_cdbarra, cod_mercadoria) 
		);
	end if;


if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_tributacao_nfce_cod_tributacao' 
			) = 0  -->> Se não existir
	   	)	
	then 
	--drop table if exists tbzanthus_tributacao_nfce_cod_tributacao;
			create table tbzanthus_tributacao_nfce_cod_tributacao 
				(		cod_tributacao_pdv int
					,	icms_cst char(2)
					,	icms_aliquota numeric(17,4)
					,	icms_reducao numeric(17,4)
					,	icms_aliquota_final numeric(17,4)
					,	api_regra_fiscal				smallint 					
					,	constraint pkzanthus_tributacao_nfce_cod_tributacao primary key (cod_tributacao_pdv, icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final)
				)
				;
	end if;





	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_regra_icms' 
			  and   column_name = 'api_regra_fiscal'
			) = 0  -->> Se não existir
	   	)	
	then 
				alter table TbZanthusTab_Regra_Icms add api_regra_fiscal smallint default(0)	;
	end if;
end$$



--- TESTE CARGA
/*
SELECT * FROM tbzanthus_tributacao_nfce LIMIT 10

SELECT f0085_50_1012016_zanthus_carga_decomposicao();
SELECT f0085_51_1012016_zanthus_carga_tributacao();
SELECT f0085_52_1012016_zanthus_carga_log();
SELECT f0085_53_1012016_zanthus_carga_regra_icms();
SELECT f0085_54_1012016_zanthus_carga_tabMercadoria();
SELECT f0085_55_1012016_zanthus_carga_preco_voucher();
*/

