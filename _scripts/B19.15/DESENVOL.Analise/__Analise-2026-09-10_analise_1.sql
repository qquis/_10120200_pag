


/*
Script base para indicar o codigo da regra fiscal, considerando que a api nfe traz um sequenci no lugar do codigo
			SELECT   x.prb_cdprodutobluesoft, a.*
			FROM        ( 
			SELECT 		pr_cdproduto 				as pr_cdproduto
					,	prb_cdprodutobluesoft_pk   		as prb_cdprodutobluesoft
					,	prb_cdprodutobluesoftunitario 	as prb_cdprodutobluesoftunitario
			FROM        tbprodutobluesoft       prb 
            LEFT JOIN   tbproduto               pr ON pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
            WHERE       PRB.prb_cdprodutobluesoft_pk = 228547
			) as x, (	select  	t.fc_regrafiscal_cd as fc_regrafiscal_cd, o.df_nf_tipo as df_nf_tipo
					from 		tbfc_regrafiscal t
					inner join 	tbfc_regrafiscal_operacao o on o.fc_regrafiscal_cd = t.fc_regrafiscal_cd
					where t.fc_figurafiscal_cd = 426
					and t.tipo = 'SAIDA'
					and  t.fc_regrafiscal_status = 1
					and   o.df_nf_tipo  = 9
					and   t.tipocliente = 'TIPO_REVENDA')  as  a

			
            WHERE 1 = 1
			AND   NOT EXISTS (
                    SELECT 1 
                    FROM tbfc_regrafiscal_nfce_produto 
                    WHERE prb_cdprodutobluesoft = 228547 
                    and nfce_produto_tipo_cd = 3
                    )
            ;
*/

--> tabela alimentada pelas apis 
select * from tbfc_regrafiscal_nfce_produto limit 10

select * from tbzanthus_tributacao_nfce limit 10

--> tabela formato basico de tributacao com codigo de barra 
--> alimentada pela função f0085_51_1012018_zanthus_carga_tributacao
select * from tbzanthus_tributacao_nfce limit 10

select * from tbzanthustab_regra_icms limit 10
select 	column_name
from 	information_schema.columns 
where	table_name = 'tbzanthustab_regra_icms'
order by ordinal_position asc

create table tbzanthus_tributacao_regra_icms
	(
		dtlog_insert 


	)



select      pr.pr_cdproduto
                        ,   me.prb_cdprodutobluesoft
                        ,   a.cod_regras_icms             as  cod_regras_icms
                        ,	a.cod_loja 
                        ,	a.descricao 
                        ,	a.prioridade 
                        ,	a.flg_registro 
                        ,	a.cod_ncm_ini                 as  cod_ncm_ini
                        ,	a.cod_ncm_fim                 as  cod_ncm_final
                        ,	a.cod_mercadoria 
                        ,	a.uf_origem 
                        ,	a.uf_destino 
                        ,	a.aliquota
                        ,	a.cst
                        ,	a.perc_substituicao 
                        ,	a.perc_reducao 
                        ,	a.flg_tipo_imposto 
                        ,	a.flg_revenda 
                        ,	a.dta_val_inicial 
                        ,	a.dta_val_final 
                        ,	a.cst_orig
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	a.data_ultima_alteracao 
                        ,	a.aliquota_interestadual 
                        ,	a.valor_imposto 
                        ,	a.tipo_lista_st 
                        ,	a.perc_reducao_st 
                        ,	a.perc_diferimento 
                        ,	a.exigibilidade_iss 
                        ,	a.flg_incentivo_fiscal_iss 
                        ,	a.tipo_documento
                        ,   a.codigo_beneficio_fiscal
                from 		 tbzanthustab_regra_icms           			 a
                inner join   TbZanthustab_produto_decomposicao_insum     me on me.cod_insumo = a.cod_mercadoria 
                inner join   tbproduto 						   			 pr on pr.pr_cdproduto = me.pr_cdproduto 
				where		 pr.pr_cdproduto != 0 




INSERT INTO tbzanthus_tributacao_nfce 
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
				,	api_regra_fiscal	
				
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
								
		FROM 	 	TBPRODUTOBLUESOFT_GTINS				GT
		INNER JOIN  tbprodutobluesoft					pr on pr.prb_cdprodutobluesoft_pk = gt.prb_cdprodutobluesoft 
		LEFT JOIN 	tbprodutoembalagem_gtins			GTX ON GTX.preg_cdbarra = gt.prbg_cdbarra_pk
		INNER JOIN 	tbfc_regrafiscal_nfce_produto		TR  ON TR.PRB_CDPRODUTOBLUESOFT = pr.prb_cdprodutobluesoftunitario 
		where		1 = 1 
		and			pr.prb_status_embalagemcaixa = 'false'
		and			lpad(gt.prbg_cdbarra_pk, 17, '0') not in (SELECT cod_mercadoria from tbzanthus_tributacao_nfce)


select * from tbzanthus_tributacao_icms_pdv



insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 0, '000 07%' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 0)
;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 4, '060 00% - SUBSTITUICAO' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 4)
;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 5, '040 00% - ISENTO' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 5)

;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 7, '012 12%' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 7)

;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 8, '018 18%' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 8)

;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 9, '025 25%' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 9)

;
insert into tbzanthus_tributacao_icms_pdv (icms_cd, cod_tributacao_pdv, tributacao_icms_pdv_descricao)
		select 0, 10, '020 12% REDUCAO DE 8,33' WHERE NOT EXISTS (SELECT 1 FROM tbzanthus_tributacao_icms_pdv WHERE cod_tributacao_pdv = 10)


