-- Active: 1773758617277@@127.0.0.1@5432@zeusretail_des

select column_name 
from information_schema.columns 
where 1= 1 
and table_name = 'tab_mercadoria' 
and column_name like '%peso%'
order by column_name asc


select cod_mercadoria, descricao, peso_bruto, peso_liquido from tab_mercadoria