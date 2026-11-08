select * from tbfc_figurafiscal where fc_figurafiscal_descricao like 'CST 020 18 61,11 - ALIMENTOS'
SELECT * 
FROM tbfc_figurafiscal_produto 
where fc_figurafiscal_cd = 605 
and prb_cdprodutobluesoft = 43
and 

SELECT * FROM tbfc_regrafiscal_nfce_PRODUTO_TIPO
select * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 43
select nfce_produto_tipo_cd, codigo_figura_regra_fiscal, * from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = 43

select codigo_figura_regra_fiscal, nfce_produto_tipo_cd, * from tbfc_regrafiscal_nfce_produto 
where codigo_figura_regra_fiscal = 605 
and nfce_produto_tipo_cd = 3
AND prb_cdprodutobluesoft = 43
