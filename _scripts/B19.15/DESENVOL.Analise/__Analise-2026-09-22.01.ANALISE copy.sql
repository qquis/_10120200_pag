select * from tbfc_figurafiscal_produto
where coalesce(regrafiscal_nfe,0) = 0 


select nfce_produto_tipo_cd, prb_cdprodutobluesoft from tbfc_regrafiscal_nfce_produto limit 10