update tbfaturamento_controle 
set processamento_pendente = 1 
where datafaturamento = '2026-10-02' 
and op_cdoperacao = 1

select processamento_pendente, * from tbfaturamento_controle where numeropedido = 512260


tbfaturamentoitensembalagem

DELETE FROM tbfaturamentoitensembalagem i
WHERE i.seqfaturamentoorigem in (
	SELECT o.seqfaturamentoorigem
	from   tbfaturamentoorigem o 
	inner join tbfaturamento f on f.seqfaturamento = o.seqfaturamento
	where f.datafaturamento = '2026-10-01'
	and   f.op_cdoperacao = 1


);

DELETE FROM tbfaturamentoitens i
WHERE i.seqfaturamentoorigem in (
	SELECT o.seqfaturamentoorigem
	from   tbfaturamentoorigem o 
	inner join tbfaturamento f on f.seqfaturamento = o.seqfaturamento
	where f.datafaturamento = '2026-10-01'
	and   f.op_cdoperacao = 1


)

select * from tbfaturamento_bluesoft where numeropedido = 513008
select fat_controle_tipo_cd,* from tbfaturamento_controle where numeropedido = 512563

/*venda*/
select * from tbfaturamentoitensembalagem where seqfaturamentoorigem = 9887896
select statusfaturamentoitem,*  from tbfaturamentoitens where seqfaturamentoorigem = 9887896

/*recusa*/
select * from tbfaturamentoitensembalagem where seqfaturamentoorigem = 9887912
select statusfaturamentoitem,* from tbfaturamentoitens where seqfaturamentoorigem = 9887912

select * from tbfaturamentostatusitem



            SELECT * FROM f0070_23_1012019_faturamentoitem_processar 
            (
                    vfaturamento_controle_seq:= 5531521
                ,       vnumeropedido:= 512563
                ,   vnumeropedido_fv:= 472962
                ,       vcdpessoabluesoft_cliente:= 28182
                ,   vop_cdoperacao:= 1
                ,   vdf_nf_seq_blue:= 1044769
            );
        
            SELECT f0070_26_1012019_faturamento_recusa_processar 
            (
                    vfaturamento_controle_seq:= 5531521
                ,       vnumeropedido:= 512563
                ,   vnumeropedido_fv:= 472962
                ,       vcdpessoabluesoft_cliente:= 28182
                ,   vop_cdoperacao:= 1
                ,   vdf_nf_seq_blue:= 1044769
            );

select * from tabzanthus_produto_composicao            





select * from tbzanthustab_regra_icms cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum)   
select * from TbZanthustab_produto_decomposicao_insum  where cod_insumo = '00000000000102044'



 select     a.pr_cdproduto
                                ,   a.prb_cdprodutobluesoft
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
                                ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                                ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                                ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
                left join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                --inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 

                                            
                and  a.cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum)   
                                         
                                    
                and  me.cod_mercadoria = '00000000000101895'

                select * from tbzanthustab_regra_icms where cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum) and cod_mercadoria = '00000000000101895'
                select * from tbzanthustab_mercadoria where cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum) and cod_mercadoria = '00000000000101895'