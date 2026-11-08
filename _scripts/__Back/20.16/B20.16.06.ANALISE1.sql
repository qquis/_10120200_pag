select  cod_mercadoria
	,	descricao 
	,	descricao_abr
	,	cod_departamento

	,	data_cadastro
	,	data_ultima_alteracao 


	,	cfop 
	,	cod_tributacao_mercadoria 

	,	cod_situacao_tributaria 
	,	aliquota_icms
	,	percentual_reduz_b_calculo


	,	cod_sit_trib_pis
	,	aliquota_pis

	,	cod_sit_trib_cofins
	,	aliquota_cofins
		
	
from 	tab_mercadoria m
where   m.cod_mercadoria like '%428118'
