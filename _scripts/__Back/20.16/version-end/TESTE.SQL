-- FUNCTION: public.


select oxan_carga()

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

    BEGIN
	cod_voucher_valido_hoje:= to_char(current_date, 'YYYYMMDD');


/* TRATATIVA VOUCHER ---------------------------------------------------------------------------*/
   		DELETE FROM tab_voucher_promocional_prod WHERE cod_voucher = cod_voucher_valido_hoje
                ;

                INSERT INTO tab_voucher_promocional 
                    (
                            cod_voucher
                        ,       descricao_parceiro
                        ,       validade_inicial 
                        ,       validade_final
                        ,       minimo_venda
                        ,       tipo_desconto 
                        ,       tipo_utilizacao 
                        ,       tipo_aplicacao 
                        ,       valor_aplicacao
                        ,       flg_status --- >> 0 
                        ,       flg_ativo
                        ,       Dth_inclusao 
                        ,       Dth_alteracao 
                        ,       Idt_usuario_alteracao 
                        ,       limite_utilizacao 
                        ,       limite_utilizado 
                        ,       tipo_comportamento 
                        ,       limite_por_cliente
                        ,       cod_voucher_alternativo
                        ,       flg_fornecedor
                        ,       flags_manager
                        ,       tipo_venda 
                    )

                select          cod_voucher_valido_hoje                           as cod_voucher                                
                        ,       'PROMOCAO DIA '  || cod_voucher_valido_hoje     as descricao_parceiro                 
                        ,       current_date                             as validade_inicial             
                        ,       current_date                             as validade_final                       
                        ,       1.00                                     as minimo_venda                         
                        ,       1                                        as tipo_desconto                        
                        ,       0                                        as tipo_utilizacao                      
                        ,       1                                        as tipo_aplicacao                       
                        ,       NULL                                     as valor_aplicacao                      
                        ,       0                                        as flg_status                           
                        ,       'S'                                      as flg_ativo                            
                        ,       current_timestamp                        as Dth_inclusao                         
                        ,       current_timestamp                        as Dth_alteracao                            
                        ,       100                                      as Idt_usuario_alteracao        
                        ,       0                                        as limite_utilizacao                
                        ,       NULL                                     as limite_utilizado                 
                        ,       2                                        as tipo_comportamento                   
                        ,       1                                        as limite_por_cliente                   
                        ,       NULL                                     as cod_voucher_alternativo          
                        ,       'N'                                      as flg_fornecedor                               
                        ,       NULL                                     as flags_manager                                    
                        ,       1                                        as tipo_venda                                                   
                    WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional  WHERE cod_voucher  = cod_voucher_valido_hoje)
                ;

                INSERT INTO tab_voucher_promocional_prod
                        (
                                cod_voucher 
                            ,   cod_produto 
                            ,   qtd_maxima 
                            ,   tipo_aplicacao 
                            ,   valor_aplicacao 
                            ,   flg_ativo 
                            ,   Dth_inclusao 
                            ,   Dth_alteracao 
                            ,   Idt_usuario_alteracao 
                        )
                    select
                                    cod_voucher_valido_hoje                                                 as cod_voucher                              
                                ,       m.cod_mercadoria                                               as cod_produto                            
                                ,       0                                                              as qtd_maxima                                 
                                ,       1                                                              as tipo_aplicacao                         
                                ,       cast(v1.preco_unitario - v2.preco_unitario as numeric(13,2))   as valor_aplicacao                        
                                ,       'S'                                                            as flg_ativo                              
                                ,       current_timestamp                                              as Dth_inclusao                    
                                ,       current_timestamp                                              as Dth_alteracao                      
                                ,       current_timestamp                                              as Idt_usuario_alteracao      
                    from                tab_mercadoria                          m
                    left join   tab_mercadoria_tipo_venda       v1 on v1.cod_mercadoria = m.cod_mercadoria and v1.cod_tipo_venda = '1'
                    left join   tab_mercadoria_tipo_venda       v2 on v2.cod_mercadoria = m.cod_mercadoria and v2.cod_tipo_venda = '2'
                    where               1 = 1
                    and             cast(v1.preco_unitario as numeric(13,2)) > cast(v2.preco_unitario as numeric(13,2))

                ;
                
                INSERT INTO tab_voucher_promocional_loja
                        ( cod_voucher, cod_loja , flg_ativo, Dth_inclusao, Dth_alteracao, Idt_usuario_alteracao )
                        select cod_voucher_valido_hoje, 1, 'S', current_date, current_date, 100  
                                WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional_loja  WHERE cod_voucher = cod_voucher_valido_hoje)

				;
















	
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

	/* AJUSTE DOS IMPOSTOS REDUZIDOS COM ERRO DESDE AGOSTO */
	
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

	;



	
	UPDATE TAB_MERCADORIA SET CFOP = '5405' WHERE COD_SITUACAO_TRIBUTARIA = 60  AND COALESCE(CFOP,'0000000') != '5405'
	;
	UPDATE TAB_MERCADORIA SET CFOP = '5102' WHERE COD_SITUACAO_TRIBUTARIA != 60  AND COALESCE(CFOP,'0000000') != '5102'


	;
	UPDATE tab_mercadoria X
	SET    COD_SIT_TRIB_PIS = a.CST 
	     , aliquota_pis = a.ALIQUOTA
	FROM   TAB_REGRAS_ICMS A
	WHERE  A.COD_MERCADORIA = X.COD_MERCADORIA 
	  AND  A.FLG_TIPO_IMPOSTO = 1 -- PIS 
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
	  AND  A.FLG_TIPO_IMPOSTO = 2 -- COFINS
	 -- AND  A.COD_MERCADORIA = '00000000000428118'
	  AND  (		cast(coalesce(x.COD_SIT_TRIB_COFINS,'0') as int) <> cast(coalesce(a.CST,'0') as int)
	  			OR  coalesce(x.aliquota_COFINS,0) <> a.ALIQUOTA
			)  

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

    EXCEPTION
        WHEN others THEN
            RAISE NOTICE 'ERRO na função oxan_carga(): % - %', SQLSTATE, SQLERRM;
            RAISE;
    END;	
end;
$BODY$;

ALTER FUNCTION public.oxan_carga()
    OWNER TO postgres;

