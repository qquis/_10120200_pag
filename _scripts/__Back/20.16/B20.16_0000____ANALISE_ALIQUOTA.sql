select f0085_51_1012014_zanthusprocessamento_tributacao() 



DELETE FROM tbzanthus_tributacao_nfce_cod_tributacao
--1) INSERE OS TIPOS DE TRIBUTACOES DE/PARA COD_TRIBUTACAO_ZANTHUS
--1.1) PRIORIDADE PARA O QUE VEM DA API 
INSERT INTO tbzanthus_tributacao_nfce_cod_tributacao 
	(		cod_tributacao_pdv 
		,	icms_cst 
		,	icms_aliquota 
		,	icms_reducao 
		,	icms_aliquota_final 
		,	api_regra_fiscal
	)
select 	99, icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final , 1
from	 tbzanthus_tributacao_nfce 
where api_regra_fiscal = 1
and  not exists (
			select 1 
			from tbzanthus_tributacao_nfce_cod_tributacao tbtc
			where tbtc.icms_cst = tbzanthus_tributacao_nfce.icms_cst
			  and tbtc.icms_aliquota = tbzanthus_tributacao_nfce.icms_aliquota
			  and tbtc.icms_reducao = tbzanthus_tributacao_nfce.icms_reducao
			  and tbtc.icms_aliquota_final = tbzanthus_tributacao_nfce.icms_aliquota_final
			)
group by icms_cst, icms_aliquota, icms_reducao, icms_aliquota_final 



INSERT INTO tbzanthus_tributacao_nfce_cod_tributacao 
	(		cod_tributacao_pdv 
		,	icms_cst 
		,	icms_aliquota 
		,	icms_reducao 
		,	icms_aliquota_final 
	)
select 	99, icms_cst, icms_aliquota, icms_reducao, 0 
from	 	tbzanthus_tributacao_nfce 
where api_regra_fiscal = 0
and  not exists (
			select 1 
			from tbzanthus_tributacao_nfce_cod_tributacao tbtc
			where tbtc.icms_cst = tbzanthus_tributacao_nfce.icms_cst
			  and tbtc.icms_aliquota = tbzanthus_tributacao_nfce.icms_aliquota
			  and tbtc.icms_reducao = tbzanthus_tributacao_nfce.icms_reducao
			)
group by icms_cst, icms_aliquota, icms_reducao


update tbzanthus_tributacao_nfce_cod_tributacao set icms_aliquota_final = cast(icms_aliquota * (1 - (icms_reducao/100)) as numeric(13,2) ) 
where coalesce(api_regra_fiscal,0) = 0 
and icms_cst = '20'

update tbzanthus_tributacao_nfce_cod_tributacao set icms_aliquota_final = icms_aliquota 
where coalesce(api_regra_fiscal,0) = 0 
and icms_cst = '00'





select * from tbzanthus_tributacao_nfce_cod_tributacao WHERE ICMS_CST = '00'

	--->>> CST 000 _ 07.00% REDUCAO 0 _ COD ZANTHUS 00
	update 		tbzanthus_tributacao_nfce_cod_tributacao 
		set 	cod_tributacao_pdv = 0
	where		ICMS_CST = '00'
		and		ICMS_ALIQUOTA_FINAL = 7
		and		ICMS_REDUCAO = 0 

	;


select * from tbzanthus_tributacao_nfce_cod_tributacao







