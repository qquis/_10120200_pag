select * from tbzanthustab_mercadoria
select * from tbzanthustab_mercadoria_tipo_venda
select * from tbzanthustab_mercadoria_tipo_venda_qtde 
select * from TbZanthustab_produto_decomposicao
select * from TbZanthustab_produto_decomposicao_insum
select * from tbzanthustabtributacao
select * from tbzanthustabtributacao_cod_tributacao 
select * from tbfc_regrafiscal
select * from tbzanthus_tributacao_nfce limit 10
select * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoftunitario = 43

DROP TABLE tbzanthus_tributacao_pdv_tipo

drop table if exists tbproduto_tributacao_pdv_tipo;
create table tbproduto_tributacao_pdv_tipo 
	(
			produto_tributacao_pdv_tipo_cd int 
		,	produto_tributacao_pdv_tipo_descricao varchar(15)
		,	tipocliente varchar(30)
		,	df_nf_tipo  int 
		,	constraint pkproduto_tributacao_pdv_tipo  primary key (produto_tributacao_pdv_tipo_cd)
	)
	;
	insert into tbproduto_tributacao_pdv_tipo (produto_tributacao_pdv_tipo_cd, produto_tributacao_pdv_tipo_descricao, tipocliente, df_nf_tipo)
			SELECT 1, 'NFCE', '', 0 where not exists (SELECT 1 FROM tbproduto_tributacao_pdv_tipo WHERE produto_tributacao_pdv_tipo_cd = 1);
	insert into tbproduto_tributacao_pdv_tipo (produto_tributacao_pdv_tipo_cd, produto_tributacao_pdv_tipo_descricao, tipocliente, df_nf_tipo)
			SELECT 2, 'NFE CONSUMIDOR', 'TIPO_CONSUMIDOR', 26 where not exists (SELECT 1 FROM tbproduto_tributacao_pdv_tipo WHERE produto_tributacao_pdv_tipo_cd = 2);
	insert into tbproduto_tributacao_pdv_tipo (produto_tributacao_pdv_tipo_cd, produto_tributacao_pdv_tipo_descricao, tipocliente, df_nf_tipo)
			SELECT 3, 'NFE REVENDA', 'TIPO_REVENDA', 26 where not exists (SELECT 1 FROM tbproduto_tributacao_pdv_tipo WHERE produto_tributacao_pdv_tipo_cd = 3);


select * from tbproduto_tributacao_pdv_tipo			


drop table if exists tbproduto_tributacao_pdv;
select 	
	
		pr_cdproduto 
	,	prb_cdprodutobluesoft
	,	cast(0 as int) prb_cdprodutobluesoftunitario 
	,	cast(0 as int) fc_regrafiscal_cd
	,	cast(0 as int) fc_figurafiscal_cd 
	,	cast(0 as int) as cfop 
	,	cast(0 as int) as produto_tributacao_pdv_tipo_cd 

	,	ncm_codigo
	,	ncm_excecao
	,	ncm_variacao
	,	cest 
	,	pis_cst
	,	pis_aliquota
	,	cofins_cst
	,	cofins_aliquota
	,	cod_tributacao_pdv	
	,	icms_cst_origem
	,	icms_cst
	,	icms_aliquota
	,	icms_reducao
	,	icms_aliquota_final
	,	rt_codigo_cst_ibs_cbs 
into 	tbproduto_tributacao_pdv
from 	tbzanthus_tributacao_nfce
where 1 = 2
;

alter table tbproduto_tributacao_pdv add constraint pkzanthus_tributacao_pdv primary key (prb_cdprodutobluesoft);
alter table tbproduto_tributacao_pdv add constraint uqzanthus_tributacao_pdv unique (pr_cdproduto, prb_cdprodutobluesoft, produto_tributacao_pdv_tipo_cd);


INSERT INTO tbproduto_tributacao_pdv 
			(
					pr_cdproduto
				,	prb_cdprodutobluesoft
				,	preg_cdbarra					
				,	cod_mercadoria 					
				,	cod_tributacao_pdv 	
				,	ncm_codigo 
				,	ncm_excecao 
				,	ncm_variacao 
				,	cest 
				,	pis_cst 
				,	pis_aliquota 
				,	cofins_cst 
				,	cofins_aliquota 
				
				,	icms_cst_origem					
				,	icms_cst						
				,	icms_aliquota					
				,	icms_reducao 					
				,	icms_aliquota_final			
				
			)
		SELECT 	 		cast(coalesce(GTX.pr_cdproduto,0) as int) as pr_cdproduto 
					,	cast(coalesce(GTX.prb_cdprodutobluesoft,0) as int) as prb_cdprodutobluesoft
					,	gt.prbg_cdbarra_pk as preg_cdbarra
					,	lpad(gt.prbg_cdbarra_pk, 17, '0') as cod_mercadoria 
					,	0 as cod_tributacao_pdv
					,	cast(coalesce(case when tr.ncm_codigo = '' then '0' else tr.ncm_codigo end, '0')  as int) as ncm_codigo
					,	cast(coalesce(tr.ncm_excecao,0) as int) as ncm_excecao
					,	cast(coalesce(tr.ncm_variacao,0)  as int) as ncm_variacao
					,	0 as cest
					,	tr.pis_cst as pis_cst
					,	tr.pis_aliquota  as pis_aliquota
					,	tr.cofins_cst as cofins_cst
					,	tr.cofins_aliquota as cofins_aliquota 
					,	coalesce(tr.icms_codigo_origem, '0')	 as icms_codigo_origem
					,	coalesce(tr.icms_codigo_tributacao, '00') as icms_codigo_tributacao 
					,	tr.icms_aliquota as icms_aliquota
					,	tr.icms_reducao as icms_reducao 
					,	tr.icms_aliquota_final as icms_aliquota_final 
					,	cast(1 as SMALLINT) as regra_fiscal
								
		FROM 	 	tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'false'

select * from tbproduto_tributacao_pdv
select * from tbfc_regrafiscal_nfce_produto limit 10
