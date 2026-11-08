-- Active: 1773758617277@@127.0.0.1@5432@zeusretail_des
select  pg.m00af                            as datafaturamento
    ,   pg.m00ac                            as ecf 
    ,   pg.m00ad                            as numerocupom
    ,   A.M45XD		                		as nf_numero
    ,   coalesce(N.serie_nf,'0')            as nf_serie
    ,   a.M45XB                             as nf_chave    
    ,   pg.m04ak                            as valor 
    ,   pg.m04aw                            as valor_troco
    ,   pg.m04bx                            as valor_troco_x
    ,   pg.m04ai                            as finalizadora_cd
    ,   f.descricao                         as finalizadora_descricao
    ,   pg.m04azb                           as bandeiracd
    ,   pg.m04ba                            as sitef_codigo_autorizacao
    ,   pg.m04bbc                           as sitef_cartao_bin
    ,   pg.m04cu                            as sitef_transacao
    ,   pg.m04cz                            as sitef_credenciadora_cnpj 
    ,   pg.m04da                            as sitef_bandeira_cartao
    ,   pg.m04dl                            as sitef_tipo_cartao
    ,   pg.m04ah                            as operador_codigo
    ,   fu.nome                             as operador_nome
from        zan_m04 pg 
inner join	ZAN_M45         A on a.m00ac = pg.m00ac and a.m00ad = pg.m00ad and a.m00af = pg.m00af                                                                                            
left join   ZAN_M45         x on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad                        
left JOIN	tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF  
left join   tab_finalizadora f on f.cod_finalizadora = pg.m04ai
left join   tab_funcionario  fu on fu.cod_funcionario = pg.m04ah
WHERE 1 = 1
and   pg.m00af = '2026-07-01'
limit 100

--select cod_finalizadora, descricao from tab_finalizadora
--select * from tab_funcionario