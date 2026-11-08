select * from tbforca_venda_fab_meta
select * from tbforca_venda_fab_meta_grupo_item
select * from tbforca_venda_fab_meta_grupo
select * from tbforca_venda_fab_meta_mix where fv_fab_meta_cd = 2026001
select * from tbforca_venda_fab_meta_mix_grupo  where fv_fab_meta_cd = 2026001
select * from tbinterface
select * from tbfaturamentoitens limit 10
select * from tbforca_venda_fab_meta_mix


select * from tbforca_venda_meta where fv_meta_cd = 255

select * from tbforca_venda_meta_vendedor 
where fv_meta_cd = 255
and fv_meta_cdparticipantevendedor = 4

select max(fv_fab_meta_cd) as fv_fab_meta_cd from tbforca_venda_fab_meta
select * from tbparticipante_vendedor
select * from tbparticipante



							SELECT 	 a.cdparticipante  as cdparticipantevendedor
                                ,    v.cdpessoabluesoft
                                ,    v.nome_razao
								,    p.email_main 
								,    a.vendedor_status
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 99 then qtde_positivacao else 0 end ) as pos
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 2 then qtde_positivacao else 0 end )  as mix02	   
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 7 then qtde_positivacao else 0 end )  as mix07
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 17 then qtde_positivacao else 0 end ) as mix17
                                ,	sum(case when coalesce(fv_fab_meta_mix_cd,0) = 28 then qtde_positivacao else 0 end ) as mix28
                            from    tbparticipante_vendedor a
							left join  tbparticipante p on p.cdparticipante = a.cdparticipante
                            inner  join tbparticipante_bluesoft v on v.cdparticipante = a.cdparticipante
							left   join tbforca_venda_fab_meta_res_vendedor b on b.cdparticipantevendedor = a.cdparticipante
                            
                            where   1 = 1
                            and     b.fv_fab_meta_cd = 2026001
                            and     b.seqinterface = 0
                            group by a.cdparticipante  
                                ,    v.cdpessoabluesoft
                                ,    v.nome_razao
								,    p.email_main 
								,    a.vendedor_status

select * from tbparticipante_vendedor



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
										  and   a.cdparticipantecliente = 17845
                                          		group by cdparticipantecliente
								

								select * from tbparticipante where cpf_cnpj like '%49093172000146'

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