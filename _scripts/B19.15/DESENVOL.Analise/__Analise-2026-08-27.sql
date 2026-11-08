select rt_codigo_cst_ibs_cbs as cod_sit_tributaria_ibs_cbs
 	,   
from tbfc_regrafiscal_nfce_produto limit 10






	select 		lpad(cast(x.cod_ncm as varchar(11)), 11, '0') as cod_ncm  
			,	x.cod_sit_tributaria_ibs_cbs 
			,	x.cod_class_tributaria_ibs_cbs 
			,	x.per_aliquota_ibs_uf 
			,	x.per_reducao_aliquota_ibs_uf 
			,	x.per_diferimento_ibs_mun 
			,	x.per_aliquota_ibs_mun 
			,	x.per_reducao_aliquota_ibs_mun 
			,	x.per_aliquota_cbs 
			,	x.per_diferimento_cbs 
			,	x.per_reducao_aliquota_cbs 
			,	x.per_cred_presumido_ibs_mono 
			,	x.per_cred_presumido_cbs_mono 
			,	x.info_complementar 