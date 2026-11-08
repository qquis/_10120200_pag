select lpad(preg_cdbarra,14,'0'), * 
from tbprodutoembalagem_gtins 
where lpad(preg_cdbarra,14,'0') = lpad('93613',14,'0')


BEGIN TRANSACTION;
delete from tbprodutoembalagem_gtins 
where prb_cdprodutobluesoft = 93613 
and pre_embalagem = 'CX'
AND lpad(preg_cdbarra,14,'0') = lpad('93613',14,'0')
ROLLBACK
-- COMMIT

select * from tbprodutobluesoft_gtins 
where lpad(prbg_cdbarra_pk, 14, '0') = lpad('93613',14,'0')

begin transaction;
delete 
from tbprodutobluesoft_gtins 
where lpad(prbg_cdbarra_pk, 14, '0') = lpad('93613',14,'0')
-- COMMIT

limit 10

select * from tbproduto where pr_cdproduto = 31449