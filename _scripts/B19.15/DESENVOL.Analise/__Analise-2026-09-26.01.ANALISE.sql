select * from tbintegracao_status
select * from tbintegracao_tipo
UPDATE tbintegracao_produto SET integracao_status_cd = 1 WHERE integracao_tipo_cd = 20008501



select pr_cdproduto, prb_cdprodutobluesoft, flg_revenda, flg_tipo_imposto, prb_cdprodutobluesoft, aliquota, * 
from TbZanthusTab_Regra_Icms 
where prb_cdprodutobluesoft in (223199, 223235, 223200, 223233, 223135, 223201, 223232, 223236, 223133, 223134, 218445, 223166, 223234)
order by prb_cdprodutobluesoft, flg_revenda, flg_tipo_imposto
limit 10


select prb_cdprodutobluesoft, count(*)
from TbZanthusTab_Regra_Icms 
where prb_cdprodutobluesoft in (223199, 223235, 223200, 223233, 223135, 223201, 223232, 223236, 223133, 223134, 218445, 223166, 223234)
group by prb_cdprodutobluesoft
order by prb_cdprodutobluesoft, flg_revenda, flg_tipo_imposto


 select      me.pr_cdproduto
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
                        ,	coalesce(a.aliquota,0) as aliquota
                        ,	a.cst
                        ,	a.perc_substituicao 
                        ,	coalesce(a.perc_reducao,0) as perc_reducao 
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
                        ,   a.cod_class_tributaria
                        ,   a.per_cred_presumido_ibs_mono
                        ,   a.per_cred_presumido_cbs_mono                        
                from 		 tbzanthustab_regra_icms           			 a
                inner join   TbZanthustab_produto_decomposicao_insum     me on me.cod_insumo = a.cod_mercadoria 
                --inner join   tbproduto 						   			 pr on pr.pr_cdproduto = me.pr_cdproduto 
				where		 1 = 1 
				--and   pr.pr_cdproduto != 0 
				and         a.prb_cdprodutobluesoft in (223199, 223235, 223200, 223233, 223135, 223201, 223232, 223236, 223133, 223134, 218445, 223166, 223234)


select * from tbzanthus_tributacao_produto where prb_cdprodutobluesoft in (223199, 223235, 223200, 223233, 223135, 223201, 223232, 223236, 223133, 223134, 218445, 223166, 223234)
order by 	flg_revenda, prb_cdprodutobluesoft asc



         select      --pr.pr_cdproduto
                        --,   me.prb_cdprodutobluesoft
                           a.cod_regras_icms             as  cod_regras_icms
                        ,	a.cod_loja 
                        ,	a.descricao 
                        ,	a.prioridade 
                        ,	a.flg_registro 
                        ,	a.cod_ncm_ini                 as  cod_ncm_ini
                        ,	a.cod_ncm_fim                 as  cod_ncm_final
                        ,	a.cod_mercadoria 
                        ,	a.uf_origem 
                        ,	a.uf_destino 
                        ,	coalesce(a.aliquota,0) as aliquota
                        ,	a.cst
                        ,	a.perc_substituicao 
                        ,	coalesce(a.perc_reducao,0) as perc_reducao 
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
                        ,   a.cod_class_tributaria
                        ,   a.per_cred_presumido_ibs_mono
                        ,   a.per_cred_presumido_cbs_mono                        
                from 		 tbzanthustab_regra_icms           			 a
                --inner join   TbZanthustab_produto_decomposicao_insum     me on me.cod_insumo = a.cod_mercadoria 
                --inner join   tbproduto 						   			 pr on pr.pr_cdproduto = me.pr_cdproduto 
				where prb_cdprodutobluesoft in (223199, 223235, 223200, 223233, 223135, 223201, 223232, 223236, 223133, 223134, 218445, 223166, 223234)




                select  c.carga_uuid 
                    ,   c.carga_tipo_cd
                    ,   t.carga_tipo_descricao
                    ,   c.carga_seq 
                    ,   c.carga_data 
                    ,   c.carga_status_cd
                    ,   c.carga_hora_ini 
                    ,   c.carga_hora_fim 
                    ,   c.carga_usr_seq_create
                    ,   cp.qtd_unitario
                    ,   cp.qtd_bluesoft
                    ,   cp.qtd_mercadoria
                from        tbzanthus_carga c
                inner join  tbzanthus_carga_tipo t on t.carga_tipo_cd = c.carga_tipo_cd
                inner join  tbzanthus_carga_status s on s.carga_status_cd = c.carga_status_cd 
                left join   ( select    carga_uuid
                                    ,   count(distinct (prb_cdprodutobluesoftunitario)) as qtd_unitario
                                    ,   count(distinct (prb_cdprodutobluesoft)) as qtd_bluesoft
                                    ,   count(distinct (cod_mercadoria)) as qtd_mercadoria
                              from    tbzanthus_carga_produto
                              group by carga_uuid
                ) cp on cp.carga_uuid = c.carga_uuid

select * from tbzanthus_carga_status
select * from tbprodutoembalagem

                            select      
                                       pr.pr_cdproduto
                                    ,	i.prb_cdprodutobluesoftunitario 	
                                    ,   e.prb_cdprodutobluesoft
                                    ,	m.cod_mercadoria 
                            from     	tbintegracao_produto i
                            inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoftunitario
                            inner join  tbprodutoembalagem e on e.pr_cdproduto = pr.pr_cdproduto
                            inner join  tbzanthustab_mercadoria m on m.prb_cdprodutobluesoft = e.prb_cdprodutobluesoft
                            where    	i.integracao_tipo_cd = 20008501
                            and         i.integracao_status_cd = 2
                            order by 1, 2, 3, 4 asc





    SELECT * FROM TbZanthustab_produto_decomposicao where prb_cdprodutobluesoft = 223133
    SELECT * FROM TbZanthustab_produto_decomposicao_insum where cod_mercadoria = '00000040232866739'
	SELECT * FROM TbZanthustab_produto_decomposicao_insum where cod_mercadoria = '00000000000102032'
	SELECT      i.pr_cdproduto
            ,   pb.prb_cdprodutobluesoftunitario 
            ,   i.prb_cdprodutobluesoft
            ,   i.cod_mercadoria 
    FROM        TbZanthustab_produto_decomposicao i
    inner join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
    where   pb.prb_status = 'true'


    SELECT i.pr_cdproduto
            ,   pb.prb_cdprodutobluesoftunitario 
            ,   i.prb_cdprodutobluesoft
            ,   i.cod_insumo 
    FROM        TbZanthustab_produto_decomposicao_insum i
    inner join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
    where   pb.prb_status = 'true'
      and   i.cod_mercadoria in (	
            SELECT      
                       i.cod_mercadoria 
            FROM        TbZanthustab_produto_decomposicao i
    inner join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
    where   pb.prb_status = 'true')
    order by i.pr_cdproduto
            ,   pb.prb_cdprodutobluesoftunitario 
            ,   i.prb_cdprodutobluesoft
            ,   i.cod_mercadoria 

            

