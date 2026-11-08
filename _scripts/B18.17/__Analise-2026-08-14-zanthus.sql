-- Active: 1773758617277@@127.0.0.1@5432@zeusretail_des
-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1758901528917@@192.168.1.6@5432-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@oxan-- Active: 1773758617277@@127.0.0.1@5432@zeusretail_des
select * from tbfaturamentozanthus 
where 1 =1
and   fat_zanthus_data_m00af = '2026-01-03'
and   fat_zanthus_sat_ecf_m00ac = 13
limit 10

		select 		
					coalesce(x.fat_zanthus_sat_ecf_m00ac ,0)
				,	x.fat_zanthus_data_m00af
				,	coalesce(x.fat_zanthus_ctlr_cupomfiscal_m00ad_atual,0)
				,	coalesce(x.fat_zanthus_ctlr_cupomfiscal_m00ad_ultimo ,0)
				,	coalesce(x.fat_zanthus_ctlr_cupomfiscal_m00ad_pendentes,0)
				,	coalesce(x.fz_cupom_qtde ,0)
				,	coalesce(x.fz_cupom_inicial ,0)
				,	coalesce(x.fz_cupom_final,0)
				,	coalesce(x.fz_valor,0)
				,	coalesce(x.fz_pag_cupom_qtde,0)
				, 	coalesce(x.fz_pag_cupom_inicial,0)
				,	coalesce(x.fz_pag_cupom_final,0)
				,	coalesce(x.fz_pag_valor,0)
				
				,	coalesce(x.fat_cupom_qtde,0)
				, 	coalesce(x.fat_cupom_inicial,0)
				,	coalesce(x.fat_cupom_final,0)
				,	coalesce(x.fat_cupom_valor,0)				
		from 		tbfaturamentozanthus_ctrl x 
		where 		1 = 1
                and fat_zanthus_data_m00af = '2026-01-03'
                and fat_zanthus_sat_ecf_m00ac = 13

select 		fa.seqfaturamento
					from	 	tbfaturamentoorigem 				o 	
					inner join  tbfaturamento						fa 	on fa.seqfaturamento = o.seqfaturamento 
					inner join  tbfaturamentozanthus				z   on z.fat_zanthus_sat_ecf_m00ac = o.sat_ecf 
									   and z.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal 
					where		1 = 1 
					  and       fa.em_cdempresa = 1
					  and 		fa.op_cdoperacao = 2 
					  and		fa.datafaturamento = '2026-01-16'
					  and		z.fat_zanthus_status_cancelado = 1
					group by 	fa.seqfaturamento

select 		f.seqfaturamento
		,	o.seqfaturamentoorigem
		,	f.datafaturamento
		,	o.sat_ecf
		,	o.cupomfiscal 
		,	count(*)
from   		tbfaturamentoitens i
inner join 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem
inner join  tbfaturamento f on f.seqfaturamento = o.seqfaturamento 
where       1 = 1
and         f.datafaturamento = '2026-01-16'
and         f.op_cdoperacao = 2
and         f.em_cdempresa = 1
--and         o.sat_ecf = 19
group by f.seqfaturamento
		,	o.seqfaturamentoorigem
		,	f.datafaturamento
		,	o.sat_ecf
		,	o.cupomfiscal 
order by    o.sat_ecf, o.cupomfiscal asc
limit 10


select * from tbfaturamentozanthus_ctrl 
where fat_zanthus_data_m00af = '2026-01-16' 
and fat_zanthus_sat_ecf_m00ac = 19




 update tbfaturamentozanthus_ctrl a
                set    fat_cupom_qtde 		= x.fat_cupom_qtde
                    ,  fat_cupom_inicial 	= x.fat_cupom_inicial
                    ,  fat_cupom_final 		= x.fat_cupom_final
                    ,  fat_cupom_valor 		= x.fat_cupom_valor
                from 	( 	select 		f.datafaturamento						as fat_zanthus_data_m00af
                                    ,	o.sat_ecf 								as fat_zanthus_sat_ecf_m00ac 
                                    ,	count(distinct(o.cupomfiscal))			as fat_cupom_qtde 
                                    ,	min(o.cupomfiscal)  					as fat_cupom_inicial
                                    ,	max(o.cupomfiscal) 						as fat_cupom_final
                                    ,	sum(i.valortotalfaturamentoliquido) 	as fat_cupom_valor
                            from 		tbfaturamento			 f
                            inner join 	tbfaturamentoorigem 	 o on o.seqfaturamento = f.seqfaturamento 
                            inner join  tbfaturamentoitens      i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
                            where		1 = 1
                            and			f.datafaturamento >= '2026-01-03'
                            and			f.datafaturamento <= '2026-01-03'
                            group by 	f.datafaturamento	
                                    ,	o.sat_ecf 
                            order by 	f.datafaturamento
                                    ,	o.sat_ecf 
                        ) x 
                where 	a.fat_zanthus_data_m00af = x.fat_zanthus_data_m00af
                and 	a.fat_zanthus_sat_ecf_m00ac = x.fat_zanthus_sat_ecf_m00ac





                

select    a.m00ac                           as fat_zanthus_sat_ecf_m00ac
                                  ,             a.m00af                           as fat_zanthus_data_m00af
                                  ,             count(coalesce(a.m00ad,0))        as fz_cupom_qtde        
                                  ,             min(coalesce(a.m00ad,0))          as fz_cupom_inicial
                                  ,             max(coalesce(a.m00ad,0))          as fz_cupom_final
                                  ,   sum(case  
                                          when A.M00Ad <> A.M45BO then 0                          
                                          else case when coalesce(a.M45BO,0) <> 0 then 0 
                                                            else  case n.tiponota 
                                                                    when 99 then 0
                                                                    when 90 then 0
                                                                    else a.M45AK
                                                                  end
                                                end 
                                      end)  as fz_valor                                           
                                  ,   cast(0 as int)                    as fz_pag_cupom_qtde        
                                  ,   cast(0 as int)                    as fz_pag_cupom_inicial     
                                  ,   cast(0 as int)                    as fz_pag_cupom_final       
                                  ,   cast(0 as numeric(13,2))          as fz_pag_valor      
                                  ,   cast(0 as int)                    as fat_cupom_qtde 
                                  ,   cast(0 as int)                    as fat_cupom_inicial
                                  ,   cast(0 as int)                    as fat_cupom_final
                                  ,   cast(0 as numeric(13,2))          as fat_valor                                                                                                               
                      from              ZAN_M45 a
                      left JOIN tab_nota_header n ON    A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF                       
                      where             1 = 1 
                        and       a.m00af >= '2026-08-02'
                        and       a.m00af <= '2026-08-02'
                      group by  a.m00ac, a.m00af 				




select peso_liquido, peso_bruto, flg_confere_peso, variacao_produto_pesado, limite_peso_minimo 
from tab_mercadoria limit 10                      


select table_name, column_name from information_schema.columns
where 1 = 1 
--and table_name = 'tab_mercadoria'
and column_name like '%larg%'
order by table_name asc

