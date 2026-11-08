-- FUNCTION: public.oxan_carga()

-- DROP FUNCTION IF EXISTS public.oxan_carga();

CREATE OR REPLACE FUNCTION public.oxan_carga(
	)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

	declare vdescricao_conf varchar(50):= '';
	declare hora_carga varchar(5):= '';
	
	declare vdescricao_prom varchar(30):= '';
		declare vdescricao_prod varchar(20):= '';

	declare cod_voucher_valido_hoje varchar(8):= '';
	declare vl_preco_data varchar(10):= '';
begin
	cod_voucher_valido_hoje:= to_char(current_date, 'YYYYMMDD');
	hora_carga:= to_char(current_timestamp, 'HH24:MI');

	
	vl_preco_data:= to_char(current_timestamp, 'HH24.MI');

	--select * from tab_voucher_promocional

	if (select count(*) 
		from tab_voucher_promocional 
		where cod_voucher = cod_voucher_valido_hoje) > 0 
	then 
		vdescricao_prod:= (select 		left(m.descricao,10) || '_' || right(i.cod_produto,2)
							  from   		tab_voucher_promocional_prod i
							  inner join 	tab_mercadoria m on m.cod_mercadoria = i.cod_produto 

							  order by i.valor_aplicacao DESC
							  limit 1);
		vdescricao_prom:= 'Prm_' || right(cod_voucher_valido_hoje,4) || '_' || vdescricao_prod;							  
	else 
			vdescricao_prom:=  'Prm error';
	end if

	;

	vdescricao_conf:= 'OXAN-DADOS_' || to_char(current_date, 'MMDD') || '_'|| hora_carga || ' - ' || vdescricao_prom;	

	update tab_mercadoria 
		set descricao = vdescricao_conf
		,	descricao_abr = 'OXAN-DADOS_' || to_char(current_date, 'MMDD') || '_'|| hora_carga
		,	data_ultima_alteracao = current_timestamp
	where cod_mercadoria like '00000000000101801'
	;
	
	update tab_mercadoria_tipo_venda 
		set preco_unitario = cast(vl_preco_data as numeric(13,2)) 
		,	data_ultima_alteracao = current_timestamp		
	where cod_mercadoria like '00000000000101801'
	
	;

	/* AJUSTE DOS IMPOSTOS REDUZIDOS COM ERRO DESDE AGOSTO 
	
	UPDATE tab_mercadoria
	set    aliquota_icms = 12
	WHERE  1 = 1 
	and    cod_tributacao_mercadoria = 10
	and    percentual_reduz_b_calculo = 8.33
	AND    COD_SITUACAO_TRIBUTARIA = '20'
	AND    aliquota_icms = 11
	AND    COD_MERCADORIA IN (SELECT COD_MERCADORIA FROM TMP_1227_MERC)
	;
	
	UPDATE TAB_REGRAS_ICMS
		SET	ALIQUOTA = 12
	WHERE 1=1 
	and flg_tipo_imposto = 0
	AND PERC_REDUCAO = 8.33
	AND ALIQUOTA = 11
	AND cod_mercadoria IN (SELECT COD_MERCADORIA FROM TMP_1227_MERC)

	;*/

	/*
	UPDATE TAB_MERCADORIA SET CFOP = '5405' WHERE COD_SITUACAO_TRIBUTARIA = 60  AND COALESCE(CFOP,'0000000') != '5405'
	;
	UPDATE TAB_MERCADORIA SET CFOP = '5102' WHERE COD_SITUACAO_TRIBUTARIA != 60  AND COALESCE(CFOP,'0000000') != '5102'
	;*/

	
	UPDATE tab_mercadoria X
	SET    COD_SIT_TRIB_PIS = a.CST 
	     , aliquota_pis = a.ALIQUOTA
	FROM   TAB_REGRAS_ICMS A
	WHERE  A.COD_MERCADORIA = X.COD_MERCADORIA 
	  AND  A.FLG_TIPO_IMPOSTO = '1' -- PIS 
	 -- AND  A.COD_MERCADORIA = '00000000000428118'
	  AND  (		cast(coalesce(x.COD_SIT_TRIB_PIS,'0') as int) != cast(coalesce(a.CST,'0') as int) 
	  			OR  x.aliquota_pis != a.ALIQUOTA
			)
	;	
	UPDATE tab_mercadoria X
	SET    COD_SIT_TRIB_COFINS = a.CST 
	     , aliquota_COFINS = a.ALIQUOTA
	FROM   TAB_REGRAS_ICMS A
	WHERE  A.COD_MERCADORIA = X.COD_MERCADORIA 
	  AND  A.FLG_TIPO_IMPOSTO = '2' -- COFINS
	 -- AND  A.COD_MERCADORIA = '00000000000428118'
	  AND  (		cast(coalesce(x.COD_SIT_TRIB_COFINS,'0') as int) <> cast(coalesce(a.CST,'0') as int)
	  			OR  coalesce(x.aliquota_COFINS,0) <> a.ALIQUOTA
			)  

	;

	/* ALIMENTA TABELA DE NCM X REFORMA OXAN 31/07/2023 */
	insert into tboxan_ncm_reforma
		(
				cod_ncm  
			,	cod_sit_tributaria_ibs_cbs 
			,	cod_class_tributaria_ibs_cbs 
			,	per_aliquota_ibs_uf 
			,	per_reducao_aliquota_ibs_uf 
			,	per_diferimento_ibs_mun 
			,	per_aliquota_ibs_mun 
			,	per_reducao_aliquota_ibs_mun 
			,	per_aliquota_cbs 
			,	per_diferimento_cbs 
			,	per_reducao_aliquota_cbs 
			,	per_cred_presumido_ibs_mono 
			,	per_cred_presumido_cbs_mono 
			,	info_complementar 
	
	
		)
	
	select 		lpad(cast(x.cod_ncm as varchar(11)), 11, '0') as cod_ncm  
			,	x.cod_sit_tributaria_ibs_cbs 
			,	x.cod_class_tributaria_ibs_cbs 
			,	x.per_aliquota_ibs_uf 
			,	x.per_reducao_aliquota_ibs_uf 
			,	x.per_diferimento_ibs_mun 
			,	x.per_aliquota_ibs_mun 
			,	x.per_reducao_aliquota_ibs_mun 
			,	x.per_aliquota_cbs 
			,	x.per_diferimento_cbs 
			,	x.per_reducao_aliquota_cbs 
			,	x.per_cred_presumido_ibs_mono 
			,	x.per_cred_presumido_cbs_mono 
			,	x.info_complementar 
	--into 	tboxan_ncm_reforma 		
	from 	tab_mercadoria	x
	where origem_cadastro = '2'
	and   not exists (select 1 from tboxan_ncm_reforma aa where aa.cod_ncm = lpad(cast(x.cod_ncm as varchar(11)), 11, '0') )
	group by lpad(cast(cod_ncm as varchar(11)), 11, '0') 
			,	cod_sit_tributaria_ibs_cbs 
			,	cod_class_tributaria_ibs_cbs 
			,	per_aliquota_ibs_uf 
			,	per_reducao_aliquota_ibs_uf 
			,	per_diferimento_ibs_mun 
			,	per_aliquota_ibs_mun 
			,	per_reducao_aliquota_ibs_mun 
			,	per_aliquota_cbs 
			,	per_diferimento_cbs 
			,	per_reducao_aliquota_cbs 
			,	per_cred_presumido_ibs_mono 
			,	per_cred_presumido_cbs_mono 
			,	info_complementar 
	order by 	1
	;
		UPDATE	TAB_MERCADORIA A
				SET 
			
					cod_sit_tributaria_ibs_cbs = B.cod_sit_tributaria_ibs_cbs
				,	cod_class_tributaria_ibs_cbs = B.cod_class_tributaria_ibs_cbs
				,	per_aliquota_ibs_uf = B.per_aliquota_ibs_uf
				,	per_reducao_aliquota_ibs_uf = B.per_reducao_aliquota_ibs_uf
				,	per_diferimento_ibs_mun = B.per_diferimento_ibs_mun
				,	per_aliquota_ibs_mun = B.per_aliquota_ibs_mun
				,	per_reducao_aliquota_ibs_mun = B.per_reducao_aliquota_ibs_mun
				,	per_aliquota_cbs = B.per_aliquota_cbs
				,	per_diferimento_cbs = B.per_diferimento_cbs
				,	per_reducao_aliquota_cbs = B.per_reducao_aliquota_cbs
				,	per_cred_presumido_ibs_mono  = B.per_cred_presumido_ibs_mono
				,	per_cred_presumido_cbs_mono = B.per_cred_presumido_cbs_mono
				,	info_complementar = B.info_complementar
		FROM ( select 		xx.cod_ncm 
						,	xx.seq 
						,	xx.cod_sit_tributaria_ibs_cbs 
						,	xx.cod_class_tributaria_ibs_cbs 
						,	xx.per_aliquota_ibs_uf 
						,	xx.per_reducao_aliquota_ibs_uf 
						,	xx.per_diferimento_ibs_mun 
						,	xx.per_aliquota_ibs_mun 
						,	xx.per_reducao_aliquota_ibs_mun 
						,	xx.per_aliquota_cbs 
						,	xx.per_diferimento_cbs 
						,	xx.per_reducao_aliquota_cbs 
						,	xx.per_cred_presumido_ibs_mono 
						,	xx.per_cred_presumido_cbs_mono  
						,	xx.info_complementar 		
				from tboxan_ncm_reforma xx
				inner join (	select 	x.cod_ncm
									,	min(x.seq) as seq 
								from 	tboxan_ncm_reforma x
								group by x.cod_ncm 
							) x on x.cod_ncm = xx.cod_ncm and x.seq = xx.seq 
		) b 
		WHERE lpad(cast(a.cod_ncm as varchar(11)), 11, '0')  = b.cod_ncm 
			and   a.origem_cadastro is null
			--and   a.cod_mercadoria like '%7896348301670' -- teste produto
		;

	UPDATE	TAB_MERCADORIA 
		SET 
	
			cod_sit_tributaria_ibs_cbs = 200
		,	cod_class_tributaria_ibs_cbs = 200014
		,	per_aliquota_ibs_uf = 0.1000
		,	per_reducao_aliquota_ibs_uf = 100.0000
		,	per_diferimento_ibs_mun = 0.0000
		,	per_aliquota_ibs_mun = 0 
		,	per_reducao_aliquota_ibs_mun = 100.0000
		,	per_aliquota_cbs = 0.9000
		,	per_diferimento_cbs = 0.0000
		,	per_reducao_aliquota_cbs = 100
		,	per_cred_presumido_ibs_mono  = 0
		,	per_cred_presumido_cbs_mono = 0
		,	info_complementar = 'I'
	where 	1= 1
	--and    cod_mercadoria like '%500715'
	and	  cod_sit_tributaria_ibs_cbs is null 
	and   origem_cadastro is null
	and   per_aliquota_ibs_uf is null
	and	  per_aliquota_cbs is null 
	;

	--update tab_mercadoria set aliquota_interna_icms = aliquota_icms where  coalesce(aliquota_interna_icms,0) != coalesce(aliquota_icms,0)
	--;
end;
$BODY$;

ALTER FUNCTION public.oxan_carga()
    OWNER TO postgres;
