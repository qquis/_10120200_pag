/* Tabelas VALIDAS PARA A OPERAÇÃO FUTURA */
select * from tbfaturamentocontrato limit 10
select * from tbfaturamentocontrato_tipo
select * from tbfaturamentocontratoproduto
select * from tbfaturamentoitenscontratos




/* 
	1) ALTERACAO DO NOME DA TABELA  
	1.1 Alteração do nome da tabela 
*/
--->>>>>> alter table tbfaturamentocontratoproduto rename to tbfaturamentocontrato_produto


/* 
	2) CONTRATOS INTEG
*/
select * from tbfaturamentoitenscontratos_integ limit 10
select * from   information_schema.columns where table_name = 'tbfaturamentoitenscontratos_integ'
select * from   information_schema.table_constraints tc  where  table_name =  'tbfaturamentoitenscontratos_integ'

alter table tbfaturamentoitenscontratos_integ drop constraint pkfaturamentoitenscontratos_integ
SELECT 
    table_schema,
    table_name,
    column_name,
    column_default,
    data_type
FROM information_schema.columns
WHERE table_name = 'tbfaturamentoitenscontratos_integ'
AND (column_default LIKE 'nextval%' OR data_type = 'bigserial' OR data_type = 'serial')
ORDER BY ordinal_position;


--->>> alter table tbfaturamentoitenscontratos_integ add seq_id serial 
--->>> alter table tbfaturamentoitenscontratos_integ add seqfaturamento int
--->>> alter table tbfaturamentoitenscontratos_integ add datafaturamento date

--->>> alter table tbfaturamentoitenscontratos_integ add constraint pkfaturamentoitenscontratos_integ primary key (seqfaturamentoorigem, contratoitem_Seq, pr_cdproduto, seq_id)

