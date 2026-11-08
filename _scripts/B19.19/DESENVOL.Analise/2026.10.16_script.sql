select * from tbforca_venda_fab_meta
select * from tbforca_venda_fab_meta_grupo_item
select * from tbforca_venda_fab_meta_grupo
select * from tbforca_venda_fab_meta_mix where fv_fab_meta_cd = 2026001
select * from tbforca_venda_fab_meta_mix_grupo  where fv_fab_meta_cd = 2026001
select * from tbinterface
select * from tbfaturamentoitens limit 10
select * from tbforca_venda_fab_meta_mix


tbforca_venda_fab_meta_cliente_grupo
tbforca_venda_fab_meta_cliente_mix


SELECT		
				F.CdParticipanteVendedor	
			,	COALESCE(g.cdgrupoeconomico,0) cdgrupoeconomico
			,   COALESCE(g.descricao, '') descricaogrupoeconomico
			,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
					 when 1010 then 'PRINCIPAL' 
					 when 1020 then 'SEMPREMIO' 
					 when 1025 then 'PREMIOINDUSTRIA' 
					 when 0 then  'OUTROS'
					 else 'OUTROS'
					 end 					
			,	count(distinct(F.CdParticipanteCliente )) as positivacao
			,	SUM(I.EmbalagemEstoqueQtde) as embalagemestoqueqtde
			,	SUM(I.EmbalagemCompraQtde) as embalagemcompraqtde
			,	SUM(I.ValorTotalFaturamento) as valortotalfaturamento

FROM		TbFaturamento				f
INNER JOIN	TbFaturamentoOrigem			o on o.SeqFaturamento = f.SeqFaturamento 
INNER JOIN	TbFaturamentoItens			i on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
INNER JOIN  tbproduto  					pr on pr.pr_cdproduto = i.pr_cdproduto 
inner join  tbprodutobluesoft		   prb on prb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
left join   tbparticipante_bluesoft      c on c.cdparticipante = f.cdparticipantecliente
left join   tbgrupoeconomico g on g.cdgrupoeconomico = c.cdgrupoeconomico
LEFT JOIN   (	select 		i.fv_fabricante_cdpessoabluesoft
						, 	i.fv_fabricante_info_tipo_cd 
						, 	t.fv_fabricante_info_tipo_descricao 
				from  tbforca_venda_fabricante_info i
				inner join   tbforca_venda_fabricante_info_tipo t on t.fv_fabricante_info_tipo_cd = i.fv_fabricante_info_tipo_cd
				where fv_fabricante_info_status = 1
				and  t.fv_fabricante_info_tipo_cd in (1010, 1025, 1020) 
				) TPF ON TPF.fv_fabricante_cdpessoabluesoft = prb.prb_cdpessoabluesoft_fabricante 
WHERE		1 = 1
AND			F.em_cdempresa = 1
AND			F.op_cdoperacao  = 1
AND			f.StatusFaturamento  = 1
and			i.StatusFaturamentoItem = 1
AND			F.DataFaturamento >= '2026-10-01'
AND			F.DataFaturamento <= '2026-10-31' 
GROUP BY		F.CdParticipanteVendedor	
			,	COALESCE(g.cdgrupoeconomico,0)
				,   COALESCE(g.descricao, '')
			,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
					 when 1010 then 'PRINCIPAL' 
					 when 1020 then 'SEMPREMIO' 
					 when 1025 then 'PREMIOINDUSTRIA' 
					 when 0 then  'OUTROS'
					 else 'OUTROS'
					 end 					



SELECT  	a.CdParticipanteVendedor
		,	v.nome_razao as nome_vendedor
		,	sum(case when fabricante = 'PRINCIPAL' then positivacao else 0 end ) as johson_positivacao
		,	sum(case when fabricante = 'PRINCIPAL' then embalagemestoqueqtde else 0 end ) as johson_embalagemestoque
		,	sum(case when fabricante = 'PRINCIPAL' then embalagemcompraqtde else 0 end ) as johson_embalagemcompra
		,	sum(case when fabricante = 'PRINCIPAL' then valortotalfaturamento else 0 end ) as johson_valortotalfaturamento

		,	sum(case when fabricante = 'SEMPREMIO' then positivacao else 0 end ) as sempremio_positivacao
		,	sum(case when fabricante = 'SEMPREMIO' then embalagemestoqueqtde else 0 end ) as sempremio_embalagemestoque
		,	sum(case when fabricante = 'SEMPREMIO' then embalagemcompraqtde else 0 end ) as sempremio_embalagemcompra
		,	sum(case when fabricante = 'SEMPREMIO' then valortotalfaturamento else 0 end ) as sempremio_valortotalfaturamento

		,	sum(case when fabricante = 'PREMIOINDUSTRIA' then positivacao else 0 end ) as premioindustria_positivacao
		,	sum(case when fabricante = 'PREMIOINDUSTRIA' then embalagemestoqueqtde else 0 end ) as premioindustria_embalagemestoque
		,	sum(case when fabricante = 'PREMIOINDUSTRIA' then embalagemcompraqtde else 0 end ) as premioindustria_embalagemcompra
		,	sum(case when fabricante = 'PREMIOINDUSTRIA' then valortotalfaturamento else 0 end ) as premioindustria_valortotalfaturamento
		,	sum(case when fabricante = 'OUTROS' then positivacao else 0 end ) as outros_positivacao
		,	sum(case when fabricante = 'OUTROS' then embalagemestoqueqtde else 0 end ) as outros_embalagemestoque
		,	sum(case when fabricante = 'OUTROS' then embalagemcompraqtde else 0 end ) as outros_embalagemcompra
		,	sum(case when fabricante = 'OUTROS' then valortotalfaturamento else 0 end ) as outros_valortotalfaturamento
FROM (
	SELECT		
					F.CdParticipanteVendedor	
				,   COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
				,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
						when 1010 then 'PRINCIPAL' 
						when 1020 then 'SEMPREMIO' 
						when 1025 then 'PREMIOINDUSTRIA' 
						when 0 then  'OUTROS'
						else 'OUTROS'
						end as fabricante 			
				,	count(distinct(F.CdParticipanteCliente )) as positivacao
				,	SUM(cast(I.EmbalagemEstoqueQtde as numeric(13,1))) as embalagemestoqueqtde
				,	SUM(cast(I.EmbalagemCompraQtde as numeric(13,1))) as embalagemcompraqtde
				,	SUM(cast(I.ValorTotalFaturamento as numeric(13,2))) as valortotalfaturamento

	FROM		TbFaturamento				f
	INNER JOIN	TbFaturamentoOrigem			o on o.SeqFaturamento = f.SeqFaturamento 
	INNER JOIN	TbFaturamentoItens			i on i.SeqFaturamentoOrigem = o.SeqFaturamentoOrigem 
	INNER JOIN  tbproduto  					pr on pr.pr_cdproduto = i.pr_cdproduto 
	inner join  tbprodutobluesoft		   prb on prb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
	left join   tbparticipante_bluesoft      c on c.cdparticipante = f.cdparticipantecliente
	left join   tbgrupoeconomico g on g.cdgrupoeconomico = c.cdgrupoeconomico
	LEFT JOIN   (	select 		i.fv_fabricante_cdpessoabluesoft
							, 	i.fv_fabricante_info_tipo_cd 
							, 	t.fv_fabricante_info_tipo_descricao 
					from  tbforca_venda_fabricante_info i
					inner join   tbforca_venda_fabricante_info_tipo t on t.fv_fabricante_info_tipo_cd = i.fv_fabricante_info_tipo_cd
					where fv_fabricante_info_status = 1
					and  t.fv_fabricante_info_tipo_cd in (1010, 1025, 1020) 
					) TPF ON TPF.fv_fabricante_cdpessoabluesoft = prb.prb_cdpessoabluesoft_fabricante 
	WHERE		1 = 1
	AND			F.em_cdempresa = 1
	AND			F.op_cdoperacao  = 1
	AND			f.StatusFaturamento  = 1
	and			i.StatusFaturamentoItem = 1
	AND			F.DataFaturamento >= '2026-10-01'
	AND			F.DataFaturamento <= '2026-10-31' 
	GROUP BY	F.CdParticipanteVendedor	

				,  	 COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
				,	case COALESCE(TPF.fv_fabricante_info_tipo_cd, 0) 
						when 1010 then 'PRINCIPAL' 
						when 1020 then 'SEMPREMIO' 
						when 1025 then 'PREMIOINDUSTRIA' 
						when 0 then  'OUTROS'
						else 'OUTROS'
						end 										 

) A
left join tbparticipante_bluesoft v on v.cdparticipante = a.CdParticipanteVendedor
group by a.CdParticipanteVendedor, v.nome_razao



select * from tbforca_venda_meta_vendedor where fv_meta_cd = 253 and fv_meta_cdparticipantevendedor = 15
SELECT * FROM TBFORCA_VENDA_META WHERE COMPETENCIA_CD = 202610
select * from tbforca_venda_fab_meta_mix
select * from tbforca_venda_fab_meta_res_vendedor
SELECT * FROM tbforca_venda_meta_info



	UPDATE      tbforca_venda_meta_vendedor A
	   set      fv_meta_rz_pos	 = MR.qtde_positivacao
			,	fv_meta_rz_qtde	 = 0
			,	fv_meta_rz_valor = 0
    FROM       (
					SELECT 	    a.cdparticipantevendedor
							,	a.qtde_positivacao 
							,   m.fv_meta_cd
					FROM 		tbforca_venda_fab_meta_res_vendedor a
					INNER JOIN  tbforca_venda_meta_info 			mi on mi.fv_fab_meta_cd = a.fv_fab_meta_cd 
																and mi.fv_fab_meta_mix_cd = a.fv_fab_meta_mix_cd
					INNER JOIN  tbforca_venda_meta 					m  on m.fv_meta_cd = mi.fv_meta_cd
					WHERE       m.competencia_cd = 202610
					AND         m.fv_meta_tipo_cd = 99 -->> DO TIPO MIX
					and         a.seqinterface = 0 ---> BASE DE DADOS REAL
				) MR 
	WHERE      A.fv_meta_cdparticipantevendedor = MR.cdparticipantevendedor
	  AND      A.fv_meta_cd = MR.fv_meta_cd

	;



select 		v.fv_meta_cdparticipantevendedor 
		,	v.fv_meta_cd
		,   m.fv_meta_descricao 
        ,   COALESCE(v.fv_meta_rq_pos,0)    as fv_meta_rq_pos     
        ,   COALESCE(v.fv_meta_rq_pos_maximo,0)  as fv_meta_rq_pos_maximo
        ,   COALESCE(v.fv_meta_rz_pos,0)         as fv_meta_rz_pos
        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde
        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde_maximo
        ,   COALESCE(v.fv_meta_rz_qtde,0)        as fv_meta_rz_qtde
        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor
        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor_maximo
        ,   COALESCE(v.fv_meta_rz_valor,0)       as fv_meta_rz_valor
        ,   COALESCE(v.fv_meta_bonus_percentual,0)    as fv_meta_bonus_percentual
from 		tbforca_venda_meta_vendedor v
inner join 	tbforca_venda_meta m on m.fv_meta_cd = v.fv_meta_cd
where       m.competencia_cd = 202610
order by    v.fv_meta_cdparticipantevendedor, v.fv_meta_cd


SELECT 	competencia_data_ini
	,	competencia_data_fim
	,   competencia_cd
FROM tbcompetencia 
where competencia_cd = 202610




  select 		v.fv_meta_cdparticipantevendedor 
                                        ,	v.fv_meta_cd
                                        ,   m.fv_meta_descricao 
                                        ,   COALESCE(v.fv_meta_rq_pos_minimo,0) as fv_meta_rq_pos_minimo
                                        ,   COALESCE(v.fv_meta_rq_pos,0)  		 as fv_meta_rq_pos
                                        ,   COALESCE(v.fv_meta_rz_pos,0)         as fv_meta_rz_pos
                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde_minimo
                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde
                                        ,   COALESCE(v.fv_meta_rz_qtde,0)        as fv_meta_rz_qtde
                                        ,   COALESCE(v.fv_meta_rq_valor_minimo,0)       as fv_meta_rq_valor_minimo
                                        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor
                                        ,   COALESCE(v.fv_meta_rz_valor,0)       as fv_meta_rz_valor
                                        ,   COALESCE(v.fv_meta_bonus_percentual,0)    as fv_meta_bonus_percentual
                                from 		tbforca_venda_meta_vendedor v
                                inner join 	tbforca_venda_meta m on m.fv_meta_cd = v.fv_meta_cd
                                where       m.competencia_cd = 202610
                                order by    v.fv_meta_cdparticipantevendedor, v.fv_meta_cd



SELECT 		ROW_NUMBER() OVER (ORDER BY fv_meta_cd) AS RO
		,	fv_meta_cd
		, 	fv_meta_descricao 
		
FROM 	tbforca_venda_meta 
WHERE 	competencia_cd = 202610
ORDER BY fv_meta_cd


SELECT 		m.fv_meta_cdparticipantevendedor
		,   sum(case when m.fv_meta_cd = 252 then fv_meta_rq_pos else 0 end) as C01_RQ
		,   sum(case when m.fv_meta_cd = 252 then fv_meta_rz_pos else 0 end) as C01_RZ
		,   sum(case when m.fv_meta_cd = 252 then fv_meta_bonus_percentual else 0 end) as C01_RQ_BONUS
		,   sum(case when m.fv_meta_cd = 252 then fv_meta_bonus_valor else 0 end) as C01_RQ_BONUS		

FROM  ( select 		v.fv_meta_cdparticipantevendedor 
                                        ,	v.fv_meta_cd
                                        ,   m.fv_meta_descricao 
                                        ,   COALESCE(v.fv_meta_rq_pos_minimo,0) as fv_meta_rq_pos_minimo
                                        ,   COALESCE(v.fv_meta_rq_pos,0)  		 as fv_meta_rq_pos
                                        ,   COALESCE(v.fv_meta_rz_pos,0)         as fv_meta_rz_pos
										,   COALESCE(v.fv_meta_rz_pos,0)         as fv_meta_rz_pos

                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde_minimo
                                        ,   COALESCE(v.fv_meta_rq_qtde,0)        as fv_meta_rq_qtde
                                        ,   COALESCE(v.fv_meta_rz_qtde,0)        as fv_meta_rz_qtde
                                        ,   COALESCE(v.fv_meta_rq_valor_minimo,0)       as fv_meta_rq_valor_minimo
                                        ,   COALESCE(v.fv_meta_rq_valor,0)       as fv_meta_rq_valor
                                        ,   COALESCE(v.fv_meta_rz_valor,0)       as fv_meta_rz_valor
                                        ,   COALESCE(v.fv_meta_bonus_percentual,0)    as fv_meta_bonus_percentual
                                from 		tbforca_venda_meta_vendedor v
                                inner join 	tbforca_venda_meta m on m.fv_meta_cd = v.fv_meta_cd
                                where       m.competencia_cd = 202610
                                order by    v.fv_meta_cdparticipantevendedor, v.fv_meta_cd
) M
group by v.fv_meta_cdparticipantevendedor


SELECT V.*
    from 		tbforca_venda_meta_vendedor v
inner join 	tbforca_venda_meta m on m.fv_meta_cd = v.fv_meta_cd
where       m.competencia_cd = 202610
order by    v.fv_meta_cdparticipantevendedor, v.fv_meta_cd



select 	* 
from 	tbparticipante_bluesoft v


select 		v.cdparticipante 
		,   b.nome_razao
		,   coalesce(fv01.fv_meta_rq_pos, 0)				 as fv01_meta_rq_pos
		,   coalesce(fv01.fv_meta_rz_pos, 0) 				 as fv01_meta_rz_pos
		,   coalesce(fv01.fv_meta_bonus_percentual, 0) 		 as fv01_meta_bonus_percentual
		,   coalesce(fv01.fv_meta_base_valor, 0)             as fv01_meta_base_valor
		,   coalesce(fv01.fv_meta_resultado_valor, 0)        as fv01_meta_resultado_valor

		,	coalesce(fv02.fv_meta_rq_qtde ,0)				 as fv02_meta_rq_qtde
		,	coalesce(fv02.fv_meta_rz_qtde, 0) 				 as fv02_meta_rz_qtde
		,	coalesce(fv02.fv_meta_bonus_percentual,0) 		 as fv02_meta_bonus_percentual
		,	coalesce(fv02.fv_meta_base_valor, 0)  			 as fv02_meta_base_valor
		,	coalesce(fv02.fv_meta_resultado_valor, 0) 		 as fv02_meta_resultado_valor

		, coalesce(fv03.fv_meta_rq_pos ,0)				     as fv03_meta_rq_pos
		, coalesce(fv03.fv_meta_rz_pos, 0) 				     as fv03_meta_rz_pos
		, coalesce(fv03.fv_meta_bonus_percentual,0) 		 as fv03_meta_bonus_percentual
		, coalesce(fv03.fv_meta_base_valor, 0)  			 as fv03_meta_base_valor
		, coalesce(fv03.fv_meta_resultado_valor, 0) 		 as fv03_meta_resultado_valor
		, coalesce(fv04.fv_meta_rq_valor, 0)				 as fv04_meta_rq_valor
		, coalesce(fv04.fv_meta_rz_valor, 0) 				 as fv04_meta_rz_valor
		, coalesce(fv04.fv_meta_bonus_percentual, 0) 		 as fv04_meta_bonus_percentual
		, coalesce(fv04.fv_meta_base_valor, 0)  			 as fv04_meta_base_valor
		, coalesce(fv04.fv_meta_resultado_valor, 0) 		 as fv04_meta_resultado_valor
		, coalesce(fv05.fv_meta_rq_qtde, 0)				     as fv05_meta_rq_qtde
		, coalesce(fv05.fv_meta_rz_qtde, 0) 				 as fv05_meta_rz_qtde
		, coalesce(fv05.fv_meta_bonus_percentual, 0) 		 as fv05_meta_bonus_percentual
		, coalesce(fv05.fv_meta_base_valor, 0)  			 as fv05_meta_base_valor
		, coalesce(fv05.fv_meta_resultado_valor, 0) 		 as fv05_meta_resultado_valor
		, coalesce(fv06.fv_meta_rq_qtde, 0)				     as fv06_meta_rq_qtde
		, coalesce(fv06.fv_meta_rz_qtde, 0) 				 as fv06_meta_rz_qtde
		, coalesce(fv06.fv_meta_bonus_percentual, 0) 		 as fv06_meta_bonus_percentual
		, coalesce(fv06.fv_meta_base_valor, 0)  			 as fv06_meta_base_valor
		, coalesce(fv06.fv_meta_resultado_valor, 0) 		 as fv06_meta_resultado_valor

		,  coalesce(fv01.fv_meta_resultado_valor, 0)  +
		   coalesce(fv02.fv_meta_resultado_valor, 0)  +
		   coalesce(fv03.fv_meta_resultado_valor, 0)  +
		   coalesce(fv04.fv_meta_resultado_valor, 0)  +
		   coalesce(fv05.fv_meta_resultado_valor, 0)  +
		   coalesce(fv06.fv_meta_resultado_valor, 0)  		as total_meta_resultado_valor

from 		tbparticipante_vendedor 	v
inner join 	tbparticipante_bluesoft 	b on b.cdparticipante = v.cdparticipante
left join   tbforca_venda_meta_vendedor fv01 on fv01.fv_meta_cdparticipantevendedor = v.cdparticipante and fv01.fv_meta_cd = 252
left join   tbforca_venda_meta_vendedor fv02 on fv02.fv_meta_cdparticipantevendedor = v.cdparticipante and fv02.fv_meta_cd = 253
left join   tbforca_venda_meta_vendedor fv03 on fv03.fv_meta_cdparticipantevendedor = v.cdparticipante and fv03.fv_meta_cd = 254
left join   tbforca_venda_meta_vendedor fv04 on fv04.fv_meta_cdparticipantevendedor = v.cdparticipante and fv04.fv_meta_cd = 255
left join   tbforca_venda_meta_vendedor fv05 on fv05.fv_meta_cdparticipantevendedor = v.cdparticipante and fv05.fv_meta_cd = 256
left join   tbforca_venda_meta_vendedor fv06 on fv06.fv_meta_cdparticipantevendedor = v.cdparticipante and fv06.fv_meta_cd = 257

where       v.vendedor_status = 1
