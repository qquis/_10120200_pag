
								select * from tbparticipante where cpf_cnpj like '%49093172000146'
                                select * from tbparticipante where cpf_cnpj like '%10957419000190'
                                16628533000152
                                select * from tbparticipante where cpf_cnpj like '%16628533000152'
                                select * from tbforca_venda_fab_meta_res_cliente_mix where cdparticipantecliente = 18408





SELECT cdparticipantecliente
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd =  2 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,2) else 0 end) as mix02
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd =  7 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,7) else 0 end) as mix07
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd = 17 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,17) else 0 end) as mix17
                                                ,	 SUM(case when a.fv_fab_meta_mix_cd = 28 then a.fv_fab_meta_grupo_cd_qtde  - coalesce(b.fv_fab_meta_mix_grupo_qtde_minima,28) else 0 end) as mix28

                                            FROM tbforca_venda_fab_meta_res_cliente_mix a
                                            left join tbforca_venda_fab_meta_mix b on a.fv_fab_meta_mix_cd = b.fv_fab_meta_mix_cd and a.fv_fab_meta_cd = b.fv_fab_meta_cd
                                            where 1 = 1 
                                          and   a.seqinterface = 0
                                          and   a.fv_fab_meta_cd = 2026001
                                          AND    A.cdparticipantecliente = 18099
                                          		group by cdparticipantecliente




















select * from tbparticipante_bluesoft where cdpessoabluesoft = 95481
select * from tbforca_venda_fab_meta_res_vendedor where cdparticipantevendedor = 9051607
select * from tbparticipante_bluesoft

select * from tbforca_venda_fab_meta_res_cliente_grupo where cdparticipantecliente = 18934
select * from tbforca_venda_fab_meta_res_cliente_mix where cdparticipantecliente = 18934

SELECT * FROM tbforca_venda_fab_meta




	select 	
			i.seqinterface
		,	i.fv_fab_meta_cd
		,	i.cdparticipantecliente 
		,   m.fv_fab_meta_mix_cd 
		,   count(distinct i.fv_fab_meta_grupo_cd)

	from 		tbforca_venda_fab_meta_res_cliente_grupo i
	inner join  tbforca_venda_fab_meta_mix_grupo m on m.fv_fab_meta_grupo_cd = i.fv_fab_meta_grupo_cd and m.fv_fab_meta_cd = i.fv_fab_meta_cd
	where   embalagemestoqueqtde > 3
	and not exists (select 1
					from 	tbforca_venda_fab_meta_res_cliente_mix r
					where 	r.seqinterface = i.seqinterface
					and 	r.fv_fab_meta_cd = i.fv_fab_meta_cd
					and 	r.cdparticipantecliente = i.cdparticipantecliente
					and 	r.fv_fab_meta_mix_cd = m.fv_fab_meta_mix_cd
				)
	group by 
			i.seqinterface
		,	i.fv_fab_meta_cd
		,	i.cdparticipantecliente 
		,   m.fv_fab_meta_mix_cd 

select * from tbinterfacefaturamentoinfoitem limit 10






select cdparticipantecliente, count(fv_fab_meta_grupo_Cd)--, embalagemestoqueqtde 
from tbforca_venda_fab_meta_res_item 
where fv_fab_meta_grupo_Cd in (3,4,5,6,7)
and  embalagemestoqueqtde >= 3
group by cdparticipantecliente
having count(fv_fab_meta_grupo_Cd) >= 4



select * from tbforca_venda_fab_meta_res_cliente_mix where cdparticipantecliente = 18934
select * from tbforca_venda_fab_meta_res_cliente_grupo where cdparticipantecliente = 18934
select * from tbforca_venda_fab_meta_res_item where cdparticipantecliente = 18934 and fv_fab_meta_grupo_Cd in (1,2,3,4,5,6,7)
select * from tbforca_venda_fab_meta_res_vendedor where cdparticipantevendedor = 9051607




   select     a.seqinterface
			,  a.fv_fab_meta_cd
			,  v.cdparticipante as cdparticipantevendedor
			,  a.cdparticipantecliente
            ,  c.nome_razao 
            ,  c.cpf_cnpj 
			,  a.fv_fab_meta_mix_cd
            ,  a.fv_fab_meta_grupo_cd_qtde

	from 		tbforca_venda_fab_meta_res_cliente_mix A
	inner join 	tbforca_venda_fab_meta_mix b on b.fv_fab_meta_cd = A.fv_fab_meta_cd and b.fv_fab_meta_mix_cd = A.fv_fab_meta_mix_cd
	inner join  tbparticipante_bluesoft    	c on c.cdparticipante = a.cdparticipantecliente
	inner join  tbparticipante_bluesoft     v on v.cdpessoabluesoft = c.cdpessoabluesoft_vendedor
	WHERE       1 = 1
	AND         a.fv_fab_meta_cd = 2026001
    and         a.cdparticipantecliente = 18934
	and          a.fv_fab_meta_mix_cd = 7
    AND         a.fv_fab_meta_grupo_cd_qtde >= b.fv_fab_meta_mix_grupo_qtde_minima
	and         v.cdparticipante = 9051607
    
    group by 
	a.fv_fab_meta_cd
			, a.seqinterface
			, a.fv_fab_meta_mix_cd
			, v.cdparticipante
    

    select * from tbforca_venda_fab_meta_mix_grupo where fv_fab_meta_cd = 2026001


    select * from tbforca_venda_meta_vendedor where fv_meta_cdparticipantevendedor = 18098 and fv_meta_cd = 252


      select 		v.fv_meta_cdparticipantevendedor 
                                        ,	v.fv_meta_cd
                                        ,   m.fv_meta_descricao 
                                        ,   COALESCE(v.fv_meta_rq_pos_minimo,0)  as fv_meta_rq_pos_minimo
                                        ,   COALESCE(v.fv_meta_rq_pos,0)  as fv_meta_rq_pos
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