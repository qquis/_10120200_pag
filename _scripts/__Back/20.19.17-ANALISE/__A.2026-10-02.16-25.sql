
select 	r.cod_regras_icms 
	,	r.cod_mercadoria 
	,	c.regra_count
	,	m.descricao 
	,	r.flg_tipo_imposto
	,	r.flg_revenda 
	,	r.descricao 
	,	r.aliquota
	,	r.cst
	,	r.perc_reducao 
	,	r.dta_val_inicial
	,	r.dta_val_final
	,	r.cst_orig
	,	r.tipo_documento
	,	r.cod_class_tributaria
	,	r.per_cred_presumido_ibs_mono
	,	r.per_cred_presumido_cbs_mono
	,	r.cod_ncm_ini
	,	r.cod_ncm_final
from 	tab_regras_icms r
left join tab_mercadoria m on m.cod_mercadoria = r.cod_mercadoria 
left join (
				select cod_mercadoria 
					,	count(*) as regra_count
				from   tab_regras_icms x
				group by cod_mercadoria

) c on c.cod_mercadoria = r.cod_mercadoria 

limit 10