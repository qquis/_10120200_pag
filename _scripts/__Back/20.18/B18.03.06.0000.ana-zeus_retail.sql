

select cod_mercadoria, cod_situacao_tributaria from tab_mercadoria 

select cod_situacao_tributaria from tab_mercadoria group by cod_situacao_tributaria

select cod_mercadoria, codigo_beneficio_fiscal, * from tab_mercadoria where codigo_beneficio_fiscal != ''
select cod_mercadoria, lpad(cst,3,'0') , cst from tab_regras_icms 
where flg_tipo_imposto = '0' 
and coalesce(codigo_beneficio_fiscal,'') != ''


                              UPDATE tab_regras_icms set codigo_beneficio_fiscal = 'SP010360' 
                     where cod_mercadoria = '00000000000804127' 
                       and flg_tipo_imposto = '0' ;


     UPDATE tab_regras_icms set codigo_beneficio_fiscal = ''
                        where flg_tipo_imposto = '0'
               and lpad(cst,3,'0') not in ('040','020')					   