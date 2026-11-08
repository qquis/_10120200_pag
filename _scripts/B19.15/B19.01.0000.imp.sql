-- Active: 1773758617277@@127.0.0.1@5432@oxan

do $$
begin 



--prb_ncm varchar(8)
--prb_cest varchar(7)

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal_nfce_produto' 
			and   column_name = 'api_ncm'
			) = 0
	   	)	
	then 
		alter table tbfc_regrafiscal_nfce_produto add column api_ncm smallint default(0);
	end if;	
	

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_regrafiscal_nfce_ncm' 
			) = 0
	   	)	
	then 
		create table tbfc_regrafiscal_nfce_ncm (
				dtlog_insert                                      timestamp default(current_timestamp),
				dtlog_update                                      timestamp without time zone,
				fc_regrafiscal_nfce_ncm_seq                       serial,
				ncm_codigo                                        varchar(8),
				ncm_excecao                                       integer,
				ncm_variacao                                      integer,
				codigo_figura_regra_fiscal                        integer,
				codigo_regra_fiscal                               integer,
				cfop                                              integer not null,
				icms_codigo_origem                                integer,
				icms_codigo_tributacao                            integer,
				icms_codigo_tributacao_final                      integer,
				icms_percentual_diferimento                       numeric(10,4),
				icms_aliquota_interna                             numeric(10,4),
				icms_fcp_agregado                                 numeric(10,2),
				icms_fcp_segregado                                numeric(10,4),
				icms_codigo_icms                                  integer,
				icms_reducao_aliquota_efetiva                     numeric(10,4),
				icms_aliquota_efetiva                             numeric(10,2),
				icms_aliquota                                     numeric(10,2),
				icms_reducao                                      numeric(10,4),
				icms_aliquota_final                               numeric(10,1),
				icms_csosn                                        varchar(10),
				icms_aliquota_desoneracao                         integer,
				icms_decreto_de_lei                               varchar(120),
				icms_desconto_icms_desonerado                     varchar(60),
				cofins_aliquota                                   numeric(10,4),
				cofins_cst                                        integer,
				pis_aliquota                                      numeric(10,4),
				pis_cst                                           integer,
				ipi_aliquota                                       numeric(10,3),
				ipi_cst                                           integer,
				data_hora_geracao                                 timestamp without time zone,
				data_referencia                                   varchar(10),
				rt_codigo_cst_ibs_cbs                             varchar(10),
				rt_codigo_class_trib_ibs_cbs                      varchar(20),
				ibs_cd                                            integer,
				ibs_aliquota                                      numeric(10,4),
				ibs_aliquota_efetiva                              numeric(10,4),
				ibs_percentual_credito_presumido                  numeric(10,4),
				ibs_percentual_diferimento                        numeric(10,4),
				ibs_percentual_reducao                            numeric(10,4),
				ibs_aliquota_desoneracao                          numeric(10,4),
				ibs_aliquota_ad_rem                               numeric(10,4),
				ibs_percentual_credito_presumido_monofasico       numeric(10,4),
				ibs_percentual_diferimento_monofasico             numeric(10,4),
				cbs_cd                                            integer,
				cbs_aliquota                                      numeric(10,4),
				cbs_aliquota_efetiva                              numeric(10,4),
				cbs_percentual_credito_presumido                  numeric(10,4),
				cbs_percentual_diferimento                        numeric(10,4),
				cbs_percentual_reducao                            numeric(10,4),
				cbs_aliquota_desoneracao                          numeric(10,4),
				cbs_aliquota_ad_rem                               numeric(10,4),
				cbs_percentual_credito_presumido_monofasico       numeric(10,4),
				cbs_percentual_diferimento_monofasico             numeric(10,4),
				nfce_produto_tipo_cd                              integer not null default 0,
				ibs_mun_cd                                        integer,
				ibs_mun_aliquota                                  numeric(10,4),
				ibs_mun_aliquota_efetiva                          numeric(10,4),
				ibs_mun_percentual_credito_presumido              numeric(10,4),
				ibs_mun_percentual_diferimento                    numeric(10,4),
				ibs_mun_percentual_reducao                        numeric(10,4),
				ibs_mun_aliquota_desoneracao                      numeric(10,4),
				ibs_mun_aliquota_ad_rem                           numeric(10,4),
				ibs_mun_percentual_credito_presumido_monofasico   numeric(10,4),
				ibs_mun_percentual_diferimento_monofasico         numeric(10,4),
				constraint pkfc_regrafiscal_nfce_ncm primary key (ncm_codigo, ncm_excecao, ncm_variacao),
				constraint uqfc_regrafiscal_nfce_ncm unique (fc_regrafiscal_nfce_ncm_seq, 
								ncm_codigo, 
								ncm_excecao, 
								ncm_variacao, 
								codigo_figura_regra_fiscal, 
								codigo_regra_fiscal)
			);

	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_figurafiscal_produto' 
			and   column_name = 'regrafiscal_nfe'
			) = 0
	   	)	
	then 
		alter table tbfc_figurafiscal_produto add column regrafiscal_nfe smallint;
		
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_figurafiscal_produto' 
			and   column_name = 'regrafiscal_nfe_ncm'
			) = 0
	   	)	
	then 
		alter table tbfc_figurafiscal_produto add column regrafiscal_nfe_ncm char(8);
	end if;	



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			and   column_name = 'prb_ncm'
			) = 0
	   	)	
	then 
		alter table tbprodutobluesoft add column prb_ncm varchar(8);
		
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			and   column_name = 'prb_cest'
			) = 0
	   	)	
	then 
		alter table tbprodutobluesoft add column prb_cest varchar(7);
		
	end if;



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_mercadoria' 
			and   column_name = 'flginativo'
			) = 0
	   	)	
	then 
		alter table tbzanthustab_mercadoria add column flginativo char(1);
		
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_regra_icms' 
			and   column_name = 'per_cred_presumido_ibs_mono'
			) = 0
	   	)	
	then 
		alter table tbzanthustab_regra_icms add column per_cred_presumido_ibs_mono numeric(17,4);
		alter table tbzanthustab_regra_icms add column per_cred_presumido_cbs_mono numeric(17,4);
		alter table tbzanthustab_regra_icms add column cod_class_tributaria int; 
		alter table tbzanthustab_regra_icms add column per_aliquota_especifica numeric(17,4);
	end if;




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbzanthustab_regra_icms' 
			and   column_name = 'flg_tipo_imposto'
			and   data_type = 'integer'
			) > 0
	   	)	
	then 
		alter table tbzanthustab_regra_icms alter column flg_tipo_imposto type char(1);
	end if;



	if ((select count(*)
			FROM pg_indexes
			WHERE tablename like 'tbzanthustab_regra_icms'
			and indexdef = 'CREATE UNIQUE INDEX pkzanthustab_regra_icms ON public.tbzanthustab_regra_icms USING btree (pr_cdproduto, prb_cdprodutobluesoft, preg_cdbarra, cod_mercadoria, cod_regras_icms, flg_tipo_imposto)'
			) > 0 
	   	)	
	then 
		alter table tbzanthustab_regra_icms 
		drop constraint pkzanthustab_regra_icms
		;

		alter table tbzanthustab_regra_icms 
			add constraint pkzanthustab_regra_icms 
		primary key (pr_cdproduto, prb_cdprodutobluesoft, preg_cdbarra, cod_mercadoria, cod_regras_icms, flg_tipo_imposto, flg_revenda)
		;

	end if;


	if ((select count(*)
			FROM pg_indexes
			WHERE tablename like 'tbzanthustab_regra_icms'
			and indexdef = 'CREATE UNIQUE INDEX uqzanthustab_regra_icms ON public.tbzanthustab_regra_icms USING btree (cod_mercadoria, flg_tipo_imposto)'
			) > 0 
	   	)	
	then 
		alter table tbzanthustab_regra_icms drop constraint uqzanthustab_regra_icms
		;

		alter table tbzanthustab_regra_icms 
			add constraint uqzanthustab_regra_icms 
		unique (cod_mercadoria, flg_tipo_imposto, flg_revenda)
		;

	end if;	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbprodutobluesoft' 
			  and   column_name = 'prb_cest'
			) = 0
	   	)	
	then 
			alter table tbprodutobluesoft add column prb_cest varchar(7);
	end if;




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_endereco' 
			  and   column_name = 'ibge_municipio_cd'
			) = 0
	   	)	
	then 
			alter table tbparticipante_endereco add column ibge_municipio_cd varchar(8);
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_regrafiscal_nfce_produto_tipo' 
			) = 0
	   	)	
	then 
			create table tbfc_regrafiscal_nfce_produto_tipo 
			(
					nfce_produto_tipo_cd int 
				,	nfce_produto_tipo_descricao varchar(15)
				,	tipocliente varchar(30)
				,	df_nf_tipo  int 
				,	constraint pkfc_regrafiscal_nfce_produto_tipo  primary key (nfce_produto_tipo_cd)
			)
			;
			
			
	end if;

	

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_tributacao_icms_pdv' 
			) = 0
	   	)	
	then 

		create table tbzanthus_tributacao_icms_pdv
		(		dtlog_insert        timestamp default(current_timestamp)
			,	icms_cd 			int
			,	cod_tributacao_pdv	int default (999)
			,	tributacao_icms_pdv_descricao varchar(60)
			,	constraint pkzanthus_tributacao_icms_pdv primary key (icms_cd)
		);
		
	end if;



	-- drop table if exists tbzanthus_tributacao_produto
	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbzanthus_tributacao_produto' 
			) = 0
	   	)	
	then 
		create table tbzanthus_tributacao_produto
		(
				dtlog_insert 					timestamp default (current_timestamp)
			,	dtlog_update 					timestamp 
			,	codigo_figura_regra_fiscal		int	
			,	codigo_regra_fiscal				int
			,	flg_revenda						char(1)
			,	pr_cdproduto 					int
			,	prb_cdprodutobluesoftunitario 	int
			,	prb_cdprodutobluesoft 			int
			,	usuario							varchar(35)
			,	data_cadastro					date
			,	data_ultima_alteracao			timestamp

			,	ncm_codigo 						int
			,	ncm_excecao 					int
			,	ncm_variacao 					int
			,	cest 							int
			,	pis_cst 						char(3)
			,	pis_aliquota 					NUMERIC(17,4)	
			,	cofins_cst 						char(3)
			,	cofins_aliquota 				NUMERIC(17,4)


			,	cod_tributacao_pdv 				int
			,	icms_codigo_icms				int
			,	icms_cst_origem					char(1)
			,	icms_cst						char(3)
			,	icms_aliquota					NUMERIC(17,4)	
			,	icms_reducao 					NUMERIC(17,4)		
			,	icms_aliquota_final				NUMERIC(17,4)

			,	codigo_beneficio_fiscal			varchar(10)
			
			,	cod_sit_tributaria_ibs_cbs 		varchar(4)
			,	cod_class_tributaria_ibs_cbs 	int


			,	per_aliquota_ibs_uf 			numeric(17,4)
			,	per_reducao_aliquota_ibs_uf 	numeric(17,4)
			,   per_diferimento_ibs_uf 			numeric(17,4)	


			,	per_aliquota_ibs_mun 			numeric(17,4)
			,	per_reducao_aliquota_ibs_mun 	numeric(17,4)
			,	per_diferimento_ibs_mun 		numeric(17,4)


			,	per_aliquota_cbs 				numeric(17,4)
			,	per_reducao_aliquota_cbs 		numeric(17,4)
			,	per_diferimento_cbs 			numeric(17,4)		

			,	per_cred_presumido_ibs_mono 	numeric(17,4)
			,	per_cred_presumido_cbs_mono 	numeric(17,4)
			,	info_complementar 				char(19)
			,   constraint pkzanthus_tributacao_produto primary key (flg_revenda, prb_cdprodutobluesoft)
			,   constraint uqzanthus_tributacao_produto unique (flg_revenda, pr_cdproduto, prb_cdprodutobluesoftunitario, prb_cdprodutobluesoft)
			

		)
		;
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal_nfce_produto' 
			  and   column_name = 'nfce_produto_tipo_cd'
			) = 0
	   	)	
	then 
		alter table tbfc_regrafiscal_nfce_produto drop constraint uk_fc_regrafiscal_nfce_produto;
		alter table tbfc_regrafiscal_nfce_produto drop constraint pkfc_regrafiscal_nfce_produto;
		
		alter table tbfc_regrafiscal_nfce_produto add column nfce_produto_tipo_cd int default(0) not null;
		update tbfc_regrafiscal_nfce_produto set nfce_produto_tipo_cd = 1;
		alter table tbfc_regrafiscal_nfce_produto add constraint pkfc_regrafiscal_nfce_produto primary key (nfce_produto_tipo_cd, prb_cdprodutobluesoft);
		alter table tbfc_regrafiscal_nfce_produto add constraint uqfc_regrafiscal_nfce_produto unique (pr_cdproduto, prb_cdprodutobluesoftunitario, prb_cdprodutobluesoft, nfce_produto_tipo_cd, codigo_regra_fiscal);

			
			
	end if;


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbfc_regrafiscal_nfce_produto' 
			  and   column_name = 'ibs_mun_cd'
			) = 0
	   	)	
	then 
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_cd int;
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_aliquota numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_aliquota_efetiva numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_percentual_credito_presumido numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_percentual_diferimento numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_percentual_reducao numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_aliquota_desoneracao numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_aliquota_ad_rem numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_percentual_credito_presumido_monofasico numeric(10,4);
			alter table tbfc_regrafiscal_nfce_produto add column ibs_mun_percentual_diferimento_monofasico numeric(10,4)
			;
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.tables 
			where 	table_name = 'tbfc_ibs_mun' 
			) = 0
	   	)	
	then 
			create table tbfc_ibs_mun (
					dtlog_insert timestamp default(current_timestamp)
				,	dtlog_update timestamp
				,   ibs_mun_cd int
				,   ibs_mun_descricao varchar(100)
				,   ibs_mun_descricao_abreviada varchar(50)
				,	constraint pkfc_ibs_mun primary key (ibs_mun_cd)
			);
	end if;

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_endereco' 
			  and   column_name = 'ibge_municipio_cd'
			) = 0
	   	)	
	then 
			alter table tbparticipante_endereco add column ibge_municipio_cd varchar(8);
	end if;
	

	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante' 
			  and   column_name = 'inscricaoestadual'
			) = 0
	   	)	
	then 
			alter table tbparticipante add column inscricaoestadual varchar(20);
			
		
	end if;		




	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_bluesoft' 
			  and   column_name = 'tipocliente'
			) = 0
	   	)	
	then 
			alter table tbparticipante_bluesoft add column tipocliente varchar(15);
			
		
	end if;		



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_endereco_tipo' 
			  and   column_name = 'descricaobluesoft_api'
			) = 0
	   	)	
	then 
			alter table tbparticipante_endereco_tipo add column descricaobluesoft_api varchar(20);
			
		
	end if;		



	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_contato_tipo' 
			  and   column_name = 'contato_tipo_bluesoft_api'
			) = 0
	   	)	
	then 
			alter table tbparticipante_contato_tipo add column contato_tipo_bluesoft_api varchar(40);
			
		
	end if;	


	if ((	SELECT 	count(*)
			FROM 	information_schema.columns 
			where 	table_name = 'tbparticipante_contato_tipo' 
			  and   column_name = 'contato_tipo_bluesoft_api'
			) = 0
	   	)	
	then 
			alter table tbparticipante_contato_tipo add column contato_tipo_bluesoft_api varchar(40);
			
		
	end if;	







end$$	
;




/*
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
					SCRIPTA DE TRATATIVAS NA TABELA tbzanthus_tributacao_produto
					TIPO : tbzanthus_tributacao_icms_pdv

*/


	

	---2) EXECUTAR O SCRIPT ABAIXO
	insert into tbzanthus_tributacao_icms_pdv
			(
				icms_cd 
			)
	SELECT 	 		
				tr.icms_codigo_icms as icms_codigo_icms

	FROM 	 	tbprodutobluesoft					prb 
	INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = prb.prb_cdprodutobluesoftunitario 
	INNER JOIN  tbproduto pr on pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
	--> REGISTRA APENAS OS PRODUTOS QUE TEM CODIGO DE TRIBUTACAO VINCULADOp
	inner join tbproduto_subgrupo sg on sg.prsg_cdsubgrupo = prb.prb_cdsubgrupo 
	inner join tbproduto_grupo g on g.prg_cdgrupo = sg.prg_cdgrupo 
	inner join tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
	inner join tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento 
	WHERE       1 = 1
	and         d.prd_cddepartamento in (1, 5)
	AND         coalesce(rt_codigo_cst_ibs_cbs, '') != ''
	AND         prb.prb_status = 'true'
	and         tr.icms_codigo_icms not in ( select icms_cd from tbzanthus_tributacao_icms_pdv )
	group by 	tr.icms_codigo_icms

	;


	/*TEMPORARIO*/
	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 17
	,      tributacao_icms_pdv_descricao = 'TEMP 020 ICMS 25% RED 52%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 25
	and     i.reducao = 52 
	;
	
	/*TEMPORARIO*/
	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 6
	,      tributacao_icms_pdv_descricao = 'TEMP 051 ICMS 0%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.codigotributacao = 51
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 0
	,      tributacao_icms_pdv_descricao = '000 ICMS 7%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 7
	and     i.reducao = 0 
	;


	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 4
	,      tributacao_icms_pdv_descricao = '060 SUBSTITUICAO'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 0
	and     i.reducao = 0 
	and     i.codigotributacao = 60
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 5
			,      tributacao_icms_pdv_descricao = 'ISENTO'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 0
	and     i.reducao = 0 
	and     i.codigotributacao = 40
	;
	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 7
	,      tributacao_icms_pdv_descricao = '000 ICMS 12%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 12
	and     i.reducao = 0 
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 8
	,      tributacao_icms_pdv_descricao = '000 ICMS 18%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 18
	and     i.reducao = 0 
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 9
	,      tributacao_icms_pdv_descricao = '000 ICMS 25%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 25
	and     i.reducao = 0 
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 10
	,      tributacao_icms_pdv_descricao = '020 ICMS 12% RED 8.33%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 12
	and     i.reducao = 8.33
	;



	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 13
	,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 33.33%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 18
	and     i.reducao = 33.33000
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 14
	,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 38.88%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 18
	and     i.reducao = 38.88000		
	;

	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 15
	,      tributacao_icms_pdv_descricao = '020 ICMS 12% RED 41.67%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 12
	and     i.reducao = 41.67000		
	;


	update tbzanthus_tributacao_icms_pdv x
	set    cod_tributacao_pdv  = 16
	,      tributacao_icms_pdv_descricao = '020 ICMS 18% RED 61.11%'
	from   tbfc_icms i
	where   i.icms_cd = x.icms_cd 
	and     i.aliquota = 18
	and     i.reducao = 61.11
	;



/*
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
*/








/*AJUSTE CST TbZanthusTab_Regra_Icms  */
		update     TbZanthusTab_Regra_Icms 
		    set    cst = lpad(cst, 3, '0') 
		WHERE length(cst) < 3	      
	
	;



/*AJUSTE INICIAL TABELA DE PRODUTO NCM / CEST */
update tbprodutobluesoft a
set		prb_ncm = b.prbt_ncm 
     ,  prb_cest = b.prbt_cest
from 	 tbprodutoblueSoft_tributacao b
where a.prb_cdprodutobluesoft_pk = b.prb_cdprodutobluesoft
and a.prb_ncm is null
;
update tbprodutobluesoft a
set		prb_ncm = b.prbt_ncm 
     ,  prb_cest = b.prbt_cest
from 	 tbprodutoblueSoft_tributacao b
where a.prb_cdprodutobluesoftunitario = b.prb_cdprodutobluesoft
and a.prb_ncm is null
;




/*TIPOS DE REGRAS FISCAIS ----------------------------------------------------*/

		insert into tbfc_regrafiscal_nfce_produto_tipo (nfce_produto_tipo_cd, nfce_produto_tipo_descricao, tipocliente, df_nf_tipo)
				SELECT 1, 'NFCE', '', 0 where not exists (SELECT 1 FROM tbfc_regrafiscal_nfce_produto_tipo WHERE nfce_produto_tipo_cd = 1);
		insert into tbfc_regrafiscal_nfce_produto_tipo (nfce_produto_tipo_cd, nfce_produto_tipo_descricao, tipocliente, df_nf_tipo)
				SELECT 2, 'NFE CONSUMIDOR', 'TIPO_CONSUMIDOR', 26 where not exists (SELECT 1 FROM tbfc_regrafiscal_nfce_produto_tipo WHERE nfce_produto_tipo_cd = 2);
		insert into tbfc_regrafiscal_nfce_produto_tipo (nfce_produto_tipo_cd, nfce_produto_tipo_descricao, tipocliente, df_nf_tipo)
				SELECT 3, 'NFE REVENDA', 'TIPO_REVENDA', 26 where not exists (SELECT 1 FROM tbfc_regrafiscal_nfce_produto_tipo WHERE nfce_produto_tipo_cd = 3);

/*PARTICIPANTE ----------------------------------------------------------------*/

		insert into tbparticipante_endereco_tipo (endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)
		select 1, 'BLUE - FATURAMENTO' , 'FATURAMENTO'
			where not exists (select 1 from tbparticipante_endereco_tipo where endereco_tipo_cd = 1)
		;
		insert into tbparticipante_endereco_tipo (endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)
		select 2, 'PAG - ENDERECO' , ''
			where not exists (select 1 from tbparticipante_endereco_tipo where endereco_tipo_cd = 2)
		;
		insert into tbparticipante_endereco_tipo (endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)
		select 3, 'RH - ENDEREÇO' , ''
			where not exists (select 1 from tbparticipante_endereco_tipo where endereco_tipo_cd = 3)
		;
		
		UPDATE tbparticipante_endereco_tipo 
			SET 	endereco_tipo_descricao = 'BLUE - FATURAMENTO' 
				,	descricaobluesoft_api = 'FATURAMENTO'
			WHERE endereco_tipo_cd = 1;
		
		delete from tbparticipante_endereco_tipo where endereco_tipo_cd = 4;
		insert into tbparticipante_endereco_tipo ( endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api) 
		SELECT 4, 'BLUE - ENTREGA', 'ENTREGA' 
		WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_endereco_tipo WHERE endereco_tipo_cd = 4);
		
		delete from tbparticipante_endereco_tipo where endereco_tipo_cd = 5;
		insert into tbparticipante_endereco_tipo ( endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)  
		SELECT 5, 'BLUE - COBRANCA', 'COBRANCA'
		WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_endereco_tipo WHERE endereco_tipo_cd = 5);
		
		delete from tbparticipante_endereco_tipo where endereco_tipo_cd = 7;
		insert into tbparticipante_endereco_tipo ( endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)  
		SELECT 7, 'BLUE - ECOMMERCE', 'ECOMMERCE'
		WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_endereco_tipo WHERE endereco_tipo_cd = 7);
		
		delete from tbparticipante_endereco_tipo where endereco_tipo_cd = 8;
		insert into tbparticipante_endereco_tipo ( endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)  
		SELECT 8, 'BLUE - EMPREGADOR', 'EMPREGADOR'
		WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_endereco_tipo WHERE endereco_tipo_cd = 8);
		
		delete from tbparticipante_endereco_tipo where endereco_tipo_cd = 9;
		insert into tbparticipante_endereco_tipo ( endereco_tipo_cd, endereco_tipo_descricao, descricaobluesoft_api)  
		SELECT 9, 'BLUE - ADICIONAL', 'ADICIONAL'
		WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_endereco_tipo WHERE endereco_tipo_cd = 9);
		
		
		UPDATE tbparticipante_contato_tipo set contato_tipo_bluesoft_api = 'BLUESOFT_PAG_IMP_REDSHIFT' WHERE contato_tipo_cd = 1;
		UPDATE tbparticipante_contato_tipo set contato_tipo_bluesoft_api = 'CONTATO_PAG' WHERE contato_tipo_cd = 2;
		
		INSERT INTO tbparticipante_contato_tipo (contato_tipo_cd, contato_tipo_descricao, contato_tipo_bluesoft_api) 
		   SELECT 3, 'MAIL NFE BLUE', 'EMAIL_NOTA_FISCAL_ELETRONICA'
		   WHERE NOT EXISTS (SELECT 1 FROM tbparticipante_contato_tipo WHERE contato_tipo_cd = 3)
		;



/*AJUSTES DE TAREFAS*/

		INSERT INTO tbsistema_tarefa (sis_cd, sis_ta_cd, sis_ta_descricao, sis_ta_tipo_cd)
				SELECT 5,99915100, 'PARTICIPANTE | Ver dados do RH', 1 
				WHERE NOT EXISTS (SELECT 1 FROM tbsistema_tarefa WHERE sis_cd = 5 AND sis_ta_cd = 99915100)
			
		;

		INSERT INTO tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 1, 1011, 99915100
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1011 and sis_cd = 5 and sis_fc_cd = 1 and sis_ta_cd = 99915100)
		;


/*MENUS*/

		select public._local_acesso_web(5, 1211, 'Tabela de Cliente', 'm1211', 1200, '/pages/cadastro/zanthus/cliente')
			;	


		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1211, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1211 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)

		;


		select public._local_acesso_web(5, 1211, 'Tabela de Cliente', 'm1211', 1200, '/pages/cadastro/zanthus/cliente')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 1211, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 1211 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)
		;

		--select * from tbsistema_acesso
		--select * from tbsistema_acesso_grupomenu where sis_ac_modulo_menu_cd = 4000

		insert into tbsistema_acesso_grupomenu (sis_ac_gmenu_cd, sis_ac_gmenu, sis_ac_gmenu_sub, sis_ac_modulo_menu_cd)
		select 4700, 'Controller | Dados Fiscais Zanthus', 'Controller', 4000
		where not exists (select 1 from tbsistema_acesso_grupomenu where sis_ac_gmenu_cd = 4700);


		delete from tbsistema_acesso where sis_ac_cd = 4720;
		select public._local_acesso_web(5, 4720, 'Tributação Blue/Zanthus Codigo ICMS', 'm4720', 4700, '/pages/controller/fiscal/zanthustributacaopdv')
			;	
		insert into tbsistema_permissao (sis_cd, sis_fc_cd, sis_ac_cd, sis_ta_cd)
		select 5, 2, 4720, 1
		where not exists (select 1 from tbsistema_permissao where sis_ac_cd = 4720 and sis_cd = 5 and sis_fc_cd = 2 and sis_ta_cd = 1)
		;





