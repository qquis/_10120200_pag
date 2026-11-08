SELECT * FROM tbfc_regrafiscal_nfce_produto
SELECT * FROM tbfc_figurafiscal_produto


select * from tbfc_regrafiscal_nfce_produto 
select * from tbfc_cbs
select * from tbfc_class_trib_ibs_cbs
select * from tbfc_cst_ibs_cbs




select  pr.pr_cdproduto  
    ,   pr.pr_descricao 
    ,   pr.pr_status 
    ,   pr.prb_cdprodutobluesoft as prb_produtobluesoftunitario 
    ,   em.pre_embalagem
    ,   em.prb_cdprodutobluesoft
    ,   coalesce(nfce.prb_cdprodutobluesoft, 0) 
    ,   coalesce(nfce.cfop ,0) 
    ,   cast(nfce.icms_codigo_origem as varchar(1)) ||  cast(nfce.icms_codigo_tributacao as varchar(2)) as cst
    ,   nfce.icms_aliquota
    ,   nfce.icms_reducao 
    ,   nfce.cofins_cst 
    ,   nfce.cofins_aliquota
    ,   nfce.pis_cst 
    ,   nfce.pis_aliquota        
    ,   nfce.ncm_codigo 
    ,   nfce.ncm_excecao 
    ,   nfce.ncm_variacao
    ,   nfce.rt_codigo_cst_ibs_cbs
    ,   nfce.rt_codigo_class_trib_ibs_cbs 
    ,   nfce.ibs_aliquota_efetiva
    ,   nfce.cbs_aliquota_efetiva                
from        tbproduto pr
left join   tbprodutoembalagem                  em on em.pr_cdproduto = pr.pr_cdproduto
left join   tbprodutobluesoft                   pb on pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft
left join   tbfc_regrafiscal_nfce_produto     nfce on nfce.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft
left join   tbpessoabluesoft                    ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
left join   tbproduto_subgrupo                  sb on sb.prsg_cdsubgrupo = pr.prsg_cdsubgrupo
left join   tbproduto_grupo                     gr on gr.prg_cdgrupo = sb.prg_cdgrupo 
left join   tbproduto_secao                     sc on sc.prs_cdsecao = gr.prs_cdsecao
left join   tbproduto_departamento              dp on dp.prd_cddepartamento = sc.prd_cddepartamento
where       1 = 1 
and pr.pr_cdproduto = 43