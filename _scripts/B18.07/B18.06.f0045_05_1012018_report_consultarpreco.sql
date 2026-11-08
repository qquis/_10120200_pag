-- FUNCTION: public.f0045_05_1012003_report_consultarpreco(integer, integer, boolean, date, date, character varying, character varying, boolean, boolean, integer, integer, integer, integer, integer, boolean, date, boolean, date, date, integer, integer)

-- DROP FUNCTION IF EXISTS public.f0045_05_1012003_report_consultarpreco(integer, integer, boolean, date, date, character varying, character varying, boolean, boolean, integer, integer, integer, integer, integer, boolean, date, boolean, date, date, integer, integer);

CREATE OR REPLACE FUNCTION public.f0045_05_1012018_report_consultarpreco(
	vcdproduto integer,
	vcdprodutobluesoft integer,
	vseleciona_data_cadastro boolean,
	vdt_cadastro_ini date,
	vdt_cadastro_fim date,
	vdescricao character varying,
	vdescricao_fiscal character varying,
	vstatus_ativo boolean,
	vstatus_inativo boolean,
	vprd_cddepartamento integer,
	vprs_cdsecao integer,
	vprg_cdgrupo integer,
	vprsg_cdsubgrupo integer,
	vtab_pre_cd integer,
	vagendamento_consulta boolean,
	vdata_agendamento date,
	vseleciona_data_mov_entrada boolean,
	vdt_data_entrada_ini date,
	vdt_data_entrada_fim date,
	vpr_status_comercial_preco_inativo integer,
	vvisualizacao_comercial integer)
    RETURNS TABLE(pr_cdproduto integer, prb_cdprodutobluesoft_unitario integer, prb_cdprodutobluesoft integer, pr_descricao character varying, pr_status boolean, pr_embalagemestoque character, pre_embalagem character, pre_fatorestoque numeric, pre_fatorpreco numeric, prc_valor numeric, prca_dt_aplicacao date, prca_aplicacao_definitiva integer, ec_valor_custo_precificacao numeric, ec_valor_custo_faturamento numeric, consulta_valor_custo_precificacao numeric, ec_embalagemestoque_qtde numeric, pr_cesta boolean, prc_qtde_promocional numeric, prc_valor_promocional numeric, consulta_agendamento integer, pr_status_comercial_preco_inativo integer, data_ultima_compra date, data_ultima_venda date, est_satual_embalagemcompraqtde numeric, est_satual_embalagemestoqueqtde numeric, est_satual_ec_valorcusto_faturamento_total numeric, est_satual_valortotalfaturamentoliquido numeric, est_satual_clientes integer, est_satual_pontos integer, est_s4_embalagemcompraqtde numeric, est_s4_embalagemestoqueqtde numeric, est_s4_ec_valorcusto_faturamento_total numeric, est_s4_valortotalfaturamentoliquido numeric, est_s4_clientes integer, est_s4_pontos integer, est_s3_embalagemcompraqtde numeric, est_s3_embalagemestoqueqtde numeric, est_s3_ec_valorcusto_faturamento_total numeric, est_s3_valortotalfaturamentoliquido numeric, est_s3_clientes integer, est_s3_pontos integer, est_s2_embalagemcompraqtde numeric, est_s2_embalagemestoqueqtde numeric, est_s2_ec_valorcusto_faturamento_total numeric, est_s2_valortotalfaturamentoliquido numeric, est_s2_clientes integer, est_s2_pontos integer, est_s1_embalagemcompraqtde numeric, est_s1_embalagemestoqueqtde numeric, est_s1_ec_valorcusto_faturamento_total numeric, est_s1_valortotalfaturamentoliquido numeric, est_s1_clientes integer, est_s1_pontos integer) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE SqlCommand text:= '';
BEGIN

	   if vseleciona_data_mov_entrada
	then 
		drop table if exists temp_codigos_entrada;
	
		CREATE TEMPORARY TABLE temp_codigos_entrada( prb_cdprodutobluesoft int );

		INSERT INTO temp_codigos_entrada (prb_cdprodutobluesoft)
		select 	a.prb_cdprodutobluesoft as codigo_bluesoft 
		from 	tbestoquecusto_entrada a
		
		where    1 = 1
		and    ece_nf_datarecebimento >= vdt_data_entrada_ini
		and    ece_nf_datarecebimento <= vdt_data_entrada_fim
		group by a.prb_cdprodutobluesoft ;

	end if ;
   

   
   
   
   SqlCommand:= '	

   
   
    select 				pr.pr_cdproduto															as pr_cdproduto
					,   pr.prb_cdprodutobluesoft											    as prb_cdprodutobluesoft_unitario 
					,	em.prb_cdprodutobluesoft												as prb_cdprodutobluesoft
					,	xe.prb_descricao 													    as pr_descricao
					,	pr.pr_status															as pr_status
					,	pr.pr_embalagemestoque													as pr_embalagemestoque
					,	em.pre_embalagem														as pre_embalagem
					,	em.pre_fatorestoque														as pre_fatorestoque
					,   case when pr.pr_embalagemestoque = ' || '''' || 'UN'  || '''' || 'then 1 else 
						cast(case when coalesce(em.pre_fatorpreco,0) = 0 then 1 else	coalesce(em.pre_fatorpreco,0) end as numeric(17,4)) end 
																								as pre_fatorpreco';
			if (vagendamento_consulta)
			then																								
					SqlCommand:= SqlCommand || ' ,	cast(case when xx.prc_valor is null then coalesce(xp.prc_valor,0) else coalesce(xx.prc_valor, 0) end   as numeric(13,2)) 	as prc_valor';
			else
					SqlCommand:= SqlCommand || ' ,	cast(coalesce(xx.prc_valor, 0)  as numeric(13,2)) 						as prc_valor';
			end if;
			
			if (vagendamento_consulta)
			then
   				SqlCommand:= SqlCommand || ' , coalesce(xx.prca_dt_aplicacao, ' || '''' || vdata_agendamento || '''' || ') 	as prca_dt_aplicacao';
				SqlCommand:= SqlCommand || ' , coalesce(xx.prca_aplicacao_definitiva,0) 		as prca_aplicacao_definitiva';
			else 
				SqlCommand:= SqlCommand || ' , current_date 									as prca_dt_aplicacao ';
				SqlCommand:= SqlCommand || ' , cast(0 as int)   								as prca_aplicacao_definitiva ';
			end if;

			/******** TIPO VISUALIZACAO DE CUSTO  */
			if coalesce(vvisualizacao_comercial,0) = 0
			then 
				SqlCommand:= SqlCommand || '
					,	cast(coalesce(ex.ec_valor_custo_precificacao,0) * em.pre_fatorestoque as numeric(13,2))				as ec_valor_custo_precificacao
					,	cast(coalesce(ex.ec_valor_custo_faturamento,0)  * em.pre_fatorestoque  as numeric(13,2))			as ec_valor_custo_faturamento			
				';
			end if;
			
			if coalesce(vvisualizacao_comercial,0) = 1 ---> [Maior valor entre custo medio x ultima entrada]
			then 
				SqlCommand:= SqlCommand || '
					, 	cast( 	CASE 
									WHEN coalesce(ex.ec_valor_custo_precificacao,0) > coalesce(ex.ec_valor_custo_faturamento,0)
									THEN coalesce(ex.ec_valor_custo_precificacao,0) * em.pre_fatorestoque
									ELSE coalesce(ex.ec_valor_custo_faturamento,0) * em.pre_fatorestoque
								END  as numeric(13,2))				as ec_valor_custo_precificacao
					,	cast(coalesce(ex.ec_valor_custo_faturamento,0)  * em.pre_fatorestoque  as numeric(13,2))			as ec_valor_custo_faturamento			
				';
			end if;			
			/**************************************/

			SqlCommand:= SqlCommand || '
					,	cast(coalesce(ex.ec_valor_custo_precificacao,0) * em.pre_fatorestoque as numeric(13,2))				as consulta_valor_custo_precificacao
					,	cast(coalesce(ex.ec_embalagemestoque_qtde,0) as numeric(17,4)) 										as ec_embalagemestoque_qtde 
					, 	pr.pr_cesta 																						as pr_cesta'
			;
			if (vagendamento_consulta)
			then
				SqlCommand:= SqlCommand || '
					,	cast(case when xx.prc_qtde_promocional is null then coalesce(xp.prc_qtde_promocional,0) else coalesce(xx.prc_qtde_promocional,0) end  as numeric(17,4)) as prc_qtde_promocional
					,	cast(case when xx.prc_valor_promocional is null then coalesce(xp.prc_valor_promocional, 0) else coalesce(xx.prc_valor_promocional,0) end as numeric(17,4)) as prc_valor_promocional
					';
			else 
				SqlCommand:= SqlCommand || '
					,	cast(coalesce(xx.prc_qtde_promocional, 0) as numeric(17,4)) 										as prc_qtde_promocional
					,	cast(coalesce(xx.prc_valor_promocional, 0) as numeric(17,4)) 										as prc_valor_promocional
					';

			end if;
			
			if (vagendamento_consulta)
			then
   				SqlCommand:= SqlCommand || ' ,cast( 1 as int ) 																as consulta_agendamento';
			else 
				SqlCommand:= SqlCommand || ' ,cast( 0 as int ) 																as consulta_agendamento';
			end if;
			
			
				
			SqlCommand:= SqlCommand || 
			'		, 	cast(coalesce(pr_status_comercial_preco_inativo,0) as int )						as pr_status_comercial_preco_inativo
					, 	cast(coalesce(ep.data_ultima_compra, ' || '''' || '1900-01-01' || '''' || ' ) as date) as data_ultima_compra
					, 	cast(coalesce(eo.data_ultima_venda, ' || '''' || '1900-01-01' || '''' || ' ) as date) as data_ultima_venda
					
					
					,	coalesce(est_satual_embalagemcompraqtde,0)
					,	coalesce(est_satual_embalagemestoqueqtde ,0)			
					,	coalesce(est_satual_ec_valorcusto_faturamento_total,0)	
					,	coalesce(est_satual_valortotalfaturamentoliquido,0)		
					,	coalesce(est_satual_clientes,0)							
					,	coalesce(est_satual_pontos,0)							
									
					,	coalesce(est_s4_embalagemcompraqtde	,0)				
					,	coalesce(est_s4_embalagemestoqueqtde ,0)				
					,	coalesce(est_s4_ec_valorcusto_faturamento_total	,0)	
					,	coalesce(est_s4_valortotalfaturamentoliquido,0)			
					,	coalesce(est_s4_clientes,0)								
					,	coalesce(est_s4_pontos	,0)							
									
					,	coalesce(est_s3_embalagemcompraqtde	,0)				
					,	coalesce(est_s3_embalagemestoqueqtde ,0)				
					,	coalesce(est_s3_ec_valorcusto_faturamento_total		,0)
					,	coalesce(est_s3_valortotalfaturamentoliquido,0)			
					,	coalesce(est_s3_clientes,0)								
					,	coalesce(est_s3_pontos,0)								
								
					,	coalesce(est_s2_embalagemcompraqtde	,0)				
					,	coalesce(est_s2_embalagemestoqueqtde ,0)				
					,	coalesce(est_s2_ec_valorcusto_faturamento_total		,0)
					,	coalesce(est_s2_valortotalfaturamentoliquido,0)			
					,	coalesce(est_s2_clientes	,0)							
					,	coalesce(est_s2_pontos,0)								
									
					,	coalesce(est_s1_embalagemcompraqtde	,0)				
					,	coalesce(est_s1_embalagemestoqueqtde 	,0)			
					,	coalesce(est_s1_ec_valorcusto_faturamento_total	,0)	
					,	coalesce(est_s1_valortotalfaturamentoliquido	,0)		
					,	coalesce(est_s1_clientes,0)								
					,	coalesce(est_s1_pontos	,0)							
					
					
					
						
			from 		tbproduto				pr
			inner join  tbprodutobluesoft       b on b.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
			inner join 	tbprodutoembalagem		em on em.pr_cdproduto = pr.pr_cdproduto 
			inner join  tbprodutobluesoft       xe on xe.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft ';
			
			
			if (vagendamento_consulta)
			then

   				SqlCommand:= SqlCommand || 'left  join  tbpreco_agendamento		xx on xx.pr_cdproduto = em.pr_cdproduto 
														and xx.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft 
														AND xx.tab_pre_cd = ' || cast(vtab_pre_cd as varchar(5)) || '
														and xx.prca_dt_aplicacao = ' || '''' || vdata_agendamento  || '''';
   				SqlCommand:= SqlCommand || 'left  join  tbpreco 				xp on xp.pr_cdproduto = em.pr_cdproduto and xp.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft AND xp.tab_pre_cd = ' || cast(vtab_pre_cd as varchar(5)) ;														
			else 
   				SqlCommand:= SqlCommand || 'left  join  tbpreco 				xx on xx.pr_cdproduto = em.pr_cdproduto and xx.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft AND xx.tab_pre_cd = ' || cast(vtab_pre_cd as varchar(5)) ;
			end if;			

			SqlCommand:= SqlCommand || '
			left  join  tbestoquecusto			ex on ex.pr_cdproduto = pr.pr_cdproduto 	
			left  join  tbproduto_subgrupo		sg on sg.prsg_cdsubgrupo = pr.prsg_cdsubgrupo 
			left  join  tbproduto_grupo 		gr on gr.prg_cdgrupo = sg.prg_cdgrupo 
			left  join  tbproduto_secao 		sc on sc.prs_cdsecao = gr.prs_cdsecao
			left  join  tbproduto_departamento	dp on dp.prd_cddepartamento = sc.prd_cddepartamento 
			left  join  tbest_produto			ep on ep.pr_cdproduto = pr.pr_cdproduto and ep.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 
			left  join  tbest_produto_empresa_operacao eo
												   on eo.pr_cdproduto = pr.pr_cdproduto 
												   and eo.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
												   and eo.em_cdempresa = 1
												   and eo.op_cdoperacao = 2
			
			where 		1 = 1
			and			pr_status = ' || '''' || 'true' || ''''  || '
			and			pr.prb_cdprodutobluesoft not in (select prb_cdprodutobluesoft from tbprodutobluesoft_composicao)
			and			coalesce(ex.ec_valor_custo_precificacao,0) <> 0
			';
		

		if vcdproduto > 0 
		then
   			SqlCommand:= SqlCommand || ' and pr.pr_cdproduto = ' || cast(vcdproduto as varchar(15));
		end if;

		if vcdprodutobluesoft > 0 
		then
   			SqlCommand:= SqlCommand || ' and pr.prb_cdprodutobluesoft = ' || cast(vcdprodutobluesoft as varchar(15));
		end if;

		if vdescricao != ''
		then
			SqlCommand:= SqlCommand || ' and pr.pr_descricao like ' || '''' || '%' || vdescricao  || '%' ||  '''';
		end if;
		
		if vSeleciona_Data_Cadastro
		then 
			SqlCommand:= SqlCommand || ' and b.prb_dt_cadastro between ' || '''' || vdt_cadastro_ini  || '''' || ' and ' || '''' || vdt_cadastro_fim  || '''' ;
		end if;
		
		if (vstatus_ativo = 'true' and vstatus_inativo = 'false')
		then 
			SqlCommand:= SqlCommand || ' and pr.pr_status = ' || '''' || '1' || '''';
		end if;

		if (vstatus_ativo = 'false' and vstatus_inativo = 'true')
		then 
			SqlCommand:= SqlCommand || ' and pr.pr_status = ' || '''' || '0' || '''';
		end if;
		
		if (vprd_cddepartamento > 0 )
		then
			SqlCommand:= SqlCommand || ' and dp.prd_cddepartamento = ' || cast(vprd_cddepartamento as varchar(10));
		end if;
		
		if (vprs_cdsecao > 0 )
		then
			SqlCommand:= SqlCommand || ' and sc.prs_cdsecao = ' || cast(vprs_cdsecao as varchar(10));
		end if;	

		if (vprg_cdgrupo > 0 )
		then
			SqlCommand:= SqlCommand || ' and gr.prg_cdgrupo = ' ||  cast(vprg_cdgrupo as varchar(10));
		end if;		

		if (vprsg_cdsubgrupo > 0 )
		then
			SqlCommand:= SqlCommand || ' and sg.prsg_cdsubgrupo = ' ||  cast(vprsg_cdsubgrupo as varchar(10));
		end if;		
		
		/*
		if vseleciona_data_mov_entrada
		then 
			SqlCommand:= SqlCommand || ' and pr.prb_cdprodutobluesoft in ( select 	prb_cdprodutobluesoft 
																		   from 	tbestoquecusto_entrada 
																		   where    1 = 1
																		     and    ece_nf_datarecebimento >= ' || '''' || vdt_data_entrada_ini || '''' || '
																			 and    ece_nf_datarecebimento <= ' || '''' || vdt_data_entrada_fim || '''' || '
																		   group by prb_cdprodutobluesoft 
																	     ) ';
		end if 
		;*/

		if vseleciona_data_mov_entrada
		then 
			SqlCommand:= SqlCommand || ' and pr.prb_cdprodutobluesoft in ( select 	prb_cdprodutobluesoft 
																		   from 	temp_codigos_entrada
																	     ) ';
		end if 

		;
		
		
		
		if coalesce(vpr_status_comercial_preco_inativo,0) = 1
		then 
			SqlCommand:= SqlCommand || ' and coalesce(pr.pr_status_comercial_preco_inativo,0) = 1';
		end if 
		;
		
		if coalesce(vpr_status_comercial_preco_inativo,0) = 0
		then 
			SqlCommand:= SqlCommand || ' and coalesce(pr.pr_status_comercial_preco_inativo,0) = 0 ';
		end if 
		;		
		
		SqlCommand:= SqlCommand || ' order by pr.pr_descricao asc ';
		
		----select * from tbestoquecusto_entrada
   RETURN QUERY 
   EXECUTE SqlCommand;
END;
$BODY$;

ALTER FUNCTION public.f0045_05_1012003_report_consultarpreco(integer, integer, boolean, date, date, character varying, character varying, boolean, boolean, integer, integer, integer, integer, integer, boolean, date, boolean, date, date, integer, integer)
    OWNER TO postgres;

